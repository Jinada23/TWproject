using Domain.Entities.User;
using MyProject.BusinessLogic.DbModel;
using MyProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {

        public List<UserData> GetAllUsers(string searchString, string sortType)
        {
            var userData = new List<UserData>();

            if (searchString == null && sortType != null)
            {
                using (var db = new UserContext())
                {
                    switch (sortType)
                    {
                        case "name": userData = db.Users.OrderBy(u => u.Name).Select(MapToUserData).ToList(); break;
                        case "name_desc": userData = db.Users.OrderByDescending(u => u.Name).Select(MapToUserData).ToList(); break;
                        case "type": userData = db.Users.OrderBy(u => u.Role).Select(MapToUserData).ToList(); break;
                        case "type_desc": userData = db.Users.OrderByDescending(u => u.Role).Select(MapToUserData).ToList(); break;
                        case "regDate": userData = db.Users.OrderBy(u => u.RegisterDate).Select(MapToUserData).ToList(); break;
                        case "regDate_desc": userData = db.Users.OrderByDescending(u => u.RegisterDate).Select(MapToUserData).ToList(); break;
                        default: userData = db.Users.OrderByDescending(u => u.RegisterDate).Select(MapToUserData).ToList(); break;
                    }
                }
            }
            else
            {
                if (searchString != null)
                {
                    using (var db = new UserContext())
                    {
                        switch (sortType)
                        {
                            case "name": userData = db.Users.Where(u => u.Name.Contains(searchString)).OrderBy(u => u.Name).Select(MapToUserData).ToList(); break;
                            case "name_desc": userData = db.Users.Where(u => u.Name.Contains(searchString)).OrderByDescending(u => u.Name).Select(MapToUserData).ToList(); break;
                            case "type": userData = db.Users.Where(u => u.Name.Contains(searchString)).OrderBy(u => u.Role).Select(MapToUserData).ToList(); break;
                            case "type_desc": userData = db.Users.Where(u => u.Name.Contains(searchString)).OrderByDescending(u => u.Role).Select(MapToUserData).ToList(); break;
                            case "regDate": userData = db.Users.Where(u => u.Name.Contains(searchString)).OrderBy(u => u.RegisterDate).Select(MapToUserData).ToList(); break;
                            case "regDate_desc": userData = db.Users.Where(u => u.Name.Contains(searchString)).OrderByDescending(u => u.RegisterDate).Select(MapToUserData).ToList(); break;
                            default: userData = db.Users.Where(u => u.Name.Contains(searchString)).OrderByDescending(u => u.RegisterDate).Select(MapToUserData).ToList(); break;
                        }
                    }
                }
                else
                {
                    using (var db = new UserContext())
                    {
                        userData = db.Users.OrderBy(u => u.RegisterDate).Select(MapToUserData).ToList();

                    }
                }
            }
            return userData;
        }

        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password == data.Password);

            }
            if (result == null)
            {

                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "The username or password is incorrect"
                };
            }
            return new ULoginResp { Status = true, Info = result.Info, Role = result.Role, date = result.RegisterDate, Name = result.Name };
        }


        internal ULoginResp UserRegisterAction(URegistrationData data)
        {
            UsersDbTable result;

            var user = new UsersDbTable();
            user.Name = data.Name;
            user.Username = data.Username;
            user.Password = data.Password;
            user.Info = data.Info;
            user.RegisterDate = data.RegisterDateTime;
            user.Role = data.Role;

            try
            {

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Username);
                    if (result == null)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        return new ULoginResp { Status = true };
                    }
                    else
                    {
                        return new ULoginResp
                        {
                            Status = false,
                            StatusMsg = "This email is already registred."
                        };
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }

        private UserData MapToUserData(UsersDbTable user)
        {
            return new UserData
            {
                Name = user.Name,
                Info = user.Info,
                Role = user.Role
            };
        }

        internal bool DeleteUser(ULoginData user)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == user.Username);
                if (result != null)
                {
                    db.Users.Remove(result);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

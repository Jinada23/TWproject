using Domain.Entities.User;
using MyProject.BusinessLogic.DbModel;
using MyProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Validation;
using System.Globalization;
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
        internal UserData UserData(string username)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == username);

            }
            return new UserData
            {
                Id = result.Id,
                Username = result.Username,
                Info = result.Info,
                Role = result.Role,
                date = result.RegisterDate,
                Name = result.Name,
                ImgUrl = result.ImgUrl,
                Genre = result.Genre,
                Tags = result.Tags,
                Instruments = result.Instruments,
            };
        }
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password == data.Password);

                if (result == null)
                {
                    return new ULoginResp
                    {
                        Status = false,
                        StatusMsg = "The username or password is incorrect"
                    };
                }
                else
                {
                    return new ULoginResp { Status = true };

                }
            }
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
                Id = user.Id,
                Name = user.Name,
                Info = user.Info,
                Role = user.Role,
                ImgUrl = user.ImgUrl,

            };
        }
        internal void LoadProfileInfo(string user, UserPageInputDTO input)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == user);
                if (result != null)
                {
                    if (input.ImgUrl != null) result.ImgUrl = input.ImgUrl;
                    if (input.Genre != null) result.Genre = input.Genre;
                    if (input.Tags != null) result.Tags = input.Tags;
                    if (input.Instruments != null) result.Instruments = input.Instruments;
                    db.SaveChanges();
                }
            }
        }
        internal UserData getUserByID(int userID)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Id == userID);

            }
            if (result != null)
            {
                return new UserData
                {
                    Id = result.Id,
                    Username = result.Username,
                    Info = result.Info,
                    Role = result.Role,
                    date = result.RegisterDate,
                    Name = result.Name,
                    ImgUrl = result.ImgUrl,
                    Genre = result.Genre,
                    Tags = result.Tags,
                    Instruments = result.Instruments,
                };
            }
            else
            {
                return new UserData { };
            }
        }
    }
}

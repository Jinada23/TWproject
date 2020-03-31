using AutoMapper;
using Domain.Entities.User;
using MyProject.BusinessLogic.DbModel;
using MyProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
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
                    StatusMsg = "The username or password is incorrect" };
            }
            return new ULoginResp { Status = true };
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

            //var user = _mapper.Map<URegistrationData, UsersDbTable>(data);

            try {

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
                            Status = true,
                            StatusMsg = "This username already exists."
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

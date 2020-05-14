using Domain.Entities.User;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
    public class SessionBL : ISession
    {
        private readonly UserApi userApi = new UserApi();
        private readonly AdminApi adminApi = new AdminApi();

        public ULoginResp UserLogin(ULoginData data)
        {
            return userApi.UserLoginAction(data);
        }
        public ULoginResp UserRegister(URegistrationData data)
        {
            return userApi.UserRegisterAction(data);
        }
        public List<UserData> GetAllUsers(string searchString, string sortType)
        {
            return userApi.GetAllUsers(searchString, sortType);
        }
        public bool DeleteUser(string user)
        {
            return adminApi.DeleteUser(user);
        }
        public bool AddAdmin(string user)
        {
            return adminApi.AddAdmin(user);
        }
        public void LoadProfileInfo(string user, UserPageInputDTO input)
        {
            userApi.LoadProfileInfo(user, input);
        }
        public UserData userData(string username)
        {
            return userApi.UserData(username);
        }
        public UserData getUserByID(int userID)
        {
            return userApi.getUserByID(userID);
        }
    }

}

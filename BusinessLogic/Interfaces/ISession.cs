using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
        ULoginResp UserRegister(URegistrationData data);
        List<UserData> GetAllUsers(string searchString, string sortType);
        bool DeleteUser(string user);
        bool AddAdmin(string user);
        void LoadProfileInfo(string user, UserPageInputDTO input);
        UserData userData(string username);
        UserData getUserByID(int userID);
    }
}

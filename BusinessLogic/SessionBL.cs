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

        public ULoginResp UserLogin(ULoginData data)
        {
            return userApi.UserLoginAction(data);
        }

        public ULoginResp UserRegister(URegistrationData data)
        {
            return userApi.UserRegisterAction(data);
        }

    }
}

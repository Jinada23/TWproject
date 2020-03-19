﻿using Domain.Entities.User;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public ULoginResp UserLogin(ULoginData data)
        {
            return new ULoginResp { Status = true };
        }


    }
}

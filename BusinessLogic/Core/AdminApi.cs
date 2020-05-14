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
    public class AdminApi
    {
        internal bool DeleteUser(string user)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == user);
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

        internal bool AddAdmin(string user)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == user);
                if (result != null)
                {
                    result.Role = 0;
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

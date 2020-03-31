using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class URegistrationData
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Info { get; set; }
        public DateTime RegisterDateTime { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class ULoginResp
    {
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int Role { get; set; }
        public DateTime date { get; set; }

    }
}

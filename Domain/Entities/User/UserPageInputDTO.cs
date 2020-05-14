using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class UserPageInputDTO
    {
        public string Username { get; set; }
        public string ImgUrl { get; set; }
        public string Genre { get; set; }
        public string Tags { get; set; }
        public string Instruments { get; set; }

    }
}

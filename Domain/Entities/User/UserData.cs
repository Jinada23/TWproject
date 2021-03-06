﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Info { get; set; }
        public int Role { get; set; }
        public DateTime date { get; set; }
        public string ImgUrl { get; set; }
        public string Genre { get; set; }
        public string Tags { get; set; }
        public string Instruments { get; set; }
        public bool Status { get; set; }

    }
}

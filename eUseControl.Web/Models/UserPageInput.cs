using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class UserPageInput
    {
        public string ImgUrl { get; set; }
        public ULoginResp ULoginResp { get; set; }
        public string Genre { get; set; }
        public string Tags { get; set; }
        public string Instruments { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "• The Name field is empty.")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[A-Za-z]+", ErrorMessage = "• The Name field is not a valid name.")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "• Name must be more than 4 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "• The Email field is empty.")]
        [EmailAddress(ErrorMessage = "• The Email Address field is not a valid e-mail address.")]
        [Display(Name = "Email Address")]
        [StringLength(30, ErrorMessage = "• Email must be less then 30 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "• The Password field is empty.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "• Password must be more than 5 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "• The Information field is empty.")]
        [Display(Name = "Info")]
        [StringLength(300, ErrorMessage = "• Information must be less then 300 characters.")]
        public string Info { get; set; }

    }
}
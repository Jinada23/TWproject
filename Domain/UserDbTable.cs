using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Domain.Entities.User
{
    public class UsersDbTable
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        
    [Required]
    [Display(Name = "Name")]
    [StringLength(30, MinimumLength = 4)]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Password")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "Password must be more than 8 characters")]
    public string Password { get; set; }
        
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    [StringLength(30)]
    public string Username { get; set; }

    [Required]
    [Display(Name = "Info")]
    [StringLength(300, MinimumLength = 4)]
    public string Info { get; set; }

        [DataType(DataType.DateTime)]
    public DateTime RegisterDate { get; set; }
    }
}
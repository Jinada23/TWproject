using MyProject.Domain.Entities.User;
using System.Data.Entity;

namespace MyProject.BusinessLogic.DbModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
        base("name = MyProjectDB")
        {
        }
        public virtual DbSet<UsersDbTable> Users { get; set; }
    }
}
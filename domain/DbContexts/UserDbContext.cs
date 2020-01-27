using domain.Models;
using Microsoft.EntityFrameworkCore;

namespace domain.DbContexts
{
    public class UserDbContext : DbContext
    {
        /// <summary>
        /// 用户
        /// </summary>
        /// <value></value>
        public DbSet<User> Users { get; set; }
    }
}
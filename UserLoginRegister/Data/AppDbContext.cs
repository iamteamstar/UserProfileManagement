using Microsoft.EntityFrameworkCore;
using UserLoginRegister.Models;

namespace UserLoginRegister.Data
{
    public class AppDbContext:DbContext
    {
       
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<User> Users { get; set; }
        }
    
}

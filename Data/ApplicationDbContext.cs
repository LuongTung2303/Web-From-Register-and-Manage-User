using Microsoft.EntityFrameworkCore;
using WebFormRegister.Models; // Đảm bảo namespace này đúng với nơi bạn đặt các model

namespace WebFormRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
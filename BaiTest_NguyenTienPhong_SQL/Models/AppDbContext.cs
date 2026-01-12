using Microsoft.EntityFrameworkCore;

namespace BaiTest_NguyenTienPhong_SQL.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

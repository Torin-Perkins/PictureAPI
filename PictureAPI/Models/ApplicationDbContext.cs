using Microsoft.EntityFrameworkCore;

namespace PictureAPI.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Picture> Pictures { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserFiles.Models;

namespace UserFiles.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserFiles.Models.User> User { get; set; } = default!;
        public DbSet<UserFiles.Models.File> File { get; set; } = default!;
    }
}

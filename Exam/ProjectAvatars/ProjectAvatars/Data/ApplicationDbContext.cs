using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectAvatars.Models;

namespace ProjectAvatars.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectAvatars.Models.Users> Users { get; set; } = default!;
        public DbSet<ProjectAvatars.Models.Avatar> Avatar { get; set; } = default!;
        public DbSet<ProjectAvatars.Models.Log> Log { get; set; } = default!;
    }
}

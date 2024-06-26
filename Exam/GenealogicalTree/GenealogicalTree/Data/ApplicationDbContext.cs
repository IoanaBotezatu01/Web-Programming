using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GenealogicalTree.Models;

namespace GenealogicalTree.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GenealogicalTree.Models.Users> Users { get; set; } = default!;
        public DbSet<GenealogicalTree.Models.FamilyRelations> FamilyRelations { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebExam.Models;

namespace WebExam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebExam.Models.Authors> Authors { get; set; } = default!;
        public DbSet<WebExam.Models.Documents> Documents { get; set; } = default!;
        public DbSet<WebExam.Models.Movies> Movies { get; set; } = default!;
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Subiect922.Models;

namespace Subiect922.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Subiect922.Models.Flights> Flights { get; set; } = default!;
        public DbSet<Subiect922.Models.Hotels> Hotels { get; set; } = default!;
        public DbSet<Subiect922.Models.Reservations> Reservations { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsOrders.Models;

namespace ProductsOrders.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductsOrders.Models.Product> Product { get; set; } = default!;
        public DbSet<ProductsOrders.Models.Order> Order { get; set; } = default!;
    }
}

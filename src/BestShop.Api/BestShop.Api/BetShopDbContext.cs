using BestShop.Api.Authentication;
using BestShop.Api.efConfigurations;
using BestShop.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api
{
    public class BetShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public BetShopDbContext(DbContextOptions<BetShopDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration<Product>(new ProductConfiguration());
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<OrderLine>().ToTable("OrderLines");
        }
    }
}

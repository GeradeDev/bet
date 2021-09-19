using BestShop.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.efConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasData
            (
                GetSeedProducts()
            );
        }

        private List<Product> GetSeedProducts()
        {
            return new List<Product>()
            {
                new Product(Guid.NewGuid()) { Code = "Prod001", AvailableQuantity = 10, Description = "Description for Product 1", Name = "Product 1", Price = 22.50m },
                new Product(Guid.NewGuid()) { Code = "Prod002", AvailableQuantity = 15, Description = "Description for Product 2", Name = "Product 2", Price = 23.99m },
                new Product(Guid.NewGuid()) { Code = "Prod003", AvailableQuantity = 15, Description = "Description for Product 3", Name = "Product 3", Price = 10.00m },
                new Product(Guid.NewGuid()) { Code = "Prod004", AvailableQuantity = 15, Description = "Description for Product 4", Name = "Product 4", Price = 92.00m },
                new Product(Guid.NewGuid()) { Code = "Prod005", AvailableQuantity = 15, Description = "Description for Product 5", Name = "Product 5", Price = 5.00m },
                new Product(Guid.NewGuid()) { Code = "Prod006", AvailableQuantity = 15, Description = "Description for Product 6", Name = "Product 6", Price = 40.99m },
                new Product(Guid.NewGuid()) { Code = "Prod007", AvailableQuantity = 15, Description = "Description for Product 7", Name = "Product 7", Price = 60.00m },
                new Product(Guid.NewGuid()) { Code = "Prod008", AvailableQuantity = 15, Description = "Description for Product 8", Name = "Product 8", Price = 50.89m },
                new Product(Guid.NewGuid()) { Code = "Prod009", AvailableQuantity = 15, Description = "Description for Product 9", Name = "Product 9", Price = 145.89m },
                new Product(Guid.NewGuid()) { Code = "Prod0010", AvailableQuantity = 15, Description = "Description for Product 10", Name = "Product 10", Price = 265.49m },
                new Product(Guid.NewGuid()) { Code = "Prod0011", AvailableQuantity = 15, Description = "Description for Product 11", Name = "Product 11", Price = 300.59m },
                new Product(Guid.NewGuid()) { Code = "Prod0012", AvailableQuantity = 15, Description = "Description for Product 12", Name = "Product 12", Price = 172.59m },
                new Product(Guid.NewGuid()) { Code = "Prod0013", AvailableQuantity = 15, Description = "Description for Product 13", Name = "Product 13", Price = 101.50m },
                new Product(Guid.NewGuid()) { Code = "Prod0014", AvailableQuantity = 15, Description = "Description for Product 14", Name = "Product 14", Price = 35.50m },
                new Product(Guid.NewGuid()) { Code = "Prod0015", AvailableQuantity = 15, Description = "Description for Product 15", Name = "Product 15", Price = 100.50m },
                new Product(Guid.NewGuid()) { Code = "Prod0016", AvailableQuantity = 15, Description = "Description for Product 16", Name = "Product 16", Price = 83.50m },
                new Product(Guid.NewGuid()) { Code = "Prod0017", AvailableQuantity = 15, Description = "Description for Product 17", Name = "Product 17", Price = 189.50m },
                new Product(Guid.NewGuid()) { Code = "Prod0018", AvailableQuantity = 15, Description = "Description for Product 18", Name = "Product 18", Price = 365.50m },
                new Product(Guid.NewGuid()) { Code = "Prod0019", AvailableQuantity = 15, Description = "Description for Product 19", Name = "Product 19", Price = 13.50m },
                new Product(Guid.NewGuid()) { Code = "Prod0020", AvailableQuantity = 15, Description = "Description for Product 20", Name = "Product 20", Price = 69.30m },
                new Product(Guid.NewGuid()) { Code = "Prod0021", AvailableQuantity = 15, Description = "Description for Product 21", Name = "Product 21", Price = 44.78m },
                new Product(Guid.NewGuid()) { Code = "Prod0022", AvailableQuantity = 15, Description = "Description for Product 22", Name = "Product 22", Price = 285.99m },
                new Product(Guid.NewGuid()) { Code = "Prod0023", AvailableQuantity = 15, Description = "Description for Product 23", Name = "Product 23", Price = 500.99m },
                new Product(Guid.NewGuid()) { Code = "Prod0024", AvailableQuantity = 15, Description = "Description for Product 24", Name = "Product 24", Price = 412.00m },
                new Product(Guid.NewGuid()) { Code = "Prod0025", AvailableQuantity = 15, Description = "Description for Product 25", Name = "Product 25", Price = 60.00m }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public string Price { get; set; }
    }
}

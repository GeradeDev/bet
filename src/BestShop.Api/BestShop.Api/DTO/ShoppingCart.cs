using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.DTO
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }
        public double CartTotal { get; set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }
    }

    public class CartItem
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}

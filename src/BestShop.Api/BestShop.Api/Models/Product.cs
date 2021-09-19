using BetShop.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.Models
{
    public class Product : BaseIdentifiable
    {
        public Product(Guid id) : base(id)
        {
        }

        [JsonProperty]
        public string Code { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public int AvailableQuantity { get; set; }
        [JsonProperty]
        [DefaultValue(false)]
        public bool HasMarkup { get; set; }
        [JsonProperty]
        public int? Markup { get; set; }
        [JsonProperty]
        public decimal Price { get; set; }
    }
}

using BetShop.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.Models
{
    public class OrderLine : BaseIdentifiable
    {
        public OrderLine(Guid id) : base(id)
        {
        }

        [JsonProperty]
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal LineTotal { get; set; }
    }
}

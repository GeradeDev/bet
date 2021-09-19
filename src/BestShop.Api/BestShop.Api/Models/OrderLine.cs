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
        public Guid OrderId { get; private set; }
        [Required]
        public Guid ProductId { get; private set; }
        [Required]
        public int Quantity { get; private set; }
        [Required]
        public decimal LineTotal { get; private set; }
    }
}

using BetShop.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.Models
{
    public class Order : BaseIdentifiable
    {
        public Order(Guid id) : base(id)
        {
        }

        [JsonProperty]
        [Required]
        public Guid UserId { get; private set; }
        [JsonProperty]
        [Required]
        public string OrderNo { get; private set; }
        [JsonProperty]
        [Required]
        public decimal OrderTotal { get; private set; }

    }
}

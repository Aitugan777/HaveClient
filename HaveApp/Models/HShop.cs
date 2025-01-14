using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HaveApp.Models
{
    public class HShop
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("positionX")]
        public double PositionX { get; set; }

        [JsonProperty("positionY")]
        public double PositionY { get; set; }

        [JsonProperty("sellerId")]
        public int SellerId { get; set; }
    }
}

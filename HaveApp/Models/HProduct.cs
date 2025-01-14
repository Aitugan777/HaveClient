using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace HaveApp.Models
{
    public class HProduct
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("shopId")]
        public int ShopId { get; set; }

        [JsonProperty("shop")]
        public HShop Shop { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public string ImageSource { get; set; } = "https://ir-3.ozone.ru/s3/multimedia-1-h/w1200/7007465609.jpg";


        // Команда для обработки клика
        [JsonIgnore]
        public ICommand? OnImageClickCommand { get; set; }
    }

    public class HProductPair
    {
        public HProduct Column1 { get; set; }
        public HProduct Column2 { get; set; }
    }
}

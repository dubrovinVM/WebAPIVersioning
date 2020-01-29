using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPIVersioning.Models
{
    public class Order
    {
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("productCode")]
        public string ProductCode { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class OrderExt: Order
    {
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }

        [JsonPropertyName("customerAddress")]
        public string CustomerAddress { get; set; }
    }
}

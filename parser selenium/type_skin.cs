using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium
{
    public class ItemCollection
    {
        [JsonProperty("items")]
        public Dictionary<string, Item> Items { get; set; }
    }
}

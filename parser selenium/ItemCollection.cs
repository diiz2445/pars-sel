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
        public Dictionary<string, Item> Items { get ; set; }

        public void print()
        {
            foreach (var item in Items)
            {
                Console.WriteLine(item.Key + item.Value.Buff163GoodsId.ToString());
            }
        }
        public static ItemCollection GetCollection()
        {
            string json = System.IO.File.ReadAllText("cs2_marketplaceids.json");
            ItemCollection itemCollection = JsonConvert.DeserializeObject<ItemCollection>(json);

            string[] separators = new string[] { " | " };
            foreach(var item in itemCollection.Items)
            {
                string[] str_arr_name = item.Key.Split(separators,StringSplitOptions.RemoveEmptyEntries);
                
                item.Value.Name = item.Key;
            }
            
            return itemCollection;
        }

    }

    
}

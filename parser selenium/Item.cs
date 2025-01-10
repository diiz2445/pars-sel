using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium
{
    public class Item
    {
        [JsonProperty("buff163_goods_id")]
        public int Buff163GoodsId { get; set; }//ID скина на BUFF163 из JSON

        [JsonProperty("youpin_id")]
        public int YoupinId { get; set; }

        [JsonProperty("buff163_sticker_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Buff163StickerId { get; set; }//ID стикера на BUFF163 из JSON (нужно переписать будет для стикеров отдельную структуру)

        public String Name { get; set; }
        public String type { get; set; }
    }
    
}

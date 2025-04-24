using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium.Core.steam_market
{
    internal class Urls
    {
        static Dictionary<string,uint> GameID = new Dictionary<string, uint>
        {
            {"ETS2",22730 }
        };
        [JsonProperty ("ETS2_urls")]
        static Dictionary<string, string> ETS2 = new Dictionary<string, string> {
                { "Decorative Cab Lights Assortment", "https://steamcommunity.com/market/listings/227300/Decorative%20Cab%20Lights%20Assortment" },
                {"Decorative Cab Lights","https://steamcommunity.com/market/listings/227300/Decorative%20Cab%20Lights" },
                {"Pit Stop","https://steamcommunity.com/market/listings/227300/Pit%20Stop" },
                {"Crystal Dimension","https://steamcommunity.com/market/listings/227300/Crystal%20Dimension" },
                {"Driving the Future","https://steamcommunity.com/market/listings/227300/Driving%20the%20Future" },
                {"Nature's Embrace (Trailer)","https://steamcommunity.com/market/listings/227300/Nature%27s%20Embrace%20%28Trailer%29" },
                {"Nature's Embrace (Truck)","https://steamcommunity.com/market/listings/227300/Nature%27s%20Embrace%20%28Truck%29" },
                {"Terra Constructor","https://steamcommunity.com/market/listings/227300/Terra%20Constructor" },
                {"On top of the world","https://steamcommunity.com/market/listings/227300/On%20top%20of%20the%20world" },
                {"Viking Warrior","https://steamcommunity.com/market/listings/227300/Viking%20Warrior" },
                {"Golden Stag","https://steamcommunity.com/market/listings/227300/Golden%20Stag" },
                {"Starlight Burst (Truck)","https://steamcommunity.com/market/listings/227300/Starlight%20Burst%20%28Truck%29" },
                {"Starlight Burst (Trailer)","https://steamcommunity.com/market/listings/227300/Starlight%20Burst%20%28Trailer%29" },
                {"Winter Blast","https://steamcommunity.com/market/listings/227300/Winter%20Blast" },
                {"Lines of Reflection (Trailer)","https://steamcommunity.com/market/listings/227300/Lines%20of%20Reflection%20%28Trailer%29" },
                {"Midnight Dolphin","https://steamcommunity.com/market/listings/227300/Midnight%20Dolphin" },
                {"Lines of Reflection (Truck)","https://steamcommunity.com/market/listings/227300/Lines%20of%20Reflection%20%28Truck%29" },
                {"Slipstream","https://steamcommunity.com/market/listings/227300/Slipstream" }

            };
        public static Dictionary<string,string> GetETS2URLs()
        {
            return ETS2;
        }
    }
}

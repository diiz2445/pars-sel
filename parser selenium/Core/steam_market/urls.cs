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
                {"Pit Stop","https://steamcommunity.com/market/listings/227300/Pit%20Stop" }

            };
        public static Dictionary<string,string> GetETS2URLs()
        {
            return ETS2;
        }
    }
}

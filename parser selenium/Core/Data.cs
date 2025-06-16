using parser_selenium.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium.Core
{
    internal class Data
    {
        /*
         * "(" = "%28"
         * ")" = "%29"
         * " " = "%20"
         * "|" = "%7C"
         * "-" = "%20"
         */
        List<string> quality = new List<string>
        {
            "Factory-New",
            "Minimal-Wear",
            "Field-Tested",
            "Well-Worn",
            "Battle-Scarred"
        };
        List<Item> items = new List<Item>();
        public async void init()
        {
            items = await importData.GetItemsAsync("CSGODB.json");
        }
    }
    internal class Item
    {

        string name;
        public string Name { get => name; set { name = value; } }

        string rarity;
        public string Rarity { get => rarity; set { rarity = value; } }

        string collection;
        public string Collection { get => collection; set { collection = value; } }

        string introduced;
        public string Introduced { get => introduced; set { introduced = value; } }
    }
}

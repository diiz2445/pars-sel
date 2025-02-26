using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using parser_selenium.Core.steam_market;
using System.Runtime.Serialization;

namespace parser_selenium
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Class_for_parse_names parse_names = new Class_for_parse_names();
            //parse_names.b();

            //Dictionary<string, int> x = Class_for_parse_names.deserialize();
            //Console.ReadLine();


            //ParseCsMoney parseCsMoney = new ParseCsMoney();
            //parseCsMoney.GetNames();
            //DB dB = new DB();
            string json = System.IO.File.ReadAllText("cs2_marketplaceids.json");
            Console.WriteLine("readed");
            ItemCollection itemCollection = JsonConvert.DeserializeObject<ItemCollection>(json);
            //itemCollection.print();
            

            WebRequest request = WebRequest.Create("https://www.steamwebapi.com/steam/api/item?key=APIKEY&market_hash_name=AK-47%20%7C%20Redline%20(Field-Tested)");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            item_info item = JsonConvert.DeserializeObject<item_info>(responseText);
            Console.ReadLine();
            
        }
    }
}
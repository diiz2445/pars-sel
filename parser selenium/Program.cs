using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.Json;
using System.Text.Json.Nodes;

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
            itemCollection.print();
            
            Console.ReadLine();


        }
    }
}
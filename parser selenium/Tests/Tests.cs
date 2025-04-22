using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parser_selenium.Tests;
using System.Text.Json;
using Newtonsoft.Json;


namespace parser_selenium.Tests
{
    internal class Tests
    {
        public static void TestCSM()
        {
            Class_for_parse_names parse_names = new Class_for_parse_names();
            parse_names.b();

            //Dictionary<string, int> x = Class_for_parse_names.deserialize();
            //Console.ReadLine();


            ParseCsMoney parseCsMoney = new ParseCsMoney();
            parseCsMoney.GetNames();
            DB dB = new DB();
            string json = System.IO.File.ReadAllText("cs2_marketplaceids.json");
            Console.WriteLine("readed");
            ItemCollection itemCollection = JsonConvert.DeserializeObject<ItemCollection>(json);
            itemCollection.print();
        }
    }
}

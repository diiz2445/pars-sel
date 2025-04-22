using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parser_selenium.Tests;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;

namespace parser_selenium.Tests
{
    internal class Test
    {
        public static void TestCSM()
        {
            
            

            ParseCsMoney parseCsMoney = new ParseCsMoney();
            parseCsMoney.GetNames();
            string json = File.ReadAllText("cs2_marketplaceidds.json");
            Console.WriteLine("readed");
            ItemCollection itemCollection = JsonConvert.DeserializeObject<ItemCollection>(json);
            itemCollection.print();
        }
        public static void TestBuff() 
        {
            Class_for_parse_names parse_Names = new Class_for_parse_names();
            parse_Names.deserialize();
            parse_Names.Parse();

        }

    }
}

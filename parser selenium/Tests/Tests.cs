using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parser_selenium.Tests;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;
using parser_selenium.TG_BOT;
using parser_selenium.Imports;

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
        public static async Task TestBuff() 
        {
            string path = "codes.json";
            Class_for_parse_names parse_Names = new Class_for_parse_names();
            Dictionary<string,int> data = await importData.DeserializeDictAsync(path);
            parse_Names.Parse();
            Console.WriteLine($"Count = {parse_Names.names.Count()}");

        }
        public static async Task TestBot()
        {
            Bot bot = new Bot();
            await Bot.Run();
        }

    }
}

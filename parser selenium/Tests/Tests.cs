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
using parser_selenium.Core.steam_market;
using parser_selenium.Core.Buff;
using parser_selenium.Core.CSDB;
using parser_selenium.Core;


namespace parser_selenium.Tests
{
    internal class Test
    {
        public static async Task TestCSM()
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
            BuffParse parse_Names = new BuffParse();
            Dictionary<string,int> data = await Imports.Data.DeserializeDictAsync(path);
            await parse_Names.Parse();
            Console.WriteLine($"Count = {parse_Names.names.Count()}");

        }
        public static async Task TestBot()
        {
            Bot bot = new Bot();
            await Bot.Run();
        }
        public static async Task TestSerialize()
        {
            string path = "urls.json";
            var obj = new Urls();
            await Imports.Data.SerializeAsync(path,obj);

            Urls obj2 = await Imports.Data.DeserializeUrlsAsync(path);
        }
        public static async Task TestMarket()
        {
            MarketParse marketParse = new MarketParse();
            await marketParse.GetNotifyAllItemsString();
        }
        public static async Task TestCSGODB()
        {
            CSGODB_Parse cSGODB_Parse = new CSGODB_Parse();
            await cSGODB_Parse.Parse();
        }
        public static async Task TestGetURL()
        {
            Core.Data data = new Core.Data();
            Console.WriteLine(MarketParse.GetURL("CS", data.items[0], data.quality[0]));
        }

    }
}

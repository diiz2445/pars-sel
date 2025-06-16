using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using parser_selenium.Core.steam_market;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using parser_selenium.Tests;
using parser_selenium.Core;
using parser_selenium.TG_BOT;

namespace parser_selenium
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Data data = new Data();
            data.init();
            //Test.TestSerialize();
            //await Test.TestBot();
            //await Test.TestMarket();
            await Test.TestCSGODB();
            await Test.TestCSM();
            await Test.TestBuff();
            HttpClient httpClient = new HttpClient();
            Uri.TryCreate("https://www.steamwebapi.com/steam/api/item?key=OTWUI9X5EHED2V39&market_hash_name=AK-47%20%7C%20Redline%20(Field-Tested)",0,out Uri result);
            httpClient.BaseAddress = result;


            //HttpResponseMessage response = await httpClient.GetAsync("https://www.steamwebapi.com/steam/api/item?key=OTWUI9X5EHED2V39&market_hash_name=AK-47%20%7C%20Redline%20(Field-Tested)");
            //string msg = await response.Content.ReadAsStringAsync();
            //Console.WriteLine($"{msg}");
            //item_info_CS info= JsonConvert.DeserializeObject<item_info_CS>(msg);
            //Console.WriteLine(info);
            


            //WebRequest request = WebRequest.Create("https://www.steamwebapi.com/steam/api/item?key=OTWUI9X5EHED2V39&market_hash_name=AK-47%20%7C%20Redline%20(Field-Tested)");
            //WebResponse response = request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());
            //string responseText = reader.ReadToEnd();
            //item_info item = JsonConvert.DeserializeObject<item_info>(responseText);
            Console.ReadLine();
            
        }
    }
}
using Newtonsoft.Json;
using parser_selenium.Core.steam_market;
using parser_selenium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium.Imports
{
    internal class Data
    {
        public static async Task SerializeAsync(string path, object obj)
        {
            Console.WriteLine("Ser");
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
            Console.WriteLine("Ser done");
        }
        public static async Task<Dictionary<string,int>> DeserializeDictAsync(string path)
        {
            Console.WriteLine("Deser");
            string st = File.ReadAllText(path);
            Dictionary<string, int> names = JsonConvert.DeserializeObject< Dictionary<string, int>>(st);
            Console.WriteLine("Deser done");
            return names;
        }
        public static async Task<Urls> DeserializeUrlsAsync(string path)
        {
            string st = File.ReadAllText(path);
            Urls obj = JsonConvert.DeserializeObject<Urls>(st);
            
            return obj;
        }
        public static List<Item> GetItems(string path)
        {
            string st = File.ReadAllText(path);
            List<Item> obj = JsonConvert.DeserializeObject<List<Item>>(st);

            return obj;
        }

        public static string importToken()
        {
            return File.ReadAllText("token.txt");
        }
    }
}

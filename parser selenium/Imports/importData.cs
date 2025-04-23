using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium.Imports
{
    internal class importData
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
        public static string importToken()
        {
            return File.ReadAllText("token.txt");
        }
    }
}

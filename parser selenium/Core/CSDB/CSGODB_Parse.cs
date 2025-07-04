using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using parser_selenium.Imports;
using parser_selenium.Core.steam_market;
using System.Text.Json.Nodes;

namespace parser_selenium.Core.CSDB
{
    internal class CSGODB_Parse
    {
        string URL_skins = "https://www.csgodatabase.com/skins/";
        string URL_weapon = "https://www.csgodatabase.com/weapons/";
        IWebDriver driver;
        List<Item> items = new List<Item>();
        
        public CSGODB_Parse() { }
        public CSGODB_Parse(string path)
        {
            items= Imports.Data.GetItems(path);
        }
        /// <summary>
        /// Base func for https://www.csgodatabase.com/skins/
        /// </summary>
        public async Task Parse()
        {
            driver = new ChromeDriver();
            Data data = new Data();
            driver.Url = URL_skins;
            List<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"post-23\"]/section/table[3]/tbody/tr")).ToList();
            
            foreach (IWebElement element in elements)
            {
                Item item = new Item();
                IWebElement[] tmp = element.FindElements(By.TagName("td")).ToArray();
                
                item.Name = InsertPipeAfterMatches( tmp[0].Text,data.Weapons);
                item.Rarity = tmp[1].Text;
                item.Collection = tmp[2].Text;
                item.Introduced = tmp[3].Text;
                foreach(string quality in data.Quality)
                {
                    item.SteamURLs.Add(quality,MarketParse.GetURL("CS", item, quality));
                }
                
                items.Add(item);
            }
            Imports.Data.SerializeAsync("CSGODB.json", items);
        }
        
        public async Task ReworkNames()
        {
            Data data = new Data();
            foreach(Item item in items)
            {
                item.Name = InsertPipeAfterMatches(item.Name, data.Weapons);
            }
            await Imports.Data.SerializeAsync("CSGODB.json", items);
        }
        public static string InsertPipeAfterMatches(string input, List<string> patterns)
        {
            StringBuilder result = new StringBuilder(input);

            // Проходим по каждому паттерну
            foreach (var pattern in patterns)
            {
                int index = 0;
                // Ищем все вхождения паттерна
                while (index <= result.Length - pattern.Length)
                {
                    index = result.ToString().IndexOf(pattern, index, StringComparison.Ordinal);
                    if (index == -1) break;

                    // Проверяем, чтобы после паттерна не было уже '|'
                    if (index + pattern.Length < result.Length && result[index + pattern.Length] != '|')
                    {
                        // Вставляем '|' после паттерна
                        result.Insert(index + pattern.Length, " |");
                    }
                    index += pattern.Length + 1; // Перемещаем индекс за паттерн и '|'
                }
            }

            return result.ToString();
        }
        public async Task ParseWeapon()
        {
            driver.Url = URL_weapon;
            List<IWebElement> elements = driver.FindElements(By.ClassName("row")).ToList();
            StringBuilder ctrlc = new StringBuilder( "{\n");
            foreach (IWebElement element in elements)
            {

                ctrlc.Append($"{element.Text},\n");
            }

            Console.WriteLine(ctrlc.ToString());
            
        }
        public async Task AddSteamURL()
        {
            Data data = new Data();
            List<Item> items = Imports.Data.GetItems("CSGODB.json");
            foreach (Item item in items)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (string quality in data.Quality)
                {
                    values.Add(quality, MarketParse.GetURL("CS", item, quality));
                }
                item.SteamURLs = values;

            }
            await Imports.Data.SerializeAsync("CSGODB.json", items);
        }
        public async Task AddPrices()
        {
            IWebDriver driver = new EdgeDriver();
            foreach (Item item in items)
            {
                if (item.Prices == null)
                    item.Prices = new Dictionary<string, double>();
                Core.Data data = new Core.Data();
                foreach (string quality in data.Quality)
                {
                    try
                    {
                        item.Prices.Add(quality, MarketParse.ParseSellPrice(item.SteamURLs[quality], driver));
                        Console.WriteLine($"{item.Name}({quality}) = {item.Prices.ToString()}");
                    }
                    catch { Console.WriteLine("already taken"); }
                    
                }
                await Imports.Data.SerializeAsync("CSGODB.json", items);
                Thread.Sleep(40000);
            }
            
        }
    }
    
    
}

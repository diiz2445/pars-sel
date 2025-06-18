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

namespace parser_selenium.Core.CSDB
{
    internal class CSGODB_Parse
    {
        string URL_skins = "https://www.csgodatabase.com/skins/";
        string URL_weapon = "https://www.csgodatabase.com/weapons/";
        IWebDriver driver = new ChromeDriver();
        List<Item> items = new List<Item>();
        public async Task Parse(string url)
        {
             
        }

        /// <summary>
        /// Base func for https://www.csgodatabase.com/skins/
        /// </summary>
        public async Task Parse()
        {
            Data data = new Data();
            driver.Url = URL_skins;
            List<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"post-23\"]/section/table[3]/tbody/tr")).ToList();
            
            foreach (IWebElement element in elements)
            {
                Item item = new Item();
                IWebElement[] tmp = element.FindElements(By.TagName("td")).ToArray();
                
                item.Name = tmp[0].Text;
                item.Rarity = tmp[1].Text;
                item.Collection = tmp[2].Text;
                item.Introduced = tmp[3].Text;
                foreach(string quality in data.quality)
                {
                    item.SteamURLs.Add(quality,MarketParse.GetURL("CS", item, quality));
                }
                
                items.Add(item);
            }
            importData.SerializeAsync("CSGODB.json", items);
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
            List<Item> items = importData.GetItems("CSGODB.json");
            foreach (Item item in items)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (string quality in data.quality)
                {
                    values.Add(quality, MarketParse.GetURL("CS", item, quality));
                }
                item.SteamURLs = values;

            }
            await importData.SerializeAsync("CSGODB.json", items);
        }
    }
    
    
}

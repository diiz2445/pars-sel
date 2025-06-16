using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using parser_selenium.Imports;

namespace parser_selenium.Core.CSDB
{
    internal class CSGODB_Parse
    {
        string URL_skins = "https://www.csgodatabase.com/skins/";
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
               
                items.Add(item);
            }
            importData.SerializeAsync("CSGODB.json", items);
        }
    }
    
    
}

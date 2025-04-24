using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium.Core.steam_market
{
    internal class MarketParse
    {
        IWebDriver driver = new EdgeDriver();
        Dictionary<string, string[,]> items;

        public MarketParse() { }
        public async Task ParseETS()
        {

            items = new Dictionary<string, string[,]>();
            Dictionary<string,string> urls = Urls.GetETS2URLs();
            foreach (var url in urls)
            {
                items.Add(url.Key,ParsePage(url.Value));
                Thread.Sleep(10 * 1000);
            }
            
        }
        public string[,] ParsePage(string url) 
        {
           
            driver.Url = url;
            List<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"market_commodity_forsale_table\"]/table/tbody/tr")).ToList();
            string[,] items = new string[5,2];//[Count Elements,0 - Price|1 - Count]
            int IndexURL = 0;
            //foreach(IWebElement element in elements)
            for(int i=1;i<elements.Count-1;i++)
            {
                IWebElement element = elements[i];
                items[i-1,0] = element.Text.Split(' ')[0].Remove(0,1);//price without '$'
                items[i-1,1] = element.Text.Split(' ')[1];//Count of items with current price
                Console.WriteLine(element.Text);
                

            }
            return items;
        }
        public async Task<string> GetNotifyAllItemsString()
        {
            StringBuilder sb = new StringBuilder() ;
            ParseETS();

            foreach (var item in items)
            {
                sb.Append($"*Item:* {item.Key.ToString()}\n*Prices:*");
                
                    for(int i = 0; i < item.Value.GetLength(0);i++)
                    {
                        sb.AppendLine($"{i+1}. {item.Value[i,0]} | {item.Value[i,1]}");
                    }
                
            }

            Console.WriteLine(sb);
            return sb.ToString();
        }


    }
}

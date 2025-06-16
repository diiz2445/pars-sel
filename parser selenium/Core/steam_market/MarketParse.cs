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
        Dictionary<string, string[][,]> items;
        double[] margins;
        public MarketParse() { }
        public async Task ParseETS()//парсинг страниц ETS2
        {

            items = new Dictionary<string, string[][,]>();
            Dictionary<string,string> urls = Urls.GetETS2URLs();
            foreach (var url in urls)
            {
                items.Add(url.Key,ParsePage(url.Value));
                Thread.Sleep(10 * 1000);
            }
            driver.Quit();
            margins = CalculateMargin();
        }
        public string[][,] ParsePage(string url)//Парсинг одной страницы на маркете 
        {
           
            driver.Url = url;
            Thread.Sleep(100);

            List<IWebElement> elementsForSale = new List<IWebElement>();
            List<IWebElement> elementsForBuy = new List<IWebElement>();
            string[][,] items = new string[2][,];//0 - sale, 1 - buy
            while (elementsForSale.Count == 0)
            {
                elementsForSale = driver.FindElements(By.XPath("//*[@id=\"market_commodity_forsale_table\"]/table/tbody/tr")).ToList();
                elementsForBuy = driver.FindElements(By.XPath("//*[@id=\"market_commodity_buyreqeusts_table\"]/table/tbody/tr")).ToList();

            }
            items[0] = new string[5,2];//[Count Elements,0 - Price|1 - Count]
            items[1] = new string[5, 2];//[Count Elements,0 - Price|1 - Count]

            //foreach(IWebElement element in elements)
            for (int i=1;i<elementsForSale.Count-1;i++)
            {
                IWebElement elementForSale = elementsForSale[i];
                IWebElement elementForBuy = elementsForBuy[i];
                
                //sell
                items[0][i-1,0] = elementForSale.Text.Split(' ')[0].Remove(0,1);//price without '$'
                items[0][i-1,1] = elementForSale.Text.Split(' ')[1];//Count of items with current price

                //Buy
                items[1][i - 1, 0] = elementForBuy.Text.Split(' ')[0].Remove(0, 1);//price without '$'
                items[1][i - 1, 1] = elementForBuy.Text.Split(' ')[1];//Count of items with current price
                //Console.WriteLine("Sell:\n"+elementForSale.Text+"\n");
                //Console.WriteLine("Buy:\n"+elementForBuy.Text+"\n");
                

            }
            
            return items;
        }
        public async Task<string> GetNotifyAllItemsString()
        {
            Console.WriteLine("Start GetNotify");
            StringBuilder sb = new StringBuilder() ;
            await ParseETS();
            Console.WriteLine("EndParse");
            int k = 0;
            foreach (var item in items)
            {
                Console.WriteLine("AppndItemSell");
                sb.Append($"*Item:* {item.Key.ToString()}\n*sell:*\n");
                
                for(int i = 0; i < item.Value[0].GetLength(0);i++)
                {
                    sb.AppendLine($"{i+1}. {item.Value[0][i,0]} | {item.Value[0][i,1]}");
                }
                sb.AppendLine($"\n*buy:*");

                for (int i = 0; i < item.Value[0].GetLength(0); i++)
                {
                    sb.AppendLine($"{i + 1}. {item.Value[1][i, 0]} | {item.Value[1][i, 1]}");
                }
                sb.AppendLine($"*Margin:*\n{margins[k]:f2}");
                k++;
                sb.AppendLine();
            }
            
            Console.WriteLine("End Getnotify");
            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }
        private double[] CalculateMargin()
        {
            double[] margin = new double[items.Count];
            int i = 0;
            foreach (var item in items)
            {
                double sell = Convert.ToDouble((item.Value[0][0,0]).Replace('.',','))*0.87;
                double buy = Convert.ToDouble((item.Value[1][0, 0]).Replace('.', ','));
                margin[i] = (sell/buy)-1;
                i++;
            }
            return margin;
        }
        public static string GetURL(string game,Item item, string quality)
        {
            Data data = new Data();
            string name = $"{item.Name} ({quality})";
            foreach(var currentReplace in data.URL_Replaces)
            {
                name = name.Replace(currentReplace.Key, currentReplace.Value);
            }

            string URL = new string($"https://steamcommunity.com/market/listings/{Urls.GameID["CS"].ToString()}/{name}");
            return URL;
        }
    }
}

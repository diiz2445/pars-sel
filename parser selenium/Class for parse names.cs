using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium
{

    internal class Class_for_parse_names
    {
        string info;
        Dictionary<string, int> names;

        public Class_for_parse_names()
        {
            names = new Dictionary<string, int>();
        }

        public static void b()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Minimize();
            driver.Url = "https://buff.163.com/market/csgo";
            List<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"j_list_card\"]/ul/li/h3/a")).ToList();
            List<IWebElement> codes = driver.FindElements(By.XPath("//*[@id=\"j_list_card\"]/ul/li/h3")).ToList();

            foreach (IWebElement element in codes)
            {
                Console.WriteLine(element.Text);
                Console.WriteLine(element.GetAttribute("href"));
            }
        }
        
    }
}
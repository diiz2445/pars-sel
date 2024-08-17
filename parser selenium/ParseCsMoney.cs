using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace parser_selenium
{
    class inf
    {
        string name;
        string href;
    }
    internal class ParseCsMoney
    {
        string[] _name = new string[55];
        string[] _href = new string[55];
        public ParseCsMoney()
        {
        }
        public void GetNames()
        {
            int i;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Url = "https://wiki.cs.money/weapons/ak-47";
            driver.Url = "https://wiki.cs.money";

            {
                IWebElement[] ShowAllClick = driver.FindElements(By.ClassName("zydijptxtdznttzttbpqclfdht")).ToArray();

                for (i = 0; i < 5; i++)
                {
                    ShowAllClick[i].Click();
                }
            }
            
            IWebElement[] hf = new IWebElement[55];
            for(int j=0; j<55; j++)
                for(i=0;i<30;i++)
                {
                    try
                    {   
                        hf[i] = driver.FindElement(By.XPath($"//*[@id=\"skins\"]/div[{j+1}]/div[2]/div[{i + 1}]/a"));
                        _name[i] =hf[i].Text.Split("\r")[0];
                        _href[i] = hf[i].GetAttribute("href");
                        Console.WriteLine($"name: {_name[i]}\nhf = {_href[i]}");
                    }
                    catch { }
                }
            i = 0;
            

        }
        public void ParseUrl()
        {
            
        }

       
    }
}

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
    internal class ParseCsMoney
    {
        List<string> _Names;
        List<string> Types;

        public ParseCsMoney()
        {
            _Names = new List<string>();
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
            IWebElement[] names = driver.FindElements(By.ClassName("yuevqsquaveulqpticinqpvght")).ToArray();
            string[,] info = new string[100,4];
            IWebElement[] href = driver.FindElements(By.ClassName("itixalfiylvsvmdssbpcdzfawb")).ToArray();
            string[] qq = new string[names.Length];
            IWebElement[] hf = new IWebElement[names.Length];
            for(int j=0; j<names.Length; j++)
                for(i=0;i<30;i++)
                {
                    try
                    {
                        hf[i] = driver.FindElement(By.XPath($"//*[@id=\"skins\"]/div[{j}]/div[2]/div[{i + 1}]/a"));
                        Console.WriteLine($"name: {hf[i].Text}\nhf = {hf[i].GetAttribute("href")}");
                    }
                    catch { }
                }

            i = 0;
            

        }
        public void ParseUrl()
        {
            
        }

        public void serialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("codes.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _Names);

                Console.WriteLine("Объект сериализован");
            }
        }
        public static Dictionary<string, int> deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("codes.txt", FileMode.Open))
            {
                Dictionary<string, int> newNames = (Dictionary<string, int>)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Info: {newNames}");
                return newNames;
            }
        }
    }
}

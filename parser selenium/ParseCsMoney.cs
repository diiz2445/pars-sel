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
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Url = "https://wiki.cs.money/weapons/ak-47";
            driver.Url = "https://wiki.cs.money";
            //IWebElement el = driver.FindElement(By.XPath("//*[@id=\"skins\"]/div[2]/div[2]/div/div[1]/div/a/div[2]"));

            string[] type = driver.FindElement(By.XPath("//*[@id=\"skins\"]/div[1]/div[1]/div[2]")).Text.Split("\r\n");
            
            Console.WriteLine(type);
            


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

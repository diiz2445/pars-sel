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
            //var options = new ChromeOptions();
            //options.AddArgument("--ignore-certificate-errors");
            //options.AddArgument("--ignore-ssl-errors");
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Minimize();
            driver.Url = "https://wiki.cs.money/weapons/ak-47";
            List<IWebElement> elements = driver.FindElements(By.ClassName("kxmatkcipwonxvwweiqqdoumxg")).ToList();
            //try { _Names = deserialize(); Console.WriteLine("начальная сер пройдено"); }
            //catch { }


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

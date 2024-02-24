using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace parser_selenium
{
    [Serializable]
    internal class Class_for_parse_names
    {
        
        public Dictionary<string, int> names;

        public Class_for_parse_names()
        {
            names = new Dictionary<string, int>();
        }

        public void b()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Minimize();
            driver.Url = "https://buff.163.com/market/csgo";
            List<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"j_list_card\"]/ul/li/h3/a")).ToList();
            try { names = deserialize(); Console.WriteLine("начальная сер пройдено"); }
            catch { }
            foreach (IWebElement element in elements)
            {
                Console.WriteLine(element.Text);
                Console.WriteLine(element.GetAttribute("href"));

                string[] href = element.GetAttribute("href").Split('/', '?');
                foreach(string str in href)
                {
                    try
                    {
                        names.Add(element.Text, int.Parse(str));
                        Console.WriteLine("добавлен");
                    }
                    catch(Exception e)
                    { Console.WriteLine(e.Message); }
                }
                
            }
            serialize();
        }
        public void serialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("codes.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, names);

                Console.WriteLine("Объект сериализован");
            }
        }
        public static Dictionary<string,int> deserialize()
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
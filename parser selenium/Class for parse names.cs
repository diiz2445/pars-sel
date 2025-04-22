using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;


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
            //try { names = deserialize(); Console.WriteLine("начальная сер пройдено"); }
            //catch { }
            while (true)
            {
                foreach (IWebElement element in elements)
                {
                    Console.WriteLine(element.Text);
                    Console.WriteLine(element.GetAttribute("href"));
                    string[] nameA = element.Text.Split(' ');
                    string name = "";
                    
                    for (int i = 0 ; i<nameA.Length; i++)
                    {
                        if (nameA[i] != "|" && (!nameA[i].Contains('('))&& nameA[i] != "|" && (!nameA[i].Contains(')')))
                            name += nameA[i]+" ";
                    }
                    name = name.TrimEnd();
                    Console.WriteLine(name);
                    string[] href = element.GetAttribute("href").Split('/', '?');
                    
                        try
                        {
                            names.Add(name, int.Parse(href[4]));
                            Console.WriteLine("добавлен");
                        }
                        catch (Exception e)
                        {  }
                    

                }
                serialize();
                Thread.Sleep(1000);
                driver.Close();
               
            }
        }
        public void serialize()
        {
            string JsonNames = JsonConvert.SerializeObject(names,Formatting.Indented);

            using (StreamWriter fs = File.CreateText("codes.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(fs, JsonNames);

                Console.WriteLine("Объект сериализован");
            }
        }
        public static Dictionary<string, int> deserialize()
        {
            JsonConvert.DeserializeObject<Dictionary<string,string>>(File.ReadAllText("codes.json"));
            
            using (StreamReader file = File.OpenText("codes.json"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                return (Dictionary<string, int>)jsonSerializer.Deserialize(file,typeof(Dictionary<string,int>));
            }
        }
    }
}
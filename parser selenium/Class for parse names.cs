using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Parse()
        {
            IWebDriver driver = new EdgeDriver();
            
            driver.Url = "https://buff.163.com/market/csgo";
            List<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"j_list_card\"]/ul/li/h3/a")).ToList();
            
            try {deserialize(); Console.WriteLine("начальная сер пройдено"); }
            catch(Exception e) { Console.WriteLine($"Exception: {e.Message}"); }
            
            //while (true)
            {
                foreach (IWebElement element in elements)
                {
                    //try
                    {
                        Console.WriteLine(element.Text);
                        Console.WriteLine(element.GetAttribute("href"));
                        string[] nameA = element.Text.Split(' ');
                        string name = "";

                        for (int i = 0; i < nameA.Length; i++)
                        {
                            if (nameA[i] != "|" && (!nameA[i].Contains('(')) && nameA[i] != "|" && (!nameA[i].Contains(')')))
                                name += nameA[i] + " ";
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
                        { Console.WriteLine($"EXCEPTION: {e.Message}"); }

                    }
                    //catch { }
                }
                serialize();
                Thread.Sleep(1000);
                
                
               
            }
            driver.Close();
        }
        public void serialize()
        {
            File.WriteAllText("codes.json", JsonConvert.SerializeObject(names));
            Console.WriteLine("Ser done");
        }
        public void deserialize()
        {
            string st = File.ReadAllText("codes.json");
            names = JsonConvert.DeserializeObject<Dictionary<string, int>>(st);
            
        }
    }
}
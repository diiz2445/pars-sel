using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using parser_selenium.Imports;


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

        public async Task Parse()
        {
            while (true)
            {
                
                IWebDriver driver = new EdgeDriver();

                driver.Url = "https://buff.163.com/market/csgo";
                List<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"j_list_card\"]/ul/li/h3/a")).ToList();
                string PathFile = "codes.json";
                try { names = await importData.DeserializeDictAsync(PathFile); Console.WriteLine("начальная сер пройдено"); }
                catch (Exception e) { Console.WriteLine($"Exception: {e.Message}"); }

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
                importData.SerializeAsync(PathFile, names);
                driver.Close();
                Console.WriteLine($"Count names: {names.Count}");

                Thread.Sleep(50000);


                
            }
            
        }
        
    }
}
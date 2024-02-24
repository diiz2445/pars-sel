using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace parser_selenium
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Class_for_parse_names parse_names = new Class_for_parse_names();
            parse_names.b();

            Dictionary<string, int> x = Class_for_parse_names.deserialize();
            Console.ReadLine();
        }
    }
}
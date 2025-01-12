using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace parser_selenium
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ItemCollection itemCollection = ItemCollection.GetCollection();
            

            foreach (var item in itemCollection.Items)//проверка наличия у всех предметов 
            {
                if(item.Value.type ==null)
                    Console.WriteLine("Error: "+item.Value.Name);
            }

            ItemCollection OtherCollection = itemCollection.GetItemsWhereTypeIs("Other");//проверка, чтобы не было лишних Other  в типе предмета
            foreach (var item in OtherCollection.Items)
            {
                Console.WriteLine(item.Key);
            } 
            Console.WriteLine("Done");



            Console.ReadLine();//ожидание, чтобы не выйти из отладки
        }
    }
}
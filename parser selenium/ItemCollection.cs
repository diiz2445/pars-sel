using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium
{

    public class ItemCollection
    {
        [JsonProperty("items")]
        public Dictionary<string, Item> Items { get ; set; }

        public void print()
        {
            foreach (var item in Items)
            {
                Console.WriteLine(item.Key + item.Value.Buff163GoodsId.ToString());
            }
        }
        public static ItemCollection GetCollection()
        {
            string json = System.IO.File.ReadAllText("cs2_marketplaceids.json");
            ItemCollection itemCollection = JsonConvert.DeserializeObject<ItemCollection>(json);

            string[] separators = new string[] { " | " };
            string[] sep2 = new string[] { " | ", " " };
            foreach(var item in itemCollection.Items)
            {
                string[] str_arr_name = item.Key.Split(separators,StringSplitOptions.RemoveEmptyEntries);

                // Ищем элементы из массива, которые есть в словаре
                var matchingItems = str_arr_name
                    .Where(temp_item => All_Info.Name_Type.ContainsKey(temp_item)) // Фильтруем элементы, которые есть в словаре
                    .Select(temp_item => new { Key = temp_item, Value = All_Info.Name_Type[temp_item] }) // Формируем пары ключ-значение
                    .ToList();

                // Проверяем результат
                if (matchingItems.Any())
                {
                    Console.WriteLine("Найдены элементы и их значения:");
                    foreach (var temp_item in matchingItems)
                    {
                        Console.WriteLine($"Ключ: {temp_item.Key}, Значение: {temp_item.Value}");
                        item.Value.type = temp_item.Value;//добавили тип предмета
                    }
                }
                else
                {
                    string[] str_arr_2_name = item.Key.Split(sep2, StringSplitOptions.RemoveEmptyEntries);
                    
                    var matchingItems_2 = str_arr_2_name
                    .Where(temp_item_2 => All_Info.Name_Type.ContainsKey(temp_item_2)) // Фильтруем элементы, которые есть в словаре
                    .Select(temp_item_2 => new { Key = temp_item_2, Value = All_Info.Name_Type[temp_item_2] }) // Формируем пары ключ-значение
                    .ToList();

                    if (matchingItems_2.Any())
                    {
                        Console.WriteLine("Найдены элементы и их значения:");
                        foreach (var temp_item_2 in matchingItems_2)
                        {
                            Console.WriteLine($"Ключ: {temp_item_2.Key}, Значение: {temp_item_2.Value}");
                            item.Value.type = temp_item_2.Value;//добавили тип предмета
                        }
                    }
                    else
                    {
                        Console.WriteLine("не найден тип предмета: " + item.Key);
                        item.Value.type = "Other";//добавили тип предмета
                    }
                }
                
            }
            
            return itemCollection;
        }

    }

    
}

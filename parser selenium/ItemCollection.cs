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

        public void print()//вывод названия и ID с BUFF163
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
            foreach (var item in itemCollection.Items)
            { 
                string[] str_arr_name = item.Key.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                // Проверяем пары i и i+1
                var matchingItems = new List<(string Key, string Value)>();

                for (int i = 0; i < str_arr_name.Length - 1; i++)
                {
                    string combinedKey = $"{str_arr_name[i]} {str_arr_name[i + 1]}"; // Формируем совокупность i и i+1
                    if (All_Info.Name_Type.ContainsKey(combinedKey))
                    {
                        matchingItems.Add((combinedKey, All_Info.Name_Type[combinedKey]));
                    }
                }

                // Проверяем одиночные элементы, если пары не найдены
                if (!matchingItems.Any())
                {
                    matchingItems = str_arr_name
                        .Where(temp_item => All_Info.Name_Type.ContainsKey(temp_item))
                        .Select(temp_item => (temp_item, All_Info.Name_Type[temp_item]))
                        .ToList();
                }

                // Проверяем результат
                if (matchingItems.Any())
                {
                    Console.WriteLine("Найдены элементы и их значения:");
                    foreach (var temp_item in matchingItems)
                    {
                        Console.WriteLine($"Ключ: {temp_item.Key}, Значение: {temp_item.Value}");
                        item.Value.type = temp_item.Value; // добавили тип предмета
                    }
                }
                else
                {
                    string[] str_arr_2_name = item.Key.Split(sep2, StringSplitOptions.RemoveEmptyEntries);

                    matchingItems = new List<(string Key, string Value)>();
                    for (int i = 0; i < str_arr_2_name.Length - 1; i++)
                    {
                        string combinedKey = $"{str_arr_2_name[i]} {str_arr_2_name[i + 1]}";
                        if (All_Info.Name_Type.ContainsKey(combinedKey))
                        {
                            matchingItems.Add((combinedKey, All_Info.Name_Type[combinedKey]));
                        }
                    }

                    if (!matchingItems.Any())
                    {
                        matchingItems = str_arr_2_name
                            .Where(temp_item_2 => All_Info.Name_Type.ContainsKey(temp_item_2))
                            .Select(temp_item_2 => (temp_item_2, All_Info.Name_Type[temp_item_2]))
                            .ToList();
                    }

                    if (matchingItems.Any())
                    {
                        Console.WriteLine("Найдены элементы и их значения:");
                        foreach (var temp_item in matchingItems)
                        {
                            Console.WriteLine($"Ключ: {temp_item.Key}, Значение: {temp_item.Value}");
                            item.Value.type = temp_item.Value; // добавили тип предмета
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не найден тип предмета: " + item.Key);
                        item.Value.type = "Other"; // добавили тип предмета
                    }
                }
            }
            return itemCollection;
        }
        public ItemCollection GetItemsWhereTypeIs(string typeValue)
        {
            // Создаем новый словарь для фильтрованных элементов
            var filteredItems = new Dictionary<string, Item>();

            // Перебираем все элементы исходной коллекции
            foreach (var item in Items)
            {
                // Если тип элемента совпадает с заданным, добавляем его в новый словарь
                if (item.Value.type == typeValue)
                {
                    filteredItems.Add(item.Key, item.Value);
                }
            }

            // Создаем новый экземпляр ItemCollection с отфильтрованными элементами
            var newItemCollection = new ItemCollection
            {
                Items = filteredItems
            };

            return newItemCollection;
        }

    }

    
}

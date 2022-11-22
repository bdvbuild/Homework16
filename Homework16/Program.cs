using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;


//1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
//Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число),
//«Название товара» (строка), «Цена товара» (вещественное число).
//Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
//Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».


namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите код товара: ");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите название товара: ");
                string name = Console.ReadLine();
                Console.Write("Введите цену товара: ");
                double price = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product { Code = code, Name = name, Price = price };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter("../../../Products.json")) 
            {
                sw.WriteLine(jsonString);
            }

        }
    }
}

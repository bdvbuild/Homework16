using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

//2.Необходимо разработать программу для получения информации о товаре из json-файла.
//Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product mostExp = products[0];
            foreach (Product p in products)
            {
                if (p.Price > mostExp.Price)
                    mostExp = p;
            }
            Console.WriteLine($"Самый дорогой товар: {mostExp.Name}\nцена: {mostExp.Price}");
            Console.ReadKey();
        }
    }
}

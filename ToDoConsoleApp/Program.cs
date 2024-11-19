﻿using System.Collections;
using System.Security.Cryptography.X509Certificates;
namespace ToDoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray dynamicArray = new DynamicArray();
            dynamicArray.Add("Apple");
            dynamicArray.Add("Lemon");
            dynamicArray.Add("Car");
            dynamicArray.Add("Juice");
            dynamicArray.Add("Juces");

           //dynamicArray.Insert(2, "Kids");
           //dynamicArray.delete("Apple");
           //dynamicArray.delete("Lemon");
           //dynamicArray.delete("Kids");
           //dynamicArray.delete("caR");
           //dynamicArray.delete("JuCeS");



            Console.WriteLine($"Elements: {dynamicArray.ListAll()}");
            Console.WriteLine($"Current size: {dynamicArray.size}");
            Console.WriteLine($"Current capacity: {dynamicArray.capacity}");
            Console.WriteLine($"Car is at {dynamicArray.search("Car")}");
        }
    }
}

using System.Collections;
using System.Security.Cryptography.X509Certificates;
namespace ToDoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray dynamicArray = new DynamicArray();
            dynamicArray.Add("Alma");
            dynamicArray.Add("Körte");
            dynamicArray.Add("Néma");
            dynamicArray.Add("Béla");

            dynamicArray.Insert(2, "Léta");
            dynamicArray.delete("Alma");



            Console.WriteLine($"Elements: {dynamicArray.ListAll()}");
            Console.WriteLine($"Current size: {dynamicArray.size}");
            Console.WriteLine($"Current capacity: {dynamicArray.capacity}");
        }
    }
}

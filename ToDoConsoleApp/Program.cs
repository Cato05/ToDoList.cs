using System.Collections;
using System.Net;
using System.Security.Cryptography.X509Certificates;
namespace ToDoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your To-Do list!\n Navigate with arrows, press enter to mark a task completed!");

            ConsoleKeyInfo key;
            int option = 1;
            bool done = false;
            string marking = "\u001b[31m";
            int max = 2; //The amount of tasks on the list
            int min = 1; //If there are tasks, 1, otherwise 0
            (int left, int top) = Console.GetCursorPosition();
            while (!done)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($" {(option == 1 ? marking : "")}Task 1\u001b[0m");
                Console.WriteLine($" {(option == 2 ? marking : "")}Task 2\u001b[0m");

                key = Console.ReadKey(true);


                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option--;
                        break;

                     case ConsoleKey.DownArrow:
                        option++;
                        break;

                    case ConsoleKey.Enter:
                        //delete element
                        break;

                    case ConsoleKey.Escape:
                        done = true;
                        break;
                }
                
                if (option < min)
                    option = min;
                else if (option > max)
                    option = max;
            }
        }
    }
}

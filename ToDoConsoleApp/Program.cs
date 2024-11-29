using System.Collections;
using System.Net;
using System.Security.Cryptography.X509Certificates;
namespace ToDoConsoleApp
{

    internal class Program
    {
        
        static void Main(string[] args)
        {

            DynamicArray ToDoList = new DynamicArray();
            Console.WriteLine("Welcome to your To-Do list!\n Navigate with arrows, press enter to select!");

            ConsoleKeyInfo key; 
            int option = 1;
            bool done = false; //Checks if user is done with checking the list
            string marking = "\u001b[31m"; //Marking color for the selection
            int max = 2; //The amount of tasks on the list
            int min = 1; //If there are tasks, 1, otherwise 0
            (int left, int top) = Console.GetCursorPosition();

            while (!done)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($" {(option == 1 ? marking : "")}Add a task\u001b[0m");
                Console.WriteLine($" {(option == 2 ? marking : "")}See tasks\u001b[0m");

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
                        if (option == 1)
                        {
                            Console.Clear();
                            Console.WriteLine($"Your current tasks are: {ToDoList.ListAll()}");
                            continue; //Go to the "task creator", pass for now
                        }
                        else if (option == 2)
                            continue; //Go to list all the tasks, WIP as well
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

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
            string ToDoFile = "../../../ToDo/To-DoList.txt";
            StreamWriter sw = new StreamWriter(ToDoFile);
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
                            char answer = 'y';

                            Console.Clear();
                            Console.WriteLine($"Your current tasks are: {ToDoList.ListAll()}");
                            while (answer == 'y')
                            {
                                Console.WriteLine("Please type in what you want to add: ");
                                string newTask = Convert.ToString(Console.ReadLine());
                                ToDoList.Add(newTask);
                                Console.WriteLine($"{newTask} has been succesfully added to your to-do list!\n Would you like to add something else? (y/n)");
                                answer = Convert.ToChar(Console.ReadLine());
                               
                            }
                            Console.Clear();
                            //Iterate through the list with a for loop, write out everything from it, to a file, delete the toDoList array, so it saves up memory
                            
                            sw.Close();
                            Console.WriteLine("Your To-Do List has been succesfully updated!");

                            
                        }
                        else if (option == 2)
                        {
                            Console.Clear();
                            Console.WriteLine($"You're tasks are below: \n{ToDoList.ListAll()}"); 
                        }
                            
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

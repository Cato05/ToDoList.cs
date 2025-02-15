using System.Collections;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
namespace ToDoConsoleApp
{
    

    internal class Program
    {
        static void MainMenu(int right, int bot, int option, string marking, string writeOutOpt1, string writeOutOpt2, string writeOutOpt3)
        {
           
            
            Thread.Sleep(100);
            Console.SetCursorPosition(right, bot);
            Console.WriteLine($" {(option == 1 ? marking : "")} {writeOutOpt1}\u001b[0m");
            Console.WriteLine($" {(option == 2 ? marking : "")} {writeOutOpt2}\u001b[0m");
            Console.WriteLine($" {(option == 3 ? marking : "")} {writeOutOpt3}\u001b[0m");


        }


        static void Main(string[] args)
        {

            DynamicArray ToDoList = new DynamicArray();
            Console.WriteLine("Welcome to your To-Do list!\n Navigate with arrows, press enter to select! Press escape to exit.");
            string ToDoFile = "../../../ToDo/To-DoList.txt";
            ConsoleKeyInfo key; 
            int option = 1;
            bool done = false; //Checks if user is done with checking the list
            string marking = "\u001b[31m"; //Marking color for the selection
            string markingColorTasks = "\u001B[32m";
            int max = 2; //The amount of tasks on the list
            int min = 1; //If there are tasks, 1, otherwise 0
            (int left, int bot) = Console.GetCursorPosition();
            (int top, int right) = Console.GetCursorPosition();
            string[] options = ["Add task", "See tasks", "Back"];
            string writeOutOpt1 = options[0];
            string writeOutOpt2 = options[1];
            string writeOutOpt3 = "";
            bool firstTimeInMainMenu = true;
            bool isMainMenu = true;

            while (!done)
            {
                

                
               
                Thread.Sleep(100);
                Console.SetCursorPosition(right, bot);
                if (!firstTimeInMainMenu && isMainMenu)
                {
                    Console.Clear();
                    Console.WriteLine("This is a beutifull MainMenu :)");
                    writeOutOpt3 = "";
                }
                Console.WriteLine($" {(option == 1 ? marking : "")} {writeOutOpt1}\u001b[0m");
                Console.WriteLine($" {(option == 2 ? marking : "")} {writeOutOpt2}\u001b[0m");
                Console.WriteLine($" {(option == 3 ? marking : "")} {writeOutOpt3}\u001b[0m");

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
                        firstTimeInMainMenu = (firstTimeInMainMenu == true ? false : false);
                        Console.Clear();
                        min = 1;
                        max = 3;
                        writeOutOpt1 = options[0];
                        writeOutOpt2 = options[1];
                        writeOutOpt3 = options[2];
                        if (option == 1)
                        {
                            char answer = 'y';

                            Console.Clear();
                            Console.WriteLine($"Your current tasks are: \n{ToDoList.ListAll()}");
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
                            
                            
                            Console.WriteLine("Your To-Do List has been succesfully updated!");

                            
                        }
                        else if (option == 2)
                        {
                            isMainMenu = false;
                            Console.Clear();
                            Console.WriteLine($"You're tasks are below, press esc, to go back: ");
                            string[] tasks = ToDoList.ListAll().Split(" ");
                            for (int i = 0; i < tasks.Length; i++)
                            {
                                Console.WriteLine($" {(option == i ? marking : "")}{tasks[i]}\u001b[0m");
                                
                            }
                            (left, bot) = Console.GetCursorPosition();
                            
                            writeOutOpt1 = "";
                            writeOutOpt2 = "";
                            min = 3;
                            max = 3;
                            option = 3;
                            writeOutOpt3 = options[2];
                          
                        }

                        
                        else if (option == 3)
                        {
                            isMainMenu = true;
                            max = 2;
                            break;
                        }

                            break;//corresponding to the case statement

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


//Start the Completed tasks window!

/*
 Make the tasks readable with  for loop, and cw, as you have done in lines 31, ans 32.
 Selection color will be green.
 Upon pressing enter, the task will be moved to "CompletedTasks" array.
 CompletedTasksWindow will be cleared every day, and every day, it writes out how many tasks have we completed the prevoius day.
 Tasks array stays the same.
 Add timeStamps to tasks.
 Sort it by what has the user the shortes time for.
 */
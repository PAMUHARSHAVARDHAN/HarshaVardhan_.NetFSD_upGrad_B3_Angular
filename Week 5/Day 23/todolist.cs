

using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class TodoList
    {
        static void Main(String[] args)
        {

            List<string> tasks = new List<string>();
            while (true)
            {


                Console.WriteLine($"tasks");
                Console.WriteLine($"1. Add Task");
                Console.WriteLine($"2. view Task");
                Console.WriteLine($"3. remove Task");
                Console.WriteLine($"4. exit Task");
                Console.WriteLine($"Enter the Task:");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine($"Enter task");
                    string task = Console.ReadLine();
                    tasks.Add(task);
                    Console.WriteLine($"task Addedd");

                }
                else if (choice == "2")
                {
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine($"tasks are not added");
                    }
                    else
                    {
                        Console.WriteLine($"tasks:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + tasks[i]);
                        }
                    }
                }
                else if (choice == "3")
                {
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks to remove!");
                    }
                    else
                    {
                        Console.WriteLine("Tasks:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + tasks[i]);
                        }

                        Console.Write("Enter the task number to remove: ");
                        string input = Console.ReadLine().Trim();

                        int num;
                        bool isNumber = int.TryParse(input, out num);
                        if (isNumber == false || num < 1 || num > tasks.Count)
                        {
                            Console.WriteLine("Invalid Task Number." + tasks.Count);
                        }
                        else
                        {
                            Console.WriteLine("Removed: " + tasks[num - 1]);
                            tasks.RemoveAt(num - 1); 
                    }
                }


            }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }


                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }



            }
        }
    }
}
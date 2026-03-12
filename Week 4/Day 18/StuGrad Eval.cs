using System;
namespace ConsoleApp1
{
    internal class program
    {
        static void Main(string[] args)
        {
            string UName;
            int Marks;
            string Grade;


            Console.WriteLine("Enter Student Name :");
            UName = Console.ReadLine();
            Console.WriteLine("Enter Student Marks:");
            Marks = int.Parse(Console.ReadLine());

            if (Marks <= 0 || Marks > 100)
            {

                Console.WriteLine("Invalid Marks");

            }
            else
            {


                if (Marks >= 90 && Marks <= 100)
                {
                    Grade = "A";
                }
                else if (Marks >= 80 && Marks < 90)
                {
                    Grade = "B";
                }
                else if (Marks >= 70 && Marks < 80)
                {
                    Grade = "C";
                }
                else if (Marks >= 60 && Marks < 70)
                {
                    Grade = "D";
                }
                else if (Marks >= 50 && Marks < 60)
                {
                    Grade = "E";
                }
                else
                {
                    Grade = "Fail";
                }


                Console.WriteLine("****** User Details *********");
                Console.WriteLine("Student  : " + UName);
                Console.WriteLine("MarksGrade :" + Grade);
        }

            Console.ReadLine();

        }
    }
}
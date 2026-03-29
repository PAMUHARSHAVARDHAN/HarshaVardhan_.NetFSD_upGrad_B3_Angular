

//Level - 1 Problem 1: Student Record Management System Using Record Data Structure

//Scenario:
//A college wants to develop a console-based Student Record Management System. The system should store and manage student records using a Record data structure. Each student record should contain fields such as Roll Number, Name, Course, and Marks. The system must allow users to add multiple student records, display all records, and search for a student using the Roll Number.
//Requirements:
//1.Define a Record to store student details.
//2. Allow the user to input details for multiple students.
//3. Display all student records in a formatted manner.
//4. Provide a search functionality to find a student by Roll Number.
//5. Display appropriate message if the record is not found.
//Technical Constraints:
//1.Must use Record data type.
//2. Use an array (or list) of records to store multiple students.
//3. Do not use external databases.
//4. Program should be menu-driven.
//5. Input validation must be handled for Roll Number and Marks.
//Expectations:
//1.Proper use of Record / Structure syntax.
//2. Clean and modular code.
//3. Proper formatting of displayed output.
//4. Efficient search implementation.
//Learning Outcome:
//1.Understand how to define and use Record/Structure data types.
//2. Learn how to manage multiple records using arrays/ lists.
//3.Implement searching techniques on structured data.
//4. Develop structured problem-solving skills for real-world scenarios


using System;
using System.Collections.Generic;

// Define Record
public record Student(int RollNumber, string Name, string Course, int Marks);

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Student Record Management =====");
            Console.WriteLine("1. Add Students");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice! Try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudents();
                    break;
                case 2:
                    DisplayStudents();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    // Add Students
    static void AddStudents()
    {
        Console.Write("Enter number of students: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Invalid number!");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nStudent {i + 1}:");

            int roll;
            while (true)
            {
                Console.Write("Enter Roll Number: ");
                if (int.TryParse(Console.ReadLine(), out roll))
                    break;
                Console.WriteLine("Invalid Roll Number!");
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            int marks;
            while (true)
            {
                Console.Write("Enter Marks (0-100): ");
                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                    break;
                Console.WriteLine("Invalid Marks!");
            }

            students.Add(new Student(roll, name, course, marks));
        }

        Console.WriteLine("Students added successfully!");
    }

    // Display Students
    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\nStudent Records:");
        foreach (var s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

    // Search Student
    static void SearchStudent()
    {
        Console.Write("Enter Roll Number to search: ");
        if (!int.TryParse(Console.ReadLine(), out int roll))
        {
            Console.WriteLine("Invalid Roll Number!");
            return;
        }

        var student = students.Find(s => s.RollNumber == roll);

        Console.WriteLine("\nSearch Result:");
        if (student != null)
        {
            Console.WriteLine("Student Found:");
            Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}

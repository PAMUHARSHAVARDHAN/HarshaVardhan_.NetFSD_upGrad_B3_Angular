using ConsoleApp1;
using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

    }
    class StudentRepository
    {
        private List<Student> students = new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetStudents() { return students; }



    }
    class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine(" Student Report");
            foreach (var student in students)
            {
                string result = student.Marks >= 40 ? "pass" : "fail";
                Console.WriteLine($"ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Result: {result}");
            }



        }




    }


    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository repo = new StudentRepository();
            repo.AddStudent(new Student { Id = 1, Name = "Harsha", Marks = 75 });
            repo.AddStudent(new Student { Id = 2, Name = "Rahul", Marks = 35 });
            repo.AddStudent(new Student { Id = 3, Name = "Anjali", Marks = 60 });
            var students = repo.GetStudents();
            ReportGenerator report = new ReportGenerator();
            report.GenerateReport(students);

            Console.ReadLine();

        }


    }
}
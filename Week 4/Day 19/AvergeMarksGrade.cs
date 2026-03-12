using System;

class Student
{
    public double CalculateAverage(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }

    static void Main(string[] args)
    {
        Student s = new Student();

        Console.Write("Enter mark 1: ");
        int m1 = int.Parse(Console.ReadLine());

        Console.Write("Enter mark 2: ");
        int m2 = int.Parse(Console.ReadLine());

        Console.Write("Enter mark 3: ");
        int m3 = int.Parse(Console.ReadLine());

        double average = s.CalculateAverage(m1, m2, m3);

        string grade;

        if (average >= 90)
            grade = "A";
        else if (average >= 80)
            grade = "B";
        else if (average >= 70)
            grade = "C";
        else if (average >= 60)
            grade = "D";
        else
            grade = "E";

        Console.WriteLine("Average = " + average);
        Console.WriteLine("Grade = " + grade);

        Console.ReadLine();
    }
}
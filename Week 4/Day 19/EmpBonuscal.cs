using System;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Your Name ");
        String Uname = Console.ReadLine();

        Console.WriteLine("Enter your Salary ");
        int salary = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Your Experience ");
        int Exp = int.Parse(Console.ReadLine());

        double bonus;
        

        if (Exp <=2) {
            bonus = 0.05;
        }
        else if (Exp <= 5){
            bonus = 0.10;
        }
        else
        {
            bonus = 0.15;
        }
        double bonus1 = salary * bonus;
        double Total = salary + bonus1;

        Console.WriteLine("Name" + Uname);
        Console.WriteLine("Bonus" + bonus);
        Console.WriteLine("TotalSalary" + Total);

        Console.ReadLine();

    }

}
  
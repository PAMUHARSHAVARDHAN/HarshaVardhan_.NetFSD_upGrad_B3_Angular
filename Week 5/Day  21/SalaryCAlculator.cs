//Level - 1 Problem 2: Employee Salary Calculator
//Scenario:
//A company wants to calculate employee salaries using inheritance.All employees have a base salary, but different roles calculate bonuses differently.
//Requirements:
//1.Create a base class Employee with Name and BaseSalary properties.
//2. Create derived classes Manager and Developer.
//3. Override a virtual method CalculateSalary().
//4. Manager gets 20% bonus, Developer gets 10% bonus.
//Technical Constraints:
//• Use inheritance and method overriding.
//• Apply polymorphism using base class reference.
//• Use properties for salary details.
//Expectations:
//• Demonstrate runtime polymorphism.
//• Avoid code duplication.
//• Display final calculated salary.
//Learning Outcome:
//• Understand inheritance hierarchy.
//• Implement polymorphism using virtual and override.
//• Write reusable and extensible code.
//Sample Input: 
//BaseSalary = 50000
//Sample Output: 
//Manager Salary = 60000, Developer Salary = 55000


using System;
class Employee
{ 
    public string Name { get; set; }
     
     public Double BaseSalary {  get; set; }
    public virtual double CalSalary()
    {
        return BaseSalary;
    }
}
class Manager : Employee
{
    public override double CalSalary()
    {
        return BaseSalary + (BaseSalary * 0.20);                            ///20% bonus for manager 
    } 
}
class Developer : Employee
{
    public override double CalSalary()
    {
        return BaseSalary + (BaseSalary * 0.10);                              ////10% bonus for developer
    }
}
 class Program
{
    static void Main(string[] args)
    {
        double basesalary =50000;
        Employee emp1 = new Manager();
        emp1.Name = "Harsha";
        emp1.BaseSalary = basesalary;

        Employee emp2 = new Developer();
        emp2.Name = "Srikar ";
        emp2.BaseSalary = basesalary;



        Console.WriteLine($" BaseSalary      : {basesalary}");
        Console.WriteLine($" Manager Name    : {emp1.Name}");
        Console.WriteLine($" Manager Salary  : {emp1.CalSalary()} ");
        Console.WriteLine($" Devloper Name   : {emp2.Name}");
        Console.WriteLine($" Devloper Salary : {emp2.CalSalary()} ");



    }
}

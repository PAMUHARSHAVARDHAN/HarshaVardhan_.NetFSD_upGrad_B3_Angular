using System;
class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public int Subtract(int x, int y)
    {
        return x - y;
    }
    static void Main(string[] args)
    {
        Calculator c =new Calculator();
        int add =c.Add(1,2);
        int sub =c.Subtract(1,2);

        Console.WriteLine("Addition =" + add);
        Console.WriteLine("Subtraction =" + sub);

        Console.ReadLine();
    }
}
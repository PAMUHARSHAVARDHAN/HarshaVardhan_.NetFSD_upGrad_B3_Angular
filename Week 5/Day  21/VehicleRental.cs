//Level - 2 Problem 2: Vehicle Rental System
//Scenario:
//A vehicle rental company wants a system where different vehicle types calculate rental charges differently.
//Requirements:
//1.Create a base class Vehicle with properties Brand and RentalRatePerDay.
//2. Create derived classes Car and Bike.
//3. Override CalculateRental(int days) method.
//4. Car adds insurance charge of 500 per rental.
//5. Bike offers 5% discount on total rental.
//Technical Constraints:
//• Use encapsulation with proper access modifiers.
//• Apply runtime polymorphism.
//• Validate number of rental days.
//Expectations:
//• Use base class reference to call overridden methods.
//• Implement clean class hierarchy.
//• Display final rental cost.
//Learning Outcome:
//• Master inheritance and polymorphism.
//• Implement real-world OOP scenarios.
//• Improve object-oriented design skills.
//Sample Input: 
//Car RentalRatePerDay = 2000, Days = 3
//Sample Output: 
//Total Rental = 6500

using System;
using System.Transactions;
class Vehcile
{
    private int rentalrateperday;
    public string Brand {  get; set; }
     public int Rentalperday
    {
        get
        {
            return rentalrateperday; 
        }
        set
        {
            if (value < 0)
            {
                Console.WriteLine($"rental rate cannot be zero");
            }
            else
            {
                rentalrateperday = value;
            }
        }
    }
    public virtual double Calrental(int days)
    {
        return   rentalrateperday * days;
    }
}
 class Car : Vehcile
{
    public override double Calrental(int days)
    {
        if (days < 0)
        {
            Console.WriteLine($"invalid Days");
            return 0;

        }
        double total = Rentalperday* days;
        return total + 500;

    } 
}
class Bike : Vehcile
{
    public override double Calrental(int days)
    {
        if (days < 0)
        {
            Console.WriteLine($"Inavalid Days");
            return 0;
        }
        double total = Rentalperday * days;
        return total - (total * 0.05);
    } 
}
class Program
{
    static void Main()
    {
        Vehcile car = new Car();
        car.Brand = "Toyato";
        Console.WriteLine($" Enter Rental per Day price of Car :");
        int rate1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Enter days :");
        int days1 = Convert.ToInt32(Console.ReadLine());
        car.Rentalperday = rate1;
        double finalprice = car.Calrental(days1);
        Console.WriteLine($"final price of car rent :{finalprice}");


        Vehcile bike = new Bike();
        bike.Brand = "Enfield";
        Console.WriteLine($"Enter Per Day Price Of Bike: ");
        int rate2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Enter Days :");
        int days = Convert.ToInt32(Console.ReadLine());
        bike.Rentalperday = rate2;
        double finalprice1 = bike.Calrental(days1);
        Console.WriteLine($"final price of car rent :{finalprice1}");

    }
}
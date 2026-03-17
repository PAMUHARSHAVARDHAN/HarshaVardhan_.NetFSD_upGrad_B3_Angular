//DAY - 1 Hands - On
//Level - 1 Problem 1: Bank Account Management System
//Scenario:
//A bank wants to develop a simple console-based application to manage customer bank accounts. The system should protect account balance information and allow controlled access using properties.
//Requirements:
//1.Create a BankAccount class with private fields for account number and balance.
//2.Use properties to allow controlled access to account number and balance.
//3.Implement Deposit and Withdraw methods with proper validation.
//4.Prevent withdrawal if balance is insufficient.
//Technical Constraints:
//• Use private fields with public properties.
//• Apply encapsulation and data hiding.
//• No direct access to balance field from outside the class.
//Expectations:
//• Demonstrate correct use of access modifiers.
//• Validate negative deposit or withdrawal amounts.
//• Display updated balance after each transaction.
//Learning Outcome:
//• Understand encapsulation using properties.
//• Apply data hiding effectively.
//• Implement validation logic inside class methods.
//Sample Input: 
//Deposit = 5000, Withdraw = 2000
//Sample Output: 
//Current Balance = 3000

//using System;
//class BankAccount
//{ 
//    /// private fields for account number and balance.
  
//    private string accountnumber;          
//    private double balance;

    //controlled access to account number and balance
    public string AccountNumber
    {
        get { return accountnumber; }
        set { accountnumber = value; }

    }

    //Deposit and Withdraw methods with proper validation
    public double Balance
    {
        get { return balance; }

    }
    public void Deposit( double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine($"invalid Deposit");
            return;                                                                                    // Deposit

        }
        balance += amount;
        Console.WriteLine($"deposited : {amount}");
        Console.WriteLine($"Total balannce : {balance}");
    }
    public void Withdraw(double amount)                                                                // Withdraw
    {
        if (amount <= 0)
        {
            Console.WriteLine($"invalid withdrawl amount");
            return ;
        }
        if (amount > balance)
        {
            Console.WriteLine( $"invalid Amount");
            return;
        }
        balance -= amount;
        Console.WriteLine($"Withdrawn :{amount}");
        Console.WriteLine($"Total balannce : {balance}");
    }

   
    
        public static void Main(String[] args)
        {
            BankAccount acc = new BankAccount();
            acc.AccountNumber = "84165";
            acc.Deposit(50000);
            acc.Withdraw(1000);
            Console.WriteLine($"Final Balance : {acc.Balance}");
        }

    
    
}

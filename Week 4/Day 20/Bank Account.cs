using System;

public class BankAccount
{
    // 🔒 Private field (Data Hiding)
    private decimal _balance;

    // 🔒 Readonly field (never changes after creation)
    private readonly string _accountNumber;

    private string _accountHolder;

    // ✅ Public Properties

    // Read-only Balance
    public decimal Balance
    {
        get { return _balance; }
    }

    // Read-only Account Number
    public string AccountNumber
    {
        get { return _accountNumber; }
    }

    // Read/Write Account Holder with validation
    public string AccountHolder
    {
        get { return _accountHolder; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Account holder name cannot be empty.");

            _accountHolder = value;
        }
    }

    // ✅ Constructor (Safe Initialization)
    public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Account number cannot be empty.");

        if (string.IsNullOrWhiteSpace(accountHolder))
            throw new ArgumentException("Account holder name cannot be empty.");

        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");

        _accountNumber = accountNumber;
        _accountHolder = accountHolder;
        _balance = initialBalance;
    }

    // ✅ Deposit Method
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        _balance += amount;

        Console.WriteLine($"₹{amount} deposited successfully. Current Balance: ₹{_balance}");
    }

    // ✅ Withdraw Method
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be greater than zero.");
            return false;
        }

        if (amount > _balance)
        {
            Console.WriteLine("Insufficient balance.");
            return false;
        }

        _balance -= amount;

        Console.WriteLine($"₹{amount} withdrawn successfully. Current Balance: ₹{_balance}");
        return true;
    }
}
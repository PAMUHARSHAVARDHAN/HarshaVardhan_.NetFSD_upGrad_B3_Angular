using System;

namespace ISP_PrinterExample
{
    // 1. Small Interfaces
    interface IPrinter
    {
        void Print();
    }

    interface IScanner
    {
        void Scan();
    }

    interface IFax
    {
        void Fax();
    }

    // 2. Basic Printer (Print only)
    class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing...");
        }
    }

    // 3. Advanced Printer (Print + Scan + Fax)
    class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Faxing...");
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            // Basic Printer
            IPrinter basic = new BasicPrinter();
            basic.Print();

            Console.WriteLine();

            // Advanced Printer
            AdvancedPrinter adv = new AdvancedPrinter();
            adv.Print();
            adv.Scan();
            adv.Fax();

            Console.ReadLine();
        }
    }
}
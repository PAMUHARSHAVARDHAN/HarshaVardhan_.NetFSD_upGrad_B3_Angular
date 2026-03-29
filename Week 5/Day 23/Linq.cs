

//Please download and refer shared Code template (LinqCodeTemplate) and solve problems as given below. 
//(Please Refer Problem-1 Solved in the Code Template and solve rest of other problems in the same project accordingly)
//Problem Level- 1 and 2:
//1.Write a LINQ query to search and display all products with category “FMCG”.
//2. Write a LINQ query to search and display all products with category “Grain”.
//3. Write a LINQ query to sort products in ascending order by product code.
//4. Write a LINQ query to sort products in ascending order by product Category.
//5. Write a LINQ query to sort products in ascending order by product Mrp.
//6. Write a LINQ query to sort products in descending order by product Mrp.
//7. Write a LINQ query to display products group by product Category.
//8. Write a LINQ query to display products group by product Mrp.
//9. Write a LINQ query to display product detail with highest price in FMCG category.
//10. Write a LINQ query to display count of total products.
//11. Write a LINQ query to display count of total products with category FMCG.
//12.Write a LINQ query to display Max price.
//13.Write a LINQ query to display Min price.
//14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
//15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not. 
//from 1 to 7 give linq in query form  














using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal Mrp { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product{ProductCode=1, ProductName="Soap", Category="FMCG", Mrp=25},
            new Product{ProductCode=2, ProductName="Rice", Category="Grain", Mrp=50},
            new Product{ProductCode=3, ProductName="Oil", Category="FMCG", Mrp=120},
            new Product{ProductCode=4, ProductName="Wheat", Category="Grain", Mrp=40},
            new Product{ProductCode=5, ProductName="Shampoo", Category="FMCG", Mrp=30}
        };

        // 1. FMCG Products (Query Syntax)
        Console.WriteLine("\n1. FMCG Products:");
        var q1 = from p in products
                 where p.Category == "FMCG"
                 select p;
        foreach (var p in q1)
            Console.WriteLine($"{p.ProductName} {p.Mrp}");

        // 2. Grain Products (Query Syntax)
        Console.WriteLine("\n2. Grain Products:");
        var q2 = from p in products
                 where p.Category == "Grain"
                 select p;
        foreach (var p in q2)
            Console.WriteLine($"{p.ProductName} {p.Mrp}");

        // 3. Sort by ProductCode (Query Syntax)
        Console.WriteLine("\n3. Sort by ProductCode:");
        var q3 = from p in products
                 orderby p.ProductCode
                 select p;
        foreach (var p in q3)
            Console.WriteLine($"{p.ProductCode} {p.ProductName}");

        // 4. Sort by Category (Query Syntax)
        Console.WriteLine("\n4. Sort by Category:");
        var q4 = from p in products
                 orderby p.Category
                 select p;
        foreach (var p in q4)
            Console.WriteLine($"{p.Category} {p.ProductName}");

        // 5. Sort by MRP Asc (Query Syntax)
        Console.WriteLine("\n5. Sort by MRP Asc:");
        var q5 = from p in products
                 orderby p.Mrp
                 select p;
        foreach (var p in q5)
            Console.WriteLine($"{p.ProductName} {p.Mrp}");

        // 6. Sort by MRP Desc (Query Syntax)
        Console.WriteLine("\n6. Sort by MRP Desc:");
        var q6 = from p in products
                 orderby p.Mrp descending
                 select p;
        foreach (var p in q6)
            Console.WriteLine($"{p.ProductName} {p.Mrp}");

        // 7. Group by Category (Query Syntax)
        Console.WriteLine("\n7. Group by Category:");
        var q7 = from p in products
                 group p by p.Category into g
                 select g;
        foreach (var group in q7)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($"   {p.ProductName}");
        }

        // 8. Group by MRP (Method Syntax)
        Console.WriteLine("\n8. Group by MRP:");
        var q8 = products.GroupBy(p => p.Mrp);
        foreach (var group in q8)
        {
            Console.WriteLine($"MRP: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($"   {p.ProductName}");
        }

        // 9. Highest price in FMCG
        Console.WriteLine("\n9. Highest price in FMCG:");
        var q9 = products
                 .Where(p => p.Category == "FMCG")
                 .OrderByDescending(p => p.Mrp)
                 .FirstOrDefault();
        Console.WriteLine($"{q9.ProductName} {q9.Mrp}");

        // 10. Count total products
        Console.WriteLine("\n10. Total Products Count:");
        Console.WriteLine(products.Count());

        // 11. Count FMCG products
        Console.WriteLine("\n11. FMCG Count:");
        Console.WriteLine(products.Count(p => p.Category == "FMCG"));

        // 12. Max Price
        Console.WriteLine("\n12. Max Price:");
        Console.WriteLine(products.Max(p => p.Mrp));

        // 13. Min Price
        Console.WriteLine("\n13. Min Price:");
        Console.WriteLine(products.Min(p => p.Mrp));

        // 14. All below 30?
        Console.WriteLine("\n14. All products below 30?");
        Console.WriteLine(products.All(p => p.Mrp < 30));

        // 15. Any below 30?
        Console.WriteLine("\n15. Any product below 30?");
        Console.WriteLine(products.Any(p => p.Mrp < 30));
    }
}
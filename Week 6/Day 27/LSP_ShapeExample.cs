using System;

namespace LSP_ShapeExample
{
    // 1. Base Class
    abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // 2. Rectangle Class
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // 3. Circle Class
    class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // 4. Area Calculator
    class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            AreaCalculator calculator = new AreaCalculator();

            // Rectangle
            Shape rect = new Rectangle { Width = 5, Height = 4 };
            calculator.PrintArea(rect);

            // Circle
            Shape circle = new Circle { Radius = 3 };
            calculator.PrintArea(circle);

            Console.ReadLine();
        }
    }
}
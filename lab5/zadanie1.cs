using System;

namespace lab5
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }
        public override double CalculateArea()
        {
            return Math.Pow(SideLength, 2);
        }
    }

    public class zadanie1
    {
        public static void Wykonaj()
        {
            Shape circle = new Circle(5);
            Shape square = new Square(4);

            Console.WriteLine($"Pole koła o promieniu 5: {circle.CalculateArea()}");
            Console.WriteLine($"Pole kwadratu o boku 4: {square.CalculateArea()}");
        }
    }
}
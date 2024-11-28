using System;
using System.Collections.Generic;

namespace lab4
{
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Shape(int x, int y, int height, int width)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Rysowanie kszta?tu");
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(int x, int y, int height, int width) : base(x, y, height, width) { }

        public override void Draw()
        {
            Console.WriteLine("Rysowanie prostok?ta");
        }
    }
    public class Triangle : Shape
    {
        public Triangle(int x, int y, int height, int width) : base(x, y, height, width) { }

        public override void Draw()
        {
            Console.WriteLine("Rysowanie trójk?ta");
            double area = 0.5 * Width * Height;
            Console.WriteLine($"Pole trójk?ta: {area}");
        }
    }
    public class Circle : Shape
    {
        public Circle(int x, int y, int height, int width) : base(x, y, height, width) { }

        public override void Draw()
        {
            Console.WriteLine("Rysowanie ko?a");
        }
    }
    public class Zadanie1
    {
        public static void Wykonaj()
        {
            List<Shape> shapes = new List<Shape>
            {
                new Rectangle(0, 0, 10, 20),
                new Triangle(10, 10, 15, 15),
                new Circle(20, 20, 30, 30)
            };
            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}


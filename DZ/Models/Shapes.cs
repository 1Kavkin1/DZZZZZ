using System;
using DZ.Exceptions;

namespace DZ.Models
{
    // Абстрактна фігура
    public abstract class Shape
    {
        public abstract double GetArea();
    }

    // Коло
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0) throw new InvalidShapeException("Радіус має бути додатнім", nameof(radius));
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;
    }

    // Прямокутник
    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0) throw new InvalidShapeException("Ширина і висота мають бути додатні");
            Width = width; Height = height;
        }

        public override double GetArea() => Width * Height;
    }

    // Трикутник (площа за формулою Герона)
    public class Triangle : Shape
    {
        // сторони
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) throw new InvalidShapeException("Сторони трикутника мають бути додатні");
            // перевірка нерівності трикутника
            if (a + b <= c || a + c <= b || b + c <= a) throw new InvalidShapeException("Неприпустимі сторони трикутника (порушено нерівність трикутника)");
            A = a; B = b; C = c;
        }

        public override double GetArea()
        {
            var s = (A + B + C) / 2.0;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }
}

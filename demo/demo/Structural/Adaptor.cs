using System;
using System.IO;

namespace demo.Structural
{
    class Adaptor
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var shapes = new Polygon[]
            {
                new RegularPolygon{Sides = 4, Length = 2.2M},
                new CircleToPolygon(new Circle{Radius = 1})
            };

            foreach (var shape in shapes)
            {
                var perimeter = shape.GetPerimeter();
                writer.WriteLine("perimeter = {0}", perimeter);
            }
        }
    }

    interface Polygon
    {
        decimal GetPerimeter();
    }

    class RegularPolygon
        : Polygon
    {
        public int Sides { get; set; }
        public decimal Length { get; set; }

        public decimal GetPerimeter()
        {
            return Sides * Length;
        }
    }

    class Circle
    {
        public double Radius { get; set; }

        public double Circumference()
        {
            return Math.PI * 2 * Radius;
        }
    }

    class CircleToPolygon
        : Polygon
    {
        readonly Circle circle;

        public CircleToPolygon(Circle circle)
        {
            this.circle = circle;
        }

        public decimal GetPerimeter()
        {
            var circumference = circle.Circumference();
            return Convert.ToDecimal(circumference);
        }
    }
}

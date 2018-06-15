using System;

namespace EulerLibrary2.Inheritance
{

    public abstract class Shape
    {
        public abstract double Area();

        public virtual double Circumstance()
        {
            return 0;
        }

        public virtual double Height()
        {
            return 0;
        }

        public string ToString()
        {
            return $"Area is {this.Area()}, Circumnstance is {this.Circumstance()}";
        }
    }

    public class Circle : Shape
    {
        public Circle(double r)
        {
            this.r = r;
        }

        private readonly double r = 1.0;

        public override double Area()
        {
            return Math.PI * this.r * this.r;
        }

        public new double Circumstance()
        {
            return 2 * Math.PI * this.r;
        }

        public override double Height()
        {
            return 2 * r;
        }

        internal string Draw()
        {
            return $"DrawMe!!! {this.ToString()}";
        }
    }
}

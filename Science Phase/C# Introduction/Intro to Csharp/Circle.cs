using System;
using System.Collections.Generic;
using System.Text;

namespace Introduction_to_Csharp
{
    internal class Circle
    {
        public double Radius { get; set; }

        public Circle(double radius) => Radius = radius;

        public double Area => Math.PI * Radius * Radius;

        public double Diameter() => Radius * 2;
    }
}

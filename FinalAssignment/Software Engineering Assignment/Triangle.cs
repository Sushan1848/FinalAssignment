using Software_Engineering_Assignment;
using System;
using System.Drawing;

namespace Software_Engineering_Assignment
{
    /// <summary>
    /// We created a triangle class to create a shape 'triangle' when the user gives a command in the textbox.
    /// </summary>
    class Triangle : Shape
    {
        int sideLength1, sideLength2, sideLength3;

        public Triangle(Color colour, int x, int y, int sideLength1, int sideLength2, int sideLength3, bool fill) : base(colour, x, y, fill)
        {
            this.sideLength1 = sideLength1; // Given the first side length of the triangle
            this.sideLength2 = sideLength2; // Given the second side length of the triangle
            this.sideLength3 = sideLength3; // Given the third side length of the triangle
        }

        /// <summary>
        /// We have overridden the draw method to draw a triangle.
        /// The side lengths are given by the user. 
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g, bool fill)
        {
            Pen p = new Pen(Color.Black, 2);

            // Calculate the height of the triangle using the formula for the area of a triangle
            double s = (sideLength1 + sideLength2 + sideLength3) / 2.0;
            double triangleHeight = (2.0 / sideLength1) * Math.Sqrt(s * (s - sideLength1) * (s - sideLength2) * (s - sideLength3));

            // Define the vertices of the triangle
            Point point1 = new Point(x, y);
            Point point2 = new Point(x + sideLength1, y);
            Point point3 = new Point(x + sideLength1 / 2, (int)(y - triangleHeight));

            // Create an array of points for the triangle
            Point[] trianglePoints = { point1, point2, point3 };

            // Draw the triangle
            g.DrawPolygon(p, trianglePoints);
        }
    }
}
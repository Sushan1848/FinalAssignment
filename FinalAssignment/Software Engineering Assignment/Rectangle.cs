using Software_Engineering_Assignment;
using Software_Engineering_Assignment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Assignment
{
    /// <summary>
    /// We created rectangle class to create a shape 'rectangle' when user gives command in textbox
    /// </summary>
    class Rectangle : Shape
    {
        int length, height;
        public Rectangle(Color colour, int x, int y, int length, int height, bool fill) : base(colour, x, y, fill)
        {

            this.length = length;             //Given the length of rectangle
            this.height = height;           //Given the height of rectangle
        }

        /// <summary>
        /// We have ovverridden draw method to draw rectangle
        /// length and heights are given by users
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g, bool fill)
        {
            Pen p = new Pen(colour, 2);
            g.DrawRectangle(p, x, y, length, height);
        }
    }
}

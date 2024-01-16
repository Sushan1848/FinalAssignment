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
    /// We created Circle class to create a shape 'circle' when user gives command in textbox
    /// </summary>
    class Circle : Shape
    {
        int radius;
        public Circle(Color colour, int x, int y, int radius, bool fill) : base(colour, x, y, fill)
        {

            this.radius = radius;   //Radius is stored in this variable
        }

        /// <summary>
        /// We have ovverridden draw method to draw circle
        /// radius is given by users
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g, bool fill)
        {
            if (fill)
            {
                Brush b = new SolidBrush(colour); // Use SolidBrush for filling
                g.FillEllipse(b, x, y, radius * 2, radius * 2);
            }
            else
            {
                Pen p = new Pen(colour);
                g.DrawEllipse(p, x, y, radius * 2, radius * 2);

            }

        }

    }
}



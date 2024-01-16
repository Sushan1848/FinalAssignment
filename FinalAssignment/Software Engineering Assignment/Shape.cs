using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Software_Engineering_Assignment
{
    /// <summary>
    /// We have created an abstract class Shape to inherit position to create different shapes like rectangle, traingle and so on
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// We have given color variable to give colors to different shapes
        /// We have protected to give access to only child classes
        /// </summary>

        protected Color colour;
        protected int x, y;
        protected bool fill;

        /// <summary>
        /// </summary>
        /// <param name="colour">This is where we give shape's colour</param>
        /// <param name="x">We get the position of x thorugh this</param>
        /// <param name="y"> We get the position of y thorugh this </param>
        public Shape(Color colour, int x, int y, bool fill)
        {

            this.colour = colour; //
            this.x = x; //
            this.y = y; //
            this.fill = fill;

        }

        /// <summary>
        /// Any derrived class must implement this method to draw shapes
        /// </summary>
        /// <param name="g"></param>
        public abstract void draw(Graphics g, bool fill);

    }
}



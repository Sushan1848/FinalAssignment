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
    class ShapeFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Shape getShape(String shapeType, Color colour, int x, int y, int length, int height, bool fill)
        {
            shapeType = shapeType.ToUpper().Trim(); //yoi could argue that you want a specific word string to create an object but I'm allowing any case combination


            if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle(colour, x, y, length, height, fill);

            }
            else
            {
                /// We throw exception for any errors 
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
                throw argEx;
            }


        }
        public static Shape getShape1(String shapeType, Color colour, int x, int y, int size, bool fill)
        {
            shapeType = shapeType.ToUpper().Trim(); //yoi could argue that you want a specific word string to create an object but I'm allowing any case combination


            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle(colour, x, y, size, fill);

            }
            else
            {
                /// We throw exception for any errors 
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
                throw argEx;
            }


        }
        public static Shape getShape2(String shapeType, Color colour, int x, int y, int sideLength1, int sideLength2, int sideLength3, bool fill)
        {
            shapeType = shapeType.ToUpper().Trim(); //yoi could argue that you want a specific word string to create an object but I'm allowing any case combination

            if (shapeType.Equals("TRIANGLE"))
            {
                return new Triangle(colour, x, y, sideLength1, sideLength2, sideLength3, fill);

            }
            else
            {
                /// We throw exception for any errors 
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
                throw argEx;
            }


        }
    }
}

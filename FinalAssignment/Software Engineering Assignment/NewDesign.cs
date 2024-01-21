using System;
using System.Drawing;

namespace Software_Engineering_Assignment
{
    class FlowerPattern : Shape
    {
        int size;

        public FlowerPattern(Color colour, int x, int y, int size, bool fill)
            : base(colour, x, y, fill)
        {
            this.size = size;
        }

        public override void draw(Graphics g, bool fill)
        {
            // Drawing circles
            for (int i = 0; i < 360; i += 45)  // Adjust the angle and count as needed
            {
                int xOffset = (int)(Math.Cos(i * Math.PI / 180) * size);
                int yOffset = (int)(Math.Sin(i * Math.PI / 180) * size);

                Circle circle = new Circle(colour, x + xOffset, y + yOffset, size / 4, fill);
                circle.draw(g, fill);
            }

            // Drawing rectangles
            for (int i = 0; i < 360; i += 45)  // Adjust the angle and count as needed
            {
                int xOffset = (int)(Math.Cos(i * Math.PI / 180) * size * 0.7);
                int yOffset = (int)(Math.Sin(i * Math.PI / 180) * size * 0.7);

                Rectangle rect = new Rectangle(colour, x + xOffset, y + yOffset, size / 2, size / 2, fill);
                rect.draw(g, fill);
            }
        }
    }
}

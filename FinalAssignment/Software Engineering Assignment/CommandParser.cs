using Software_Engineering_Assignment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Software_Engineering_Assignment
{
    public class CommandParser
    {
        Shape shape;
        public string[] command;
        public Color shapeColor = Color.Green;
        public List<int> parameters = new List<int>();
        public bool fill = false;
        public Graphics g;


        public CommandParser(Graphics g)
        {
            this.g = g;
        }
        public void RunCommand(string[] command, Graphics g, bool testing = false)
        {
            try
            {

                if (command[0] == "rectangle")
                {
                    if (command.Length == 3 && int.Parse(command[1]) > 0 && int.Parse(command[2]) > 0)
                    {
                        shape = ShapeFactory.getShape(command[0], shapeColor, 0, 0, int.Parse(command[1]), int.Parse(command[2]), fill);
                        shape.draw(g, fill);
                    }
                    else
                    {
                        // Handle invalid parameters for rectangle
                        throw new Exception(" Invalid parameters for rectangle. Please provide exactly 2 positive values.");
                    }
                }
                else if (command[0] == "circle")
                {
                    if (command.Length == 2 && int.Parse(command[1]) > 0)
                    {
                        shape = ShapeFactory.getShape1(command[0], shapeColor, 0, 0, int.Parse(command[1]), fill);
                        shape.draw(g, fill);
                    }
                    else
                    {
                        // Handle invalid parameters for circle
                        throw new Exception(" Invalid parameters for circle. Please provide exactly 1 positive value.");
                    }
                }
                else if (command[0] == "triangle")
                {
                    if (command.Length == 4 && int.Parse(command[1]) > 0 && int.Parse(command[2]) > 0 && int.Parse(command[3]) > 0)
                    {
                        shape = ShapeFactory.getShape2(command[0], shapeColor, 0, 0, int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), fill);
                        shape.draw(g, fill);
                    }
                    else
                    {
                        // Handle invalid parameters for triangle
                        throw new Exception(" Invalid parameters for triangle. Please provide exactly 3 positive values.");
                    }
                }
                else if (command[0] == "drawto")
                {
                    if (command.Length == 3 && int.Parse(command[1]) >= 0 && int.Parse(command[2]) >= 0)
                    {
                        int x = int.Parse(command[1]);
                        int y = int.Parse(command[2]);
                        // Draw a line from the current position (0, 0) to the specified coordinates (x, y)
                        g.DrawLine(Pens.Green, 0, 0, x, y);
                    }
                    else
                    {
                        // Handle invalid parameters for drawto
                        throw new Exception(" Invalid parameters for drawto. Please provide exactly 2 non-negative values.");
                    }
                }
                else if (command[0] == "moveto")
                {
                    if (command.Length == 3)
                    {
                        int x = int.Parse(command[1]);
                        int y = int.Parse(command[2]);
                        // Move the current position to the specified coordinates
                        g.TranslateTransform(x, y);
                    }
                    else
                    {
                        // Handle invalid parameters for moveto
                        throw new Exception(" Invalid parameters for moveto. Please provide exactly 2 values.");
                    }
                }
                else if (command[0] == "clear")
                {
                    g.Clear(Color.Gray);
                }
                else if (command[0] == "reset")
                {
                    // Move the current position to the initial position (0, 0)
                    g.ResetTransform();
                }
                else if (command[0].ToLower() == "pen")
                {
                    if (command[1] == "red")
                    {
                        shapeColor = Color.Red;
                    }
                    else if (command[1] == "blue")
                    {
                        shapeColor = Color.Blue;
                    }
                    else if (command[1] == "yellow")
                    {
                        shapeColor = Color.Yellow;
                    }
                    else if (command[1] == "black")
                    {
                        shapeColor = Color.Black;
                    }
                }
                else if (command[0] == "fill")
                {
                    if (command[1].Trim().ToLower() == "on")
                    {
                        fill = true;
                    }
                    else if (command[1].Trim().ToLower() == "off")
                    {
                        fill = false;
                    }
                }
                else
                {
                    // Handle unknown command
                    throw new Exception("Please enter valid command");
                }
            }
            catch (Exception ex)
            {
                if (testing == true)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }
                // Handle the exception or take appropriate actions
            }

        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment1;
using System.Drawing;
using System.Windows.Forms;
using Software_Engineering_Assignment;
using Software_Engineering_Assignment.Commands;

namespace Software_Engineering_Assignment

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CircleTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "circle 100";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);
            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    




        [TestMethod]
        public void NegativeCircleTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "circle -10";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);
            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void PositiveRectangleTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "Rectangle 50 100";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);
            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void NegativeRectangleTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "Rectangle 50 -20";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);
            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PositiveTriangleTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "Triangle 50 50 100";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);
            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void NegativeTriangleTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "Triangle 50 50 -10";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);
            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void movetoTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "moveto 50 50";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);
            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void FillCommandTest()
        {

            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string commandOn = "fill on";
            string commandOff = "fill off";
            string[] stringsOn = commandOn.Split(new char[] { ' ' });
            string[] stringsOff = commandOff.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);

            try
            {
                c.RunCommand(stringsOn, graphics, true);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                c.RunCommand(stringsOff, graphics, true);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DrawToTest()
        {

            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "drawto 100 150";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);

            try
            {
                c.RunCommand(strings, graphics);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ResetTest()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "reset";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);

            try
            {
                c.RunCommand(strings, graphics);

                Assert.IsTrue(graphics.Transform.Elements[0] == 1 && graphics.Transform.Elements[3] == 1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ClearTest()
        {

            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            string run = "run";
            string command = "clear";
            string[] strings = command.Split(new char[] { ' ' });
            CommandParser c = new CommandParser(graphics);

            try
            {
                c.RunCommand(strings, graphics);


                Assert.AreEqual(panel.Controls.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    

    [TestMethod]
    public void PenColorTest1()
    {
        Panel panel = new Panel();
        Graphics graphics = panel.CreateGraphics();
        string run = "run";
        string command = "pen red";
        string[] strings = command.Split(new char[] { ' ' });
        CommandParser c = new CommandParser(graphics);

        try
        {
            c.RunCommand(strings, graphics);

            Assert.IsTrue(c.shapeColor == Color.Red);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    
    [TestMethod]
    public void PenColorTest2()
    {
        Panel panel = new Panel();
        Graphics graphics = panel.CreateGraphics();
        string run = "run";
        string command = "pen black";
        string[] strings = command.Split(new char[] { ' ' });
        CommandParser c = new CommandParser(graphics);

        try
        {
            c.RunCommand(strings, graphics);

            Assert.IsTrue(c.shapeColor == Color.Black);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [TestMethod]
    public void PenColorTest3()
    {
        Panel panel = new Panel();
        Graphics graphics = panel.CreateGraphics();
        string run = "run";
        string command = "pen yellow";
        string[] strings = command.Split(new char[] { ' ' });
        CommandParser c = new CommandParser(graphics);

        try
        {
            c.RunCommand(strings, graphics);

            Assert.IsTrue(c.shapeColor == Color.Yellow);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
    }

    }
    

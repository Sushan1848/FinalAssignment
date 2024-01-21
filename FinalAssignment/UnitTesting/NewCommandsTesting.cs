using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering_Assignment.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTesting
{
    [TestClass]
    public class ErrorTesting
    {
        /// <summary>
        /// Executes command with invalid If syntax; should result in an error.
        /// </summary>
        [TestMethod]
        public void ExecuteCommandWithInvalidIfSyntaxShouldResultError()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            var commandFilter = new FilterCommand(graphics);

            string command = "temp = 100\nif temp == 100\ncircle 100\nendif";
            Assert.ThrowsException<Exception>(() => commandFilter.ExecuteCommands("run", command));
        }

        [TestMethod]
        public void ExecuteCommandWithInvalidMethodSyntaxShouldResultError()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            var commandFilter = new FilterCommand(graphics);

            string command = "method myMethod(a, b, c)\r\ndrawto 100 100\r\nendmethod\r\nmyMethod(1, 2, 4) \r\n";
            Assert.ThrowsException<Exception>(() => commandFilter.ExecuteCommands("run", command));
        }

        [TestMethod]
        public void ExecuteCommandWithInvalidLoopSyntaxShouldResultError()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            var commandFilter = new FilterCommand(graphics);

            string command = "x = 100\r\nWhile x < 200\r\ncircle x \r\ntemp =  x + 10\r\nEndloop";
            Assert.ThrowsException<Exception>(() => commandFilter.ExecuteCommands("run", command));
        }
    }


}








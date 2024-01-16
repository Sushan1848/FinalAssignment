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
    public class ErrorTestingMethod
    {
        [TestMethod]
        public void ExecuteCommandWithInvalidMethodSyntaxShouldResultError()
        {
            Panel panel = new Panel();
            Graphics graphics = panel.CreateGraphics();
            var commandFilter = new FilterCommand(graphics);

            string command = "method myMethod(a, b, c)\r\ndrawto 100 100\r\nendmethod\r\nmyMethod(1, 2, 4) \r\n";
            Assert.ThrowsException<Exception>(() => commandFilter.ExecuteCommands("run", command));
        }
    }
}

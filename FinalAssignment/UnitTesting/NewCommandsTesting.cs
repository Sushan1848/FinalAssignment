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
    public class ErrorTestingIF
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

            string command = "abc = 100\nif abc == 100\ncircle 100\nendif";
            Assert.ThrowsException<Exception>(() => commandFilter.ExecuteCommands("run", command));
        }
    }

}   



    
   


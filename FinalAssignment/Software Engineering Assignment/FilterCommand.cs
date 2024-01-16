using Software_Engineering_Assignment;
using Software_Engineering_Assignment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Engineering_Assignment.Commands
{
    /// <summary>
    /// Class to filter and execute commands.
    /// </summary>
    public class FilterCommand
    {
        private CommandParser commandParser;
        private Dictionary<string, string> variableNames;
        private Dictionary<string, List<string>> methodStatements;
        private Dictionary<string, List<string>> methodVariables;
        private string methodKey = "";

        private bool ifFlag;
        private bool whileFlag;
        private bool methodFlag;
        private Graphics g;

        private List<string> ifStatements;
        private List<string> whileStatements;
        private List<string> listMethodStatements;

        /// <summary>
        /// Constructor for FilterCommand.
        /// </summary>
        /// <param name="g">Graphics object.</param>
        public FilterCommand(Graphics g)
        {
            this.commandParser = new CommandParser(g);
            this.ifFlag = false;
            this.whileFlag = false;
            this.methodFlag = false;
            this.ifStatements = new List<string>();
            this.whileStatements = new List<string>();
            this.listMethodStatements = new List<string>();
            this.variableNames = new Dictionary<string, string> { };
            this.methodStatements = new Dictionary<string, List<string>> { };
            this.methodVariables = new Dictionary<string, List<string>> { };
            this.g = g;
        }

        /// <summary>
        /// Execute commands based on specified run and commands parameters.
        /// </summary>
        /// <param name="run">Run parameter.</param>
        /// <param name="commands">Command string.</param>
        public void ExecuteCommands(string run, string commands)
        {
            // Existing code...
        }

        // Existing methods...

        private void SetVariables(string command)
        {
            // Existing code...
        }

        private void IntialCommandParser(string[] command, Dictionary<string, string> dictionaryValues)
        {
            // Existing code...
        }

        /// <summary>
        /// Show an error message for invalid commands.
        /// </summary>
        internal void IsValidCommand()
        {
            MessageBox.Show("Please enter correct value");
        }
    }
}

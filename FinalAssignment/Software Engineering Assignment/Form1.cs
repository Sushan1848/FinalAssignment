using Software_Engineering_Assignment.Commands;
using Software_Engineering_Assignment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Engineering_Assignment
{
    public partial class Form1 : Form
    {
        FilterCommand filter;
        FilterCommand filter1;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = OutputBox.CreateGraphics();
            FilterCommand filter;
            FilterCommand filter1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FilterCommand parser = new FilterCommand(g);
            //parser.ExecuteCommands(SingleLineTextBox.Text, MultiLineTextBox.Text);
            ////parser.RunCommand(g);
            filter = new FilterCommand(g);
            filter1 = new FilterCommand(g);

            // Thread for the old multiline textbox commands
            Thread threadForOldTextBox = new Thread(() => {
                ExecuteCommands(filter, MultiLineTextBox.Text);
            });

            // Thread for the new multiline textbox commands
            Thread threadForNewTextBox = new Thread(() => {
                ExecuteCommands(filter1, MultiLineTextBox2.Text);
            });

            // Start the threads
            threadForOldTextBox.Start();
            threadForNewTextBox.Start();
        }

        // Updated the ExecuteCommands helper method
        private void ExecuteCommands(FilterCommand filterCommand, string commands)
        {
            // This will check if the call is from a non-UI thread
            if (this.InvokeRequired)
            {
                // Use Invoke to handle the command execution on the UI thread
                this.Invoke(new Action(() =>
                {
                    filterCommand.ExecuteCommands(SingleLineTextBox.Text, commands);
                }));
            }
            else
            {
                // If it's already on the UI thread, just execute the commands
                filterCommand.ExecuteCommands(SingleLineTextBox.Text, commands);
            }
        }

        private void fIleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SyntaxButton_Click(object sender, EventArgs e)
        {
            FilterCommand parser = new FilterCommand(g);
            //parser.RunCommand(g);

            // Combines the text from all three text boxes
            string singleLineCommand = SingleLineTextBox.Text.ToLower().Trim();
            string multiLineCommandOld = MultiLineTextBox.Text.ToLower().Trim();
            string multiLineCommandNew = MultiLineTextBox2.Text.ToLower().Trim();
            string allCommands = $"{singleLineCommand}\n{multiLineCommandOld}\n{multiLineCommandNew}";

            // Creates a CommandParser instance with the combined text.
           // CommandParser parser = new CommandParser(allCommands);

            // Performs a syntax check on the parsed commands.
            parser.IsValidCommand();


        }

        private void MultiLineTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SingleLineTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (.txt)|.txt|All Files (.)|.";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Save the necessary data to the file
                    // save the commands in richTextBox1.Text
                    writer.Write(MultiLineTextBox.Text);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (.txt)|.txt|All Files (.)|.";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Load the data from the file
                    // load the commands into richTextBox1.Text
                    MultiLineTextBox.Text = reader.ReadToEnd();
                }
            }
        }


        private void MultiLine2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MultiLineTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Graphical User Friendly Application to draw different shapes and sizes" + "\nPresents Circle, Rectangle and Triangle" +
                "\n Presented by Sushan Dhakal ",
            "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FlowerPattern flowerPattern = new FlowerPattern(Color.Red, 100, 100, 50, true);

            // Draw the flower pattern
            flowerPattern.draw(g, true);
        }
    }
}

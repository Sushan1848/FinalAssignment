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
    public class FilterCommand
    {
        CommandParser commandParser;
        private Dictionary<string, string> variableNames;
        private Dictionary<string, List<string>> methodStatements;
        private Dictionary<string, List<string>> methodVariables;
        private string methodKey = "";

        bool ifFlag;
        bool whileFlag;
        bool methodFlag;
        Graphics g;

        List<string> ifStatements;
        List<string> whileStatements;
        List<string> listMethodStatements;

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


        public void ExecuteCommands(string run, string commands)
        {
            if (run.ToLower() == "run")
            {
                string[] commandList = commands.Split('\n');
                if (commandList.Any(command => command.Contains("If")) && !commandList.Any(command => command.Contains("Endif")))
                {
                    throw new Exception("If statement needs an \"Endif\".");
                }

                if (commandList.Any(command => command.Contains("While")) && !commandList.Any(command => command.Contains("Endloop")))
                {
                    throw new Exception("While statement needs an \"Endloop\".");
                }

                if (commandList.Any(command => command.Contains("method")) && !commandList.Any(command => command.Contains("endmethod")))
                {
                    throw new Exception("method statement needs an \"endmethod\".");
                }

                foreach (string command in commandList)
                {
                    if (ifFlag == true)
                    {
                        ifStatements.Add(command.Trim());
                        if (command.Contains("Endif"))
                        {
                            ifFlag = false;
                            RunIfCondition(ifStatements);
                            ifStatements.Clear();
                        }
                    }

                    else if (whileFlag == true)
                    {
                        whileStatements.Add(command.Trim());
                        if (command.Contains("Endloop"))
                        {
                            whileFlag = false;
                            RunWhileCondition(whileStatements);
                            whileStatements.Clear();
                        }
                    }

                    else if (methodFlag == true)
                    {
                        listMethodStatements.Add(command.Trim());
                        if (command.Contains("endmethod"))
                        {
                            methodFlag = false;
                            methodStatements.Add(methodKey, listMethodStatements);
                            methodKey = "";
                        }
                    }

                    else
                    {
                        if (command.Contains("=") && command.Split('=').Length == 2)
                        {
                            SetVariables(command);
                            /*var variableDeclaration = command.Trim().Split('=');

                            if (int.TryParse(variableDeclaration[1], out int numericValue))
                            {
                                if (variableNames.ContainsKey(variableDeclaration[0].ToLower().Trim()))
                                {
                                    variableNames[variableDeclaration[0].ToLower().Trim()] = variableDeclaration[1].Trim();
                                }
                                else
                                {
                                    variableNames.Add(variableDeclaration[0].ToLower().Trim(), variableDeclaration[1].Trim());
                                }
                            }
                            else
                            {
                                throw new Exception("Variable assignment needs a numeric value.");
                            }*/

                        }

                        else if (command.Contains("If"))
                        {
                            ifFlag = true;
                            ifStatements.Add(command.Trim());
                        }

                        else if (command.Contains("While"))
                        {
                            whileFlag = true;
                            whileStatements.Add(command.Trim());
                        }

                        else if (command.Contains("method") && command.Contains("(") && command.Contains(")"))
                        {
                            methodFlag = true;
                            string pattern = @"^method\s+(\w+)\s*\(([^)]*)\)$";
                            Match match = Regex.Match(command.Trim(), pattern);
                            if (match.Success)
                            {
                                methodKey = match.Groups[1].Value;
                                string parameterString = match.Groups[2].Value;
                                string[] parameterArray = parameterString.Split(',').Select(p => p.Trim()).ToArray();

                                methodVariables.Add(methodKey, parameterArray.ToList());
                                listMethodStatements.Add(command.Trim());
                            }
                            else
                            {
                                throw new Exception("Invalid method declaration format");
                            }
                        }

                        else if (command.Contains("(") && command.Contains(")"))
                        {
                            string pattern = @"^(\w+)\s*\(([^)]*)\)$";

                            Match match = Regex.Match(command, pattern);

                            if (match.Success)
                            {
                                string methodName = match.Groups[1].Value;
                                string parameterString = match.Groups[2].Value;
                                string[] parameterArray = parameterString.Split(',').Select(p => p.Trim()).ToArray();
                                if (methodStatements.ContainsKey(methodName))
                                {
                                    RunMethod(methodStatements[methodName], methodName, parameterArray);
                                    methodStatements.Remove(methodName);
                                }
                            }
                            else
                            {
                                throw new Exception("Invalid method call.");
                            }
                        }

                        else
                        {
                            IntialCommandParser(command.Split(' '), variableNames);
                        }

                    }
                }
            }
            else
            {
                IntialCommandParser(run.Split(' '), variableNames);
            }
        }

        private void RunIfCondition(List<string> ifStatements)
        {
            string[] conditionVariables;
            string condition = ifStatements[0].Replace("If", "").Trim();

            if (ConditionResult(condition))
            {
                for (int i = 1; i < ifStatements.Count; i++)
                {
                    // MessageBox.Show(ifStatements[i]);
                    if (ifStatements[i].Contains("=") && whileStatements[i].Split('=').Length == 2)
                    {
                        SetVariables(ifStatements[i]);
                    }
                    else
                    {
                        var splitIfStatements = ifStatements[i].Split(' ');
                        IntialCommandParser(splitIfStatements, variableNames);
                    }
                }
            }
        }

        private void RunWhileCondition(List<string> whileStatements)
        {
            string[] conditionVariables;
            string condition = whileStatements[0].Replace("While", "").Trim();

            while (ConditionResult(condition))
            {
                for (int i = 1; i < whileStatements.Count; i++)
                {
                    if (whileStatements[i].Contains("=") && whileStatements[i].Split('=').Length == 2)
                    {
                        SetVariables(whileStatements[i]);
                        /*var variableDeclaration = whileStatements[i].Split('=');
                        if (variableNames.ContainsKey(variableDeclaration[0].Trim()))
                        {
                            if (variableDeclaration[1].Trim().Contains("+"))
                            {
                                var counter = variableDeclaration[1].Trim().Split('+');

                                int count = int.Parse(variableNames[counter[0].Trim()]) + int.Parse(counter[1].Trim());
                                variableNames[variableDeclaration[0].Trim()] = count.ToString();

                            }

                            else if (variableDeclaration[1].Trim().Contains("-"))
                            {
                                var counter = variableDeclaration[1].Trim().Split('-');

                                int count = int.Parse(variableNames[counter[0].Trim()]) - int.Parse(counter[1].Trim());
                                variableNames[variableDeclaration[0].Trim()] = count.ToString();
                            }
                        }*/

                    }

                    else
                    {
                        var splitWhileStatements = whileStatements[i].Split(' ');
                        IntialCommandParser(splitWhileStatements, variableNames);
                    }
                }
            }
        }

        private void RunMethod(List<string> methodStatements, string methodName, string[] parameterArray)
        {
            Dictionary<string, string> methodDictionary = new Dictionary<string, string>();

            if (methodStatements[0].Contains("(") && methodStatements[0].Contains(")"))
            {
                if (parameterArray.Length == methodVariables[methodName].Count())
                {
                    for (int i = 0; i < parameterArray.Length; i++)
                    {
                        methodDictionary.Add(methodVariables[methodName][i].Trim(), parameterArray[i].Trim());
                    }
                    for (int i = 1; i < methodStatements.Count; i++)
                    {
                        IntialCommandParser(methodStatements[i].Split(' '), methodDictionary);
                    }

                }
                else
                {
                    throw new Exception("Error paremeter declaration.");
                }
                //string parameters = methodStatements[0].Replace("method", "").Trim();
            }
        }

        public bool ConditionResult(string condition)
        {
            if (condition.Contains(">") && !condition.Contains("="))
            {
                var splitCommand = condition.Trim().Split('>');
                if (variableNames.ContainsKey(splitCommand[0].Trim()))
                {
                    if (int.Parse(variableNames[splitCommand[0].Trim()]) > int.Parse(splitCommand[1].Trim()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Variable declaration not found");
                }
            }

            else if (condition.Contains("<") && !condition.Contains("="))
            {
                var splitCommand = condition.Trim().Split('<');
                if (int.Parse(variableNames[splitCommand[0].Trim()]) < int.Parse(splitCommand[1].Trim()))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else if (condition.Contains("<="))
            {
                var splitCommand = condition.Trim().Split(new[] { "<=" }, StringSplitOptions.None);
                if (int.Parse(variableNames[splitCommand[0].Trim()]) <= int.Parse(splitCommand[1].Trim()))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else if (condition.Contains(">="))
            {
                var splitCommand = condition.Trim().Split(new[] { ">=" }, StringSplitOptions.None);
                if (int.Parse(variableNames[splitCommand[0].Trim()]) >= int.Parse(splitCommand[1].Trim()))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else if (condition.Contains("=="))
            {
                var splitCommand = condition.Trim().Split(new[] { "==" }, StringSplitOptions.None);
                if (int.Parse(variableNames[splitCommand[0].Trim()]) == int.Parse(splitCommand[1].Trim()))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                throw new Exception("Invalid operator.");
            }

            //return false;
        }

        private void SetVariables(string command)
        {
            //MessageBox.Show(command);
            var variableDeclaration = command.Trim().Split('=');


            if (variableNames.ContainsKey(variableDeclaration[0].Trim()) && (variableDeclaration[1].Trim().Contains('+') || variableDeclaration[1].Trim().Contains('-')))
            {
                if (variableDeclaration[1].Trim().Contains("+"))
                {
                    var counter = variableDeclaration[1].Trim().Split('+');

                    int count = int.Parse(variableNames[counter[0].Trim()]) + int.Parse(counter[1].Trim());
                    variableNames[variableDeclaration[0].Trim()] = count.ToString();

                }

                else if (variableDeclaration[1].Trim().Contains("-"))
                {
                    var counter = variableDeclaration[1].Trim().Split('-');

                    int count = int.Parse(variableNames[counter[0].Trim()]) - int.Parse(counter[1].Trim());
                    variableNames[variableDeclaration[0].Trim()] = count.ToString();
                }
            }

            else if (int.TryParse(variableDeclaration[1], out int numericValue))
            {
                if (variableNames.ContainsKey(variableDeclaration[0].ToLower().Trim()))
                {
                    variableNames[variableDeclaration[0].ToLower().Trim()] = variableDeclaration[1].Trim();
                }
                else
                {
                    variableNames.Add(variableDeclaration[0].ToLower().Trim(), variableDeclaration[1].Trim());
                }
            }

            else
            {
                throw new Exception("Variable assignment needs a numeric value.");
            }
        }

        private void IntialCommandParser(string[] command, Dictionary<string, string> dictionaryValues)
        {
            if (command[0].Trim().ToLower().Contains("pen") || command[0].Trim().ToLower().Contains("reset") || command[0].Trim().ToLower().Contains("fill") || command[0].Trim().ToLower().Contains("clear"))
            {

            }
            else
            {
                for (int i = 1; i < command.Count(); i = i + 1)
                {
                    if (int.TryParse(command[i].Trim(), out int parsedValue))
                    {

                    }
                    else if (dictionaryValues.ContainsKey(command[i].Trim()))
                    {




                        command[i] = dictionaryValues[command[i].Trim()];

                    }
                    else
                    {
                        throw new Exception("Error finding variable: " + command[i]);
                        /*  try
                          {
                              throw new Exception("Error finding variable: " + command[i]);
                          }
                          catch (Exception)
                          {
                              MessageBox.Show("Error finding variable: " + command[i]);
                          }
                        */
                    }

                }
            }
            commandParser.RunCommand(command, g, false);
        }

        internal void IsValidCommand()
        {
            MessageBox.Show("Please enter correct value");
        }

        /* public async Task DrawShapesFilter(Graphics graphics)
         {
             await commandParser.DrawShapesAsync(graphics);
         }*/
    }
}
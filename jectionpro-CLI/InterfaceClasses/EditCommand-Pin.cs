using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Runtime.InteropServices;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class EditCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("edit", "Edit an existing pin. [not implemented]");
            
            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }

        private static void Handler()
        {
            var currentProject = ProjectCommand.GetCurrentProject();

            PinCommand.VerifyOpenPin();

            var text = PinCommand.OpenPin.TextContent;

            PinCommand.OpenPin.TextContent = ReadDynamicInput(text);
            
            ProjectCommand.Save(currentProject.ToXml());
        }

        private static string ReadDynamicInput(string input)
        {
            Console.Write(input);
            
            var lines = input.Split("\n");
            var currentLine = 0;
            
            while (true)
            {
                var key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.Enter && key.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    Console.WriteLine();
                    break;
                }
                
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    break;
                }
                
                if (key.Key == ConsoleKey.Enter)
                {
                    input += Environment.NewLine;
                    Console.WriteLine();
                    currentLine++;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (currentLine == 0)
                        continue;
                    
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    currentLine--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (currentLine == lines.Length - 1)
                        continue;
                    
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    currentLine++;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Console.CursorLeft == 0)
                        continue;
                    
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (Console.CursorLeft == lines[currentLine].Length - 1)
                        continue;
                    
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (Console.CursorLeft == 0)
                    {
                        if (currentLine == 0)
                            continue;
                        
                        Console.SetCursorPosition(lines[--currentLine].Length,Console.CursorTop - 1);
                        Console.Write(" ");
                        continue;
                    }

                    //Put the cursor on character back
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    //Delete it with a space
                    Console.Write(" ");
                    //Put it back again
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    //Delete the last char of the input
                    input = string.Join("", input.Take(input.Length - 1));
                }
                //Regular key? add it to the input
                else if (
                    char.IsLetterOrDigit(key.KeyChar) ||
                    char.IsSymbol(key.KeyChar) || 
                    char.IsWhiteSpace(key.KeyChar) || 
                    char.IsPunctuation(key.KeyChar))
                {
                    input += key.KeyChar.ToString();
                    Console.Write(key.KeyChar);
                } //else it must be another control code (ESC etc) or something.

                lines = input.Split(Environment.NewLine);
            }

            return input;
        }
    }
}
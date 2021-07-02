using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Runtime.InteropServices;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class EditCommand_Pin
    {
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        
        const int VkReturn = 0x0D;
        const int WmKeydown = 0x100;
        
        public static Command GetCommand()
        {
            var command = new Command("edit", "Edit an existing pin. [not implemented]");
            
            command.Handler = CommandHandler.Create<int>(Handler);
            
            return command;
        }

        public static void Handler(int id)
        {
            var currentProject = ProjectCommand.GetCurrentProject();

            if (PinCommand.OpenPin == null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "pin");
                return;
            }

            var text = PinCommand.OpenPin.TextContent;

            PinCommand.OpenPin.TextContent = ReadDynamicInput(text);
            
            Project.Save(currentProject.ToXml());
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
                
                if (key.Key == ConsoleKey.Enter)
                {
                    input += key.KeyChar.ToString();
                    Console.WriteLine();
                    currentLine++;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (Console.CursorLeft == 0)
                    {
                        if (currentLine == 0)
                            continue;

                        Console.SetCursorPosition(lines[--currentLine].Length,Console.CursorTop - 1);
                        Console.Write(" ");
                        continue; //suppress
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

                lines = input.Split("\n");
            }

            return input;
        }
    }
}
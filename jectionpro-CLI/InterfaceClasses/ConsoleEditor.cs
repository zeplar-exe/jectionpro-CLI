using System;
using System.Collections.Generic;
using System.Linq;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class ConsoleEditor
    {
        public static string ReadDynamicInput(string input)
        {
            input = input.Replace("\n", Environment.NewLine);
            
            Console.Write(input);
            var lines = input.Split(Environment.NewLine).ToList();
            var currentLine = lines.Count - 1;

            if (currentLine == -1)
                currentLine = 0;

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
                    lines[currentLine] += Environment.NewLine;
                    lines.Insert(++currentLine, "");
                    Console.WriteLine();
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (currentLine == 0)
                        continue;

                    int leftPosition = Console.CursorLeft;

                    if (leftPosition > lines[--currentLine].Length)
                        leftPosition = lines[currentLine].Length;
                    
                    Console.SetCursorPosition(leftPosition, Console.CursorTop - 1);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (currentLine++ == lines.Count - 1)
                        continue;

                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Console.CursorLeft == 0)
                        continue;

                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (Console.CursorLeft == lines[currentLine].Length)
                        continue;

                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (Console.CursorLeft == 0)
                    {
                        if (currentLine == 0)
                            continue;
                        
                        int leftPosition = Console.CursorLeft;

                        if (leftPosition > lines[--currentLine].Length)
                            leftPosition = lines[currentLine].Length;
                    
                        Console.SetCursorPosition(leftPosition, Console.CursorTop - 1);
                        
                        continue; // TODO: Fix error on newline deletion

                        Console.SetCursorPosition(lines[--currentLine].Length, Console.CursorTop - 1);
                        Console.Write(" ");
                        lines.RemoveAt(currentLine);
                        
                        continue;
                    }

                    //Put the cursor on character back
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    //Delete it with a space
                    Console.Write(" ");
                    //Put it back again
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    //Delete the last char of the input
                    lines[currentLine] = lines[currentLine].Remove(lines[currentLine].Length - 1, 1);
                }
                //Regular key? add it to the input
                else if (
                    char.IsLetterOrDigit(key.KeyChar) ||
                    char.IsSymbol(key.KeyChar) ||
                    char.IsWhiteSpace(key.KeyChar) ||
                    char.IsPunctuation(key.KeyChar))
                {
                    lines[currentLine] += key.KeyChar.ToString();
                    Console.Write(key.KeyChar);
                } //else it must be another control code (ESC etc) or something.
            }

            input = string.Join("", lines).Replace(Environment.NewLine, "\n");

            return input;
        }
    }
}
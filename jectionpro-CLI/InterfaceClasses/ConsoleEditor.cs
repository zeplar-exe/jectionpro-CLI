using System;
using System.Collections.Generic;
using System.Linq;

namespace jectionpro_CLI.InterfaceClasses
{
    internal class ConsoleEditor
    {
        public Buffer Buffer;
        private Cursor _cursor;
        private readonly Stack<object> _history;
        private bool isRunning;

        public ConsoleEditor(IEnumerable<string> lines)
        {
            Buffer = new Buffer(lines);
            _cursor = new Cursor();
            _history = new Stack<object>();
        }

        public void Run()
        {
            isRunning = true;
            
            while (isRunning)
            {
                Render();
                HandleInput();
            }
        }

        public void Stop()
        {
            isRunning = false;
        }

        private void HandleInput()
        {
            var character = Console.ReadKey();


            if ((ConsoleModifiers.Control & character.Modifiers) != 0 &&
                character.Key == ConsoleKey.Q)
            {
                Stop();
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) != 0 &&
                     character.Key == ConsoleKey.P)
            {
                _cursor = _cursor.Up(Buffer);
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) != 0 &&
                     character.Key == ConsoleKey.N)
            {
                _cursor = _cursor.Down(Buffer);
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) != 0 &&
                     character.Key == ConsoleKey.B)
            {
                _cursor = _cursor.Left(Buffer);
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) != 0 &&
                     character.Key == ConsoleKey.Z)
            {
                _cursor = _cursor.Right(Buffer);
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) != 0 &&
                     character.Key == ConsoleKey.U)
            {
                RestoreSnapshot();
            }

            else if (character.Key == ConsoleKey.Backspace)
            {
                if (_cursor.Col > 0)
                {
                    SaveSnapshot();
                    Buffer = Buffer.Delete(_cursor.Row, _cursor.Col - 1);
                    _cursor = _cursor.Left(Buffer);
                }
            }

            else if (character.Key == ConsoleKey.Enter)
            {
                SaveSnapshot();
                Buffer = Buffer.SplitLine(_cursor.Row, _cursor.Col);
                _cursor = _cursor.Down(Buffer).MoveToCol(0);
            }

            else
            {
                SaveSnapshot();
                Buffer = Buffer.Insert(character.KeyChar.ToString(), _cursor.Row, _cursor.Col);
                _cursor = _cursor.Right(Buffer);
            }
        }

        private void Render()
        {
            ANSI.ClearScreen();
            ANSI.MoveCursor(0, 0);
            Buffer.Render();
            ANSI.MoveCursor(_cursor.Row, _cursor.Col);
        }

        private void SaveSnapshot()
        {
            _history.Push(_cursor);
            _history.Push(Buffer);
        }

        private void RestoreSnapshot()
        {
            if (_history.Count > 0)
            {
                Buffer = (Buffer) _history.Pop();
                _cursor = (Cursor) _history.Pop();
            }
        }
    }

    internal class Buffer
    {
        public readonly string[] Lines;

        public Buffer(IEnumerable<string> lines)
        {
            Lines = lines.ToArray();
        }

        public void Render()
        {
            foreach (var line in Lines) Console.WriteLine(line);
        }

        public int LineCount()
        {
            return Lines.Count();
        }

        public int LineLength(int row)
        {
            return Lines[row].Length;
        }

        internal Buffer Insert(string character, int row, int col)
        {
            var linesDeepCopy = Lines.Select(x => x).ToArray();
            linesDeepCopy[row] = linesDeepCopy[row].Insert(col, character);
            return new Buffer(linesDeepCopy);
        }

        internal Buffer Delete(int row, int col)
        {
            var linesDeepCopy = Lines.Select(x => x).ToArray();
            linesDeepCopy[row] = linesDeepCopy[row].Remove(col, 1);
            return new Buffer(linesDeepCopy);
        }

        internal Buffer SplitLine(int row, int col)
        {
            var linesDeepCopy = Lines.Select(x => x).ToList();

            var line = linesDeepCopy[row];

            var newLines = new[]
                {line.Substring(0, col), line.Substring(col, line.Length - line.Substring(0, col).Length)};

            linesDeepCopy[row] = newLines[0];
            linesDeepCopy[row + 1] = newLines[1];


            return new Buffer(linesDeepCopy);
        }
    }

    internal class Cursor
    {
        public Cursor(int row = 0, int col = 0)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        internal Cursor Up(Buffer buffer)
        {
            return new Cursor(Row - 1, Col).Clamp(buffer);
        }

        internal Cursor Down(Buffer buffer)
        {
            return new Cursor(Row + 1, Col).Clamp(buffer);
        }


        internal Cursor Left(Buffer buffer)
        {
            return new Cursor(Row, Col - 1).Clamp(buffer);
        }

        internal Cursor Right(Buffer buffer)
        {
            return new Cursor(Row, Col + 1).Clamp(buffer);
        }

        private Cursor Clamp(Buffer buffer)
        {
            Row = Math.Min(buffer.LineCount() - 1, Math.Max(Row, 0));
            Col = Math.Min(buffer.LineLength(Row), Math.Max(Col, 0));
            return new Cursor(Row, Col);
        }

        internal Cursor MoveToCol(int col)
        {
            return new Cursor(Row);
        }
    }

    internal class ANSI
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void MoveCursor(int row, int col)
        {
            Console.CursorTop = row;
            Console.CursorLeft = col;
        }
    }
}
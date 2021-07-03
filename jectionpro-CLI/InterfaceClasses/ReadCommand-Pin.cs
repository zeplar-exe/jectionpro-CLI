using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class ReadCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("read", "Read the text content of the currently opened pin.");
            
            command.Handler = CommandHandler.Create(Handler);

            return command;
        }

        private static void Handler()
        {
            PinCommand.VerifyOpenPin();
            
            Console.WriteLine(PinCommand.OpenPin.TextContent);
        }
    }
}
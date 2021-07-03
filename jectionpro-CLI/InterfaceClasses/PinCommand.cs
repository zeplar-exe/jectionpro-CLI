using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class PinCommand
    {
        internal static Pin OpenPin;
        
        public static Command GetCommand()
        {
            var command = new Command("pin", "Create and manipulate pins.")
            {
                CreateCommand_Pin.GetCommand(),
                DeleteCommand_Pin.GetCommand(),
                EditCommand_Pin.GetCommand(),
                OpenCommand_Pin.GetCommand(),
                CloseCommand_Pin.GetCommand(),
                MoveCommand_Pin.GetCommand(),
                DisplayCommand_Pin.GetCommand(),
                ReadCommand_Pin.GetCommand(),
                DescCommand_Pin.GetCommand()
            };
            
            command.Handler = CommandHandler.Create(Handler);

            return command;
        }

        private static void Handler()
        {
            ProjectCommand.VerifyCurrentProject();
        }

        public static void VerifyOpenPin()
        {
            if (OpenPin == null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "pin");
                Environment.Exit(1);
            }
        }
    }
}
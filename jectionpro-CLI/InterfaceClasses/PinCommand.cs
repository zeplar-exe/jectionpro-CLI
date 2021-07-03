using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class PinCommand
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
                DisplayCommand_Pin.GetCommand()
            };
            
            command.Handler = CommandHandler.Create(Handler);

            return command;
        }

        private static void Handler()
        {
            if (ProjectCommand.GetCurrentProject() == null)
            {
                throw new Exception(ParsingErrorResources.NoProjectFound);
            }
        }
    }
}
using System.CommandLine;
using jectionpro_CLI.Classes;

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
                MoveCommand_Pin.GetCommand()
            };

            return command;
        }
    }
}
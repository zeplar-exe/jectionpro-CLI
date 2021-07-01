using System.CommandLine;
using jectionpro_CLI.Classes;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class ListCommand
    {
        internal static PinList OpenList;
        
        public static Command GetCommand()
        {
            var command = new Command("list", "Create and manipulate pin lists.")
            {
                CreateCommand_List.GetCommand(),
                DisplayCommand_List.GetCommand(),
                OpenCommand_List.GetCommand(),
                CloseCommand_List.GetCommand(),
                DeleteCommand_List.GetCommand()
            };

            return command;
        }
    }
}
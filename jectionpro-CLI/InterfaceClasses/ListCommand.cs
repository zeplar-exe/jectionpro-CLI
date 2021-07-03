using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

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
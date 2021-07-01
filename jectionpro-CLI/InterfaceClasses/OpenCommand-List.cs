using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class OpenCommand_List
    {
        public static Command GetCommand()
        {
            var command = new Command("open", "Opens a list to automatically write to it via other commands.")
            {
                new Argument<int>("id", getDefaultValue: () => -1)
            };

            command.Handler = CommandHandler.Create<int>(Handler);
            
            return command;
        }

        private static void Handler(int id)
        {
            var list = ProjectCommand.GetCurrentProject().GetPinListById(id);

            if (list is null)
            {
                Console.WriteLine(ParsingErrorResources.InvalidListId, id);
                return;
            }
            
            Console.WriteLine(OtherMessagesResources.ListOpened, list.Name);
            ListCommand.OpenList = list;
            // TODO: Make this persistent
        }
    }
}
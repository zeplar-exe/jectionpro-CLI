using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class CloseCommand_List
    {
        public static Command GetCommand()
        {
            var command = new Command("close", "Close the currently opened list.");

            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }

        private static void Handler()
        {
            if (ListCommand.OpenList != null)
            {
                Console.WriteLine(OtherMessagesResources.ListClosed, ListCommand.OpenList.Name);
                ListCommand.OpenList = null;
            }
        }
    }
}
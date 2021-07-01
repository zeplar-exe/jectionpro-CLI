using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class DeleteCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("delete", "Delete an existing pin.");

            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }
        
        private static void Handler()
        {
            if (ListCommand.OpenList == null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "list");
                return;
            }

            if (PinCommand.OpenPin == null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "pin");
                return;
            }

            ListCommand.OpenList.Remove(PinCommand.OpenPin);
            ListCommand.OpenList = null;
            Project.Save(ProjectCommand.GetCurrentProject().ToXml());
        }
    }
}
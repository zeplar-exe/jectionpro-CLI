using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
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
            var currentProject = ProjectCommand.GetCurrentProject();
            
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

            currentProject.GetPinListById(ListCommand.OpenList.Id)?.Remove(PinCommand.OpenPin.Id);
            ListCommand.OpenList.Remove(PinCommand.OpenPin);
            PinCommand.OpenPin = null;
            ProjectCommand.Save(currentProject.ToXml());
        }
    }
}
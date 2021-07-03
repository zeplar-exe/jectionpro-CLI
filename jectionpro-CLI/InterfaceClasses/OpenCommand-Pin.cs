using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class OpenCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("open", "Opens a pin to automatically write to it via other commands.")
            {
                new Argument<int>("id", getDefaultValue: () => -1)
            };

            command.Handler = CommandHandler.Create<int>(Handler);
            
            return command;
        }

        private static void Handler(int id)
        {
            var currentProject = ProjectCommand.GetCurrentProject();
            
            if (ListCommand.OpenList == null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "list");
                return;
            }
            
            PinCommand.OpenPin = ListCommand.OpenList.GetPinById(id);

            if (PinCommand.OpenPin == null)
            {
                Console.WriteLine(ParsingErrorResources.InvalidPinId, id);
                return;
            }
            
            Console.WriteLine(OtherMessagesResources.OpenedPin, PinCommand.OpenPin.Name);
            ProjectCommand.Save(currentProject.ToXml());
        }
    }
}
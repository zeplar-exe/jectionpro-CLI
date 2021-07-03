using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class MoveCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("move", "Moves a pin to another pin list.")
            {
                new Option<int>("--list", getDefaultValue: () => -1)
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

            if (PinCommand.OpenPin == null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "pin");
                return;
            }

            if (id == -1)
            {
                var oldParent = PinCommand.OpenPin.Parent;
                
                ListCommand.OpenList.Add(PinCommand.OpenPin);
                oldParent.Remove(PinCommand.OpenPin);
                Console.WriteLine(OtherMessagesResources.PinMoved, PinCommand.OpenPin.Name, ListCommand.OpenList);
                
                return;
            }

            var newList = currentProject.GetPinListById(id);

            if (newList == null)
            {
                Console.WriteLine(ParsingErrorResources.InvalidListId, id);
                return;
            }
            
            var oldParentE = PinCommand.OpenPin.Parent;
                
            newList.Add(PinCommand.OpenPin);
            oldParentE.Remove(PinCommand.OpenPin);
            Console.WriteLine(OtherMessagesResources.PinMoved, PinCommand.OpenPin.Name, newList.Name);
            
            ProjectCommand.Save(currentProject.ToXml());
            
            // TODO: Make this less bloated
        }
    }
}
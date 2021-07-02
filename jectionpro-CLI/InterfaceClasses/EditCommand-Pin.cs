using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class EditCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("edit", "Edit an existing pin. [not implemented]");
            
            command.Handler = CommandHandler.Create<int>(Handler);
            
            return command;
        }

        public static void Handler(int id)
        {
            Console.WriteLine(ParsingErrorResources.CommandNotImplemented);
            return;

            var currentProject = ProjectCommand.GetCurrentProject();

            if (PinCommand.OpenPin == null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "pin");
                return;
            }

            /*var editor = new ConsoleEditor(PinCommand.OpenPin.TextContent.Split("\n").Where(x => x != Environment.NewLine));
            editor.Run();

            PinCommand.OpenPin.TextContent = string.Join("", editor.Buffer.Lines);*/
            // TODO: Add back edit mode
            
            Project.Save(currentProject.ToXml());
        }
    }
}
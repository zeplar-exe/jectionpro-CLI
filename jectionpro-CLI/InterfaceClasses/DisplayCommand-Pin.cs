using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class DisplayCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("display", "Lists all pins in the currently opened pin list.");

            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }

        private static void Handler()
        {
            ListCommand.VerifyOpenList();
            
            var outputList = new StringBuilder();
            
            outputList.AppendLine("Pins in current pin list:");
            outputList.AppendLine();
            
            ListCommand.OpenList.ForEach(pin => outputList.AppendLine(pin.Name + $" (ID: {pin.Id})"));

            Console.WriteLine(outputList.ToString());
        }
    }
}
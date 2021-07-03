using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace jectionpro_CLI.InterfaceClasses
{
    public class RootCommandBuilder : RootCommand
    {
        private const string Version = "1.1.2";
        
        public RootCommandBuilder()
        {
            var descBuilder = new StringBuilder("jectionpro CLI");
            
            Description = descBuilder.ToString();

            Add(ProjectCommand.GetCommand());
            Add(ListCommand.GetCommand());
            Add(PinCommand.GetCommand());

            Add(new Option(
                new[] {"-v", "--version"},
                "Displays the current CLI version",
                typeof(bool)));

            Handler = CommandHandler.Create<bool>(RootHandler);
        }

        private void RootHandler(bool version)
        {
            if (version)
                Console.WriteLine(Version);
        }
    }
}
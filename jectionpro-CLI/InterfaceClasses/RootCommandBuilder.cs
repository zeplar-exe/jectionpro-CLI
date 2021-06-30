using System.CommandLine;
using System.Text;

namespace jectionpro_CLI.InterfaceClasses
{
    public class RootCommandBuilder : RootCommand
    {
        public RootCommandBuilder()
        {
            var descBuilder = new StringBuilder("jectionpro CLI");
            
            Description = descBuilder.ToString();

            Add(ProjectCommand.GetCommand());
            Add(ListCommand.GetCommand());
        }
    }
}
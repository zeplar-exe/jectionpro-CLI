using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using jectionpro_CLI.Classes;
using jectionpro_CLI.InterfaceClasses;

namespace jectionpro_CLI
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (ProjectCommand.GetCurrentProject() == null)
            {
                return 1;
            }
            
            RootCommand root = new RootCommandBuilder();

            return root.InvokeAsync(args).Result;
        }
    }
}
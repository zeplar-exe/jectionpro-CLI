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
            RootCommand root = new RootCommandBuilder();

            try
            {
                return root.InvokeAsync(args).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 1;
        }
    }
}
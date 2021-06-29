using System;
using System.Collections.Generic;

namespace jectionpro_CLI.Library
{
    public class Project : List<PinList>
    {
        public string Name;
        public string Description;
        public Guid Link;

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
            Link = Guid.NewGuid();
        }
    }
}
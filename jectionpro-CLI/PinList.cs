using System;
using System.Collections.Generic;
using System.Linq;

namespace jectionpro_CLI.Library
{
    public class PinList : List<Pin>
    {
        public string Name;
        public string ShortDesc;
        public Guid Link;

        public PinList(string name, string shortDesc)
        {
            Name = name;
            ShortDesc = shortDesc;
            Link = Guid.NewGuid();
        }

        public void Remove(Guid link)
        {
            Remove(GetPinByLink(link));
        }

        public List<Pin> GetPinsByName(string name)
        {
            return this.Where(pin => pin.Name == name).ToList();
        }

        public Pin GetPinByLink(Guid link)
        {
            return this.DefaultIfEmpty(null).First(pin => pin.Link == link);
        }
    }
}
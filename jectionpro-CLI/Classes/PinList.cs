using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace jectionpro_CLI.Classes
{
    public class PinList : List<Pin>
    {
        public string Name;
        public string Description;
        public readonly Guid Id;

        public PinList(string name, string description)
        {
            Name = name;
            Description = description;
            Id = Guid.NewGuid();
        }

        public void Remove(Guid id)
        {
            Remove(GetPinByLink(id));
        }

        public XElement ToXml()
        {
            var xml = new XElement("pinlist");
            var pins = new XElement("pins");
            
            xml.Add("name", Name);
            xml.Add("description", Description);

            foreach (var pin in this)
            {
                pins.Add("pin", pin.ToXml());
            }
            
            xml.Add(pins);

            return xml;
        }

        public static PinList FromXml(XElement xml)
        {
            var list = new PinList(xml.Element("name")?.Value, xml.Element("description")?.Value);
            
            foreach (var pin in xml.Elements("pins"))
            {
                list.Add(Pin.FromXml(pin));
            }

            return list;
        }

        public List<Pin> GetPinsByName(string name)
        {
            return this.Where(pin => pin.Name == name).ToList();
        }

        public Pin GetPinByLink(Guid id)
        {
            return this.DefaultIfEmpty(null).First(pin => pin.Id == id);
        }
    }
}
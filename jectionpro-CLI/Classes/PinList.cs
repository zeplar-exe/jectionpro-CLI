using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace jectionpro_CLI.Classes
{
    public class PinList : List<Pin>
    {
        public string Name;
        public int Id;

        public PinList(string name)
        {
            Name = name;
        }

        public new void Add(Pin item)
        {
            item.Id = Count;
            item.Parent = this;
            base.Add(item);
        }

        public void Remove(int id)
        {
            base.Remove(GetPinById(id));
        }

        public XElement ToXml()
        {
            var xml = new XElement("pinlist");
            var pins = new XElement("pins");
            
            xml.Add(new XElement("name", Name));
            xml.Add(new XElement("id", Id));

            foreach (var pin in this)
            {
                pins.Add(pin.ToXml());
            }
            
            xml.Add(pins);

            return xml;
        }

        public static PinList FromXml(XElement xml)
        {
            var list = new PinList(xml.Element("name")?.Value);
            list.Id = Convert.ToInt32(xml.Element("id")?.Value);
            
            foreach (var pin in xml.Element("pins").Elements("pin"))
            {
                list.Add(Pin.FromXml(pin));
            }

            return list;
        }

        public List<Pin> GetPinsByName(string name)
        {
            return this.Where(pin =>
            {
                if (pin != null)
                    return pin.Name == name;

                return false;
            }).ToList();
        }

        public Pin GetPinById(int id)
        {
            return this.DefaultIfEmpty(null).FirstOrDefault(pin =>
            {
                if (pin != null) return pin.Id == id;

                return false;
            });
        }
    }
}
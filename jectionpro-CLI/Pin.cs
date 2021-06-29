using System;
using System.Collections.Generic;

namespace jectionpro_CLI.Library
{
    public class Pin
    {
        public string Name;
        public string Description;
        public List<PinContent> Content;
        public Guid Link;

        public string Text { get; private set; }

        public Pin(string name, string text = "")
        {
            Name = name;
            Text = text;
            Link = Guid.NewGuid();
        }

        public void AppendText(string newText)
        {
            Text += newText;
        }
        
        public void OverwriteText(string newText)
        {
            Text = newText;
        }
    }
}
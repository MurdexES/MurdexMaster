using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentarySlavery
{
    public class Document : ICloneable
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int FontSize { get; set; }
        public Document() { }
        public Document(string name, string text, int fontsize) 
        {
            Name = name;
            Text = text;
            FontSize = fontsize;
        }

        public object Clone() => new Document()
        {
            Name = this.Name,
            Text = this.Text,
            FontSize = this.FontSize,
        };
    }
}

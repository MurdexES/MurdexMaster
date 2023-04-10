using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderGitMerge.Model
{
    public class Character
    {
        public string Name { get; set; }
        public uint Damage { get; set; } = 25;
        public uint Health { get; set; } = 50;
        public uint Shield { get; set; } = 100;
    }
}

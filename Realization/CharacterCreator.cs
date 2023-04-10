using BuilderGitMerge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderGitMerge.Realization
{
    public class CharacterCreator
    {
        public Character CreateCharacter(string name)
        {
            Character ch = new Character() { Name = name};
            
            return ch;
        }
    }
}

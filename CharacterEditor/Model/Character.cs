using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CharacterEditor.Model
{
    public class Character: IResettable
    {
        public string Name { get; set; }
        public Stat Strength { get; } = new Stat("Strength", "STR", 0);

        public void Reset()
        {
            Strength.Reset();
        }
    }
}
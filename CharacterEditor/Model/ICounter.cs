using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor.Model
{
    public interface ICounter
    {
        ICounter Increment(uint x);
        ICounter Decrement(uint x);
    }
}

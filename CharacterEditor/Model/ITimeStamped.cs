using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor.Model
{
    interface ITimeStamped
    {
        DateTimeOffset Read();
        DateTimeOffset Set(DateTimeOffset time);
    }
}

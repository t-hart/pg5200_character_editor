using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CharacterEditor.Model
{
    public class Stat : IResettable, IAddable
    {
        public string Name { get; }
        public string DisplayName { get; }

        public int Value { get; set; }

        private readonly int _defaultValue;

        public Stat([NotNull] string name, [NotNull] string displayName, int defaultValue)
        {
            Name = name;
            DisplayName = displayName;
            _defaultValue = defaultValue;
        }

        public void Reset()
        {
            Value = _defaultValue;
        }

        public int Add(int x) => (Value += x);
    }
}

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
        const uint STAT_MAX = 20;
        public string Name { get; }
        public string DisplayName { get; }

        private uint _value;
        public uint Value
        {
            get => _value;
            set => _value = Stat.Clamp(value);
        }

        private readonly uint _defaultValue = 0;

        public Stat([NotNull] string name, [NotNull] string displayName, uint value, uint defaultValue)
        {
            Name = name;
            DisplayName = displayName;
            Value = value;
            _defaultValue = Stat.Clamp(defaultValue);
        }

        public void Reset()
        {
            Value = _defaultValue;
        }

        public uint Add(uint x) => (Value += x);

        public static uint Clamp(uint x) => Math.Min(x, STAT_MAX);
    }
}

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

        private uint _value;
        public uint Value
        {
            get => _value;
            set => _value = Clamp(value);
        }

        private readonly uint _minValue = 0;
        private readonly uint _maxValue = 0;
        private readonly uint _defaultValue = 0;

        public Stat(uint minValue, uint maxValue, uint defaultValue, [NotNull] string name, [NotNull] string displayName, uint value)
        {
            Name = name;
            DisplayName = displayName;
            _minValue = minValue;
            _maxValue = maxValue;
            _defaultValue = Clamp(defaultValue);
            Value = value;

        }

        public void Reset()
        {
            Value = _defaultValue;
        }

        public uint Add(uint x) => (Value += x);

        public uint Clamp(uint x) => x < _minValue ? _minValue : x > _maxValue ? _maxValue : x;
    }
}

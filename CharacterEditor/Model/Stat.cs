using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using CharacterEditor.ViewModel;
using JetBrains.Annotations;

namespace CharacterEditor.Model
{
    public class Stat : IResettable, ICounter
    {
        public string Name { get; }
        public string DisplayName { get; }

        private uint _value;
        public uint Value
        {
            get => _value;
            set => _value = Clamp(value);
        }


        private readonly uint _minValue;
        private readonly uint _maxValue;
        private readonly uint _defaultValue;

        private Stat(uint minValue, uint maxValue, uint defaultValue, [NotNull] string name, [NotNull] string displayName, uint value)
        {
            Name = name;
            DisplayName = displayName;
            _minValue = minValue;
            _maxValue = maxValue;
            _defaultValue = Clamp(defaultValue);
            Value = value;
        }

        private static Stat Attribute(string attrName, string displayName, uint value) => new Stat(0, 20, 0, attrName, displayName, value);

        public static Stat Strength(uint value) => Attribute("Strength", "STR", value);
        public static Stat Dexterity(uint value) => Attribute("Dexterity", "DEX", value);
        public static Stat Constitution(uint value) => Attribute("Constitution", "CON", value);
        public static Stat Intelligence(uint value) => Attribute("Intelligence", "INT", value);
        public static Stat Wisdom(uint value) => Attribute("Wisdom", "WIS", value);
        public static Stat Charisma(uint value) => Attribute("Charisma", "CHA", value);
        public static Stat Level(uint value) => new Stat(1, 100, 1, "Level", "LVL", value);

        public Stat([NotNull] Stat stat) => stat.Clone();

        private Stat Clone() => new Stat(_minValue, _maxValue, _defaultValue, Name, DisplayName, Value);

        public IResettable Reset()
        {
            Value = _defaultValue;
            return this;
        }


        public ICounter Increment(uint x)
        {
            Value += x;
            return this;
        }

        public ICounter Decrement(uint x)
        {
            Value -= Math.Min(x, Value);
            return this;
        }

        public uint Clamp(uint x) => x < _minValue ? _minValue : x > _maxValue ? _maxValue : x;

        private class Validation : ValidationRule
        {
            private uint Min { get; set; }
            private uint Max { get; set; }

            public override ValidationResult Validate(object value, CultureInfo _ = null)
            {
                (Exception, uint?) TryParse(object x)
                {
                    var s = x as string;
                    if (string.IsNullOrEmpty(s))
                    {
                        return (new ArgumentException("Value must be a string"), null);
                    }

                    try
                    {
                        return (null, uint.Parse(s));
                    }

                    catch (Exception e)
                    {
                        return (new ArgumentException($"Illegal characters or {e.Message}"), null);
                    }

                }

                var (err, res) = TryParse(value);
                if (err != null)
                {
                    return new ValidationResult(false, err.Message);
                }

                return res < Min || res > Max
                    ? new ValidationResult(false, $"Value must be between {Min} and {Max}")
                    : ValidationResult.ValidResult;
            }

            public Validation(uint min, uint max)
            {
                Max = max;
                Min = min;
            }
        }

        public ValidationRule Validate() => new Validation(_minValue, _maxValue);
    }
}

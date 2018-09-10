using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using CharacterEditor.ViewModel;
using JetBrains.Annotations;

namespace CharacterEditor.Model
{
    public class Stat : ValidationRule, IResettable, IAddable, ISubtractable
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

        public Stat(uint minValue, uint maxValue, uint defaultValue, [NotNull] string name, [NotNull] string displayName, uint value)
        {
            Name = name;
            DisplayName = displayName;
            _minValue = minValue;
            _maxValue = maxValue;
            _defaultValue = Clamp(defaultValue);
            Value = value;

        }

        public IResettable Reset()
        {
            Value = _defaultValue;
            return this;
        }

        public IAddable Add(uint x)
        {
            Value += x;
            return this;
        }

        public ISubtractable Subtract(uint x)
        {
            Value -= x;
            return this;
        }

        public uint Clamp(uint x) => x < _minValue ? _minValue : x > _maxValue ? _maxValue : x;

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

            return res < _minValue || res > _maxValue
                ? new ValidationResult(false, $"Value must be between {_minValue} and {_maxValue}")
                : ValidationResult.ValidResult;
        }

        public static Func<object, CultureInfo, ValidationResult> ValidateStat(Stat x) => x.Validate;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CharacterEditor.Model
{
    public class Character : IResettable
    {
        [NotNull] public string Name { get; set; }
        [NotNull] public Stat Strength { get; set; }
        [NotNull] public Stat Dexterity { get; set; }
        [NotNull] public Stat Constitution { get; set; }
        [NotNull] public Stat Intelligence { get; set; }
        [NotNull] public Stat Wisdom { get; set; }
        [NotNull] public Stat Charisma { get; set; }

        public void Reset()
        {
            Strength.Reset();
        }

        public Character(string name, uint strength = 0, uint dexterity = 0, uint constitution = 0, uint intelligence = 0, uint wisdom = 0, uint charisma = 0)
        {
            Name = name;
            Strength = new Stat("Strength", "STR", strength, 0);
            Dexterity = new Stat("Dexterity", "DEX", dexterity, 0);
            Constitution = new Stat("Constitution", "CON", constitution, 0);
            Intelligence = new Stat("Intelligence", "INT", intelligence, 0);
            Wisdom = new Stat("Wisdom", "WIS", wisdom, 0);
            Charisma = new Stat("Charisma", "CHA", charisma, 0);
        }

        public override bool Equals(object obj) => obj is Character other && this.Equals(other);

        protected bool Equals(Character other)
        {
            return string.Equals(Name, other.Name) && Strength.Equals(other.Strength) && Dexterity.Equals(other.Dexterity) && Constitution.Equals(other.Constitution) && Intelligence.Equals(other.Intelligence) && Wisdom.Equals(other.Wisdom) && Charisma.Equals(other.Charisma);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Strength.GetHashCode();
                hashCode = (hashCode * 397) ^ Dexterity.GetHashCode();
                hashCode = (hashCode * 397) ^ Constitution.GetHashCode();
                hashCode = (hashCode * 397) ^ Intelligence.GetHashCode();
                hashCode = (hashCode * 397) ^ Wisdom.GetHashCode();
                hashCode = (hashCode * 397) ^ Charisma.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==([NotNull] Character a, [NotNull] Character b) => a.Equals(b);
        public static bool operator !=([NotNull] Character a, [NotNull] Character b) => !(a == b);

    }
}
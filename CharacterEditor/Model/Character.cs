using System;
using System.Windows.Forms;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CharacterEditor.Model
{
    public class Character : IResettable, ITimeStamped
    {
        public DateTimeOffset SaveTime { get; private set; }
        public string Notes { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Alignment Alignment { get; set; }

        [NotNull] public string Name { get; set; }
        [NotNull] public Stat Strength { get; set; }
        [NotNull] public Stat Dexterity { get; set; }
        [NotNull] public Stat Constitution { get; set; }
        [NotNull] public Stat Intelligence { get; set; }
        [NotNull] public Stat Wisdom { get; set; }
        [NotNull] public Stat Charisma { get; set; }
        [NotNull] public Stat Level { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Race Race { get; set; }

        public IResettable Reset()
        {
            Name = "";
            Strength.Reset();
            Dexterity.Reset();
            Constitution.Reset();
            Intelligence.Reset();
            Wisdom.Reset();
            Charisma.Reset();
            Level.Reset();
            Race = Race.Unset;
            return this;
        }

        public static Character Default => new Character("", Race.Unset);

        public Character([NotNull] string name, Race race, uint strength = 0, uint dexterity = 0, uint constitution = 0, uint intelligence = 0, uint wisdom = 0, uint charisma = 0, uint level = 1)
        {
            Name = name;
            Race = race;
            Strength = Stat.Strength(strength);
            Dexterity = Stat.Dexterity(dexterity);
            Constitution = Stat.Constitution(constitution);
            Intelligence = Stat.Intelligence(intelligence);
            Wisdom = Stat.Wisdom(wisdom);
            Charisma = Stat.Charisma(charisma);
            Level = Stat.Level(level);
        }

        public DateTimeOffset Read() => SaveTime;

        public DateTimeOffset Set(DateTimeOffset time) => SaveTime = time;
    }
}
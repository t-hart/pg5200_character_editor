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
        [NotNull] public Stat Level { get; set; }
        [NotNull] public Race Race { get; set; }

        public void Reset()
        {
            Name = "";
            Strength.Reset();
            Dexterity.Reset();
            Constitution.Reset();
            Intelligence.Reset();
            Wisdom.Reset();
            Charisma.Reset();
            Level.Reset();
            Race = Race.Human;
        }

        public Character([NotNull] string name, [NotNull] Race race, uint strength = 0, uint dexterity = 0, uint constitution = 0, uint intelligence = 0, uint wisdom = 0, uint charisma = 0, uint level = 1)
        {
            Stat Attribute(string attrName, string displayName, uint value) => new Stat(0, 20, 0, attrName, displayName, value);

            Name = name;
            Race = race;
            Strength = Attribute("Strength", "STR", strength);
            Dexterity = Attribute("Dexterity", "DEX", dexterity);
            Constitution = Attribute("Constitution", "CON", constitution);
            Intelligence = Attribute("Intelligence", "INT", intelligence);
            Wisdom = Attribute("Wisdom", "WIS", wisdom);
            Charisma = Attribute("Charisma", "CHA", charisma);
            Level = new Stat(1, 100, 1, "Level", "LVL", level);
        }
    }
}
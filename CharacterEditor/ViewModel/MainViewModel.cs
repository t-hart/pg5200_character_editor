using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using CharacterEditor.Model;
using GalaSoft.MvvmLight.CommandWpf;
using JetBrains.Annotations;

namespace CharacterEditor.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private Character _character = Character.Default;
        public Character Character
        {
            get => _character;
            set
            {
                if (value == Character) { return; }
                _character = value;
                RaisePropertyChanged();
            }
        }

        [NotNull] public List<Race> Races { get; }

        public int RaceIndex
        {
            get => Races.FindIndex(x => x == Race);
            set => Race = Races[value];
        }

        public Race Race
        {
            get => Character.Race;
            set
            {
                if (value == Race) { return; }
                Character.Race = value;
                RaisePropertyChanged();
            }

        }

        public string Name
        {
            get => Character.Name;
            set
            {
                if (value == Name) { return; }
                Character.Name = value;
                RaisePropertyChanged();
            }
        }

        [NotNull] public StatRowViewModel Strength { get; }
        [NotNull] public StatRowViewModel Dexterity { get; }
        [NotNull] public StatRowViewModel Constitution { get; }
        [NotNull] public StatRowViewModel Intelligence { get; }
        [NotNull] public StatRowViewModel Wisdom { get; }
        [NotNull] public StatRowViewModel Charisma { get; }

        public uint Level
        {
            get => Character.Level.Value;
            set
            {
                var previousValue = Level;
                Character.Level.Value = value;
                if (previousValue != Level)
                {
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand ResetCommand { get; private set; }
        public ICommand IncrementCommand { get; private set; }
        public ICommand DecrementCommand { get; private set; }

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string WelcomeTitle
        {
            get => _welcomeTitle;
            set => Set(ref _welcomeTitle, value);
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
            Strength = new StatRowViewModel(Character.Strength);
            Dexterity = new StatRowViewModel(Character.Dexterity);
            Constitution = new StatRowViewModel(Character.Constitution);
            Intelligence = new StatRowViewModel(Character.Intelligence);
            Wisdom = new StatRowViewModel(Character.Wisdom);
            Charisma = new StatRowViewModel(Character.Charisma);

            Races = new List<Race> {Race.Unset}.Concat(Enum.GetNames(typeof(Race)).Where(x => x != Enum.GetName(typeof(Race), Race.Unset))
                .OrderBy(x => x).Select(x => (Race) Enum.Parse(typeof(Race), x))).ToList();
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
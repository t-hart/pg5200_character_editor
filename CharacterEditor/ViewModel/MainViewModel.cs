using System;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using CharacterEditor.Model;
using GalaSoft.MvvmLight.CommandWpf;

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

        private Character _character = new Character("Thorin", Race.Human, strength: 16, level:100);
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

        public string[] Races { get; } = Enum.GetNames(typeof(Race)).OrderBy(x => x).ToArray();

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

        public uint Strength
        {
            get => Character.Strength.Value;
            set
            {
                var previousValue = Strength;
                Character.Strength.Value = value;
                if (previousValue != Strength)
                {
                    RaisePropertyChanged();
                }
            }
        }

        public uint Dexterity
        {
            get => Character.Dexterity.Value;
            set
            {
                var previousValue = Dexterity;
                Character.Dexterity.Value = value;
                if (previousValue != Dexterity)
                {
                    RaisePropertyChanged();
                }
            }
        }

        public uint Constitution
        {
            get => Character.Constitution.Value;
            set
            {
                var previousValue = Constitution;
                Character.Constitution.Value = value;
                if (previousValue != Constitution)
                {
                    RaisePropertyChanged();
                }
            }
        }

        public uint Intelligence
        {
            get => Character.Intelligence.Value;
            set
            {
                var previousValue = Intelligence;
                Character.Intelligence.Value = value;
                if (previousValue != Intelligence)
                {
                    RaisePropertyChanged();
                }
            }
        }

        public uint Wisdom
        {
            get => Character.Wisdom.Value;
            set
            {
                var previousValue = Wisdom;
                Character.Wisdom.Value = value;
                if (previousValue != Wisdom)
                {
                    RaisePropertyChanged();
                }
            }
        }

        public uint Charisma
        {
            get => Character.Charisma.Value;
            set
            {
                var previousValue = Charisma;
                Character.Charisma.Value = value;
                if (previousValue != Charisma)
                {
                    RaisePropertyChanged();
                }
            }
        }

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

            ResetCommand = new RelayCommand(() => Strength = 0);
            // IncrementCommand = new RelayCommand<IAddable>(x => { x.Add(1); RaisePropertyChanged(); });
            IncrementCommand = new RelayCommand(() => Strength += 1);
            DecrementCommand = new RelayCommand(() => Strength -= 1);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
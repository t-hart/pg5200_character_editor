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

        public Character Character { get; set; } = new Character { Name = "Thorin" };

        private int _test;
        public int Test
        {
            get => _test;
            //set { _test = value; RaisePropertyChanged(); }
            set { _test = value; }
        }

        public Stat Strength
        {
            get => Character.Strength;
            set
            {
                if (value.Value == Strength.Value) return;
                Strength.Value = value.Value;
                RaisePropertyChanged();
            }
        }

        public ICommand ResetCommand { get; private set; }
        public ICommand IncrementCommand { get; private set; }

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
    
            ResetCommand = new RelayCommand<IResettable>((x) => { x.Reset(); RaisePropertyChanged(); });
            IncrementCommand = new RelayCommand(() => { Strength.Add(1); RaisePropertyChanged(); });
            // IncrementCommand = new RelayCommand(() => { Test += 1; });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
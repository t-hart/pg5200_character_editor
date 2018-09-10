using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CharacterEditor.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JetBrains.Annotations;

namespace CharacterEditor.ViewModel
{
    class StatRowViewModel : ViewModelBase
    {
        [NotNull] private Stat _stat;

        [NotNull] public Stat Stat
        {
            get => _stat;
            set
            {
                if (value == Stat) { return; } 
                _stat = value;
                RaisePropertyChanged();
            }
        }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }
        public ICommand ResetCommand { get; }

        public StatRowViewModel([NotNull] Stat stat)
        {
            _stat = stat;
            ResetCommand = new RelayCommand<IResettable>(x => Set(ref x, x.Reset()));
            IncrementCommand = new RelayCommand<IAddable>(x => Set(ref x, x.Add(1)));
            DecrementCommand = new RelayCommand<ISubtractable>(x => Set(ref x, x.Subtract(1)));
        }
    }
}

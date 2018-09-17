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
    public class StatRowViewModel : ViewModelBase
    {
        [NotNull] public Stat Stat { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }
        public ICommand ResetCommand { get; }

        public StatRowViewModel([NotNull] Stat stat)
        {
            Stat = stat;

            ResetCommand = new RelayCommand<IResettable>(x => Update(x, x.Reset()));
            IncrementCommand = new RelayCommand<ICounter>(x => Update(x, x.Increment(1)));
            DecrementCommand = new RelayCommand<ICounter>(x => Update(x, x.Decrement(1)));

            void Update<T>(T field, T newVal)
            {
                Set(ref field, newVal);
                RaisePropertyChanged("");
            }
        }
    }
}
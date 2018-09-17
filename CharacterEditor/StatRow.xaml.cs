using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CharacterEditor.Model;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for StatRow.xaml
    /// </summary>
    public partial class StatRow : UserControl
    {


        public Stat Stat
        {
            get => (Stat)GetValue(StatProperty);
            set => SetValue(StatProperty, value);
        }

        public static readonly DependencyProperty StatProperty =
            DependencyProperty.Register(nameof(Stat), typeof(Stat), typeof(StatRow), new PropertyMetadata(null));

        public ICommand IncrementCommand
        {
            get => (ICommand)GetValue(IncrementCommandProperty);
            set => SetValue(IncrementCommandProperty, value);
        }
        public static readonly DependencyProperty IncrementCommandProperty =
            DependencyProperty.Register(nameof(IncrementCommand), typeof(ICommand), typeof(StatRow));

        public StatRow()
        {
            InitializeComponent();
        }
    }
}

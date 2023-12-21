using AssignmentWPF.ViewModels;
using System.Windows;

namespace AssignmentWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}
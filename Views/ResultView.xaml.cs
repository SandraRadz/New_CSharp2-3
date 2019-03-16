using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels.Authentication;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Views
{
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new ResultViewModel();
        }
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.ProgrammingInCSharp2019.Practice3.LoginControlMVVM.Properties;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels.Authentication
{
    class ResultViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _backCommand;

        public string Name => $"Your name:\n{StationManager.CurrentUser.Name}";
        public string LastName => $"Your surname:\n{StationManager.CurrentUser.LastName}";
        public string Email => $"Your email:\n{StationManager.CurrentUser.Email}";
        public string Birth => $"Your birthday:\n{StationManager.CurrentUser.Birth.ToShortDateString()}";
        public string SunSign => $"Your sun sign:\n{StationManager.CurrentUser.GetSunSign}";
        public string ChineseSign => $"Your chinese sign:\n{StationManager.CurrentUser.GetChineseSign}";
        public string IsBirthday => $"Today is {(StationManager.CurrentUser.GetIsBirthday ? "" : "not ")}your birthday";
        public string IsAdult => $"You are {(StationManager.CurrentUser.GetIsAdult ? "" : "not ")}adult";


        public RelayCommand<object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.Start);

                           }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

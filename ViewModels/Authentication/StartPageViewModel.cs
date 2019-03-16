using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels.Authentication
{
    internal class StartPageViewModel : INotifyPropertyChanged

    {
        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _birth;

        private RelayCommand<object> _goCommand;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Birth
        {
            get
            {
                return ("birth " + _birth);
            }
            set
            {
                _birth = Convert.ToDateTime(value);
                OnPropertyChanged();
            }
        }



        public RelayCommand<object> GoCommand
        {
            get
            {
                return _goCommand ?? (_goCommand = new RelayCommand<object>(
                           CreateUser, o => CanExecuteCommand()));
            }
        }

        private async void CreateUser(object o)
        {

           var done = await Task.Run(() =>
            {
                try
                {
                    StationManager.CurrentUser = new Person(_name, _lastName, _email, _birth);
                   
                }
                catch (EmailError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (FutureDayError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (PastDayError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (NameError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                MessageBox.Show("Successful input");
                return true;

            });
           if (done)
           {
               NavigationManager.Instance.Navigate(ViewType.Result);
           }
        }

     

        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_email) && !(_birth == default(DateTime));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

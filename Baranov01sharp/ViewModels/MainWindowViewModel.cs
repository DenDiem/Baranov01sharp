using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Baranov01sharp.Model;
using Baranov01sharp.Tools;

namespace Baranov01sharp.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private DateTime? _dateTimeProp;


        private ICommand _signInCommand;
        private int _age;

        public ICommand SignInCommand =>
            _signInCommand ?? (_signInCommand = new RelayCommand<object>(o => { SignIn(); }));

        public DateTime? DateTimeProp
        {
            get { return _dateTimeProp; }
            set
            {


                User.Instance.InitUser(value.Value.Day, value.Value.Month, value.Value.Year);
                AgeInit();
                _dateTimeProp = value;
                OnPropertyChanged();
            }
        }

        public String Greeting
        {
            get
            {
               
                if(User.Instance.CheckBirthDay())
                    return "З др кр4";
                return "";
            }
        }
        async void AgeInit()
        {
            await Task.Run(() => AgeProp = User.Instance.Age);
        }
      
        public int AgeProp
        {
            get
            {
                if (_age < 0 || _age > 135)
                {
                 
                    ErrorNotAvalibleAge();
                    return -1;
                }
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
       
       
        private async void SignIn()
        {

            await Task.Run(() => Thread.Sleep(1000));

            MessageBox.Show("User sign in succesfully  " + User.Instance.Age);
        }
        private async void ErrorNotAvalibleAge()
        {

            await Task.Run(() => Thread.Sleep(1000));

            MessageBox.Show("please enter right birthday ");
        }
        #region OnProperetyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

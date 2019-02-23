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

        private String _greating, _simpleSign, _chinaSign;

        private ICommand _currentTime;
        private String _age;

        public ICommand CurrentTimeCommand =>
            _currentTime ?? (_currentTime = new RelayCommand<object>(o => { CurrentTime(); }));

        public DateTime? DateTimeProp
        {
            get { return _dateTimeProp; }
            set
            {


                User.Instance.InitUser(value.Value.Day, value.Value.Month, value.Value.Year);
                InitFullStack();
                _dateTimeProp = value;
                OnPropertyChanged();
            }
        }

        public String Greeting
        {
            get { return _greating; }
            set
            {
                
                _greating = value;
                OnPropertyChanged();
            }

        }

        public String SimpleSign
        {
            get { return _simpleSign; }
            set
            {
               
                _simpleSign = value;
                OnPropertyChanged();
            }
        }
        public String ChinaSign
        {
            get { return _chinaSign; }
            set
            {
                _chinaSign = value;
                OnPropertyChanged();
            }
        }
        async void InitFullStack()
        {
             if (!User.Instance.Avalible())
                {
                    ErrorNotAvalibleAge();
                    return;
                }
            await Task.Run(() => AgeProp = User.Instance.Age.ToString());
            await Task.Run(() => ChinaSign = User.Instance.CalculateChinaSign());
            await Task.Run(() => SimpleSign = User.Instance.CalculateSimpleSign());
            await Task.Run(() => Greeting = User.Instance.CalculateSimpleGreatingn());
        }
      
        public String AgeProp
        {
            get
            {
               
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
       
       
        private async void CurrentTime()
        {
            //for example
            await Task.Run(() => Thread.Sleep(1000));

            MessageBox.Show(DateTime.Now.ToString());
        }
        private async void ErrorNotAvalibleAge()
        {
            //for example
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

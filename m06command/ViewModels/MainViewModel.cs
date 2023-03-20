using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace m06command.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private int _position = 0;

        public MainViewModel()
        {
            NextCommand = new Command(() =>
            {
                Position = Position + 1;
            },
            () => { return Position < 5; });
            PreviousCommand = new Command(() =>
            {
                Position = Position - 1;
            },
            () => { return Position > 0; }
            );
            SetCommand = new Command<string>((value) =>
            {
                int v = Int32.Parse(value);
                Position = v;
            });
        }

        public int Position
        {
            get { return _position; }
            set { 
                _position = value; 
                OnPropertyChanged();
                (PreviousCommand as Command).ChangeCanExecute();
                (NextCommand as Command).ChangeCanExecute();
            }
        }

        public ICommand AlertCommand =>
            new Command(() =>
            {
                App.Current.MainPage.DisplayAlert("Pozor", "Zpráva", "OK");
            });

        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }
        public ICommand SetCommand { get; private set; }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

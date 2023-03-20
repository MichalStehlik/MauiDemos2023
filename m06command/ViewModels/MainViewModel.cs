using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m06command.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private int _position = 0;

        public int Position
        {
            get { return _position; }
            set { 
                _position = value; 
                OnPropertyChanged();
            }
        }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m08collections.Models
{
    internal class Student : INotifyPropertyChanged
    {
        private string _firstname;
        private string _lastname;

        public string FirstName {
            get { return _firstname; } 
            set { _firstname = value; OnPropertyChanged(); } 
        }
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; OnPropertyChanged(); }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
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

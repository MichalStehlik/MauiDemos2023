using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m04binding.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string _firstname;
        private string _lastname;
        private int _age;
        public string Firstname 
        { 
            get { return _firstname; }
            set { _firstname = value; OnPropertyChanged(); } 
        }
        public string Lastname
        {
            get => _lastname; set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }
        public int Age
        {
            get => _age; set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) // název bindou se doplní automaticky
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

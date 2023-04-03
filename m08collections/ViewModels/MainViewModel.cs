using m08collections.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m08collections.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private List<Student> _students;


        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

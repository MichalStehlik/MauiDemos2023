using m08collections.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace m08collections.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Student _selected;
        private ObservableCollection<Student> _students;
        public ICommand CreateCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public MainViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student {FirstName = "Alois", LastName = "Aladin"},
                new Student {FirstName = "Beáta", LastName = "Blatná"}
            };
            CreateCommand = new Command(() =>
            {
                Students.Add(new Student { FirstName = "Ctirad", LastName = "Cudný" });
            });
            RemoveCommand = new Command<Student>((s) =>
            {
                Students.Remove(s);
                SelectedStudent = null;
            },
            (s) =>
            {
                return s is not null;
            });
        }

        public ObservableCollection<Student> Students { 
            get { return _students; }
            set { _students = value; OnPropertyChanged(); }
        }
        public Student SelectedStudent
        {
            get { return _selected; }
            set { 
                _selected = value; 
                OnPropertyChanged(); 
                (RemoveCommand as Command).ChangeCanExecute(); 
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

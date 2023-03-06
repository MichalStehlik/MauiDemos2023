using m04binding.Models;
using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace m04binding
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private Person _p;

        public MainPage()
        {
            _p = new Person
            {
                Firstname = "Alfons",
                Lastname = "Avatar",
                Age = 100
            };
            InitializeComponent();
            
            //var personalBinding = new Binding();
            //personalBinding.Source = _p;
            //personalBinding.Path = nameof(Person.Lastname);
            // lblOutput.SetBinding(Label.TextProperty, personalBinding);
            lblOutput.BindingContext = _p;
            lblOutput.SetBinding(Label.TextProperty, nameof(Person.Lastname));
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            _p.Lastname = "Bořislav";
        }

        private void ChangeBtn_Clicked(object sender, EventArgs e)
        {
            _p = new Person { Firstname = "Jakub", Lastname = "Jouda", Age = 12 };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) // název bindou se doplní automaticky
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
using m04binding.Models;
using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace m04binding
{
    public partial class MainPage : ContentPage
    {
        private Person _p;
        public Person P
        {
            get => _p;
            set { 
                _p = value;
                OnPropertyChanged(nameof(this.P));
                if (lblOutput != null) // přebindování ostatních vazeb po změně objektu
                {
                    lblOutput.BindingContext = P;
                    lblOutput.SetBinding(Label.TextProperty, nameof(Person.Lastname));
                }
            }
        }

        public MainPage()
        {
            P = new Person
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
            lblOutput.BindingContext = P;
            lblOutput.SetBinding(Label.TextProperty, nameof(Person.Lastname));
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            P.Lastname = "Bořislav";
        }

        private void ChangeBtn_Clicked(object sender, EventArgs e)
        {
            P = new Person { Firstname = "Jakub", Lastname = "Jouda", Age = 12 };
            OnPropertyChanged("P");
        }
    }
}
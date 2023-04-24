using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m10sensors.ViewModels
{
    internal class CompassViewModel: INotifyPropertyChanged
    {
        private string _value;
        public CompassViewModel()
        {
            OnPropertyChanged(nameof(Supported));
            SwitchCommand = new Command(() =>
            {
                if (!Monitoring)
                {
                    // Turn on compass
                    Compass.Default.ReadingChanged += Compass_ReadingChanged;
                    Compass.Default.Start(SensorSpeed.UI);
                }
                else
                {
                    // Turn off compass
                    Compass.Default.Stop();
                    Compass.Default.ReadingChanged -= Compass_ReadingChanged;
                }
                OnPropertyChanged(nameof(Monitoring));
                OnPropertyChanged(nameof(Status));
            },
            () => { return Supported; });
        }

        public bool Supported { get { return Compass.IsSupported; } }
        public bool Monitoring { get { return Compass.IsMonitoring; } }
        public string Value { 
            get { 
                return _value; 
            } 
            set { 
                _value = value; 
                OnPropertyChanged(); 
            } 
        }
        public string Status { get 
            {
                if (!Supported) return "Senzor není k dispozici";
                if (Monitoring) return "Vypnout";
                return "Zapnout";
            } }
        public Command SwitchCommand { get; private set; }
        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            // Update UI Label with compass state
            Value = $"Compass: {e.Reading}";
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

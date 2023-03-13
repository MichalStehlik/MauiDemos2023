using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m05mvvm.ViewModels
{
    internal class ColorsViewModel : INotifyPropertyChanged
    {
        private int _red = 100;
        private int _green = 20;
        private int _blue = 30;
        private int _luminance = 0;
        private Color _color;

        public ColorsViewModel()
        {
            Color = new Color(Red, Green, Blue);
        }

        public int Red 
        {
            get { return _red; } 
            set { 
                _red = value;
                Color = new Color(value, Green, Blue);
                OnPropertyChanged(); 
            }
        }
        public int Green
        {
            get { return _green; }
            set { 
                _green = value;
                Color = new Color(Red, value, Blue);
                OnPropertyChanged();
            }
        }
        public int Blue
        {
            get { return _blue; }
            set { 
                _blue = value; 
                Color = new Color(Red, Green, value);
                OnPropertyChanged();
            }
        }
        public Color Color
        {
            get { return _color; }
            set { 
                _color = value;
                Luminance = (int)(0.2126 * Red + 0.7152 * Green + 0.0722 * Blue);
                OnPropertyChanged(); 
                OnPropertyChanged(nameof(Brightness));
                OnPropertyChanged(nameof(ColorText));
            }
        }

        public string ColorText { get { return Color.ToArgbHex(); } }

        public int Brightness { get { return ((Red + Green + Blue) / 3); } }
        public int Luminance { 
            get { return _luminance; }
            set { 
                _luminance = value;
                OnPropertyChanged();
            } 
        }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) // název bindou se doplní automaticky
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

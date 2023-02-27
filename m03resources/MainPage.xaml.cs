using System.Diagnostics;

namespace m03resources
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Debug.WriteLine(this.Resources["DarkFont"]);
        }
    }
}
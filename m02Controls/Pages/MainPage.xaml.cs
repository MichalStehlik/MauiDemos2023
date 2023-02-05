namespace m02Controls.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CommandsButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//command");
        }

        private void TextButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//text");
        }

        private void SetButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//set");
        }

        private void IndicatorButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//indicator");
        }

        private void CollectionButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//collection");
        }

        private void PresentButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//present");
        }
    }
}
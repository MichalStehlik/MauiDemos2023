namespace m09platform
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
#if ANDROID
            mainShell.ContentTemplate = new DataTemplate(typeof(AndroidPage));
#elif WINDOWS
            mainShell.ContentTemplate = new DataTemplate(typeof(WindowPage));
#endif
        }
    }
}
namespace m02Controls.Pages;

public partial class TextPage : ContentPage
{
	public TextPage()
	{
		InitializeComponent();
	}

	private void textEntry_TextChanged(object sender, TextChangedEventArgs e)
	{
		textLabel.Text = e.NewTextValue;
	}

	private void textEntry_Completed(object sender, EventArgs e)
	{
		DisplayAlert("Text", (sender as Entry).Text, "Zpìt");
	}
}
namespace m02Controls.Pages;

public partial class SetPage : ContentPage
{
	public SetPage()
	{
		InitializeComponent();
		SetLabel.Text = SetSlider.Value.ToString();
	}

	private void setCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		DisplayAlert("Check", (sender as CheckBox).IsChecked.ToString(), "Zpìt");
	}

	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		SetLabel.Text = (sender as Slider).Value.ToString();
	}
}
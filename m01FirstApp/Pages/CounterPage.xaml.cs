namespace m01FirstApp.Pages;

public partial class CounterPage : ContentPage
{
	private int _counter;
	public CounterPage()
	{
		_counter = 0;
		InitializeComponent();
		CounterLabel.Text = _counter.ToString();
	}

    private void DecBtn_Clicked(object sender, EventArgs e)
    {
		_counter--;
        CounterLabel.Text = _counter.ToString();
    }

    private void IncBtn_Clicked(object sender, EventArgs e)
    {
		_counter++;
        CounterLabel.Text = _counter.ToString();
    }
}
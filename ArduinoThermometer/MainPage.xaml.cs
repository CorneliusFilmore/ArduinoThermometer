namespace ArduinoThermometer;

public partial class MainPage : ContentPage
{
	int count = 0;


	public MainPage()
	{
		InitializeComponent();
		CounterBtn.Text = String.Empty;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count+=2;

		for (int i = 0; i < count; i++)
		{
			CounterBtn.Text.Substring(0, i).ToUpper();
		}
		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


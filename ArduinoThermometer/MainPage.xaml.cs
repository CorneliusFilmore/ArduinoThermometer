using ArduinoThermometer.Bluetooth;

namespace ArduinoThermometer;

public partial class MainPage : ContentPage
{
    private readonly IBluetoothConnector _bluetoothConnector;

    public int count = 0;

    public MainPage()
	{
		InitializeComponent();
        
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count+=2;
	}
}


using ArduinoThermometer.Bluetooth;

namespace ArduinoThermometer;

public partial class App : Application
{
	private readonly IBluetoothConnector _bluetoothConnector;
    public App(IBluetoothConnector bluetoothConnector)
	{
		InitializeComponent();
        _bluetoothConnector = bluetoothConnector;
        MainPage = new AppShell(_bluetoothConnector);
		
	}
}

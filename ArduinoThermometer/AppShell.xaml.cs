using ArduinoThermometer.Bluetooth;

namespace ArduinoThermometer;

public partial class AppShell : Shell
{
	private readonly IBluetoothConnector _bluetoothConnector;
	public AppShell(IBluetoothConnector bluetoothConnector)
	{
		InitializeComponent();
       
    }
}

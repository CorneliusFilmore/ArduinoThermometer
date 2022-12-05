using ArduinoThermometer.Bluetooth;

namespace ArduinoThermometer;

public partial class AppShell : Shell
{
	private readonly IBluetoothConnector _bluetoothConnector;
	public AppShell(IBluetoothConnector bluetoothConnector)
	{
		InitializeComponent();
        _bluetoothConnector = bluetoothConnector;
        const string ArduinoBluetoothTransceiverName = "BTM1";

        //Gets a list of all connected Bluetooth devices
        var ConnectedDevices = _bluetoothConnector.GetConnectedDevices();

        //Connects to the Arduino
        var arduino = ConnectedDevices.FirstOrDefault(d => d == ArduinoBluetoothTransceiverName);
        _bluetoothConnector.Connect(arduino);
    }
}

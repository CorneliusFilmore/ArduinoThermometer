using ArduinoThermometer.Bluetooth;
using ArduinoThermometer.Platforms.Android;

namespace ArduinoThermometer;

public partial class MainPage : ContentPage
{
    private IBluetoothConnector _bluetoothConnector;

    public MainPage() 
	{
		InitializeComponent();
        /*_bluetoothConnector = new BluetoothConnector();
        const string ArduinoBluetoothTransceiverName = "BTM1";

        //Gets a list of all connected Bluetooth devices
        var ConnectedDevices = _bluetoothConnector.GetConnectedDevices();

        //Connects to the Arduino
        var arduino = ConnectedDevices.FirstOrDefault(d => d == ArduinoBluetoothTransceiverName);
        _bluetoothConnector.Connect(arduino);*/

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        

        TimeLabel.Text = DateTime.Now.ToString();
        SemanticScreenReader.Announce(TimeLabel.Text);

        TempLabel.Text = _bluetoothConnector.GetData(Commands.GetTemperature).ToString();
        SemanticScreenReader.Announce(TempLabel.Text);


        HumLabel.Text = _bluetoothConnector.GetData(Commands.GetHumidity).ToString();
        SemanticScreenReader.Announce(HumLabel.Text);

        TempProgress.Progress = (double) (_bluetoothConnector.GetData(Commands.GetTemperature) +40) / 180;
        HumProgress.Progress = (double) _bluetoothConnector.GetData(Commands.GetHumidity) / 200;

        SemanticScreenReader.Announce(TempProgress.Progress.ToString());
        SemanticScreenReader.Announce(HumProgress.Progress.ToString());



    }

    private double NormalizeTemp(int temperature)
    {
        var normalizedTemperature = 0;

        normalizedTemperature = (temperature + 40) / 90;

        return normalizedTemperature;
    }
}


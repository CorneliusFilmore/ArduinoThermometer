using Android.Bluetooth;
using ArduinoThermometer.Bluetooth;
using ArduinoThermometer.Platforms.Android;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Dependency(typeof(BluetoothConnector))]
namespace ArduinoThermometer.Platforms.Android
{
    public class BluetoothConnector : IBluetoothConnector
    {
        private BluetoothSocket _socket;


        public BluetoothConnector()
        {

        }

        public List<string> GetConnectedDevices()
        {
            _adapter = BluetoothAdapter.DefaultAdapter;
            if (_adapter == null)
                throw new Exception("No Bluetooth adapter found.");

            if (_adapter.IsEnabled)
            {
                if (_adapter.BondedDevices.Count > 0)
                {
                    return _adapter.BondedDevices.Select(d => d.Name).ToList();
                }
            }
            else
            {
                Console.Write("Bluetooth is not enabled on device");
            }
            return new List<string>();
        }

        
        public void Connect(string deviceName)
        {
            var device = _adapter.BondedDevices.FirstOrDefault(d => d.Name == deviceName);
            _socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString(SspUdid));

           _socket.Connect();
        }

        public int GetData(Commands com)
        {
            byte[] buffer = { 0 };
            if (com == Commands.GetTemperature)
            {
                buffer = new byte[] { 1 };

            }
            else if (com == Commands.GetHumidity)
            {
                buffer = new byte[] { 2 };
            }
            else if (com == Commands.GetLight)
            {
                buffer = new byte[] { 3 };
            }

            byte[] output = new byte[5];
            _socket.OutputStream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(2000);
            _socket.InputStream.Read(output, 0, output.Length);
            var val = ConvertStreamToInt(output);
            if (val > 10000)
            {
                _socket.InputStream.Read(output, 0, output.Length);
                val = ConvertStreamToInt(output);
            }

            return val;
        }

        private int ConvertStreamToInt(byte[] data)
        {
            string val = "";
            int i = 0;
            while (i < data.Length && data[i] != 13)
            {
                if (data[i] >= 48)
                {
                    data[i] -= 48;
                    Console.Write(data[i] + " ");
                }
                val = val + "" + data[i];
                i++;
            }
            Console.WriteLine("");
            return int.Parse(val);
        }

        /// <summary>
        /// The standard UDID for SSP
        /// </summary>
        private const string SspUdid = "00001101-0000-1000-8000-00805f9b34fb";
        private BluetoothAdapter _adapter;
    }
}

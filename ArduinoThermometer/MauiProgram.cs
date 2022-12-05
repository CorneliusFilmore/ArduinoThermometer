using Syncfusion.Maui.Core.Hosting;
using ArduinoThermometer.Bluetooth;
using ArduinoThermometer.Platforms.Android;

namespace ArduinoThermometer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<IBluetoothConnector, BluetoothConnector>();
        return builder.Build();
	}
}

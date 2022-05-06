using LedDisplay.Mqtt;

namespace LedDisplay.Ui
{
    public class AppSettings : IMqttSettings
    {
        public string ServerAddress => "10.20.10.16";

        public string UserName => "mqtt";

        public string Password => "IllBeInMyBunk2459";

        public string Topic => "leddisplay/1/data";
    }
}

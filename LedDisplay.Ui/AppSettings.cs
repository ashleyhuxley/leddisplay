using LedDisplay.Mqtt;

namespace LedDisplay.Ui
{
    public class AppSettings : IMqttSettings
    {
        public string ServerAddress => "";

        public string UserName => "";

        public string Password => "";

        public string Topic => "leddisplay/1/data";
    }
}

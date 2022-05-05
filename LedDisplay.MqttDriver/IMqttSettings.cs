namespace LedDisplay.Mqtt
{
    public interface IMqttSettings
    {
        string ServerAddress { get; }

        string UserName { get; }

        string Password { get; }

        string Topic { get; }
    }
}

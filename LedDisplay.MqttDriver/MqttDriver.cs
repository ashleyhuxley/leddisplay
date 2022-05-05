using LedDisplay.Graphics.Controller;
using MQTTnet;
using MQTTnet.Client.Options;

namespace LedDisplay.Mqtt
{
    public class MqttDriver : ILedDisplayDriver
    {
        private readonly IMqttSettings settings;

        public MqttDriver(IMqttSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.settings = settings;
        }

        public async Task SendDataAsync(byte[] data)
        {
            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(this.settings.ServerAddress)
                    .WithCredentials(this.settings.UserName, this.settings.Password)
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(this.settings.Topic)
                    .WithPayload(data)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
            }
        }
    }
}
using MQTTnet;
using MQTTnet.Client;
using ProjetoUbiqua.Mqtt.Interface;

namespace ProjetoUbiqua.Mqtt
{
    public static class ClienteMqtt 
    {
        private static IMqttClient client;
        private static MqttClientOptions options;
        private static bool conectadoAoBroker = false;

        static ClienteMqtt()
        { 
            var mqttFactory = new MqttFactory();
            client = mqttFactory.CreateMqttClient();

            options = new MqttClientOptionsBuilder()
                .WithClientId("UbiquaServer")
                .WithTcpServer("mosquitto", 1883)
                .WithCleanSession()
                .Build();

            client.ConnectedAsync += Client_ConnectedAsync;
            client.DisconnectedAsync += Client_DisconnectedAsync;
        }

        public static async void MandarMensagemAsync(string mensagem, string topico)
        {
            await ConectarAoBroker();

            var mqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topico)
                .WithPayload(mensagem)
                .Build();

            if(conectadoAoBroker)
                await client.PublishAsync(mqttMessage);

            await DesconectarDoBroker();
        }

        private static async Task ConectarAoBroker()
        {
            if (conectadoAoBroker)
                return;

            await client.ConnectAsync(options);
            conectadoAoBroker = true;
        }

        private static async Task DesconectarDoBroker()
        {
            if (!conectadoAoBroker)
                return;

            await client.DisconnectAsync();
            conectadoAoBroker = false;
        }

        private static async Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            Console.WriteLine("Desconectado ao Broker MQTT");
            return;
        }

        private static async Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            Console.WriteLine("Conectado ao Broker MQTT");
            return;
        }
    }
}

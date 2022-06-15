using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using ProjetoUbiqua.Mqtt.Interface;

namespace ProjetoUbiqua.Mqtt
{
    public class ClienteMqtt : IClienteMqtt
    {
        private IMqttClient client;
        private MqttClientOptions? options = default;
        private bool conectadoAoBroker = false;

        public ClienteMqtt(IConfiguration configuration)
        { 
            var mqttFactory = new MqttFactory();
            client = mqttFactory.CreateMqttClient();
            var mqttAddress = configuration.GetValue<string>("MosquittoAddress");
            var portaMqtt = configuration.GetValue<int>("MosquittoPort");

            options = new MqttClientOptionsBuilder()
                .WithClientId("UbiquaServer")
                .WithTcpServer(mqttAddress, portaMqtt)
                .WithCleanSession()
                .Build();

            client.ConnectedAsync += Client_ConnectedAsync;
            client.DisconnectedAsync += Client_DisconnectedAsync;
        }

        public async void MandarMensagemAsync(string mensagem, string topico)
        {
            await ConectarAoBroker();

            var mqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topico)
                .WithPayload(mensagem)
                .Build();

            if (conectadoAoBroker)
                await client.PublishAsync(mqttMessage);

            await DesconectarDoBroker();
        }

        private async Task ConectarAoBroker()
        {
            if (conectadoAoBroker)
                return;

            await client.ConnectAsync(options);
            conectadoAoBroker = true;
        }

        private async Task DesconectarDoBroker()
        {
            if (!conectadoAoBroker)
                return;

            await client.DisconnectAsync();
            conectadoAoBroker = false;
        }

        private static async Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            Console.WriteLine("Desconectado do Broker MQTT");
            return;
        }

        private static async Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            Console.WriteLine("Conectado ao Broker MQTT");
            return;
        }
    }
}

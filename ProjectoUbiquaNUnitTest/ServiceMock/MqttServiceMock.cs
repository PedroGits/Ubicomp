using ProjetoUbiqua.Mqtt.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoUbiquaNUnitTest.ServiceMock
{
    internal class MqttServiceMock : IClienteMqtt
    {
        public void MandarMensagemAsync(string mensagem, string topico)
        {
            
        }
    }
}

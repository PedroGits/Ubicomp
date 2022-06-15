namespace ProjetoUbiqua.Mqtt.Interface
{
    public interface IClienteMqtt
    {
        void MandarMensagemAsync(string mensagem, string topico);
    }
}

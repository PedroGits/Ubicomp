namespace ProjetoUbiqua.DTO
{
    public class RegistoDTO
    {
        public RegistoDTO(string nomeUtilizador, string email, string password)
        {
            NomeUtilizador = nomeUtilizador;
            Email = email;
            Password = password;
        }

        public string NomeUtilizador { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

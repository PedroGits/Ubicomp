namespace ProjetoUbiqua.JWT.Model
{
    public class RespostaTokenDTO
    {
        public string Token { get; set; }
        public DateTime ValidoUntil { get; set; }
    }
}

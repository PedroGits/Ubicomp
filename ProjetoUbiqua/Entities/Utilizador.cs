using System.ComponentModel.DataAnnotations;

namespace ProjetoUbiqua.Entities
{
    public class Utilizador
    {
        [Key]
        public int ID_Utilizador { get; set; }
        [Required]
        public string NomeUtilizador { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]        
        public string Password { get; set; }
        public bool Is_admin { get; set; }
        public bool Banido { get; set; }

        public List<Sala>? Salas { get; set; }
    }
}

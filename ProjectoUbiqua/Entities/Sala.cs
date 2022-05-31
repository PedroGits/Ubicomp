using System.ComponentModel.DataAnnotations;

namespace ProjetoUbiqua.Entities
{
    public class Sala
    {
        [Key]
        public int ID_Sala { get; set; }
        [Required]
        public string NomeSala { get; set; }
        [Required]
        public int Lotacao { get; set; }
        [Required]
        public float Area { get; set; }
        [Required]
        public bool EstadoLuzes { get; set; }

        public List<Utilizador>? Utilizadores { get; set; }   
    }
}

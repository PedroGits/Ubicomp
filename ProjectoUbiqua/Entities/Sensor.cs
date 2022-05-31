using System.ComponentModel.DataAnnotations;

namespace ProjetoUbiqua.Entities
{
    public class Sensor
    {
        [Key]
        public int ID_Sensor { get; set; }
        [Required]
        public string NSerie { get; set; }
        [Required]
        public string Tipo { get; set; }
        public string? Descricao { get; set; }
        public Sala Sala { get; set; }
    }
}

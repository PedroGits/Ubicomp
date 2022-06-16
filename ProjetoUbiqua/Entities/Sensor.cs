using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int SalaID_Sala { get; set; }

        [DefaultValue(false)]
        public bool? Ligado { get; set; }
    }
}

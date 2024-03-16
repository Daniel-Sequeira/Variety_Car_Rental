using System.ComponentModel.DataAnnotations;

namespace VarietyCarRental.Models.LeerData
{
    public class Accesos
    {
        [Key]
        [Required]
        public int IdAcceso {  get; set; }
        public string? NombreAcceso { get; set; }


        public Usuarios? Usuarios { get; set; }
    }
}

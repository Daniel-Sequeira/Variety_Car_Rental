using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarietyCarRental.Models.LeerData
{
    public class Accesos
    {
        [Key, ForeignKey("Usuarios")]
        public string? IdUsuario { get; set; }
        public int IdAcceso {  get; set; }
        public string? Rol { get; set; }
       


        public Usuarios? Usuarios { get; set; }
    }
}

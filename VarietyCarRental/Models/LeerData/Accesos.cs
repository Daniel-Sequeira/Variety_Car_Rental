namespace VarietyCarRental.Models.LeerData
{
    public class Accesos
    {

        public int IdAcceso {  get; set; }
        public string NombreAcceso { get; set; }
        public int IdPermiso { get; set; }

        public Usuarios Usuarios { get; set; }
    }
}

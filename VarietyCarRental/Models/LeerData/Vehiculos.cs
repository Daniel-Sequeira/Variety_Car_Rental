using Humanizer.DateTimeHumanizeStrategy;

namespace VarietyCarRental.Models.LeerData
{
    public class Vehiculos
    {
        public int IdVehiculo {  get; set; }  
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public int Capacidad { get; set; } 
        public decimal PrecioDia { get; set; }
        public bool Disponibilidad { get; set; }
    }
}

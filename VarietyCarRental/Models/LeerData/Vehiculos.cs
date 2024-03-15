using Humanizer.DateTimeHumanizeStrategy;

namespace VarietyCarRental.Models.LeerData
{
    public class Vehiculos
    {
        public int id_vehiculo {  get; set; }  
        public string modelo { get; set; }
        public string tipo { get; set; }
        public int capacidad { get; set; } 
        public decimal precio_dia { get; set; }
        public bool disponibilidad { get; set; }
    }
}

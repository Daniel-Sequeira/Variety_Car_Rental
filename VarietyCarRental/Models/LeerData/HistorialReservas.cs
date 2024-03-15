namespace VarietyCarRental.Models.LeerData
{
    public class HistorialReservas
    {
        public int IdHistorial {  get; set; }
        public int IdReserva { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
    }
}

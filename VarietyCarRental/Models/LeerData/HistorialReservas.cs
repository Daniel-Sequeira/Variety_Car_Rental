namespace VarietyCarRental.Models.LeerData
{
    public class HistorialReservas
    {
        public int id_historial {  get; set; }
        public int id_reserva { get; set; }
        public int id_vehiculo { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin {  get; set; }
    }
}

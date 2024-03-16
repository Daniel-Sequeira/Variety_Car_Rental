namespace VarietyCarRental.Models.LeerData
{
    public class Reservas
    {
        public int IdReserva {  get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }
        public int IdPoliza { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin {  get; set; }

        public decimal CostoTotal {  get; set; }


    }
}

namespace VarietyCarRental.Models.LeerData
{
    public class Mantenimiento
    {
        public int id_mantenimiento {  get; set; }
        public string mant_realizado { get; set; }
        public int id_poliza { get; set; }
        public decimal costo_mant {  get; set; }

    }
}

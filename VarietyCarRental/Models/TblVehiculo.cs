using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblVehiculo
{
    public int IdVehiculo { get; set; }

    public string? Modelo { get; set; }

    public string? Tipo { get; set; }

    public string? Capacidad { get; set; }

    public decimal? PrecioDia { get; set; }

    public string? Disponibilidad { get; set; }

    public virtual ICollection<TblReserva> TblReservas { get; set; } = new List<TblReserva>();
}

using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblHistorial
{
    public int IdHistorial { get; set; }

    public int? IdReserva { get; set; }

    public int? IdVehiculo { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }
}

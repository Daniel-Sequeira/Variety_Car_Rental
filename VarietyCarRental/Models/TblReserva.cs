using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblReserva
{
    public int IdReserva { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCliente { get; set; }

    public int? IdVehiculo { get; set; }

    public int? IdPoliza { get; set; }

    public DateOnly? FechaInicioReserva { get; set; }

    public DateOnly? FechaFinReserva { get; set; }

    public decimal? CostoTotal { get; set; }

    public virtual TblCliente? IdClienteNavigation { get; set; }

    public virtual TblPoliza? IdPolizaNavigation { get; set; }

    public virtual TblUsuario? IdUsuarioNavigation { get; set; }

    public virtual TblVehiculo? IdVehiculoNavigation { get; set; }
}

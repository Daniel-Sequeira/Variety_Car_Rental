using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblCliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? EmailCliente { get; set; }

    public virtual ICollection<TblReserva> TblReservas { get; set; } = new List<TblReserva>();
}

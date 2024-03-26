using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblPoliza
{
    public int IdPoliza { get; set; }

    public string? DescripcionPoliza { get; set; }

    public decimal? CostoPoliza { get; set; }

    public virtual ICollection<TblMantenimiento> TblMantenimientos { get; set; } = new List<TblMantenimiento>();

    public virtual ICollection<TblReserva> TblReservas { get; set; } = new List<TblReserva>();
}

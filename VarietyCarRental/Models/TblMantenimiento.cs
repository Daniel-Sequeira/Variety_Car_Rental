using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblMantenimiento
{
    public int IdMantenimiento { get; set; }

    public string? DescripcionMantenimiento { get; set; }

    public int? IdPoliza { get; set; }

    public decimal? CostoMantenimiento { get; set; }

    public virtual TblPoliza? IdPolizaNavigation { get; set; }
}

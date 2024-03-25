using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblRol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}

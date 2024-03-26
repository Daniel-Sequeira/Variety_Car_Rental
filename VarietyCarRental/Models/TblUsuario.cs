using System;
using System.Collections.Generic;

namespace VarietyCarRental.Models;

public partial class TblUsuario
{
    public int IdUsuarios { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public virtual TblRol? IdRolNavigation { get; set; }

    public virtual ICollection<TblReserva> TblReservas { get; set; } = new List<TblReserva>();
}

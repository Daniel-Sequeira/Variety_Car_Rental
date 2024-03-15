﻿namespace VarietyCarRental.Models.LeerData
{
    public class Usuarios
    {
        public int IdUsuario {  get; set; }
        public int IdAcceso { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public required string Contrasena {  get; set; }
        public string Email {  get; set; }

        public Accesos Accesos { get; set; }
    }
}
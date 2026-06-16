using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroClientes
{
    internal class Cliente
    {
        public Cliente()
        {
        }

        public Cliente(string apellidos, string nombres, string dni, string direccion, string estadoCivil)
        {
            Apellidos = apellidos;
            Nombres = nombres;
            Dni = dni;
            Direccion = direccion;
            EstadoCivil = estadoCivil;
        }

        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string EstadoCivil { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Examen01
{
    internal class TicketVenta
    {
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public string Formato { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }

        public string PrecioFormateado
        {
            get { return "S/ " + Precio.ToString("N2"); }
        }
    }
}

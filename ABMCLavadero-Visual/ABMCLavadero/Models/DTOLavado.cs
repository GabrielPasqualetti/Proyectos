using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMCLavadero.Models
{
    public class DTOLavado
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public bool Taxi { get; set; }
        public bool Habitual { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
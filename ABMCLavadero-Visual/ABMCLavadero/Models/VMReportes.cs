using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMCLavadero.Models
{
    public class VMReportes
    {
        public List<DTOCantidadPorTipo> CantidadPorTipo { get; set; }
        public DTOLavado UltimoLavado { get; set; }
    }
}
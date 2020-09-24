using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMCLavadero.Models
{
    public class VMLavado
    {
        public Lavado LavadoModel { get; set; }
        public List<Tipo> TiposLavado { get; set; }
    }
}
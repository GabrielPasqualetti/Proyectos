using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecuperatorioProg06_07.Models
{
    public class VMAgencia
    {
        public Mediciones medicionModel { get; set; }
        public List<Estaciones> estacionesModel { get; set; }
    }
}
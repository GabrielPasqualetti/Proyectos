using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecuperatorioProg06_07.Models
{
    public class Mediciones
    {
        public int Id { get; set; }
        public int dia { get; set; }
        public int idEstacion { get; set; }
        public float temperatura { get; set; }
        public float humedad { get; set; }

    }
}
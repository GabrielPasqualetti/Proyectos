using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecuperatorioProg06_07.Models
{
    public class DTOAgencia
    {
        public int id { get; set; }
        public int dia { get; set; }
        public string nombre { get; set; }
        public double temperatura { get; set; }
        public double humedad { get; set; }
    }
}
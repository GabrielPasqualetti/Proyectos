using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABMCLavadero.Models
{
    public class Lavado
    {
        public int Id { get; set; }
        [Required]
        public string Patente { get; set; }
        public bool Taxi { get; set; }
        public bool Habitual { get; set; }
        //public double Precio { get; set; }
        public int IdTipo { get; set; }
    }
}
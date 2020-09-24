
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProgIII.Models
{
    public class Materia
    {
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int nivel { get; set; }
    }
}
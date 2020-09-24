using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProgIII.Models
{
    public class Examen
    {
       public int IdExamen { get; set; }
        [Required]
        public string fecha { get; set; }
        [Required]
        public int Idmateria { get; set; }
        [Required]
        public int nota { get; set; }

        
    }
}
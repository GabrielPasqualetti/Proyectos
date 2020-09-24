using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgIII.Models
{
    public class DTOExamen
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public int nivel { get; set; }
        public int nota { get; set; }
    }
}
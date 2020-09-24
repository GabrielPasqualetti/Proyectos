using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineEstrella
{
    class Peliculas
    {

        private int idPelicula;
        private string nombre;
        private int duracion;
        private DateTime anoEstreno;
        private int idClasificacion;
        private int idVersion;
        private int idGeneroPelicula;


        public int pIdPelicula
        { get { return idPelicula; } set { idPelicula = value; } }

        public string pNombre
        { get { return nombre; } set { nombre = value; } }

        public int pDuracion
        { get { return duracion; } set { duracion = value; } }

        public DateTime pAnoEstreno
        { get { return anoEstreno; } set { anoEstreno = value; } }

        public int pIdClasificacion
        { get { return idClasificacion; } set { idClasificacion = value; } }

        public int pIdVersion
        { get { return idVersion; } set { idVersion = value; } }

        public int pIdGeneroPelicula
        { get { return idGeneroPelicula; } set { idGeneroPelicula = value; } }

        public Peliculas()
        {
            idPelicula = 0;
            nombre = "";
            duracion = 0;
            anoEstreno = DateTime.Today;
            idClasificacion = 0;
            idVersion = 0;
            idGeneroPelicula = 0;
        }

        public Peliculas(int id_pelicula, string nombre, int duracion, DateTime anoEstreno, int id_clasificacion, int id_version, int idgenero_pelicula)
        {
            this.idPelicula = id_pelicula;
            this.nombre = nombre;
            this.duracion = duracion;
            this.anoEstreno = anoEstreno;
            this.idClasificacion = id_clasificacion;
            this.idVersion = id_version;
            this.idGeneroPelicula = idgenero_pelicula;
        }

        public override string ToString()
        {
            return nombre +" - Duración= "+ duracion +" minutos - Estreno= "+ anoEstreno.ToShortDateString();
        }
    }
}

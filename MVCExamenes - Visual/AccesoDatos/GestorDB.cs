using FinalProgIII.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProgIII.AccesoDatos
{
    public class GestorDB
    {
       
        public void InsertarExamen(Examen examen)
        {
            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                var sql = "INSERT INTO Examenes VALUES (@Fecha, @IdMateria, @Nota)";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@Fecha", examen.fecha);
                cmd.Parameters.AddWithValue("@IdMateria", examen.Idmateria);
                cmd.Parameters.AddWithValue("@Nota", examen.nota);

                cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<DTOExamen> ListadoExamen()
        {

            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            var lista = new List<DTOExamen>();
            try
            {
                var sql = @"SELECT e.IdExamen, e.Fecha, m.Nombre, m.Nivel, e.Nota
                            FROM Examenes e
                            JOIN Materias m on m.IdMateria = e.IdMateria
                            ORDER BY m.Nivel ASC, e.Nota DESC";

                

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DTOExamen e = new DTOExamen();
                    e.id = (int)dr["IdExamen"];
                    e.fecha = (string)dr["Fecha"];
                    e.nombre = (string)dr["Nombre"];
                    e.nivel = (int)dr["Nivel"];
                    e.nota = (int)dr["Nota"];

                    lista.Add(e);
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }


        public List<Materia> ListaMaterias()
        {

            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            var lista = new List<Materia>();
            try
            {
                var sql = "SELECT * FROM Materias";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Materia mat = new Materia();

                    mat.Id = (int)dr["IdMateria"];
                    mat.nombre = (string)dr["Nombre"];
                    mat.nivel = (int)dr["Nivel"];

                    lista.Add(mat);
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        public List<DTOPromNota> reportePromedioNotas()
        {

            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            var lista = new List<DTOPromNota>();
            try
            {
                var sql = @"SELECT m.Nivel, AVG(e.nota) 'Promedio',count(*) 'CantidadAprobados'
                            FROM Examenes e
                            JOIN Materias m on m.IdMateria = e.IdMateria
                            WHERE e.Nota > 5
                            GROUP BY M.Nivel
                            ORDER BY M.Nivel";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DTOPromNota P = new DTOPromNota();
                    P.nivel = (int)dr["Nivel"];
                    P.Promedio = int.Parse(dr["Promedio"].ToString());
                    P.CantidadAprobados = (int)dr["CantidadAprobados"];

                    lista.Add(P);
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }
    }
}

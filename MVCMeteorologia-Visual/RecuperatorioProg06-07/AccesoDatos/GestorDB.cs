using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RecuperatorioProg06_07.Models;

namespace RecuperatorioProg06_07.AccesoDatos
{
    public class GestorDB
    {
        //insertar a la base de datos
        public void InsertarMedicion(Mediciones medir)
        {
            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                var sql = "INSERT INTO  Mediciones VALUES (@Dia, @IdEstaciones, @Temperatura, @Humedad)";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@Dia", medir.dia);
                cmd.Parameters.AddWithValue("@IdEstaciones", medir.idEstacion);
                cmd.Parameters.AddWithValue("@Temperatura", medir.temperatura);
                cmd.Parameters.AddWithValue("@Humedad", medir.humedad);


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

        //traer todo de la base de datos
        public List<DTOAgencia> ListadoMediciones()
        {

            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            var lista = new List<DTOAgencia>();
            try
            {
                var sql = @"SELECT Id, Dia, Nombre, Temperatura, Humedad
                            FROM Mediciones m
                            JOIN Estaciones e ON m.IdEstacion = e.IdEstacion";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DTOAgencia m = new DTOAgencia();
                    m.id = (int)dr["Id"];
                    m.dia = (int)dr["DIa"];
                    m.nombre = (string)dr["Nombre"];
                    m.temperatura = (double)dr["Temperatura"];
                    m.humedad = (double)dr["Humedad"];

                    lista.Add(m);
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


        //para traer el combo
        public List<Estaciones> ListadoEstaciones()
        {

            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            var lista = new List<Estaciones>();
            try
            {
                var sql = "SELECT * FROM Estaciones";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Estaciones estac = new Estaciones();

                    estac.Id = (int)dr["IdEstacion"];
                    estac.nombre = (string)dr["Nombre"];
                   
                    lista.Add(estac);
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

        //reporte
        public List<DTOPromTempYHum> PromTempYHums()
        {

            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            var lista = new List<DTOPromTempYHum>();
            try
            {
                var sql = @"SELECT e.Nombre, avg(m.Temperatura) as 'PromedioTemperatura', avg(m.Humedad) as 'PromedioHumedad'
	                        from Mediciones m
	                        join Estaciones e on e.IdEstacion = m.IdEstacion
                            group by e.Nombre";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DTOPromTempYHum l = new DTOPromTempYHum();
                    l.nombre = (string)dr["Nombre"];
                    l.PromedioTemperatura = (double)dr["PromedioTemperatura"];
                    l.PromedioTemperatura = (double)dr["PromedioHumedad"];

                    lista.Add(l);
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

        public List<DTOTempMaxima> TemperatuaMaxima()
        {

            string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaDB"].ToString();

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            var lista = new List<DTOTempMaxima>();
            try
            {
                var sql = @"SELECT e.Nombre, max(m.Temperatura) as 'MaximaTemperatura'
	                        FROM Mediciones m
	                        JOIN Estaciones e on e.IdEstacion = m.IdEstacion
                            GROUP BY e.Nombre";

                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DTOTempMaxima tm = new DTOTempMaxima();
                    tm.nombre = (string)dr["Nombre"];
                    tm.MaximaTemperatura = (double)dr["MaximaTemperatura"];

                    lista.Add(tm);
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
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ABMCLavadero.Models;
using System.Configuration;

namespace ABMCLavadero.AccesoDatos
{
    public class GestorBD
    {
        public void InsertarLavado(Lavado lavado)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            try
            {
                var sql = "INSERT INTO Lavados (patente, taxi, habitual, idTipo) VALUES (@patente, @taxi, @habitual, @idTipo)";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@patente", lavado.Patente);
                cmd.Parameters.AddWithValue("@taxi", lavado.Taxi);
                cmd.Parameters.AddWithValue("@habitual", lavado.Habitual);
                cmd.Parameters.AddWithValue("@idTipo", lavado.IdTipo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {

            }
            finally
            {
                conexion.Close();
            }
        }

        public List<DTOLavado> ListadoLavados()
        {
            var lista = new List<DTOLavado>();

            var sql = @"SELECT idLavado, patente, taxi, habitual, nombre, precio
                        FROM Lavados l
                        JOIN Tipos t ON l.idTipo = t.idTipo";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DTOLavado lavado = new DTOLavado();

                lavado.Patente = (string)dr["patente"];
                lavado.Id = (int)dr["idLavado"];
                lavado.Taxi = (bool)dr["taxi"];
                lavado.Habitual = (bool)dr["habitual"];
                lavado.Nombre = (string)dr["nombre"];
                lavado.Precio = (double)dr["precio"];

                lista.Add(lavado);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }

        public List<DTOCantidadPorTipo> CantidadLavadosPorTipo()
        {
            var lista = new List<DTOCantidadPorTipo>();

            var sql = @"SELECT nombre, COUNT(*) as cantidad
                        FROM Lavados l
                        JOIN Tipos t ON l.idTipo = t.idTipo
                        GROUP BY nombre";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DTOCantidadPorTipo lavado = new DTOCantidadPorTipo();

                lavado.Nombre = dr.GetString(0);
                lavado.Cantidad = dr.GetInt32(1);

                lista.Add(lavado);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }

        public DTOLavado UltimoTaxiHabitual()
        {
            var sql = @"SELECT TOP 1 idLavado, patente, taxi, habitual, nombre, precio
                            FROM Lavados l
                            JOIN Tipos t ON l.idTipo = t.idTipo
                            WHERE l.taxi = 1
                            AND l.habitual = 1
                            order by idLavado desc";

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);

            SqlDataReader dr = cmd.ExecuteReader();

            DTOLavado lavado = null;

            if (dr.Read())
            {
                lavado = new DTOLavado();
                lavado.Patente = (string)dr["patente"];
                lavado.Id = (int)dr["idLavado"];
                lavado.Taxi = (bool)dr["taxi"];
                lavado.Habitual = (bool)dr["habitual"];
                lavado.Nombre = (string)dr["nombre"];
                lavado.Precio = (double)dr["precio"];
            }

            dr.Close();
            conexion.Close();

            return lavado;
        }


        


        public Lavado BuscarLavado(int idLavado)
        {
            var sql = "SELECT * FROM Lavados WHERE idLavado = @id";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id", idLavado);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            Lavado lavado = new Lavado();

            lavado.Patente = (string)dr["patente"];
            lavado.Id = (int)dr["idLavado"];
            lavado.Taxi = (bool)dr["taxi"];
            lavado.Habitual = (bool)dr["habitual"];
            lavado.IdTipo = (int)dr["idTipo"];

            dr.Close();
            conexion.Close();

            return lavado;
        }

        public void EditarLavado(Lavado lavado)
        {
            //var sql = "INSERT INTO Lavados (patente, taxi, habitual, precio) VALUES (@patente, @taxi, @habitual, @precio)";

            var sql = "UPDATE Lavados SET patente = @patente, taxi = @taxi, habitual = @habitual, idTipo = @idTipo WHERE idLavado = @id";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@patente", lavado.Patente);
            cmd.Parameters.AddWithValue("@taxi", lavado.Taxi);
            cmd.Parameters.AddWithValue("@habitual", lavado.Habitual);
            cmd.Parameters.AddWithValue("@id", lavado.Id);
            cmd.Parameters.AddWithValue("@idTipo", lavado.IdTipo);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarLavado(Lavado lavado)
        {
            var sql = "DELETE FROM Lavados WHERE idLavado = @id";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@id", lavado.Id);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public List<Tipo> ListadoTipos()
        {
            var lista = new List<Tipo>();

            var sql = "SELECT * FROM Tipos";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Tipo tipo = new Tipo();

                tipo.Nombre = (string)dr["nombre"];
                tipo.Id = (int)dr["idTipo"];
                tipo.Precio = (double)dr["precio"];
                
                lista.Add(tipo);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cineEstrella
{
    public partial class ConsultasFijas : Form
    {
        AccesoDatos datos = new AccesoDatos(@"Provider=SQLNCLI11;Data Source=LAPTOP-D2H1GFR3\GABIPC;Integrated Security=SSPI;Initial Catalog=CINE_ESTRELLAS");
        public ConsultasFijas()
        {
            InitializeComponent();
        }

        private void btnConsultaF_Click(object sender, EventArgs e)
        {
            string query;
            if (rbtConsulta1.Checked)//Anshie-1
            {
                query = "select  D.ID_COMPROBANTE 'COMPROBANTE', sum(D.MONTO * D.CANTIDAD)'IMPORTE TOTAL'," +
                "avg(D.CANTIDAD * D.MONTO)'PROMEDIO' " +
                "from DETALLES_COMPROBANTES D " +
                "group by D.ID_COMPROBANTE " +
                "having avg(cantidad)> 3 and sum(D.MONTO* D.CANTIDAD)> 1000 " +
                "order by 2 desc";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta2.Checked)//-2
            {
                query = "SELECT C.ID_CLIENTE 'CODIGO CLIENTE', P.NOMBRE 'PELICULA' " +
                "FROM CLIENTES C JOIN RESERVAS R ON C.ID_CLIENTE = R.ID_CLIENTE " +
                "JOIN TICKETS T ON R.ID_TICKET = T.ID_TICKET " +
                "JOIN FUNCIONESXPELICULAS FP ON T.ID_FUNCIONXPELICULA = FP.ID_FUNCIONXPELICULA " +
                "JOIN PELICULAS P ON FP.ID_PELICULA = P.ID_PELICULA " +
                "WHERE C.ID_CLIENTE BETWEEN 1 AND 6";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta3.Checked)//3
            {
                query = "select p.nombre NombrePeli, avg(dc.cantidad) PromedioCant, sum(dc.cantidad) " +
                        "CantEntradas, sum(dc.MONTO) SumaMontos, sum(dc.cantidad*dc.monto) Importe, FECHA_COMPROBANTE Fecha " +
                        "from detalles_comprobantes dc " + 
                        "join comprobantes c on dc.id_comprobante = c.id_comprobante " +
                        "join tickets t on c.id_comprobante = t.id_comprobante " +
                        "join funcionesxpeliculas fp on t.id_funcionxpelicula = fp.id_funcionxpelicula " + 
                        "join peliculas p on fp.id_pelicula = p.id_pelicula " +
                        "group by p.nombre, FECHA_COMPROBANTE " +
                        "having avg(dc.cantidad) > (select avg(cantidad) from DETALLES_COMPROBANTES)";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta4.Checked)//Gabi-4
            {
                query = "SELECT C.NOMBRE, C.TELEFONO " +
                        "FROM CLIENTES C JOIN TIPOS_DOCUMENTOS T ON T.IDTIPO_DNI = C.IDTIPO_DOCUMENTO " +
                        "WHERE T.IDTIPO_DNI != 1";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta5.Checked)//5
            {
                query = "SELECT * " +
                        "FROM CLIENTES C JOIN TIPOS_DOCUMENTOS T ON T.IDTIPO_DNI = C.IDTIPO_DOCUMENTO " +
                        "WHERE T.DESCRIPCION = 'pasaporte'";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta6.Checked)//Maka//6
            {
                query = "select avg(dc.MONTO) as 'Promedio $' from DETALLES_COMPROBANTES dc, COMPROBANTES c " +
                        "where dc.ID_COMPROBANTE = c.ID_COMPROBANTE " +
                        "and dc.CANTIDAD >= 2 " +
                        "and month(c.FECHA_COMPROBANTE) = month(getdate()) - 1 " +
                        "and year(c.FECHA_COMPROBANTE) = year(getdate()) ";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta7.Checked)//7
            {
                query = "select cl.APELLIDO +', '+ cl.NOMBRE as 'Nombre Completo', co.FECHA_COMPROBANTE as 'Fecha', fp.DESCRIPCION as 'Forma de Pago' " +
                        "from clientes cl, FORMAS_PAGO fp, RESERVAS r, TICKETS ti, COMPROBANTES co " +
                        "where cl.ID_CLIENTE = r.ID_CLIENTE " +
                        "and r.ID_TICKET = ti.ID_TICKET " +
                        "and ti.ID_COMPROBANTE = co.ID_COMPROBANTE " +
                        "and fp.IDFORMA_PAGO = co.IDFORMA_PAGO " +
                        "and fp.IDFORMA_PAGO = 1 " +
                        "and cl.APELLIDO like 'N%' " +
                        "order by 1";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta8.Checked)//8
            {
                query = "select fp.DESCRIPCION as 'Forma de Pago', " +
                        "count(*)'Cant.Comprobantes', min(co.FECHA_COMPROBANTE)'Primer factura', " +
                        "max(co.FECHA_COMPROBANTE)'última factura', sum(dc.MONTO * dc.CANTIDAD) as 'Monto Total' " +
                        "from FORMAS_PAGO fp, COMPROBANTES co, DETALLES_COMPROBANTES dc " +
                        "where fp.IDFORMA_PAGO = co.IDFORMA_PAGO " +
                        "and co.ID_COMPROBANTE = dc.ID_COMPROBANTE " +
                        "and co.ID_COMPROBANTE between 5 and 19 " +
                        "group by fp.DESCRIPCION";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta9.Checked)//Amarillo-9
            {
                query = "SELECT P.ID_PELICULA 'CODIGO PELICULA', P.NOMBRE 'NOMBRE PELICULA', COUNT(*) 'CANTIDAD ENTRADAS',SUM(D.MONTO)'MONTO TOTAL ENTRAS' " +
                        "FROM TICKETS T JOIN FUNCIONESXPELICULAS FP ON T.ID_FUNCIONXPELICULA = FP.ID_FUNCIONXPELICULA " +
                        "JOIN PELICULAS P ON FP.ID_PELICULA = P.ID_PELICULA " +
                        "JOIN FUNCIONES F ON FP.ID_FUNCION = F.ID_FUNCION " +
                        "JOIN COMPROBANTES C ON T.ID_COMPROBANTE = C.ID_COMPROBANTE " +
                        "JOIN DETALLES_COMPROBANTES D ON C.ID_COMPROBANTE = D.ID_COMPROBANTE " +
                        "GROUP BY P.ID_PELICULA, P.NOMBRE " +
                        "HAVING SUM(D.MONTO) > (SELECT AVG(DC.CANTIDAD * DC.MONTO) FROM DETALLES_COMPROBANTES DC " +
                        "JOIN COMPROBANTES CO ON DC.ID_COMPROBANTE = CO.ID_COMPROBANTE " +
                        "JOIN TICKETS TI ON CO.ID_COMPROBANTE = TI.ID_COMPROBANTE " +
                        "JOIN FUNCIONESXPELICULAS FUP ON FUP.ID_FUNCIONXPELICULA = TI.ID_FUNCIONXPELICULA " +
                        "JOIN FUNCIONES FU ON FUP.ID_FUNCION = FU.ID_FUNCION " +
                        "WHERE FU.FECHA= GETDATE())";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta10.Checked)//10
            {
                query = "SELECT D.MONTO 'MONTO TOTAL', D.CANTIDAD 'CANTIDAD DE ENTRADAS', AVG(MONTO/CANTIDAD) 'PROMEDIO DE VENTAS' " +
                        "FROM DETALLES_COMPROBANTES D JOIN PROMOCIONES P ON D.ID_PROMOCION = P.ID_PROMOCION " +
                        "where D.ID_PROMOCION IN(1,4) " +
                        "GROUP BY D.MONTO, D.CANTIDAD " +
                        "HAVING AVG(MONTO * CANTIDAD) > 20 " +
                        "order by 2 desc";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta11.Checked)//11
            {
                query = "SELECT R.ID_RESERVA 'CODIGO DE RESERVA', R.ID_TICKET 'TICKET DE LA RESERVA', C.APELLIDO+' '+C.NOMBRE 'CLIENTE' " +
                        "FROM RESERVAS R JOIN CLIENTES C ON R.ID_CLIENTE = C.ID_CLIENTE " +
                        "ORDER BY 3";

                dataGridView1.DataSource = datos.consultar(query);
            }
            else if (rbtConsulta12.Checked)//12         
            {
                query = "SELECT C.ID_COMPROBANTE CODIGO, TV.DESCRIPCION ' TIPO DE VENTA', TE.DESCRIPCION 'TIPO DE ENTRADA', COUNT(*)'CANTIDAD DE VENTAS' " +
                        "FROM COMPROBANTES C, TICKETS T, TIPOS_VENTAS TV, TIPOS_ENTRADAS TE " +
                        "WHERE C.IDTIPO_VENTA = TV.IDTIPO_VENTA " +
                        "AND C.ID_COMPROBANTE = T.ID_COMPROBANTE " +
                        "AND T.IDTIPO_ENTRADA = TE.IDTIPO_ENTRADA " +
                        "AND(TV.DESCRIPCION = 'INTERNET' OR TE.DESCRIPCION = 'ADULTO') " +
                        "GROUP BY C.ID_COMPROBANTE,TV.DESCRIPCION,TE.DESCRIPCION " +
                        "HAVING COUNT(*) > 1 " +
                        "ORDER BY 3, 2 DESC";

                dataGridView1.DataSource = datos.consultar(query);
            }
        }

        private void RbtConsulta8_CheckedChanged(object sender, EventArgs e)
        {

        }

     
    }
}

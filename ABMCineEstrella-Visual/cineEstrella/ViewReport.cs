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
    public partial class ViewReport : Form
    {
        AccesoDatos dato = new AccesoDatos(@"Provider=SQLNCLI11;Data Source=LAPTOP-D2H1GFR3\GABIPC;Integrated Security=SSPI;Initial Catalog=CINE_ESTRELLAS");
        public ViewReport()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ReportePeliculas rp = new ReportePeliculas();
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }

        private void btnImpriFiltro_Click(object sender, EventArgs e)
        {
            ReportePeliculas rpo = new ReportePeliculas();

            string query = Consulta(cboClasi.SelectedIndex, cboVersion.SelectedIndex, cboGenero.SelectedIndex);


            rpo.SetDataSource(dato.consultar(query));
            crystalReportViewer1.ReportSource = rpo;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
            cboClasi.SelectedIndex = -1;
            cboGenero.SelectedIndex = -1;
            cboVersion.SelectedIndex = -1;

           
            


        }

        public void cargarCombos(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = dato.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            this.cargarCombos(cboClasi, "clasificaciones");
            this.cargarCombos(cboGenero, "generos_peliculas");
            this.cargarCombos(cboVersion, "versiones");
            gboFiltroID.Enabled = false;
            gboFiltrotxt.Enabled = false;
        }

        public string Consulta(int x, int y, int z)
        {
            string qfinal = "";
            int a = x;
            int b = y;
            int c = z;
            
            if (a != -1)
            {
                if (b == -1 && c == -1)
                {
                    qfinal = "Select * from peliculas where id_clasificacion =" + (a + 1);
                }
                else if (b != -1 && c == -1)
                {
                    qfinal = "Select* from peliculas where id_clasificacion = " + (a + 1) + "and id_version=" + (b + 1);
                }
                else if (b == -1 && c != -1)
                {
                    qfinal = "Select* from peliculas where id_clasificacion = " + (a + 1) + "and idgenero_pelicula=" + (c + 1);
                }
                else if ( b != -1 && c != -1)
                {
                    qfinal = "Select * from peliculas where id_clasificacion = " + (a + 1) + "and id_version = "+ (b+1) +
                        "and idgenero_pelicula = " + (c + 1);
                        //"exec ListaPeliculas @Clafi= " + (a + 1) + ", @Verci= " + (b + 1) + ",@Genero= " + (c + 1);
                }
            }
            if (b != -1)
            {
                if (a == -1 && c == -1)
                {
                    qfinal = "Select * from PELICULAS where id_version =" + (b + 1);
                }
                else if (a == -1 && c != -1)
                {
                    qfinal = "Select* from peliculas where id_version = " + (b + 1) + "and idgenero_pelicula=" + (c + 1);
                }
            }
            if (c != -1)
            {
                if (a == -1 && b == -1)
                {
                    qfinal = "Select * from peliculas where idgenero_pelicula =" + (c + 1);
                }
            }
            if (a == -1 && b == -1 && c == -1)
            {
                qfinal = "Select * from Peliculas ";

            }
            return qfinal;
        }

        private void rbtHabilitarID_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHabilitarID.Checked == true)
                gboFiltroID.Enabled = true;
            else
                gboFiltroID.Enabled = false;

            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDuracion.Checked == true)
                txtDurHasta.Enabled = true;
            else
            {
                txtDurHasta.Enabled = false;
                txtDurHasta.Clear();
            }
        }

        

        private void rbtHabilitarTxt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHabilitarTxt.Checked == true)
            {
                gboFiltrotxt.Enabled = true;
                txtMesHasta.Enabled = false;
                txtDurHasta.Enabled = false;
            }

            else
            {
                gboFiltrotxt.Enabled = false;
                ckbMes.Checked = false;
                ckbDuracion.Checked = false;
                txtPeliculas.Clear();
                txtMesDesde.Clear();
                txtMesHasta.Clear();
                txtDurDesde.Clear();
                txtDurHasta.Clear();
            }
            
        }

        private void ckbMes_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMes.Checked == true)
                txtMesHasta.Enabled = true;
            else
            {
                txtMesHasta.Enabled = false;
                txtMesHasta.Clear();
            }

        }

        private void btnImprimirFiltro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPeliculas.Text) && string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
            {
                MessageBox.Show("Debe rellenar algun campo");
            }
            else
            {
                if (!string.IsNullOrEmpty(txtPeliculas.Text) && string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "Select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text + "%'";


                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }
                if (!string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text)) 
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text + "%' and day(año_estreno) =" + txtMesDesde.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where day(año_estreno) =" + txtMesDesde.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                !string.IsNullOrEmpty(txtMesHasta.Text) && string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where day(año_estreno) " +
                        "between " + txtMesDesde.Text + " and " + txtMesHasta.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (!string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                !string.IsNullOrEmpty(txtMesHasta.Text) && string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text +
                       " day(año_estreno) between " + txtMesDesde.Text + " and " + txtMesHasta.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (!string.IsNullOrEmpty(txtPeliculas.Text) && string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text +
                        " duracion = " + txtDurDesde.Text;

                        rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();

                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where duracion = " + txtDurDesde.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                !string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where duracion between " + txtDurDesde.Text +
                        " and " + txtDurHasta.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (!string.IsNullOrEmpty(txtPeliculas.Text) && string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                !string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text +
                        " and duracion between " + txtDurDesde.Text + " and " + txtDurHasta.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (!string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text +
                        "and day(año_estreno)=" + txtMesDesde.Text + "and duracion =" + txtDurDesde.Text;

                        rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (!string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                !string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text +
                       " and day(año_estreno) between " + txtMesDesde.Text + " and " + txtMesHasta.Text +
                       "and duracion =" + txtDurDesde.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (!string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                !string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula like '%" + txtPeliculas.Text +
                        "and day(año_estreno)=" + txtMesDesde.Text + " and duracion between " + txtDurDesde.Text +
                        " and " + txtDurHasta.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (!string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                !string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                !string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where nombre_pelicula= '%" + txtPeliculas.Text + "%' and day(año_estreno) " +
                        "between " + txtMesDesde.Text + " and " + txtMesHasta.Text + " and duracion between " + txtDurDesde.Text +
                        " and " + txtDurHasta.Text; 

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where day(año_estreno)=" + txtMesDesde.Text + 
                        "and duracion =" + txtDurDesde.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                !string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where day(año_estreno) between " + txtMesDesde.Text + 
                        " and " + txtMesHasta.Text + "and duracion =" + txtDurDesde.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                !string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where day(año_estreno)=" + txtMesDesde.Text + " and duracion between " +
                        txtDurDesde.Text + " and " + txtDurHasta.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }

                if (string.IsNullOrEmpty(txtPeliculas.Text) && !string.IsNullOrEmpty(txtMesDesde.Text) &&
                !string.IsNullOrEmpty(txtMesHasta.Text) && !string.IsNullOrEmpty(txtDurDesde.Text) &&
                !string.IsNullOrEmpty(txtDurHasta.Text))
                {
                    ReportePeliculas rpo = new ReportePeliculas();

                    string query = "select * from Peliculas where day(año_estreno) " +
                        "between " + txtMesDesde.Text + " and " + txtMesHasta.Text + " and duracion between " + txtDurDesde.Text +
                        " and " + txtDurHasta.Text;

                    rpo.SetDataSource(dato.consultar(query));
                    crystalReportViewer1.ReportSource = rpo;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                }
            }
            txtPeliculas.Clear();
            txtMesDesde.Clear();
            txtMesHasta.Clear();
            txtDurDesde.Clear();
            txtDurHasta.Clear();
            ckbMes.Checked = false;
            ckbDuracion.Checked = false;

        }

        public string ConsutlaTxt(string p, int mD)/*, int mH, int aD, int aH)*/
        {
            string sql="";
            string a = p;
            int md = mD;
            //int mh = mH;
            //int ad = aD;
            //int ah = aH;

            if(!string.IsNullOrEmpty(txtPeliculas.Text))
            {
                sql = "Select * from Peliculas where nombre_pelicula like '%" + a + "%'";
            }
            if (!string.IsNullOrEmpty(txtMesDesde.Text))
                sql = "select * from Peliculas where año_estreño =" + md;

            return sql;
        }

        private void txtPeliculas_TextChanged(object sender, EventArgs e)
        {
            
        }
    }  
}



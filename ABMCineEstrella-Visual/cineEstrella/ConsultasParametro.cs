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
    public partial class ConsultasParametro : Form
    {
        AccesoDatos datos = new AccesoDatos(@"Provider=SQLNCLI11;Data Source=LAPTOP-D2H1GFR3\GABIPC;Integrated Security=SSPI;Initial Catalog=CINE_ESTRELLAS");

        public ConsultasParametro()
        {
            InitializeComponent();
        }

        private void Laboratorio_Load(object sender, EventArgs e)
        {
            cboTablas.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTablas.SelectedIndex = -1;
            cboTablas2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTablas2.SelectedIndex = -1;
            cboTablas3.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTablas3.SelectedIndex = -1;
            txtNombreTabla.Enabled = false;


        }

        private void cargarCombo(ComboBox combo, string nombreTabla)//metodo para cargar combo.. que sea accesible desde todos los metodos
        {
            DataTable tabla = new DataTable();
            tabla = datos.consultarTabla(nombreTabla);
            //nombre de tabla que se llama al cargar el combo..llamo al metodo consultar tabla que 
            //devuelve un datatable para cargar el combo
            combo.DataSource = tabla;//fuente de datos, de donde saca los datos que va a mostrar el combo
            combo.ValueMember = tabla.Columns[0].ColumnName;//campo descriptor
            combo.DisplayMember = tabla.Columns[1].ColumnName;// campo identificador
            combo.DropDownStyle = ComboBoxStyle.DropDownList; //hace la diferenciaaaaa. no permite editar el combo
            combo.SelectedIndex = -1;//todos aparecen posicionados en el vacio
        }


        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (habCargarPeli())
            {
                if (rbtPeliculas.Checked)
                {
                    string sql = "SELECT * FROM peliculas where ID_Version = " + cboTablas.SelectedValue + " and (" +
                    "Idgenero_pelicula= " + cboTablas2.SelectedValue + " or " +
                    "id_clasificacion= " + cboTablas3.SelectedValue + ")";
                    dataGridView1.DataSource = datos.consultar(sql);
                }
            }
            else if (habCargarSala())
            {
                if (rbtSalas.Checked)
                {
                    string sql = "SELECT * FROM salas where IDTIPO_SALA= " + cboTablas.SelectedValue;

                    dataGridView1.DataSource = datos.consultar(sql);
                }
            }
            else if(habCagaTabla())
            {
                if (rbtTablas.Checked)
                {
                    string sql = "Select * from " + txtNombreTabla.Text;

                    dataGridView1.DataSource = datos.consultar(sql);
                }
            }
            
        }

        private void rbtPeliculas_CheckedChanged(object sender, EventArgs e)
        {
            cboTablas.Enabled = true;
            cboTablas2.Enabled = true;
            cboTablas3.Enabled = true;
            cargarCombo(cboTablas, "Versiones");
            cargarCombo(cboTablas2, "Generos_peliculas");
            cargarCombo(cboTablas3, "Clasificaciones");
            txtNombreTabla.Enabled = false;


        }

        private void rbtSalas_CheckedChanged(object sender, EventArgs e)
        {
            cargarCombo(cboTablas, "Tipos_salas");
            cboTablas2.Enabled = false;
            cboTablas3.Enabled = false;
            txtNombreTabla.Enabled = false;

        }

        public bool habCargarPeli()
        {
            if (cboTablas.SelectedIndex == -1)//si no esta seleccionado uno o el otro
            {
                cboTablas.Focus();
                return false;
            }
            if (cboTablas2.SelectedIndex == -1)//si no esta seleccionado uno o el otro
            {
                cboTablas2.Focus();
                return false;
            }
            if (cboTablas3.SelectedIndex == -1)//si no esta seleccionado uno o el otro
            {
                cboTablas3.Focus();
                return false;
            }
            return true;
        }

        public bool habCargarSala()
        {
            if (cboTablas.SelectedIndex == -1)//si no esta seleccionado uno o el otro
            {
                cboTablas.Focus();
                return false;
            }
            return true;
        }

        public bool habCagaTabla()
        {
            if (string.IsNullOrEmpty(txtNombreTabla.Text))
            {
                txtNombreTabla.Focus();
                return false;
            }
            return true;
        }

        private void btnConsultaF_Click(object sender, EventArgs e)
        {
            
        }

        private void RbtTablas_CheckedChanged(object sender, EventArgs e)
        {
            cboTablas.Enabled = false;
            cboTablas2.Enabled = false;
            cboTablas3.Enabled = false;
            txtNombreTabla.Enabled = true;
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }
    }
}

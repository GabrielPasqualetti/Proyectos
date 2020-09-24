using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace cineEstrella
{
    public partial class Programacion : Form
    {
        AccesoDatos datos = new AccesoDatos(@"Provider=SQLNCLI11;Data Source=LAPTOP-D2H1GFR3\GABIPC;Integrated Security=SSPI;Initial Catalog=CINE_ESTRELLAS");
        List<Peliculas> lp = new List<Peliculas>();//instancio una lista que es una estructura dinamica en tiempos de ejecución
        bool nuevo;
        
        public Programacion()
        {
            InitializeComponent();
            nuevo = false;
        }

        private void Programacion_Load(object sender, EventArgs e)
        {
            cargarCombo(cboVersiones, "versiones");
            cargarCombo(cboClasificaciones, "clasificaciones");
            cargarCombo(cboGenerosPelis, "generos_peliculas");
            cargarLista("peliculas");
            habilitarComponentes(false);
            btnCancelar.Enabled = false;
        }


        private void habilitarComponentes(bool value)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].Enabled = value;
            }
            lstPelicula.Enabled = !value;
            btnNuevo.Enabled = !value;
            btnCancelar.Enabled = !value;
            btnSalir.Enabled = !value;
        }

        private void habilitarBotones(bool value)
        {
            habilitarComponentes(value);
            btnCancelar.Enabled = value;
            btnGrabar.Enabled = value;
            btnEditar.Enabled = !value;
            btnEliminar.Enabled = !value;
            btnNuevo.Enabled = !value;
        }

        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = datos.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void cargarLista(string nombreTabla)
        {
            
            lp.Clear();//limpio la lista
            datos.leerTabla(nombreTabla);//lo guarda en el dataReader(lector) asi
            while (datos.pLector.Read())//no se puede liberar hasta que no se lean todos los registros
            {
                Peliculas p = new Peliculas();//se mapea desde la base de datos a la clase del objeto instanciado
                if (!datos.pLector.IsDBNull(0))//se valida que no sea null
                    p.pIdPelicula = datos.pLector.GetInt32(0); 
                //tambien se puede poner por nombre de columna. ej: p.pDetalle = datos.pDr["apellido"].ToString();
                if (!datos.pLector.IsDBNull(1))
                    p.pNombre = datos.pLector.GetString(1);
                if (!datos.pLector.IsDBNull(2))
                    p.pDuracion = datos.pLector.GetInt32(2);
                if (!datos.pLector.IsDBNull(3))
                    p.pAnoEstreno = datos.pLector.GetDateTime(3);
                if (!datos.pLector.IsDBNull(4))
                    p.pIdClasificacion = datos.pLector.GetInt32(4);
                if (!datos.pLector.IsDBNull(5))
                    p.pIdVersion = datos.pLector.GetInt32(5);
                if (!datos.pLector.IsDBNull(6))
                    p.pIdGeneroPelicula = datos.pLector.GetInt32(6);
                lp.Add(p);
                
            }
            datos.pLector.Close();//cierro el lector de dataReader
            datos.desconectar();//desconecto de la base
            lstPelicula.Items.Clear();//limpio los items de la lista lst grafica
            lstPelicula.Items.AddRange(lp.ToArray()); //todo lo de la lista lo pongo en lst grafica
        }

        private bool existe(Peliculas p)//metodo para saber si existe.. se hace una consulta
        {
            string sql = "SELECT * FROM peliculas WHERE id_pelicula = " +
                p.pIdPelicula.ToString();
            DataTable tabla = datos.consultar(sql);
            return tabla.Rows.Count > 0;
        }

        private void cargarCampos(int posicion)
        {
            Peliculas selected = lp[posicion];

            txtNombre.Text = selected.pNombre;
            txtDuracion.Text = selected.pDuracion.ToString();
            dtpAnoEstreno.Value = selected.pAnoEstreno;
            cboClasificaciones.SelectedValue = selected.pIdClasificacion;
            cboVersiones.SelectedValue = selected.pIdVersion;
            cboGenerosPelis.SelectedValue = selected.pIdGeneroPelicula;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void limpiarCampos()//metodo genial para limpiar campos
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox)
                    this.Controls[i].Text = "";
                if (this.Controls[i] is CheckBox)
                    ((CheckBox)this.Controls[i]).Checked = false;
                if (this.Controls[i] is RadioButton)
                    ((RadioButton)this.Controls[i]).Checked = false;
                if (this.Controls[i] is DateTimePicker)
                    ((DateTimePicker)this.Controls[i]).Value = DateTime.Today;
            }
        }

        private bool validar()
        {

            if (string.IsNullOrEmpty(txtNombre.Text))//o sino si es txtDetalle.Text=""
            {
                MessageBox.Show("Debe ingresar un Nombre...");
                txtNombre.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtDuracion.Text))//o sino si es txtDetalle.Text=""
            {
                MessageBox.Show("Debe ingresar una Duración...");
                txtNombre.Focus();
                return false;
            }
            else
            {
                int duracion;
                if (!int.TryParse(txtDuracion.Text, out duracion))
                {
                    MessageBox.Show("La Duración permite solo números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDuracion.Focus();
                    return false;
                }
            }

            if (dtpAnoEstreno.Value > DateTime.Now)//no ingresar fechas futuras
            {
                MessageBox.Show("No se puede ingresar una Fecha futura...");
                dtpAnoEstreno.Focus();
                return false;
            }

            if (cboClasificaciones.SelectedIndex == -1)//si no esta seleccionado uno o el otro
            {
                MessageBox.Show("Debe ingresar una Clasificación...");
                cboClasificaciones.Focus();
                return false;
            }

            if (cboVersiones.SelectedIndex == -1)//si no esta seleccionado uno o el otro
            {
                MessageBox.Show("Debe ingresar una Version...");
                cboVersiones.Focus();
                return false;
            }

            if (cboGenerosPelis.SelectedIndex == -1)//si no esta seleccionado uno o el otro
            {
                MessageBox.Show("Debe ingresar un Genero...");
                cboGenerosPelis.Focus();
                return false;
            }

            //se puede hacer un metodo para validar todos los txt
            return true;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string sql = null;
                //se carga el alumno todo validadooooo!!!!!!!!!
                Peliculas p = new Peliculas();
                p.pIdPelicula = lp[lstPelicula.SelectedIndex].pIdPelicula;
                p.pNombre = txtNombre.Text;
                p.pDuracion = int.Parse(txtDuracion.Text);
                p.pAnoEstreno = dtpAnoEstreno.Value;
                p.pIdClasificacion = Convert.ToInt32(cboClasificaciones.SelectedIndex);
                p.pIdVersion = Convert.ToInt32(cboClasificaciones.SelectedIndex);
                p.pIdGeneroPelicula = Convert.ToInt32(cboClasificaciones.SelectedIndex);

                if (nuevo)
                {
                   // if (!existe(p))//mando todo el alumno para ver si existe o no
                    {
                        //si no existe, insert
                        sql = "INSERT INTO Peliculas values('" +
                            p.pNombre + "'," +
                            p.pDuracion + ",'" +
                            p.pAnoEstreno.ToString("yyyy-MM-dd") + "'," +
                            p.pIdClasificacion + "," +
                            p.pIdVersion + "," +
                            p.pIdGeneroPelicula + ")";
                        datos.actualizar(sql);//para hacer la consulta y agregar el registro a la base de datos.. 
                        this.cargarLista("peliculas");//actualizar la lista
                        MessageBox.Show("La pelicula se cargó exitosamente!");
                    }
                  //  else
                    {
                 //       MessageBox.Show("Esta Pelicula ya está registrado!");

                    }
                }
                else
                {
                    //update sin idPelicula 
                    sql = "UPDATE Peliculas SET " +
                        "nombre_pelicula='" + p.pNombre + "', " +
                        "duracion=" + p.pDuracion + ", " +
                        "año_estreno='" + p.pAnoEstreno.ToString("yyyy-MM-dd") + "', " +
                        "id_clasificacion=" + p.pIdClasificacion + ", " +
                        "id_version=" + p.pIdVersion + ", " +
                        "idgenero_pelicula=" + p.pIdGeneroPelicula +//espacio en blanco antes del where y comillas simples en fecha
                        " WHERE id_pelicula =" + p.pIdPelicula; //aca va la condicion!!
                    datos.actualizar(sql);
                    this.cargarLista("peliculas");
                    MessageBox.Show("La pelicula se actualizó exitosamente!");
                }
                habilitarBotones(false);
                limpiarCampos();
                nuevo = false;
                lstPelicula.SelectedIndex = 0;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
            this.nuevo = true;
            this.habilitarBotones(true);
            this.limpiarCampos();
            this.txtNombre.Focus();
            cboClasificaciones.SelectedIndex = -1;
            cboVersiones.SelectedIndex = -1;
            cboGenerosPelis.SelectedIndex = -1;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.nuevo = false;
            this.limpiarCampos();
            this.habilitarBotones(false);
            if (lstPelicula.SelectedIndex != -1)
            {
                cargarCampos(lstPelicula.SelectedIndex);
            }
            lstPelicula.SelectedIndex = 0;
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            habilitarBotones(true);
            txtNombre.Focus();
            cboClasificaciones.Enabled = true;
            cboGenerosPelis.Enabled = true;
            cboVersiones.Enabled = true;
        }

        private void lstPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPelicula.SelectedIndex != -1)
            {
                cargarCampos(lstPelicula.SelectedIndex);
            }
            
        }

        public bool letras(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            
            return false;
        }

        public bool numeros(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }

        private void txtIdPelicula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = numeros(sender, e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = letras(sender, e);
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = numeros(sender, e);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstPelicula.SelectedIndex != -1)
            {
                Peliculas selected = lp[lstPelicula.SelectedIndex];
                if (MessageBox.Show("Seguro que desea eliminar la Pelicula?",
                    "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {

                    string query = "DELETE From peliculas WHERE " +
                        "id_pelicula = " +
                        selected.pIdPelicula.ToString();//el de la posicion de la lista,
                    datos.actualizar(query);//actualizar la base de datos y la lista
                    cargarLista("peliculas");

                }
            }
            limpiarCampos();
            cargarLista("peliculas");
            if (lstPelicula.SelectedIndex != -1)
            {
                cargarCampos(lstPelicula.SelectedIndex);
            }
            lstPelicula.SelectedIndex = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void Programacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir de la aplicación?"
                           , "SALIR"
                           , MessageBoxButtons.OKCancel
                           , MessageBoxIcon.Question
                           , MessageBoxDefaultButton.Button1)
                           == DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}

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
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            Laboratorio labo = new Laboratorio();
            labo.ShowDialog();
        }

        private void btnProgramacion_Click(object sender, EventArgs e)
        {
            Programacion prog = new Programacion();
            prog.ShowDialog();

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ViewReport vr = new ViewReport();
            vr.ShowDialog();
        }
    }
}

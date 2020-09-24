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
    public partial class Laboratorio : Form
    {
        public Laboratorio()
        {
            InitializeComponent();
        }

        private void btnParametro_Click(object sender, EventArgs e)
        {
            ConsultasParametro cp = new ConsultasParametro();
            cp.ShowDialog();
        }

        private void btnFijas_Click(object sender, EventArgs e)
        {
            ConsultasFijas cf = new ConsultasFijas();
            cf.ShowDialog();
        }
    }
}

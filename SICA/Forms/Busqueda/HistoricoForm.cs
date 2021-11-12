using SICA.Forms.Busqueda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class HistoricoForm : Form
    {
        public HistoricoForm()
        {
            InitializeComponent();
        }

        private void HistoricoForm_Load(object sender, EventArgs e)
        {
            btEditar.Visible = Globals.auBusquedaEditar;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            EditarForm ef = new EditarForm();
            ef.ShowDialog();
        }
    }
}

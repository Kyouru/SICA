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
            string strSQL = "";
            DataTable dt = new DataTable();

            try
            {
                LoadingScreen.iniciarLoading();

                strSQL = Globals.mostrarSQL;

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }
    }
}

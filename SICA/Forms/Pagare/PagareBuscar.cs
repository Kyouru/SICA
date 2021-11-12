using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Pagare
{
    public partial class PagareBuscar : Form
    {
        public PagareBuscar()
        {
            InitializeComponent();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();

                strSQL = "SELECT SOLICITUD_SISGO, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, U.NOMBRE_USUARIO";
                strSQL += " FROM PAGARE PA LEFT JOIN USUARIO U ON U.ID_USUARIO = PA.ID_USUARIO_POSEE";
                strSQL += " WHERE 1 = 1";

                if (tbBuscar.Text != "")
                {
                    strSQL += " AND CONCAT LIKE '%" + tbBuscar.Text + "%'";
                }
                strSQL += " ORDER BY SOLICITUD_SISGO DESC";

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
                //dgv.Columns[0].Visible = false;
                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }
    }
}

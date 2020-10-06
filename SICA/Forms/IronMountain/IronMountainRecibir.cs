using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainRecibir : Form
    {
        public IronMountainRecibir()
        {
            InitializeComponent();
            actualizarCantidad();
        }

        private void actualizarCajas()
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                dt.Columns.Add("CAJA", System.Type.GetType("System.String"));
                dt.Columns.Add("FECHA SOLICITUD", System.Type.GetType("System.String"));
                dt.Columns.Add("USUARIO", System.Type.GetType("System.String"));

                strSQL = "SELECT DISTINCT IH.NUMERO_CAJA AS CAJA, IH.FECHA_INICIO AS 'FECHA SOLICITUD', OBSERVACION AS USUARIO FROM INVENTARIO_HISTORICO IH";
                strSQL = strSQL + " LEFT JOIN TMP_CARRITO TC ON TC.NUMERO_CAJA = IH.NUMERO_CAJA";

                strSQL = strSQL + " WHERE IH.ID_USUARIO_ENTREGA_FK = " + Globals.IdIM;
                strSQL = strSQL + " AND IH.ANULADO IS NULL";
                strSQL = strSQL + " AND TC.NUMERO_CAJA IS NULL";
                strSQL = strSQL + " AND IH.ID_USUARIO_RECIBE_FK IS NULL";
                strSQL = strSQL + " AND IH.FECHA_FIN IS NULL";

                strSQL = strSQL + " ORDER BY FECHA_INICIO";

                //MessageBox.Show(strSQL);
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgv.DataSource = dt;
                    dgv.Columns[1].Width = 400;
                    dgv.Columns[2].Width = 200;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                IronMountainFunctions.RecibirCajasCarrito();
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainRecibir) + ")";
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainRecibir);
                actualizarCantidad();
                actualizarCajas();
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainRecibir) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, "", 1, 1, true);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strIronMountainRecibir);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainRecibir;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            actualizarCajas();
        }
    }

}

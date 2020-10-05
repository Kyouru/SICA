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
    public partial class IronMountainEnviar : Form
    {
        public IronMountainEnviar()
        {
            InitializeComponent();
            actualizarCantidad();
        }
        private void actualizarCajas ()
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();
                /*
                dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
                dt.Columns.Add("CAJA", System.Type.GetType("System.String"));
                dt.Columns.Add("DEPART", System.Type.GetType("System.String"));
                dt.Columns.Add("DOC", System.Type.GetType("System.String"));
                dt.Columns.Add("DESDE", System.Type.GetType("System.String"));
                dt.Columns.Add("HASTA", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 1", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 2", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 3", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 4", System.Type.GetType("System.String"));
                dt.Columns.Add("CUSTODIADO", System.Type.GetType("System.String"));
                dt.Columns.Add("POSEE", System.Type.GetType("System.String"));
                dt.Columns.Add("FECHA", System.Type.GetType("System.String"));*/

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA WHERE IG.NUMERO_DE_CAJA <> '' AND IG.USUARIO_POSEE = '" + Globals.Username + "'";
                strSQL = strSQL + " AND TC.NUMERO_CAJA IS NULL";
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgv.DataSource = dt;
                    dgv.Columns[0].Width = 0;
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
                IronMountainFunctions.EnviarCajasCarrito();
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEnviar) + ")";
                actualizarCajas();
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainEnviar);
                actualizarCantidad();
                actualizarCajas();
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEnviar) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, "", 1, 1, true);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            lbCantidad.Text = "(" + GlobalFunctions.LimpiarCarrito(Globals.strIronMountainEnviar) + ")";
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainEnviar;
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

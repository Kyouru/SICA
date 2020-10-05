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

namespace SICA.Forms.Boveda
{
    public partial class BovedaGuardar : Form
    {
        public BovedaGuardar()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {

                string strSQL;
                DataTable dt = new DataTable("BOVEDA");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = '" + Globals.Username + "'";

                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY NUMERO_DE_CAJA";

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
            if (dgv.SelectedRows.Count == 1)
            {
                if (cbCaja.Checked)
                {
                    using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        SQLiteCommand sqliteCmd;
                        sqliteConnection.Open();
                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                        try
                        {
                            DataTable dt = new DataTable();
                            SQLiteDataAdapter sqliteDataAdapter;
                            string strSQL;
                            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                            strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.USERNAME = IG.USUARIO_POSEE)";
                            strSQL = strSQL + " LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL_FK";
                            strSQL = strSQL + " WHERE U.BOVEDA = 1 AND CUSTODIADO = 'CUSTODIADO' AND TC.ID_TMP_CARRITO IS NULL AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                            strSQL = strSQL + " AND NUMERO_DE_CAJA = '" + dgv.SelectedRows[0].Cells["ID"].Value.ToString() + "'";
                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                            sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                            sqliteDataAdapter.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARION_GENERAL_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (" + row["ID"].ToString() + ", " + Globals.IdUsername + ", '" + Globals.strBovedaGuardar + "', '" + row["CAJA"].ToString() + "')";
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                            }

                            sqliteTransaction.Commit();
                            sqliteConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strBovedaGuardar);
                }

                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaGuardar) + ")";
                btBuscar_Click(sender, e);
            }
        }

        private void btBovedaGuardar_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                BovedaFunctions.RetiroCarrito();
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaGuardar) + ")";
                btBuscar_Click(sender, e);
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainSolicitar);
                actualizarCantidad();
                btBuscar_Click(sender, e);
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainSolicitar) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, "", 1, 1, true);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            lbCantidad.Text = "(" + GlobalFunctions.LimpiarCarrito(Globals.strIronMountainSolicitar) + ")";
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainSolicitar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }
        public static void StartLoadingScreen()
        {
            try
            {
                Application.Run(new LoadingScreen());
            }
            catch
            {

            }
        }

    }
}

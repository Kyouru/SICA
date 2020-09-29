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

namespace SICA.Forms
{
    public partial class IronMountainForm : Form
    {
        public IronMountainForm()
        {
            InitializeComponent();
            lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito("IM") + ")";
        }

        private void btBuscarReingreso_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

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
                dt.Columns.Add("FECHA", System.Type.GetType("System.String"));

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                //strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = 'IRON MOUNTAIN'";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = 'IRON MOUNTAIN'";
                if (tbCaja.Text != "")
                {
                    strSQL = strSQL + " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
                }

                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";

                //MessageBox.Show(strSQL);
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvSolicitarIM.DataSource = dt;
                    dgvSolicitarIM.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void dgvSolicitarIM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSolicitarIM.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvSolicitarIM.SelectedRows[0].Cells[0].Value.ToString(), "0", dgvSolicitarIM.SelectedRows[0].Cells["CAJA"].Value.ToString(), "IM");
                lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito("IM") + ")";
                dgvSolicitarIM.SelectedRows[0].Height = 0;
            }
        }

        private void btSolicitarCajasIM_Click(object sender, EventArgs e)
        {
            if (lbCantidadSolicitar.Text != "(0)")
            {
                //GlobalFunctions.SolicitarCarrito("IM");
                GlobalFunctions.SolicitarCajasCarrito("IM");
                lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito("IM") + ")";
            }
        }

        private void tpSolicitarIM_Enter(object sender, EventArgs e)
        {
            lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito("IM") + ")";
        }

        private void btActualizarRecibir_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                dt.Columns.Add("CAJA", System.Type.GetType("System.String"));
                dt.Columns.Add("FECHA SOLICITUD", System.Type.GetType("System.String"));
                dt.Columns.Add("USUARIO", System.Type.GetType("System.String"));

                strSQL = "SELECT DISTINCT NUMERO_CAJA AS CAJA, FECHA_INICIO AS 'FECHA SOLICITUD', OBSERVACION AS USUARIO FROM INVENTARIO_HISTORICO";
                strSQL = strSQL + " WHERE ID_USUARIO_ENTREGA_FK = " + Globals.IdIM;
                strSQL = strSQL + " AND ANULADO IS NULL";
                strSQL = strSQL + " AND ID_USUARIO_RECIBE_FK IS NULL";
                strSQL = strSQL + " AND FECHA_FIN IS NULL";

                strSQL = strSQL + " ORDER BY FECHA_INICIO";

                //MessageBox.Show(strSQL);
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvRecibirIM.DataSource = dt;
                    dgvRecibirIM.Columns[1].Width = 400;
                    dgvRecibirIM.Columns[2].Width = 200;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void dgvRecibirIM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecibirIM.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito("0", "0", dgvRecibirIM.SelectedRows[0].Cells["CAJA"].Value.ToString(), "IM_RECIBIR");
                lbCantidadRecibir.Text = "(" + GlobalFunctions.CantidadCarrito("IM_RECIBIR") + ")";
                dgvRecibirIM.SelectedRows[0].Height = 0;
            }
        }

        private void btRecibirCajas_Click(object sender, EventArgs e)
        {
            if (lbCantidadRecibir.Text != "(0)")
            {
                //GlobalFunctions.SolicitarCarrito("IM");
                GlobalFunctions.RecibirCajasCarrito("IM_RECIBIR");
                lbCantidadRecibir.Text = "(" + GlobalFunctions.CantidadCarrito("IM_RECIBIR") + ")";
            }
        }
    }
}

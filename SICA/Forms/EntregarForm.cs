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
    public partial class EntregarForm : Form
    {
        public EntregarForm()
        {
            InitializeComponent();
            lbCantidadEXP.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarExpediente) + ")";
        }

        private void btBuscarEXP_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA ";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL ";
                strSQL = strSQL + " AND DESCRIPCION_1 = 'EXPEDIENTES DE CREDITO' AND USUARIO_POSEE = '" + Globals.Username + "'";

                if (tbBusquedaLibreEXP.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibreEXP.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY DESCRIPCION_2";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvExpedientes.DataSource = dt;
                    dgvExpedientes.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void tbBusquedaLibreEXP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscarEXP_Click(sender, e);
            }
        }
        
        private void dgvExpedientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExpedientes.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvExpedientes.SelectedRows[0].Cells[0].Value.ToString(), "0", dgvExpedientes.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strEntregarExpediente);
                lbCantidadEXP.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarExpediente) + ")";
                btBuscarEXP_Click(sender, e);
            }
        }

        private void btEntregarEXP_Click(object sender, EventArgs e)
        {
            if (lbCantidadEXP.Text != "(0)")
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0 )
                {
                    EntregarFunctions.EntregarExpedientesCarrito();
                    lbCantidadEXP.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarExpediente) + ")";

                    btBuscarEXP_Click(sender, e);
                }
            }
        }

        private void btVerCarritoEXP_Click(object sender, EventArgs e)
        {
            if (lbCantidadEXP.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strEntregarExpediente;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void tbExpedientes_Enter(object sender, EventArgs e)
        {
            lbCantidadEXP.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarExpediente) + ")";
        }

        private void btBuscarDOC_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL ";
                strSQL = strSQL + " AND DESCRIPCION_1 <> 'EXPEDIENTES DE CREDITO' AND AND USUARIO_POSEE = '" + Globals.Username + "'";
                
                if (tbBusquedaLibreDOC.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibreDOC.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY DESCRIPCION_2";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvDocumentos.DataSource = dt;
                    dgvDocumentos.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btEntregarDOC_Click(object sender, EventArgs e)
        {
            if (lbCantidadDOC.Text != "(0)")
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    EntregarFunctions.EntregarDocumentosCarrito();
                    lbCantidadDOC.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarDocumento) + ")";

                    btBuscarDOC_Click(sender, e);
                }
            }
        }

        private void btVerCarritoDocumento_Click(object sender, EventArgs e)
        {
            if (lbCantidadDOC.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strEntregarDocumento;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvDocumentos.SelectedRows[0].Cells[0].Value.ToString(), "0", dgvDocumentos.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strEntregarDocumento);
                lbCantidadDOC.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarDocumento) + ")";
                btBuscarDOC_Click(sender, e);
            }
        }

        private void tpDocumentos_Enter(object sender, EventArgs e)
        {
            lbCantidadDOC.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarDocumento) + ")";
        }

        private void btBuscarPagare_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("REPORTE_VALORADOS");
                sqliteConnection.Open();
                if (cbDesembolsado.Checked)
                {
                    strSQL = "SELECT ID_REPORTE_VALORADOS AS ID, CIP, NOMBRE, MONTOPRESTAMO AS MONTO, SOLICITUD_SISGO AS SISGO, SIP, TIPO_PRESTAMO AS TIPO, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS CANCELACION, PAGARE ";
                    strSQL = strSQL + "FROM REPORTE_VALORADOS RV LEFT JOIN TMP_CARRITO TC ON TC.ID_REPORTE_VALORADOS_FK = RV.ID_REPORTE_VALORADOS";
                    strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND USUARIO_POSEE = '" + Globals.Username + "'";
                    if (tbBusquedaLibrePagare.Text != "")
                    {
                        strSQL = strSQL + " AND SOLICITUD_SISGO LIKE '%" + tbBusquedaLibrePagare.Text + "%'";
                    }
                    strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
                }
                else
                {
                    strSQL = "SELECT ID_PAGARE_SIN_DESEMBOLSAR AS ID, SOLICITUD_SISGO AS SISGO, DESCRIPCION_1, DESCRIPCION_2, SDESCRIPCION_3, DESCRIPCION_4";
                    strSQL = strSQL + "FROM PAGARE_SIN_DESEMBOLSAR PSD LEFT JOIN TMP_CARRITO TC ON TC.ID_REPORTE_VALORADOS_FK = PSD.ID_PAGARE_SIN_DESEMBOLSAR";
                    strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND USUARIO_POSEE = '" + Globals.Username + "'";
                    if (tbBusquedaLibrePagare.Text != "")
                    {
                        strSQL = strSQL + " AND CONCATENADO LIKE '%" + tbBusquedaLibrePagare.Text + "%'";
                    }
                    strSQL = strSQL + " AND DESEMBOLSADO = 0 ";
                    strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
                }
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvPagare.DataSource = dt;
                    dgvPagare.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void dgvPagare_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagare.SelectedRows.Count == 1)
            {
                if (cbDesembolsado.Checked)
                {
                    GlobalFunctions.AgregarCarrito("0", dgvPagare.SelectedRows[0].Cells[0].Value.ToString(), dgvPagare.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strEntregarPagare);
                    lbCantidadPagare.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagare) + ")";
                }
                else
                {
                    GlobalFunctions.AgregarCarrito("0", dgvPagare.SelectedRows[0].Cells[0].Value.ToString(), dgvPagare.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strEntregarPagareSinDesembolsar);
                    lbCantidadPagare.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagareSinDesembolsar) + ")";
                }
                
                btBuscarPagare_Click(sender, e);
            }
        }

        private void btEntregarPagare_Click(object sender, EventArgs e)
        {
            if (lbCantidadPagare.Text != "(0)")
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    if (cbDesembolsado.Checked)
                    {
                        EntregarFunctions.EntregarPagaresCarrito(1);
                        lbCantidadPagare.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagare) + ")";
                    }
                    else
                    {
                        EntregarFunctions.EntregarPagaresCarrito(0);
                        lbCantidadPagare.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagareSinDesembolsar) + ")";
                    }

                    btBuscarPagare_Click(sender, e);
                }
            }
        }

        private void tpPagare_Enter(object sender, EventArgs e)
        {
            if (cbDesembolsado.Checked)
            {
                lbCantidadPagare.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagare) + ")";
            }
            else
            {
                lbCantidadPagare.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagareSinDesembolsar) + ")";
            }
        }

    }
}

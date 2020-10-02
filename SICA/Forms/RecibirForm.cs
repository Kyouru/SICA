using SICA.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    public partial class RecibirForm : Form
    {
        public RecibirForm()
        {
            InitializeComponent();
        }

        private void btBuscarCargo_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro de Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strSQL;
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                SQLiteCommand sqliteCmd;
                SQLiteDataAdapter sqliteDataAdapter;
                try
                {
                    dt = GlobalFunctions.ConvertExcelToDataTable(ofd.FileName, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                dgvCargo.DataSource = dt;
                dt.Columns.Add("STATUS");
                dt.Columns.Add("ID REPORTE");
                foreach (DataGridViewRow row in dgvCargo.Rows)
                {
                    if (row.Cells["CODIGO DEPARTAMENTO"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Codigo Departamento Vacío;";
                    }
                    if (row.Cells["CODIGO DOCUMENTO"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Codigo Documento Vacío;";
                    }
                    if (row.Cells["FECHA DESDE"].Value.ToString() != "" && !GlobalFunctions.IsDate(row.Cells["FECHA DESDE"].Value.ToString()))
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Fecha Desde Invalida;";
                    }
                    if (row.Cells["FECHA HASTA"].Value.ToString() != "" && !GlobalFunctions.IsDate(row.Cells["FECHA HASTA"].Value.ToString()))
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Fecha Hasta Invalida;";
                    }
                    if (row.Cells["DESCRIPCION 1"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Descripcion 1 Vacío;";
                    }
                    if (row.Cells["DESCRIPCION 2"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Descripcion 2 Vacío;";
                    }
                    if (row.Cells["QUIEN ENTREGA"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Quien Entrega Vacío;";
                    }
                    if (row.Cells["STATUS"].Value.ToString() == "" && row.Cells["DESCRIPCION 2"].Value.ToString() != "")
                    {
                        using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                        {
                            try
                            {
                                dt2 = new DataTable();
                                sqliteConnection.Open();
                                strSQL = "SELECT ID_USUARIO, USERNAME FROM USUARIO WHERE NOMBRE_COMPLETO = '" + row.Cells["QUIEN ENTREGA"].Value.ToString() + "'";
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                                sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                                sqliteDataAdapter.Fill(dt2);


                                strSQL = "SELECT ID_REPORTE_VALORADOS FROM REPORTE_VALORADOS WHERE SOLICITUD_SISGO = '" + row.Cells["DESCRIPCION 2"].Value.ToString().Replace("'", "''") + "'";
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                                sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                                sqliteDataAdapter.Fill(dt3);
                                sqliteConnection.Close();
                            }
                            catch (Exception ex)
                            {
                                sqliteConnection.Close();
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }

                        if (dt3.Rows.Count == 1)
                        {
                            row.Cells["ID REPORTE"].Value = dt3.Rows[0][0].ToString();
                            row.Cells["STATUS"].Value = "OK, Desembolsado";
                        }
                        else if (dt3.Rows.Count == 0)
                        {
                            row.Cells["STATUS"].Value = "OK, SIN desembolsar";
                        }
                        else if (dt3.Rows.Count > 1)
                        {
                            row.Cells["ID REPORTE"].Value = dt3.Rows[0][0].ToString();
                            row.Cells["STATUS"].Value = "OK, Desembolsado";
                        }

                        if (dt2.Rows.Count > 0)
                        {
                            Globals.IdUsernameSelect = Int32.Parse(dt2.Rows[0][0].ToString());
                            Globals.UsernameSelect = dt2.Rows[0][1].ToString();
                        }
                        else
                        {
                            row.Cells["STATUS"].Value = "Quien Entrega No existe; ";
                        }
                    }
                }
            }
            if (valido)
            {
                btCargarValido.Visible = true; 
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            SQLiteCommand sqliteCmd;
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-ss HH:mm:ss") + "'";
                Boolean pagare;
                Boolean expediente;
                try
                {
                    sqliteConnection.Open();
                    SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                    foreach (DataGridViewRow row in dgvCargo.Rows)
                    {
                        if (row.Cells["PAGARE"].Value.ToString() == "SI")
                        {
                            pagare = true;
                        }
                        else
                        {
                            pagare = false;
                        }
                        if (row.Cells["EXPEDIENTE"].Value.ToString() == "SI")
                        {
                            expediente = true;
                        }
                        else
                        {
                            expediente = false;
                        }

                        if (row.Cells["STATUS"].Value.ToString() == "Desembolsado")
                        {
                            if (pagare)
                            {
                                sqliteCmd = new SQLiteCommand("INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, FECHA) VALUES (" + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + row.Cells["ID REPORTE"].Value.ToString() + ", ", sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                            }
                            if (row.Cells["DESCRIPCION 1"].Value.ToString() == "EXPEDIENTES DE CREDITO" && expediente)
                            {
                                if (!GlobalFunctions.EstadoCustodiaReporte(row.Cells["DESCRIPCION 2"].Value.ToString(), expediente, pagare, sqliteConnection))
                                {
                                    sqliteConnection.Close();
                                    return;
                                }
                            }

                            sqliteCmd = new SQLiteCommand(RecibirFunctions.ArmarStrNuevoIngreso(row), sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();

                            sqliteCmd = new SQLiteCommand("INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_RECIBE) VALUES (" + sqliteConnection.LastInsertRowId + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ")", sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                        }
                        else if (row.Cells["STATUS"].Value.ToString() == "SIN desembolsar")
                        {
                            sqliteCmd = new SQLiteCommand(RecibirFunctions.ArmarStrNuevoIngreso(row), sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();

                            sqliteCmd = new SQLiteCommand("INSERT INTO SIN_DESEMBOLSAR (SOLICITUD_SISGO, PAGARE, ID_INVENTARIO_GENERAL_FK) VALUES ('" + row.Cells["DESCRIPCION 2"].Value.ToString() + "', " + expediente + ", " + pagare + ", " + sqliteConnection.LastInsertRowId + ")", sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                        }
                    }
                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Proceso Finalizado");
                    dgvCargo.DataSource = null;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void btBuscarReingreso_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, ID_REPORTE_VALORADOS_FK AS 'ID REPORTE'";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = IG.ID_INVENTARIO_GENERAL WHERE TC.ID_TMP_CARRITO IS NULL";
                strSQL = strSQL + " AND (CUSTODIADO = 'PRESTADO' OR CUSTODIADO = 'DEVUELTO')";

                if (tbUsuario.Text != "")
                {
                    strSQL = strSQL + " AND USUARIO_POSEE LIKE '%" + tbUsuario.Text + "%'";
                }
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvReingreso.DataSource = dt;
                    dgvReingreso.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
        }
        
        private void dgvReingreso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReingreso.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvReingreso.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgvReingreso.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strRecibirReingreso);
                lbCantidadReingreso.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strRecibirReingreso) + ")";
                btBuscarReingreso_Click(sender, e);
            }
        }

        private void tpReingreso_Enter(object sender, EventArgs e)
        {
            lbCantidadReingreso.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strRecibirReingreso) + ")";
        }

        private void btRecibirReingreso_Click(object sender, EventArgs e)
        {
            if (lbCantidadReingreso.Text != "(0)")
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    RecibirFunctions.ReingresoCarrito(Globals.IdUsernameSelect, observacion);
                    lbCantidadReingreso.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strRecibirReingreso) + ")";
                }
            }
        }

        private void btBuscarPagare_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("REPORTE_VALORADOS");
                sqliteConnection.Open();

                strSQL = "SELECT ID_REPORTE_VALORADOS AS ID, CIP, NOMBRE, MONTOPRESTAMO AS MONTO, SOLICITUD_SISGO AS SISGO, SIP, TIPO_PRESTAMO AS TIPO, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS CANCELACION, PAGARE ";
                strSQL = strSQL + " FROM REPORTE_VALORADOS";
                strSQL = strSQL + " WHERE (PAGARE = 'NO CUSTODIADO' OR PAGARE = 'PRESTADO' OR PAGARE = 'PROTESTO' OR PAGARE IS NULL)";
                if (tbSolicitud.Text != "")
                {
                    strSQL = strSQL + " AND SOLICITUD_SISGO LIKE '%" + tbSolicitud.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY FECHA_OTORGADO";

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

        private void btRecibirPagare_Click(object sender, EventArgs e)
        {
            if (dgvPagare.SelectedRows.Count == 1)
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    RecibirFunctions.RecibirPagare(dgvPagare.SelectedRows[0].Cells["ID"].Value.ToString());
                    btBuscarPagare_Click(sender, e);
                }
            }
        }

        private void btCargarLetras_Click(object sender, EventArgs e)
        {

        }

        private void btVerCarritoReingreso_Click(object sender, EventArgs e)
        {
            if (lbCantidadReingreso.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strRecibirReingreso;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void dgvPagare_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btRecibirPagare_Click(sender, e);
        }
    }
}

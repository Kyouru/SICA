using SICA.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
                DataTable dt4 = new DataTable();
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

                //dgvCargo.DataSource = dt;
                dt.Columns.Add("STATUS");
                dt.Columns.Add("ID REPORTE");
                foreach (DataRow row in dt.Rows)
                {
                    if (row["CODIGO DEPARTAMENTO"].ToString() == "")
                    {
                        valido = false;
                        row["STATUS"] = row["STATUS"].ToString() + "Codigo Departamento Vacío;";
                    }
                    if (row["CODIGO DOCUMENTO"].ToString() == "")
                    {
                        valido = false;
                        row["STATUS"] = row["STATUS"].ToString() + "Codigo Documento Vacío;";
                    }
                    if (row["FECHA DESDE"].ToString() != "" && !GlobalFunctions.IsDate(row["FECHA DESDE"].ToString()))
                    {
                        valido = false;
                        row["STATUS"] = row["STATUS"].ToString() + "Fecha Desde Invalida;";
                    }
                    if (row["FECHA HASTA"].ToString() != "" && !GlobalFunctions.IsDate(row["FECHA HASTA"].ToString()))
                    {
                        valido = false;
                        row["STATUS"] = row["STATUS"].ToString() + "Fecha Hasta Invalida;";
                    }
                    if (row["DESCRIPCION 1"].ToString() == "")
                    {
                        valido = false;
                        row["STATUS"] = row["STATUS"].ToString() + "Descripcion 1 Vacío;";
                    }
                    if (row["DESCRIPCION 2"].ToString() == "")
                    {
                        valido = false;
                        row["STATUS"] = row["STATUS"].ToString() + "Descripcion 2 Vacío;";
                    }
                    if (valido)
                    {
                        btCargarValido.Visible = true;
                        row["STATUS"] = "OK";
                    }
                }

                using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    try
                    {
                        sqliteConnection.Open();

                        strSQL = "SELECT SOLICITUD_SISGO, ID_REPORTE_VALORADOS, EXPEDIENTE, PAGARE FROM REPORTE_VALORADOS";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                        sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                        sqliteDataAdapter.Fill(dt2);

                        strSQL = "SELECT DISTINCT ID_EXPEDIENTE_SIN_DESEMBOLSAR, SOLICITUD_SISGO FROM EXPEDIENTE_SIN_DESEMBOLSAR WHERE DESEMBOLSADO IS NULL";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                        sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                        sqliteDataAdapter.Fill(dt3);

                        strSQL = "SELECT DISTINCT ID_PAGARE_SIN_DESEMBOLSAR, SOLICITUD_SISGO FROM PAGARE_SIN_DESEMBOLSAR WHERE DESEMBOLSADO IS NULL";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                        sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                        sqliteDataAdapter.Fill(dt4);

                        sqliteConnection.Close();

                        var result = from c1 in dt.AsEnumerable()
                                     join c2 in dt2.AsEnumerable() on c1.Field<string>("DESCRIPCION 2") equals c2.Field<string>("SOLICITUD_SISGO") into j
                                     join c3 in dt3.AsEnumerable() on c1.Field<string>("DESCRIPCION 2") equals c3.Field<string>("SOLICITUD_SISGO") into k
                                     join c4 in dt4.AsEnumerable() on c1.Field<string>("DESCRIPCION 2") equals c4.Field<string>("SOLICITUD_SISGO") into m
                                     from p in j.DefaultIfEmpty() from q in k.DefaultIfEmpty() from r in m.DefaultIfEmpty()
                                     select new
                                     {
                                         ID_REPORTE = p is null ? 0 : p.Field<long>("ID_REPORTE_VALORADOS"),
                                         STATUS = c1.Field<string>("STATUS"),
                                         DESC_1 = c1.Field<string>("DESCRIPCION 1"),
                                         DESC_2 = c1.Field<string>("DESCRIPCION 2"),
                                         DESC_3 = c1.Field<string>("DESCRIPCION 3"),
                                         DESC_4 = c1.Field<string>("DESCRIPCION 4"),
                                         DESEMBOLSADO = p is null ? "NO DESEMBOLSADO" : "DESEMBOLSADO",
                                         CUST_EXPEDIENTE = q is null? p is null? "NO CUSTODIADO" : p.Field<string>("EXPEDIENTE") == "1"? "CUSTODIADO" : "NO CUSTODIADO" : "CUSTODIADO",
                                         EXP_INGRESA = c1.Field<string>("EXPEDIENTE"),
                                         CUST_PAGARE = r is null ? p is null ? "NO CUSTODIADO" : p.Field<string>("PAGARE") == "1" ? "CUSTODIADO" : "NO CUSTODIADO" : "CUSTODIADO",
                                         PAG_INGRESA = c1.Field<string>("PAGARE"),
                                         DESDE = c1.Field<string>("FECHA DESDE"),
                                         HASTA = c1.Field<string>("FECHA HASTA"),
                                         NUMERO_CAJA = c1.Field<string>("NUMERO DE CAJA IRON MOUNTAIN"),
                                         COD_DEP = c1.Field<string>("CODIGO DEPARTAMENTO"),
                                         COD_DOC = c1.Field<string>("CODIGO DOCUMENTO")
                                     };
                        dgvCargo.DataSource = result.ToList();
                        dgvCargo.Columns[0].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        sqliteConnection.Close();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
            suf.ShowDialog();
            if (Globals.IdUsernameSelect > 0)
            {
                SQLiteCommand sqliteCmd;
                string strSQL = "";
                long lastinsertid = 0;
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
                            if (row.Cells["PAG_INGRESA"].Value.ToString() == "SI")
                            {
                                pagare = true;
                            }
                            else
                            {
                                pagare = false;
                            }
                            if (row.Cells["EXP_INGRESA"].Value.ToString() == "SI")
                            {
                                expediente = true;
                            }
                            else
                            {
                                expediente = false;
                            }

                            if (row.Cells["DESEMBOLSADO"].Value.ToString() == "DESEMBOLSADO")
                            {
                                if (pagare)
                                {
                                    strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, FECHA) VALUES (" + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + row.Cells["ID_REPORTE"].Value.ToString() + ", " + fecha + ")";
                                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                    sqliteCmd.ExecuteNonQuery();
                                }
                                if (row.Cells["DESC_1"].Value.ToString() == "EXPEDIENTES DE CREDITO" && expediente)
                                {
                                    if (!GlobalFunctions.EstadoCustodiaReporte(row.Cells["DESC_2"].Value.ToString(), expediente, pagare, sqliteConnection))
                                    {
                                        sqliteConnection.Close();
                                        return;
                                    }
                                }

                                sqliteCmd = new SQLiteCommand(RecibirFunctions.ArmarStrNuevoIngreso(row), sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();

                                sqliteCmd = new SQLiteCommand("INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN) VALUES (" + sqliteConnection.LastInsertRowId + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ")", sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                            }
                            else if (row.Cells["DESEMBOLSADO"].Value.ToString() == "NO DESEMBOLSADO")
                            {
                                if (expediente)
                                {
                                    sqliteCmd = new SQLiteCommand(RecibirFunctions.ArmarStrNuevoIngreso(row), sqliteConnection);
                                    sqliteCmd.ExecuteNonQuery();

                                    lastinsertid = sqliteConnection.LastInsertRowId;

                                    if (row.Cells["CUST_EXPEDIENTE"].Value.ToString() == "NO CUSTODIADO")
                                    {
                                        sqliteCmd = new SQLiteCommand("INSERT INTO EXPEDIENTE_SIN_DESEMBOLSAR (SOLICITUD_SISGO, EXPEDIENTE, ID_INVENTARIO_GENERAL_FK, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, CONCATENADO) VALUES ('" + row.Cells["DESC_2"].Value.ToString() + "', " + expediente + ", " + lastinsertid + ", '" + row.Cells["DESC_1"].Value.ToString() + "', '" + row.Cells["DESC_2"].Value.ToString() + "', '" + row.Cells["DESC_3"].Value.ToString() + "', '" + row.Cells["DESC_4"].Value.ToString() + "', '" + row.Cells["DESC_1"].Value.ToString() + ";" + row.Cells["DESC_2"].Value.ToString() + ";" + row.Cells["DESC_3"].Value.ToString() + ";" + row.Cells["DESC_4"].Value.ToString() + "')", sqliteConnection);
                                        sqliteCmd.ExecuteNonQuery();
                                    }
                                    if (pagare && row.Cells["CUST_PAGARE"].Value.ToString() == "NO CUSTODIADO")
                                    {
                                        sqliteCmd = new SQLiteCommand("INSERT INTO PAGARE_SIN_DESEMBOLSAR (SOLICITUD_SISGO, PAGARE, ID_INVENTARIO_GENERAL_FK, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, CONCATENADO) VALUES ('" + row.Cells["DESC_2"].Value.ToString() + "', " + pagare + ", " + lastinsertid + ", '" + row.Cells["DESC_1"].Value.ToString() + "', '" + row.Cells["DESC_2"].Value.ToString() + "', '" + row.Cells["DESC_3"].Value.ToString() + "', '" + row.Cells["DESC_4"].Value.ToString() + "', '" + row.Cells["DESC_1"].Value.ToString() + ";" + row.Cells["DESC_2"].Value.ToString() + ";" + row.Cells["DESC_3"].Value.ToString() + ";" + row.Cells["DESC_4"].Value.ToString() + "')", sqliteConnection);
                                        sqliteCmd.ExecuteNonQuery();
                                    }
                                }
                                else if (pagare && row.Cells["CUST_PAGARE"].Value.ToString() == "NO CUSTODIADO")
                                {
                                    sqliteCmd = new SQLiteCommand("INSERT INTO PAGARE_SIN_DESEMBOLSAR (SOLICITUD_SISGO, PAGARE, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, CONCATENADO) VALUES ('" + row.Cells["DESC_2"].Value.ToString() + "', " + pagare + ", '" + row.Cells["DESC_1"].Value.ToString() + "', '" + row.Cells["DESC_2"].Value.ToString() + "', '" + row.Cells["DESC_3"].Value.ToString() + "', '" + row.Cells["DESC_4"].Value.ToString() + "', '" + row.Cells["DESC_1"].Value.ToString() + ";" + row.Cells["DESC_2"].Value.ToString() + ";" + row.Cells["DESC_3"].Value.ToString() + ";" + row.Cells["DESC_4"].Value.ToString() + "')", sqliteConnection);
                                    sqliteCmd.ExecuteNonQuery();
                                }
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
                        MessageBox.Show(ex.Message + "\n" + strSQL);
                    }
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

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, IG.ID_REPORTE_VALORADOS_FK AS 'ID REPORTE'";
                strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK) ";
                strSQL = strSQL + " LEFT JOIN (SELECT * FROM USUARIO WHERE CUSTODIA = 0 AND REAL = 1) U ON U.USERNAME = IG.USUARIO_POSEE";
                strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND (CUSTODIADO = 'PRESTADO' OR CUSTODIADO = 'DEVUELTO')";

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
                    dgvReingreso.Columns[0].Visible = false;
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
                    dgvPagare.Columns[0].Visible = false;
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
                    dgvPagare.SelectedRows[0].Visible = false;
                    //btBuscarPagare_Click(sender, e);
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

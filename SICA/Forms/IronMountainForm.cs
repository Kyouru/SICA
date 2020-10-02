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

        private void btBuscarSolicitarIM_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
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
                GlobalFunctions.AgregarCarrito(dgvSolicitarIM.SelectedRows[0].Cells[0].Value.ToString(), "0", dgvSolicitarIM.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainSolicitar);
                lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainSolicitar) + ")";
                //btBuscarSolicitarIM_Click(sender, e);
                dgvSolicitarIM.SelectedRows[0].Height = 0;
            }
        }

        private void btSolicitarCajasIM_Click(object sender, EventArgs e)
        {
            if (lbCantidadSolicitar.Text != "(0)")
            {
                //GlobalFunctions.SolicitarCarrito("IM");
                IronMountainFunctions.SolicitarCajasCarrito();
                lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainSolicitar) + ")";
                //btBuscarSolicitarIM_Click(sender, e);
                dgvSolicitarIM.SelectedRows[0].Height = 0;
            }
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
                GlobalFunctions.AgregarCarrito("0", "0", dgvRecibirIM.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainRecibir);
                lbCantidadRecibir.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainRecibir) + ")";
                btActualizarRecibir_Click(sender, e);
            }
        }

        private void btRecibirCajas_Click(object sender, EventArgs e)
        {
            if (lbCantidadRecibir.Text != "(0)")
            {
                IronMountainFunctions.RecibirCajasCarrito();
                lbCantidadRecibir.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainRecibir) + ")";
            }
        }

        private void btBuscarArmar_Click(object sender, EventArgs e)
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
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = '" + Globals.Username + "'";
                
                if (tbBusquedaArmar.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaArmar.Text + "%'";
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

                    dgvArmarIM.DataSource = dt;
                    dgvArmarIM.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void dgvArmarIM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArmarIM.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvArmarIM.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgvArmarIM.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainArmar);
                lbCantidadArmar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainArmar) + ")";
                btBuscarArmar_Click(sender, e);
            }
        }

        private void btArmarCaja_Click(object sender, EventArgs e)
        {
            if (lbCantidadArmar.Text != "(0)")
            {
                string numero = Microsoft.VisualBasic.Interaction.InputBox("Escriba el numero de caja:", "Numero de Caja", "");
                if (numero != "")
                {
                    int n = 0;
                    string check = "CONFIRMADO";
                    using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        SQLiteCommand sqliteCmd;
                        sqliteConnection.Open();

                        try
                        {
                            sqliteCmd = new SQLiteCommand("SELECT COUNT(*) FROM INVENTARIO_GENERAL WHERE NUMERO_DE_CAJA = '" + numero + "'", sqliteConnection);
                            n = Convert.ToInt32(sqliteCmd.ExecuteScalar());
                            sqliteConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (n > 0)
                    {
                        check = Microsoft.VisualBasic.Interaction.InputBox("La Caja no es nueva\nEscriba \"CONFIRMAR\" para reemplazar el contenido" , "Ya registrado", "");
                    }
                    if (check == "CONFIRMADO")
                    {
                        IronMountainFunctions.ArmarCajasCarrito(numero);
                        lbCantidadArmar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainArmar) + ")";
                        btBuscarArmar_Click(sender, e);
                    }
                    
                }
            }
        }

        private void btActualizarEnviar_Click(object sender, EventArgs e)
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

                    dgvEnviarIM.DataSource = dt;
                    dgvEnviarIM.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void dgvEnviarIM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEnviarIM.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvEnviarIM.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgvEnviarIM.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainEnviar);
                lbCantidadEnviar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEnviar) + ")";
                btActualizarEnviar_Click(sender, e);
            }
        }

        private void btEnviarCajas_Click(object sender, EventArgs e)
        {
            if (lbCantidadEnviar.Text != "(0)")
            {
                IronMountainFunctions.EnviarCajasCarrito();
                lbCantidadEnviar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEnviar) + ")";
                btActualizarEnviar_Click(sender, e);
            }
        }

        private void btActualizarEntregar_Click(object sender, EventArgs e)
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
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = 'EN TRANSITO A CP'";
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";


                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvEntregarIM.DataSource = dt;
                    dgvEntregarIM.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void dgvEntregarIM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEntregarIM.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvEntregarIM.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgvEntregarIM.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainEntregar);
                lbCantidadEntregar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEntregar) + ")";
                btActualizarEntregar_Click(sender, e);
            }
        }

        private void btEntregarCajas_Click(object sender, EventArgs e)
        {
            if (lbCantidadEntregar.Text != "(0)")
            {
                IronMountainFunctions.EntregarCajasCarrito();
                lbCantidadEntregar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEntregar) + ")";
                btActualizarEntregar_Click(sender, e);
            }
        }
        private void tpSolicitarIM_Enter(object sender, EventArgs e)
        {
            lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainSolicitar) + ")";
        }

        private void tpRecibirIM_Enter(object sender, EventArgs e)
        {
            lbCantidadRecibir.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainRecibir) + ")";
        }

        private void tpEntregar_Enter(object sender, EventArgs e)
        {
            lbCantidadEntregar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEntregar) + ")";
        }

        private void tpArmarIM_Enter(object sender, EventArgs e)
        {
            lbCantidadArmar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainArmar) + ")";
        }

        private void tpEnviar_Enter(object sender, EventArgs e)
        {
            lbCantidadEnviar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEnviar) + ")";
        }

        private void btVerCarritoSolicitar_Click(object sender, EventArgs e)
        {
            if (lbCantidadSolicitar.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainSolicitar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void IronMountainForm_Load(object sender, EventArgs e)
        {
            lbCantidadSolicitar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainSolicitar) + ")";
        }

        private void btVerCarritoRecibir_Click(object sender, EventArgs e)
        {
            if (lbCantidadRecibir.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainRecibir;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btVerCarritoArmar_Click(object sender, EventArgs e)
        {
            if (lbCantidadArmar.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainArmar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btVerCarritoEnviar_Click(object sender, EventArgs e)
        {
            if (lbCantidadEnviar.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainEnviar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btVerCarritoEntregar_Click(object sender, EventArgs e)
        {
            if (lbCantidadEntregar.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainEntregar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btGenerarCargo_Click(object sender, EventArgs e)
        {
            if (tbCargoCajas.Text != "")
            {
                DataTable dt = new DataTable("CAJAS");
                dt.Columns.Add("NUMERO_CAJA");
                foreach (string linea in tbCargoCajas.Lines.ToList())
                {
                    if (linea != "")
                    {
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1][0] = linea;
                    }
                }

                string[] distinctLines = tbCargoCajas.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Distinct().ToArray();
                tbCargoCajas.Text = string.Join("\r\n", distinctLines);

                using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    string strSQL;
                    DataTable dt2 = new DataTable("INVENTARIO_GENERAL");
                    try
                    {
                        sqliteConnection.Open();

                        strSQL = "SELECT 'PY121' AS CODIGO_CLIENTE, NUMERO_DE_CAJA, NUMERO_DE_CAJA AS 'NUMERO_DE_CAJA2', 'MASTER' AS CODIGO_DIVISION, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS FECHA_DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3,";
                        strSQL = strSQL + " REPLACE(DESCRIPCION_4, '&', ' Y ') AS DESCRIPCION_4 FROM INVENTARIO_GENERAL";
                        SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                        sqliteCmd.ExecuteNonQuery();
                        sqliteDataAdapter.Fill(dt2);
                        sqliteConnection.Close();

                        var result = from c1 in dt.AsEnumerable()
                                     join c2 in dt2.AsEnumerable() on c1.Field<string>("NUMERO_CAJA") equals c2.Field<string>("NUMERO_DE_CAJA")
                                     select new
                                     {
                                         CODIGO_CLIENTE = c2.Field<string>("CODIGO_CLIENTE"),
                                         NUMERO_DE_CAJA = c2.Field<string>("NUMERO_DE_CAJA"),
                                         NUMERO_DE_CAJA2 = c2.Field<string>("NUMERO_DE_CAJA2"),
                                         CODIGO_DIVISION = c2.Field<string>("CODIGO_DIVISION"),
                                         CODIGO_DEPARTAMENTO = c2.Field<string>("CODIGO_DEPARTAMENTO"),
                                         CODIGO_DOCUMENTO = c2.Field<string>("CODIGO_DOCUMENTO"),
                                         FECHA_DESDE = c2.Field<string>("FECHA_DESDE"),
                                         FECHA_HASTA = c2.Field<string>("FECHA_HASTA"),
                                         DESCRIPCION_1 = c2.Field<string>("DESCRIPCION_1"),
                                         DESCRIPCION_2 = c2.Field<string>("DESCRIPCION_2"),
                                         DESCRIPCION_3 = c2.Field<string>("DESCRIPCION_3"),
                                         DESCRIPCION_4 = GlobalFunctions.SinTildes(c2.Field<string>("DESCRIPCION_4"))
                                     };
                        DataTable dt3 = new DataTable("CARGO");
                        dt3 = GlobalFunctions.ToDataTable(result.ToList());
                        GlobalFunctions.ArmarCargoExcel(dt3, Globals.PlantillaCargoIMPath, Globals.CargoPath + "CARGO_IM_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 1, 1, false);
                    }
                    catch (Exception ex)
                    {
                        sqliteConnection.Close();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vacio");
            }
        }
    }
}

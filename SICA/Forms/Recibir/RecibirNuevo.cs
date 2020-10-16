
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SICA.Forms.Recibir
{
    public partial class RecibirNuevo : Form
    {
        public RecibirNuevo()
        {
            InitializeComponent();
        }

        private void btBuscarCargo_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro de Excel 97 - 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();

                string strSQL = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();

                try
                {
                    dt = GlobalFunctions.ConvertExcelToDataTable(ofd.FileName, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                dt.Columns.Add("STATUS");
                dt.Columns.Add("ID REPORTE");
                try
                {
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
                            row["STATUS"] = "OK";
                        }
                    }

                    if (!Conexion.conectar())
                        return;

                    strSQL = "SELECT SOLICITUD_SISGO, ID_REPORTE_VALORADOS, EXPEDIENTE, PAGARE FROM REPORTE_VALORADOS";
                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                    dt2 = Conexion.llenarDataTable();
                    if (dt2 is null)
                        return;

                    strSQL = "SELECT DISTINCT ID_EXPEDIENTE_SIN_DESEMBOLSAR, SOLICITUD_SISGO FROM EXPEDIENTE_SIN_DESEMBOLSAR WHERE DESEMBOLSADO = FALSE";
                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                    dt3 = Conexion.llenarDataTable();
                    if (dt3 is null)
                        return;

                    strSQL = "SELECT DISTINCT ID_PAGARE_SIN_DESEMBOLSAR, SOLICITUD_SISGO FROM PAGARE_SIN_DESEMBOLSAR WHERE DESEMBOLSADO = FALSE";
                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                    dt4 = Conexion.llenarDataTable();
                    if (dt4 is null)
                        return;

                    Conexion.cerrar();



                    var result = from c1 in dt.AsEnumerable()
                                    join c2 in dt2.AsEnumerable() on c1.Field<string>("DESCRIPCION 2") equals c2.Field<string>("SOLICITUD_SISGO") into j
                                    join c3 in dt3.AsEnumerable() on c1.Field<string>("DESCRIPCION 2") equals c3.Field<string>("SOLICITUD_SISGO") into k
                                    join c4 in dt4.AsEnumerable() on c1.Field<string>("DESCRIPCION 2") equals c4.Field<string>("SOLICITUD_SISGO") into m
                                    from p in j.DefaultIfEmpty()
                                    from q in k.DefaultIfEmpty()
                                    from r in m.DefaultIfEmpty()
                                    select new
                                    {
                                        ID_REPORTE = p is null ? 0 : p.Field<Int32>("ID_REPORTE_VALORADOS"),
                                        STATUS = c1.Field<string>("STATUS"),
                                        DESC_1 = c1.Field<string>("DESCRIPCION 1"),
                                        DESC_2 = c1.Field<string>("DESCRIPCION 2"),
                                        DESC_3 = c1.Field<string>("DESCRIPCION 3"),
                                        DESC_4 = c1.Field<string>("DESCRIPCION 4"),
                                        DESEMBOLSADO = p is null ? "NO DESEMBOLSADO" : "DESEMBOLSADO",
                                        CUST_EXPEDIENTE = q is null ? p is null ? "NO CUSTODIADO" : p.Field<string>("EXPEDIENTE") != "0" ? "CUSTODIADO" : "NO CUSTODIADO" : "CUSTODIADO",
                                        EXP_INGRESA = c1.Field<string>("EXPEDIENTE"),
                                        CUST_PAGARE = r is null ? p is null ? "NO CUSTODIADO" : p.Field<string>("PAGARE") != "0" ? "CUSTODIADO" : "NO CUSTODIADO" : "CUSTODIADO",
                                        PAG_INGRESA = c1.Field<string>("PAGARE"),
                                        DESDE = c1.Field<string>("FECHA DESDE"),
                                        HASTA = c1.Field<string>("FECHA HASTA"),
                                        NUMERO_CAJA = c1.Field<string>("NUMERO DE CAJA IRON MOUNTAIN"),
                                        COD_DEP = c1.Field<string>("CODIGO DEPARTAMENTO"),
                                        COD_DOC = c1.Field<string>("CODIGO DOCUMENTO")
                                    };
                    dgv.DataSource = result.ToList();
                    dgv.Columns[0].Visible = false;
                    dgv.ClearSelection();

                    if (valido)
                    {
                        btCargarValido.Visible = true;
                    }

                    LoadingScreen.cerrarLoading();
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                    return;
                }
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL = TRUE AND CUSTODIA = FALSE";
            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
            suf.ShowDialog();
            if (Globals.IdUsernameSelect > 0)
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                LoadingScreen.iniciarLoading();

                string strSQL = "";
                long lastinsertid = 0;
                string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
                Boolean pagare;
                Boolean expediente;
                try
                {
                    if (!Conexion.conectar())
                        return;
                    foreach (DataGridViewRow row in dgv.Rows)
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
                                strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, FECHA, OBSERVACION_RECIBE) VALUES (" + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + row.Cells["ID_REPORTE"].Value.ToString() + ", " + fecha + ", '" + observacion + "')";

                                if (!Conexion.iniciaCommand(strSQL))
                                    return;
                                if (!Conexion.ejecutarQuery())
                                    return;
                            }
                            if (row.Cells["DESC_1"].Value.ToString() == "EXPEDIENTES DE CREDITO" && expediente)
                            {
                                if (!GlobalFunctions.EstadoCustodiaReporte(row.Cells["DESC_2"].Value.ToString(), expediente, pagare))
                                    return;
                            }

                            if (!Conexion.iniciaCommand(RecibirFunctions.ArmarStrNuevoIngreso(row)))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;

                            strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBE) VALUES (" + Conexion.lastIdInsert() + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', TRUE)";
                            
                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;
                        }
                        else if (row.Cells["DESEMBOLSADO"].Value.ToString() == "NO DESEMBOLSADO")
                        {
                            if (expediente)
                            {
                                if (!Conexion.iniciaCommand(RecibirFunctions.ArmarStrNuevoIngreso(row)))
                                    return;
                                if (!Conexion.ejecutarQuery())
                                    return;

                                lastinsertid = Conexion.lastIdInsert();

                                if (row.Cells["CUST_EXPEDIENTE"].Value.ToString() == "NO CUSTODIADO")
                                {
                                    strSQL = "INSERT INTO EXPEDIENTE_SIN_DESEMBOLSAR (SOLICITUD_SISGO, CUSTODIADO, ID_INVENTARIO_GENERAL_FK, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, CONCATENADO) VALUES ('" + row.Cells["DESC_2"].Value.ToString() + "', 'CUSTODIADO', " + lastinsertid + ", '" + row.Cells["DESC_1"].Value.ToString() + "', '" + row.Cells["DESC_2"].Value.ToString() + "', '" + row.Cells["DESC_3"].Value.ToString() + "', '" + row.Cells["DESC_4"].Value.ToString() + "', '" + row.Cells["DESC_1"].Value.ToString() + ";" + row.Cells["DESC_2"].Value.ToString() + ";" + row.Cells["DESC_3"].Value.ToString() + ";" + row.Cells["DESC_4"].Value.ToString() + "')";

                                    if (!Conexion.iniciaCommand(strSQL))
                                        return;
                                    if (!Conexion.ejecutarQuery())
                                        return;

                                }
                                if (pagare && row.Cells["CUST_PAGARE"].Value.ToString() == "NO CUSTODIADO")
                                {
                                    strSQL = "INSERT INTO PAGARE_SIN_DESEMBOLSAR (SOLICITUD_SISGO, CUSTODIADO, ID_INVENTARIO_GENERAL_FK, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, CONCATENADO) VALUES ('" + row.Cells["DESC_2"].Value.ToString() + "', 'CUSTODIADO', " + lastinsertid + ", '" + row.Cells["DESC_1"].Value.ToString() + "', '" + row.Cells["DESC_2"].Value.ToString() + "', '" + row.Cells["DESC_3"].Value.ToString() + "', '" + row.Cells["DESC_4"].Value.ToString() + "', '" + row.Cells["DESC_1"].Value.ToString() + ";" + row.Cells["DESC_2"].Value.ToString() + ";" + row.Cells["DESC_3"].Value.ToString() + ";" + row.Cells["DESC_4"].Value.ToString() + "')";

                                    if (!Conexion.iniciaCommand(strSQL))
                                        return;
                                    if (!Conexion.ejecutarQuery())
                                        return;

                                }
                            }
                            else if (pagare && row.Cells["CUST_PAGARE"].Value.ToString() == "NO CUSTODIADO")
                            {
                                strSQL = "INSERT INTO PAGARE_SIN_DESEMBOLSAR (SOLICITUD_SISGO, CUSTODIADO, ID_INVENTARIO_GENERAL_FK, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, CONCATENADO) VALUES ('" + row.Cells["DESC_2"].Value.ToString() + "', 'CUSTODIADO', " + lastinsertid + ", '" + row.Cells["DESC_1"].Value.ToString() + "', '" + row.Cells["DESC_2"].Value.ToString() + "', '" + row.Cells["DESC_3"].Value.ToString() + "', '" + row.Cells["DESC_4"].Value.ToString() + "', '" + row.Cells["DESC_1"].Value.ToString() + ";" + row.Cells["DESC_2"].Value.ToString() + ";" + row.Cells["DESC_3"].Value.ToString() + ";" + row.Cells["DESC_4"].Value.ToString() + "')";

                                if (!Conexion.iniciaCommand(strSQL))
                                    return;
                                if (!Conexion.ejecutarQuery())
                                    return;
                            }
                        }
                    }
                    Conexion.cerrar();
                    LoadingScreen.cerrarLoading();

                    MessageBox.Show("Proceso Finalizado");
                    dgv.DataSource = null;
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                    return;
                }
            }
        }
    }

}

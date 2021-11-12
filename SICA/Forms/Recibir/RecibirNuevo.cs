
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SICA.Forms.Recibir
{
    public partial class RecibirNuevo : Form
    {
        public RecibirNuevo()
        {
            InitializeComponent();

            btIngresoManual.Visible = Globals.auRecibirManual;
        }

        private void btBuscarCargo_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro de Excel|*.xlsx;*.xls|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();

                if (!File.Exists(ofd.FileName))
                    return;

                FileInfo fi = new FileInfo(ofd.FileName);
                long filesize = fi.Length;

                Microsoft.Office.Interop.Excel.Application xlApp;
                Workbook xlWorkBook;
                Worksheet xlWorkSheet;
                Range range;
                var misValue = Type.Missing;

                // abrir el documento 
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(ofd.FileName, misValue, misValue,
                    misValue, misValue, misValue, misValue, misValue, misValue,
                    misValue, misValue, misValue, misValue, misValue, misValue);

                // seleccion de la hoja de calculo
                // get_item() devuelve object y numera las hojas a partir de 1
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // seleccion rango activo
                range = xlWorkSheet.UsedRange;

                int rows = range.Rows.Count;
                //int cols = range.Columns.Count;
                int cols = 12;

                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("STATUS");
                dt.Columns.Add("NUMERO CAJA");
                dt.Columns.Add("CODIGO DEPARTAMENTO");
                dt.Columns.Add("CODIGO DOCUMENTO");
                dt.Columns.Add("FECHA DESDE");
                dt.Columns.Add("FECHA HASTA");
                dt.Columns.Add("DESCRIPCION 1");
                dt.Columns.Add("DESCRIPCION 2");
                dt.Columns.Add("DESCRIPCION 3");
                dt.Columns.Add("DESCRIPCION 4");
                dt.Columns.Add("DESCRIPCION 5");
                dt.Columns.Add("EXPEDIENTE");
                dt.Columns.Add("PAGARE");
                dt.Columns.Add("ID DEPARTAMENTO");
                dt.Columns.Add("ID DOCUMENTO");

                //Lista Departamento
                string strSQL = "SELECT ID_DEPARTAMENTO, NOMBRE_DEPARTAMENTO FROM LDEPARTAMENTO ORDER BY ORDEN ASC";
                System.Data.DataTable dtdep = new System.Data.DataTable("Departamento");
                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dtdep = Conexion.llenarDataTable();
                if (dtdep is null)
                    return;

                //Lista Documento
                strSQL = "SELECT ID_DOCUMENTO, NOMBRE_DOCUMENTO FROM LDOCUMENTO ORDER BY ORDEN ASC";
                System.Data.DataTable dtdoc = new System.Data.DataTable("Documento");
                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dtdoc = Conexion.llenarDataTable();
                if (dtdoc is null)
                    return;

                Conexion.cerrar();

                for (int row = 1; row <= rows; row++)
                {
                    DataRow newrow = dt.NewRow();
                    for (int col = 1; col <= cols; col++)
                    {
                        // lectura como cadena
                        string cellText = xlWorkSheet.Cells[row, col].Text;
                        //cellText = Convert.ToString(cellText);
                        //cellText = cellText.Replace("'", ""); // Comillas simples no pueden pasar en el Texto

                        if (row == 1)
                        {
                            switch (col)
                            {
                                case 1:
                                    if (!cellText.Equals("NUMERO DE CAJA IRON MOUNTAIN"))
                                    {

                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rNUMERO DE CAJA IRON MOUNTAIN");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 2:
                                    if (!cellText.Equals("CODIGO DEPARTAMENTO"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rCODIGO DEPARTAMENTO");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 3:
                                    if (!cellText.Equals("CODIGO DOCUMENTO"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rCODIGO DOCUMENTO");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 4:
                                    if (!cellText.Equals("FECHA DESDE"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rFECHA DESDE");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 5:
                                    if (!cellText.Equals("FECHA HASTA"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rFECHA HASTA");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 6:
                                    if (!cellText.Equals("DESCRIPCION 1"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 1");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 7:
                                    if (!cellText.Equals("DESCRIPCION 2"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 2");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 8:
                                    if (!cellText.Equals("DESCRIPCION 3"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 3");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 9:
                                    if (!cellText.Equals("DESCRIPCION 4"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 4");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 10:
                                    if (!cellText.Equals("DESCRIPCION 5"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 5");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 11:
                                    if (!cellText.Equals("EXPEDIENTE"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rEXPEDIENTE");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                                case 12:
                                    if (!cellText.Equals("PAGARE"))
                                    {
                                        GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                        MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rPAGARE");
                                        row = 100000;
                                        col = 100000;
                                        valido = false;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            //newrow[0] es para el status
                            newrow[col] = cellText;

                            switch (col)
                            {
                                case 2:
                                    if (cellText == "")
                                    {
                                        valido = false;
                                        newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Departamento Vacío;";
                                    }
                                    else
                                    {
                                        bool existe = false;
                                        foreach(DataRow dtrow in dtdep.Rows)
                                        {
                                            if (dtrow["NOMBRE_DEPARTAMENTO"].ToString() == cellText)
                                            {
                                                existe = true;
                                                newrow[13] = dtrow["ID_DEPARTAMENTO"].ToString();
                                                break;
                                            }
                                        }
                                        if (!existe)
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Departamento No es Valido;";
                                        }
                                    }
                                    break;
                                case 3:
                                    if (cellText == "")
                                    {
                                        valido = false;
                                        newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Documento Vacío;";
                                    }
                                    else
                                    {
                                        bool existe = false;
                                        foreach (DataRow dtrow in dtdoc.Rows)
                                        {
                                            if (dtrow["NOMBRE_DOCUMENTO"].ToString() == cellText)
                                            {
                                                existe = true;
                                                newrow[14] = dtrow["ID_DOCUMENTO"].ToString();
                                                break;
                                            }
                                        }
                                        if (!existe)
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Documento No es Valido;";
                                        }
                                    }
                                    break;
                                case 4:
                                    if (cellText != "" && !GlobalFunctions.IsDate(newrow["FECHA DESDE"].ToString()))
                                    {
                                        valido = false;
                                        newrow["STATUS"] = newrow["STATUS"].ToString() + "Fecha Desde Invalida;";
                                    }
                                    break;
                                case 5:
                                    if (cellText != "" && !GlobalFunctions.IsDate(newrow["FECHA HASTA"].ToString()))
                                    {
                                        valido = false;
                                        newrow["STATUS"] = newrow["STATUS"].ToString() + "Fecha Hasta Invalida;";
                                    }
                                    break;
                                case 6:
                                    if (cellText == "")
                                    {
                                        valido = false;
                                        newrow["STATUS"] = newrow["STATUS"].ToString() + "Descripcion 1 Vacío;";
                                    }
                                    break;
                                case 7:
                                    if (cellText == "")
                                    {
                                        valido = false;
                                        newrow["STATUS"] = newrow["STATUS"].ToString() + "Descripcion 2 Vacío;";
                                    }
                                    break;
                            }

                            if (valido)
                            {
                                newrow["STATUS"] = "OK";
                            }
                        }
                    }

                    if (row > 1)
                        dt.Rows.Add(newrow);
                }

                GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);

                dgv.DataSource = dt;

                //dgv.Columns[0].Visible = false;
                dgv.ClearSelection();

                if (valido)
                {
                    btCargarValido.Visible = true;
                }

                LoadingScreen.cerrarLoading();
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            Globals.strQueryArea = "";
            Globals.strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1 AND ID_AREA_FK != 1";
            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
            suf.ShowDialog();
            if (Globals.IdUsernameSelect > 0)
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                LoadingScreen.iniciarLoading();

                string strSQL = "";
                long lastinsertid;
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                Boolean pagare;

                try
                {
                    if (!Conexion.conectar())
                        return;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["PAGARE"].Value.ToString() == "SI")
                        {
                            pagare = true;
                        }
                        else
                        {
                            pagare = false;
                        }

                        if (!Conexion.iniciaCommand(RecibirFunctions.ArmarStrNuevoIngreso(((DataRowView)row.DataBoundItem).Row)))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;
                        lastinsertid = Conexion.lastIdInsert();

                        strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO, ANULADO) VALUES (" + lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', 1, 0)";

                        if (!Conexion.iniciaCommand(strSQL))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;
                            
                        if (pagare)
                        {
                            if (!RecibirFunctions.RecibirPagare(((DataRowView)row.DataBoundItem).Row, observacion))
                                return;
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

        private void btIngresoManual_Click(object sender, EventArgs e)
        {
            RecibirManual recibirManual = new RecibirManual();
            recibirManual.ShowDialog();
        }

        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to release the object(object:{0})\n" + ex.Message, obj.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


    }

}

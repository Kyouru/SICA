
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
                                    break;
                                case 3:
                                    if (cellText == "")
                                    {
                                        valido = false;
                                        newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Documento Vacío;";
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
            Globals.strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1 AND ID_AREA_FK != 1";
            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
            suf.ShowDialog();
            if (Globals.IdUsernameSelect > 0)
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                LoadingScreen.iniciarLoading();

                string strSQL = "";
                long lastinsertid;
                string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
                Boolean pagare;
                Boolean expediente;

                System.Data.DataTable dt;
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
                        if (row.Cells["EXPEDIENTE"].Value.ToString() == "SI")
                        {
                            expediente = true;
                        }
                        else
                        {
                            expediente = false;
                        }


                        if (expediente)
                        {
                            if (!Conexion.iniciaCommand(RecibirFunctions.ArmarStrNuevoIngreso(row)))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;
                            lastinsertid = Conexion.lastIdInsert();

                            strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO) VALUES (" + lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', 1)";

                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;
                        }
                            
                        if (pagare)
                        {
                            strSQL = "SELECT * FROM PAGARE WHERE SOLICITUD_SISGO = '" + row.Cells["DESCRIPCION 2"].Value.ToString() + "'";
                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;
                            dt = Conexion.llenarDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO) VALUES (";
                                strSQL += dt.Rows[0]["ID_PAGARE"].ToString() + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', 1)";

                                if (!Conexion.iniciaCommand(strSQL))
                                    return;
                                if (!Conexion.ejecutarQuery())
                                    return;

                                strSQL = "UPDATE PAGARE SET USUARIO_POSEE = '" + Globals.Username + "'";
                                strSQL += " WHERE ID_PAGARE = " + dt.Rows[0]["ID_PAGARE"].ToString();

                                if (!Conexion.iniciaCommand(strSQL))
                                    return;
                                if (!Conexion.ejecutarQuery())
                                    return;
                            }
                            else
                            {
                                strSQL = "INSERT INTO PAGARE (SOLICITUD_SISGO, CODIGO_SOCIO, USUARIO_POSEE, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, CONCAT) VALUES (";
                                strSQL += "'" + row.Cells["DESCRIPCION 2"].Value.ToString() + "', '" + row.Cells["DESCRIPCION 3"].Value.ToString().Split('-')[0] + "', '" + Globals.Username + "', '" + row.Cells["DESCRIPCION 3"].Value.ToString() + "', '" + row.Cells["DESCRIPCION 4"].Value.ToString() + "', '" + row.Cells["DESCRIPCION 5"].Value.ToString() + "', '" + row.Cells["DESCRIPCION 2"].Value.ToString() + ";" + row.Cells["DESCRIPCION 3"].Value.ToString() + ";" + row.Cells["DESCRIPCION 4"].Value.ToString() + ";" + row.Cells["DESCRIPCION 5"].Value.ToString() + "')";

                                if (!Conexion.iniciaCommand(strSQL))
                                    return;
                                if (!Conexion.ejecutarQuery())
                                    return;
                                lastinsertid = Conexion.lastIdInsert();
                                
                                strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE) VALUES (";
                                strSQL += lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "')";

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

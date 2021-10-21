using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Pagare
{
    public partial class PagareRecibir : Form
    {
        public PagareRecibir()
        {
            InitializeComponent();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                System.Data.DataTable dt;

                strSQL = @"SELECT ID_PAGARE, SOLICITUD_SISGO, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, FORMAT(FECHA_INICIO, 'dd/MM/yyyy hh:mm:ss') AS FECHA_INICIO
                        FROM PAGARE PA LEFT JOIN PAGARE_HISTORICO PH ON PA.ID_PAGARE = PH.ID_PAGARE_FK WHERE PH.ANULADO = 0 AND PH.RECIBIDO = 0 AND PH.ID_USUARIO_RECIBE_FK = " + Globals.IdUsername;

                strSQL += " ORDER BY SOLICITUD_SISGO DESC";

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
                //dgv.Columns["DESC_1"].Width = 250;

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    GlobalFunctions.AgregarCarrito("0", dgv.SelectedRows[0].Cells["ID_PAGARE"].Value.ToString(), dgv.SelectedRows[0].Cells["SOLICITUD_SISGO"].Value.ToString(), Globals.strPagareRecibir);
                    actualizarCantidad();
                }
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strPagareRecibir) + ")";
        }

        private void btIngresoManual_Click(object sender, EventArgs e)
        {
            PagareManual pagareManual = new PagareManual();
            pagareManual.ShowDialog();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strPagareRecibir;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strPagareRecibir);
            actualizarCantidad();
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {

                    PagareFunctions.RecibirPagareCarrito();
                    actualizarCantidad();

                    //btActualizar_Click(sender, e);
                }
            }
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

                Globals.strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1 AND ID_AREA_FK != 1";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
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
                    int cols = 5;

                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("STATUS");
                    dt.Columns.Add("SOLICITUD SISGO");
                    dt.Columns.Add("CODIGO SOCIO");
                    dt.Columns.Add("NOMBRE");
                    dt.Columns.Add("OBSERVACION ENTREGA");
                    dt.Columns.Add("OBSERVACION RECIBE");

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
                                        if (!cellText.Equals("SOLICITUD SISGO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rSOLICITUD SISGO");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 2:
                                        if (!cellText.Equals("CODIGO SOCIO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rCODIGO SOCIO");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 3:
                                        if (!cellText.Equals("NOMBRE"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rNOMBRE");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 4:
                                        if (!cellText.Equals("OBSERVACION ENTREGA"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rOBSERVACION ENTREGA");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 5:
                                        if (!cellText.Equals("OBSERVACION RECIBE"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rOBSERVACION RECIBE");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                newrow[col] = cellText;

                                switch (col)
                                {
                                    case 1:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Solicitud Sisgo Vacío;";
                                        }
                                        break;
                                    case 2:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Socio Vacío;";
                                        }
                                        break;
                                    case 3:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Nombre Vacío;";
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

                    if (!valido)
                    {
                        MessageBox.Show("Se encontro Solicitud/Socio/Nombre vacío");
                        return;
                    }

                    if (dt.Rows.Count > 0)
                    {
                        if (!Conexion.conectar())
                            return;
                        foreach (DataRow row in dt.Rows)
                        {
                            string strSQL = "INSERT INTO PAGARE (SOLICITUD_SISGO, CODIGO_SOCIO, USUARIO_POSEE, DESCRIPCION_3, DESCRIPCION_4, CONCAT) VALUES (";
                            strSQL += "'" + row["SOLICITUD SISGO"] + "', ";
                            strSQL += "'" + row["CODIGO SOCIO"] + "', ";
                            strSQL += "'" + Globals.Username + "', ";
                            strSQL += "'" + row["CODIGO SOCIO"] + "', ";
                            strSQL += "'" + row["NOMBRE"] + "', ";
                            strSQL += "'" + row["SOLICITUD SISGO"] + ";" + row["CODIGO SOCIO"] + ";" + row["NOMBRE"] + ";" + row["OBSERVACION ENTREGA"] + ";" + row["OBSERVACION RECIBE"] + "')";

                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;

                            int lastinsertid = Conexion.lastIdInsert();
                            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";

                            strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_ENTREGA, OBSERVACION_RECIBE, RECIBIDO) VALUES (";
                            strSQL += lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + row["OBSERVACION ENTREGA"] + "', '" + row["OBSERVACION RECIBE"] + "', 1)";

                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;
                        }
                        Conexion.cerrar();
                    }

                    //dgv.DataSource = dt;
                    //dgv.Columns[0].Visible = false;
                    //dgv.ClearSelection();

                    LoadingScreen.cerrarLoading();
                    MessageBox.Show("Proceso Completado");
                }
            }
        }
    }
}

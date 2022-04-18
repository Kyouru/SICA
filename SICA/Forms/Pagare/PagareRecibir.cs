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
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strPagareRecibir;

        public PagareRecibir()
        {
            InitializeComponent();
            Globals.CarritoSeleccionado = tipo_carrito;
            actualizarCantidad();
        }
        public void actualizarCantidad(int cantidad = -1)
        {
            if (cantidad >= 0)
            {
                cantidadcarrito = cantidad;
            }
            else
            {
                cantidadcarrito = GlobalFunctions.CantidadCarrito(tipo_carrito);
            }
            lbCantidad.Text = "(" + cantidadcarrito + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                System.Data.DataTable dt;

                strSQL = "SELECT ID_PAGARE, SOLICITUD_SISGO, DESCRIPCION_3 AS CODIGO, DESCRIPCION_4 AS NOMBRE, DESCRIPCION_5";
                strSQL += " FROM (PAGARE PA LEFT JOIN (SELECT * FROM USUARIO WHERE ID_AREA_FK <> " + Globals.IdAreaCustodia + ") U ON U.ID_USUARIO = PA.ID_USUARIO_POSEE)";
                strSQL += " LEFT JOIN TMP_CARRITO TC ON TC.ID_AUX_FK = PA.ID_PAGARE";
                strSQL += " WHERE TC.ID_TMP_CARRITO IS NULL";
                strSQL += " AND U.ID_USUARIO IS NOT NULL";
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

                actualizarCantidad();
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
                    btActualizar_Click(sender, e);
                }
            }
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
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog();
                btActualizar_Click(sender, e);
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strPagareRecibir);
            btActualizar_Click(sender, e);
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryArea = "";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    PagareFunctions.RecibirPagareCarrito();
                    btActualizar_Click(sender, e);
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
                Globals.strQueryArea = "AND ID_AREA <> " + Globals.IdAreaCustodia;
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
                            strSQL += "'" + row["SOLICITUD SISGO"] + ";" + row["CODIGO SOCIO"] + ";" + GlobalFunctions.lCadena(row["NOMBRE"].ToString()) + ";" + GlobalFunctions.lCadena(row["OBSERVACION ENTREGA"].ToString()) + ";" + GlobalFunctions.lCadena(row["OBSERVACION RECIBE"].ToString()) + "')";

                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;

                            int lastinsertid = Conexion.lastIdInsert();
                            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                            strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_ENTREGA, OBSERVACION_RECIBE, RECIBIDO) VALUES (";
                            strSQL += lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + GlobalFunctions.lCadena(row["OBSERVACION ENTREGA"].ToString()) + "', '" + GlobalFunctions.lCadena(row["OBSERVACION RECIBE"].ToString()) + "', 1)";

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

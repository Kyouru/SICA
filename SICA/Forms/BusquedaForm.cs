using Microsoft.VisualBasic;
using SICA.Forms;
using SimpleLogger;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace SICA
{
    public partial class BusquedaForm : Form
    {
        public BusquedaForm()
        {
            InitializeComponent();

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void BusquedaForm_Load(object sender, EventArgs e)
        {
            //tbUsuario.Text = Globals.Username;
            //dtpFecha.Value = DateTime.Now;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            string fecha;

            try
            {
                LoadingScreen.iniciarLoading();

                if (cbFecha.Checked)
                    fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                else
                    fecha = "";
                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                strSQL = @"SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, 
                        FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2,
                        DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA
                        FROM INVENTARIO_GENERAL WHERE 1 = 1";

                if (tbBusquedaLibre.Text != "")
                    strSQL += " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                if (tbCaja.Text != "")
                    strSQL += " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
                if (fecha != "")
                    strSQL += " AND FECHA_DESDE <= @fecha_desde AND FECHA_HASTA >= @fecha_hasta";
                if (tbUsuario.Text != "")
                    strSQL += " AND USUARIO_POSEE LIKE '%" + tbUsuario.Text + "%'";
                strSQL += " ORDER BY CODIGO_DOCUMENTO";
                
                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (fecha != "")
                {
                    if (!Conexion.agregarParametroCommand("@fecha_desde", fecha))
                        return;
                    if (!Conexion.agregarParametroCommand("@fecha_hasta", fecha))
                        return;
                }

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgvBusqueda.DataSource = dt;
                dgvBusqueda.Columns[0].Visible = false;
                dgvBusqueda.Columns["DESC_1"].Width = 250;

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgvBusqueda, null);
        }

        private void dgvBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgvBusqueda.SelectedCells.Count == 1)
                {
                    Globals.mostrarSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, U1.NOMBRE_USUARIO AS ENTREGA, U2.NOMBRE_USUARIO AS RECIBE, FORMAT(FECHA_INICIO, 'dd/MM/yyyy hh:mm:ss') AS FECHA_ENTREGA, FORMAT(FECHA_FIN, 'dd/MM/yyyy hh:mm:ss') AS FECHA_RECIBE, NUMERO_CAJA";
                    Globals.mostrarSQL += " FROM ((INVENTARIO_HISTORICO IH LEFT JOIN USUARIO U1 ON IH.ID_USUARIO_ENTREGA_FK = U1.ID_USUARIO) LEFT JOIN USUARIO U2 ON IH.ID_USUARIO_RECIBE_FK = U2.ID_USUARIO) LEFT JOIN INVENTARIO_GENERAL IG ON IG.ID_INVENTARIO_GENERAL = IH.ID_INVENTARIO_GENERAL_FK WHERE IH.ANULADO = 0 AND IH.RECIBIDO = 1 AND IG.ID_INVENTARIO_GENERAL = " + Int32.Parse(dgvBusqueda.Rows[dgvBusqueda.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
                    Globals.mostrarSQL += " ORDER BY FECHA_INICIO";
                    HistoricoForm vHistorico = new HistoricoForm();
                    vHistorico.Show();
                }
            }
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                dtpFecha.Enabled = true;
            }
            else
            {
                dtpFecha.Enabled = false;
            }
        }
    }
}

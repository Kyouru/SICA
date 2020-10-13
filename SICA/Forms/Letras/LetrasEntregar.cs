using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Letras
{
    public partial class LetrasEntregar : Form
    {
        public LetrasEntregar()
        {
            InitializeComponent();
            actualizarCantidad();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();
                DataTable dt = new DataTable("LETRAS");

                strSQL = "SELECT SOCIO, NOMBRE, SOLICITUD, N_LIQ, NUMERO, FORMAT(F_GIRO, 'dd/MM/yyyy') AS F_GIRO, FORMAT(F_VENCIMIENTO, 'dd/MM/yyyy') AS F_VENCIMIENTO, IMPORTE, ACEPTANTE, MD, ESTADO, UBICACION, FECHA_ESTADO, OBSERVACION";
                strSQL = strSQL + " FROM (LETRA L LEFT JOIN TMP_CARRITO TC ON L.ID_LETRA = TC.ID_LETRA_FK) ";
                strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND ESTADO = 'CUSTODIADO'";

                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND CONCATENADO LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY F_VENCIMIENTO";

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
                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void btEntregar_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL = TRUE";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    //LetrasFunctions.EntregarCarrito(Globals.IdUsernameSelect, observacion);
                    actualizarCantidad();
                }
            }
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strRecibirReingreso;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strRecibirReingreso);
                actualizarCantidad();
                btBuscar_Click(sender, e);
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
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strRecibirReingreso) + ")";
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strRecibirReingreso);
            actualizarCantidad();
        }
    }

}

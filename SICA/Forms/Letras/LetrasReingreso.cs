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
    public partial class LetrasReingreso : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strLetrasReingreso;
        public LetrasReingreso()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            LoadingScreen.iniciarLoading();
            strSQL = "SELECT ID_LETRA, SOCIO, NOMBRE, SOLICITUD, N_LIQ, NUMERO, FORMAT(F_GIRO, 'dd/MM/yyyy') AS F_GIRO, FORMAT(F_VENCIMIENTO, 'dd/MM/yyyy') AS F_VENCIMIENTO, IMPORTE, ACEPTANTE, MD, ESTADO";
            strSQL += " FROM LETRA LE LEFT JOIN TMP_CARRITO TC ON LE.ID_LETRA = TC.ID_AUX_FK";
            strSQL += " WHERE ESTADO = 'DEVUELTO' AND TC.ID_TMP_CARRITO IS NULL";
            if (tbBusquedaLibre.Text != "")
            {
                strSQL += " AND CONCATENADO LIKE @busqueda_libre";
            }
            strSQL += " ORDER BY F_GIRO";

            try
            {
                DataTable dt = new DataTable();

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.agregarParametroCommand("@busqueda_libre", "%" + tbBusquedaLibre.Text + "%"))
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

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = tipo_carrito;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            cantidadcarrito = 0;
            actualizarCantidad();
            btBuscar_Click(sender, e);
        }

        private void btRecibir_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL2 = TRUE AND CUSTODIA = FALSE";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observación (opcional):", "Observación", "");
                    LetrasFunctions.ReingresoCarrito(Globals.IdUsernameSelect, observacion);
                    cantidadcarrito = 0;
                    actualizarCantidad();
                }
            }
        }
        private void actualizarCantidad()
        {
            //lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(tipo_carrito) + ")";
            lbCantidad.Text = "(" + cantidadcarrito + ")";
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (!Conexion.conectar())
                    return;
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    string strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_AUX_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (";
                    strSQL += 0 + ", " + row.Cells["ID_LETRA"].Value.ToString() + ", " + Globals.IdUsername + ", '" + tipo_carrito + "', '" + 0 + "')";
                    try
                    {

                        if (!Conexion.iniciaCommand(strSQL))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;

                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                        return;
                    }
                    ++cantidadcarrito;
                }
                Conexion.cerrar();

                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgv.Rows.Remove(row);
                }
                actualizarCantidad();
            }
        }
    }
}

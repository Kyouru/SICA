using SimpleLogger;
using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class SeleccionarUsuarioForm : Form
    {
        public SeleccionarUsuarioForm()
        {
            InitializeComponent();
        }


        private void SeleccionarUsuarioForm_Load(object sender, EventArgs e)
        {
            Globals.IdUsernameSelect = -1;

            string strSQL = "SELECT ID_AREA, NOMBRE_AREA FROM AREA WHERE ANULADO = 0";
            strSQL += " ORDER BY ORDEN";

            try
            {
                DataTable dt = new DataTable("AREA");

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

                cmbArea.DataSource = dt;
                cmbArea.ValueMember = "ID_AREA";
                cmbArea.DisplayMember = "NOMBRE_AREA";
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }

        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex != -1)
            {
                Globals.IdUsernameSelect = Int32.Parse(cmbUsuario.SelectedValue.ToString());
                Globals.UsernameSelect = cmbUsuario.Text;
                string strSQL = "SELECT ID_AREA_FK FROM USUARIO WHERE ID_USUARIO = " + Globals.IdUsernameSelect;
                try
                {
                    if (!Conexion.conectar())
                        return;

                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                    DataTable dt = Conexion.llenarDataTable();
                    if (dt is null)
                        return;
                    Conexion.cerrar();

                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Globals.EntregarConfirmacion = true;
                        Globals.strEntregarEstado = "CUSTODIADO";
                    }
                    else
                    {
                        Globals.EntregarConfirmacion = false;
                        Globals.strEntregarEstado = "PRESTADO";
                    }
                    LoadingScreen.cerrarLoading();
                    this.Close();
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                }
            }
        }

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex >= 0)
            {
                string strSQL = "SELECT ID_USUARIO, USERNAME FROM USUARIO WHERE REAL = 1";
                strSQL += " AND ID_USUARIO <> " + Globals.IdUsername;
                strSQL += " AND ID_AREA_FK = " + cmbArea.SelectedValue + " ORDER BY ORDEN";

                DataTable dt = new DataTable("USUARIO");

                try
                {
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

                    cmbUsuario.DataSource = dt;
                    cmbUsuario.ValueMember = "ID_USUARIO";
                    cmbUsuario.DisplayMember = "USERNAME";
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                }
            }
            else
            {
                cmbUsuario.DataSource = null;
            }
        }
    }
}

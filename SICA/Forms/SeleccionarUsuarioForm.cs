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
            string strSQL = Globals.strQueryUser;
            DataTable dt = new DataTable("USUARIO");

            strSQL = strSQL + " AND ID_USUARIO <> " + Globals.IdUsername + " ORDER BY ORDEN";

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
                LoadingScreen.cerrarLoading();
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
                string strSQL = "SELECT CUSTODIA FROM USUARIO WHERE ID_USUARIO = " + Globals.IdUsernameSelect;
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

                    if (dt.Rows[0][0].ToString() == "True")
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
            else
            {
                DialogResult dialogResult = MessageBox.Show("Usuario no existe.\nDesea Crear?", "Usuario no ingresado", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string strSQL = "INSERT INTO USUARIO (USERNAME, ADMIN, REAL, CUSTODIA, BOVEDA) VALUES ('" + cmbUsuario.Text + "', 0, 1, 0, 0)";
                    try
                    {
                        if (!Conexion.conectar())
                            return;

                        if (!Conexion.iniciaCommand(strSQL))
                            return;

                        if (!Conexion.ejecutarQuery())
                            return;

                        Conexion.cerrar();
                        LoadingScreen.cerrarLoading();

                        Globals.IdUsernameSelect = Conexion.lastIdInsert();
                        Globals.UsernameSelect = cmbUsuario.Text;
                        Globals.EntregarConfirmacion = false;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                    }
                }
            }
        }

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }
    }
}

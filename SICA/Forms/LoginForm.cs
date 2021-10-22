using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SimpleLogger;
using System.IO;
using SICA.Forms;

namespace SICA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            SimpleLog.SetLogFile(".\\Log", "MyLog_");

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Close-Maximize-Minimize
        private void btCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void btMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                entrar();
            }
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            entrar();
        }

        private void entrar()
        {
            if (tbPassword.Text != "" && tbUsername.Text != "")
            {
                Globals.user = tbUsername.Text;
                Globals.pass = tbPassword.Text;

                try
                {
                    DataTable dt = new DataTable("Password");
                    String strSQL = "SELECT ID_USUARIO, NOMBRE_USUARIO, ID_AREA_FK, CAMBIAR_PASSWORD, ACCESO_PERMITIDO FROM USUARIO WHERE NOMBRE_USUARIO = @username AND REAL = 1";

                    if (!Conexion.conectar())
                        return;

                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.agregarParametroCommand("@username", tbUsername.Text))
                        return;

                    if (!Conexion.ejecutarQuery())
                        return;

                    dt = Conexion.llenarDataTable();
                    if (dt is null)
                        return;

                    Conexion.cerrar();


                    Globals.Username = tbUsername.Text;
                    Globals.IdUsername = Int32.Parse(dt.Rows[0]["ID_USUARIO"].ToString());
                    Globals.IdArea = Int32.Parse(dt.Rows[0]["ID_AREA_FK"].ToString());

                    //Cambiar Password
                    if (Boolean.Parse(dt.Rows[0]["CAMBIAR_PASSWORD"].ToString()) == true)
                    {
                        CambiarPasswordForm vCambiar = new CambiarPasswordForm();
                        vCambiar.ShowDialog();
                        SimpleLog.Info(tbUsername.Text + " cambió su contraseña");
                        tbPassword.Text = "";
                        Globals.pass = "";
                        Globals.loginsuccess = 0;
                    }
                    else
                    {
                        //Acceso Permitido
                        if (Boolean.Parse(dt.Rows[0]["ACCESO_PERMITIDO"].ToString()) == true)
                        {
                            SimpleLog.Info(tbUsername.Text + " inicio Session Exitosamente");
                            Globals.loginsuccess = 1;
                            this.Close();
                        }
                        else
                        {
                            Globals.loginsuccess = 0;
                            MessageBox.Show("Acceso no permitido\nContactarse con el Administrador");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Error Login");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Usuario/Contraseña vacio");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
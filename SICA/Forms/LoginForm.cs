using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SimpleLogger;
using System.IO;

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
            if (tbPassword.Text != "")
            {
                DataTable dt = new DataTable("Password");

                String strSQL = "SELECT PASSWORD, ID_USUARIO, CERRAR_SESION FROM USUARIO WHERE USERNAME = @username AND REAL2 = TRUE";

                try
                {
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
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                    return;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario o Contraseña Errada");
                    return;
                }

                if (dt.Rows[0]["CERRAR_SESION"].ToString() == "True")
                {
                    MessageBox.Show("Sesion Cerrada");
                    return;
                }

                if (dt.Rows[0][0].ToString() != "")
                {
                    if (dt.Rows[0][0].ToString() == GlobalFunctions.sha256(tbPassword.Text).ToUpper())
                    {
                        SimpleLog.Info(tbUsername.Text + " inicio Session Exitosamente");
                        this.Hide();
                        Globals.Username = tbUsername.Text;
                        Globals.IdUsername = Int32.Parse(dt.Rows[0][1].ToString());
                        MainForm mf = new MainForm();
                        mf.Closed += (s, args) => this.Close();
                        mf.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Errada");
                        return;
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Usuario no tiene contraseña\nDesea Considerar esta contraseña?", "Usuario no tiene contraseña", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            if (!Conexion.conectar())
                                return;

                            strSQL = "UPDATE USUARIO SET [PASSWORD] = @password WHERE [USERNAME] = @username";
                            if (!Conexion.iniciaCommand(strSQL))
                                return;

                            if (!Conexion.agregarParametroCommand("@password", GlobalFunctions.sha256(tbPassword.Text).ToUpper()))
                                return;
                            if (!Conexion.agregarParametroCommand("@username", tbUsername.Text))
                                return;

                            if (!Conexion.ejecutarQuery())
                                return;

                            Conexion.cerrar();
                            MessageBox.Show("Contraseña actualizada");
                        }
                        catch (Exception ex)
                        {
                            GlobalFunctions.casoError(ex, strSQL);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Contraseña vacia\nEn caso no tenga, escriba una.");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string text = File.ReadAllText(Globals.configPathDB);
            if (text != null)
            {
                Globals.DBPath = text;
            }
            
        }
    }
}
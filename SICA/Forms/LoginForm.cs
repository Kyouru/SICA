using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using System.Data.SQLite;
using Microsoft.VisualBasic;

namespace SICA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

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
                if (tbUsername.Text == "")
                {
                    MessageBox.Show("Username Vacio");
                    return;
                }

                var dt = new DataTable("Password");
                
                using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    reintentar_coneccion: //caso se establesca una nueva contraseña
                    String strSQL = "SELECT PASSWORD, ID_USUARIO FROM USUARIO WHERE USERNAME = '" + tbUsername.Text + "'";
                    SQLiteCommand sqliteCmd;
                    try
                    {
                        sqliteConnection.Open();
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                        using (var sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd))
                        {
                            sqliteDataAdapter.Fill(dt);
                            sqliteConnection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        sqliteConnection.Close();
                        MessageBox.Show(ex.Message + "\n" + strSQL);
                        return;
                    }

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Usuario o Contraseña Errada");
                        return;
                    }

                    if (dt.Rows[0][0].ToString() != "")
                    {
                        if (dt.Rows[0][0].ToString() == GlobalFunctions.sha256(tbPassword.Text).ToUpper())
                        {
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
                                sqliteConnection.Open();
                                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                                sqliteCmd = new SQLiteCommand("UPDATE USUARIO SET PASSWORD = '" + GlobalFunctions.sha256(tbPassword.Text).ToUpper() + "'", sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                                sqliteTransaction.Commit();
                                sqliteConnection.Close();
                                MessageBox.Show("Contraseña actualizada");
                                goto reintentar_coneccion;
                            }
                            catch (Exception ex)
                            {
                                sqliteConnection.Close();
                                MessageBox.Show(ex.Message + "\n" + strSQL);
                            }
                        }
                    }
                }
            }
        }

    }


}

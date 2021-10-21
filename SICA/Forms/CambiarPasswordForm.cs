using SimpleLogger;
using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class CambiarPasswordForm : Form
    {
        public CambiarPasswordForm()
        {
            InitializeComponent();
        }


        private void CambiarPasswordForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btGrabarPassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != "")
            {
                string strSQL = "ALTER LOGIN " + Globals.user + " WITH PASSWORD = '" + tbPassword.Text + "' OLD_PASSWORD = '" + Globals.pass + "'";
                try
                {
                    if (!Conexion.conectar())
                        return;

                    if (!Conexion.iniciaCommand(strSQL))
                        return;

                    if (!Conexion.ejecutarQuery())
                        return;

                    Conexion.cerrar();

                    MessageBox.Show("Nueva Contraseña Establecida");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error estableciendo nueva contraseña");
                    GlobalFunctions.casoError(ex, strSQL);
                }
            }
            else
            {
                MessageBox.Show("Contraseña Vacia");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("USUARIO");
                sqliteConnection.Open();

                strSQL = "SELECT ID_USUARIO, USERNAME FROM USUARIO WHERE REAL = 1 ORDER BY ORDEN";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    cmbUsuario.DataSource = dt;
                    cmbUsuario.ValueMember = "ID_USUARIO";
                    cmbUsuario.DisplayMember = "USERNAME";
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            //cmbUsuario.DataSource
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex != -1)
            {
                Globals.IdUsernameSelect = Int32.Parse(cmbUsuario.SelectedValue.ToString());
                this.Close();
            }
        }
    }
}

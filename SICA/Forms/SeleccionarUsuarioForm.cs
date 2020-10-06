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
            Globals.IdUsernameSelect = -1;
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL = Globals.strQueryUser;
                DataTable dt = new DataTable("USUARIO");
                sqliteConnection.Open();

                strSQL = strSQL + " AND ID_USUARIO <> " + Globals.IdUsername + " ORDER BY ORDEN";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    if (dt.Rows[0]["CUSTODIA"].ToString() == "1")
                    {
                        Globals.strEntregarEstado = "CUSTODIADO";
                    }
                    else
                    {
                        Globals.strEntregarEstado = "PRESTADO";
                    }

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
            
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex != -1)
            {
                Globals.IdUsernameSelect = Int32.Parse(cmbUsuario.SelectedValue.ToString());
                Globals.UsernameSelect = cmbUsuario.Text;
                this.Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Usuario no existe.\nDesea Crear?", "Usuario no ingresado", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        sqliteConnection.Open();

                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                        string strSQL = "INSERT INTO USUARIO (USERNAME, ADMIN, REAL, CUSTODIA, BOVEDA) VALUES ('" + cmbUsuario.Text + "', 0, 1, 0, 0)";
                        SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        Globals.IdUsernameSelect = Int32.Parse(sqliteConnection.LastInsertRowId.ToString());
                        Globals.UsernameSelect = cmbUsuario.Text;

                        sqliteTransaction.Commit();
                        sqliteConnection.Close();

                        this.Close();
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

using SimpleLogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class LoadingScreen : Form
    {
        public static Thread t;
        public static LoadingScreen screenLoading;

        public LoadingScreen()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            pbLoading.Image = SICA.Properties.Resources.loading1;
            pbLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Height = this.Height - 6;
            this.Width = this.Width - 3;
        }

        private void LoadingScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public static void iniciarLoading()
        {
            try
            {
                if (t != null)
                    t.Abort();
                t = new Thread(new ThreadStart(StartLoadingScreen));
                t.IsBackground = true;
                t.Start();
            }
            catch (Exception ex)
            {
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }

        public static void StartLoadingScreen()
        {
            screenLoading = new LoadingScreen();
            Application.Run(screenLoading);
        }

        public static void cerrarLoading()
        {
            if (screenLoading.InvokeRequired)
            {
                screenLoading.Invoke(new MethodInvoker(cerrarLoading));
            }
            else
            {
                screenLoading.Close();
            }
        }
    }
}

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

        private void pbLoading_Click(object sender, EventArgs e)
        {

        }
    }
}

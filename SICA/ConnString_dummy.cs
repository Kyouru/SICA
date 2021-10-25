using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    class ConnString
    {
        public string sqlserversica = "SQLSERVER CONNECTION STRING";
        public string GetString(string _name)
        {
            try
            {
                return (string)typeof(ConnString).GetField(_name).GetValue(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}

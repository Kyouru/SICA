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
        //public string sqlservercasa = "Data Source=DESKTOP-LC8AVUS;Initial Catalog=master;Persist Security Info=True;User ID=KyouruAdmin;Password=Micaela";
        //public string sqlservercasa = "Data Source=localhost;Initial Catalog=master;Persist Security Info=True;User ID=KyouruAdmin;Password=Bigotes";
        //public string sqlservercp = "Data Source=192.168.9.84,1433;Initial Catalog=SICA;User ID=@USER@;Password=@PASS@";
        //public string sqlserversica = "Data Source=192.168.9.84,1433;Initial Catalog=SICA;User ID=@USER@;Password=@PASS@";
        //public string sqlserversica = "Data Source=192.168.18.101,1433;Initial Catalog=SICA;User ID=@USER@;Password=@PASS@";
        //public string sqlserversica = "Data Source=10.81.234.45,1433;Initial Catalog=SICA;User ID=@USER@;Password=@PASS@";
        public string sqlserversica = "Data Source=DESKTOP-R32200G;Initial Catalog=SICA;User ID=@USER@;Password=@PASS@";
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

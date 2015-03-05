using System;
using System.Globalization;
using System.Windows.Forms;
using SQLt.Properties;

namespace SQLt
{
    public partial class ConnnectionOracle : Form, IConnectionStringDialog
    {
        public ConnnectionOracle()
        {
            InitializeComponent();
        }

        private string Database { get; set; }

        private string Password { get; set; }

        private Int32 Port { get; set; }

        private string Server { get; set; }

        private string SID { get; set; }

        private string User { get; set; }

        public String ConnectionString()
        {
            String ConnectionStr;
            /*
             * Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=ls)(PORT=1521)))(CONNECT_DATA=(SID=ora92ls)(SERVER=DEDICATED)));User Id=lafisadmin;Password=a;
             */

            ConnectionStr = String.Format(CultureInfo.InvariantCulture,
                Resources.ConnectionFormatOracle,
                Server, Port, SID, User, Password /*DATABASE,*/
                );
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey(Resources.RegKeyOptionsOracle);
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(Resources.RegKeyOptionsOracle);
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue(Resources.OracleOptionServer, Resources.OracleDefaultServer).ToString();
                User = SearchKey.GetValue(Resources.OracleOptionUser, Resources.OracleDefaultUser).ToString();
                Password = SearchKey.GetValue(Resources.OracleOptionPassword, Resources.OracleDefaultPassword).ToString();
                Database = SearchKey.GetValue(Resources.OracleOptionDb, Resources.OracleDefaultDatabase).ToString();
                SID = SearchKey.GetValue(Resources.OracleOptionSID, Resources.OracleDefaultSid).ToString();
                Port = Int32.Parse(SearchKey.GetValue(Resources.OracleOptionPort, Resources.OracleDefaultPort).ToString(), CultureInfo.InvariantCulture);
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(Resources.RegKeyOptionsOracle, true);
            if (SearchKey != null)
            {
                SearchKey.SetValue(Resources.OracleOptionServer, Server);
                SearchKey.SetValue(Resources.OracleOptionUser, User);
                SearchKey.SetValue(Resources.OracleOptionPassword, Password);
                SearchKey.SetValue(Resources.OracleOptionDb, Database);
                SearchKey.SetValue(Resources.OracleOptionSID, SID);
                SearchKey.SetValue(Resources.OracleOptionPort, Port);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnActivated(object sender, EventArgs e)
        {
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadOptions();
            txtDatabase.Text = Database;
            txtInstance.Text = SID;
            txtPass.Text = Password;
            txtServer.Text = Server;
            txtPort.Text = Port.ToString(CultureInfo.InvariantCulture);
            txtUser.Text = User;
        }

        private void OnOK(object sender, EventArgs e)
        {
            Server = txtServer.Text;
            User = txtUser.Text;
            Password = txtPass.Text;
            SID = txtInstance.Text;
            Database = txtDatabase.Text;
            Port = Convert.ToInt32(txtPort.Text, CultureInfo.InvariantCulture);
            this.Close();
        }

        //
    }
}
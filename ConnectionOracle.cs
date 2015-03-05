using System;
using System.Globalization;
using System.Windows.Forms;

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
                "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SID={2})(SERVER=DEDICATED)));User Id={3};Password={4};",
                Server, Port, SID, User, Password /*DATABASE,*/
                );
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey("Options\\Oracle");
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey("Options\\Oracle");
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue("Server", "localhost").ToString();
                User = SearchKey.GetValue("User", "lafisadmin").ToString();
                Password = SearchKey.GetValue("Password", "a").ToString();
                Database = SearchKey.GetValue("DATABASE", "lafis").ToString();
                SID = SearchKey.GetValue("SID", "orcl").ToString();
                Port = Int32.Parse(SearchKey.GetValue("Port", "1521").ToString(), CultureInfo.InvariantCulture);
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey("Options\\Oracle", true);
            if (SearchKey != null)
            {
                SearchKey.SetValue("Server", Server);
                SearchKey.SetValue("User", User);
                SearchKey.SetValue("Password", Password);
                SearchKey.SetValue("DATABASE", Database);
                SearchKey.SetValue("SID", SID);
                SearchKey.SetValue("Port", Port);
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
using System;
using System.Globalization;
using System.Windows.Forms;
using SQLt.Properties;

namespace SQLt
{
    public partial class ConnectionSQL : Form, IConnectionStringDialog
    {
        public ConnectionSQL()
        {
            InitializeComponent();
        }

        private string Instance { get; set; }

        private string Password { get; set; }

        private string Server { get; set; }

        private string SQL_REGKEY = Resources.RegKeyOptionsSQL;

        private string User { get; set; }
        public String ConnectionString()
        {
            String ConnectionStr;
            ConnectionStr = String.Format(CultureInfo.CurrentCulture, Resources.SqlConnectionFormat, Server, Instance, User, Password);
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey(SQL_REGKEY);
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(SQL_REGKEY);
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue(Resources.SqlOptionServer, Resources.SqlDefaultServer).ToString();
                User = SearchKey.GetValue(Resources.SqlOptionUser, Resources.SqlDefaultUser).ToString();
                Password = SearchKey.GetValue(Resources.SqlOptionPassword, Resources.SqlDefaultPassword).ToString();
                Instance = SearchKey.GetValue(Resources.SqlOptionInstance, Resources.SqlDefaultInstance).ToString();
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(SQL_REGKEY, true);
            if (SearchKey != null)
            {
                SearchKey.SetValue(Resources.SqlOptionServer, Server);
                SearchKey.SetValue(Resources.SqlOptionUser, User);
                SearchKey.SetValue(Resources.SqlOptionPassword, Password);
                SearchKey.SetValue(Resources.SqlOptionInstance, Instance);
            }
        }
        private void OnActivated(object sender, EventArgs e)
        {
        }

        private void OnClose(object sender, EventArgs e)
        {
            Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadOptions();
            txtInstance.Text = Instance;
            txtUser.Text = User;
            txtPass.Text = Password;
            txtServer.Text = Server;
        }

        private void OnOK(object sender, EventArgs e)
        {
            Server = txtServer.Text;
            User = txtUser.Text;
            Password = txtPass.Text;
            Instance = txtInstance.Text;
            SaveOptions();
            Close();
        }
    }
}
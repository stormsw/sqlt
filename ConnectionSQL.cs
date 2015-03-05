using System;
using System.Globalization;
using System.Windows.Forms;

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

        private string User { get; set; }
        public String ConnectionString()
        {
            String ConnectionStr;
            ConnectionStr = String.Format(CultureInfo.CurrentCulture, "Provider=sqloledb;Data Source={0};Initial Catalog={1};User Id={2};Password={3};", Server, Instance, User, Password);
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey("Options\\SQL");
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey("Options\\SQL");
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue("Server", "").ToString();
                User = SearchKey.GetValue("User", "lafisadmin").ToString();
                Password = SearchKey.GetValue("Password", "a").ToString();
                Instance = SearchKey.GetValue("Instance", "lafis").ToString();
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey("Options\\SQL", true);
            if (SearchKey != null)
            {
                SearchKey.SetValue("Server", Server);
                SearchKey.SetValue("User", User);
                SearchKey.SetValue("Password", Password);
                SearchKey.SetValue("Instance", Instance);
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
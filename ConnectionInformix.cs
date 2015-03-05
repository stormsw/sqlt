using SQLt.Properties;

namespace SQLt
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class ConnectionInformix : Form, IConnectionStringDialog
    {
        private string OPTIONS_INFORMIX = Resources.RegKeyOptionsInformix;

        public ConnectionInformix()
        {
            InitializeComponent();
        }

        private string Instance { get; set; }

        private string Password { get; set; }

        private string Server { get; set; }

        private string User { get; set; }

        public string ConnectionString()
        {
            string
            ConnectionStr = String.Format(CultureInfo.InvariantCulture,
                Resources.InformixConnectionFormat, Server, Instance, User, Password);
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey(OPTIONS_INFORMIX);
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_INFORMIX);
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue(Resources.InformixOptionServer, Resources.InformixDefaultServer).ToString();
                User = SearchKey.GetValue(Resources.InformixOptionUser, Resources.InformixDefaultUser).ToString();
                Password = SearchKey.GetValue(Resources.InformixOptionPassword, Resources.InformixDefaultPassword).ToString();
                Instance = SearchKey.GetValue(Resources.InformixOptionInstance, Resources.InformixDefaultInstance).ToString();
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_INFORMIX, true);
            if (SearchKey != null)
            {
                SearchKey.SetValue(Resources.InformixOptionServer, Server);
                SearchKey.SetValue(Resources.InformixOptionUser, User);
                SearchKey.SetValue(Resources.InformixOptionPassword, Password);
                SearchKey.SetValue(Resources.InformixOptionInstance, Instance);
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadOptions();
            txtServer.Text = Server;
            txtUser.Text = User;
            txtPass.Text = Password;
            txtInstance.Text = Instance;
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
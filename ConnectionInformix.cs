namespace SQLt
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class ConnectionInformix : Form, IConnectionStringDialog
    {
        private const string OPTIONS_INFORMIX = "Options\\Informix";

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
                "Provider=Ifxoledbc.2;User ID={2};password={3};Data Source={1}@{0};Persist Security Info=true", Server, Instance, User, Password);
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey(OPTIONS_INFORMIX);
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_INFORMIX);
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue("Server", "").ToString();
                User = SearchKey.GetValue("User", "informix").ToString();
                Password = SearchKey.GetValue("Password", "informix").ToString();
                Instance = SearchKey.GetValue("Instance", "lafis").ToString();
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_INFORMIX, true);
            if (SearchKey != null)
            {
                SearchKey.SetValue("Server", Server);
                SearchKey.SetValue("User", User);
                SearchKey.SetValue("Password", Password);
                SearchKey.SetValue("Instance", Instance);
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
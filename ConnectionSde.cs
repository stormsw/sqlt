using System;
using System.Globalization;
using System.Windows.Forms;

namespace SQLt
{
    public partial class ConnectionSde : Form, IConnectionStringDialog
    {
        public ConnectionSde()
        {
            InitializeComponent();
        }

        private string Instance { get; set; }

        private string Password { get; set; }

        private string Server { get; set; }

        private Int32 Service { get; set; }

        private string User { get; set; }
        public String ConnectionString()
        {
            String ConnectionStr;
            ConnectionStr = String.Format(CultureInfo.CurrentCulture, "Provider=GAFOLEDB.ArcSDE.1;Location={0};Data Source={1}@{2};User Id={3};Password={4};", Server, Instance, Service, User, Password);
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey("Options\\SDE");

            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey("Options\\SDE");
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue("Server", "localhost").ToString();
                User = SearchKey.GetValue("User", "sde").ToString();
                Password = SearchKey.GetValue("Password", "sde").ToString();
                Instance = SearchKey.GetValue("Instance", "lafis").ToString();
                Service = Int32.Parse(SearchKey.GetValue("Service", 5152).ToString(), CultureInfo.CurrentCulture);
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey("Options\\SDE", true);
            if (SearchKey != null)
            {
                SearchKey.SetValue("Server", Server);
                SearchKey.SetValue("User", User);
                SearchKey.SetValue("Password", Password);
                SearchKey.SetValue("Instance", Instance);
                SearchKey.SetValue("Service", Service);
            }
        }
        private void OnClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadOptions();
            txtServer.Text = Server;
            txtUser.Text = User;
            txtPass.Text = Password;
            txtInstance.Text = Instance;
            txtService.Text = Service.ToString(CultureInfo.CurrentCulture);
        }

        private void OnOK(object sender, EventArgs e)
        {
            Server = txtServer.Text;
            User = txtUser.Text;
            Password = txtPass.Text;
            Instance = txtInstance.Text;
            Service = Convert.ToInt32(txtService.Text, CultureInfo.CurrentCulture);

            SaveOptions();

            this.Close();
        }
    }
}
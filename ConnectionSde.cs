using System;
using System.Globalization;
using System.Windows.Forms;
using SQLt.Properties;

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

        private string SDE_REGKEY = Resources.RegKeyOptionsSDE;

        private string User { get; set; }
        public String ConnectionString()
        {
            String ConnectionStr;
            ConnectionStr = String.Format(CultureInfo.CurrentCulture, Resources.ConnectionFormatSDE, Server, Instance, Service, User, Password);
            return ConnectionStr;
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey(SDE_REGKEY);

            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(SDE_REGKEY);
            if (SearchKey != null)
            {
                Server = SearchKey.GetValue(Resources.SdeOptionServer, Resources.SdeDefaultServer).ToString();
                User = SearchKey.GetValue(Resources.SdeOptionUser, Resources.SdeDefaultUser).ToString();
                Password = SearchKey.GetValue(Resources.SdeOptionPassword, Resources.SdeDefaultPassword).ToString();
                Instance = SearchKey.GetValue(Resources.SdeOptionInstance, Resources.SdeDefaultInstance).ToString();
                Service = Int32.Parse(SearchKey.GetValue(Resources.SdeOptionService, Resources.SdeDefaultService).ToString(), CultureInfo.CurrentCulture);
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(SDE_REGKEY, true);
            if (SearchKey != null)
            {
                SearchKey.SetValue(Resources.SdeOptionServer, Server);
                SearchKey.SetValue(Resources.SdeOptionUser, User);
                SearchKey.SetValue(Resources.SdeOptionPassword, Password);
                SearchKey.SetValue(Resources.SdeOptionInstance, Instance);
                SearchKey.SetValue(Resources.SdeOptionService, Service);
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
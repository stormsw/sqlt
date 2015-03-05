namespace SQLt
{
    using SQLt.Properties;
    using System;
    using System.Windows.Forms;

    public partial class ConnectionODBC : Form, IConnectionStringDialog
    {
        private string ODBC_DSN = Resources.ODBCDataSourcesRegKey;
        private string OPTIONS_ODBC = Resources.RegKeyOptionsODBC;
        private bool isFormLoaded = false;

        public ConnectionODBC()
        {
            InitializeComponent();
        }

        private string DSN { get; set; }

        private string PID { get; set; }

        private string UID { get; set; }

        public string ConnectionString()
        {
            return string.Format(Resources.ConnectionFormatODBC, DSN, UID, PID);
        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey(OPTIONS_ODBC);
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_ODBC);
            if (SearchKey != null)
            {
                DSN = SearchKey.GetValue(Resources.OdbcOptionDSN, Resources.OdbcDefaultDSN).ToString();
                UID = SearchKey.GetValue(Resources.OdbcOptionUID, Resources.OdbcDefaultUID).ToString();
                PID = SearchKey.GetValue(Resources.OdbcOptionPID, Resources.OdbcDefaultPID).ToString();
            }
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_ODBC, true);
            if (SearchKey != null)
            {
                SearchKey.SetValue(Resources.OdbcOptionDSN, DSN);
                SearchKey.SetValue(Resources.OdbcOptionUID, UID);
                SearchKey.SetValue(Resources.OdbcOptionPID, PID);
            }
        }

        private void OnActivated(object sender, EventArgs e)
        {
            int n = comboDSNlist.Items.Count;
            for (int i = 0; i < n; i++)
            {
                if (comboDSNlist.Items[i].ToString() == DSN)
                {
                    comboDSNlist.SelectedIndex = i;
                }
            }
            if (UID.Length > 0) txtUser.Text = UID;
            if (PID.Length > 0) txtPassword.Text = PID;
        }

        private void OnDSNChanged(object sender, EventArgs e)
        {
            if (isFormLoaded)
            {
                DSN = comboDSNlist.SelectedItem != null ? comboDSNlist.SelectedItem.ToString() : string.Empty;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //get system DSN
            Microsoft.Win32.RegistryKey SearchKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ODBC_DSN);
            if (SearchKey != null)
            {
                foreach (string DsnName in SearchKey.GetValueNames())
                {
                    comboDSNlist.Items.Add(DsnName);
                }
            }
            //get User DSN
            SearchKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ODBC_DSN);
            if (SearchKey != null)
            {
                foreach (string DsnName in SearchKey.GetValueNames())
                {
                    comboDSNlist.Items.Add(DsnName);
                }
            }

            LoadOptions();
            isFormLoaded = true;
        }

        private void OnOK(object sender, EventArgs e)
        {
            DSN = comboDSNlist.SelectedItem != null ? comboDSNlist.SelectedItem.ToString() : string.Empty;
            UID = txtUser.Text;
            PID = txtPassword.Text;

            SaveOptions();

            if (DSN.Length > 0)
                this.Close();
        }
    }
}
namespace SQLt
{
    using System;
    using System.Windows.Forms;

    public partial class ConnectionODBC : Form, IConnectionStringDialog
    {
        private bool isFormLoaded = false;
        private const string ODBC_DSN = "SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources";
        private const string OPTIONS_ODBC = "Options\\ODBC";

        private string UID { get; set; }
        private string PID { get; set; }
        private string DSN { get; set; }

        public ConnectionODBC()
        {
            InitializeComponent();
        }

        public void SaveOptions()
        {
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_ODBC, true);
            if (SearchKey != null)
            {
                SearchKey.SetValue("DSN", DSN);
                SearchKey.SetValue("UID", UID);
                SearchKey.SetValue("PID", PID);
            }

        }

        public void LoadOptions()
        {
            Application.UserAppDataRegistry.CreateSubKey(OPTIONS_ODBC);
            Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_ODBC);
            if (SearchKey != null)
            {
                DSN = SearchKey.GetValue("DSN", "").ToString();
                UID = SearchKey.GetValue("UID", "informix").ToString();
                PID = SearchKey.GetValue("PID", "informix").ToString();
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

        public string ConnectionString()
        {
            //string result = "Dsn=" + DSN+";Uid="+UID+";Pwd="+PID+";";            
            return string.Format("Dsn={0};Uid={1};Pwd={2};", DSN, UID, PID);
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

        private void OnDSNChanged(object sender, EventArgs e)
        {
            if (isFormLoaded)
            {
                DSN = comboDSNlist.SelectedItem != null ? comboDSNlist.SelectedItem.ToString() : string.Empty;
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
    }
}

namespace SQLt
{
    using DataModel;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ConnectionInformix : Form, IConnectionStringDialog
    {
        private const string OPTIONS_INFORMIX = "Options\\Informix";
        private InformixConnectionAttributes attributes;
        private Control[] controls;// = new Control[] { txtServer, txtUser, txtPass, txtInstance };
        private string[] attribNames;// = new string[] { "Server", "User", "Password", "Instance" };

        public ConnectionInformix()
        {
            InitializeComponent();
            attributes = new InformixConnectionAttributes();
            controls = new Control[] { txtServer, txtUser, txtPass, txtInstance };
            attribNames = new string[] { "Server", "User", "Password", "Instance" };
        }

        public void SaveOptions()
        {
            try
            {
                Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_INFORMIX, true);
                ConnectionFormsUtils.BaseSaveOptions(SearchKey, attributes);
            }
            catch (SaveOptionsException ex)
            {
                //todo: handle
            }
        }

        public void LoadOptions()
        {
            attributes = new InformixConnectionAttributes()
            {
                Server = string.Empty,
                User = "informix",
                Password = "informix",
                Instance = "lafis"
            };

            try
            {
                Application.UserAppDataRegistry.CreateSubKey(OPTIONS_INFORMIX);
                Microsoft.Win32.RegistryKey SearchKey = Application.UserAppDataRegistry.OpenSubKey(OPTIONS_INFORMIX);
                ConnectionFormsUtils.BaseLoadOptions<InformixConnectionAttributes>(SearchKey, attributes);
            }
            catch (LoadOptionsException ex)
            {
                var log = ex.Message;
            }
        }

        public string ConnectionString()
        {
            string ConnectionStr = String.Format(CultureInfo.InvariantCulture,
                "Provider=Ifxoledbc.2;User ID={2};password={3};Data Source={1}@{0};Persist Security Info=true",
                attributes.Server,
                attributes.Instance,
                attributes.User,
                attributes.Password);
            return ConnectionStr;
        }

        private void OnClose(object sender, EventArgs e)
        {
            Close();
        }

        private void OnOK(object sender, EventArgs e)
        {
            SaveOptions();
            Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadOptions();
            controls.Zip(attribNames,
                (controll, attrName) =>
                        new { First = controll, Second = attrName }
                    ).ToList().ForEach(
                        item => ConnectionFormsUtils.
                            makeBind(item.First, attributes, item.Second));
        }
    }
}
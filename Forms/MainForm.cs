namespace SQLt
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private OleDbConnection OleDbConnection = new OleDbConnection();
        private OdbcConnection OdbcConnection = new OdbcConnection();

        private bool IsODBC { get; set; }

        private String connectionString = "Click settings.";
        private ArrayList tblArray;
        private const string COLUMN_NAME = "COLUMN_NAME";
        private const string DATABASE = "DATABASE";
        private const string ROOT_DB = "RootDB";
        private const string TABLES = "Tables";
        private const string FIELDS = "Fields";
        private const string TABLE = "TABLE";
        private ArrayList fldArray;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateUI()
        {
            //textBox1.Text = connectionString;
            tlConStr.Text = connectionString;
        }

        private void OnSDE(object sender, EventArgs e)
        {
            using (ConnectionSde SdeParams = new ConnectionSde())
            {
                SdeParams.ShowDialog(this);
                connectionString = SdeParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private void OnQuery(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Update();
            String strSQL = txtHistory.Text;
            lstHistory.Items.Insert(0, strSQL);

            try
            {
                using (DataTable m_DataTable = new DataTable() { Locale = CultureInfo.CurrentCulture })
                {
                    if (IsODBC)
                    {
                        using (OdbcDataAdapter dbc = new OdbcDataAdapter(strSQL, OdbcConnection))
                        {
                            dbc.Fill(m_DataTable);
                        }
                    }
                    else
                    {
                        using (OleDbDataAdapter dba = new OleDbDataAdapter(strSQL, OleDbConnection))
                        {
                            dba.Fill(m_DataTable);
                        }
                    }

                    using (BindingSource bSource = new BindingSource())
                    {
                        bSource.DataSource = m_DataTable;
                        dataGridView1.DataSource = bSource;
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSQL(object sender, EventArgs e)
        {
            using (ConnectionSQL SQLParams = new ConnectionSQL())
            {
                SQLParams.ShowDialog(this);
                connectionString = SQLParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        private void GetTables(OleDbConnection connection)
        {
            try
            {
                //connection.Open();
                using (DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new Object[] { null, null, null, TABLE }))
                {
                    tblArray = new ArrayList();
                    foreach (DataRow datRow in schemaTable.Rows)
                    {
                        tblArray.Add(datRow["TABLE_NAME"].ToString());
                    }
                    //connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetFields(OleDbConnection cnn, string tabNode)
        {
            string tabName;
            try
            {
                tabName = tabNode;
                //connection.Open();
                using (DataTable schemaTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,
                    new Object[] { null, null, tabName }))
                {
                    fldArray = new ArrayList();
                    foreach (DataRow datRow in schemaTable.Rows)
                    {
                        fldArray.Add(datRow[COLUMN_NAME].ToString());
                    }
                    //connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTreeView(OleDbConnection datCon)
        {
            ObjectView.Nodes.Clear();
            // set root node of TreeView.
            ObjectView.Nodes.Add(DATABASE);
            ObjectView.Nodes[0].ImageIndex = 0;
            ObjectView.Nodes[0].SelectedImageIndex = 1;
            ObjectView.Nodes[0].Tag = ROOT_DB;

            if (ConnectionState.Open == datCon.State)
            {
                GetTables(datCon);

                // add table node
                for (int i = 0; i < tblArray.Count; i++)
                {
                    ObjectView.Nodes[0].Nodes.Add(tblArray[i].ToString());
                    ObjectView.Nodes[0].Nodes[i].Tag = TABLES;
                    ObjectView.Nodes[0].Nodes[i].ImageIndex = 2;
                    ObjectView.Nodes[0].Nodes[i].SelectedImageIndex = 2;
                }

                // add field node
                for (int i = 0; i < tblArray.Count; i++)
                {
                    GetFields(datCon, tblArray[i].ToString());
                    for (int j = 0; j < fldArray.Count; j++)
                    {
                        ObjectView.Nodes[0].Nodes[i].Nodes.Add(fldArray[j].ToString());
                        ObjectView.Nodes[0].Nodes[i].Nodes[j].Tag = FIELDS;
                        ObjectView.Nodes[0].Nodes[i].Nodes[j].ImageIndex = 3;
                        ObjectView.Nodes[0].Nodes[i].Nodes[j].SelectedImageIndex = 3;
                    }
                }
            }
        }

        private void OnConnect(object sender, EventArgs e)
        {
            connectionString = tlConStr.Text.ToString();
            if (connectionString.StartsWith("Provider", StringComparison.OrdinalIgnoreCase))
            {
                //User can mix....
                IsODBC = false;
                connectOle();
            }
            else
            {
                IsODBC = true;
                connectOdbc();
            }

            btnQuery.Enabled = (IsOleConnected || IsOdbcConnected);
            tlConStr.Enabled = !btnQuery.Enabled;
        }

        private void connectOle()
        {
            if (!IsOleConnected && connectionString.Length > 10)
            {
                OleDbConnection.ConnectionString = connectionString;
                try
                {
                    OleDbConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (IsOleConnected)
                {
                    btnConnect.Text = "Disconnect [OLEDB]";
                    dataGridView1.DataSource = OleDbConnection.GetSchema();
                    FillTreeView(OleDbConnection);
                }
            }
            else
            {
                OleDbConnection.Close();
                btnConnect.Text = "Connect";
                dataGridView1.DataSource = null;
            }
        }

        private void connectOdbc()
        {
            if (!IsOdbcConnected && connectionString.Length > 0)
            {
                OdbcConnection.ConnectionString = connectionString;
                try
                {
                    OdbcConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (IsOdbcConnected)
                {
                    btnConnect.Text = "Disconnect [ODBC]";
                    dataGridView1.DataSource = OdbcConnection.GetSchema();
                }
            }
            else
            {
                OdbcConnection.Close();
                btnConnect.Text = "Connect";
                dataGridView1.DataSource = null;
            }
        }

        private bool IsOdbcConnected
        {
            get
            {
                return OdbcConnection.State == ConnectionState.Open;
            }
        }

        private bool IsOleConnected
        {
            get
            {
                return OleDbConnection.State == ConnectionState.Open;
            }
        }

        private void OnInformix(object sender, EventArgs e)
        {
            using (ConnectionInformix InformixParams = new ConnectionInformix())
            {
                InformixParams.ShowDialog();
                connectionString = InformixParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        private void OnOracle(object sender, EventArgs e)
        {
            using (ConnnectionOracle OraParams = new ConnnectionOracle())
            {
                OraParams.ShowDialog();
                connectionString = OraParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        private void lstHistory_DoubleClick(object sender, EventArgs e)
        {
            txtHistory.Text = lstHistory.SelectedItem.ToString();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            lstHistory.Items.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lstHistory.SelectedItem != null)
                txtHistory.Text += ";\r\n" + lstHistory.SelectedItem.ToString();
        }

        private void SaveSQL(object sender, EventArgs e)
        {
            using (SaveFileDialog fileSaveDialog = new SaveFileDialog())
            {
                fileSaveDialog.AddExtension = true;
                fileSaveDialog.CheckPathExists = true;
                fileSaveDialog.DefaultExt = ".sql";
                fileSaveDialog.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                fileSaveDialog.FilterIndex = 1;
                if (fileSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    String FileName = fileSaveDialog.FileName;
                    try
                    {
                        using (StreamWriter sf = new StreamWriter(FileName))
                        {
                            sf.Write(txtHistory.Text);
                            sf.Flush();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void LoadSQL(object sender, EventArgs e)
        {
            using (OpenFileDialog fileOpenDialog = new OpenFileDialog())
            {
                fileOpenDialog.CheckFileExists = true;
                fileOpenDialog.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                fileOpenDialog.FilterIndex = 1;
                if (fileOpenDialog.ShowDialog() == DialogResult.OK)
                {
                    String FileName = fileOpenDialog.FileName;
                    try
                    {
                        using (StreamReader sf = new StreamReader(FileName))
                        {
                            txtHistory.Text = sf.ReadToEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void SaveHistory()
        {
            String FileName = getFileName();
            List<string> stringList = new List<string>();
            //stringList.OrEmptyIfNull
            try
            {
                using (StreamWriter sf = new StreamWriter(FileName))
                {
                    lstHistory.Items.Cast<Object>()
                        .ForEachLazzy(item => sf.WriteLine(item.ToString())).ToArray();

                    int Cnt = lstHistory.Items.Count;
                    while (Cnt > 0)
                    {
                        sf.WriteLine(lstHistory.Items[--Cnt].ToString());
                    }

                    sf.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadHistory()
        {
            String FileName = getFileName();
            try
            {
                using (StreamReader sf = new StreamReader(FileName))
                {
                    while (!sf.EndOfStream)
                    {
                        lstHistory.Items.Insert(0, sf.ReadLine());
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string getFileName()
        {
            return Application.CommonAppDataPath.ToString() + "\\OleSqlHistoryData.sql";
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = false;
            SaveHistory();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void SQL_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Control))
            {
                OnQuery(this, e);
            }
        }

        private void OnODBC(object sender, EventArgs e)
        {
            using (ConnectionODBC ODBCParams = new ConnectionODBC())
            {
                ODBCParams.ShowDialog(this);
                connectionString = ODBCParams.ConnectionString();
                IsODBC = true;
                UpdateUI();
            }
        }

        private void SwitchDBMode(object sender, EventArgs e)
        {
            if (IsODBC != checkOLE.Checked)
            {
                IsODBC = checkOLE.Checked;
                //perform needed operations (like db disconnect)
            }
            checkOLE.Text = (IsODBC) ? "ODBC" : "OLE";
        }
    }
}
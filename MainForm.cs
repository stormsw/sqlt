using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Collections;
using System.Globalization;

namespace SQLt
{
    public partial class MainForm : Form
    {

        private OleDbConnection m_OleDbCon = new OleDbConnection();
        private OdbcConnection m_ODBCConnection = new OdbcConnection();
        bool IsODBC { get; set; }
        private String strConnectionString = "Click settings.";
        private ArrayList tblArray;
        private const string COLUMN_NAME = "COLUMN_NAME";
        private const string DATABASE = "DATABASE";
        private const string ROOT_DB = "RootDB";
        private const string TABLES = "Tables";
        private const string FIELDS = "Fields";
        private ArrayList fldArray;

        public MainForm()
        {
            InitializeComponent();
        }


        private void UpdateUI()
        {
            //textBox1.Text = strConnectionString;
            tlConStr.Text = strConnectionString;
        }

        private void OnSDE(object sender, EventArgs e)
        {
            using (ConnectionSde SdeParams = new ConnectionSde())
            {
                SdeParams.ShowDialog(this);
                strConnectionString = SdeParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        private void OnQuery(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Update();
            String strSQL = textBox2.Text;
            lstHistory.Items.Insert(0, strSQL);

            try
            {
                using (DataTable m_DataTable = new DataTable() { Locale = CultureInfo.CurrentCulture })
                {
                    if (IsODBC)
                    {
                        using (OdbcDataAdapter dbc = new OdbcDataAdapter(strSQL, m_ODBCConnection))
                        {
                            dbc.Fill(m_DataTable);
                        }
                    }
                    else
                    {
                        using (OleDbDataAdapter dba = new OleDbDataAdapter(strSQL, m_OleDbCon))
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
                strConnectionString = SQLParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        private void GetTables(OleDbConnection connection)
        {
            try
            {
                //connection.Open();
                using (DataTable schTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new Object[] { null, null, null, "TABLE" }))
                {
                    tblArray = new ArrayList();
                    foreach (DataRow datRow in schTable.Rows)
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
            strConnectionString = tlConStr.Text.ToString();

            if (strConnectionString.StartsWith("Provider", StringComparison.OrdinalIgnoreCase))
            {
                //User can mix....
                IsODBC = false;
            }
            else
            {
                IsODBC = true;
            }

            if (!IsODBC)
            {
                if ((m_OleDbCon.State != ConnectionState.Open) && strConnectionString.Length > 10)
                {
                    m_OleDbCon.ConnectionString = strConnectionString;
                    try
                    {
                        m_OleDbCon.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (m_OleDbCon.State == ConnectionState.Open)
                    {
                        btnConnect.Text = "Disconnect [OLEDB]";
                        dataGridView1.DataSource = m_OleDbCon.GetSchema();
                        FillTreeView(m_OleDbCon);
                    }
                }
                else
                {
                    m_OleDbCon.Close();
                    btnConnect.Text = "Connect";
                    dataGridView1.DataSource = null;

                }

            }
            else
            {
                if (m_ODBCConnection.State != ConnectionState.Open && strConnectionString.Length > 0)
                {
                    m_ODBCConnection.ConnectionString = strConnectionString;
                    try
                    {
                        m_ODBCConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (m_ODBCConnection.State == ConnectionState.Open)
                    {
                        btnConnect.Text = "Disconnect [ODBC]";
                        dataGridView1.DataSource = m_ODBCConnection.GetSchema();
                    }
                }
                else
                {
                    m_ODBCConnection.Close();
                    btnConnect.Text = "Connect";
                    dataGridView1.DataSource = null;
                }
            }

            btnQuery.Enabled = ((m_OleDbCon.State == ConnectionState.Open) ||
                (m_ODBCConnection.State == ConnectionState.Open));
            tlConStr.Enabled = !btnQuery.Enabled;
        }

        private void OnInformix(object sender, EventArgs e)
        {
            using (ConnectionInformix IfxParams = new ConnectionInformix())
            {
                IfxParams.ShowDialog();
                strConnectionString = IfxParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        private void OnOracle(object sender, EventArgs e)
        {
            using (ConnnectionOracle OraParams = new ConnnectionOracle())
            {
                OraParams.ShowDialog();
                strConnectionString = OraParams.ConnectionString();
                IsODBC = false;
                UpdateUI();
            }
        }

        private void lstHistory_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = lstHistory.SelectedItem.ToString();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            lstHistory.Items.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lstHistory.SelectedItem != null)
                textBox2.Text += ";\r\n" + lstHistory.SelectedItem.ToString();
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
                            sf.Write(textBox2.Text);
                            sf.Flush();
                         //   sf.Close();
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
                            textBox2.Text = sf.ReadToEnd();
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
            String FileName = Application.CommonAppDataPath.ToString() + "\\OleSqlHistoryData.sql";

            try
            {
                using (StreamWriter sf = new StreamWriter(FileName))
                {
                    int Cnt = lstHistory.Items.Count;
                    while (Cnt > 0)
                    {
                        sf.WriteLine(lstHistory.Items[--Cnt].ToString());
                    }


                    sf.Flush();
                    //sf.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadHistory()
        {
            String FileName = Application.CommonAppDataPath.ToString() + "\\OleSqlHistoryData.sql";
            try
            {
                using (StreamReader sf = new StreamReader(FileName))
                {
                    while (!sf.EndOfStream)
                    {
                        lstHistory.Items.Insert(0, sf.ReadLine());
                    }
                    //sf.Close();
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
                OnQuery(this, e);

        }

        private void OnODBC(object sender, EventArgs e)
        {
            using (ConnectionODBC ODBCParams = new ConnectionODBC())
            {
                ODBCParams.ShowDialog(this);
                strConnectionString = ODBCParams.ConnectionString();
                IsODBC = true;
                UpdateUI();
            }
        }

        private void SwitchDBMode(object sender, EventArgs e)
        {
            if (IsODBC != chkOLE.Checked)
            {
                IsODBC = chkOLE.Checked;
                //perform needed operations (like db disconnect)
            }

            chkOLE.Text = (IsODBC) ? "ODBC" : "OLE";

        }
    }
}
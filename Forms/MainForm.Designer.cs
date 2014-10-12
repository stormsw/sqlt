namespace SQLt
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConStrBuilder = new System.Windows.Forms.ToolStripSplitButton();
            this.sDEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNFORMIXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRACLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oDBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlConStr = new System.Windows.Forms.ToolStripTextBox();
            this.checkOLE = new System.Windows.Forms.ToolStripButton();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuery = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.ObjectView = new System.Windows.Forms.TreeView();
            this.dbObjects = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStripContainer1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 41);
            this.panel1.TabIndex = 10;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(701, 35);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(701, 60);
            this.toolStripContainer1.TabIndex = 11;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConStrBuilder,
            this.tlConStr,
            this.checkOLE,
            this.btnConnect,
            this.toolStripSeparator1,
            this.btnQuery,
            this.btnSave,
            this.btnOpen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(701, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConStrBuilder
            // 
            this.btnConStrBuilder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConStrBuilder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sDEToolStripMenuItem,
            this.iNFORMIXToolStripMenuItem,
            this.mSSQLToolStripMenuItem,
            this.oRACLEToolStripMenuItem,
            this.oDBCToolStripMenuItem});
            this.btnConStrBuilder.Image = ((System.Drawing.Image)(resources.GetObject("btnConStrBuilder.Image")));
            this.btnConStrBuilder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConStrBuilder.Name = "btnConStrBuilder";
            this.btnConStrBuilder.Size = new System.Drawing.Size(48, 36);
            this.btnConStrBuilder.Text = "Builder";
            // 
            // sDEToolStripMenuItem
            // 
            this.sDEToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sDEToolStripMenuItem.Image")));
            this.sDEToolStripMenuItem.Name = "sDEToolStripMenuItem";
            this.sDEToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sDEToolStripMenuItem.Text = "SDE";
            this.sDEToolStripMenuItem.Click += new System.EventHandler(this.OnSDE);
            // 
            // iNFORMIXToolStripMenuItem
            // 
            this.iNFORMIXToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("iNFORMIXToolStripMenuItem.Image")));
            this.iNFORMIXToolStripMenuItem.Name = "iNFORMIXToolStripMenuItem";
            this.iNFORMIXToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.iNFORMIXToolStripMenuItem.Text = "INFORMIX";
            this.iNFORMIXToolStripMenuItem.Click += new System.EventHandler(this.OnInformix);
            // 
            // mSSQLToolStripMenuItem
            // 
            this.mSSQLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mSSQLToolStripMenuItem.Image")));
            this.mSSQLToolStripMenuItem.Name = "mSSQLToolStripMenuItem";
            this.mSSQLToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.mSSQLToolStripMenuItem.Text = "MSSQL";
            this.mSSQLToolStripMenuItem.Click += new System.EventHandler(this.OnSQL);
            // 
            // oRACLEToolStripMenuItem
            // 
            this.oRACLEToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oRACLEToolStripMenuItem.Image")));
            this.oRACLEToolStripMenuItem.Name = "oRACLEToolStripMenuItem";
            this.oRACLEToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.oRACLEToolStripMenuItem.Text = "ORACLE";
            this.oRACLEToolStripMenuItem.Click += new System.EventHandler(this.OnOracle);
            // 
            // oDBCToolStripMenuItem
            // 
            this.oDBCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oDBCToolStripMenuItem.Image")));
            this.oDBCToolStripMenuItem.Name = "oDBCToolStripMenuItem";
            this.oDBCToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.oDBCToolStripMenuItem.Text = "ODBC";
            this.oDBCToolStripMenuItem.Click += new System.EventHandler(this.OnODBC);
            // 
            // tlConStr
            // 
            this.tlConStr.Name = "tlConStr";
            this.tlConStr.Size = new System.Drawing.Size(250, 39);
            // 
            // checkOLE
            // 
            this.checkOLE.CheckOnClick = true;
            this.checkOLE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.checkOLE.Image = ((System.Drawing.Image)(resources.GetObject("checkOLE.Image")));
            this.checkOLE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkOLE.Name = "checkOLE";
            this.checkOLE.Size = new System.Drawing.Size(23, 36);
            this.checkOLE.Text = "OLE";
            this.checkOLE.Click += new System.EventHandler(this.SwitchDBMode);
            // 
            // btnConnect
            // 
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 36);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.OnConnect);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnQuery
            // 
            this.btnQuery.Enabled = false;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 36);
            this.btnQuery.Text = "Query";
            this.btnQuery.Click += new System.EventHandler(this.OnQuery);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 36);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.SaveSQL);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(36, 36);
            this.btnOpen.Text = "Open";
            this.btnOpen.ToolTipText = "Open";
            this.btnOpen.Click += new System.EventHandler(this.LoadSQL);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Connection string";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(701, 468);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lstHistory);
            this.splitContainer2.Panel1.Controls.Add(this.txtHistory);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ObjectView);
            this.splitContainer2.Size = new System.Drawing.Size(701, 232);
            this.splitContainer2.SplitterDistance = 500;
            this.splitContainer2.TabIndex = 11;
            // 
            // lstHistory
            // 
            this.lstHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lstHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.Location = new System.Drawing.Point(0, 163);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(500, 69);
            this.lstHistory.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem6,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 98);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "Insert";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.lstHistory_DoubleClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Add to SQL";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Save History";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "Clear";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // txtHistory
            // 
            this.txtHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistory.Location = new System.Drawing.Point(0, 0);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.Size = new System.Drawing.Size(500, 232);
            this.txtHistory.TabIndex = 1;
            this.txtHistory.Text = "SELECT * FROM OPENQUERY(LAFIS_INVEKOS,\'SELECT 1\') ";
            // 
            // ObjectView
            // 
            this.ObjectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectView.ImageIndex = 0;
            this.ObjectView.ImageList = this.dbObjects;
            this.ObjectView.ItemHeight = 24;
            this.ObjectView.Location = new System.Drawing.Point(0, 0);
            this.ObjectView.Name = "ObjectView";
            this.ObjectView.SelectedImageIndex = 1;
            this.ObjectView.Size = new System.Drawing.Size(197, 232);
            this.ObjectView.TabIndex = 0;
            // 
            // dbObjects
            // 
            this.dbObjects.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("dbObjects.ImageStream")));
            this.dbObjects.TransparentColor = System.Drawing.Color.Transparent;
            this.dbObjects.Images.SetKeyName(0, "database_inactive.ico");
            this.dbObjects.Images.SetKeyName(1, "database_active.ico");
            this.dbObjects.Images.SetKeyName(2, "table.ico");
            this.dbObjects.Images.SetKeyName(3, "stock_table_same_width.ico");
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(701, 232);
            this.dataGridView1.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 509);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Test SQL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton btnConStrBuilder;
        private System.Windows.Forms.ToolStripMenuItem sDEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNFORMIXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRACLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tlConStr;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnQuery;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripMenuItem oDBCToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton checkOLE;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.TreeView ObjectView;
        private System.Windows.Forms.ImageList dbObjects;
    }
}


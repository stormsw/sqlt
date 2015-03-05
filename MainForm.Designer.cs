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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
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
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnConStrBuilder
            // 
            resources.ApplyResources(this.btnConStrBuilder, "btnConStrBuilder");
            this.btnConStrBuilder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConStrBuilder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sDEToolStripMenuItem,
            this.iNFORMIXToolStripMenuItem,
            this.mSSQLToolStripMenuItem,
            this.oRACLEToolStripMenuItem,
            this.oDBCToolStripMenuItem});
            this.btnConStrBuilder.Name = "btnConStrBuilder";
            // 
            // sDEToolStripMenuItem
            // 
            resources.ApplyResources(this.sDEToolStripMenuItem, "sDEToolStripMenuItem");
            this.sDEToolStripMenuItem.Name = "sDEToolStripMenuItem";
            this.sDEToolStripMenuItem.Click += new System.EventHandler(this.OnSDE);
            // 
            // iNFORMIXToolStripMenuItem
            // 
            resources.ApplyResources(this.iNFORMIXToolStripMenuItem, "iNFORMIXToolStripMenuItem");
            this.iNFORMIXToolStripMenuItem.Name = "iNFORMIXToolStripMenuItem";
            this.iNFORMIXToolStripMenuItem.Click += new System.EventHandler(this.OnInformix);
            // 
            // mSSQLToolStripMenuItem
            // 
            resources.ApplyResources(this.mSSQLToolStripMenuItem, "mSSQLToolStripMenuItem");
            this.mSSQLToolStripMenuItem.Name = "mSSQLToolStripMenuItem";
            this.mSSQLToolStripMenuItem.Click += new System.EventHandler(this.OnSQL);
            // 
            // oRACLEToolStripMenuItem
            // 
            resources.ApplyResources(this.oRACLEToolStripMenuItem, "oRACLEToolStripMenuItem");
            this.oRACLEToolStripMenuItem.Name = "oRACLEToolStripMenuItem";
            this.oRACLEToolStripMenuItem.Click += new System.EventHandler(this.OnOracle);
            // 
            // oDBCToolStripMenuItem
            // 
            resources.ApplyResources(this.oDBCToolStripMenuItem, "oDBCToolStripMenuItem");
            this.oDBCToolStripMenuItem.Name = "oDBCToolStripMenuItem";
            this.oDBCToolStripMenuItem.Click += new System.EventHandler(this.OnODBC);
            // 
            // tlConStr
            // 
            resources.ApplyResources(this.tlConStr, "tlConStr");
            this.tlConStr.Name = "tlConStr";
            // 
            // checkOLE
            // 
            resources.ApplyResources(this.checkOLE, "checkOLE");
            this.checkOLE.CheckOnClick = true;
            this.checkOLE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.checkOLE.Name = "checkOLE";
            this.checkOLE.Click += new System.EventHandler(this.SwitchDBMode);
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Click += new System.EventHandler(this.OnConnect);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Click += new System.EventHandler(this.OnQuery);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.SaveSQL);
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Click += new System.EventHandler(this.LoadSQL);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.lstHistory);
            this.splitContainer2.Panel1.Controls.Add(this.txtHistory);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.ObjectView);
            // 
            // lstHistory
            // 
            resources.ApplyResources(this.lstHistory, "lstHistory");
            this.lstHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.Name = "lstHistory";
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem6,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.lstHistory_DoubleClick);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // toolStripMenuItem6
            // 
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            // 
            // toolStripMenuItem4
            // 
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // txtHistory
            // 
            resources.ApplyResources(this.txtHistory, "txtHistory");
            this.txtHistory.Name = "txtHistory";
            // 
            // ObjectView
            // 
            resources.ApplyResources(this.ObjectView, "ObjectView");
            this.ObjectView.ImageList = this.dbObjects;
            this.ObjectView.ItemHeight = 24;
            this.ObjectView.Name = "ObjectView";
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
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Name = "dataGridView1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.toolStripContainer1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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


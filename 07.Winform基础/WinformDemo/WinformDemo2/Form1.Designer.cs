namespace WinformDemo2
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAnimal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangeName = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbAnimal = new System.Windows.Forms.ListBox();
            this.cmsListbot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtAnimal = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.打开日期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsListbot.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuAnimal,
            this.menuChangeName,
            this.打开日期ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuSave,
            this.menuQuit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(53, 24);
            this.menuFile.Text = "文件";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(122, 26);
            this.menuOpen.Text = "打开";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(122, 26);
            this.menuSave.Text = "保存";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuQuit
            // 
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(122, 26);
            this.menuQuit.Text = "退出";
            this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
            // 
            // menuAnimal
            // 
            this.menuAnimal.Name = "menuAnimal";
            this.menuAnimal.Size = new System.Drawing.Size(53, 24);
            this.menuAnimal.Text = "动物";
            this.menuAnimal.Click += new System.EventHandler(this.menuAnimal_Click);
            // 
            // menuChangeName
            // 
            this.menuChangeName.Name = "menuChangeName";
            this.menuChangeName.Size = new System.Drawing.Size(143, 24);
            this.menuChangeName.Text = "修改所有动物名称";
            this.menuChangeName.Click += new System.EventHandler(this.menuChangeName_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbAnimal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtAnimal);
            this.splitContainer1.Size = new System.Drawing.Size(800, 422);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbAnimal
            // 
            this.lbAnimal.ContextMenuStrip = this.cmsListbot;
            this.lbAnimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAnimal.FormattingEnabled = true;
            this.lbAnimal.ItemHeight = 20;
            this.lbAnimal.Location = new System.Drawing.Point(0, 0);
            this.lbAnimal.Name = "lbAnimal";
            this.lbAnimal.Size = new System.Drawing.Size(266, 422);
            this.lbAnimal.TabIndex = 0;
            // 
            // cmsListbot
            // 
            this.cmsListbot.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsListbot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDelete});
            this.cmsListbot.Name = "cmsListbot";
            this.cmsListbot.Size = new System.Drawing.Size(109, 28);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(108, 24);
            this.cmsDelete.Text = "删除";
            this.cmsDelete.Click += new System.EventHandler(this.cmsDelete_Click);
            // 
            // txtAnimal
            // 
            this.txtAnimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnimal.Location = new System.Drawing.Point(0, 0);
            this.txtAnimal.Name = "txtAnimal";
            this.txtAnimal.Size = new System.Drawing.Size(530, 422);
            this.txtAnimal.TabIndex = 0;
            this.txtAnimal.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // 打开日期ToolStripMenuItem
            // 
            this.打开日期ToolStripMenuItem.Name = "打开日期ToolStripMenuItem";
            this.打开日期ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.打开日期ToolStripMenuItem.Text = "打开日期";
            this.打开日期ToolStripMenuItem.Click += new System.EventHandler(this.打开日期ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "主窗体";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsListbot.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuOpen;
        private ToolStripMenuItem menuSave;
        private SplitContainer splitContainer1;
        private ListBox lbAnimal;
        private RichTextBox txtAnimal;
        private ToolStripMenuItem menuAnimal;
        private ContextMenuStrip cmsListbot;
        private ToolStripMenuItem cmsDelete;
        private ToolStripMenuItem menuQuit;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem menuChangeName;
        private ToolStripMenuItem 打开日期ToolStripMenuItem;
    }
}
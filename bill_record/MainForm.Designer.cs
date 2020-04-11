namespace bill_record
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManager = new System.Windows.Forms.ToolStripMenuItem();
            this.option = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_monthly = new System.Windows.Forms.Button();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_in = new System.Windows.Forms.PictureBox();
            this.pic_out = new System.Windows.Forms.PictureBox();
            this.pic_monthly = new System.Windows.Forms.PictureBox();
            this.pic_bill = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_out)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_monthly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bill)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.工具TToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.开始ToolStripMenuItem.Text = "开始(&S)";
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManager,
            this.option});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // userManager
            // 
            this.userManager.Name = "userManager";
            this.userManager.Size = new System.Drawing.Size(144, 22);
            this.userManager.Text = "用户管理(&M)";
            this.userManager.Click += new System.EventHandler(this.userManager_Click);
            // 
            // option
            // 
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(144, 22);
            this.option.Text = "选项(&O)";
            this.option.Click += new System.EventHandler(this.option_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(885, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(19, 21);
            this.toolStripStatusLabel1.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(135, 21);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(135, 21);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // btn_monthly
            // 
            this.btn_monthly.Location = new System.Drawing.Point(26, 399);
            this.btn_monthly.Name = "btn_monthly";
            this.btn_monthly.Size = new System.Drawing.Size(75, 23);
            this.btn_monthly.TabIndex = 8;
            this.btn_monthly.Text = "月结";
            this.btn_monthly.UseVisualStyleBackColor = true;
            this.btn_monthly.Visible = false;
            this.btn_monthly.Click += new System.EventHandler(this.btn_monthly_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(123, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(762, 434);
            this.dockPanel1.TabIndex = 9;
            this.dockPanel1.ActiveContentChanged += new System.EventHandler(this.dockPanel1_ActiveContentChanged);
            this.dockPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.pic_in);
            this.panel1.Controls.Add(this.pic_out);
            this.panel1.Controls.Add(this.pic_monthly);
            this.panel1.Controls.Add(this.pic_bill);
            this.panel1.Controls.Add(this.btn_monthly);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 434);
            this.panel1.TabIndex = 11;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pic_in
            // 
            this.pic_in.Image = global::bill_record.Properties.Resources.feed_in_128px_1210751_easyicon_net;
            this.pic_in.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_in.InitialImage")));
            this.pic_in.Location = new System.Drawing.Point(13, 14);
            this.pic_in.Name = "pic_in";
            this.pic_in.Size = new System.Drawing.Size(89, 87);
            this.pic_in.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_in.TabIndex = 1;
            this.pic_in.TabStop = false;
            this.pic_in.Click += new System.EventHandler(this.pic_in_Click);
            this.pic_in.MouseEnter += new System.EventHandler(this.pic_in_MouseEnter);
            // 
            // pic_out
            // 
            this.pic_out.Image = global::bill_record.Properties.Resources.exit_128px_1210133_easyicon_net;
            this.pic_out.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_out.InitialImage")));
            this.pic_out.Location = new System.Drawing.Point(13, 107);
            this.pic_out.Name = "pic_out";
            this.pic_out.Size = new System.Drawing.Size(89, 87);
            this.pic_out.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_out.TabIndex = 0;
            this.pic_out.TabStop = false;
            this.pic_out.Click += new System.EventHandler(this.pic_out_Click);
            this.pic_out.MouseEnter += new System.EventHandler(this.pic_in_MouseEnter);
            // 
            // pic_monthly
            // 
            this.pic_monthly.Image = global::bill_record.Properties.Resources.calendar_clock_icon;
            this.pic_monthly.Location = new System.Drawing.Point(13, 293);
            this.pic_monthly.Name = "pic_monthly";
            this.pic_monthly.Size = new System.Drawing.Size(89, 87);
            this.pic_monthly.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_monthly.TabIndex = 5;
            this.pic_monthly.TabStop = false;
            this.pic_monthly.Click += new System.EventHandler(this.pic_monthly_Click);
            this.pic_monthly.MouseEnter += new System.EventHandler(this.pic_in_MouseEnter);
            // 
            // pic_bill
            // 
            this.pic_bill.Image = global::bill_record.Properties.Resources.see_no_evil_monkey_128px_1214323_easyicon_net;
            this.pic_bill.Location = new System.Drawing.Point(13, 200);
            this.pic_bill.Name = "pic_bill";
            this.pic_bill.Size = new System.Drawing.Size(89, 87);
            this.pic_bill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_bill.TabIndex = 5;
            this.pic_bill.TabStop = false;
            this.pic_bill.Click += new System.EventHandler(this.pic_bill_Click);
            this.pic_bill.MouseEnter += new System.EventHandler(this.pic_in_MouseEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 485);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_out)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_monthly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_out;
        private System.Windows.Forms.PictureBox pic_in;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pic_bill;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManager;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button btn_monthly;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_monthly;
        private System.Windows.Forms.ToolStripMenuItem option;
    }
}

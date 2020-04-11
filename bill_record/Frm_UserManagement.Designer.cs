namespace bill_record
{
    partial class Frm_UserManagement
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
            this.components = new System.ComponentModel.Container();
            this.bds_UserManagement = new System.Windows.Forms.BindingSource(this.components);
            this.xsd_UserManagement = new bill_record.xsd_UserManagement();
            this.dgv_userview = new System.Windows.Forms.DataGridView();
            this.accuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accunameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accupasswordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acculevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accuvalidDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.accustateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_reEnter = new System.Windows.Forms.TextBox();
            this.txt_newPass = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_userid = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_all = new System.Windows.Forms.CheckBox();
            this.btn_reject = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bds_UserManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsd_UserManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userview)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bds_UserManagement
            // 
            this.bds_UserManagement.DataMember = "tbl_access";
            this.bds_UserManagement.DataSource = this.xsd_UserManagement;
            // 
            // xsd_UserManagement
            // 
            this.xsd_UserManagement.DataSetName = "xsd_UserManagement";
            this.xsd_UserManagement.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgv_userview
            // 
            this.dgv_userview.AllowUserToAddRows = false;
            this.dgv_userview.AutoGenerateColumns = false;
            this.dgv_userview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accuidDataGridViewTextBoxColumn,
            this.accunameDataGridViewTextBoxColumn,
            this.accupasswordDataGridViewTextBoxColumn,
            this.acculevelDataGridViewTextBoxColumn,
            this.accuvalidDataGridViewCheckBoxColumn,
            this.accustateDataGridViewCheckBoxColumn});
            this.dgv_userview.DataSource = this.bds_UserManagement;
            this.dgv_userview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_userview.Location = new System.Drawing.Point(3, 48);
            this.dgv_userview.Name = "dgv_userview";
            this.dgv_userview.ReadOnly = true;
            this.dgv_userview.RowTemplate.Height = 23;
            this.dgv_userview.Size = new System.Drawing.Size(679, 304);
            this.dgv_userview.TabIndex = 0;
            // 
            // accuidDataGridViewTextBoxColumn
            // 
            this.accuidDataGridViewTextBoxColumn.DataPropertyName = "acc_uid";
            this.accuidDataGridViewTextBoxColumn.HeaderText = "acc_uid";
            this.accuidDataGridViewTextBoxColumn.Name = "accuidDataGridViewTextBoxColumn";
            this.accuidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accunameDataGridViewTextBoxColumn
            // 
            this.accunameDataGridViewTextBoxColumn.DataPropertyName = "acc_uname";
            this.accunameDataGridViewTextBoxColumn.HeaderText = "acc_uname";
            this.accunameDataGridViewTextBoxColumn.Name = "accunameDataGridViewTextBoxColumn";
            this.accunameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accupasswordDataGridViewTextBoxColumn
            // 
            this.accupasswordDataGridViewTextBoxColumn.DataPropertyName = "acc_upassword";
            this.accupasswordDataGridViewTextBoxColumn.HeaderText = "acc_upassword";
            this.accupasswordDataGridViewTextBoxColumn.Name = "accupasswordDataGridViewTextBoxColumn";
            this.accupasswordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // acculevelDataGridViewTextBoxColumn
            // 
            this.acculevelDataGridViewTextBoxColumn.DataPropertyName = "acc_ulevel";
            this.acculevelDataGridViewTextBoxColumn.HeaderText = "acc_ulevel";
            this.acculevelDataGridViewTextBoxColumn.Name = "acculevelDataGridViewTextBoxColumn";
            this.acculevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accuvalidDataGridViewCheckBoxColumn
            // 
            this.accuvalidDataGridViewCheckBoxColumn.DataPropertyName = "acc_uvalid";
            this.accuvalidDataGridViewCheckBoxColumn.HeaderText = "acc_uvalid";
            this.accuvalidDataGridViewCheckBoxColumn.Name = "accuvalidDataGridViewCheckBoxColumn";
            this.accuvalidDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // accustateDataGridViewCheckBoxColumn
            // 
            this.accustateDataGridViewCheckBoxColumn.DataPropertyName = "acc_ustate";
            this.accustateDataGridViewCheckBoxColumn.HeaderText = "acc_ustate";
            this.accustateDataGridViewCheckBoxColumn.Name = "accustateDataGridViewCheckBoxColumn";
            this.accustateDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 381);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_username);
            this.tabPage1.Controls.Add(this.btn_Cancel);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_reEnter);
            this.tabPage1.Controls.Add(this.txt_newPass);
            this.tabPage1.Controls.Add(this.txt_password);
            this.tabPage1.Controls.Add(this.txt_userid);
            this.tabPage1.Controls.Add(this.btn_submit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(685, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "账户管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "用户名：";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(137, 60);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(136, 21);
            this.txt_username.TabIndex = 10;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(198, 240);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "确认新密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "输入新密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "输入原始密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户ID：";
            // 
            // txt_reEnter
            // 
            this.txt_reEnter.Location = new System.Drawing.Point(137, 159);
            this.txt_reEnter.Name = "txt_reEnter";
            this.txt_reEnter.PasswordChar = '*';
            this.txt_reEnter.Size = new System.Drawing.Size(138, 21);
            this.txt_reEnter.TabIndex = 4;
            this.txt_reEnter.TextChanged += new System.EventHandler(this.txt_reEnter_TextChanged);
            this.txt_reEnter.Validated += new System.EventHandler(this.txt_reEnter_Validated);
            // 
            // txt_newPass
            // 
            this.txt_newPass.Location = new System.Drawing.Point(137, 126);
            this.txt_newPass.Name = "txt_newPass";
            this.txt_newPass.PasswordChar = '*';
            this.txt_newPass.Size = new System.Drawing.Size(138, 21);
            this.txt_newPass.TabIndex = 3;
            this.txt_newPass.TextChanged += new System.EventHandler(this.txt_newPass_TextChanged);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(137, 93);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(138, 21);
            this.txt_password.TabIndex = 2;
            // 
            // txt_userid
            // 
            this.txt_userid.Location = new System.Drawing.Point(137, 27);
            this.txt_userid.Name = "txt_userid";
            this.txt_userid.ReadOnly = true;
            this.txt_userid.Size = new System.Drawing.Size(138, 21);
            this.txt_userid.TabIndex = 1;
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(59, 241);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 0;
            this.btn_submit.Text = "提交";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_userview);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(685, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "用户管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_all);
            this.panel1.Controls.Add(this.btn_reject);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 45);
            this.panel1.TabIndex = 3;
            // 
            // chk_all
            // 
            this.chk_all.AutoSize = true;
            this.chk_all.Location = new System.Drawing.Point(412, 13);
            this.chk_all.Name = "chk_all";
            this.chk_all.Size = new System.Drawing.Size(96, 16);
            this.chk_all.TabIndex = 7;
            this.chk_all.Text = "包括离职用户";
            this.chk_all.UseVisualStyleBackColor = true;
            this.chk_all.CheckedChanged += new System.EventHandler(this.chk_all_CheckedChanged);
            // 
            // btn_reject
            // 
            this.btn_reject.Enabled = false;
            this.btn_reject.Location = new System.Drawing.Point(168, 9);
            this.btn_reject.Name = "btn_reject";
            this.btn_reject.Size = new System.Drawing.Size(75, 23);
            this.btn_reject.TabIndex = 6;
            this.btn_reject.Text = "撤销";
            this.btn_reject.UseVisualStyleBackColor = true;
            this.btn_reject.Click += new System.EventHandler(this.btn_reject_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(93, 9);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 5;
            this.btn_edit.Text = "编辑";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(318, 9);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 4;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(18, 9);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "新增";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Enabled = false;
            this.btn_delete.Location = new System.Drawing.Point(243, 9);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "离职";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Frm_UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 381);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_UserManagement";
            this.Text = "Frm_UserManagement";
            this.Load += new System.EventHandler(this.Frm_UserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bds_UserManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsd_UserManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userview)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bds_UserManagement;
        private xsd_UserManagement xsd_UserManagement;
        private System.Windows.Forms.DataGridView dgv_userview;
        private System.Windows.Forms.DataGridViewTextBoxColumn accuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accunameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accupasswordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn acculevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn accuvalidDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn accustateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_reEnter;
        private System.Windows.Forms.TextBox txt_newPass;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_userid;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_reject;
        private System.Windows.Forms.CheckBox chk_all;
    }
}
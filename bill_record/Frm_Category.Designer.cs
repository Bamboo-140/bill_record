namespace bill_record
{
    partial class Frm_Category
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_main = new System.Windows.Forms.DataGridView();
            this.dgv_sub = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.xsd_Category1 = new bill_record.xsd_Category();
            this.bds_main = new System.Windows.Forms.BindingSource(this.components);
            this.bds_sub = new System.Windows.Forms.BindingSource(this.components);
            this.midDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smainIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sub)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xsd_Category1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_sub)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 345);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_main);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_sub);
            this.splitContainer1.Size = new System.Drawing.Size(800, 345);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgv_main
            // 
            this.dgv_main.AllowUserToAddRows = false;
            this.dgv_main.AutoGenerateColumns = false;
            this.dgv_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.midDataGridViewTextBoxColumn,
            this.mtypeDataGridViewTextBoxColumn,
            this.mnoteDataGridViewTextBoxColumn});
            this.dgv_main.DataSource = this.bds_main;
            this.dgv_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_main.Location = new System.Drawing.Point(0, 0);
            this.dgv_main.Name = "dgv_main";
            this.dgv_main.RowTemplate.Height = 23;
            this.dgv_main.Size = new System.Drawing.Size(351, 345);
            this.dgv_main.TabIndex = 1;
            // 
            // dgv_sub
            // 
            this.dgv_sub.AllowUserToAddRows = false;
            this.dgv_sub.AutoGenerateColumns = false;
            this.dgv_sub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sub.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sidDataGridViewTextBoxColumn,
            this.snameDataGridViewTextBoxColumn,
            this.smainIdDataGridViewTextBoxColumn,
            this.snoteDataGridViewTextBoxColumn});
            this.dgv_sub.DataSource = this.bds_sub;
            this.dgv_sub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sub.Location = new System.Drawing.Point(0, 0);
            this.dgv_sub.Name = "dgv_sub";
            this.dgv_sub.RowTemplate.Height = 23;
            this.dgv_sub.Size = new System.Drawing.Size(445, 345);
            this.dgv_sub.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.btn_delete);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_edit);
            this.panel2.Controls.Add(this.btn_new);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 58);
            this.panel2.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // xsd_Category1
            // 
            this.xsd_Category1.DataSetName = "xsd_Category";
            this.xsd_Category1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bds_main
            // 
            this.bds_main.DataMember = "tbl_main";
            this.bds_main.DataSource = this.xsd_Category1;
            // 
            // bds_sub
            // 
            this.bds_sub.DataMember = "tbl_sub";
            this.bds_sub.DataSource = this.xsd_Category1;
            // 
            // midDataGridViewTextBoxColumn
            // 
            this.midDataGridViewTextBoxColumn.DataPropertyName = "m_id";
            this.midDataGridViewTextBoxColumn.HeaderText = "m_id";
            this.midDataGridViewTextBoxColumn.Name = "midDataGridViewTextBoxColumn";
            // 
            // mtypeDataGridViewTextBoxColumn
            // 
            this.mtypeDataGridViewTextBoxColumn.DataPropertyName = "m_type";
            this.mtypeDataGridViewTextBoxColumn.HeaderText = "m_type";
            this.mtypeDataGridViewTextBoxColumn.Name = "mtypeDataGridViewTextBoxColumn";
            // 
            // mnoteDataGridViewTextBoxColumn
            // 
            this.mnoteDataGridViewTextBoxColumn.DataPropertyName = "m_note";
            this.mnoteDataGridViewTextBoxColumn.HeaderText = "m_note";
            this.mnoteDataGridViewTextBoxColumn.Name = "mnoteDataGridViewTextBoxColumn";
            // 
            // sidDataGridViewTextBoxColumn
            // 
            this.sidDataGridViewTextBoxColumn.DataPropertyName = "s_id";
            this.sidDataGridViewTextBoxColumn.HeaderText = "s_id";
            this.sidDataGridViewTextBoxColumn.Name = "sidDataGridViewTextBoxColumn";
            // 
            // snameDataGridViewTextBoxColumn
            // 
            this.snameDataGridViewTextBoxColumn.DataPropertyName = "s_name";
            this.snameDataGridViewTextBoxColumn.HeaderText = "s_name";
            this.snameDataGridViewTextBoxColumn.Name = "snameDataGridViewTextBoxColumn";
            // 
            // smainIdDataGridViewTextBoxColumn
            // 
            this.smainIdDataGridViewTextBoxColumn.DataPropertyName = "s_mainId";
            this.smainIdDataGridViewTextBoxColumn.HeaderText = "s_mainId";
            this.smainIdDataGridViewTextBoxColumn.Name = "smainIdDataGridViewTextBoxColumn";
            // 
            // snoteDataGridViewTextBoxColumn
            // 
            this.snoteDataGridViewTextBoxColumn.DataPropertyName = "s_note";
            this.snoteDataGridViewTextBoxColumn.HeaderText = "s_note";
            this.snoteDataGridViewTextBoxColumn.Name = "snoteDataGridViewTextBoxColumn";
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(17, 17);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 0;
            this.btn_new.Text = "新建";
            this.btn_new.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(122, 17);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 1;
            this.btn_edit.Text = "编辑";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(229, 17);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(335, 17);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(701, 17);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 4;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            // 
            // Frm_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Frm_Category";
            this.Text = "Frm_Category";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sub)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xsd_Category1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_sub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_main;
        private System.Windows.Forms.DataGridView dgv_sub;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn midDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bds_main;
        private xsd_Category xsd_Category1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn smainIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bds_sub;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_new;
    }
}
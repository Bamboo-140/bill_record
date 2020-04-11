namespace bill_record
{
    partial class Frm_ItemMana
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
            this.dgv_item_mana = new System.Windows.Forms.DataGridView();
            this.bds_itemsMana = new System.Windows.Forms.BindingSource(this.components);
            this.xsd_itemMana1 = new bill_record.xsd_itemMana();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_reject = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.itserialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itunitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itvalidityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itrecoderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_mana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_itemsMana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsd_itemMana1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_item_mana
            // 
            this.dgv_item_mana.AllowUserToAddRows = false;
            this.dgv_item_mana.AutoGenerateColumns = false;
            this.dgv_item_mana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_item_mana.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itserialDataGridViewTextBoxColumn,
            this.itnameDataGridViewTextBoxColumn,
            this.itunitDataGridViewTextBoxColumn,
            this.itvalidityDataGridViewTextBoxColumn,
            this.itrecoderDataGridViewTextBoxColumn});
            this.dgv_item_mana.DataSource = this.bds_itemsMana;
            this.dgv_item_mana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_item_mana.Location = new System.Drawing.Point(0, 69);
            this.dgv_item_mana.Name = "dgv_item_mana";
            this.dgv_item_mana.Size = new System.Drawing.Size(800, 359);
            this.dgv_item_mana.TabIndex = 0;
            // 
            // bds_itemsMana
            // 
            this.bds_itemsMana.DataMember = "tbl_item";
            this.bds_itemsMana.DataSource = this.xsd_itemMana1;
            this.bds_itemsMana.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // xsd_itemMana1
            // 
            this.xsd_itemMana1.DataSetName = "xsd_itemMana";
            this.xsd_itemMana1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(18, 41);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(43, 23);
            this.btn_new.TabIndex = 1;
            this.btn_new.Text = "新建";
            this.btn_new.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(67, 41);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(43, 23);
            this.btn_edit.TabIndex = 2;
            this.btn_edit.Text = "编辑";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(116, 41);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(43, 23);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(165, 41);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(43, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_reject
            // 
            this.btn_reject.Location = new System.Drawing.Point(214, 41);
            this.btn_reject.Name = "btn_reject";
            this.btn_reject.Size = new System.Drawing.Size(43, 23);
            this.btn_reject.TabIndex = 5;
            this.btn_reject.Text = "撤销";
            this.btn_reject.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(236, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(411, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(586, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "label5";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(692, 5);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 15;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            // 
            // itserialDataGridViewTextBoxColumn
            // 
            this.itserialDataGridViewTextBoxColumn.DataPropertyName = "it_serial";
            this.itserialDataGridViewTextBoxColumn.HeaderText = "序号";
            this.itserialDataGridViewTextBoxColumn.Name = "itserialDataGridViewTextBoxColumn";
            // 
            // itnameDataGridViewTextBoxColumn
            // 
            this.itnameDataGridViewTextBoxColumn.DataPropertyName = "it_name";
            this.itnameDataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.itnameDataGridViewTextBoxColumn.Name = "itnameDataGridViewTextBoxColumn";
            // 
            // itunitDataGridViewTextBoxColumn
            // 
            this.itunitDataGridViewTextBoxColumn.DataPropertyName = "it_unit";
            this.itunitDataGridViewTextBoxColumn.HeaderText = "商品单位";
            this.itunitDataGridViewTextBoxColumn.Name = "itunitDataGridViewTextBoxColumn";
            // 
            // itvalidityDataGridViewTextBoxColumn
            // 
            this.itvalidityDataGridViewTextBoxColumn.DataPropertyName = "it_validity";
            this.itvalidityDataGridViewTextBoxColumn.HeaderText = "有效性";
            this.itvalidityDataGridViewTextBoxColumn.Name = "itvalidityDataGridViewTextBoxColumn";
            // 
            // itrecoderDataGridViewTextBoxColumn
            // 
            this.itrecoderDataGridViewTextBoxColumn.DataPropertyName = "it_recoder";
            this.itrecoderDataGridViewTextBoxColumn.HeaderText = "记录人";
            this.itrecoderDataGridViewTextBoxColumn.Name = "itrecoderDataGridViewTextBoxColumn";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_new);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_reject);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 69);
            this.panel1.TabIndex = 17;
            // 
            // Frm_ItemMana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_item_mana);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Frm_ItemMana";
            this.Text = "商品管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_mana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_itemsMana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsd_itemMana1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_item_mana;
        private xsd_itemMana xsd_itemMana1;
        private System.Windows.Forms.BindingSource bds_itemsMana;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_reject;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DataGridViewTextBoxColumn itserialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itunitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itvalidityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itrecoderDataGridViewTextBoxColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
    }
}
namespace bill_record
{
    partial class Frm_Option
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_allow_minus = new System.Windows.Forms.CheckBox();
            this.bds_option = new System.Windows.Forms.BindingSource(this.components);
            this.xsd_option = new bill_record.xsd_option();
            this.chk_allow_all_view = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_option)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsd_option)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(129, 307);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(14, 8);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh.TabIndex = 2;
            this.btn_refresh.Text = "刷新";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "月结日为每月";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bds_option, "monthly_day", true));
            this.numericUpDown1.Location = new System.Drawing.Point(98, 37);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 21);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "日";
            // 
            // chk_allow_minus
            // 
            this.chk_allow_minus.AutoSize = true;
            this.chk_allow_minus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_allow_minus.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bds_option, "allow_minus", true));
            this.chk_allow_minus.Location = new System.Drawing.Point(110, 64);
            this.chk_allow_minus.Name = "chk_allow_minus";
            this.chk_allow_minus.Size = new System.Drawing.Size(72, 16);
            this.chk_allow_minus.TabIndex = 6;
            this.chk_allow_minus.Text = "允许负数";
            this.chk_allow_minus.UseVisualStyleBackColor = true;
            this.chk_allow_minus.CheckedChanged += new System.EventHandler(this.chk_allow_minus_CheckedChanged);
            // 
            // bds_option
            // 
            this.bds_option.DataMember = "tbl_config";
            this.bds_option.DataSource = this.xsd_option;
            // 
            // xsd_option
            // 
            this.xsd_option.DataSetName = "xsd_option";
            this.xsd_option.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chk_allow_all_view
            // 
            this.chk_allow_all_view.AutoSize = true;
            this.chk_allow_all_view.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_allow_all_view.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bds_option, "allow_view_all", true));
            this.chk_allow_all_view.Location = new System.Drawing.Point(14, 86);
            this.chk_allow_all_view.Name = "chk_allow_all_view";
            this.chk_allow_all_view.Size = new System.Drawing.Size(168, 16);
            this.chk_allow_all_view.TabIndex = 7;
            this.chk_allow_all_view.Text = "允许用户查看所有用户数据";
            this.chk_allow_all_view.UseVisualStyleBackColor = true;
            this.chk_allow_all_view.CheckedChanged += new System.EventHandler(this.chk_allow_all_view_CheckedChanged);
            // 
            // Frm_Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 386);
            this.Controls.Add(this.chk_allow_all_view);
            this.Controls.Add(this.chk_allow_minus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_save);
            this.Name = "Frm_Option";
            this.Text = "Frm_Option";
            this.Load += new System.EventHandler(this.Frm_Option_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_option)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsd_option)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_allow_minus;
        private System.Windows.Forms.CheckBox chk_allow_all_view;
        private System.Windows.Forms.BindingSource bds_option;
        private xsd_option xsd_option;
    }
}
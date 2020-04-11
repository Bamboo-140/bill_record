namespace bill_record
{
    partial class Frm_Monthly
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
            this.dtp_month = new System.Windows.Forms.DateTimePicker();
            this.btn_monthly = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtp_month
            // 
            this.dtp_month.Location = new System.Drawing.Point(87, 75);
            this.dtp_month.Name = "dtp_month";
            this.dtp_month.Size = new System.Drawing.Size(116, 21);
            this.dtp_month.TabIndex = 0;
            // 
            // btn_monthly
            // 
            this.btn_monthly.Location = new System.Drawing.Point(128, 102);
            this.btn_monthly.Name = "btn_monthly";
            this.btn_monthly.Size = new System.Drawing.Size(75, 23);
            this.btn_monthly.TabIndex = 1;
            this.btn_monthly.Text = "执行月结";
            this.btn_monthly.UseVisualStyleBackColor = true;
            this.btn_monthly.Click += new System.EventHandler(this.btn_monthly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据转结至";
            // 
            // Frm_Monthly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_monthly);
            this.Controls.Add(this.dtp_month);
            this.Name = "Frm_Monthly";
            this.Text = "Frm_Monthly";
            this.Load += new System.EventHandler(this.Frm_Monthly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_month;
        private System.Windows.Forms.Button btn_monthly;
        private System.Windows.Forms.Label label1;
    }
}
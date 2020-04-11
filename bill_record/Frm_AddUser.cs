using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bill_record
{
    public partial class Frm_AddUser : Form
    {
        public string _connectionString;
        int maxSerial = 0;
        public Frm_AddUser()
        {
            InitializeComponent();
        }

        private void Frm_AddUser_Load(object sender, EventArgs e)
        {
            object max;
            string queryMax = "select  max(acc_uid) from tbl_access ";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand(queryMax, conn))
                {
                    max = com.ExecuteScalar();
                }
            }
            int.TryParse(max.ToString(), out maxSerial);
            txt_uid.Text = (maxSerial + 1).ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            RecalcMask pass = new RecalcMask();
            StringBuilder sqlText = new StringBuilder();
            sqlText.Append("insert into  ");
            sqlText.Append("	tbl_access  ");
            sqlText.Append("		(acc_uname, ");
            sqlText.Append("		acc_upassword, ");
            sqlText.Append("		acc_ulevel, ");
            sqlText.Append("		acc_ustate, ");
            sqlText.Append("		acc_uvalid,acc_uid) ");
            sqlText.Append("values ");
            sqlText.AppendFormat("	('{0}','{1}',{2},0,1,{3}) ",txt_username.Text,pass.CalcMask(txt_mask.Text),cmb_userLevel.Text,maxSerial+1);
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sqlText.ToString(), con))
                {
                    int i = -1;
                    i = com.ExecuteNonQuery();
                    if (i <= 0)
                    {
                        MessageBox.Show("失败");
                    }
                    else
                    {
                        MessageBox.Show("成功");
                    }
                }
            }
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_username_Validated(object sender, EventArgs e)
        {
            //是否有同名用户，需要校验一下
            StringBuilder sqlText = new StringBuilder();
            sqlText.Append("select acc_uid from tbl_access where acc_uname = '"+txt_username.Text+"'");
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sqlText.ToString(), con))
                {
                    object ob = null;
                    ob = com.ExecuteScalar();
                    if(ob != null)
                    {
                        label5.Text = "已被占用！";
                        //txt_username.Clear();
                    }
                    else
                    {
                        label5.Text = "";
                    }
                }
            }
        }
    }    
}

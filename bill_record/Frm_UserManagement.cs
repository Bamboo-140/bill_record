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
using WeifenLuo.WinFormsUI.Docking;

namespace bill_record
{
    public partial class Frm_UserManagement : DockContent
    {
        public string _connectString ;
        public string _userName;
        public int _userid;
        public int _userLevel;
        public Frm_UserManagement()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            //校验用户原始密码是否正确
            StringBuilder sqlText = new StringBuilder();
            RecalcMask pass = new RecalcMask();
            sqlText.AppendFormat("SELECT " +
               "                           isnull(acc_uname,'-1') as acc_uname "+
               "                    FROM tbl_access " +
               "                    WHERE " +
                                   "acc_uid = {0} " +
                                   "AND acc_uvalid = 1 " +
                                   "AND acc_ustate = 0 " +
                                   "AND acc_upassword = '{1}' ",
               (string.IsNullOrWhiteSpace(txt_userid.Text) ? "(-1)" : txt_userid.Text), pass.CalcMask(txt_password.Text));
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                object o;

                conn.Open();
                using (SqlCommand com = new SqlCommand(sqlText.ToString(), conn))
                {
                    o = com.ExecuteScalar();
                    if (o == null)
                    {
                        MessageBox.Show("修改失败，请校验ID及密码！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }   
                }
               
                    sqlText.Remove(0, sqlText.Length);
                    sqlText.Append("update ");
                    sqlText.Append("    tbl_access ");
                    sqlText.Append("set ");
                    sqlText.AppendFormat("    acc_uname = '{0}', ", (string.IsNullOrWhiteSpace(txt_username.Text) ? _userName : txt_username.Text));
                    sqlText.AppendFormat("    acc_upassword = '{0}' ", pass.CalcMask(txt_newPass.Text));
                    sqlText.Append("where ");
                    sqlText.AppendFormat("    acc_uid = {0} ", txt_userid.Text);
                using (SqlCommand com = new SqlCommand(sqlText.ToString(), conn))
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
            //校验新密码和确认密码是否一致
            //提交数据库变更
        }

        private void txt_reEnter_TextChanged(object sender, EventArgs e)
        {
            //check_password(txt_reEnter);
        }
        private void check_password(Control control)
        {
            if (!txt_reEnter.Text.Equals(txt_newPass.Text))
            {
                errorProvider1.SetError(control, "两次密码不符！");
                control.ForeColor = Color.Red;
                btn_submit.Enabled = false;
            }
            else
            {
                control.ForeColor = Color.Black;
                btn_submit.Enabled = true;
                errorProvider1.Clear();
            }
        }

        private void txt_newPass_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_reEnter.Text))
            {
                check_password(txt_reEnter);
            }
        }

        private void txt_reEnter_Validated(object sender, EventArgs e)
        {
            check_password(txt_reEnter);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_UserManagement_Load(object sender, EventArgs e)
        {
            query();
            txt_userid.Text = _userid.ToString();
            txt_username.Text = _userName;
            if(_userLevel < 3)
            {
                tabControl1.TabPages.Remove(tabPage2);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
 
            if(btn_edit.Text.Equals("编辑"))
            {
                btn_edit.Text = "保存";
                dgv_userview.ReadOnly = false;
                btn_reject.Enabled = true;
                btn_delete.Enabled = true;
            }
            else
            {
                btn_edit.Text = "编辑";
                dgv_userview.ReadOnly = true;
                btn_reject.Enabled = false;
                btn_delete.Enabled = false;
                int i = 0;
                i = DataHelper.Update_dataSet(xsd_UserManagement, "tbl_access",_connectString);
                if (i < 0)
                {
                    MessageBox.Show("更新失败！");
                }
                else if (i == 0)
                {
                    MessageBox.Show("没有要更新的数据！");
                }
                else
                {
                    MessageBox.Show("更新成功！");
                }
            }
        }

        ///// <summary>
        ///// 获取更新并提交更改到数据库
        ///// </summary>
        ///// <returns>成功返回值为更新数量;失败返回 -1;0没有要更新的数据</returns>
        //private int Update_dataSet(DataSet dataSet, string dataTable)
        //{
        //    //dataSet.AcceptChanges();
        //    int count = -1;

        //    DataSet change = new DataSet();
        //    change = dataSet.GetChanges();
        //    if (change == null)
        //    {
        //        //MessageBox.Show("没有更改任何数据！");
        //        count = 0;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            using (SqlConnection conn = new SqlConnection(_connectString))
        //            {
        //                conn.Open();
        //                string queyText = "SELECT * FROM " + dataTable.Trim();
        //                using (SqlDataAdapter da = new SqlDataAdapter(queyText, conn))
        //                {
        //                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
        //                    count = da.Update(change, dataTable);
        //                }
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    }

        //    return count;
        //}

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlText = "update tbl_access set acc_uvalid = 0 where acc_uid = " + dgv_userview[0, dgv_userview.CurrentRow.Index].Value;
                //dgv_expend_view[6, dgv_expend_view.CurrentRow.Index].Value = false;
                using (SqlConnection conn = new SqlConnection(_connectString))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(sqlText, conn))
                    {
                        int i = 0;
                        i = com.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("删除成功！");
                        else
                            MessageBox.Show("没有执行删除命令");
                    }
                }
            }
            catch
            {

            }
            query();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Frm_AddUser adduser = new Frm_AddUser();
            adduser._connectionString = _connectString;
            adduser.ShowDialog();
            query();
        }

        private void btn_reject_Click(object sender, EventArgs e)
        {
            xsd_UserManagement.RejectChanges();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            query();
        }
        private void query()
        {
                StringBuilder sqlText = new StringBuilder();
                try
                {
                    sqlText.Append("select * from tbl_access where acc_uid <> 0 ");
                    if(!chk_all.Checked)
                    {
                        sqlText.Append(" and acc_uvalid = 1 ");
                    }
                    using (SqlConnection con = new SqlConnection(_connectString))
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(sqlText.ToString(), con))
                        {
                            xsd_UserManagement.tbl_access.Clear();
                            da.Fill(xsd_UserManagement, "tbl_access");
                        }
                    }
                }
                catch
                {
                    // MessageBox.Show(ex.Message);
                }
            }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            query();
        }
    }
}

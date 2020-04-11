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
using System.Collections;
using System.Configuration;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using WeifenLuo.WinFormsUI.Docking;

namespace bill_record
{
    public partial class frm_income : DockContent
    {
        //自定义控件
        #region
        //全局变量区
        public int _userID;     //用户ID
        public string _userName;
        public int _userLevel; //用户等级
        public int _userState = 0;
        public int _userValid = 0;
        public Boolean _view_all = false;
        #endregion

        DateTimePicker dtp = new DateTimePicker();
        ComboBox cmb_type = new ComboBox();
        string filterReg = "Excel 2003兼容格式|*.xls|Excel 2007文件格式|*.xlsx";
        private bool editFlag = false;

        private string _connectString = string.Empty;// ConfigurationManager.ConnectionStrings["mycon"].ToString();

        public frm_income()
        {
            InitializeComponent();
        }

        private void dgv_income_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            dgv_income_view.ReadOnly = false;
            DataRow dRow = xsd_income_view.tbl_income.NewRow();
            dRow["inc_date"] = DateTime.Now.ToString("yyyy/MM/dd");
            dRow["inc_amount"] = 0;
            dRow["inc_valid"] = true;
            dRow["inc_record"] = _userName;
            if (chk_only_public.Checked)
            {
                dRow["inc_public"] = true;
            }
            else
            {
                dRow["inc_public"] = false;
            }
            
            xsd_income_view.tbl_income.Rows.Add(dRow);
         }

        private void dgv_income_view_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_type.Text = dgv_income_view[2, dgv_income_view.CurrentRow.Index].Value.ToString();
                dtp.Value = DateTime.Parse(dgv_income_view[1, dgv_income_view.CurrentRow.Index].Value.ToString());
                //MessageBox.Show("当前行号是：("+dgv_income_view.CurrentRow.Index.ToString()+")");
                dtp.Visible = false;
                //if (dgv_income_view.CurrentRow.Index >= 0)
                {
                    if (dgv_income_view.CurrentCell.ColumnIndex == 1)
                    {
                        cmb_type.Visible = false;
                        Rectangle rec = dgv_income_view.GetCellDisplayRectangle(dgv_income_view.CurrentCell.ColumnIndex, dgv_income_view.CurrentCell.RowIndex, false);
                        dtp.Height = rec.Height;
                        dtp.Width = rec.Width;
                        dtp.Location = new Point(rec.X, rec.Y);
                        dgv_income_view.Controls.Add(dtp);
                        //dgv_income_view[1, dgv_income_view.CurrentRow.Index].Value = dtp.Value.ToString("yyyy/MM/dd").Trim();
                        dtp.Visible = true;
                    }
                    else if (dgv_income_view.CurrentCell.ColumnIndex == 2)
                {
                    dtp.Visible = false;
                    Rectangle rec = dgv_income_view.GetCellDisplayRectangle(dgv_income_view.CurrentCell.ColumnIndex, dgv_income_view.CurrentRow.Index, false);
                    cmb_type.Height = rec.Height;
                    cmb_type.Width = rec.Width;
                    cmb_type.Location = new Point(rec.X, rec.Y);
                    dgv_income_view.Controls.Add(cmb_type);
                    //dgv_income_view[2, dgv_income_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
                    cmb_type.Visible = true;
                }
                else
                {
                    cmb_type.Visible = false;
                }
                }
               
            }
            catch
            {
             
            }
        }
        private void dtp_begin_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_end.Value < dtp_begin.Value)
            {
                dtp_end.Value = dtp_begin.Value;
            }
        }

        #region 自定义控件方法
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            //dgv_income_view.CurrentCell.Value = dtp.Value.ToString("yyyy/MM/dd");
            dgv_income_view[1,dgv_income_view.CurrentRow.Index].Value = dtp.Value.ToString("yyyy/MM/dd");
        }

        private void cmb_type_ValueChanged(object sender, EventArgs e)
        {
            dgv_income_view[2, dgv_income_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
        }


        private void cmb_type_Validating(object sender, EventArgs e)
        {
            dgv_income_view[2, dgv_income_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
        }

        private void cmb_type_MouseDown(object sender, EventArgs e)
        {
            dgv_income_view[2, dgv_income_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
        }
        #endregion

        private void frm_income_Load(object sender, EventArgs e)
        {
            int key = CalcKey.CalcKeyFun(ConfigurationManager.AppSettings.Get("seed"));
            _connectString = CalcMask.RestoreMask(ConfigurationManager.ConnectionStrings["mycon"].ToString(), key);
            dtp.ValueChanged += new EventHandler(dtp_ValueChanged);
            cmb_type.SelectedIndexChanged += new EventHandler(cmb_type_ValueChanged);
            cmb_type.Validating += new CancelEventHandler(cmb_type_Validating);
            cmb_type.MouseDown += new MouseEventHandler(cmb_type_MouseDown);
            dtp.Enabled = false;
            cmb_type.Enabled = false;

            btn_delete.Enabled = false;
            btn_new.Enabled = false;
            btn_reject.Enabled = false;
            btn_save.Enabled = false;
            this.dtp_begin.Value = DateTime.Now.AddDays((-1)*(DateTime.Now.Day - 1));

            List<object> sourc = new List<object>();
            using (SqlConnection con = new SqlConnection(_connectString))
            {
                con.Open();
                string sqlText = "select distinct inc_source from tbl_income";
                using (SqlCommand command = new SqlCommand(sqlText, con))
                {
                    SqlDataReader dReader = command.ExecuteReader();
                    while (dReader.Read())
                    {
                        sourc.Add(dReader["inc_source"]);
                    }
                }
            }
            cmb_type.Items.AddRange(sourc.ToArray());
            cmb_source.Items.AddRange(sourc.ToArray());
            do_query();
        }

        //用户权限校验函数
        private bool check_userLeve(int level)
        {
            bool result;
            result = level >= 3 ? true : false;
            return result;
        }

        private void dgv_income_view_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
            cmb_type.Visible = false;
        }

        private void dgv_income_view_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            

            //权限校验
            int i = DataHelper.Update_dataSet(xsd_income_view, "tbl_income",_connectString);
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
            do_query();
            editFlag = false;
            checkEdit();
            //btn_delete.Enabled = false;
            //btn_new.Enabled = false;
            //btn_reject.Enabled = false;
            //btn_save.Enabled = false;
        }
        #region
        ///// <summary>
        ///// 获取更新并提交更改到数据库
        ///// </summary>
        ///// <returns>成功返回值为更新数量;失败返回 -1;0没有要更新的数据</returns>
        //private int Update_dataSet(DataSet dataSet,string dataTable)
        //{
        //    //dataSet.AcceptChanges();
        //    int count = -1;

        //    DataSet change = new DataSet();
        //    change = dataSet.GetChanges();
        //    if (change == null)
        //    {
        //        //MessageBox.Show("没有更改任何数据！");
        //       count = 0;
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
        //                    count = da.Update(change,dataTable);
        //                }
        //            }
        //        }
        //        catch
        //        { }
        //    }

        //    return count;
        //}
        #endregion
        private void btn_query_Click(object sender, EventArgs e)
        {
            do_query();
        }

        private void do_query()
        {

            dtp.Visible = false;
            cmb_type.Visible = false;

            double temp = 0;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlText.Append("select * from tbl_income where 1 = 1 ");
                if (chk_date.Checked)
                {
                    sqlText.AppendFormat(" and convert(varchar(10),inc_date,120) between convert(varchar(10),cast('{0}'as datetime ),120) and convert(varchar(10),cast('{1}'as datetime ),120) ", dtp_begin.Value, dtp_end.Value);
                }
                if (!chk_valid.Checked)
                {
                    sqlText.Append(" and inc_valid = 1 and inc_monthly = 0");
                    
                }
                else
                {
                    sqlText.Append(" and inc_valid = 1  ");
                }
                if(chk_only_public.Checked)
                {
                    sqlText.Append(" and inc_public = 1");
                }
                else
                {
                    sqlText.Append(" and inc_public = 0");
                }
                if (!String.IsNullOrEmpty(cmb_source.Text.Trim()))
                {
                    sqlText.Append(" and inc_source = '" + cmb_source.Text.Trim() + "'");
                }
                if (double.TryParse(txt_amountBegin.Text,out temp) && double.TryParse(txt_amountEnd.Text,out temp))
                {
                    sqlText.AppendFormat(" and inc_amount between {0} and {1} ", txt_amountBegin.Text.Trim(), txt_amountEnd.Text.Trim());
                }
                else if (!String.IsNullOrWhiteSpace(txt_amountEnd.Text.Trim()))
                {
                    if (string.IsNullOrWhiteSpace(txt_amountBegin.Text))
                    {
                        sqlText.AppendFormat(" and inc_amount = {0} ", txt_amountEnd.Text);
                        txt_amountBegin.Text = "=";
                    }
                    else
                    {
                        sqlText.AppendFormat(" and inc_amount {0} {1} ", txt_amountBegin.Text.Trim(), txt_amountEnd.Text);
                    }
                }
                //是否只显示当前用户的数据
                if(!(_view_all || _userID == 0))
                {
                    sqlText.AppendFormat(" and inc_record = '{0}'",_userName);
                }
                using (SqlConnection con = new SqlConnection(_connectString))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlText.ToString(), con))
                    {
                        xsd_income_view.tbl_income.Clear();
                        da.Fill(xsd_income_view, "tbl_income");
                    }
                }
            }
            catch
            {
                // MessageBox.Show(ex.Message);
            }
        }
        private void btn_reject_Click(object sender, EventArgs e)
        {
            xsd_income_view.RejectChanges();
            editFlag = false;
            checkEdit();
            //dgv_income_view.ReadOnly = true;
            //dtp.Enabled = false;
            //cmb_type.Enabled = false;
            //btn_delete.Enabled = false;
            //btn_new.Enabled = false;
            //btn_reject.Enabled = false;
            //btn_save.Enabled = false;
        }

        private void txt_amountBegin_TextChanged(object sender, EventArgs e)
        {
          //  double d = 0;
          //if(!(Double.TryParse(txt_amountBegin.Text, out d)
          //          ||txt_amountBegin.Text.Trim().Equals(">") 
          //          || txt_amountBegin.Text.Trim().Equals(">=")
          //          || txt_amountBegin.Text.Trim().Equals("=") 
          //          || txt_amountBegin.Text.Trim().Equals("<=")
          //          || txt_amountBegin.Text.Trim().Equals("<")))
          //  {
          //      txt_amountBegin.Clear();
          //  }
        }

        private void txt_amountBegin_Validated(object sender, EventArgs e)
        {
            double d = 0;
            if (!(Double.TryParse(txt_amountBegin.Text, out d)
                      || txt_amountBegin.Text.Trim().Equals(">")
                      || txt_amountBegin.Text.Trim().Equals(">=")
                      || txt_amountBegin.Text.Trim().Equals("=")
                      || txt_amountBegin.Text.Trim().Equals("<=")
                      || txt_amountBegin.Text.Trim().Equals("<")))
            {
                txt_amountBegin.Clear();
                errorProvider1.SetError(txt_amountBegin, "只能是数字或比较运算符：<、>、<=、<= ");
            }
            else
                errorProvider1.Clear();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            // dgv_income_view[4, dgv_income_view.CurrentRow.Index].Value = false;

            string sqlText = "update tbl_income set inc_valid = 0 ,inc_operate = '"+_userName+"' where inc_serial = " + dgv_income_view[0, dgv_income_view.CurrentRow.Index].Value;
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
            do_query();
        }



        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (check_userLeve(_userLevel))
            {
                editFlag = true;
                checkEdit();
            }
            else
            {
                MessageBox.Show("对不起，您没有编辑权限，请联系系统管理员！");
            }
            //dgv_income_view.ReadOnly = false;
            //cmb_type.Enabled = true;
            //dtp.Enabled = true;
            //btn_delete.Enabled = true;
            //btn_new.Enabled = true;
            //btn_reject.Enabled = true;
            //btn_save.Enabled = true;
        }

 
        private void checkEdit()
        {
            dgv_income_view.ReadOnly = !editFlag;
            cmb_type.Enabled = editFlag;
            dtp.Enabled = editFlag;
            btn_delete.Enabled = editFlag;
            btn_new.Enabled = editFlag;
            btn_reject.Enabled = editFlag;
            btn_save.Enabled = editFlag;
        }

        private void txt_amountEnd_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_amountEnd.Text))
            {
                if (is_number(txt_amountEnd.Text))
                {
                    errorProvider1.SetError(txt_amountEnd, "只能是数字！");
                    txt_amountEnd.Clear();
                }
            }
        }

        private bool is_number(string s)
        {

            double tmp = 0.0;
            return double.TryParse(s, out tmp);
        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_end.Value < dtp_begin.Value)
            {
                dtp_begin.Value = dtp_end.Value;
            }
        }

        public void btn_export2Excel_Click(object sender, EventArgs e)
        {
            //创建保存对话框
            SaveFileDialog saveFile = new SaveFileDialog();
            //设置文件过滤器
            saveFile.Filter = filterReg;
            //保存用户的操作
            DialogResult isSave = new DialogResult();
            isSave = saveFile.ShowDialog();
            if (DialogResult.OK == isSave && saveFile.FileName != null)
            {
                ExcelHelper.ExportExcel(dgv_income_view, true, saveFile.FileName);
            }
        }
        private void frm_income_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xsd_income_view.GetChanges() != null && editFlag)
            {
                //DataHelper dh = new DataHelper();

                DialogResult dResult =
                MessageBox.Show("数据有更改是否要保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dResult == DialogResult.Yes)
                {
                    DataHelper.Update_dataSet(xsd_income_view, "tbl_income",_connectString);
                }
                else if (dResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

 

        private void chk_date_CheckedChanged(object sender, EventArgs e)
        {
            dtp_begin.Enabled = chk_date.Checked;
            dtp_end.Enabled = chk_date.Checked;
        }

        private void chk_only_public_CheckedChanged(object sender, EventArgs e)
        {
            do_query();
        }

        private void chk_valid_CheckedChanged(object sender, EventArgs e)
        {
                this.btn_edit.Enabled = !chk_valid.Checked;
                editFlag = !chk_valid.Checked;
        }


        //如有问题欢迎大家指正

    }
}

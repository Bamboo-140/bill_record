﻿using System;
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
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using WeifenLuo.WinFormsUI.Docking;

namespace bill_record
{
    public partial class frm_expend : DockContent
    {
        public frm_expend()
        {
            InitializeComponent();
        }

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
        ComboBox cmb_item = new ComboBox();
        ComboBox cmb_type = new ComboBox();
        NumericUpDown num = new NumericUpDown();
        
        string filterReg = "Excel 2003兼容格式|*.xls|Excel 2007文件格式|*.xlsx";
        private bool editFlag = false;

        private string _connectString = string.Empty;//= ConfigurationManager.ConnectionStrings["mycon"].ToString();

        #region 自定义控件方法
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            //dgv_income_view.CurrentCell.Value = dtp.Value.ToString("yyyy/MM/dd");
            dgv_expend_view[1, dgv_expend_view.CurrentRow.Index].Value = dtp.Value.ToString("yyyy/MM/dd");
        }

        private void cmb_item_ValueChanged(object sender, EventArgs e)
        {
            dgv_expend_view[3, dgv_expend_view.CurrentRow.Index].Value = cmb_item.Text.Trim();
        }

        private void cmb_type_ValueChanged(object sender, EventArgs e)
        {
            dgv_expend_view[2, dgv_expend_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
        }

        private void cmb_item_MouseDown(object sender, EventArgs e)
        {
            dgv_expend_view[3, dgv_expend_view.CurrentRow.Index].Value = cmb_item.Text.Trim();
        }
        private void cmb_type_MouseDown(object sender, EventArgs e)
        {
            dgv_expend_view[2, dgv_expend_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
        }

        #endregion

        private void btn_Query_Click(object sender, EventArgs e)
        {
            do_query();
        }

        private void do_query()
        {

            txt_remain.Text = "0";
            txt_incomeAmount.Text = "0";
            txt_countAmount.Text = "0";
            dtp.Visible = false;
            cmb_item.Visible = false;
            cmb_type.Visible = false;
            num.Visible = false;
            double temp = 0;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlText.Append("select * from tbl_expend where 1 = 1 ");
                if (chk_date.Checked)
                {
                    sqlText.AppendFormat(" and exp_date between convert(varchar(10),cast('{0}'as datetime ),120) and convert(varchar(10),cast('{1}'as datetime ),120) ", dtp_begin.Value, dtp_end.Value);
                }
                if (!chk_valid.Checked)
                {
                    sqlText.Append(" and exp_valid = 1 and exp_monthly = 0");
                }
                else
                {
                    sqlText.Append(" and exp_valid = 1 ");
                }

                if (chk_only_public.Checked)
                {
                    sqlText.Append(" and exp_public = 1");
                }
                else
                {
                    sqlText.Append(" and exp_public = 0");
                }
                //读取设置是否显示全部
                if(!_view_all)
                {
                    sqlText.AppendFormat(" and exp_record = '{0}'",_userID);
                }

                if (!String.IsNullOrEmpty(cmb_itemtype.Text.Trim()))
                {
                    sqlText.Append(" and exp_type = '" + cmb_itemtype.Text.Trim() + "'");
                }
                if (double.TryParse(txt_amountBegin.Text,out temp) && double.TryParse(txt_amountEnd.Text,out temp))
                {
                    sqlText.AppendFormat(" and exp_amount between {0} and {1} ", txt_amountBegin.Text.Trim(), txt_amountEnd.Text.Trim());
                }
                else if (!String.IsNullOrWhiteSpace(txt_amountEnd.Text.Trim()))
                {
                    if (string.IsNullOrWhiteSpace(txt_amountBegin.Text))
                    {
                        txt_amountBegin.Text = "=";
                        sqlText.AppendFormat(" and (exp_count*exp_price) = {0} ", txt_amountEnd.Text);
                    }
                    else
                    {
                        sqlText.AppendFormat(" and (exp_count*exp_price) {0} {1} ", txt_amountBegin.Text.Trim(), txt_amountEnd.Text);
                    }
                }
                if(!(_view_all || _userID == 0))
                {
                    sqlText.AppendFormat(" and exp_record = '{0}'",_userName);
                }
                using (SqlConnection con = new SqlConnection(_connectString))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlText.ToString(), con))
                    {
                        xsd_expend_view.tbl_expend.Clear();
                        da.Fill(xsd_expend_view, "tbl_expend");
                    }
                }
                collect();
            }
            catch
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void chk_date_CheckedChanged(object sender, EventArgs e)
        {
            dtp_begin.Enabled = chk_date.Checked;
            dtp_end.Enabled = chk_date.Checked;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            //dgv_expend_view.ReadOnly = false;
            DataRow dRow = xsd_expend_view.tbl_expend.NewRow();
            dRow["exp_date"] = DateTime.Now.ToString("yyyy/MM/dd");
            dRow["exp_price"] = 0;            
            dRow["exp_count"] = 0;
            dRow["exp_valid"] = true;
            dRow["exp_level"] = 0;
            dRow["exp_record"] = _userName;
            if (chk_only_public.Checked)
            {
                dRow["exp_public"] = true;
            }
            else
            {
                dRow["exp_public"] = false;
            }
            xsd_expend_view.tbl_expend.Rows.Add(dRow);
        }

        private void dtp_dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if(dtp_end.Value < dtp_begin.Value)
            {
                dtp_end.Value = dtp_begin.Value;
            }
        }

        private void dtp_dateBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_end.Value < dtp_begin.Value)
            {
                dtp_begin.Value = dtp_end.Value;
            }
        }

       


        private void dgv_expend_view_CurrentCellChanged(object sender, EventArgs e)
        {

            try
            {
                cmb_item.Text = dgv_expend_view[3, dgv_expend_view.CurrentRow.Index].Value.ToString();
                cmb_type.Text = dgv_expend_view[2, dgv_expend_view.CurrentRow.Index].Value.ToString();
                dtp.Value = DateTime.Parse(dgv_expend_view[1, dgv_expend_view.CurrentRow.Index].Value.ToString());
                num.Value = int.Parse(dgv_expend_view[4, dgv_expend_view.CurrentRow.Index].Value.ToString());
                //MessageBox.Show("当前行号是：("+dgv_expend_view.CurrentRow.Index.ToString()+")");
                dtp.Visible = false;
                //if (dgv_expend_view.CurrentRow.Index >= 0)
                {
                    if (dgv_expend_view.CurrentCell.ColumnIndex == 1)
                    {
                       cmb_item.Visible = false;
                        cmb_type.Visible = false;
                        num.Visible = false;
                        Rectangle rec = dgv_expend_view.GetCellDisplayRectangle(dgv_expend_view.CurrentCell.ColumnIndex, dgv_expend_view.CurrentCell.RowIndex, false);
                        dtp.Height = rec.Height;
                        dtp.Width = rec.Width;
                        dtp.Location = new Point(rec.X, rec.Y);
                        dgv_expend_view.Controls.Add(dtp);
                        //dgv_expend_view[1, dgv_expend_view.CurrentRow.Index].Value = dtp.Value.ToString("yyyy/MM/dd").Trim();
                        dtp.Visible = true;
                    }

                    else if (dgv_expend_view.CurrentCell.ColumnIndex == 2)
                    {
                        dtp.Visible = false;
                        cmb_item.Visible = false;
                        num.Visible = false;
                        Rectangle rec = dgv_expend_view.GetCellDisplayRectangle(dgv_expend_view.CurrentCell.ColumnIndex, dgv_expend_view.CurrentCell.RowIndex, false);
                        cmb_type.Height = rec.Height;
                        cmb_type.Width = rec.Width;
                        cmb_type.Location = new Point(rec.X, rec.Y);
                        dgv_expend_view.Controls.Add(cmb_type);
                        //dgv_expend_view[1, dgv_expend_view.CurrentRow.Index].Value = dtp.Value.ToString("yyyy/MM/dd").Trim();
                        cmb_type.Visible = true;
                    }

                    else if(dgv_expend_view.CurrentCell.ColumnIndex == 4)
                    {
                        
                        dtp.Visible = false;
                        cmb_item.Visible = false;
                        cmb_type.Visible = false;
                        Rectangle rec = dgv_expend_view.GetCellDisplayRectangle(dgv_expend_view.CurrentCell.ColumnIndex, dgv_expend_view.CurrentRow.Index, false);
                        num.Width = rec.Width;
                        num.Height = rec.Height;
                        num.Location = new Point(rec.X, rec.Y);
                        dgv_expend_view.Controls.Add(num);
                        num.Visible = true;
                    }
                    else if (dgv_expend_view.CurrentCell.ColumnIndex == 3)
                    {
                        dtp.Visible = false;
                        cmb_type.Visible = false;
                        num.Visible = false;
                        
                        Rectangle rec = dgv_expend_view.GetCellDisplayRectangle(dgv_expend_view.CurrentCell.ColumnIndex, dgv_expend_view.CurrentRow.Index, false);
                       cmb_item.Height = rec.Height;
                       cmb_item.Width = rec.Width;
                       cmb_item.Location = new Point(rec.X, rec.Y);
                        dgv_expend_view.Controls.Add(cmb_item);
                        //dgv_expend_view[2, dgv_income_view.CurrentRow.Index].Value =cmb_item.Text.Trim();
                       cmb_item.Visible = true;
                    }
                    else
                    {
                       cmb_item.Visible = false;
                        dtp.Visible = false;
                        cmb_type.Visible = false;
                        num.Visible = false;
                    }
                }

            }
            catch
            {

            }
        }

        private void frm_expend_Load(object sender, EventArgs e)
        {
            int key = CalcKey.CalcKeyFun(ConfigurationManager.AppSettings.Get("seed"));
            _connectString = CalcMask.RestoreMask(ConfigurationManager.ConnectionStrings["mycon"].ToString(), key);
            dtp.ValueChanged += new EventHandler(dtp_ValueChanged);
            cmb_item.SelectedIndexChanged += new EventHandler(cmb_item_ValueChanged);
            cmb_item.MouseDown += new MouseEventHandler(cmb_type_MouseDown);
            cmb_item.Validating += new CancelEventHandler(cmb_item_Validating);

            cmb_type.SelectedIndexChanged += new EventHandler(cmb_type_ValueChanged);
            cmb_type.SelectedValueChanged += new EventHandler(cmb_type_ValueChanged);
            cmb_type.Validating += new CancelEventHandler(cmb_type_Validating);
            num.ValueChanged += new EventHandler(num_ValueChanged);

            dtp.Enabled = false;
            cmb_item.Enabled = false;
            cmb_type.Enabled = false;
            num.Enabled = false;

            btn_delete.Enabled = false;
            btn_new.Enabled = false;
            btn_reject.Enabled = false;
            btn_save.Enabled = false;
            num.DecimalPlaces = 4;
            num.Increment = 0.0001M;
            this.dtp_begin.Value = DateTime.Now.AddDays((-1) * (DateTime.Now.Day - 1));

            List<object> sourc = new List<object>();
            using (SqlConnection con = new SqlConnection(_connectString))
            {
                con.Open();
                string sqlText = "select distinct exp_item from tbl_expend";
                using (SqlCommand command = new SqlCommand(sqlText, con))
                {
                    SqlDataReader dReader = command.ExecuteReader();
                    while (dReader.Read())
                    {
                        sourc.Add(dReader["exp_item"]);
                    }
                }
            }
            cmb_item.Items.AddRange(sourc.ToArray());

            sourc.Clear();

            using (SqlConnection con = new SqlConnection(_connectString))
            {
                con.Open();
                string sqlText = "select distinct exp_type from tbl_expend";
                using (SqlCommand command = new SqlCommand(sqlText, con))
                {
                    SqlDataReader dReader = command.ExecuteReader();
                    while (dReader.Read())
                    {
                        sourc.Add(dReader["exp_type"]);
                    }
                }
            }
            cmb_type.Items.AddRange(sourc.ToArray());
            cmb_itemtype.Items.AddRange(sourc.ToArray());
            do_query();
            toolStripStatusLabel1.Text = "当前用户："+ _userName;
            toolStripStatusLabel2.Text = "就绪";
        }

        private void cmb_type_Validating(object sender, EventArgs e)
        {
            dgv_expend_view[2, dgv_expend_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            dgv_expend_view[4, dgv_expend_view.CurrentRow.Index].Value = num.Value.ToString().Trim();
        }

        private void Cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_expend_view[2, dgv_expend_view.CurrentRow.Index].Value = cmb_type.Text.Trim();
        }

        private void cmb_item_Validating(object sender, EventArgs e)
        {
            dgv_expend_view[3, dgv_expend_view.CurrentRow.Index].Value = cmb_item.Text.Trim();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
      
            try
            {
                string sqlText = "update tbl_expend set exp_valid = 0,exp_operate = '"+_userName+"' where exp_serial = " + dgv_expend_view[0, dgv_expend_view.CurrentRow.Index].Value;
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
                editFlag = false;
                checkEdit();
                do_query();
            }
            catch
            {
                
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
            
            int i = 0;
            i = DataHelper.Update_dataSet(xsd_expend_view, "tbl_expend",_connectString);
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
            //dtp.Enabled = false;
            //cmb_item.Enabled = false;
            //cmb_type.Enabled = false;
            //num.Enabled = false;
            //dgv_expend_view.ReadOnly = true;
            //btn_delete.Enabled = false;
            //btn_new.Enabled = false;
            //btn_reject.Enabled = false;
            //btn_save.Enabled = false;
        }

        private bool check_userLeve( int level)
        {
            bool result;
            result = level >= 3 ? true:false;
            return result;
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if(check_userLeve(_userLevel))
            {
                editFlag = true;
                checkEdit();
            }
            else
            {
                MessageBox.Show("对不起，您没有编辑权限，请联系系统管理员！");
            }
        
            //dgv_expend_view.ReadOnly = false;
            //dtp.Enabled = true;
            //cmb_item.Enabled = true;
            //cmb_type.Enabled = true;
            //num.Enabled = true;
            ////dtp.Visible = true;
            //btn_delete.Enabled = true;
            //btn_new.Enabled = true;
            //btn_reject.Enabled = true;
            //btn_save.Enabled = true;
        }

        private void checkEdit()
        {
            dgv_expend_view.ReadOnly = !editFlag;
            dtp.Enabled = editFlag;
            cmb_item.Enabled = editFlag;
            cmb_type.Enabled = editFlag;
            num.Enabled = editFlag;
            //dtp.Visible = true;
            btn_delete.Enabled = editFlag;
            btn_new.Enabled = editFlag;
            btn_reject.Enabled = editFlag;
            btn_save.Enabled = editFlag;
            if (editFlag)
            {
                toolStripStatusLabel2.Text = "编辑";
            }
            else
            {
                toolStripStatusLabel2.Text = "就绪";
            }
        }

        private void btn_reject_Click(object sender, EventArgs e)
        {
            xsd_expend_view.RejectChanges();
            //btn_delete.Enabled = false;
            //btn_new.Enabled = false;
            //btn_reject.Enabled = false;
            //btn_save.Enabled = false;
            //dtp.Enabled = false;
            //cmb_item.Enabled = false;
            //cmb_type.Enabled = false;
            //num.Enabled = false;
            //dgv_expend_view.ReadOnly = true;
            editFlag = false;
            checkEdit();
            do_query();
        }

        private void txt_amountBegin_Validating(object sender, CancelEventArgs e)
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

        private void txt_amountBegin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_amountEnd_TextChanged(object sender, EventArgs e)
        {

        }
        private bool is_number(string s)
        {
            
            double tmp = 0.0;
            return double.TryParse(s,out tmp);
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

        private void frm_expend_FormClosing(object sender, FormClosingEventArgs e)
        {
           
                if (xsd_expend_view.GetChanges() != null && editFlag)
                {
                    DialogResult dResult =
                    MessageBox.Show("数据有更改是否要保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dResult == DialogResult.Yes)
                    {
                        DataHelper.Update_dataSet(xsd_expend_view, "tbl_expend",_connectString);
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

        ////传入DataGridView
        ///// <summary>
        ///// 输出数据到Excel
        ///// </summary>
        ///// <param name="dataGridView">DataGridView</param>
        ///// <param name="includeHeader">是否包含字段名</param>
        ///// <param name="savePath">保存路径</param>
        ///// <returns>成功TRUE/失败FALSE</returns>
        //public static bool ExportExcel(DataGridView dataGridView, bool includeHeader, string savePath)
        //{
        //    bool succeed = true;
        //    try
        //    {
        //        //创建工作薄
        //        IWorkbook wbook = null;
        //        //创建工作表
        //        ISheet sheet = null;
        //        wbook = ICreateIWorkBook(savePath, null);
        //        sheet = wbook.CreateSheet("Sheet1");           //创建工作表                
        //        int columnCount = dataGridView.ColumnCount;    //获取行数
        //        int rowCount = dataGridView.RowCount;          //获取列数
        //        int rowIndex = 0;
        //        IRow row = null;
        //        ICell cell;
        //        int start = 0;    //是否包含表头行数
        //        //dataGridView是否有数据
        //        if (rowCount <= 0)
        //        {
        //            succeed = false;
        //            Exception error = new Exception("无可用于导出的数据");
        //            throw error;
        //        }
        //        //是否包含表头
        //        if (includeHeader)
        //        {
        //            row = sheet.CreateRow(rowIndex);
        //            //输入标题表头行
        //            for (int i = 0; i < columnCount; i++)
        //            {
        //                cell = row.CreateCell(i);
        //                cell.SetCellValue(dataGridView.Columns[i].HeaderText);
        //            }
        //            ++start;     //如果包含表头行索引累加
        //        }

        //        //DataGridView有多少行
        //        for (; rowIndex < rowCount; ++rowIndex)
        //        {
        //            row = sheet.CreateRow(rowIndex + start);    //创建行
        //            for (int cellIndex = 0; cellIndex < columnCount; ++cellIndex)
        //            {
        //                Type type = dataGridView[cellIndex, rowIndex].ValueType;
        //                object value = dataGridView[cellIndex, rowIndex].Value;
        //                if (value == DBNull.Value)
        //                {
        //                    value = "";
        //                }
        //                cell = row.CreateCell(cellIndex);     //创建单元格
        //                //写入数据
        //                if (type == typeof(Int32))
        //                {
        //                    cell.SetCellValue((int)dataGridView[cellIndex, rowIndex].Value);
        //                }
        //                else if (type == typeof(Double))
        //                {
        //                    cell.SetCellValue((double)value);
        //                }
        //                else if (type == typeof(float))
        //                {
        //                    cell.SetCellValue((float)value);
        //                }
        //                else if (type == typeof(DateTime))
        //                {
        //                    cell.SetCellValue(((DateTime)value).ToString("yyyy-MM-dd"));
        //                }
        //                else if (type == typeof(Boolean))
        //                {
        //                    cell.SetCellValue((bool)value);
        //                }
        //                //decimal这个格式无法转换
        //                //else if (type == typeof(Decimal))
        //                //{
        //                //    cell.SetCellValue((float)value);
        //                //}
        //                else
        //                {
        //                    cell.SetCellValue((string)value);
        //                }
        //            }
        //        }
        //        //保存的文件流保存或创建
        //        FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate);
        //        wbook.Write(fs);   //写入文件
        //        wbook.Close();
        //        fs.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        succeed = false;
        //        throw ex;
        //    }
        //    return succeed;
        //}


        ///// <summary>
        ///// 根据文件格式返回表文件
        ///// </summary>
        ///// <param name="filePath">文件路径</param>
        ///// <param name="fs">文件流</param>
        ///// <returns>IWorkBook 表</returns>
        //private static IWorkbook ICreateIWorkBook(string filePath, FileStream fs)
        //{
        //    IWorkbook wbook = null;
        //    //读取用户选择的保存格式
        //    string extesion = Path.GetExtension(filePath).ToLower();
        //    if (extesion.Equals(".xlsx"))
        //    //if( saveFile.FileName.IndexOf(".xlsx") > 0);
        //    {
        //        if (null != fs)
        //        {
        //            wbook = new XSSFWorkbook(fs);
        //        }
        //        else
        //        {
        //            wbook = new XSSFWorkbook();
        //        }
        //    }
        //    else if (extesion.Equals(".xls"))
        //    //else if (saveFile.FileName.IndexOf(".xls") > 0) ;    //这种方法也可以实现但.xlsx必须在前面
        //    {
        //        if (null != fs)
        //        {
        //            wbook = new HSSFWorkbook(fs);
        //        }
        //        else
        //        {
        //            wbook = new HSSFWorkbook();
        //        }
        //    }
        //    else    //如果不是上述两种格式,因为设置了过滤器几乎不会出现下面的情况
        //    {
        //        //MessageBox.Show("对不起，您所输入的文件格式不受支持！");
        //        //return null;
        //        Exception error = new Exception("文件格式不正确!");
        //        throw error;
        //    }
        //    return wbook;
        //}

        private void btn_export2Excel_Click(object sender, EventArgs e)
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
                ExcelHelper.ExportExcel(dgv_expend_view, true, saveFile.FileName);
            }
        }

        private void dgv_expend_view_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
            cmb_item.Visible = false;
            cmb_type.Visible = false;
            num.Visible = false;
        }

        private void chk_only_public_CheckedChanged(object sender, EventArgs e)
        {
            do_query();
        }

        private void dgv_expend_view_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            collect();
        }

        private void dgv_expend_view_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex== 4 || e.ColumnIndex == 5)
            {
                collect();
            }
        }

        private void collect()
        {
            double sumValue = 0.0d;
            double total = 0.0d;
            StringBuilder sqlText = new StringBuilder();
            //查询区间内入账金额
            sqlText.Append(" select ");
            sqlText.Append(" 	isnull(sum(inc_amount),0) as amount ");
            sqlText.Append(" from ");
            sqlText.Append(" 	tbl_income");
            sqlText.Append(" where 1=1");

            sqlText.Append("    and inc_valid = 1");
            //是否公款
            if (chk_only_public.Checked)
            {
                sqlText.Append(" and inc_public= 1 ");
            }
            else
            {
                sqlText.Append(" and inc_public= 0 ");
            }
            //按日期查找 
            if (chk_date.Checked)
            {
                sqlText.AppendFormat(" and inc_date between convert(varchar(10),cast('{0}'as datetime ),120) and convert(varchar(10),cast('{1}'as datetime ),120) ", dtp_begin.Value, dtp_end.Value);
            }
            
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand(sqlText.ToString(), conn))
                {
                    total = Double.Parse(com.ExecuteScalar().ToString());
                    txt_incomeAmount.Text = total.ToString();
                }

            }

            foreach (DataGridViewRow dr in dgv_expend_view.Rows)
                {
                    sumValue += ((double)dr.Cells["expcountDataGridViewTextBoxColumn"].Value * (double)dr.Cells["exppriceDataGridViewTextBoxColumn"].Value);
                }
            txt_countAmount.Text = sumValue.ToString();
            txt_remain.Text = (total - sumValue).ToString();
        }

        private void chk_valid_CheckedChanged(object sender, EventArgs e)
        {
                editFlag = !chk_valid.Checked ;
                btn_edit.Enabled = !chk_valid.Checked;
        }
        //如有问题欢迎大家指正

    }
}

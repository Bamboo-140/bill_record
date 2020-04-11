using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Data.SqlClient;

namespace bill_record
{
    public partial class Frm_Option : DockContent
    {
        public string _connectString;
        public Frm_Option()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bds_option.EndEdit();
            int i = -1;
            i = DataHelper.Update_dataSet(xsd_option, "tbl_config", _connectString);
            if(i == 0)
            {
                MessageBox.Show("无数据更改！");
            }
            else if(i == -1)
            {
                MessageBox.Show("更改失败！");
            }
            else
            {
                MessageBox.Show("数据保存完成");
            }
        }

        private void Frm_Option_Load(object sender, EventArgs e)
        {
            query();
        }
        void query()
        {
            xsd_option.Clear();
            string sqlText = "select * from tbl_config";
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(sqlText, conn))
                {
                    da.Fill(xsd_option,"tbl_config");
                }
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            query();
        }

        private void chk_allow_minus_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_allow_all_view_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}

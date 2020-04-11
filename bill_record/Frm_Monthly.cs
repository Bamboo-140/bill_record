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
    
    public partial class Frm_Monthly : DockContent
    {
        public int _userID ;
        public string _connectString = string.Empty;
        public Frm_Monthly()
        {
            InitializeComponent();
        }

        private void btn_monthly_Click(object sender, EventArgs e)
        {
            if (dtp_month.Value >= (DateTime.Now.AddMonths(1)))
            {
                MessageBox.Show("已经做过月结了");
                return;
            }
            StringBuilder sqlText = new StringBuilder();
            int i = -1;
            /*--月结入账代码*/

            sqlText.Append(" insert into tbl_income ");
            sqlText.Append(" select");
            sqlText.Append(" 	convert(varchar(7),dateadd(month,1,max(inc_date)),120)+'-01' as inc_date,");
            sqlText.Append(" 	'月结'as inc_source,isnull(sum(inc_amount)-isnull(b.exp_amount,0),0)as inc_amount,");
            sqlText.Append(" 	1 as inc_valid,");
            sqlText.Append(" 	0 as inc_uid,");
            sqlText.Append(" 	0 as inc_public,");
            sqlText.Append(" 	'上月结转'as method,");
            sqlText.AppendFormat(" 	'{0}' as inc_record,",_userID);
            sqlText.Append(" 	0 as inc_monthly");
            sqlText.Append(" from tbl_income ");
            sqlText.Append(" 	right join ");
            sqlText.Append(" 		(");
            sqlText.Append(" 			select ");
            sqlText.Append(" 				isnull(sum(isnull(exp_count,0)*isnull(exp_price,0)),0) as exp_amount");
            sqlText.Append(" 			from tbl_expend");
            sqlText.Append(" 				where exp_valid = 1 and exp_public = 0 and convert(char(7),exp_date,120)= (select convert(varchar(7),max(inc_date),120) from tbl_income where inc_valid = 1 and inc_public = 0 )");
            sqlText.Append(" 		) b On 1=1");
            sqlText.Append(" where inc_valid =1");
            sqlText.Append(" 	and inc_public =0");
            sqlText.Append(" 	and inc_monthly = 0");
            sqlText.Append(" 	and convert(char(7),inc_date,120)= (select convert(varchar(7),max(inc_date),120) from tbl_income where inc_valid = 1 and inc_public = 0 )");
            sqlText.Append(" 	group by  b.exp_amount");


            /*--更新数据库月结标记*/
            sqlText.Append(" 	update tbl_income set inc_monthly = 1 ");
            sqlText.Append(" 	where inc_valid =1");
            sqlText.Append(" 	and inc_public =0");
            sqlText.Append(" 	and inc_monthly = 0");
            sqlText.Append(" 	and convert(char(7),inc_date,120)= (select convert(varchar(7),dateadd(month,-1,max(inc_date)),120) from tbl_income where inc_valid = 1 and inc_public = 0 )");

            /*--月结出账代码*/
            sqlText.Append(" if exists ( ");
            sqlText.Append(" 	select  ");
            sqlText.Append(" 		exp_monthly  ");
            sqlText.Append(" 	from  ");
            sqlText.Append(" 		tbl_expend ");
            sqlText.Append(" 	where exp_valid = 1 ");
            sqlText.Append(" 		and exp_public = 0 ");
            sqlText.Append(" 		and exp_monthly = 0 ");
            sqlText.Append(" 		and convert(char(7),exp_date,120)= (select convert(varchar(7),max(exp_date),120) from tbl_expend where exp_valid = 1 and exp_public = 0 ) ");
            sqlText.Append(" ) ");
            sqlText.Append(" begin ");
            sqlText.Append(" 	update  ");
            sqlText.Append(" 		tbl_expend  ");
            sqlText.Append(" 			set exp_monthly = 1  ");
            sqlText.Append(" 	where exp_valid = 1 ");
            sqlText.Append(" 	and exp_public = 0 ");
            sqlText.Append(" 	and exp_monthly = 0 ");
            sqlText.Append(" 	and convert(char(7),exp_date,120)= (select convert(varchar(7),max(exp_date),120) from tbl_expend where exp_valid = 1 and exp_public = 0 ) ");
            sqlText.Append(" end ");

            try
            {
                
                using (SqlConnection conn = new SqlConnection(_connectString))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(sqlText.ToString(), conn))
                    {
                        i = com.ExecuteNonQuery();
                    }
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (i > 0)
            {
                MessageBox.Show("成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
            InitialDate();
        }

        private void Frm_Monthly_Load(object sender, EventArgs e)
        {
            InitialDate();
        }
        void InitialDate()
        {
            object od = new object();
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand("select 	convert(varchar(7),	dateadd(month,1,max(inc_date)),120)+'-01'	from tbl_income where inc_valid = 1", conn))
                {
                    od = com.ExecuteScalar();
                }
            }
            dtp_month.Value = Convert.ToDateTime(od.ToString());
        }
    }
}

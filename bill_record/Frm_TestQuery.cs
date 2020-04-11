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
using System.Configuration;
using WeifenLuo.WinFormsUI.Docking;

namespace bill_record
{
    public partial class Frm_TestQuery : DockContent
    {
        private string _connectString = string.Empty;//ConfigurationManager.ConnectionStrings["mycon"].ToString();
        

        public Frm_TestQuery()
        {
            InitializeComponent();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            query();
        }
        private void query()
        {
            DataSet ds = new DataSet();
            StringBuilder sqlText = new StringBuilder();
            try
            {
                /*
                 * 
                 * 将要查询的数据放入临时表中，如果直接查询得到的结果将与实际数据有差异
                 * #temp1
                 * 首先判断收入表是否有当月数据
                 *      有则直接插入到临时表#temp1中
                 *      没有则将0插入到临时表#temp1中
                 * #temp2
                 * 首先判断支出表是否有当月数据
                 *      有则直接插入到临时表#temp2中
                 *      没有则将0插入到临时表#temp2中
                 * if exists()
                 * 
                 */
                DateTime dt = this.dtp_month.Value;
                int isPublic = 0, isValid = 1,isMonthly = 0;
                if(chk_public.Checked)
                {
                    isPublic = 1;
                }
                else
                {
                    isPublic = 0;
                }
                
                if (cmb_type.SelectedIndex == 0)
                {
                    sqlText.Append("  if exists( ");
                    sqlText.Append(" 	select  ");
                    sqlText.Append(" 		exp_count ");
                    sqlText.Append(" 	from ");
                    sqlText.Append(" 		tbl_expend ");
                    sqlText.Append(" 	where  ");
                    sqlText.AppendFormat(" 		exp_valid = {0} and exp_public = {1} /*and exp_monthly = {2}*/ and  convert(varchar(7),exp_date,120) = convert(varchar(7),cast('{2}'as datetime ),120)   ",isValid,isPublic/*,isMonthly*/,dt);
                    sqlText.Append(" ) ");
                    sqlText.Append(" 	begin ");
                    sqlText.Append(" 		select  ");
                    sqlText.Append(" 			exp_count,exp_price,exp_public,exp_date,exp_item,exp_valid,exp_monthly,exp_record,exp_type,exp_level");
                    sqlText.Append(" 		into temp1 ");
                    sqlText.Append(" 		from ");
                    sqlText.Append(" 			tbl_expend ");
                    sqlText.Append(" 		where  ");
                    sqlText.AppendFormat(" 			exp_valid = {0} and exp_public = {1}/* and exp_monthly = {2}*/ and  convert(varchar(7),exp_date,120) = convert(varchar(7),cast('{2}'as datetime ),120)   ",isValid,isPublic/*,isMonthly*/,dt);
                    sqlText.Append(" 	end ");
                    sqlText.Append(" else ");
                    sqlText.Append(" 	begin ");
                    sqlText.AppendFormat(" 		select 0 as exp_count,0 as exp_price,'{0}' as exp_date,'' as exp_item  ,{1} as exp_valid,{2} as exp_monthly,0 as exp_record,'' as exp_type,0 as exp_level,{3} as exp_public into temp1 ",dt,isValid,isMonthly,isPublic);
                    sqlText.Append(" 	end ");


                    sqlText.Append("  select   ");
                    sqlText.AppendFormat(" 	convert(varchar(7),cast('{0}'as datetime ),120) as 月份,  ",dt);
                    sqlText.Append(" 	isnull(count(isnull(exp_item,0)),0) as 消费计数,  	isnull(sum(isnull(exp_price,0)*isnull(exp_count,0)),0) as 花费金额  ");
                    sqlText.Append(" 	,isnull(inc_amount,0) as 收款金额,  	(isnull(inc_amount,0)-isnull(sum(isnull(exp_price,0)*isnull(exp_count,0)),0)) as 余额  ");
                    sqlText.Append(" from   ");
                    sqlText.Append(" 	temp1 a  full join ( ");
                    sqlText.Append(" 			select   			 ");
                    sqlText.Append(" 				isnull(sum(isnull(inc_amount,0)),0) as inc_amount  		 ");
                    sqlText.Append(" 			from   			tbl_income   		 ");
                    sqlText.Append(" 			where  ");
                    sqlText.AppendFormat(" 				convert(varchar(7),inc_date,120) = convert(varchar(7),cast('{0}'as datetime ),120)  ",dt);
                    sqlText.AppendFormat(" 				and inc_valid = {0} /*and inc_monthly = {1}*/  and inc_public = {1} 	) b on 1 = 1   ",isValid/*,isMonthly*/,isPublic);
                    sqlText.Append(" where   	 ");

                    sqlText.AppendFormat(" 	exp_valid = {0} /*and exp_monthly = {1}*/  and exp_public = {1}    ",isValid/*,isMonthly*/,isPublic);
                    sqlText.AppendFormat(" 	and convert(varchar(7),exp_date,120) = convert(varchar(7),cast('{0}'as datetime ),120)  	 ",dt);
                    sqlText.Append(" group by    ");
                    sqlText.Append(" 	convert(varchar(7),exp_date,111),inc_amount  ");
                    sqlText.Append("drop table temp1");

                    #region
                    /*
                     sqlText.Append(" select  ");
                    sqlText.Append(" 	convert(varchar(7),exp_date,111) as 月份, ");
                    sqlText.Append(" 	count(exp_item) as 消费计数, ");
                    sqlText.Append(" 	sum(exp_price*exp_count) as 花费金额, ");
                    sqlText.Append(" 	inc_amount as 收款金额, ");
                    sqlText.Append(" 	inc_amount-sum(exp_price*exp_count) as 余额 ");
                    sqlText.Append(" from ");
                    sqlText.Append(" 	tbl_expend a ");
                    sqlText.Append(" 	left join ( ");
                    sqlText.Append(" 		select  ");
                    sqlText.Append(" 			sum(inc_amount) as inc_amount");
                    sqlText.Append(" 		from  ");
                    sqlText.Append(" 			tbl_income  ");
                    sqlText.AppendFormat(" 		where convert(varchar(7),inc_date,120) = convert(varchar(7),cast('{0}'as datetime ),120) ", dtp_month.Value);
                    sqlText.Append(" 			and inc_valid = 1 and inc_monthly = 0 ");

                    if (chk_public.Checked)
                    {
                        sqlText.Append(" and inc_public = 1");
                    }
                    else
                    {
                        sqlText.Append(" and inc_public = 0");
                    }

                    sqlText.Append(" 	) b on 1 = 1  ");
                    sqlText.Append(" where  ");
                    sqlText.AppendFormat(" 	convert(varchar(7),exp_date,120) = convert(varchar(7),cast('{0}'as datetime ),120) ", dtp_month.Value);
                    sqlText.Append(" 	and exp_valid = 1 and exp_monthly = 0 ");
                    //sqlText.Append(" 	and exp_public =1 ");

                    if (chk_public.Checked)
                    {
                        sqlText.Append(" and exp_public = 1");
                    }
                    else
                    {
                        sqlText.Append(" and exp_public = 0");
                    }
                    sqlText.Append("  group by  ");
                    sqlText.Append(" 	convert(varchar(7),exp_date,111),inc_amount ");
                 */
                    #endregion
                }

                else if (cmb_type.SelectedIndex == 1)
                {
                    sqlText.Append("  select  ");
                    sqlText.AppendFormat(" 	distinct inc_source as 收款对象,convert(varchar(7),'{0}',111) as 月份,count(inc_amount) as 收款次数,isnull(sum(inc_amount),0) as 收款金额 ",dt);
                    sqlText.Append("  from ");
                    sqlText.Append(" 	tbl_income  ");
                    sqlText.Append("  where  ");
                 //   sqlText.AppendFormat(" 	convert(varchar(7),inc_date,111) between  '2019/09' and '2019/09'  ");
                    sqlText.AppendFormat(" convert(varchar(7), inc_date, 120) = convert(varchar(7), cast('{0}' as datetime), 120) ", dt);
                    sqlText.Append(" 	and inc_valid = 1  ");

                    if (chk_public.Checked)
                    {
                        sqlText.Append(" and inc_public = 1");
                    }
                    else
                    {
                        sqlText.Append(" and inc_public = 0");
                    }

                    sqlText.Append("  group by  ");
                    sqlText.Append(" 	convert(varchar(7),inc_date,111) ,inc_source ");

                    sqlText.Append("  union all ");
                    sqlText.Append("  select  ");
                    sqlText.Append(" 	'合计' ,'',1,isnull(sum(inc_amount),0)  ");
                    sqlText.Append("  from  ");
                    sqlText.Append(" 	tbl_income  ");
                    sqlText.Append("  where  ");
                    sqlText.AppendFormat(" 	convert(varchar(7),inc_date,120)=  convert(varchar(7),cast('{0}'as datetime ),120) and inc_valid = 1 ", dt);
                    if (chk_public.Checked)
                    {
                        sqlText.Append(" and inc_public = 1");
                    }
                    else
                    {
                        sqlText.Append(" and inc_public = 0");
                    }
                }
                else
                {
                    sqlText.Append(" select  ");
                    sqlText.Append(" 	distinct exp_type as 物品类型 , ");
                    sqlText.AppendFormat("    convert(varchar(7), '{0}', 111) as 月份, ",dt);
                    sqlText.Append(" 	isnull(count (exp_type),0) as 采购次数, ");
                    sqlText.Append(" 	isnull(sum(exp_price*exp_count),0) as 金额 ");
                    sqlText.Append(" from ");
                    sqlText.Append(" 	tbl_expend  ");
                    sqlText.Append(" where  ");
                    //sqlText.Append(" 	convert(varchar(7),exp_date,111) between  '2019/09' and '2019/09' ");

                    sqlText.AppendFormat(" 	convert(varchar(7),exp_date,120) = convert(varchar(7),cast('{0}'as datetime ),120) ", dtp_month.Value);

                    sqlText.Append(" 	and exp_valid = 1  ");
                    //sqlText.Append(" 	and exp_public =1 ");

                    if (chk_public.Checked)
                    {
                        sqlText.Append(" and exp_public = 1");
                    }
                    else
                    {
                        sqlText.Append(" and exp_public = 0");
                    }

                    sqlText.Append("  group by  ");
                    sqlText.Append(" 	exp_type,convert(varchar(7), exp_date, 111) ");
                    sqlText.Append("  union all ");
                    sqlText.Append("  select  ");
                    sqlText.Append(" 	'合计'as 物品类型,  '',");
                    sqlText.Append(" 	1 as 次数, ");
                    sqlText.Append(" 	isnull(sum(exp_price*exp_count),0) as 金额 ");
                    sqlText.Append("  from ");
                    sqlText.Append(" 	tbl_expend  ");
                    sqlText.Append("  where  ");
                    // sqlText.Append(" 	convert(varchar(7),exp_date,111) between  '2019/09' and '2019/09' ");

                    sqlText.AppendFormat(" 	convert(varchar(7),exp_date,120) = convert(varchar(7),cast('{0}'as datetime ),120) ", dtp_month.Value);

                    sqlText.Append(" 	and exp_valid = 1  ");
                    //sqlText.Append(" 	and exp_public =1 ");

                    if (chk_public.Checked)
                    {
                        sqlText.Append(" and exp_public = 1");
                    }
                    else
                    {
                        sqlText.Append(" and exp_public = 0");
                    }

                }


                using (SqlConnection con = new SqlConnection(_connectString))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlText.ToString(), con))
                    {
                        ds.Clear();
                        da.Fill(ds, "tbl_view");
                    }
                    //sqlText.Clear();
                    //sqlText.Append("drop table temp1");
                    //using (SqlCommand clearTmpDB = new SqlCommand(sqlText.ToString(), con))
                    //{
                    //    clearTmpDB.ExecuteNonQuery();
                    //}
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgv_view.DataSource = ds.Tables["tbl_view"];
        }
        
        private void Frm_TestQuery_Load(object sender, EventArgs e)
        {           
            int key = CalcKey.CalcKeyFun( ConfigurationManager.AppSettings.Get("seed"));
            _connectString = CalcMask.RestoreMask(ConfigurationManager.ConnectionStrings["mycon"].ToString(),key);
            cmb_type.SelectedIndex = 0;
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            query();
        }

        private void chk_public_CheckedChanged(object sender, EventArgs e)
        {
            query();
        }

        private void tab_control_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tab_control.SelectedIndex == 1)
            {
                //chart1.DataSource = ds;
            }
        }
    }
}

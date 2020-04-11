using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace bill_record
{
    class  DataHelper
    {
        /// <summary>
        /// 获取更新并提交更改到数据库
        /// </summary>
        /// <returns>成功返回值为更新数量;失败返回 -1;0没有要更新的数据</returns>
        public static int Update_dataSet(DataSet dataSet, string dataTable,string connectString)
        {
            //dataSet.AcceptChanges();
            int count = -1;

            DataSet change = new DataSet();
            change = dataSet.GetChanges();
            if (change == null)
            {
                //MessageBox.Show("没有更改任何数据！");
                count = 0;
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectString))
                    {
                        conn.Open();
                        string queyText = "SELECT * FROM " + dataTable.Trim();
                        using (SqlDataAdapter da = new SqlDataAdapter(queyText, conn))
                        {
                            SqlCommandBuilder builder = new SqlCommandBuilder(da);
                            count = da.Update(change, dataTable);
                        }
                    }
                }
                catch(Exception ex )
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            return count;
        }

    }
}

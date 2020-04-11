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
using System.Data.Sql;
using System.Configuration;


namespace bill_record
{

    public partial class LoginForm : Form
    {  
        #region
         //全局变量区
         public int _userID;     //用户ID
         public string _userName;
         public int _userLevel ; //用户等级
         public int _loginState = 0;
         public bool _userValid;
        public string _connectString = String.Empty; /* ConfigurationManager.ConnectionStrings["mycon"].ToString();           // "Data Source = .;Initial Catalog = DataStorage;User ID = sa;Password = wuti5zhu";*/

       // public string _con = ConfigurationManager.AppSettings[""]
        #endregion

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            StringBuilder queryText = new StringBuilder();
            RecalcMask password = new RecalcMask();
           // if(txt_username.Text.Equals(string.IsNullOrWhiteSpace()))
            queryText.AppendFormat("SELECT " +
                "                           acc_uname as userName," +
                "                           acc_ulevel as userLevel," +
                "                           acc_uid as userID," +
                "                           acc_uvalid as userValid" +
                "                    FROM tbl_access " +
                "                    WHERE " +                  
                                    "acc_uid = {0} " +
                                    "AND acc_uvalid = 1 " +
                                    "AND acc_ustate = 0 " +
                                    "AND acc_upassword = '{1}' ",
                (string.IsNullOrWhiteSpace(txt_username.Text)?"(-1)":txt_username.Text),password.CalcMask(txt_password.Text));
            using (SqlConnection connect = new SqlConnection(_connectString))
            {
                if (connect.State != ConnectionState.Open)
                    try
                    {
                        connect.Open();
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("数据通信错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //}
              
                    using (SqlCommand com = new SqlCommand(queryText.ToString(), connect))
                    {
                        SqlDataReader dReader = com.ExecuteReader();
                        if (dReader.HasRows)
                        {
                            dReader.Read();
                            _userName = dReader.GetString(dReader.GetOrdinal("userName"));
                            _userLevel = dReader.GetInt32(dReader.GetOrdinal("userLevel"));
                            _userID = dReader.GetInt32(dReader.GetOrdinal("userID"));
                            _userValid = dReader.GetBoolean(dReader.GetOrdinal("userValid"));
                            _loginState = 1;
                            this.Close();
                        }
                        else
                        {
                            _loginState = 0;
                            MessageBox.Show("登录失败，请校验ID及密码！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connect.Close();
            }
          
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //this.btn_submit.Text = "登录";
            //this.btn_cancel.Text = "取消";
            //this.label1.Text = "用户ID：";
            //this.label2.Text = "密  码：";
            StringBuilder conTemp = new StringBuilder();


            /*解密代码开始*/
            string kk = ConfigurationManager.AppSettings.Get("seed");
            int key = 1;
            if (kk.Length != 0)
            {
                for (int i = 0; i < kk.Length; i++)
                {
                    key += (int)kk[i];
                }
            }
            conTemp.AppendFormat("Data Source = {0} ;", RestoreMask( ConfigurationManager.AppSettings.Get("Server"),key));
            conTemp.AppendFormat("Initial Catalog = {0} ;", RestoreMask( ConfigurationManager.AppSettings.Get("Database"),key));
            conTemp.AppendFormat("User ID = {0} ;", RestoreMask( ConfigurationManager.AppSettings.Get("UserID"),key));
            conTemp.AppendFormat("Password = {0}", RestoreMask(ConfigurationManager.AppSettings.Get("Password"), key));
            /*解密代码结束*/

            _connectString = conTemp.ToString();
            conTemp.Clear();


        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_loginState == 0)
                Application.Exit();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private string RestoreMask(string message, int key)
{
    if (message.Equals("") || message.Length == 0)
    {
        return "";
    }
    StringBuilder str = new StringBuilder();
    str.Append("");
    for (int j = 0; j < (8 * key); j++)
    {
        str.Clear();
        for (int i = 0; i < message.Length; i++)
        {
            str.Append((char)(((int)message[i]) - ((i * 168 + key) % 128)));
        }
        message = str.ToString();
    }
    return str.ToString();
}

private string CalcMask(string message, int key)
{
    if (message.Equals("") || message.Length == 0)
    {
        return "";
    }
    StringBuilder str = new StringBuilder();
    str.Append("");
    for (int j = 0; j < (8 * key); j++)
    {
        str.Clear();
        for (int i = 0; i < message.Length; i++)
        {
            str.Append((char)(((int)message[i]) + ((i * 168 + key) % 128)));
        }
        message = str.ToString();
    }
    return str.ToString();
}

    }
}

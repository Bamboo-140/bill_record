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
using System.Data.Sql;
using System.Data.SqlClient;

namespace bill_record
{
    public partial class MainForm : Form
    {
        public MainForm()
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
        public string _connectString="";
        public Boolean _view_all = false;
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            string flag;
            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
                _connectString = login._connectString;
                _userID = login._userID;
                _userLevel = login._userLevel;
                _userName = login._userName;
                //this.lab_in.Text = _userName;
            }
            toolStripStatusLabel1.Text = "用户名："+_userName;
            if(_userLevel < 3 )
            {
                flag = "普通用户";
                this.pic_monthly.Enabled = false;
            }
            else if(_userLevel >=3 && _userLevel <15)
            {
                flag = "系统管理员";
            }
            else
            {
                flag = "超级管理员";
            }
            toolStripStatusLabel2.Text = "所属用户组：" + flag;
            toolStripStatusLabel3.Text = "就绪";
            object ob = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectString))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand("select allow_view_all from tbl_config", conn))
                    {
                        ob = com.ExecuteScalar();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _view_all = Convert.ToBoolean(ob);

                pic_in_Click(sender, e);
        }

        private void pic_in_Click(object sender, EventArgs e)
        {
            foreach (DockContent frm in this.dockPanel1.Contents)
            {
                if(frm is frm_income)
                {
                    frm.Activate();
                    return;
                }
            }
            frm_income income = new frm_income();
            income._userID = _userID;
            income._userLevel = _userLevel;
            income._userName = _userName;
            income._userState = _userState;
            income._userValid = _userValid;
            income._view_all = _view_all;
                income.Show(this.dockPanel1);      
        }

        private void pic_out_Click(object sender, EventArgs e)
        {
            foreach (DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is frm_expend)
                {
                    frm.Activate();
                    return;
                }
            }
            frm_expend expend = new frm_expend();
            expend._userLevel = _userLevel;
            expend._userName = _userName;
            expend._userID = _userID;
            expend._userState = _userState;
            expend._userValid = _userValid;
            expend._view_all = _view_all;
            expend.Show(this.dockPanel1);
        }

        private void pic_bill_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DockContent frm in this.dockPanel1.Contents)
                {
                    if (frm is Frm_TestQuery)
                    {
                        frm.Activate();
                        return;
                    }
                }
                Frm_TestQuery query = new Frm_TestQuery();
                query.Show(this.dockPanel1);
            }
            catch { }
        }

        private void userManager_Click(object sender, EventArgs e)
        {
            Frm_UserManagement um = new Frm_UserManagement();
            um._connectString = _connectString;
            um._userName = _userName;
            um._userLevel = _userLevel;
            um._userid = _userID;            
            um.Show(this.dockPanel1);
        }

        private void btn_monthly_Click(object sender, EventArgs e)
        {

        }

        private void pic_in_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //ResetPictureBox();
            if (dockPanel1.Contents.Count == 0)
            {
                ResetPictureBox();
                return; 
            }
            else
            {
                Set_PictureBox();
            }
            //foreach(DockContent frm in this.dockPanel1.Contents)
            //{

            //}

        }
        private void ResetPictureBox()
        {
            pic_bill.BorderStyle = BorderStyle.None;
            pic_in.BorderStyle = BorderStyle.None;
            pic_out.BorderStyle = BorderStyle.None;
            pic_monthly.BorderStyle = BorderStyle.None;
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {
            Set_PictureBox();
        }
        private void Set_PictureBox()
        {
            if (dockPanel1.ActiveContent is frm_expend)
            {
                pic_out.BorderStyle = BorderStyle.Fixed3D;
                pic_in.BorderStyle = BorderStyle.None;
                pic_bill.BorderStyle = BorderStyle.None;
                pic_monthly.BorderStyle = BorderStyle.None;
            }
            else if (dockPanel1.ActiveContent is frm_income)
            {
                pic_in.BorderStyle = BorderStyle.Fixed3D;
                pic_out.BorderStyle = BorderStyle.None;
                pic_bill.BorderStyle = BorderStyle.None;
                pic_monthly.BorderStyle = BorderStyle.None;
            }
            else if (dockPanel1.ActiveContent is Frm_TestQuery)
            {
                pic_bill.BorderStyle = BorderStyle.Fixed3D;
                pic_out.BorderStyle = BorderStyle.None;
                pic_in.BorderStyle = BorderStyle.None;
                pic_monthly.BorderStyle = BorderStyle.None;

            }
            else if(dockPanel1.ActiveContent is Frm_Monthly)
            {
                pic_bill.BorderStyle = BorderStyle.None;
                pic_out.BorderStyle = BorderStyle.None;
                pic_in.BorderStyle = BorderStyle.None;
                pic_monthly.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                ResetPictureBox();
            }
        }

        private void pic_monthly_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DockContent frm in this.dockPanel1.Contents)
                {
                    if (frm is Frm_Monthly)
                    {
                        frm.Activate();
                        return;
                    }
                }
                Frm_Monthly month = new Frm_Monthly();
                month._userID = _userID;
                month._connectString = this._connectString;
                month.Show(this.dockPanel1);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void option_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DockContent frm in this.dockPanel1.Contents)
                {
                    if (frm is Frm_Option)
                    {
                        frm.Activate();
                        return;
                    }
                }
                Frm_Option option = new Frm_Option();
                option._connectString = this._connectString;
                option.Show(this.dockPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

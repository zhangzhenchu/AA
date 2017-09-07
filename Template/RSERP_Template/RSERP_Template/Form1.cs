using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UTLoginEx;  //固定格式

namespace RSERP_Template
{
    public partial class Form1 : Form
    {
        private int FormWidth = 0, FormHeight = 0, dataGridView1Width = 0, dataGridView1Height = 0;//固定格式
        private UTLoginEx.LoginEx iLoginEx = new LoginEx();//固定格式
        private int AuthID = 48; //权限ID ,不能为零。这里的零，只是模板 //固定格式
        public Form1(string[] args)
        {
            try
            {
                InitializeComponent();


                iLoginEx.Initialize(args, AuthID);//必须先初始化LoginEx  //固定格式


                SLbAccID.Text = iLoginEx.AccID(); //固定格式
                SLbAccName.Text = iLoginEx.AccName();//固定格式
                SLbServer.Text = iLoginEx.DBServerHost();//固定格式
                SLbYear.Text = iLoginEx.iYear();//固定格式
                SLbUser.Text = iLoginEx.UserId() + "[" + iLoginEx.UserName() + "]";//固定格式


            }
            catch (Exception ex)
            {
                frmMessege frmmsg = new frmMessege(ex.ToString(), "Form1()");
                frmmsg.ShowDialog(this);
                    
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormWidth = this.Width; //固定格式
            FormHeight = this.Height;//固定格式
            dataGridView1Width = dataGridView1.Width;//固定格式
            dataGridView1Height = dataGridView1.Height;//固定格式
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            IniFile.Ini ini = new IniFile.Ini(System.Windows.Forms.Application.StartupPath.ToString() + "\\utconfig.ini");//固定格式
            ini.Writue("Window", "AutoAdaptive2", "");//固定格式
            if (ini.ReadValue("Window", "AutoAdaptive") != "N")//固定格式
            {
                dataGridView1.Width = dataGridView1Width + (this.Width - FormWidth);//固定格式
                dataGridView1.Height = dataGridView1Height + (this.Height - FormHeight);//固定格式
            }//固定格式
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UTLoginEx;  //固定格式
using System.Data.OleDb; 
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Reflection;
using RSERP_ST431;
using System.Text.RegularExpressions;



namespace RSERP_ST431
{
    public partial class FrmMCoding : Form
    {
        private int FormWidth = 0, FormHeight = 0, dataGridView1Width = 0, dataGridView1Height = 0;//固定格式
        private UTLoginEx.LoginEx iLoginEx = new LoginEx();//固定格式
        private int AuthID = 12; //权限ID ,不能为零。这里的零，只是模板 //固定格式

        List<Infolst> lst = new List<Infolst>();

        #region 变量
          /// <summary>
         /// 导出模板列集合
          /// </summary>
          List<string> columnListOut = new List<string>() 
          {
              "材料编码",
              "原采购回复",
              "在途数量",
             
          };
  
          /// <summary>
          /// 导出模板文件名称
          /// </summary>
          string FileName = "Sheet1";
  
          /// <summary>
          /// Excel底层页签名称
          /// </summary>
          string SheetName = "table1";
  
          /// <summary>
          /// ExcelHelper实例化
          /// </summary>
          ExcelHelper excelHelper = new ExcelHelper();
  
          #endregion


        public FrmMCoding(string[] args)
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
            dataGridView1Width = dgvInfo.Width;//固定格式
            dataGridView1Height = dgvInfo.Height;//固定格式
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            IniFile.Ini ini = new IniFile.Ini(System.Windows.Forms.Application.StartupPath.ToString() + "\\utconfig.ini");//固定格式
            ini.Writue("Window", "AutoAdaptive2", "");//固定格式
            if (ini.ReadValue("Window", "AutoAdaptive") != "N")//固定格式
            {
                dgvInfo.Width = dataGridView1Width + (this.Width - FormWidth);//固定格式
                dgvInfo.Height = dataGridView1Height + (this.Height - FormHeight);//固定格式
            }//固定格式
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog filedialog = new OpenFileDialog();
            string FileName = "";
            string nameFile = "";
            filedialog.Filter = " Excel文件|*.csv|(*.xls)|*.xls|(*.xlsx)|*.xlsx";//选择文件的类型为Xls表格 
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                FileName = filedialog.FileName.Trim();//文件路径;
                 //System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                nameFile = filedialog.SafeFileName;

                if (!String.IsNullOrEmpty(FileName))
                {
                    FileName = FileName.Replace("\\", "/");
                    txtFile.Text = FileName;
                    //ExcelToDataGridView(FileName);
                    dgvFile.DataSource = GetExcelData(FileName,nameFile);
                    dgvInfo.DataSource = lst;
                    dgvFile.DataMember = "[Sheet1$]";

                    for (int count = 0; (count <= (dgvFile.Rows.Count - 1)); count++)
                    {

                        dgvFile.Rows[count].HeaderCell.Value = (count + 1).ToString();

                    }

                    for (int count = 0; (count <= (dgvInfo.Rows.Count - 1)); count++)
                    {

                        dgvInfo.Rows[count].HeaderCell.Value = (count + 1).ToString();

                    }
                }
                else
                {
                    MessageBox.Show("未选择任何的Execl文件！");
                }


            } 

        }
        public DataSet GetExcelData(string strExcelFileName,string nameFile)
        {
            // string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;;Data Source=" + str + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";
            // string strCon = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;'", strExcelFileName);//HDR=Yes;IMEX=1;
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelFileName + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1;'";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [table1$]";
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, "[Sheet1$]");


            for (int i = 1; i < myDataSet.Tables[0].Rows.Count; i++)
            { 
                string three = myDataSet.Tables[0].Rows[i][2].ToString();
                string tow = myDataSet.Tables[0].Rows[i][1].ToString();
                string one = myDataSet.Tables[0].Rows[i][0].ToString();
              
                Infolst lt = new Infolst();
                if (!String.IsNullOrEmpty(one) || !String.IsNullOrEmpty(tow))
                {

                    //判断文本是否为纯数字
                    if (Regex.IsMatch(tow, @"^\d+$"))
                    {
                        if (tow.Length == 5)
                        {
                            lt.MCoding = one;
                            lt.Date = DateTime.FromOADate(Convert.ToInt32(tow)).ToString("yyyy-MM-dd");
                            lt.Num = three;
                            lt.MOther = nameFile;
                            lst.Add(lt);
                        }

                    }
                    else if (Regex.IsMatch(tow, @"^\d{1,2}[\u4e00-\u9fa5]{1}\d{1,2}[\u4e00-\u9fa5]{1}$"))//判断字符串是否（几月几日）的格式。
                    {

                        lt.MCoding = one;
                        lt.Date = DateTime.Parse(tow.Trim()).ToString("yyyy-MM-dd");
                        lt.Num = three;
                        lt.MOther = nameFile;
                        lst.Add(lt);
                    }
                    else if (Regex.IsMatch(tow, @"^[\u4e00-\u9fa5]+$"))//判断字符串是否纯中文
                    {

                        lt.MCoding = one;
                        lt.Explain = tow;
                        lt.MOther = nameFile;
                        lst.Add(lt);
                    }
                    else if (tow.Contains(","))
                    {
                       
                        string[] subing = tow.Split(',');
                        Regex reg = new Regex(@"^\d{1,2}-\d{1,2}$");//判断格式是否日期（1-1）
                        Regex str = new Regex(@"^[\u4e00-\u9fa5]+$");//判断字符串是否纯中文
                        Regex g = new Regex(@"^\d+(.\d{1})[K]|\d+[K]$");//判断格式是否数值字母k
                        Regex num = new Regex(@"^\d+$");//判断格式是否纯数字
                        for (int ei = 0; ei < subing.Length; ei++)
                        {
                            Infolst llsst = new Infolst();
                            if (subing[ei].Contains(":") || subing[ei].Contains("："))
                            {
                                Infolst llst = new Infolst();
                                string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",");    
                                string[] su = eii.Split(',');
                                for (int ii = 0; ii < su.Length; ii++)
                                {
                                    NewMethod(one, reg, str, g, num, llst, su, ii);
                                }
                                if (!String.IsNullOrEmpty(llst.Num))
                                {
                                    llst.MOther = nameFile;
                                    lst.Add(llst);
                                }
                                else
                                {  
                                    llst.Num = three;
                                    llst.MOther = nameFile;
                                    lst.Add(llst);
                                }
                            }
                          
                            else
                            {
                                llsst.MCoding = one;
                                llsst.Describe = subing[ei].ToString();
                                llsst.MOther = nameFile;
                                lst.Add(llsst);
                            }
                        }
                    }
                    else if (tow.Contains("，"))
                    {
                        string[] subing = tow.Split('，');
                        Regex reg = new Regex(@"^\d{1,2}-\d{1,2}$");//判断格式是否日期（1-1）
                        Regex str = new Regex(@"^[\u4e00-\u9fa5]+$");//判断字符串是否纯中文
                        Regex g = new Regex(@"^\d+(.\d{1})[K]|\d+[K]$");//判断格式是否数值字母k
                        Regex num = new Regex(@"^\d+$");//判断格式是否纯数字
                        for (int ei = 0; ei < subing.Length; ei++)
                        {
                            Infolst llsst = new Infolst();
                            if (subing[ei].Contains(":") || subing[ei].Contains("："))
                            {
                                Infolst llst = new Infolst();
                                string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",");//.Replace("已扣", ",已扣").Replace("研发", ",").Replace("个", ",");
                                string[] su = eii.Split(',');
                                for (int ii = 0; ii < su.Length; ii++)
                                {
                                    NewMethod(one, reg, str, g, num, llst, su, ii);

                                }
                                if (!String.IsNullOrEmpty(llst.Num))
                                {
                                    llst.MOther = nameFile;
                                    lst.Add(llst);
                                }
                                else
                                { 
                                    llst.Num = three;
                                    llst.MOther = nameFile;
                                    lst.Add(llst);
                                }

                            }
                            else
                            {
                                llsst.MCoding = one;
                                llsst.Describe = subing[ei].ToString();
                                llsst.MOther = nameFile;
                                lst.Add(llsst);
                            }
                        }
                    }
                    else if (tow.Contains("：") || tow.Contains(":"))
                    {
                        //  tow = tow.Replace("K-", "K，").Replace("复-","复，").Replace("到","，").Replace(" ",":").Replace("预计",":预计:").Replace("，港","");
                        string[] subing = tow.Split('，');
                        Regex reg = new Regex(@"^\d{1,2}-\d{1,2}$");//判断格式是否日期（1-1）
                        Regex str = new Regex(@"^[\u4e00-\u9fa5]+$");//判断字符串是否纯中文
                        Regex g = new Regex(@"^\d+(.\d{1})[K]|\d+[K]$");//判断格式是否数值字母k
                        Regex num = new Regex(@"^\d+$");//判断格式是否纯数字
                        for (int ei = 0; ei < subing.Length; ei++)
                        {
                            Infolst llsst = new Infolst();
                            if (subing[ei].Contains(":") || subing[ei].Contains("："))
                            {
                                Infolst llst = new Infolst();
                                string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",");// Replace("K-", "K,每").Replace("预计", ",预计,").Replace("到台湾", ",到台湾,").Replace("香港", ",香港").Replace("到港", ",到港").Replace("号,", ",");

                                string[] su = eii.Split(',');

                                for (int ii = 0; ii < su.Length; ii++)
                                {

                                    NewMethod(one, reg, str, g, num, llst, su, ii);
                                   
                                }
                                if (String.IsNullOrEmpty(llst.Num))
                                {
                                    llst.Num = three;
                                    llst.MOther = nameFile;
                                    lst.Add(llst);
                                }
                                else
                                {
                                    llst.MOther = nameFile;
                                  lst.Add(llst);
                                }
                               

                            }
                            else
                            {
                                llsst.MCoding = one;
                                llsst.Describe = subing[ei].ToString();
                                llsst.MOther = nameFile;
                                lst.Add(llsst);
                            }
                        }


                    }
                    #region MyRegion
                    //else if (tow.Contains("至"))
                    //{
                    //    lt.MCoding = one;
                    //    lt.Explain = tow;
                    //    lst.Add(lt);
                    //}
                    //else if (tow.Contains("剩下的"))
                    //{
                    //    tow = tow.Replace("剩下的", ",剩下的");
                    //    string[] subing = tow.Split(',');
                    //    Regex reg = new Regex(@"^\d{1,2}-\d{1,2}$");//判断格式是否日期（1-1）
                    //    Regex str = new Regex(@"^[\u4e00-\u9fa5]+$");//判断字符串是否纯中文
                    //    Regex g = new Regex(@"^\d+(.\d{1})[K]|\d+[K]$");//判断格式是否数值字母k
                    //    Regex num = new Regex(@"^\d+$");//判断格式是否纯数字
                    //    for (int ei = 0; ei < subing.Length; ei++)
                    //    {
                    //        Infolst llsst = new Infolst();
                    //        if (subing[ei].Contains(":") || subing[ei].Contains("："))
                    //        {
                    //            Infolst llst = new Infolst();
                    //            string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",").Replace("寄出", ",寄出,").Replace("~10K", "K");
                    //            string[] su = eii.Split(',');
                    //            for (int ii = 0; ii < su.Length; ii++)
                    //            {
                    //                NewMethod(one, reg, str, g, num, llst, su, ii);
                    //            }
                    //            lst.Add(llst);
                    //        }
                    //        else if (subing[ei].Contains("寄出"))
                    //        {
                    //            Infolst llst = new Infolst();
                    //            string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",").Replace("寄出", ",寄出,");
                    //            string[] su = eii.Split(',');
                    //            for (int ii = 0; ii < su.Length; ii++)
                    //            {
                    //                NewMethod(one, reg, str, g, num, llst, su, ii);
                    //            }
                    //            lst.Add(llst);
                    //        }
                    //        else if (subing[ei].Contains("已到"))
                    //        {
                    //            Infolst llst = new Infolst();
                    //            string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",").Replace("已到香港", ",已到,");
                    //            string[] su = eii.Split(',');
                    //            for (int ii = 0; ii < su.Length; ii++)
                    //            {
                    //                NewMethod(one, reg, str, g, num, llst, su, ii);
                    //            }
                    //            lst.Add(llst);
                    //        }
                    //        else if (subing[ei].Contains("预计"))
                    //        {
                    //            Infolst llst = new Infolst();
                    //            string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",").Replace("已到香港", ",已到,").Replace("预计", ",预计,").Replace("香港", ",香港,").Replace("剩下的", ",剩下的,");
                    //            string[] su = eii.Split(',');
                    //            for (int ii = 0; ii < su.Length; ii++)
                    //            {
                    //                NewMethod(one, reg, str, g, num, llst, su, ii);
                    //            }
                    //            lst.Add(llst);
                    //        }
                    //        else
                    //        {
                    //            llsst.MCoding = one;
                    //            llsst.Describe = subing[ei].ToString();
                    //            lst.Add(llsst);
                    //        }
                    //    }
                    //}
                    //else if (tow.Contains("已到") || tow.Contains("快递"))
                    //{
                    //    tow = tow.Replace(".", "-").Replace("已到", ":已到:").Replace("快递", ":快递");
                    //    string[] subing = tow.Split(',');
                    //    Regex reg = new Regex(@"^\d{1,2}-\d{1,2}$");//判断格式是否日期（1-1）
                    //    Regex str = new Regex(@"^[\u4e00-\u9fa5]+$");//判断字符串是否纯中文
                    //    Regex g = new Regex(@"^\d+(.\d{1})[K]|\d+[K]$");//判断格式是否数值字母k
                    //    Regex num = new Regex(@"^\d+$");//判断格式是否纯数字
                    //    for (int ei = 0; ei < subing.Length; ei++)
                    //    {
                    //        Infolst llsst = new Infolst();
                    //        if (subing[ei].Contains(":") || subing[ei].Contains("："))
                    //        {
                    //            Infolst llst = new Infolst();
                    //            string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",").Replace("寄出", ",寄出,").Replace("~10K", "K");
                    //            string[] su = eii.Split(',');
                    //            for (int ii = 0; ii < su.Length; ii++)
                    //            {
                    //                NewMethod(one, reg, str, g, num, llst, su, ii);
                    //            }
                    //            lst.Add(llst);
                    //        }
                    //        else if (subing[ei].Contains("寄出"))
                    //        {
                    //            Infolst llst = new Infolst();
                    //            string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("，", ",").Replace("寄出", ",寄出,");
                    //            string[] su = eii.Split(',');
                    //            for (int ii = 0; ii < su.Length; ii++)
                    //            {
                    //                NewMethod(one, reg, str, g, num, llst, su, ii);
                    //            }
                    //            lst.Add(llst);
                    //        }
                    //        else
                    //        {
                    //            llsst.MCoding = one;
                    //            llsst.Describe = subing[ei].ToString();
                    //            lst.Add(llsst);
                    //        }
                    //    }

                    //}
                    //else if (tow.Contains(" "))
                    //{

                    //    tow = tow.Replace("K-", "K，").Replace(" ", ":");
                    //    string[] subing = tow.Split('，');
                    //    Regex reg = new Regex(@"^\d{1,2}-\d{1,2}$");//判断格式是否日期（1-1）
                    //    Regex str = new Regex(@"^[\u4e00-\u9fa5]+$");//判断字符串是否纯中文
                    //    Regex g = new Regex(@"^\d+(.\d{1})[K]|\d+[K]$");//判断格式是否数值字母k
                    //    Regex num = new Regex(@"^\d+$");//判断格式是否纯数字
                    //    for (int ei = 0; ei < subing.Length; ei++)
                    //    {
                    //        Infolst llsst = new Infolst();
                    //        if (subing[ei].Contains(":") || subing[ei].Contains("："))
                    //        {
                    //            Infolst llst = new Infolst();
                    //            string eii = subing[ei].Replace(":", ",").Replace("：", ",").Replace("/", "-").Replace("回,", ",").Replace("号,", ",").Replace("，", ",").Replace("K-", "K,每").Replace("预计", "预计,").Replace(".", "-").Replace("到台湾", ",到台湾,").Replace("香港", ",香港,");
                    //            string[] su = eii.Split(',');
                    //            for (int ii = 0; ii < su.Length; ii++)
                    //            {
                    //                NewMethod(one, reg, str, g, num, llst, su, ii);
                    //            }
                    //            lst.Add(llst);

                    //        }
                    //        else
                    //        {
                    //            llsst.MCoding = one;
                    //            llsst.Describe = subing[ei].ToString();
                    //            lst.Add(llsst);
                    //        }
                    //    }
                    //} 
                    #endregion
                    else
                    {
                        lt.MCoding = one;
                        lt.Explain = tow;
                        lt.MOther = nameFile;
                        lst.Add(lt);
                    }


                }
            }

           

            myConn.Close();
            return myDataSet;

        }
      
        
        
        #region 提取方法
        /// <summary>
        ///  提取方法
        /// </summary>
        /// <param name="one">材料编码</param>
        /// <param name="reg">判断格式是否日期（1-1）</param>
        /// <param name="str">判断字符串是否纯中文</param>
        /// <param name="g">判断格式是否数值字母k</param>
        /// <param name="num">判断格式是否纯数字</param>
        /// <param name="llst">llst的集合</param>
        /// <param name="su">截取字符串的数组集合</param>
        /// <param name="ii">数组集合的下标</param>
        private void NewMethod(string one, Regex reg, Regex str, Regex g, Regex num, Infolst llst, string[] su, int ii)
        {
            llst.MCoding = one;
            if (reg.Match(su[ii].ToString().Trim()).Success)
            {
                Match m = reg.Match(su[ii].Trim().ToString());
                if (m.Success)
                {
                    string strdate = iLoginEx.iYear().ToString() + "-" + m.Value;
                    llst.Date = DateTime.Parse(strdate.Trim()).ToString("yyyy-MM-dd");
                }
            }
            else if (num.Match(su[ii].Trim().ToString()).Success)
            {
                Match m = num.Match(su[ii].Trim().ToString());
                if (m.Success)
                {
                    llst.Num = m.Value;
                }
            }
            else if (g.Match(su[ii].Trim().ToString()).Success)
            {
                Match m = g.Match(su[ii].Trim().ToString());
                if (m.Success)
                {

                    string strin = (Convert.ToDouble(m.Value.Replace("K", "")) * 1000).ToString();

                    llst.Num = strin;
                }
            }
            else if (str.Match(su[ii].Trim().ToString()).Success)
            {
                Match m = str.Match(su[ii].Trim().ToString());
                if (m.Success)
                {
                    llst.Explain = m.Value;
                }
            }
            else
            {
                llst.Describe = su[ii].ToString().Trim();
            }
        } 
        #endregion

     





       


        private void dgvFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(iLoginEx.ConnString());
            conn.Open();

            try
            {
                int n = 0;
                foreach (Infolst i in lst)
                {
                    string sql = string.Format("insert into zhrs_t_zzcMaterialShortage(MCoding,MDate,MNumber,MExplain,MDescribe,MOther)values('{0}','{1}','{2}','{3}','{4}','{5}')", i.MCoding, i.Date, i.Num, i.Explain, i.Describe, i.MOther);
                    if (CheckExists(i.MCoding, i.Date, i.Num))
                    {
                        continue;            //跳出单次循环
                    }
                    else
                    {
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            n = cmd.ExecuteNonQuery();
                        }

                    }

                }
                if (n > 0)
                {
                    MessageBox.Show("保存原采购回复成功！");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("错误！" + ex.Message);
            }
            finally
            {
                conn.Close();
                GC.Collect();
                GC.Collect(1);
                btnSave.Enabled = false;
            }

        } 
        #endregion

        #region 检索查询返回行数
        /// <summary>
        /// 检索查询返回行数
        /// </summary>
        /// <param name="mCoding"></param>
        /// <param name="data"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CheckExists(string mCoding, string data, string num)
        {
            bool faler = false;

            try
            {
                OleDbConnection conn = new OleDbConnection(iLoginEx.ConnString());
                conn.Open();
                int n = 0;
                string sql = string.Format("select Count(*) from zhrs_t_zzcMaterialShortage where MCoding = '{0}' and MDate='{1}' and MNumber='{2}'", mCoding, data, num);
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    n = Convert.ToInt32(cmd.ExecuteScalar());
                }


                conn.Close();
                if (n > 0)
                {
                    faler = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误！" + ex.Message);
            }
            finally
            {

                GC.Collect();
                GC.Collect(1);
            }
            return faler;
        } 
        #endregion


        #region 下载Execl模板
        /// <summary>
        /// 下载Execl模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click(object sender, EventArgs e)
        {
            string[] columnList = this.columnListOut.ToArray();
            string msg = string.Empty;
            this.excelHelper.SaveExcelTemplate(columnList, this.FileName, this.SheetName, ref msg);
        } 
        #endregion

       


      



      


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using UTLoginEx;
using System.Data;
using System.Windows.Forms;


namespace RSERP_ST431
{
   public class MSService
    {
        private static UTLoginEx.LoginEx iLoginEx = new LoginEx();
        //创建一个连接对象
        private static OleDbConnection con = null;

        #region 获取连接对象
        /// <summary>
        /// 获取连接对象
        /// </summary>
        public static OleDbConnection GetCon()
        {
            if (con == null || con.ConnectionString == "")
            {
                con = new OleDbConnection(iLoginEx.ConnString());
            }
            return con;
        }
        #endregion

        #region 打开连接
        /// <summary>
        /// 打开连接
        /// </summary>
        public static void OpenCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        #endregion

        #region 关闭连接
        /// <summary>
        /// 关闭连接
        /// </summary>
        public static void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        #endregion


       /// <summary>
       /// 添加欠料表原采购回复
       /// </summary>
       /// <param name="iLoginEx"></param>
       /// <param name="i"></param>
       /// <returns></returns>
        public static int AddMaterialShortage(LoginEx iiLoginEx, Infolst i) 
       {
           iLoginEx = iiLoginEx; 
            int n = 0;
           try
           {
             
               OleDbConnection con = GetCon();
               OpenCon();
               string sql = string.Format("insert into zhrs_t_zzcMaterialShortage(MCoding,MDate,MNumber,MExplain,MDescribe,MOther)values('{0}','{1}','{2}','{3}','{4}','{5}')", i.MCoding, i.Date, i.Num, i.Explain, i.Describe, i.MOther);
               OleDbCommand com = new OleDbCommand(sql, con);
               com.CommandTimeout = 3600;
               n = com.ExecuteNonQuery();
               CloseCon();
             
           }
           catch (Exception ex)
           {

               MessageBox.Show("错误： " + ex.Message);
           }
           finally
           {
               GC.Collect();
               GC.Collect(1);
           }
           return n;
       
       }

    }
}

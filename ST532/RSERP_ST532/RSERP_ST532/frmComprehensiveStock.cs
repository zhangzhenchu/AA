using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using RSERP;
using UTLoginEx;


namespace RSERP_ST531
{
    public partial class frmComprehensiveStockInfo : Form
    {
        private int FormWidth = 0, FormHeight = 0, tabPageWidth = 0, tabPageHeight = 0, dataGridViewWidth = 0, dataGridViewHeight = 0, dataGridViewWidth2 = 0, dataGridViewHeight2 = 0, tab3_dataGridView1Width = 0, tab3_dataGridView1Height = 0, tab4_dataGridView1Width = 0, tab4_dataGridView1Height = 0;
        private UTLoginEx.LoginEx iLoginEx = new LoginEx();
        private RSERP.ComprehensiveStock wComprehensiveStock = new ComprehensiveStock();
        private Ini ini = null;
        private bool CellMouseDown = false;
        private int tab5_dataGridView1Width = 0, tab5_dataGridView1Height = 0;
        private short mproType = 0;
        private string mTitle = "";
        private int mOutMonth = 0;
        private string cWhCode = "";
        private bool Tab2_SaveCulomnsWidth = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="proType">0=综合查询；1=呆料预警</param>
        public frmComprehensiveStockInfo(string[] args, short proType)
        {
            InitializeComponent();
            //18:库存综合查询
            iLoginEx.Initialize(args, 18);//必须先初始化LoginEx

            mproType = proType;
            SLbAccID.Text = iLoginEx.AccID();
            SLbAccName.Text = iLoginEx.AccName();
            SLbServer.Text = iLoginEx.DBServerHost();
            SLbYear.Text = iLoginEx.iYear();
            SLbUser.Text = iLoginEx.UserId() + "[" + iLoginEx.UserName() + "]";
        }
        private void StokWarning()
        {
            try
            {
                Tab2_SaveCulomnsWidth = false;
                frmQuery fQuery = new frmQuery(iLoginEx);
                fQuery.ShowDialog(this);

                if (fQuery.GetSQL().Length > 0)
                {
                    mOutMonth = fQuery.OutMonth();
                    cWhCode = fQuery.WhCode();

                    OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                    if (myConn.State == System.Data.ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                    myConn.Open();

                    //用临时表，并分两段，以防止接连接超时
                    OleDbCommand myCommand = new OleDbCommand(fQuery.GetSQL(), myConn);
                    myCommand.CommandTimeout = 7200;
                    myCommand.ExecuteNonQuery();

                    myCommand.CommandText = fQuery.GetSQL2();
                    myCommand.ExecuteNonQuery();


                    this.tab5_dataGridView1.AutoGenerateColumns = true;
                    //设置数据源    


                    DataSet ds = new DataSet();
                    OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
                    da.Fill(ds);
                    this.tab5_dataGridView1.DataSource = ds.Tables[0];//数据源 


                    //标准居中
                    this.tab5_dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //设置自动换行

                    this.tab5_dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    //设置自动调整高度

                    this.tab5_dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    if (myConn.State == System.Data.ConnectionState.Open)
                    {
                        myConn.Close();
                    }


                    for (int i = 0; i < tab5_dataGridView1.Columns.Count; i++)
                    {
                        tab5_dataGridView1.Columns[i].ReadOnly = true;

                    }


                    for (int i = 0; i < tab5_dataGridView1.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            tab5_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                        }
                    }

                    tab5_dataGridView1.Columns[0].Width = 120;
                    tab5_dataGridView1.Columns[1].Width = 200;
                    tab5_dataGridView1.Columns[2].Width = 280;

                    tab5_dataGridView1.Columns[3].DefaultCellStyle.Format = "#,###0";
                    tab5_dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    tab5_dataGridView1.Columns[4].DefaultCellStyle.Format = "#,###0.00";
                    tab5_dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    tab5_dataGridView1.Columns[5].DefaultCellStyle.Format = "#,###0";
                    tab5_dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    tab5_dataGridView1.Columns[6].DefaultCellStyle.Format = "#,###0.00";
                    tab5_dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    Tab2_SaveCulomnsWidth = true;

                    for (int i = 7; i < tab5_dataGridView1.Columns.Count; i++)
                    {
                        tab5_dataGridView1.Columns[i].DefaultCellStyle.Format = "#,###0";
                        tab5_dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    //读取用户自定列宽

                    if (tab5_dataGridView1.Columns.Count > 0)
                    {

                        string ColumnsWidths = iLoginEx.ReadUserProfileValue("tab5StokWarning", "ColumnsWidths");
                        string[] ColumnsWidthsPara = ColumnsWidths.Split(';');
                        for (int i = 0; i < ColumnsWidthsPara.Length && i < tab5_dataGridView1.Columns.Count; i++)
                        {
                            if (ColumnsWidthsPara[i].Length > 0)
                            {
                                tab5_dataGridView1.Columns[i].Width = Convert.ToInt32(ColumnsWidthsPara[i]);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                frmMessege frmmsg = new frmMessege(ex.ToString(), "toolQuery_Click()");
                frmmsg.ShowDialog(this);
            }
        }
        /// <summary>
        /// 库存明细
        /// </summary>  
        private void DedtailQuery(bool showAllData, string DocTypeNo)
        {

            try
            {

                this.Text = mTitle + "   正在查询，请稍候...";
                System.Windows.Forms.Application.DoEvents();

                OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
                myConn.Open();

                string mySelectQuery = "";
                if (showAllData)
                {

                    mySelectQuery = " select   a.DocType as '数据类别', a.cCode as '单号',a.cpersonname as '经办人',a.cDefine30 as '源单号',a.dDate as '日期',a.Prod_cInvCode as '产品编码', pr.cInvName as '产品名称',replace(replace(pr.cinvstd,'''',''),'\"','')  as '产品型号', a.cinvcode as '物料编码',p.cInvName as '物料名称',  \r\n";
                    mySelectQuery += " replace(replace(p.cinvstd,'''',''),'\"','') as '物料规格',p.cInvDefine7 as '图号版次',a.moQty as '在制数', a.Now_PurQty as '采购在途', 0 as '即将到货',a.Now_PurArrQty as '到货在检量',a.CurSotckQty as '现存量' ,a.useQty as '已分配量'  \r\n";

                }
                else
                {
                    mySelectQuery = "select  a.DocType as '数据类别', a.cCode as '单号',a.cpersonname as '经办人',a.cDefine30 as '源单号',a.dDate as '日期',a.Prod_cInvCode as '产品编码', pr.cInvName as '产品名称',replace(replace(pr.cinvstd,'''',''),'\"','')  as '产品型号', a.cinvcode as '物料编码',p.cInvName as '物料名称',  \r\n";
                    mySelectQuery += " replace(replace(p.cinvstd,'''',''),'\"','') as '物料规格',p.cInvDefine7 as '图号版次',(a.moQty+a.Now_PurQty+a.Now_PurArrQty+a.CurSotckQty+a.useQty) as '数量'  \r\n";
                }




                mySelectQuery += "   from " + wComprehensiveStock.ComprehensiveStockInfo(iLoginEx, 0, "", "", "", iLoginEx.pubDB_UF(), cWhCode,"") + " a left join inventory p  (nolock ) on a.cinvcode=p.cinvcode  left  join  inventory pr  (nolock ) on  a.Prod_cInvCode=pr.cinvcode  where 1=1 \r\n";

                tab1_cinvCodeAny.Text = tab1_cinvCodeAny.Text.Trim();
                tab1_cinvCodeAny.Text = tab1_cinvCodeAny.Text.Replace("；", ";");

                if (tab1_cinvCodeAny.Text.Length > 0)
                {
                    string cinvCodeChild = "";
                    string[] paraCinvCode = tab1_cinvCodeAny.Text.Split(';');
                    if (paraCinvCode.Length > 0)
                    {
                        for (int i = 0; i < paraCinvCode.Length; i++)
                        {
                            cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                        }

                        mySelectQuery += " and  a.cinvcode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                    }
                    else
                    {
                        mySelectQuery += " and  a.cinvcode ='" + tab1_cinvCodeAny.Text + "' \r\n";
                    }
                }
                else
                {
                    if (tab1_cInvCodeL.Text.Length > 0 && tab1_cInvCodeH.Text.Length == 0)
                    {
                        mySelectQuery += "  and  a.cinvcode ='" + tab1_cInvCodeL.Text + "' \r\n";
                    }
                    else if (tab1_cInvCodeL.Text.Length == 0 && tab1_cInvCodeH.Text.Length > 0)
                    {
                        mySelectQuery += "  and  a.cinvcode ='" + tab1_cInvCodeH.Text + "' \r\n";
                    }
                    else if (tab1_cInvCodeL.Text.Length > 0 && tab1_cInvCodeH.Text.Length > 0)
                    {
                        mySelectQuery += "  and  a.cinvcode between  '" + tab1_cInvCodeL.Text + "' and '" + tab1_cInvCodeH.Text + "'  \r\n";
                    }
                }

                if (DocTypeNo.Length > 0)
                {
                    mySelectQuery += "  and  a.DocTypeNo in (" + DocTypeNo + ")";
                }
                if (!showAllData)
                {
                    mySelectQuery += "  order by a.cinvcode,a.dDate,a.cCode   \r\n";
                }
                else
                {
                    mySelectQuery += "  order by a.cinvcode,a.DocTypeNo  ,a.dDate,a.cCode   \r\n";
                }


                OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConn);
                this.tab4_dataGridView1.AutoGenerateColumns = true;
                //设置数据源    


                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
                da.Fill(ds);

                this.tab1_dataGridView1.DataSource = ds.Tables[0];//数据源 


                //标准居中
                this.tab1_dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //设置自动换行

                this.tab1_dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //设置自动调整高度

                this.tab1_dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }


                for (int i = 0; i < tab1_dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        tab1_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                    }
                }

                for (int i = 0; i < tab1_dataGridView1.Columns.Count; i++)
                {
                    tab1_dataGridView1.Columns[i].ReadOnly = true;

                }

                if (!showAllData)
                {
                    if (tab1_dataGridView1.Columns.Count > 0)
                    {
                        tab1_dataGridView1.Columns[12].DefaultCellStyle.Format = "#,###0";
                        tab1_dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
                else
                {
                    for (int i = 12; i < tab1_dataGridView1.Columns.Count; i++)
                    {
                        tab1_dataGridView1.Columns[i].DefaultCellStyle.Format = "#,###0";
                        tab1_dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }


                this.Text = mTitle + "   查询完成！共" + (tab1_dataGridView1.RowCount).ToString() + "行";
                System.Windows.Forms.Application.DoEvents();
            }

            catch (Exception ex)
            {
                this.Text = mTitle;
                MessageBox.Show(this, ex.ToString(), "PDBOM.btnQuery_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void tab2_cInvCodeL_Leave(object sender, EventArgs e)
        {

            if (tab2_cInvCodeH.Text.Length == 0 && tab2_cInvCodeL.Text.Length > 0)
            {
                tab2_cInvCodeH.Text = tab2_cInvCodeL.Text;
            }
        }



        private void tab2_dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0)
                {
                    return;
                }


                if (e.RowIndex < 0)
                {
                    return;
                }

                if (tab2_dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Length == 0)
                {
                    return;
                }
                else
                {

                    tab1_cInvCodeL.Text = tab2_dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    tab1_cInvCodeH.Text = tab1_cInvCodeL.Text;
                    if (e.ColumnIndex >= 0 && e.ColumnIndex <= 3)
                    {
                        tabControl1.SelectedIndex = 2;
                        DedtailQuery(true, "");
                        this.Text = mTitle;
                    }
                    switch (e.ColumnIndex)
                    {

                        case 7:
                            {
                                tabControl1.SelectedIndex = 1;
                                DedtailQuery(chkShowAll.Checked, "3");//在检
                                this.Text = mTitle + "  到货在检量";
                                break;
                            }
                        case 5:
                            {
                                tabControl1.SelectedIndex = 1;
                                DedtailQuery(chkShowAll.Checked, "1,2");//采购在途
                                this.Text = mTitle + "  采购在途";
                                break;
                            }
                        case 8:
                            {
                                tabControl1.SelectedIndex = 1;
                                DedtailQuery(chkShowAll.Checked, "4");//现存量
                                this.Text = mTitle + "  现存量";
                                break;
                            }
                        case 4:
                            {
                                tabControl1.SelectedIndex = 1;
                                DedtailQuery(chkShowAll.Checked, "5");//在制
                                this.Text = mTitle + "  在制";
                                break;
                            }
                        case 10:
                            {
                                tabControl1.SelectedIndex = 1;
                                DedtailQuery(chkShowAll.Checked, "6,7");//已分配量
                                this.Text = mTitle + "  已分配量";
                                break;
                            }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "tab2_dataGridView1_CellMouseDoubleClick()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 显示综合库存
        /// </summary>
        private void CompreStok()
        {
            try
            {

                this.Text = mTitle + "   正在查询，请稍候...";
                System.Windows.Forms.Application.DoEvents();

                OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
                myConn.Open();


                string mySelectQuery = "";

                //合计

                mySelectQuery += "   \r\n";
                mySelectQuery += " select '合计' as  'DocType' ,'' as 'cCode',null as 'dDate','' as 'cDefine30',a.cinvcode,p.cInvName,replace(replace(p.cinvstd,'''',''),'\"','') as cInvStd,p.cInvDefine7 ,a.moQty,a.Now_PurArrQty,a.Now_PurQty,a.CurSotckQty, (isnull(a.Now_PurArrQty,0)+isnull(a.CurSotckQty,0)) as 'allSotckQty',a.useQty, a.toArrQty, \r\n";
                if (tab1_chkPurQtyState.Checked)
                {
                    //可用量=即将到货+到货在检+现存量-已分配量
                    mySelectQuery += "   (isnull(a.toArrQty,0)+isnull(a.Now_PurArrQty,0)+isnull(a.CurSotckQty,0)-isnull(a.useQty,0)) as  'AvailableQty'   from   \r\n";
                    tab2_toArrQty.HeaderText = "即将到货(A)";
                    tab2_Now_PurQty.HeaderText = "采购在途";
                }
                else
                {
                    //可用量=采购在途+到货在检+现存量-已分配量
                    mySelectQuery += "   (isnull(a.Now_PurQty,0)+isnull(a.Now_PurArrQty,0)+isnull(a.CurSotckQty,0)-isnull(a.useQty,0)) as  'AvailableQty'   from   \r\n";
                    tab2_toArrQty.HeaderText = "即将到货";
                    tab2_Now_PurQty.HeaderText = "采购在途(A)";
                }
                mySelectQuery += " (select cinvcode,sum(isnull(moQty,0)) as 'moQty',sum(isnull(Now_PurArrQty,0)) as 'Now_PurArrQty',sum(isnull(Now_PurQty,0)) as 'Now_PurQty',  sum(isnull(CurSotckQty,0)) as 'CurSotckQty',  \r\n";
                mySelectQuery += " sum(isnull(useQty,0)) as 'useQty',sum(isnull(toArrQty,0)) as 'toArrQty'  \r\n";
                mySelectQuery += "    from " + wComprehensiveStock.ComprehensiveStockInfo(iLoginEx, 0, "", "", "", iLoginEx.pubDB_UF(), "","") + " vw    \r\n";
                mySelectQuery += "     where  1=1 ";

                tab2_cinvCodeAny.Text = tab2_cinvCodeAny.Text.Trim();
                tab2_cinvCodeAny.Text = tab2_cinvCodeAny.Text.Replace("；", ";");

                if (tab2_cinvCodeAny.Text.Length > 0)
                {
                    string cinvCodeChild = "";
                    string[] paraCinvCode = tab2_cinvCodeAny.Text.Split(';');
                    if (paraCinvCode.Length > 0)
                    {
                        for (int i = 0; i < paraCinvCode.Length; i++)
                        {
                            cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                        }

                        mySelectQuery += " and  cinvcode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                    }
                    else
                    {
                        mySelectQuery += " and  cinvcode ='" + tab2_cinvCodeAny.Text + "' \r\n";
                    }
                }
                else
                {
                    if (tab2_cInvCodeL.Text.Length > 0 && tab2_cInvCodeH.Text.Length == 0)
                    {
                        mySelectQuery += " and  cinvcode ='" + tab2_cInvCodeL.Text + "' \r\n";
                    }
                    else if (tab2_cInvCodeL.Text.Length == 0 && tab2_cInvCodeH.Text.Length > 0)
                    {
                        mySelectQuery += "  and  cinvcode ='" + tab2_cInvCodeH.Text + "' \r\n";
                    }
                    else if (tab2_cInvCodeL.Text.Length > 0 && tab2_cInvCodeH.Text.Length > 0)
                    {
                        mySelectQuery += "  and  cinvcode between  '" + tab2_cInvCodeL.Text + "' and '" + tab2_cInvCodeH.Text + "'  \r\n";
                    }
                }

                mySelectQuery += "  group by cinvcode) a left join inventory p on a.cinvcode=p.cinvcode    \r\n";

                if (tab2_chkMissingOnly.Checked)
                {
                    if (tab1_chkPurQtyState.Checked)
                    {
                        //可用量=即将到货+到货在检+现存量-已分配量
                        mySelectQuery += " where   (isnull(a.toArrQty,0)+isnull(a.Now_PurArrQty,0)+isnull(a.CurSotckQty,0)-isnull(a.useQty,0)) <0 \r\n";
                    }
                    else
                    {
                        //可用量=采购在途+到货在检+现存量-已分配量
                        mySelectQuery += "  where (isnull(a.Now_PurQty,0)+isnull(a.Now_PurArrQty,0)+isnull(a.CurSotckQty,0)-isnull(a.useQty,0))  <0  \r\n";
                    }

                }

                mySelectQuery += "  order by a.cinvcode   \r\n";

                OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConn);
                this.tab2_dataGridView1.AutoGenerateColumns = false;//不自动生成列
                //设置数据源    


                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
                da.Fill(ds);
                this.tab2_dataGridView1.DataSource = ds.Tables[0];//数据源 


                //标准居中
                this.tab2_dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //设置自动换行

                this.tab2_dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //设置自动调整高度

                this.tab2_dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }


                for (int i = 0; i < tab2_dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        tab2_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                    }
                }



                this.Text = mTitle + "   查询完成！共" + (tab2_dataGridView1.RowCount).ToString() + "行";
                System.Windows.Forms.Application.DoEvents();
            }

            catch (Exception ex)
            {
                this.Text = mTitle;
                MessageBox.Show(this, ex.ToString(), "PDBOM.btnQuery_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void toolQuery_Click(object sender, EventArgs e)
        {
            toolQuery.Enabled = false;
            SLBTotal.Text = "";
            string DocTypeNo = "";
            try
            {
                if (tabControl1.SelectedTab == tab5StokWarning)
                {
                    StokWarning();//呆料预警表
                }
                else if (tabControl1.SelectedTab == tab1CompreStok)
                {
                    CompreStok();
                }
                else if (tabControl1.SelectedTab == tab2DedtailQuery)
                {
                    if (tab1_chkShow12.Checked)
                    {
                        DocTypeNo += "1,2,";
                    }
                    if (tab1_chkShow3.Checked)
                    {
                        DocTypeNo += "3,";
                    }
                    if (tab1_chkShow5.Checked)
                    {
                        DocTypeNo += "5,";
                    }
                    if (tab1_chkShow67.Checked)
                    {
                        DocTypeNo += "6,7,";
                    }

                    if (tab1_chkShow4.Checked)
                    {
                        DocTypeNo += "4,";
                    }
                    if (DocTypeNo.Length > 0)
                    {
                        DocTypeNo += "\r\r\n\n";
                        DedtailQuery(true, DocTypeNo.Replace(",\r\r\n\n", ""));
                    }
                    else
                    {
                        MessageBox.Show(this, "未选【采购在途】、【到货在检】、【现存量】、【在制】、【已分配量】中的任何选项", "库存明细", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (tabControl1.SelectedTab == tab3PU_AppVouchBasis)
                {
                    PU_AppVouchBasis();
                }
                else if (tabControl1.SelectedTab == tab4mom_orderBasis)
                {
                    mom_orderBasis();
                }


                for (int i = 0; i < tab1_dataGridView1.Columns.Count; i++)
                {
                    tab1_dataGridView1.Columns[i].ReadOnly = true;

                }
                for (int i = 0; i < tab2_dataGridView1.Columns.Count; i++)
                {
                    tab2_dataGridView1.Columns[i].ReadOnly = true;

                }
                for (int i = 0; i < tab3_dataGridView1.Columns.Count; i++)
                {
                    tab3_dataGridView1.Columns[i].ReadOnly = true;

                }
            }
            catch (Exception ex)
            {
                this.Text = mTitle;
                MessageBox.Show(this, ex.ToString(), "PDBOM.btnQuery_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                toolQuery.Enabled = true;
            }
        }
        /// <summary>
        /// 请购依据
        /// </summary>
        private void PU_AppVouchBasis()
        {
            try
            {
                string cinvCodeChild = "";
                string[] paraCinvCode = null;
                this.Text = mTitle + "   正在查询，请稍候...";
                System.Windows.Forms.Application.DoEvents();

                OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
                myConn.Open();

                OleDbCommand myCommand = new OleDbCommand(" delete PU_AppVouchs_zhrs_mrp  where AutoID not in (select AutoID from PU_AppVouchs (nolock)) \r\n", myConn);
                myCommand.ExecuteNonQuery();

                string mySelectQuery = "";
                mySelectQuery = " select b.cCode as'请购单号',b.dDate as'请购单日期',b.cMaker as'请购制单人',m.mrpdatetime as '核算时间',a.cInvCode as '物料编码',i.cInvName as'物料名称',replace(replace(i.cinvstd,'''',''),'\"','')  as '规格',a.fQuantity as'请购数',m.Now_PurQty as'采购在途',m.toArrQty as '即将到货',m.Now_PurArrQty as '到货在检',m.CurSotckQty as '现存量',\r\n";
                mySelectQuery += " '在库数'=(m.Now_PurArrQty+m.CurSotckQty),m.useQty as'已分配量','可用量'=(m.Now_PurQty+(m.Now_PurArrQty+m.CurSotckQty)-m.useQty) \r\n";
                mySelectQuery += "  from PU_AppVouchs_zhrs_mrp m(nolock)  left join   PU_AppVouchs a(nolock) on m.id=a.id and a.AutoID=m.AutoID \r\n";
                mySelectQuery += " left join  PU_AppVouch b (nolock) on a.id=b.id  \r\n";
                mySelectQuery += " left join inventory i (nolock) on i.cInvCode=a.cInvCode  where 1=1 \r\n";

                tab3_cInvCode.Text = tab3_cInvCode.Text.Trim();
                tab3_cInvCode.Text = tab3_cInvCode.Text.Replace("；", ";");

                if (tab3_cInvCode.Text.Length > 0)
                {
                    cinvCodeChild = "";
                    paraCinvCode = tab3_cInvCode.Text.Split(';');
                    if (paraCinvCode.Length > 0)
                    {
                        for (int i = 0; i < paraCinvCode.Length; i++)
                        {
                            cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                        }

                        mySelectQuery += " and  a.cinvcode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                    }
                    else
                    {
                        mySelectQuery += " and  a.cinvcode ='" + tab3_cInvCode.Text + "' \r\n";
                    }
                }

                tab3_cCode.Text = tab3_cCode.Text.Trim();
                tab3_cCode.Text = tab3_cCode.Text.Replace("；", ";");

                if (tab3_cCode.Text.Length > 0)
                {
                    cinvCodeChild = "";
                    paraCinvCode = tab3_cCode.Text.Split(';');
                    if (paraCinvCode.Length > 0)
                    {
                        for (int i = 0; i < paraCinvCode.Length; i++)
                        {
                            cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                        }

                        mySelectQuery += " and  b.cCode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                    }
                    else
                    {
                        mySelectQuery += " and  b.cCode ='" + tab3_cCode.Text + "' \r\n";
                    }
                }


                if (tab3_cMaker.Text.Trim().Length > 0)
                {
                    mySelectQuery += " and  b.cMaker ='" + tab3_cMaker.Text + "' \r\n";
                }

                if (tab3_dDateLCHK.Checked && tab3_dDateHCHK.Checked)
                {
                    mySelectQuery += " and  b.dDate between  '" + tab3_dDateL.Value.ToString("yyyy-MM-dd") + "' and '" + tab3_dDateH.Value.ToString("yyyy-MM-dd") + "' \r\n";
                }
                else if (tab3_dDateLCHK.Checked)
                {
                    mySelectQuery += " and  b.dDate >= '" + tab3_dDateL.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                }
                else if (tab3_dDateHCHK.Checked)
                {
                    mySelectQuery += " and  b.dDate <='" + tab3_dDateH.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                }

                myCommand.CommandText = mySelectQuery;

                this.tab3_dataGridView1.AutoGenerateColumns = true;
                //设置数据源    


                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
                da.Fill(ds);
                this.tab3_dataGridView1.DataSource = ds.Tables[0];//数据源 


                //标准居中
                this.tab3_dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //设置自动换行

                this.tab3_dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //设置自动调整高度

                this.tab3_dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }

                for (int i = 0; i < tab3_dataGridView1.Columns.Count; i++)
                {
                    tab3_dataGridView1.Columns[i].ReadOnly = true;

                }


                for (int i = 0; i < tab3_dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        tab3_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                    }
                }
                tab3_dataGridView1.Columns[3].Width = 120;
                for (int i = 5; i < tab3_dataGridView1.Columns.Count; i++)
                {
                    tab3_dataGridView1.Columns[i].DefaultCellStyle.Format = "#,###0";
                    tab3_dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                this.Text = mTitle + "   查询完成！共" + (tab3_dataGridView1.RowCount).ToString() + "行";
                System.Windows.Forms.Application.DoEvents();
            }

            catch (Exception ex)
            {
                this.Text = mTitle;
                MessageBox.Show(this, ex.ToString(), "PU_AppVouchBasis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 制告单依据
        /// </summary>
        private void mom_orderBasis()
        {
            try
            {
                string cinvCodeChild = "";
                string[] paraCinvCode = null;
                this.Text = mTitle + "   正在查询，请稍候...";
                System.Windows.Forms.Application.DoEvents();

                OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
                myConn.Open();


                string selectSQL = " ";

                selectSQL = "select m.PlanningSortSeq as '排产序号',c.MoCode as '制造单号',b.StartDate as '开工日期',u.cUser_Name as '制单人', m.mrpdatetime as '核算时间',m.sortseq as '制造单行号',a.invcode as '物料编码',i.cInvName as'物料名称',replace(replace(i.cinvstd,'''',''),'\"','')  as '规格',  \r\n";
                selectSQL += " a.qty as '制造单数量',m.moQty as '在制数',m.CursotckQty as '现存量',m.useQty as'已分配量'  \r\n";
                selectSQL += "  from mom_orderdetail_zhrs_mrp  m(nolock)  \r\n";
                selectSQL += "   left join mom_orderdetail a (nolock) on  a.moid=m.moid and a.modid=m.modid and a.partid=m.partid and a.sortseq=m.sortseq  \r\n";
                selectSQL += "   left join mom_morder b (nolock) on a.moid=b.moid and a.modid=b.modid  \r\n";
                selectSQL += "   left join mom_order c  (nolock) on a.moid=c.moid  \r\n";
                selectSQL += "   left join inventory i (nolock)  on i.cInvCode=a.InvCode  \r\n";
                selectSQL += "     left join " + iLoginEx.pubDB_UF() + "..UA_User u(nolock) on c.CreateUser=u.cUser_Id  where 1=1 \r\n";

                tab4_cInvCode.Text = tab4_cInvCode.Text.Trim();
                tab4_cInvCode.Text = tab4_cInvCode.Text.Replace("；", ";");

                if (tab4_cInvCode.Text.Length > 0)
                {
                    cinvCodeChild = "";
                    paraCinvCode = tab4_cInvCode.Text.Split(';');
                    if (paraCinvCode.Length > 0)
                    {
                        for (int i = 0; i < paraCinvCode.Length; i++)
                        {
                            cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                        }

                        selectSQL += " and  a.invcode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                    }
                    else
                    {
                        selectSQL += " and  a.invcode ='" + tab4_cInvCode.Text + "' \r\n";
                    }
                }

                tab4_MoCode.Text = tab4_MoCode.Text.Trim();
                tab4_MoCode.Text = tab4_MoCode.Text.Replace("；", ";");

                if (tab4_MoCode.Text.Length > 0)
                {
                    cinvCodeChild = "";
                    paraCinvCode = tab4_MoCode.Text.Split(';');
                    if (paraCinvCode.Length > 0)
                    {
                        for (int i = 0; i < paraCinvCode.Length; i++)
                        {
                            cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                        }

                        selectSQL += " and  c.MoCode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                    }
                    else
                    {
                        selectSQL += " and  c.MoCode ='" + tab4_MoCode.Text + "' \r\n";
                    }
                }


                if (tab4_CreateUser.Text.Trim().Length > 0)
                {
                    selectSQL += " and  c.CreateUser ='" + tab4_CreateUser.Text + "' order by  m.PlanningSortSeq,c.MoCode,m.sortseq \r\n";
                }


                OleDbCommand myCommand = new OleDbCommand(selectSQL, myConn);

                this.tab4_dataGridView1.AutoGenerateColumns = true;
                //设置数据源    


                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
                da.Fill(ds);
                this.tab4_dataGridView1.DataSource = ds.Tables[0];//数据源 


                //标准居中
                this.tab4_dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //设置自动换行

                this.tab4_dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //设置自动调整高度

                this.tab4_dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }

                for (int i = 0; i < tab4_dataGridView1.Columns.Count; i++)
                {
                    tab4_dataGridView1.Columns[i].ReadOnly = true;

                }


                for (int i = 0; i < tab4_dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        tab4_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                    }
                }
                tab4_dataGridView1.Columns[3].Width = 120;
                for (int i = 5; i < tab4_dataGridView1.Columns.Count; i++)
                {
                    tab4_dataGridView1.Columns[i].DefaultCellStyle.Format = "#,###0";
                    tab4_dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                this.Text = mTitle + "   查询完成！共" + (tab4_dataGridView1.RowCount).ToString() + "行";
                System.Windows.Forms.Application.DoEvents();
            }

            catch (Exception ex)
            {
                this.Text = mTitle;
                MessageBox.Show(this, ex.ToString(), "mom_orderBasis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void toolToExcel_Click(object sender, EventArgs e)
        {
            toolToExcel.Enabled = false;

            try
            {
                this.Text = mTitle;

                if (tabControl1.SelectedTab == tab5StokWarning)
                {
                    iLoginEx.ExportExcel("库存呆料预警表_" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_").Replace(".", "_").Replace(":", "_").Replace("/", "_").Replace(" ", "_"), "库存呆料预警表", tab5_dataGridView1, 3);
                }
                else if (tabControl1.SelectedTab == tab1CompreStok)
                {
                    iLoginEx.ExportExcel("库存综合查询_" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_").Replace(".", "_").Replace(":", "_").Replace("/", "_").Replace(" ", "_"), "库存综合查询", tab2_dataGridView1, 4);
                }
                else if (tabControl1.SelectedTab == tab2DedtailQuery)
                {
                    iLoginEx.ExportExcel("库存综合查询明细_" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_").Replace(".", "_").Replace(":", "_").Replace("/", "_").Replace(" ", "_"), "库存综合查询明细", tab1_dataGridView1, 8);

                }
                else if (tabControl1.SelectedTab == tab3PU_AppVouchBasis)
                {
                    iLoginEx.ExportExcel("请购来源_" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_").Replace(".", "_").Replace(":", "_").Replace("/", "_").Replace(" ", "_"), "请购来源", tab3_dataGridView1, 7);
                }
                else if (tabControl1.SelectedTab == tab4mom_orderBasis)
                {
                    iLoginEx.ExportExcel("制造单来源_" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_").Replace(".", "_").Replace(":", "_").Replace("/", "_").Replace(" ", "_"), "制造单来源", tab4_dataGridView1, 9);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.ToString(), "toolToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                this.Text = mTitle;
                toolToExcel.Enabled = true;
            }
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPreprocessPurData_Load(object sender, EventArgs e)
        {
            try
            {
                FormWidth = this.Width;
                FormHeight = this.Height;
                tabPageWidth = tabControl1.Width;
                tabPageHeight = tabControl1.Height;
                dataGridViewWidth = tab1_dataGridView1.Width;
                dataGridViewHeight = tab1_dataGridView1.Height;

                dataGridViewWidth2 = tab2_dataGridView1.Width;
                dataGridViewHeight2 = tab2_dataGridView1.Height;
                tab3_dataGridView1Width = tab3_dataGridView1.Width;
                tab3_dataGridView1Height = tab3_dataGridView1.Height;

                tab5_dataGridView1Width = tab5_dataGridView1.Width;
                tab5_dataGridView1Height = tab5_dataGridView1.Height;

                tab4_dataGridView1Width = tab4_dataGridView1.Width;
                tab4_dataGridView1Height = tab4_dataGridView1.Height;


                tab2_DateL.Value = DateTime.Now;
                tab2_DateH.Value = DateTime.Now;
                tab2_DateL.Enabled = false;
                tab2_DateH.Enabled = false;
                tab3_dDateL.Enabled = false;
                tab3_dDateH.Enabled = false;


                if (mproType == 0)
                {
                    mTitle = "库存综合查询";
                    tab5StokWarning.Parent = null;
                }
                else
                {
                    tab3PU_AppVouchBasis.Parent = null;
                    tab4mom_orderBasis.Parent = null;
                    //tab1CompreStok.Parent = null; 
                    mTitle = "呆料预警表";
                }
                this.Text = mTitle;



                DateTime dt = DateTime.Now;
                DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
                DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末//
                tab3_dDateL.Value = startMonth;
                tab3_dDateH.Value = endMonth;

                ini = new Ini(System.Windows.Forms.Application.StartupPath.ToString() + "\\rserpconfig.ini");
                if (ini.ReadValue("Production", "ShowProd").Trim().Length == 0)
                {
                    ini.Writue("Production", "ShowProd", "Y");
                }
                if (ini.ReadValue("Production", "ShowProd") == "Y")
                {
                    chkShowProd.Checked = true;

                    if (tab1_dataGridView1.Columns.Count > 0)
                    {
                        tab1_dataGridView1.Columns[5].Visible = true;
                        tab1_dataGridView1.Columns[6].Visible = true;
                        tab1_dataGridView1.Columns[7].Visible = true;
                    }
                }
                else
                {
                    chkShowProd.Checked = false;
                    if (tab1_dataGridView1.Columns.Count > 0)
                    {
                        tab1_dataGridView1.Columns[5].Visible = false;
                        tab1_dataGridView1.Columns[6].Visible = false;
                        tab1_dataGridView1.Columns[7].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.ToString(), "frmPreprocessPurData_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmPreprocessPurData_Resize(object sender, EventArgs e)
        {
            IniFile.Ini ini = new IniFile.Ini(System.Windows.Forms.Application.StartupPath.ToString() + "\\utconfig.ini");
            ini.Writue("Window", "AutoAdaptive2", "");
            if (ini.ReadValue("Window", "AutoAdaptive") != "N")
            {
                tabControl1.Width = tabPageWidth + (this.Width - FormWidth);
                tabControl1.Height = tabPageHeight + (this.Height - FormHeight);

                tab1_dataGridView1.Width = dataGridViewWidth + (this.Width - FormWidth);
                tab1_dataGridView1.Height = dataGridViewHeight + (this.Height - FormHeight);

                tab2_dataGridView1.Width = dataGridViewWidth2 + (this.Width - FormWidth);
                tab2_dataGridView1.Height = dataGridViewHeight2 + (this.Height - FormHeight);

                tab3_dataGridView1.Width = tab3_dataGridView1Width + (this.Width - FormWidth);
                tab3_dataGridView1.Height = tab3_dataGridView1Height + (this.Height - FormHeight);

                tab4_dataGridView1.Width = tab4_dataGridView1Width + (this.Width - FormWidth);
                tab4_dataGridView1.Height = tab4_dataGridView1Height + (this.Height - FormHeight);

                tab5_dataGridView1.Width = tab5_dataGridView1Width + (this.Width - FormWidth);
                tab5_dataGridView1.Height = tab5_dataGridView1Height + (this.Height - FormHeight);
            }

        }

        private void frmPreprocessPurData_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void tab1_cInvCodeL_Leave(object sender, EventArgs e)
        {
            if (tab1_cInvCodeH.Text.Length == 0 && tab1_cInvCodeL.Text.Length > 0)
            {
                tab1_cInvCodeH.Text = tab1_cInvCodeL.Text;
            }
        }

        private void chkShowProd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowProd.Checked)
            {
                if (tab1_dataGridView1.Columns.Count > 0)
                {
                    tab1_dataGridView1.Columns[5].Visible = true;
                    tab1_dataGridView1.Columns[6].Visible = true;
                    tab1_dataGridView1.Columns[7].Visible = true;
                }
                ini.Writue("Production", "ShowProd", "Y");
            }
            else
            {
                if (tab1_dataGridView1.Columns.Count > 0)
                {
                    tab1_dataGridView1.Columns[5].Visible = false;
                    tab1_dataGridView1.Columns[6].Visible = false;
                    tab1_dataGridView1.Columns[7].Visible = false;
                }
                ini.Writue("Production", "ShowProd", "N");
            }
        }

        private void tab2_dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < tab2_dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tab2_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                }
            }
        }

        private void tab1_dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < tab1_dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tab1_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                }
            }
        }

        private void tab3_dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < tab3_dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tab3_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                }
            }
        }

        private void tab4_dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < tab4_dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tab4_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                }
            }
        }

        private void tab2_cInvCodeL_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            tab2_cInvCodeL.Text = iLoginEx.OpenSelectWindow("物料", "select cInvCode as '料号',cInvName  as '品名',cInvStd  as '规格' from  inventory  (nolock)", tab2_cInvCodeL.Text, 430, 300, 1);
            string[] para = tab2_cInvCodeL.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab2_cInvCodeL.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab2_cInvCodeH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tab2_cInvCodeH.Text = iLoginEx.OpenSelectWindow("物料", "select cInvCode as '料号',cInvName  as '品名',cInvStd  as '规格' from  inventory  (nolock)", tab2_cInvCodeH.Text, 430, 300, 1);
            string[] para = tab2_cInvCodeH.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab2_cInvCodeH.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab1_cInvCodeL_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tab1_cInvCodeL.Text = iLoginEx.OpenSelectWindow("物料", "select cInvCode as '料号',cInvName  as '品名',cInvStd  as '规格' from  inventory  (nolock)", tab1_cInvCodeL.Text, 430, 300, 1);
            string[] para = tab1_cInvCodeL.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab1_cInvCodeL.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab1_cInvCodeH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tab1_cInvCodeH.Text = iLoginEx.OpenSelectWindow("物料", "select cInvCode as '料号',cInvName  as '品名',cInvStd  as '规格' from  inventory  (nolock)", tab1_cInvCodeH.Text, 430, 300, 1);
            string[] para = tab1_cInvCodeH.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab1_cInvCodeH.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab3_cInvCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tab3_cInvCode.Text = iLoginEx.OpenSelectWindow("物料", "select cInvCode as '料号',cInvName  as '品名',cInvStd  as '规格' from  inventory  (nolock)", tab3_cInvCode.Text, 430, 300, 1);
            string[] para = tab3_cInvCode.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab3_cInvCode.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab4_cInvCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tab4_cInvCode.Text = iLoginEx.OpenSelectWindow("物料", "select cInvCode as '料号',cInvName  as '品名',cInvStd  as '规格' from  inventory  (nolock)", tab4_cInvCode.Text, 430, 300, 1);
            string[] para = tab4_cInvCode.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab4_cInvCode.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab3_cCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            tab3_cCode.Text = iLoginEx.OpenSelectWindow("请购单", "select cCode as '请购单号' from Pu_AppVouch (nolock)", tab3_cCode.Text, 430, 300, 1);
            string[] para = tab3_cCode.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab3_cCode.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab3_cMaker_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            tab3_cMaker.Text = iLoginEx.OpenSelectWindow("制单人", "select cUser_Name as '制单人' from  " + iLoginEx.pubDB_UF() + "..UA_User u  (nolock)", tab3_cMaker.Text, 430, 300, 1);
            string[] para = tab3_cMaker.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab3_cMaker.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab4_MoCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tab4_MoCode.Text = iLoginEx.OpenSelectWindow("制造单号", "select  MoCode as '制造单号' from mom_order  (nolock)", tab4_MoCode.Text, 430, 300, 1);
            string[] para = tab4_MoCode.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab4_MoCode.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab4_CreateUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tab4_CreateUser.Text = iLoginEx.OpenSelectWindow("制单人", "select cUser_ID as '帐号',cUser_Name as '制单人' from  " + iLoginEx.pubDB_UF() + "..UA_User u  (nolock)", tab4_CreateUser.Text, 430, 300, 1);
            string[] para = tab4_CreateUser.Text.Split(new string[] { "\r\n\r\n\r\n " }, StringSplitOptions.None);
            if (para.Length > 1)
            {
                tab4_CreateUser.Text = para[0];
                //wName = para[0];  
            }
        }

        private void tab2_DateLCHK_CheckedChanged(object sender, EventArgs e)
        {
            if (tab2_DateLCHK.Checked)
            {
                tab2_DateL.Enabled = true;
            }
            else
            {
                tab2_DateL.Enabled = false;
            }
        }

        private void tab2_DateHCHK_CheckedChanged(object sender, EventArgs e)
        {
            if (tab2_DateHCHK.Checked)
            {
                tab2_DateH.Enabled = true;
            }
            else
            {
                tab2_DateH.Enabled = false;
            }
        }

        private void tab3_dDateLCHK_CheckedChanged(object sender, EventArgs e)
        {
            if (tab3_dDateLCHK.Checked)
            {
                tab3_dDateL.Enabled = true;
            }
            else
            {
                tab3_dDateL.Enabled = false;
            }
        }

        private void tab3_dDateHCHK_CheckedChanged(object sender, EventArgs e)
        {
            if (tab3_dDateHCHK.Checked)
            {
                tab3_dDateH.Enabled = true;
            }
            else
            {
                tab3_dDateH.Enabled = false;
            }
        }

        private void tab1_dataGridView1_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseDown = true;
            SLBTotal.Text = "";
        }

        private void tab1_dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex >= 0 && e.ColumnIndex <= 11)
                //{
                double SelectTotal = 0.0;
                int selectedCellCount = tab1_dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                if (selectedCellCount > 0 && CellMouseDown)
                {
                    SelectTotal = 0.0;
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        SelectTotal += Convert.ToDouble(Convert.ToString(Convert.IsDBNull(tab1_dataGridView1.SelectedCells[i].Value) ? "" : tab1_dataGridView1.SelectedCells[i].Value) == "" ? "0" : tab1_dataGridView1.SelectedCells[i].Value.ToString());
                    }
                    SLBTotal.Text = string.Format("{0:N0}", SelectTotal);
                }
                //}

            }
            catch
            {
            }
        }

        private void tab1_dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            tab1_dataGridView1_CellMouseMove(sender, e);
            CellMouseDown = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SLBTotal.Text = "";
        }

        private void tab3_dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseDown = true;
            SLBTotal.Text = "";
        }

        private void tab3_dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex >= 0 && e.ColumnIndex <= 11)
                //{
                double SelectTotal = 0.0;
                int selectedCellCount = tab3_dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                if (selectedCellCount > 0 && CellMouseDown)
                {
                    SelectTotal = 0.0;
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        SelectTotal += Convert.ToDouble(Convert.ToString(Convert.IsDBNull(tab3_dataGridView1.SelectedCells[i].Value) ? "" : tab3_dataGridView1.SelectedCells[i].Value) == "" ? "0" : tab3_dataGridView1.SelectedCells[i].Value.ToString());
                    }
                    SLBTotal.Text = string.Format("{0:N0}", SelectTotal);
                }
                //}

            }
            catch
            {
            }
        }

        private void tab3_dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            tab3_dataGridView1_CellMouseMove(sender, e);
            CellMouseDown = false;
        }

        private void tab4_dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseDown = true;
            SLBTotal.Text = "";
        }

        private void tab4_dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex >= 0 && e.ColumnIndex <= 11)
                //{
                double SelectTotal = 0.0;
                int selectedCellCount = tab4_dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                if (selectedCellCount > 0 && CellMouseDown)
                {
                    SelectTotal = 0.0;
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        SelectTotal += Convert.ToDouble(Convert.ToString(Convert.IsDBNull(tab4_dataGridView1.SelectedCells[i].Value) ? "" : tab4_dataGridView1.SelectedCells[i].Value) == "" ? "0" : tab4_dataGridView1.SelectedCells[i].Value.ToString());
                    }
                    SLBTotal.Text = string.Format("{0:N0}", SelectTotal);
                }
                //}

            }
            catch
            {
            }
        }

        private void tab4_dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            tab4_dataGridView1_CellMouseMove(sender, e);
            CellMouseDown = false;
        }

        private void tab1_dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (mproType == 0)
            //{
            tab2_cInvCodeL.Text = tab1_dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            tab2_cInvCodeH.Text = tab2_cInvCodeL.Text;
            CompreStok();
            tabControl1.SelectedIndex = 1;
            //}
        }

        private void tab5_dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseDown = true;
            SLBTotal.Text = "";
        }

        private void tab5_dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex >= 0 && e.ColumnIndex <= 11)
                //{
                double SelectTotal = 0.0;
                int selectedCellCount = tab5_dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                if (selectedCellCount > 0 && CellMouseDown)
                {
                    SelectTotal = 0.0;
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        SelectTotal += Convert.ToDouble(Convert.ToString(Convert.IsDBNull(tab5_dataGridView1.SelectedCells[i].Value) ? "" : tab5_dataGridView1.SelectedCells[i].Value) == "" ? "0" : tab5_dataGridView1.SelectedCells[i].Value.ToString());
                    }
                    SLBTotal.Text = string.Format("{0:N0}", SelectTotal);
                }
                //}

            }
            catch
            {
            }
        }

        private void tab5_dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            tab5_dataGridView1_CellMouseMove(sender, e);
            CellMouseDown = false;
        }

        private void tab5_dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (Tab2_SaveCulomnsWidth && tab1_dataGridView1.Columns.Count > 0)
            {

                string ColumnsWidths = "";
                for (int i = 0; i < tab1_dataGridView1.Columns.Count; i++)
                {
                    ColumnsWidths += tab1_dataGridView1.Columns[i].Width.ToString() + ";";
                }
                ColumnsWidths += iLoginEx.Chr(8);
                ColumnsWidths = ColumnsWidths.Replace(";" + iLoginEx.Chr(8), "");

                iLoginEx.WriteUserProfileValue("tab5StokWarning", "ColumnsWidths", ColumnsWidths);
            }

        }
        /// <summary>
        /// 出库明细
        /// </summary>
        private void StockOutList()
        {

            try
            {
                string selectSQL = "select w.cWhName  as '仓库名称',b.cCode as '出库单号',b.dDate as '出库日期',a.cinvcode as '物料编码',i.cInvName as'物料名称',i.cInvStd as '规格型号',  \r\n";
                selectSQL += " a.cmocode as '制造单号',a.invcode as '成品半成品编码',a.iQuantity as '出库数量'   \r\n";
                selectSQL += " from RdRecords a (nolock) left join RdRecord b (nolock)on a.id=b.id   \r\n";
                selectSQL += "  left join Warehouse  w (nolock) on b.cWhCode=w.cWhCode   \r\n";
                selectSQL += "  left join Inventory i (nolock) on i.cInvCode=a.cInvCode   \r\n";
                selectSQL += "  where b.cVouchType='11'   \r\n";

                if (tab1_cInvCodeL.Text.Length > 0 && tab1_cInvCodeH.Text.Length == 0)
                {
                    selectSQL += "  and  a.cinvcode ='" + tab1_cInvCodeL.Text + "' \r\n";
                }
                else if (tab1_cInvCodeL.Text.Length == 0 && tab1_cInvCodeH.Text.Length > 0)
                {
                    selectSQL += "  and  a.cinvcode ='" + tab1_cInvCodeH.Text + "' \r\n";
                }
                else if (tab1_cInvCodeL.Text.Length > 0 && tab1_cInvCodeH.Text.Length > 0)
                {
                    selectSQL += "  and  a.cinvcode between  '" + tab1_cInvCodeL.Text + "' and '" + tab1_cInvCodeH.Text + "'  \r\n";
                }



                selectSQL += " and b.ddate between left(convert(varchar,dateadd(mm,-" + mOutMonth.ToString() + ",getdate()),20),10) and left(convert(varchar,getdate(),20),10)   \r\n";
                selectSQL += "   \r\n";

                OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
                myConn.Open();

                OleDbCommand myCommand = new OleDbCommand(selectSQL, myConn);
                this.tab4_dataGridView1.AutoGenerateColumns = true;
                //设置数据源    


                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
                da.Fill(ds);

                this.tab1_dataGridView1.DataSource = ds.Tables[0];//数据源 


                //标准居中
                this.tab1_dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //设置自动换行

                this.tab1_dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //设置自动调整高度

                this.tab1_dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }


                for (int i = 0; i < tab1_dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        tab1_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                    }
                }

                for (int i = 0; i < tab1_dataGridView1.Columns.Count; i++)
                {
                    tab1_dataGridView1.Columns[i].ReadOnly = true;

                }

                tab1_dataGridView1.Columns[tab1_dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "#,###0";
                tab1_dataGridView1.Columns[tab1_dataGridView1.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "StockOutList()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tab5_dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {


                if (e.ColumnIndex < 0)
                {
                    return;
                }


                if (e.RowIndex < 0)
                {
                    return;
                }

                if (tab5_dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Length == 0)
                {
                    return;
                }
                else
                {


                    tab1_cInvCodeL.Text = tab5_dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    tab1_cInvCodeH.Text = tab1_cInvCodeL.Text;


                    switch (e.ColumnIndex)
                    {

                        case 9:
                            {
                                tabControl1.SelectedIndex = 2;
                                DedtailQuery(chkShowAll.Checked, "3");//在检
                                this.Text = mTitle + "  到货在检量";
                                break;
                            }
                        case 8:
                            {
                                tabControl1.SelectedIndex = 2;
                                DedtailQuery(chkShowAll.Checked, "1,2");//采购在途
                                this.Text = mTitle + "  采购在途";
                                break;
                            }
                        case 3:
                            {
                                tabControl1.SelectedIndex = 2;
                                DedtailQuery(chkShowAll.Checked, "4");//现存量
                                this.Text = mTitle + "  现存量";
                                break;
                            }
                        case 4:
                            {
                                tabControl1.SelectedIndex = 2;
                                DedtailQuery(chkShowAll.Checked, "4");//现存量
                                this.Text = mTitle + "  现存量";
                                break;
                            }
                        case 10:
                            {
                                tabControl1.SelectedIndex = 2;
                                DedtailQuery(chkShowAll.Checked, "5");//在制
                                this.Text = mTitle + "  在制";
                                break;
                            }
                        case 7:
                            {
                                tabControl1.SelectedIndex = 2;
                                DedtailQuery(chkShowAll.Checked, "6,7");//已分配量
                                this.Text = mTitle + "  已分配量";
                                break;
                            }
                        case 5:
                            {
                                if (Convert.ToDouble(Convert.ToString(tab5_dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == "" ? "0" : Convert.ToString(tab5_dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)) != 0)
                                {
                                    this.Text = mTitle + "  出库明细";
                                    StockOutList();
                                }
                                break;
                            }
                        case 6:
                            {
                                if (Convert.ToDouble(Convert.ToString(tab5_dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == "" ? "0" : Convert.ToString(tab5_dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)) != 0)
                                {
                                    this.Text = mTitle + "  出库明细";
                                    StockOutList();
                                }
                                break;
                            }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "tab5_dataGridView1_CellMouseDoubleClick()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

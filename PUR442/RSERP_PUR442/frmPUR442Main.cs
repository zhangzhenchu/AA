using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UTLoginEx;
using System.Data.OleDb;
namespace RSERP_PUR442
{
    public partial class frmPUR442Main : Form
    {

        private UTLoginEx.LoginEx iLoginEx = new LoginEx();
        private int AuthID = 37; //权限ID ,不能为零。这里的零，只是模板
        private int FormWidth = 0, FormHeight = 0, tab1_dataGridView1Width = 0, tab1_dataGridView1Height = 0;
        private bool CellMouseDown = false;
        public frmPUR442Main(string[] args)
        {
            try
            {
                InitializeComponent();

                //37:442-到货单查询（按请购单分类）
                iLoginEx.Initialize(args, AuthID);//必须先初始化LoginEx
                SLbAccID.Text = iLoginEx.AccID();
                SLbAccName.Text = iLoginEx.AccName();
                SLbServer.Text = iLoginEx.DBServerHost();
                SLbYear.Text = iLoginEx.iYear();
                SLbUser.Text = iLoginEx.UserId() + "[" + iLoginEx.UserName() + "]";


            }
            catch (Exception ex)
            {
                frmMessege frmmsg = new frmMessege(ex.ToString(), "frmPUR442Main()");
                frmmsg.ShowDialog(this);
            }


        }

        private void toolQuery_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        /// <summary>
        /// 显示数据
        /// </summary>
        private void LoadData()
        {
            try
            {   
                System.Windows.Forms.Application.DoEvents();

                frmQuery fQuery = new frmQuery(iLoginEx);
                fQuery.ShowDialog(this);
                if (fQuery.GetSelectSQL().Length > 0)
                {

                    OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                    if (myConn.State == System.Data.ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                    myConn.Open();


                    OleDbCommand myCommand = new OleDbCommand(fQuery.GetSelectSQL(), myConn);
                    myCommand.ExecuteNonQuery();

                    this.tab1_dataGridView1.AutoGenerateColumns = true;
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


                    for (int i = 0; i < tab1_dataGridView1.Columns.Count; i++)
                    {
                        tab1_dataGridView1.Columns[i].ReadOnly = true;

                    }


                    for (int i = 0; i < tab1_dataGridView1.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            tab1_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                        }
                    }

                    for (int i = 0; i < tab1_dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToInt16(tab1_dataGridView1.Rows[i].Cells[0].Value)==1)
                        {
                            tab1_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Wheat; 

                        }
                    }
                    if (tab1_dataGridView1.Columns.Count > 0)
                    {
                        //tab1_dataGridView1.Columns[3].Width = 120;
                        tab1_dataGridView1.Columns[0].Width = 0;
                    }
                    
                    for (int i = 13; i < tab1_dataGridView1.Columns.Count; i++)
                    {
                        tab1_dataGridView1.Columns[i].DefaultCellStyle.Format = "#,###0";
                        tab1_dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }


                    System.Windows.Forms.Application.DoEvents();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(this, ex.ToString(), "LoadData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void tab1_dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < tab1_dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt16(tab1_dataGridView1.Rows[i].Cells[0].Value) == 1)
                {
                    tab1_dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Wheat;

                }
            }
        }

        private void toolToExcel_Click(object sender, EventArgs e)
        {
            iLoginEx.ExportExcel("采购到货单综合查询_" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_").Replace(".", "_").Replace(":", "_").Replace("/", "_").Replace(" ", "_"), "采购到货单综合查询", tab1_dataGridView1, 14);
        }

        private void frmPUR442Main_Load(object sender, EventArgs e)
        {
            FormWidth = this.Width;
            FormHeight = this.Height;
            tab1_dataGridView1Width = tab1_dataGridView1.Width;
            tab1_dataGridView1Height = tab1_dataGridView1.Height;
        }

        private void frmPUR442Main_Resize(object sender, EventArgs e)
        {
            Ini ini = new Ini(System.Windows.Forms.Application.StartupPath.ToString() + "\\utconfig.ini");
            ini.Writue("Window", "AutoAdaptive2", "");
            if (ini.ReadValue("Window", "AutoAdaptive") != "N")
            {
                tab1_dataGridView1.Width = tab1_dataGridView1Width + (this.Width - FormWidth);
                tab1_dataGridView1.Height = tab1_dataGridView1Height + (this.Height - FormHeight);
            }
        }

        private void tab1_dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseDown = true;
            SLBSql.Text = "";
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
                    SLBSql.Text = string.Format("{0:N0}", SelectTotal);
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
    }
}

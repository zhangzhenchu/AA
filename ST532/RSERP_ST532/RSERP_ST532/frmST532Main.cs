using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using RSERPLoginEx;

namespace RSERP_ST531
{
    public partial class frmST532Main : Form
    {

        private RSERPLoginEx.LoginEx iLoginEx = new LoginEx();
        private int AuthID = 40; //权限ID ,不能为零。这里的零，只是模板
        private int FormWidth = 0, FormHeight = 0, tab1_dataGridView1Width = 0, tab1_dataGridView1Height = 0;
        private bool CellMouseDown = false;
        private bool Tab2_SaveCulomnsWidth = false;
        public frmST532Main(string[] args)
        {
            try
            {
                InitializeComponent();

                 
                iLoginEx.Initialize(args, AuthID);//必须先初始化LoginEx
                SLbAccID.Text = iLoginEx.AccID();
                SLbAccName.Text = iLoginEx.AccName();
                SLbServer.Text = iLoginEx.DBServerHost();
                SLbYear.Text = iLoginEx.iYear();
                SLbUser.Text = iLoginEx.UserId() + "[" + iLoginEx.UserName() + "]";


            }
            catch (Exception ex)
            {
                frmMessege frmmsg = new frmMessege(ex.ToString(), "frmST532Main()");
                frmmsg.ShowDialog(this);
            }


        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolQuery_Click(object sender, EventArgs e)
        {
            try
            {
                frmQuery fQuery = new frmQuery(iLoginEx);
                fQuery.ShowDialog(this);

                if (fQuery.GetSQL().Length > 0)
                {

                    OleDbConnection myConn = new OleDbConnection(iLoginEx.ConnString());

                    if (myConn.State == System.Data.ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                    myConn.Open();


                    OleDbCommand myCommand = new OleDbCommand(fQuery.GetSQL(), myConn);
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

                    tab1_dataGridView1.Columns[0].Width = 120;
                    tab1_dataGridView1.Columns[1].Width = 200;
                    tab1_dataGridView1.Columns[2].Width = 280;

                    tab1_dataGridView1.Columns[3].DefaultCellStyle.Format = "#,###0";
                    tab1_dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    tab1_dataGridView1.Columns[4].DefaultCellStyle.Format = "#,###0.00";
                    tab1_dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    tab1_dataGridView1.Columns[5].DefaultCellStyle.Format = "#,###0";
                    tab1_dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    tab1_dataGridView1.Columns[6].DefaultCellStyle.Format = "#,###0.00";
                    tab1_dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    Tab2_SaveCulomnsWidth = true;

                    //读取用户自定列宽

                    if (tab1_dataGridView1.Columns.Count > 0)
                    {

                        string ColumnsWidths = iLoginEx.ReadUserProfileValue("Tab1", "ColumnsWidths");
                        string[] ColumnsWidthsPara = ColumnsWidths.Split(';');
                        for (int i = 0; i < ColumnsWidthsPara.Length && i < tab1_dataGridView1.Columns.Count; i++)
                        {
                            if (ColumnsWidthsPara[i].Length > 0)
                            {
                                tab1_dataGridView1.Columns[i].Width = Convert.ToInt32(ColumnsWidthsPara[i]);
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

        private void frmST532Main_Load(object sender, EventArgs e)
        {
            FormWidth = this.Width;
            FormHeight = this.Height;
            tab1_dataGridView1Width = tab1_dataGridView1.Width;
            tab1_dataGridView1Height = tab1_dataGridView1.Height;
        }

        private void frmST532Main_Resize(object sender, EventArgs e)
        {
            tab1_dataGridView1.Width = tab1_dataGridView1Width + (this.Width - FormWidth);
            tab1_dataGridView1.Height = tab1_dataGridView1Height + (this.Height - FormHeight);
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

        private void toolExcel_Click(object sender, EventArgs e)
        {
            
        }

        private void tab1_dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
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

                iLoginEx.WriteUserProfileValue("Tab1", "ColumnsWidths", ColumnsWidths);
            }
        }
    }
}

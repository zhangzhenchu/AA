using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UTLoginEx;

namespace RSERP_PUR442
{
    public partial class frmQuery : Form
    {
        private UTLoginEx.LoginEx iLoginEx = new LoginEx();
        private string selectSQL = "";
        public frmQuery(UTLoginEx.LoginEx iiLoginEx)
        {
            InitializeComponent();
            iLoginEx = iiLoginEx;
        }

        private void frmQuery_Load(object sender, EventArgs e)
        {
            try
            {
                selectSQL = "";
                dtPU_AppVouchDateH.Enabled = false;
                dtPU_AppVouchDateL.Enabled = false;
                dtPO_PomainDateL.Enabled = false;
                dtPO_PomainDateH.Enabled = false;
                dtPU_ArrivalVouchDateL.Enabled = false;
                dtPU_ArrivalVouchDateH.Enabled = false;

                DateTime dt = DateTime.Now;
                DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
                DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末//
                dtPO_PomainDateH.Value = endMonth;
                dtPO_PomainDateL.Value = startMonth;
                dtPU_AppVouchDateL.Value = startMonth;
                dtPU_AppVouchDateH.Value = endMonth;
                dtPU_ArrivalVouchDateL.Value = startMonth;
                dtPU_ArrivalVouchDateH.Value = endMonth;
            }
            catch (Exception ex)
            {
                frmMessege frmmsg = new frmMessege(ex.ToString(), "frmQuery_Load()");
                frmmsg.ShowDialog(this);
            }
        }
        public string GetSelectSQL()
        {
            return selectSQL;
        }

        private void btnQurey_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkShowDedtail.Checked && !chkShowTotal.Checked)
                {
                    selectSQL = "";
                    MessageBox.Show(this, "未选【显示明细】或【显示分类汇总】", "到货查询", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string cinvCodeChild = "";
                string[] paraCinvCode = null;
                
                selectSQL = " select sumType,分类,到货单号,到货日期,采购单号,供应商,采购员,请购人,请购单号,物料编码,inventory.cinvname as '物料名称', inventory.cinvstd '规格型号',inventory.cinvdefine7 as '图号版次',到货数量,请购数量,采购数量,请购欠数,采购欠数,ComputationUnit.cComUnitName as '单位'  from (  \r\n";
                if (chkShowDedtail.Checked)
                {
                    selectSQL += " select sumType=0,分类='', PU_ArrivalVouch.cCode as '到货单号',PU_ArrivalVouch.ddate as '到货日期',Po_Pomain.cpoid as '采购单号',vendor.cvenabbname as '供应商',person.cpersonname as '采购员',  \r\n";
                    selectSQL += " isnull(PU_AppVouch.cMaker,'') as'请购人',isnull(PU_AppVouch.cCode,'空白') as '请购单号',  \r\n";
                    selectSQL += " pu_arrivalvouchs.cinvcode as '物料编码',PU_ArrivalVouchs.iquantity as '到货数量',case when isnull(PU_AppVouch.cCloser,'')<>'' or  isnull(PU_AppVouchs.cbcloser,'')<>'' then 0 else isnull(PU_AppVouchs.fQuantity,0) end as '请购数量',  \r\n";
                    selectSQL += " case when isnull(Po_Pomain.cCloser,'')<>'' or  isnull(Po_podetails.cbcloser,'')<>'' then 0 else isnull(Po_podetails.iQuantity,0) end as '采购数量',0 as '请购欠数',0 as '采购欠数' FROM PU_ArrivalVouchs    (nolock)   \r\n";
                    selectSQL += " left join PU_ArrivalVouch (nolock) on (PU_ArrivalVouch.id=PU_ArrivalVouchs.id)   \r\n";
                    selectSQL += " LEFT JOIN Po_podetails  (nolock) ON PU_ArrivalVouchs.iposid=Po_podetails.id and PU_ArrivalVouch.cbustype not in ( N'委外加工' )              \r\n";
                    selectSQL += " LEFT JOIN Po_Pomain  (nolock) on Po_Podetails.poid=Po_Pomain.poid and PU_ArrivalVouch.cbustype not in ( N'委外加工' )      \r\n";
                    selectSQL += " left join vendor  (nolock) on pu_arrivalvouch.cvencode = vendor.cvencode    \r\n";
                    selectSQL += " left join person  (nolock) on Po_Pomain.cpersoncode = person.cpersoncode     \r\n";
                    selectSQL += " left join PU_AppVouchs  (nolock)  on PU_AppVouchs.AutoID=Po_podetails.iAppIds   \r\n";
                    selectSQL += " left join PU_AppVouch (nolock)  on PU_AppVouchs.id=PU_AppVouch.id  \r\n";
                    selectSQL += " where isnull(PU_ArrivalVouch.cverifier,'')<>'' and isnull(PU_ArrivalVouch.ccloser,'')='' and isnull(PU_ArrivalVouchs.cbcloser,'')='' and  \r\n";
                    selectSQL += "   PU_ArrivalVouch.cbustype <>'委外加工'   \r\n";

                    //请购单号
                    txtPU_AppVouchCode.Text = txtPU_AppVouchCode.Text.Trim();
                    txtPU_AppVouchCode.Text = txtPU_AppVouchCode.Text.Replace("；", ";");

                    if (txtPU_AppVouchCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtPU_AppVouchCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and  PU_AppVouch.cCode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and  PU_AppVouch.cCode ='" + txtPU_AppVouchCode.Text + "' \r\n";
                        }
                    }
                    //采购单号
                    txtPO_PomainCode.Text = txtPO_PomainCode.Text.Trim();
                    txtPO_PomainCode.Text = txtPO_PomainCode.Text.Replace("；", ";");

                    if (txtPO_PomainCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtPO_PomainCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and  Po_Pomain.cpoid in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and  Po_Pomain.cpoid ='" + txtPO_PomainCode.Text + "' \r\n";
                        }
                    }
                    //到货单号

                    txtPU_ArrivalVouchsCode.Text = txtPU_ArrivalVouchsCode.Text.Trim();
                    txtPU_ArrivalVouchsCode.Text = txtPU_ArrivalVouchsCode.Text.Replace("；", ";");

                    if (txtPU_ArrivalVouchsCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtPU_ArrivalVouchsCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and   PU_ArrivalVouch.cCode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and   PU_ArrivalVouch.cCode ='" + txtPU_ArrivalVouchsCode.Text + "' \r\n";
                        }
                    }

                    //物料编码
                    txtcInvCode.Text = txtcInvCode.Text.Trim();
                    txtcInvCode.Text = txtcInvCode.Text.Replace("；", ";");

                    if (txtcInvCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtcInvCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and   pu_arrivalvouchs.cinvcode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and   pu_arrivalvouchs.cinvcode ='" + txtcInvCode.Text + "' \r\n";
                        }
                    }

                    //请购人
                    txtcMaker.Text = txtcMaker.Text.Trim();
                    txtcMaker.Text = txtcMaker.Text.Replace("；", ";");

                    if (txtcMaker.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtcMaker.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and  PU_AppVouch.cMaker in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and   PU_AppVouch.cMaker ='" + txtcMaker.Text + "' \r\n";
                        }
                    }


                    if (chkPU_AppVouch.Checked)
                    {
                        selectSQL += " and PU_AppVouch.ddate >= N'" + dtPU_AppVouchDateL.Value.ToString("yyyy-MM-dd") + "' And PU_AppVouch.ddate <= N'" + dtPU_AppVouchDateH.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                    }
                    if (chkPO_Pomain.Checked)
                    {
                        selectSQL += " and Po_Pomain.ddate >= N'" + dtPO_PomainDateL.Value.ToString("yyyy-MM-dd") + "' And Po_Pomain.ddate <= N'" + dtPO_PomainDateH.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                    }
                    if (chkPU_ArrivalVouch.Checked)
                    {
                        selectSQL += " and PU_ArrivalVouch.ddate >= N'" + dtPU_ArrivalVouchDateL.Value.ToString("yyyy-MM-dd") + "' And PU_ArrivalVouch.ddate <= N'" + dtPU_ArrivalVouchDateH.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                    }
                }
                if (chkShowTotal.Checked)
                {
                    if (chkShowDedtail.Checked)
                    {
                        selectSQL += "   \r\n";
                        selectSQL += " union all  \r\n";
                        selectSQL += "   \r\n";
                    }
                    selectSQL += " select sumType=1,分类='小计', '' as '到货单号',null as '到货日期','' as '采购单号','' as '供应商','' as '采购员',  \r\n";
                    selectSQL += " isnull(PU_AppVouch.cMaker,'') as'请购人',isnull(PU_AppVouch.cCode,'空白')+'小计' as '请购单号',  \r\n";
                    selectSQL += " pu_arrivalvouchs.cinvcode  as '物料编码',sum(isnull(PU_ArrivalVouchs.iquantity,0)) as '到货数量',sum(case when isnull(PU_AppVouch.cCloser,'')<>'' or  isnull(PU_AppVouchs.cbcloser,'')<>'' then 0 else isnull(PU_AppVouchs.fQuantity,0) end )as '请购数量',  \r\n";
                    selectSQL += " sum(case when isnull(Po_Pomain.cCloser,'')<>'' or  isnull(Po_podetails.cbcloser,'')<>'' then 0 else isnull(Po_podetails.iQuantity,0) end) as '采购数量',  \r\n";
                    selectSQL += " sum(case when isnull(PU_AppVouch.cCloser,'')<>'' or  isnull(PU_AppVouchs.cbcloser,'')<>'' then 0 else isnull(PU_AppVouchs.fQuantity,0) end )-sum(isnull(PU_ArrivalVouchs.iquantity,0)) as '请购欠数',  \r\n";
                    selectSQL += " sum(case when isnull(Po_Pomain.cCloser,'')<>'' or  isnull(Po_podetails.cbcloser,'')<>'' then 0 else isnull(Po_podetails.iQuantity,0) end)-sum(isnull(PU_ArrivalVouchs.iquantity,0)) as '采购欠数' FROM PU_ArrivalVouchs    (nolock)   \r\n";
                    selectSQL += " left join PU_ArrivalVouch  (nolock) on (PU_ArrivalVouch.id=PU_ArrivalVouchs.id)   \r\n";
                    selectSQL += " LEFT JOIN Po_podetails  (nolock) ON PU_ArrivalVouchs.iposid=Po_podetails.id and PU_ArrivalVouch.cbustype not in ( N'委外加工' )              \r\n";
                    selectSQL += " LEFT JOIN Po_Pomain  (nolock) on Po_Podetails.poid=Po_Pomain.poid and PU_ArrivalVouch.cbustype not in ( N'委外加工' )      \r\n";
                    selectSQL += " left join vendor  (nolock) on pu_arrivalvouch.cvencode = vendor.cvencode    \r\n";
                    selectSQL += " left join person  (nolock) on Po_Pomain.cpersoncode = person.cpersoncode     \r\n";
                    selectSQL += " left join PU_AppVouchs  (nolock)  on PU_AppVouchs.AutoID=Po_podetails.iAppIds   \r\n";
                    selectSQL += " left join PU_AppVouch (nolock)  on PU_AppVouchs.id=PU_AppVouch.id  \r\n";
                    selectSQL += " where isnull(PU_ArrivalVouch.cverifier,'')<>'' and isnull(PU_ArrivalVouch.ccloser,'')='' and isnull(PU_ArrivalVouchs.cbcloser,'')='' and  \r\n";
                    selectSQL += "   PU_ArrivalVouch.cbustype <>'委外加工'   \r\n";
                    //请购单号
                    txtPU_AppVouchCode.Text = txtPU_AppVouchCode.Text.Trim();
                    txtPU_AppVouchCode.Text = txtPU_AppVouchCode.Text.Replace("；", ";");

                    if (txtPU_AppVouchCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtPU_AppVouchCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and  PU_AppVouch.cCode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and  PU_AppVouch.cCode ='" + txtPU_AppVouchCode.Text + "' \r\n";
                        }
                    }
                    //采购单号
                    txtPO_PomainCode.Text = txtPO_PomainCode.Text.Trim();
                    txtPO_PomainCode.Text = txtPO_PomainCode.Text.Replace("；", ";");

                    if (txtPO_PomainCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtPO_PomainCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and  Po_Pomain.cpoid in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and  Po_Pomain.cpoid ='" + txtPO_PomainCode.Text + "' \r\n";
                        }
                    }
                    //到货单号

                    txtPU_ArrivalVouchsCode.Text = txtPU_ArrivalVouchsCode.Text.Trim();
                    txtPU_ArrivalVouchsCode.Text = txtPU_ArrivalVouchsCode.Text.Replace("；", ";");

                    if (txtPU_ArrivalVouchsCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtPU_ArrivalVouchsCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and   PU_ArrivalVouch.cCode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and   PU_ArrivalVouch.cCode ='" + txtPU_ArrivalVouchsCode.Text + "' \r\n";
                        }
                    }

                    //物料编码
                    txtcInvCode.Text = txtcInvCode.Text.Trim();
                    txtcInvCode.Text = txtcInvCode.Text.Replace("；", ";");

                    if (txtcInvCode.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtcInvCode.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and   pu_arrivalvouchs.cinvcode in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and   pu_arrivalvouchs.cinvcode ='" + txtcInvCode.Text + "' \r\n";
                        }
                    }

                    //请购人
                    txtcMaker.Text = txtcMaker.Text.Trim();
                    txtcMaker.Text = txtcMaker.Text.Replace("；", ";");

                    if (txtcMaker.Text.Length > 0)
                    {
                        cinvCodeChild = "";
                        paraCinvCode = txtcMaker.Text.Split(';');
                        if (paraCinvCode.Length > 0)
                        {
                            for (int i = 0; i < paraCinvCode.Length; i++)
                            {
                                cinvCodeChild += "'" + paraCinvCode[i].ToString() + "',";
                            }

                            selectSQL += " and  PU_AppVouch.cMaker in (" + cinvCodeChild + "'\r\n'" + ") \r\n";
                        }
                        else
                        {
                            selectSQL += " and   PU_AppVouch.cMaker ='" + txtcMaker.Text + "' \r\n";
                        }
                    }

                    if (chkPU_AppVouch.Checked)
                    {
                        selectSQL += " and PU_AppVouch.ddate >= N'" + dtPU_AppVouchDateL.Value.ToString("yyyy-MM-dd") + "' And PU_AppVouch.ddate <= N'" + dtPU_AppVouchDateH.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                    }
                    if (chkPO_Pomain.Checked)
                    {
                        selectSQL += " and Po_Pomain.ddate >= N'" + dtPO_PomainDateL.Value.ToString("yyyy-MM-dd") + "' And Po_Pomain.ddate <= N'" + dtPO_PomainDateH.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                    }
                    if (chkPU_ArrivalVouch.Checked)
                    {
                        selectSQL += " and PU_ArrivalVouch.ddate >= N'" + dtPU_ArrivalVouchDateL.Value.ToString("yyyy-MM-dd") + "' And PU_ArrivalVouch.ddate <= N'" + dtPU_ArrivalVouchDateH.Value.ToString("yyyy-MM-dd") + "'  \r\n";
                    }
                    selectSQL += " group by isnull(PU_AppVouch.cCode,'空白')+'小计',isnull(PU_AppVouch.cMaker,''),pu_arrivalvouchs.cinvcode  \r\n";
                }
                selectSQL += " ) m   \r\n";
                selectSQL += " LEFT JOIN Inventory  (nolock) ON m.物料编码=Inventory.cInvCode   \r\n";
                selectSQL += " left join ComputationUnit  (nolock) on  Inventory.cComUnitCode =ComputationUnit.cComunitCode   \r\n";
                selectSQL += " order by 物料编码,请购单号,sumType  \r\n";
                selectSQL += "   \r\n";

                this.Close();
            }
            catch (Exception ex)
            {
                frmMessege frmmsg = new frmMessege(ex.ToString(), "btnQurey_Click()");
                frmmsg.ShowDialog(this);
            }
        }

        private void chkPU_AppVouch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPU_AppVouch.Checked)
            {
                dtPU_AppVouchDateH.Enabled = true;
                dtPU_AppVouchDateL.Enabled = true;
            }
            else
            {
                dtPU_AppVouchDateH.Enabled = false;
                dtPU_AppVouchDateL.Enabled = false;
            }
        }

        private void chkPO_Pomain_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPO_Pomain.Checked)
            {
                dtPO_PomainDateL.Enabled = true;
                dtPO_PomainDateL.Enabled = true;
            }
            else
            {
                dtPO_PomainDateL.Enabled = false;
                dtPO_PomainDateH.Enabled = false;
            }
        }

        private void chkPU_ArrivalVouch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPU_ArrivalVouch.Checked)
            {
                dtPU_ArrivalVouchDateH.Enabled = true;
                dtPU_ArrivalVouchDateL.Enabled = true;
            }
            else
            {
                dtPU_ArrivalVouchDateL.Enabled = false;
                dtPU_ArrivalVouchDateH.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectSQL = "";
            this.Close();
        }
    }
}

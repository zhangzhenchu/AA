namespace RSERP_PUR442
{
    partial class frmQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery));
            this.chkPU_ArrivalVouch = new System.Windows.Forms.CheckBox();
            this.chkPO_Pomain = new System.Windows.Forms.CheckBox();
            this.chkPU_AppVouch = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtPU_ArrivalVouchDateH = new System.Windows.Forms.DateTimePicker();
            this.dtPU_ArrivalVouchDateL = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPO_PomainDateH = new System.Windows.Forms.DateTimePicker();
            this.dtPO_PomainDateL = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtPU_AppVouchDateH = new System.Windows.Forms.DateTimePicker();
            this.dtPU_AppVouchDateL = new System.Windows.Forms.DateTimePicker();
            this.txtPU_ArrivalVouchsCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPO_PomainCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcMaker = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPU_AppVouchCode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtcInvCode = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQurey = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkShowTotal = new System.Windows.Forms.CheckBox();
            this.chkShowDedtail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkPU_ArrivalVouch
            // 
            this.chkPU_ArrivalVouch.AutoSize = true;
            this.chkPU_ArrivalVouch.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPU_ArrivalVouch.Location = new System.Drawing.Point(22, 293);
            this.chkPU_ArrivalVouch.Name = "chkPU_ArrivalVouch";
            this.chkPU_ArrivalVouch.Size = new System.Drawing.Size(101, 19);
            this.chkPU_ArrivalVouch.TabIndex = 12;
            this.chkPU_ArrivalVouch.Text = "到货单日期";
            this.chkPU_ArrivalVouch.UseVisualStyleBackColor = true;
            this.chkPU_ArrivalVouch.CheckedChanged += new System.EventHandler(this.chkPU_ArrivalVouch_CheckedChanged);
            // 
            // chkPO_Pomain
            // 
            this.chkPO_Pomain.AutoSize = true;
            this.chkPO_Pomain.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPO_Pomain.Location = new System.Drawing.Point(22, 264);
            this.chkPO_Pomain.Name = "chkPO_Pomain";
            this.chkPO_Pomain.Size = new System.Drawing.Size(101, 19);
            this.chkPO_Pomain.TabIndex = 9;
            this.chkPO_Pomain.Text = "采购单日期";
            this.chkPO_Pomain.UseVisualStyleBackColor = true;
            this.chkPO_Pomain.CheckedChanged += new System.EventHandler(this.chkPO_Pomain_CheckedChanged);
            // 
            // chkPU_AppVouch
            // 
            this.chkPU_AppVouch.AutoSize = true;
            this.chkPU_AppVouch.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPU_AppVouch.Location = new System.Drawing.Point(22, 234);
            this.chkPU_AppVouch.Name = "chkPU_AppVouch";
            this.chkPU_AppVouch.Size = new System.Drawing.Size(101, 19);
            this.chkPU_AppVouch.TabIndex = 6;
            this.chkPU_AppVouch.Text = "请购单日期";
            this.chkPU_AppVouch.UseVisualStyleBackColor = true;
            this.chkPU_AppVouch.CheckedChanged += new System.EventHandler(this.chkPU_AppVouch_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(278, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 145;
            this.label6.Text = "至";
            // 
            // dtPU_ArrivalVouchDateH
            // 
            this.dtPU_ArrivalVouchDateH.CustomFormat = "yyyy-MM-dd";
            this.dtPU_ArrivalVouchDateH.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPU_ArrivalVouchDateH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPU_ArrivalVouchDateH.Location = new System.Drawing.Point(317, 290);
            this.dtPU_ArrivalVouchDateH.Name = "dtPU_ArrivalVouchDateH";
            this.dtPU_ArrivalVouchDateH.Size = new System.Drawing.Size(134, 25);
            this.dtPU_ArrivalVouchDateH.TabIndex = 14;
            this.dtPU_ArrivalVouchDateH.Value = new System.DateTime(2013, 10, 11, 0, 0, 0, 0);
            // 
            // dtPU_ArrivalVouchDateL
            // 
            this.dtPU_ArrivalVouchDateL.CustomFormat = "yyyy-MM-dd";
            this.dtPU_ArrivalVouchDateL.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPU_ArrivalVouchDateL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPU_ArrivalVouchDateL.Location = new System.Drawing.Point(127, 290);
            this.dtPU_ArrivalVouchDateL.Name = "dtPU_ArrivalVouchDateL";
            this.dtPU_ArrivalVouchDateL.Size = new System.Drawing.Size(138, 25);
            this.dtPU_ArrivalVouchDateL.TabIndex = 13;
            this.dtPU_ArrivalVouchDateL.Value = new System.DateTime(2013, 10, 11, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(278, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 142;
            this.label4.Text = "至";
            // 
            // dtPO_PomainDateH
            // 
            this.dtPO_PomainDateH.CustomFormat = "yyyy-MM-dd";
            this.dtPO_PomainDateH.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPO_PomainDateH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPO_PomainDateH.Location = new System.Drawing.Point(317, 261);
            this.dtPO_PomainDateH.Name = "dtPO_PomainDateH";
            this.dtPO_PomainDateH.Size = new System.Drawing.Size(134, 25);
            this.dtPO_PomainDateH.TabIndex = 11;
            this.dtPO_PomainDateH.Value = new System.DateTime(2013, 10, 11, 0, 0, 0, 0);
            // 
            // dtPO_PomainDateL
            // 
            this.dtPO_PomainDateL.CustomFormat = "yyyy-MM-dd";
            this.dtPO_PomainDateL.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPO_PomainDateL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPO_PomainDateL.Location = new System.Drawing.Point(127, 261);
            this.dtPO_PomainDateL.Name = "dtPO_PomainDateL";
            this.dtPO_PomainDateL.Size = new System.Drawing.Size(138, 25);
            this.dtPO_PomainDateL.TabIndex = 10;
            this.dtPO_PomainDateL.Value = new System.DateTime(2013, 10, 11, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(278, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 139;
            this.label10.Text = "至";
            // 
            // dtPU_AppVouchDateH
            // 
            this.dtPU_AppVouchDateH.CustomFormat = "yyyy-MM-dd";
            this.dtPU_AppVouchDateH.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPU_AppVouchDateH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPU_AppVouchDateH.Location = new System.Drawing.Point(317, 231);
            this.dtPU_AppVouchDateH.Name = "dtPU_AppVouchDateH";
            this.dtPU_AppVouchDateH.Size = new System.Drawing.Size(134, 25);
            this.dtPU_AppVouchDateH.TabIndex = 8;
            this.dtPU_AppVouchDateH.Value = new System.DateTime(2013, 10, 11, 0, 0, 0, 0);
            // 
            // dtPU_AppVouchDateL
            // 
            this.dtPU_AppVouchDateL.CustomFormat = "yyyy-MM-dd";
            this.dtPU_AppVouchDateL.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPU_AppVouchDateL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPU_AppVouchDateL.Location = new System.Drawing.Point(127, 231);
            this.dtPU_AppVouchDateL.Name = "dtPU_AppVouchDateL";
            this.dtPU_AppVouchDateL.Size = new System.Drawing.Size(138, 25);
            this.dtPU_AppVouchDateL.TabIndex = 7;
            this.dtPU_AppVouchDateL.Value = new System.DateTime(2013, 10, 11, 0, 0, 0, 0);
            // 
            // txtPU_ArrivalVouchsCode
            // 
            this.txtPU_ArrivalVouchsCode.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPU_ArrivalVouchsCode.Location = new System.Drawing.Point(92, 74);
            this.txtPU_ArrivalVouchsCode.Name = "txtPU_ArrivalVouchsCode";
            this.txtPU_ArrivalVouchsCode.Size = new System.Drawing.Size(359, 25);
            this.txtPU_ArrivalVouchsCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 135;
            this.label2.Text = "到货单号";
            // 
            // txtPO_PomainCode
            // 
            this.txtPO_PomainCode.AcceptsReturn = true;
            this.txtPO_PomainCode.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPO_PomainCode.Location = new System.Drawing.Point(92, 43);
            this.txtPO_PomainCode.Name = "txtPO_PomainCode";
            this.txtPO_PomainCode.Size = new System.Drawing.Size(359, 25);
            this.txtPO_PomainCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 133;
            this.label1.Text = "采购单号";
            // 
            // txtcMaker
            // 
            this.txtcMaker.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcMaker.Location = new System.Drawing.Point(92, 136);
            this.txtcMaker.Name = "txtcMaker";
            this.txtcMaker.Size = new System.Drawing.Size(359, 25);
            this.txtcMaker.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(19, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 15);
            this.label15.TabIndex = 131;
            this.label15.Text = "制单人";
            // 
            // txtPU_AppVouchCode
            // 
            this.txtPU_AppVouchCode.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPU_AppVouchCode.Location = new System.Drawing.Point(92, 12);
            this.txtPU_AppVouchCode.Name = "txtPU_AppVouchCode";
            this.txtPU_AppVouchCode.Size = new System.Drawing.Size(359, 25);
            this.txtPU_AppVouchCode.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(19, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 129;
            this.label17.Text = "请购单号";
            // 
            // txtcInvCode
            // 
            this.txtcInvCode.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcInvCode.Location = new System.Drawing.Point(92, 105);
            this.txtcInvCode.Name = "txtcInvCode";
            this.txtcInvCode.Size = new System.Drawing.Size(359, 25);
            this.txtcInvCode.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(19, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 15);
            this.label19.TabIndex = 127;
            this.label19.Text = "物料编码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(19, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 15);
            this.label3.TabIndex = 149;
            this.label3.Text = "以上查询，多个内容可用分号隔开";
            // 
            // btnQurey
            // 
            this.btnQurey.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQurey.Location = new System.Drawing.Point(94, 336);
            this.btnQurey.Name = "btnQurey";
            this.btnQurey.Size = new System.Drawing.Size(75, 41);
            this.btnQurey.TabIndex = 15;
            this.btnQurey.Text = "查询";
            this.btnQurey.UseVisualStyleBackColor = true;
            this.btnQurey.Click += new System.EventHandler(this.btnQurey_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(255, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 41);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkShowTotal
            // 
            this.chkShowTotal.AutoSize = true;
            this.chkShowTotal.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowTotal.Location = new System.Drawing.Point(184, 194);
            this.chkShowTotal.Name = "chkShowTotal";
            this.chkShowTotal.Size = new System.Drawing.Size(116, 19);
            this.chkShowTotal.TabIndex = 150;
            this.chkShowTotal.Text = "显示分类汇总";
            this.chkShowTotal.UseVisualStyleBackColor = true;
            // 
            // chkShowDedtail
            // 
            this.chkShowDedtail.AutoSize = true;
            this.chkShowDedtail.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowDedtail.Location = new System.Drawing.Point(22, 194);
            this.chkShowDedtail.Name = "chkShowDedtail";
            this.chkShowDedtail.Size = new System.Drawing.Size(86, 19);
            this.chkShowDedtail.TabIndex = 151;
            this.chkShowDedtail.Text = "显示明细";
            this.chkShowDedtail.UseVisualStyleBackColor = true;
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 392);
            this.Controls.Add(this.chkShowDedtail);
            this.Controls.Add(this.chkShowTotal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQurey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkPU_ArrivalVouch);
            this.Controls.Add(this.chkPO_Pomain);
            this.Controls.Add(this.chkPU_AppVouch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtPU_ArrivalVouchDateH);
            this.Controls.Add(this.dtPU_ArrivalVouchDateL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtPO_PomainDateH);
            this.Controls.Add(this.dtPO_PomainDateL);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtPU_AppVouchDateH);
            this.Controls.Add(this.dtPU_AppVouchDateL);
            this.Controls.Add(this.txtPU_ArrivalVouchsCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPO_PomainCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcMaker);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPU_AppVouchCode);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtcInvCode);
            this.Controls.Add(this.label19);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPU_ArrivalVouch;
        private System.Windows.Forms.CheckBox chkPO_Pomain;
        private System.Windows.Forms.CheckBox chkPU_AppVouch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPU_ArrivalVouchDateH;
        private System.Windows.Forms.DateTimePicker dtPU_ArrivalVouchDateL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPO_PomainDateH;
        private System.Windows.Forms.DateTimePicker dtPO_PomainDateL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtPU_AppVouchDateH;
        private System.Windows.Forms.DateTimePicker dtPU_AppVouchDateL;
        private System.Windows.Forms.TextBox txtPU_ArrivalVouchsCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPO_PomainCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcMaker;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPU_AppVouchCode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtcInvCode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQurey;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkShowTotal;
        private System.Windows.Forms.CheckBox chkShowDedtail;
    }
}
namespace RSERP_Template
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SLbServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbAccID = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbAccName = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbYear = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLBSql = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbState = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolQuery = new System.Windows.Forms.ToolStripButton();
            this.toolToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolClose = new System.Windows.Forms.ToolStripButton();
            this.dgvFile = new System.Windows.Forms.DataGridView();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SLbServer,
            this.SLbAccID,
            this.SLbAccName,
            this.SLbYear,
            this.SLbUser,
            this.SLBSql,
            this.SLbState});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SLbServer
            // 
            this.SLbServer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.SLbServer.Name = "SLbServer";
            this.SLbServer.Size = new System.Drawing.Size(48, 21);
            this.SLbServer.Text = "服务器";
            this.SLbServer.ToolTipText = "服务器";
            // 
            // SLbAccID
            // 
            this.SLbAccID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.SLbAccID.Name = "SLbAccID";
            this.SLbAccID.Size = new System.Drawing.Size(48, 21);
            this.SLbAccID.Spring = true;
            this.SLbAccID.Text = "帐套号";
            this.SLbAccID.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // SLbAccName
            // 
            this.SLbAccName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.SLbAccName.Name = "SLbAccName";
            this.SLbAccName.Size = new System.Drawing.Size(60, 21);
            this.SLbAccName.Text = "帐套名称";
            // 
            // SLbYear
            // 
            this.SLbYear.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.SLbYear.Name = "SLbYear";
            this.SLbYear.Size = new System.Drawing.Size(36, 21);
            this.SLbYear.Text = "年度";
            // 
            // SLbUser
            // 
            this.SLbUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.SLbUser.Name = "SLbUser";
            this.SLbUser.Size = new System.Drawing.Size(48, 21);
            this.SLbUser.Text = "用户名";
            // 
            // SLBSql
            // 
            this.SLBSql.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.SLBSql.Name = "SLBSql";
            this.SLBSql.Size = new System.Drawing.Size(4, 21);
            // 
            // SLbState
            // 
            this.SLbState.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.SLbState.Name = "SLbState";
            this.SLbState.Size = new System.Drawing.Size(4, 21);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(637, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(290, 507);
            this.dataGridView1.TabIndex = 111;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolQuery,
            this.toolToExcel,
            this.toolClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(958, 40);
            this.toolStrip1.TabIndex = 112;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolQuery
            // 
            this.toolQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolQuery.Image")));
            this.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQuery.Name = "toolQuery";
            this.toolQuery.Size = new System.Drawing.Size(36, 37);
            this.toolQuery.Text = "查询";
            this.toolQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolToExcel
            // 
            this.toolToExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolToExcel.Image")));
            this.toolToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolToExcel.Name = "toolToExcel";
            this.toolToExcel.Size = new System.Drawing.Size(41, 37);
            this.toolToExcel.Text = "Excel";
            this.toolToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolClose
            // 
            this.toolClose.Image = ((System.Drawing.Image)(resources.GetObject("toolClose.Image")));
            this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(36, 37);
            this.toolClose.Text = "关闭";
            this.toolClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // dgvFile
            // 
            this.dgvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFile.Location = new System.Drawing.Point(12, 71);
            this.dgvFile.Name = "dgvFile";
            this.dgvFile.RowTemplate.Height = 23;
            this.dgvFile.Size = new System.Drawing.Size(598, 507);
            this.dgvFile.TabIndex = 113;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(12, 43);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 114;
            this.btnFile.Text = "button1";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(102, 44);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(222, 21);
            this.txtFile.TabIndex = 115;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(431, 43);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(417, 21);
            this.txtData.TabIndex = 116;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 622);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.dgvFile);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SLbServer;
        private System.Windows.Forms.ToolStripStatusLabel SLbAccID;
        private System.Windows.Forms.ToolStripStatusLabel SLbAccName;
        private System.Windows.Forms.ToolStripStatusLabel SLbYear;
        private System.Windows.Forms.ToolStripStatusLabel SLbUser;
        private System.Windows.Forms.ToolStripStatusLabel SLBSql;
        private System.Windows.Forms.ToolStripStatusLabel SLbState;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolQuery;
        private System.Windows.Forms.ToolStripButton toolToExcel;
        private System.Windows.Forms.ToolStripButton toolClose;
        private System.Windows.Forms.DataGridView dgvFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtData;
    }
}


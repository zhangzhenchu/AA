namespace RSERP_ST431
{
    partial class FrmMCoding
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SLbServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbAccID = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbAccName = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbYear = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLBSql = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLbState = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.dgvFile = new System.Windows.Forms.DataGridView();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 580);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1152, 26);
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
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvInfo.Location = new System.Drawing.Point(685, 37);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.Size = new System.Drawing.Size(455, 529);
            this.dgvInfo.TabIndex = 111;
            // 
            // dgvFile
            // 
            this.dgvFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFile.Location = new System.Drawing.Point(12, 37);
            this.dgvFile.Name = "dgvFile";
            this.dgvFile.RowTemplate.Height = 23;
            this.dgvFile.Size = new System.Drawing.Size(641, 529);
            this.dgvFile.TabIndex = 118;
            this.dgvFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFile_CellContentClick);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(210, 8);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(274, 21);
            this.txtFile.TabIndex = 117;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(116, 8);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(84, 23);
            this.btnFile.TabIndex = 116;
            this.btnFile.Text = "选择文件";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(685, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 119;
            this.btnSave.Text = "保存数据";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(12, 8);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(84, 23);
            this.btnOut.TabIndex = 120;
            this.btnOut.Text = "下载模板";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // FrmMCoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 606);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.dgvInfo);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmMCoding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "原采购回复";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridView dgvFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOut;
    }
}


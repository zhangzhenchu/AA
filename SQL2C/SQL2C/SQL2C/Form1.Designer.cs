namespace SQL2C
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.copy = new System.Windows.Forms.ToolStripMenuItem();
            this.clip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.undo = new System.Windows.Forms.ToolStripMenuItem();
            this.redo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTran = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectall2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copy2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clip2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.paste2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.delete2 = new System.Windows.Forms.ToolStripMenuItem();
            this.undo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.redo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Location = new System.Drawing.Point(12, 52);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(441, 621);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectall,
            this.toolStripMenuItem2,
            this.copy,
            this.clip,
            this.toolStripMenuItem3,
            this.paste,
            this.toolStripMenuItem1,
            this.delete,
            this.undo,
            this.redo});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 176);
            // 
            // selectall
            // 
            this.selectall.Name = "selectall";
            this.selectall.Size = new System.Drawing.Size(100, 22);
            this.selectall.Text = "全选";
            this.selectall.Click += new System.EventHandler(this.selectall_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(97, 6);
            // 
            // copy
            // 
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(100, 22);
            this.copy.Text = "复制";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // clip
            // 
            this.clip.Name = "clip";
            this.clip.Size = new System.Drawing.Size(100, 22);
            this.clip.Text = "剪切";
            this.clip.Click += new System.EventHandler(this.clip_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(97, 6);
            // 
            // paste
            // 
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(100, 22);
            this.paste.Text = "粘贴";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(100, 22);
            this.delete.Text = "清除";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // undo
            // 
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(100, 22);
            this.undo.Text = "撤销";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(100, 22);
            this.redo.Text = "重复";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // btnTran
            // 
            this.btnTran.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTran.Location = new System.Drawing.Point(239, 12);
            this.btnTran.Name = "btnTran";
            this.btnTran.Size = new System.Drawing.Size(75, 34);
            this.btnTran.TabIndex = 1;
            this.btnTran.Text = "转换";
            this.btnTran.UseVisualStyleBackColor = true;
            this.btnTran.Click += new System.EventHandler(this.btnTran_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.ContextMenuStrip = this.contextMenuStrip2;
            this.richTextBox2.Location = new System.Drawing.Point(459, 52);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(469, 621);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(138, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 34);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectall2,
            this.toolStripSeparator1,
            this.copy2,
            this.clip2,
            this.toolStripSeparator2,
            this.paste2,
            this.toolStripSeparator3,
            this.delete2,
            this.undo2,
            this.redo2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 176);
            // 
            // selectall2
            // 
            this.selectall2.Name = "selectall2";
            this.selectall2.Size = new System.Drawing.Size(152, 22);
            this.selectall2.Text = "全选";
            this.selectall2.Click += new System.EventHandler(this.selectall2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // copy2
            // 
            this.copy2.Name = "copy2";
            this.copy2.Size = new System.Drawing.Size(152, 22);
            this.copy2.Text = "复制";
            this.copy2.Click += new System.EventHandler(this.copy2_Click);
            // 
            // clip2
            // 
            this.clip2.Name = "clip2";
            this.clip2.Size = new System.Drawing.Size(152, 22);
            this.clip2.Text = "剪切";
            this.clip2.Click += new System.EventHandler(this.clip2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // paste2
            // 
            this.paste2.Name = "paste2";
            this.paste2.Size = new System.Drawing.Size(152, 22);
            this.paste2.Text = "粘贴";
            this.paste2.Click += new System.EventHandler(this.paste2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // delete2
            // 
            this.delete2.Name = "delete2";
            this.delete2.Size = new System.Drawing.Size(152, 22);
            this.delete2.Text = "清除";
            this.delete2.Click += new System.EventHandler(this.delete2_Click);
            // 
            // undo2
            // 
            this.undo2.Name = "undo2";
            this.undo2.Size = new System.Drawing.Size(152, 22);
            this.undo2.Text = "撤销";
            this.undo2.Click += new System.EventHandler(this.undo2_Click);
            // 
            // redo2
            // 
            this.redo2.Name = "redo2";
            this.redo2.Size = new System.Drawing.Size(152, 22);
            this.redo2.Text = "重复";
            this.redo2.Click += new System.EventHandler(this.redo2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 685);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.btnTran);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL脚本转C#";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnTran;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copy;
        private System.Windows.Forms.ToolStripMenuItem undo;
        private System.Windows.Forms.ToolStripMenuItem selectall;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private System.Windows.Forms.ToolStripMenuItem paste;
        private System.Windows.Forms.ToolStripMenuItem clip;
        private System.Windows.Forms.ToolStripMenuItem redo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem selectall2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copy2;
        private System.Windows.Forms.ToolStripMenuItem clip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem paste2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem delete2;
        private System.Windows.Forms.ToolStripMenuItem undo2;
        private System.Windows.Forms.ToolStripMenuItem redo2;
    }
}


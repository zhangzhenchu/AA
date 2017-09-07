using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQL2C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim().Length > 0)
            {
                richTextBox2.Text = "selectSQL =\"" + richTextBox1.Text.Replace("\n", "  \\r\\n\";\r\nselectSQL+=\" ");
                richTextBox2.Text = richTextBox2.Text.Replace("\r\r", "\r") + "  \\r\\n\";";
            }
            else
            {
                richTextBox2.Text = "";
                richTextBox1.Text = "";
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            richTextBox1.Text = "";
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (richTextBox1.CanRedo)//redo
                    redo.Enabled = true;
                else
                    redo.Enabled = false;
                if (richTextBox1.CanUndo)//undo
                    undo.Enabled = true;
                else
                    undo.Enabled = false;
                if (richTextBox1.SelectionLength > 0)
                {
                    copy.Enabled = true;
                    clip.Enabled = true;
                }
                else
                {
                    copy.Enabled = false;
                    clip.Enabled = false;
                }
                if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                    paste.Enabled = true;
                else
                    paste.Enabled = false;
                contextMenuStrip1.Show(richTextBox1, new Point(e.X, e.Y));
            }
        }

        private void selectall_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void clip_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void paste_Click(object sender, EventArgs e)
        {
            if ((richTextBox1.SelectionLength > 0) && (MessageBox.Show("是否覆盖选中的文本?", "覆盖", MessageBoxButtons.YesNo) == DialogResult.No))
                richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            richTextBox1.Paste();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void redo_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
                richTextBox1.Redo();
        }

        private void selectall2_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectAll();
        }

        private void copy2_Click(object sender, EventArgs e)
        {
            richTextBox2.Copy();
        }

        private void clip2_Click(object sender, EventArgs e)
        {
            richTextBox2.Cut();
        }

        private void paste2_Click(object sender, EventArgs e)
        {

            if ((richTextBox2.SelectionLength > 0) && (MessageBox.Show("是否覆盖选中的文本?", "覆盖", MessageBoxButtons.YesNo) == DialogResult.No))
                richTextBox2.SelectionStart = richTextBox2.SelectionStart + richTextBox2.SelectionLength;
            richTextBox2.Paste();
        }

        private void delete2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void undo2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.CanUndo)
            {
                richTextBox2.Undo();
            }
        }

        private void redo2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.CanRedo)
                richTextBox2.Redo();
        }
    }
}

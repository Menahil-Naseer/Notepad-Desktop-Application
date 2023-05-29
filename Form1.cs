using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Notepad
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey300, Primary.BlueGrey300, Primary.BlueGrey300, Accent.LightBlue200, TextShade.BLACK);
        }
        MaterialSkinManager TManager = MaterialSkinManager.Instance;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            richTextBox1.Text = OpenFile.ReadToEnd();
            OpenFile.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(openFileDialog1.FileName);
            SaveFile.WriteLine(richTextBox1.Text);
            SaveFile.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
            SaveFile.WriteLine(richTextBox1.Text);
            SaveFile.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
               richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.Font = fontDialog1.Font;

            }
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Grey900, Accent.LightBlue200, TextShade.WHITE);
            TManager.Theme = MaterialSkinManager.Themes.DARK;
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey300, Primary.BlueGrey300, Primary.BlueGrey300, Accent.LightBlue200, TextShade.BLACK);
            TManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(statusStrip1.Visible)
            {
                statusStrip1.Visible = false;
            }
            else
                statusStrip1.Visible = true;
        }

    

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 22, 20);
        }

        private void wordWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWToolStripMenuItem.Checked == true)
            {
                wordWToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                wordWToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.Yellow;
        }
        private void statusStrip1_Leave(object sender, EventArgs e)
        {
            Cursor.Show();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var lineCount = richTextBox1.Lines.Count();
            toolStripStatusLabel1.Text ="lines: "+ lineCount.ToString();

            string count = richTextBox1.Text;
            toolStripStatusLabel2.Text = "Words: " + (count.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length).ToString();
            toolStripStatusLabel3.Text = "Char: " + richTextBox1.Text.Length;
        }
        public static void QuickReplace(RichTextBox rtb, String word, String word2)
        {
            rtb.Text = rtb.Text.Replace(word, word2);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d= DateTime.Now;
            richTextBox1.Text = d.ToString();
            
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = richTextBox1.Font.Size;
            currentSize += 2.0F;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize,
            richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = richTextBox1.Font.Size;
            currentSize -= 2.0F;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize,
            richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }

        private void statusStrip1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Hide();
        }


        private void statusStrip1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }
    }

 
    }



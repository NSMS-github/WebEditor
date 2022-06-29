using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WebEditor
{
    public partial class Form1 : Form
    {
        public static bool savedfile = true;
        public static string editingfile;
        public static bool newfile = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = textBox1.Text;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(newfile)
            {
                saveFileDialog1.ShowDialog();
                editingfile = saveFileDialog1.FileName;
                try
                {
                    StreamWriter sw = new StreamWriter(editingfile);
                    sw.Write(textBox1.Text);
                    sw.Close();
                    newfile = false;
                }
                catch { }
            }
            else
            {
                StreamWriter sw = new StreamWriter(editingfile);
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!newfile)
            {
                StreamWriter sw = new StreamWriter(editingfile);
                sw.Write(textBox1.Text);
                sw.Close();
                try
                {
                    webBrowser1.Navigate("file://" + editingfile);
                }
                catch { }
            }
            else
            {
                webBrowser1.DocumentText = textBox1.Text;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            editingfile = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(editingfile);
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
            webBrowser1.Navigate("file://" + editingfile);
            newfile = false;
        }
    }
}

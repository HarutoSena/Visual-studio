using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label3.Text = "取得中";
            label3.BringToFront();
            label3.Update();

            var scr = new SampleScraping();

            string url = textBox1.Text;
            string html = scr.GetHtml(url);
            textBox3.Text = html;
            string title = scr.GetTitle(html);
            textBox2.Text = title;
            label3.Visible = false;

            string tabledata = scr.GetTable(html);
            Form Form2 = new Form2(tabledata);
            Form2.Show();

        }
    }
}

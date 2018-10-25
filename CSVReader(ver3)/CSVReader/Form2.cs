using ClosedXML.Excel;
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

namespace CSVReader
{
    public partial class Form2 : Form
    {
        string filePath;
        Form1 form1;
        public Form2(string filePath,Form1 form1)
        {
            InitializeComponent();
            listBox1.Items.Add("残高試算表");
            listBox1.Items.Add("仕訳データ");
            listBox1.Items.Add("プロプラス仕訳");
            listBox1.Items.Add("管理会計帳票");
            this.filePath = filePath;
            this.form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3("処理中です。");
            Form3.Show();
            Form3.Update();
            Sousa sousa = new Sousa(listBox1.SelectedItem.ToString(), this.filePath,this.form1);
            
        }
    }
}

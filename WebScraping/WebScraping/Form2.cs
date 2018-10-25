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
    public partial class Form2 : Form
    {
        string tabledata;
        public Form2(string tabledata)
        {
            InitializeComponent();
            this.tabledata = tabledata;
            textBox1.Text = this.tabledata;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

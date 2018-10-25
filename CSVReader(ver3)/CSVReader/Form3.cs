using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVReader
{
    public partial class Form3 : Form
    {
        string ms;
        public Form3(string ms)
        {
            InitializeComponent();
            this.ms = ms;
            label1.Text = this.ms;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutrial3
{

    public partial class Form2 : Form
    {


        public Form2(TimeSpan ts)
        {
            InitializeComponent();
            //ts = new TimeSpan();
            label1.Text =$" {ts.Minutes}分 {ts.Seconds}秒　{ts.Milliseconds}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       
    }

   
}



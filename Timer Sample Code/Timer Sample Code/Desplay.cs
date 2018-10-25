using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer_Sample_Code
{
    public partial class Desplay : Form
    {
        public Desplay()
        {
            InitializeComponent();
        }

        private void Desplay_Load(object sender, EventArgs e)
        {
            SetTime();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void secTimer_Tick(object sender, EventArgs e)
        {
            SetTime();
        }
        private void SetTime()
        {
            label1.Text = DateTime.Now.ToString("HH時mm分 ss秒");
        }
    }
}

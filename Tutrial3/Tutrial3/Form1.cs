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
    public partial class Form1 : Form
    {
        //Use this Random object to chose random icons for the suares
        Random random = new Random();

        //Each of these letters is an interesting icon inthe webdings font,and each icon appears twice in this list
        List<string> icons = new List<string>()
        {
            "ら","り","る","れ","ろ","ん","ラ","リ","ル","レ","ロ","ン","サ","さ","き","キ","す","ス","ア","あ"
        };

        //firstClicked points to the first Label control that the player clicks,but it will be null if the player hasn't clcked a labeb yet
        Label firstClicked = null;
        Label secondClicked = null;

        Stopwatch sw = new Stopwatch();
        
        private void AssignIconsToSquares()
        {
            //The TableLayoutPanel has 16 labals and the icon list has 16 icons
            //so an icon is pulled at random from the list and added to each label
            //foreachはコレクションのすべての要素を1回づつ読み出す構文
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);//Listから引っ張ってる
                    iconLabel.Text = icons[randomNumber];
                    //iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);//Listで使った要素を削除
                }
            }
            sw.Start();
        }


        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();

        }

        private void MatchingGame_Load(object sender, EventArgs e)
        {
            
        }

        private void label_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == true)
            {
                return;
            }

            Label clickedLabel = sender as Label;
            if(clickedLabel != null)
            {
                //If the clicekd label is black,the player clicked an icon that's already been revealed--
                //igonre the click
                if(clickedLabel.ForeColor == Color.Black)
                {
                    return;
                };
                if(firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CloseGame();

                string f = Microsoft.VisualBasic.Strings.StrConv(firstClicked.Text, Microsoft.VisualBasic.VbStrConv.Katakana, 0x411);
                string s = Microsoft.VisualBasic.Strings.StrConv(secondClicked.Text, Microsoft.VisualBasic.VbStrConv.Katakana, 0x411);
                if (f == s)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                //If the player gets this far,the player cliced two different icons,so start the timer
                //(which will wait three quarters of a second,and  then hide the icon)
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            //Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            //Reset firstCliced and secondClicked so the next time a label is clicked,the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }

        private void CloseGame()
        {   //一個でも揃ってない組があればリターン
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    if(iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }
            sw.Stop();
            TimeSpan ts = new TimeSpan();
            ts = sw.Elapsed;
            Form2 form2 = new Form2(ts);
            form2.Show();
            MessageBox.Show("Congratulations");
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

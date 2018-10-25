using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 10;

            dataGridView1.Columns[0].HeaderText = "曜日";
            dataGridView1.Columns[1].HeaderText = "日付";
            dataGridView1.Columns[2].HeaderText = "朝ご飯";
            dataGridView1.Columns[3].HeaderText = "カロリー";
            dataGridView1.Columns[4].HeaderText = "昼御飯";
            dataGridView1.Columns[5].HeaderText = "カロリー";
            dataGridView1.Columns[6].HeaderText = "晩御飯";
            dataGridView1.Columns[7].HeaderText = "カロリー";
            dataGridView1.Columns[8].HeaderText = "合計カロリー";
            dataGridView1.Columns[9].HeaderText = "Sort";

            dataGridView1.Rows.Add("月");
            dataGridView1.Rows.Add("火");
            dataGridView1.Rows.Add("水");
            dataGridView1.Rows.Add("木");
            dataGridView1.Rows.Add("金");
            dataGridView1.Rows.Add("土");
            dataGridView1.Rows.Add("日");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string x = dataGridView1.Rows[i].Cells[0].Value.ToString();
                switch (x)
                {
                    case "月":
                        dataGridView1.Rows[i].Cells[9].Value = 0;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "火":
                        dataGridView1.Rows[i].Cells[9].Value = 1;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "水":
                        dataGridView1.Rows[i].Cells[9].Value = 2;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "木":
                        dataGridView1.Rows[i].Cells[9].Value = 3;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "金":
                        dataGridView1.Rows[i].Cells[9].Value = 4;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "土":
                        dataGridView1.Rows[i].Cells[9].Value = 5;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "日":
                        dataGridView1.Rows[i].Cells[9].Value = 6;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                }
            }
        }

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
           
            //没
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //選択している行の下に、行を追加
            int nRowIndex = dataGridView1.CurrentCell.RowIndex;
            string Youbi = dataGridView1.Rows[nRowIndex].Cells[0].Value.ToString();
            int Sortn = int.Parse(dataGridView1.Rows[nRowIndex].Cells[9].Value.ToString());
            DishData dishdata = new DishData (Youbi, Sortn);
            dataGridView1.Rows.InsertCopy(nRowIndex, nRowIndex);
            dataGridView1.Rows[nRowIndex].Cells[0].Value = dishdata.Youbi;
            dataGridView1.Rows[nRowIndex].Cells[9].Value = dishdata.SortN;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string x = dataGridView1.Rows[i].Cells[0].Value.ToString();

                switch (x)
                {
                    case "月":
                        dataGridView1.Rows[i].Cells[9].Value = 0;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "火":
                        dataGridView1.Rows[i].Cells[9].Value = 1;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "水":
                        dataGridView1.Rows[i].Cells[9].Value = 2;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "木":
                        dataGridView1.Rows[i].Cells[9].Value = 3;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "金":
                        dataGridView1.Rows[i].Cells[9].Value = 4;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "土":
                        dataGridView1.Rows[i].Cells[9].Value = 5;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                    case "日":
                        dataGridView1.Rows[i].Cells[9].Value = 6;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        dataGridView1.Rows[i].Cells[7].Value = 0;
                        break;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //再計算
            //行ごとのカロリーを合計する
            //曜日ごとの小計を作って、カロリーの総合計を表示する（曜日列＝"小計",合計カロリー列＝”総合計”）
            int LastRown = dataGridView1.Rows.Count;
            int[] SumFirstRown = {0,0,0,0,0,0,0 };//[要素　0=月曜日,1=火曜日・・・]
            int[] SumLastRown =  {0,0,0,0,0,0,0 };


            //それぞれの曜日の最初の行、最終行をチェック

            try
            {
                for (int i = 0; i < LastRown; i++)
                {
                    //ここでエラー吐く。意味わからん。
                    string x = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    switch (x)
                    {
                        case "月":
                            SumLastRown[0] = i;
                            SumFirstRown[1] = i + 1;
                            break;
                        case "火":
                            SumLastRown[1] = i;
                            SumFirstRown[2] = i + 1;
                            break;
                        case "水":
                            SumLastRown[2] = i;
                            SumFirstRown[3] = i + 1;
                            break;
                        case "木":
                            SumLastRown[3] = i;
                            SumFirstRown[4] = i + 1;
                            break;
                        case "金":
                            SumLastRown[4] = i;
                            SumFirstRown[5] = i + 1;
                            break;
                        case "土":
                            SumLastRown[5] = i;
                            SumFirstRown[6] = i + 1;
                            break;
                        case "日":
                            SumLastRown[6] = i;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("error");
                //Nullでてくるけど握りつぶす
            }
                for (int i = 0; i < 7; i++)
                {
                    int beg = SumFirstRown[i];
                    int end = SumLastRown[i];
                    for (int j = beg; j < end + 1; j++)
                    {
                        //横計を入れる

                        double tmp1 = double.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());
                        double tmp2 = double.Parse(dataGridView1.Rows[j].Cells[5].Value.ToString());
                        double tmp3 = double.Parse(dataGridView1.Rows[j].Cells[7].Value.ToString());
                        double Htotal = tmp1 + tmp2 + tmp3;
                        dataGridView1.Rows[j].Cells[8].Value = Htotal;
                        //縦計を入れる
                    }
                }
                //DataGridViewRowCollection rows = dataGridView1.Rows; foreachでやるなら使う
            
            
        }
    }
}

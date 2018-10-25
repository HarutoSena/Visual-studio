using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingController
{
    class OriginalSort
    {
        //arrayをDataGirdView に変えて、rows[x].cell[y].Valueを入れ替えれば行ける
        public void QuickSort(DataGridView dataGridView1, int left, int right) // where T:ICompareble<t> ジェネリックをここで勉強 →今回は不要と理解
        {
            //left=要素の最初、right＝要素の末尾 arrayはソートしたいデータ
            int i = left;
            int j = right;
            int pivot;

            int mid = dataGridView1.Rows.Count / 2;
            pivot = int.Parse(dataGridView1.Rows[mid].Cells[8].Value.ToString());//arrya[]の真ん中の値をpivotに

            while (true)
            {
                while (int.Parse(dataGridView1.Rows[i].Cells[8].ToString()) < pivot)//pivot以上の値が見つかるまで右
                {
                    i++;
                }
                while(int.Parse(dataGridView1.Rows[j].Cells[8].ToString()) > pivot)//pivot以下の値が見つかるまで左
                {
                    j--;
                }
                if (i >= j) break;//軸がぶつかったら一旦ソート終り

                //pivotより大きいのと小さいのを交換
                //temp = array[i];
                //array[i] = array[j];
                //array[j] = temp;
                //i++;
                //j--;
                DishData dishData = new DishData();
                for(int k = 0; k < dataGridView1.Rows.Count - 1; k++)
                {
                        dishData.Youbi = dataGridView1.Rows[k].Cells[0].Value.ToString();
                        dishData.Morning = dataGridView1.Rows[k].Cells[1].Value.ToString();
                        dishData.MCal = double.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString());
                        dishData.Lunch = dataGridView1.Rows[k].Cells[3].Value.ToString();
                        dishData.LCal = double.Parse(dataGridView1.Rows[k].Cells[4].Value.ToString());
                        dishData.Dinner = dataGridView1.Rows[k].Cells[5].Value.ToString();
                        dishData.DCal = double.Parse(dataGridView1.Rows[k].Cells[6].Value.ToString());
                        dishData.TotalCal = double.Parse(dataGridView1.Rows[k].Cells[7].Value.ToString());
                        dishData.SortN = int.Parse(dataGridView1.Rows[k].Cells[8].Value.ToString());

                }

            }
            //上でいったんソート終了
            //軸の左側をソート開始
            if(left < i - 1)
            {
                QuickSort(dataGridView1, left, i - 1);
            }
            //軸の右側をソート開始
            if (j + 1 < right)
            {
                QuickSort(dataGridView1, j + 1, right);
            }
            
        }
    }
}

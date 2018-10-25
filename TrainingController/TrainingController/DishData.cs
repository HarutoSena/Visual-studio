using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingController
{
    class DishData
    {
        private DateTime dt;
        public DateTime Dt
        {
            get { return this.dt; }
            set { this.dt=value; }
        }
        private string youbi;
        public string Youbi
        {
            get { return this.youbi; }
            set { this.youbi = value; }
        }
        private string morning;
        public string Morning {
            get { return this.morning; }
            set { this.morning = value; }
        }
        private double mcal;
        public double MCal
        {
            get { return this.mcal; }
            set { this.mcal = value; }
        }
        private string lunch;
        public string Lunch
        {
            get { return this.lunch; }
            set { this.lunch = value; }
        }
        private double lcal;
        public double LCal
        {
            get { return this.lcal; }
            set { this.lcal = value; }
        }
        private string dinner;
        public string Dinner
        {
            get { return this.dinner; }
            set { this.dinner = value; }
        }
        private double dcal;
        public double DCal
        {
            get { return this.dcal; }
            set { this.dcal = value; }
        }
        private double totalcal;
        public double TotalCal
        {
            get { return this.totalcal; }
            set { this.totalcal = value; }
        }
        private int sortn;
        public int SortN
        {
            get { return this.sortn; }
            set { this.sortn = value; }
        }

        public DishData(DateTime dt,string youbi,string morning,double mcal,string lunch,double lcal,string dinner,double dcal,double totalcal,int sortn)
        {
            this.dt = dt;
            this.youbi = youbi;
            this.morning = morning;
            this.mcal = mcal;
            this.lunch = lunch;
            this.lcal = lcal;
            this.dinner = dinner;
            this.dcal = dcal;
            this.totalcal =totalcal;
            this.sortn = sortn;
        }

        public DishData()
            : this(DateTime.Parse("2018/1/1"), "","", 0, "", 0, "", 0, 0, 0) { }

        public DishData(string youbi,int sortn)
        {
            this.youbi = youbi;
            this.sortn = sortn;
        }

       
    }
}

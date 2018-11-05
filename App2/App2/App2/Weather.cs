using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    class Weather
    {
        public string Title { get; set; }
        public string Tempepature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }

        public Weather()
        {
            this.Title = "";
            this.Tempepature = "";
            this.Wind = "";
            this.Humidity = "";
            this.Visibility = "";
            this.Sunrise = "";
            this.Sunset = "";
        }
    }
}

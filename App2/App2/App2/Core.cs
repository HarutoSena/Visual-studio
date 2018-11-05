using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Core
    {
        public static async Task<Weather> Getweather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "d621f0dd9df3d01206db38c959d88902";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&appid=" + key + "&units=imperial";

            //awaitする際にコンテキストを保存しない設定。await後に同じスレッドに戻らなくても処理できる。
            dynamic results = await Dataservice.getDataFormService(queryString).ConfigureAwait(false);

            //続きはこっから。
        }
    }
}

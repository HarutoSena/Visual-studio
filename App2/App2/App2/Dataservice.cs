using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace App2
{
    class Dataservice
    {   //Taskは非同期処理の時つかったりする。単純に手順書的な意味だと思えばよい。
        //dynamic型は静的な型に対する動的コード生成
        //dynamic を使うとダックタイピングやデータ連携ができる。
        public static Task<dynamic> getDataFormService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            dynamic data = null;
            if(response!= null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }
    }
}

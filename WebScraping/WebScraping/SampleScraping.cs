using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScraping
{
    class SampleScraping
    {
        public string GetHtml(string url)
        {
            //指定されたURLに対してのRequestを作成
            var req = (HttpWebRequest)WebRequest.Create(url);
            // html 取得文字列
            string html = "";

            //指定したURLに対してRequestを投げてResponseを取得
            using (var res = (HttpWebResponse)req.GetResponse())
            using (var resSt = res.GetResponseStream())
            //取得した文字列をエンコード
            using (var sr = new StreamReader(resSt, Encoding.UTF8))
            {
                //Get HTML
                html = sr.ReadToEnd();
            }

            return html;
        }

        public string GetTitle(string html)
        {
            //正規表現
            //大文字小文字区別なし : RegexOptions.IgnoreCase
            //.　に改行にも適応する設定 :RegexOptions.SingleLine
            //<title>の後に何か文字があるものを集める？？？
            //var reg = new Regex(@"<title>(?<title>.*?)</title>",
            //    RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var reg = new Regex(@"<title>(?<title>.*)</title>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            //html文字列内から条件にマッチしたデータを抜き取り
            var m = reg.Match(html);

            //条件にマッチした文字列内からkey("title部分")にマッチした値を抜き取り。
            //(?<title>)でkeyを付けたので、その部分を持ってきてる
            return m.Groups["title"].Value;
        }

        public string GetTable(string html)
        {
            var reg = new Regex(@"<table(?<table>.*)</table>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var m = reg.Match(html);
            return m.Groups["table"].Value;
        }
    }
}

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVReader
{
    class Sousa
    {
        string kind;
        string filePath;
        Form1 form1;

        public string FilePath { get => filePath; set => filePath = value; }
        public string Kind { get => kind; set => kind = value; }
        public Form1 Form1 { get => form1; set => form1 = value; }


        //データ格納と操作の選択(Controller)
        public Sousa(string kind ,string filePath,Form1 form1)
        {
            this.Kind = kind;
            this.FilePath = filePath;
            this.Form1 = form1;

            if(this.Kind == "プロプラス仕訳"){
                getCSV(this.FilePath);
                this.Form1.Close();
                
            }else if (this.Kind == "残高試算表")
            {
                TBCreate(this.FilePath);
                this.Form1.Close();
                
            }
            else if (this.Kind == "仕訳データ")
            {
                PJCreate(this.FilePath);
                this.Form1.Close();
            }
            else if (this.Kind == "管理会計帳票")
            {
                Kanri(this.FilePath);
                this.Form1.Close();
            }

        }

        //こっから下はメソッド(Moduel)
        //Proplus出力仕訳データの日本語化
        private void getCSV(string filePath)
        {
            //utf-8で読み込み
            List<string[]> readList = new List<string[]>();
            string lan = "utf-8";
            using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding(lan)))
            {
                while (!sr.EndOfStream)
                {
                    string tmpLine = sr.ReadLine();
                    //何か行頭にダブルクオーテーションがあるので削除
                    string tmpLine2 = tmpLine.Replace('"', ' ');
                    string Line = tmpLine2.Trim();
                    //tsvファイルなのでタブで区切って読み取り
                    readList.Add(Line.Split('\t'));
                }
            }
            string[][] ans = readList.ToArray();
            long[] tran = new long[ans.Length];
            AccountTitle ac = new AccountTitle();
            //MessageBox.Show("\"\"");

            try
            {
                for (int i = 0; i < ans.Length; i++)
                {
                    for (int j = 0; j < ac.code.Length; j++)
                    {
                        if (ans[i][12] == ac.code[j])
                        {
                            ans[i][13] = ac.name[j];
                        }
                        //ジャグ配列のためansの配列要素（2次元目）が22までしかないものがあるためエラーを吐く
                        //どうにか配列の要素数を増やしたいが上手くいかない
                        if(ans[i].Length < 24)
                        {
                            Array.Resize(ref ans[i], ans[i].Length + 10);
                        }

                    }

                    for (int k = 0; k < ac.costcenterName.Length; k++)
                    {
                        if ((ans[i][19] == "" && ans[i][20] == ac.costcenterCode[k]) || (ans[i][19] == null && ans[i][20] == ac.costcenterCode[k]))
                        {
                            ans[i][23] = ac.costcenterName[k];
                        }
                        else if (ans[i][19] == ac.costcenterCode[k])
                        {   
                            ans[i][23] = ac.costcenterName[k];
                        }
                        else
                        {
                            //ans[i][23] = "Can't look for";
                        }
                    }

                    //仕訳の金額データをlongに変換
                    tran[i] = long.Parse(ans[i][16]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("OutOfRangeException");
            }
            finally{
                for (int i = 0; i < ans.Length; i++)
                {
                    for (int j = 0; j < ac.code.Length; j++)
                    {
                        if (ans[i][12] == ac.code[j])
                        {
                            ans[i][13] = ac.name[j];
                        }
                    }
                    tran[i] = long.Parse(ans[i][16]);
                }
            }
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Journal Entries");
            worksheet.Cell("A1").InsertData(ans);
            worksheet.Cell("Q1").InsertData(tran);
            //上記で全仕訳変換
            //下から20列目のデータの頭４桁を参照し事業領域ごとに分割する-methodを別に作る

            List<string[]> Honshya = new List<string[]>();
            List<string[]> Nishi = new List<string[]>();
            List<string[]> Tyuubu = new List<string[]>();
            List<string[]> Kawaguchi = new List<string[]>();
            List<string[]> Tokyo = new List<string[]>();
            List<string[]> Osaka = new List<string[]>();
            List<string[]> Shiga = new List<string[]>();
            List<string[]> Tokai = new List<string[]>();

            for(int i = 0;i< ans.Length; i++)
            {
                try
                {
                    string Cost = "";
                    if (ans[i][19] != null || ans[i][19] != "\"\"")
                    {
                        Cost = ans[i][19].Substring(0, 4);
                    }
                    else
                    {
                        Cost = ans[i][20].Substring(0, 4);
                    }

                    switch (Cost)
                    {
                        case "1020":
                            Nishi.Add(ans[i]);
                            break;
                        case "1030":
                            Tyuubu.Add(ans[i]);
                            break;
                        case "1078":
                            Kawaguchi.Add(ans[i]);
                            break;
                        case "1070":
                            Tokyo.Add(ans[i]);
                            break;
                        case "1072":
                            Osaka.Add(ans[i]);
                            break;
                        case "1074":
                            Tokai.Add(ans[i]);
                            break;
                        case "1066":
                            Shiga.Add(ans[i]);
                            break;
                        default:
                            Honshya.Add(ans[i]);
                            break;
                    }
                }
                catch (Exception e)
                {
                    string Cost = "";
                    Cost = ans[i][20].Substring(0, 4);


                    switch (Cost)
                    {
                        case "1020":
                            Nishi.Add(ans[i]);
                            break;
                        case "1030":
                            Tyuubu.Add(ans[i]);
                            break;
                        case "1078":
                            Kawaguchi.Add(ans[i]);
                            break;
                        case "1070":
                            Tokyo.Add(ans[i]);
                            break;
                        case "1072":
                            Osaka.Add(ans[i]);
                            break;
                        case "1074":
                            Tokai.Add(ans[i]);
                            break;
                        case "1066":
                            Shiga.Add(ans[i]);
                            break;
                        default:
                            Honshya.Add(ans[i]);
                            break;
                    }
                }
                

            }
            Array.Clear(ans, 0, ans.Length);
            ans = Honshya.ToArray();
            var worksheet1 = workbook.Worksheets.Add("本社");
            worksheet1.Cell("A1").InsertData(ans);

            Array.Clear(ans, 0, ans.Length);
            ans = Nishi.ToArray();
            var worksheet2 = workbook.Worksheets.Add("西");
            worksheet2.Cell("A1").InsertData(ans);

            Array.Clear(ans, 0, ans.Length);
            ans = Tyuubu.ToArray();
            var worksheet3 = workbook.Worksheets.Add("中");
            worksheet2.Cell("A1").InsertData(ans);

            Array.Clear(ans, 0, ans.Length);
            ans = Kawaguchi.ToArray();
            var worksheet4 = workbook.Worksheets.Add("川");
            worksheet2.Cell("A1").InsertData(ans);

            Array.Clear(ans, 0, ans.Length);
            ans = Tokyo.ToArray();
            var worksheet5 = workbook.Worksheets.Add("東");
            worksheet2.Cell("A1").InsertData(ans);

            Array.Clear(ans, 0, ans.Length);
            ans = Osaka.ToArray();
            var worksheet6 = workbook.Worksheets.Add("大");
            worksheet2.Cell("A1").InsertData(ans);

            Array.Clear(ans, 0, ans.Length);
            ans = Tokai.ToArray();
            var worksheet7 = workbook.Worksheets.Add("海");
            worksheet2.Cell("A1").InsertData(ans);

            Array.Clear(ans, 0, ans.Length);
            ans = Shiga.ToArray();
            var worksheet8 = workbook.Worksheets.Add("滋");
            worksheet2.Cell("A1").InsertData(ans);


            string desk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desk += "\\Proplus_Data.xlsx";
            workbook.SaveAs(desk);
        }

        private void TBCreate(string filePath)
        {
            List<string[]> readList = new List<string[]>();
            string lan = "UTF-8";
            using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding(lan)))
            {
                while (!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();
                    readList.Add(Line.Split('\t'));
                }
            }
            string[][] ans = readList.ToArray();
            for (int i = 0; i < ans.Length; i++)
            {
                for (int j = 0; j < ans[0].Length; j++)
                {
                    ans[i][j] = ans[i][j].Trim();
                }
            }

            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("TB");
            worksheet.Cell("A1").InsertData(ans);
            string desk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desk += "\\TB_Data.xlsx";
            workbook.SaveAs(desk);
        }

        private void Kanri(string filePath)
        {
            List<string[]> readList = new List<string[]>();
            string lan = "UTF-8";
            using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding(lan)))
            {
                while (!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();
                    readList.Add(Line.Split('|'));
                }
            }
            string[][] ans = readList.ToArray();
            for (int i = 0; i < ans.Length; i++)
            {
                for (int j = 0; j < ans[0].Length; j++)
                {
                    ans[i][j] = ans[i][j].Trim();

                }
            }

            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("TKanri");
            worksheet.Cell("A1").InsertData(ans);
            string desk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desk += "\\Kanri.xlsx";
            workbook.SaveAs(desk);
        }

        private void PJCreate(string filePath)
        {
            //基本的に没。1列目にある大量の図形オブジェクトが悪さをして処理できない！！
            //消せばできる！！
            using (XLWorkbook wb = new XLWorkbook(filePath))
            {
                //最初のシートを取得
                IXLWorksheet ws = wb.Worksheets.Worksheet(1);
                //最終行の取得・最終列の取得
                int RowN = ws.LastRowUsed().RowNumber();
                int ColN = ws.LastColumnUsed().ColumnNumber();

                //最終列の次の列を取得
                ColN++;

                //勘定科目一覧を取得してエクセル上の相手勘定コードと比較
                AccountTitle accountTitle = new AccountTitle();
                ws.Cell(1, ColN).Value = "相手勘定コード名";

                for (int i = 2; i <= RowN; i++)
                {
                    for (int j = 0; j < accountTitle.code.Length; j++)
                    {
                        if (accountTitle.code[j] == ws.Cell(i, 52).GetString())
                        {
                            //勘定科目一覧とエクセルのコードが一致していれば勘定科目名を最終列＋１に入力
                            ws.Cell(i, ColN).Value = accountTitle.name[j];
                        }
                    }

                }
                wb.Save();

            }
        }

    }
}

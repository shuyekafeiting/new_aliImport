using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace WindowsFormsApp1
{
    class Trade
    {
        private string importUrl = "";
        private string logAdd = "";//日志地址
        private int ifHanddleStart = 0;//手动导单是否开始
        private int ifProsseStart = 0;//是否已经有线程在导单
        private string acc;//当前处理的账户
        private TextBox out_text = new TextBox();//输出面板
        public static string logAcc = "查看所有";//显示log的账号
        private ProgressBar ProgressBar = new ProgressBar();//进度条
        private BackgroundWorker BackWorker;
        private Button Button;
        public int runStatus = 1;
        public ERRORACC erroracc= new ERRORACC{};//执行报错的账号
        public int ifHasError = 0;//导单是否有报错
        public Trade(string nick, TextBox out_text1, ProgressBar _progressBar, Button button, string importUrl1) {
            logAdd = "logs/" + nick + ".log";
            acc = nick;
            out_text = out_text1;
            ProgressBar = _progressBar;
            Button = button;
            importUrl = importUrl1;
        }
        //开启导单进程
        public void beginImportPress(object send)
        {

            BackgroundWorker bw = new BackgroundWorker();
            BackWorker = bw;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            //开始背景线程
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);//线程结束时汇报状态
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync(send);
        }
        //定义导单的后台工作
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker bgWorker = sender as BackgroundWorker;//定义一个后台汇报进度的进程
            var receive = e.Argument as object[];
            string start_time = (string)receive[0];
            int page = (int)receive[1];
            string order_query_type = (string)receive[2];
            int doTimes = (int)receive[3];
            string order_scene = (string)receive[4];
            //判断是否取消操作 
            doImortTrade(start_time, page, doTimes, order_scene, order_query_type, e, bgWorker);

        }
        //导单后台进程结束时调用,没有使用
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //这时后台线程已经完成，并返回了主线程，所以可以直接使用UI控件了 
            if (e.Cancelled) {
                runStatus = 0;

                //Button.Text = "开始";
                // 
                WriteLog("用户取消了操作" + System.Environment.NewLine);
            }
            else
            {
                runStatus = 0;
                if (ProgressBar.Value == ProgressBar.Maximum)
                {
                    Button.Text = "开始";
                    Button.Font = new Font("宋体", 14);
                }
                WriteLog("执行结束" + System.Environment.NewLine);
            }

        }
        //导单后台进程运行时调用
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //这时后台线程已经完成，并返回了主线程，所以可以直接使用UI控件了 
            var receive = e.UserState as object[];

            string code = (string)receive[0];
            string info = (string)receive[1];
            string acc = (string)receive[2];
            if (code == "-1")
            {
                //记录报错的账号
                erroracc.name = acc;
                erroracc.reseaon = info;
                ifHasError = 1;
            }

            try
            {
                ProgressBar.Value = ProgressBar.Value + 1;
            } catch (Exception ee)
            {
                ProgressBar.Value = ProgressBar.Maximum;
            }
            //Console.WriteLine(info + System.Environment.NewLine);
            WriteLog(info + System.Environment.NewLine);
        }
        /**
         * 导入订单可以指定导入多少次,每次导入20分钟的
         * doTimes导入次数
         * */
        private void doImortTrade(string start_time, int page, int doTimes, string order_scene, string order_query_type, DoWorkEventArgs e, BackgroundWorker bgWorker, string _position_index = "-1")
        {

            if (bgWorker.CancellationPending)
            {
                //真正取消进程
                e.Cancel = true;
                return;
            }
            var getUrl = "";

            //加工url
            getUrl = doGetUrl(_position_index, start_time, page, order_scene, order_query_type, acc);
            Console.WriteLine(getUrl);
            try
            {
                string re = HttpRequestHelper.HttpGetRequest(getUrl);


                ReObject Resault = JsonConvert.DeserializeObject<ReObject>(re);//json解析
                string ifEnd = Resault.ifEnd;
                string code = Resault.code;
                string position_index = Resault.position_index;
                if (doTimes >= 0)
                {
                    if (code == "-1")
                    {
                        //报错
                        string result = Resault.data;
                        var send = new object[3];
                        send[0] = code;
                        send[1] = result;
                        send[2] = acc;
                        //e.Result = send;汇报结束
                        bgWorker.ReportProgress(1, send);
                    }
                    else
                    {
                        if (ifEnd == "1")
                        {
                            doTimes = doTimes - 1;

                            //结束
                            string result = getResultString(Resault.startTime, order_query_type, order_scene, page.ToString(), Resault.totalNum, Resault.newNum, Resault.updateNum);

                            var send = new object[3];
                            send[0] = code;
                            send[1] = result;
                            send[2] = acc;
                            //e.Result = send;
                            bgWorker.ReportProgress(1, send);
                            //handleResult(code, result);
                            //增加20分钟继续
                            DateTime t1 = Convert.ToDateTime(Resault.startTime);
                            t1 = t1.AddMinutes(10);
                            string t2 = t1.ToString("yyyy-MM-dd HH:mm:00");
                            doImortTrade(t2, 1, doTimes, order_scene, order_query_type, e, bgWorker);
                        }
                        else
                        {
                            //下一页
                            string result = getResultString(Resault.startTime, order_query_type, order_scene, page.ToString(), Resault.totalNum, Resault.newNum, Resault.updateNum);
                            var send = new object[3];
                            send[0] = code;
                            send[1] = result;
                            send[2] = acc;
                            bgWorker.ReportProgress(1, send);
                            //handleResult(code, result);
                            doImortTrade(start_time, page + 1, doTimes, order_scene, order_query_type, e, bgWorker, position_index);
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception em)
            {
                var send = new object[3];
                send[0] = "-1";
                send[1] = "连接服务器报错";
                send[2] = acc;
                e.Result = send;
                bgWorker.ReportProgress(1, send);
            }
        }
        //停止导单
        public void Cancel_import() {
            BackWorker.CancelAsync();
        }
        //写入log
        public void WriteLog(string str)
        {
            int lineNum = out_text.GetLineFromCharIndex(out_text.Text.Length) + 1;
            if (lineNum > 200)
            {
                out_text.Text = "";
            }
            if (logAcc == "查看所有")
            {
                out_text.Text = " 账号:" + acc + " " + str + out_text.Text;

            } else if (logAcc == acc)
            {
                out_text.Text = " 账号:" + acc + " " + str + out_text.Text;
            }

            FileStream fs = null;
            FileStream fsAll = null;
            //将待写的入数据从字符串转换为字节数组  
            Encoding encoder = Encoding.UTF8;
            byte[] bytes = encoder.GetBytes(str);
            try
            {
                //fsAll = File.OpenWrite("logs/all.log");
                //fs = File.OpenWrite(logAdd);
                //设定书写的開始位置为文件的末尾  
                //fs.Position = fs.Length;
                // fsAll.Position = fsAll.Length;
                //将待写入内容追加到文件末尾  
                // fs.Write(bytes, 0, bytes.Length);
                //fsAll.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件打开失败{0}", ex.ToString());
            }

            Console.ReadLine();

        }
        //解析json使用
        public class ReObject
        {
            public string totalNum { get; set; }
            public string newNum { get; set; }
            public string updateNum { get; set; }
            public string code { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }
            public string ifEnd { get; set; }
            public string data { get; set; }
            public string position_index { get; set; }
        }

        //根据_position_index加工url
        private string doGetUrl(string _position_index, string start_time, int page, string order_scene, string order_query_type, string acc)
        {
            string getUrl;
            getUrl = importUrl + "start_time=" + start_time + "&page_no=" + page + "&acc=" + acc + "&order_query_type=" + order_query_type + "&order_scene=" + order_scene + "&span=600";
            if (_position_index != "-1")
            {
                getUrl = getUrl + "&position_index=" + _position_index;
            }
            return getUrl;
        }
        //加工处理结果字符串
        private string getResultString(string startTime, string tradeType, string order_scene, string page, string totalNum, string newNum, string updateNum)
        {
            switch (order_scene)
            {
                case "1":
                    order_scene = "常规订单";
                    break;
                case "2":
                    order_scene = "渠道订单";
                    break;
                case "3":
                    order_scene = "会员订单";
                    break;
            }
            switch (tradeType)
            {
                case "create_time":
                    tradeType = "新增";
                    break;
                case "settle_time":
                    tradeType = "结算";
                    break;
                case "payment_time":
                    tradeType = "付款";
                    break;
            }
            string resultStr;
            resultStr = startTime + " " + tradeType + "-" + order_scene + " P" + page + ": 共" + totalNum + "单,插入" + newNum + "单,更新" + updateNum + "单";
            return resultStr;
        }
        //处理报错的账号
        public class ERRORACC{
            public string name;
            public string reseaon;
        }
    }

   
}

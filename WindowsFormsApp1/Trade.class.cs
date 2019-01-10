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
        private string logAdd = "";//日志地址
        private string importUrl = ConfigHelper.GetAppConfig("importUrl");
        private int ifHanddleStart = 0;//手动导单是否开始
        private int ifProsseStart = 0;//是否已经有线程在导单
        private string acc;//当前处理的账户
        private TextBox out_text = new TextBox();//输出面板
        public static string logAcc = "查看所有";//显示log的账号
        private ProgressBar ProgressBar = new ProgressBar();//进度条
        private BackgroundWorker BackWorker;
        private Button Button;
        public int runStatus=1;
        public Trade(string nick, TextBox out_text1,ProgressBar _progressBar,Button button) {
            logAdd = "logs/" + nick + ".log";
            acc = nick;
            out_text = out_text1;
            ProgressBar = _progressBar;
            Button = button;
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
            int tradeType = (int)receive[2];
            int doTimes = (int)receive[3];
            //判断是否取消操作 
            
            if (doTimes == -1)
            {
                doImortTrade(start_time, page, tradeType, e, bgWorker);
            }
            else
            {
                
                doImortTrade1(start_time, page, tradeType, doTimes, e, bgWorker);
            }

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
                if (ProgressBar.Value== ProgressBar.Maximum)
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

            Console.WriteLine(code);
            try
            {
                ProgressBar.Value = ProgressBar.Value + 1;
            }catch(Exception ee)
            {
                ProgressBar.Value = ProgressBar.Maximum;
            }
            
            if (code == "-1")
            {
                Console.WriteLine(info + System.Environment.NewLine );
                WriteLog(info + System.Environment.NewLine);
            }
            else
            {


                Console.WriteLine(info + System.Environment.NewLine );
                WriteLog(info + System.Environment.NewLine);
                
            }
        }
        //每分钟导入订单函数
        private void doImortTrade(string start_time, int page, int tradeType, DoWorkEventArgs e, BackgroundWorker bgWorker)
        {
            
            var getUrl = "";
            var tradeTypeStr = "";
            switch (tradeType)
            {
                case 1:
                    getUrl = importUrl + "start_time=" + start_time + "&order_query_type=create_time&page_no=" + page + "&acc=" + acc;//订单创建
                    tradeTypeStr = "创建订单";
                    break;
                case 2:
                    getUrl = importUrl + "start_time=" + start_time + "&order_query_type=settle_time&page_no=" + page + "&acc=" + acc;//计算订单
                    tradeTypeStr = "结算订单";
                    break;
            }
            try
            {//请求服务器
                Console.WriteLine(getUrl);
                string re = HttpRequestHelper.HttpGetRequest(getUrl);
                Console.WriteLine(re);
                try
                {
                    ReObject Resault = JsonConvert.DeserializeObject<ReObject>(re);
                    string ifEnd = Resault.ifEnd;
                    string code = Resault.code;
                    if (code == "-1")
                    {
                        //报错
                        string result = Resault.data;
                        var send = new object[2];
                        send[0] = code;
                        send[1] = result;
                        //e.Result = send;汇报结束
                        bgWorker.ReportProgress(1, send);
                    }
                    else
                    {
                        if (ifEnd == "1")
                        {
                            //结束
                            string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ": 共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                            var send = new object[2];
                            send[0] = code;
                            send[1] = result;
                            //e.Result = send;
                            bgWorker.ReportProgress(1, send);
                        }
                        else
                        {
                            //下一页
                            string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ": 共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                            var send = new object[2];
                            send[0] = code;
                            send[1] = result;
                            //e.Result = send;
                            bgWorker.ReportProgress(1, send);
                            // handleResult(code, result);
                            doImortTrade(start_time, page + 1, tradeType, e, bgWorker);
                        }
                    }
                }
                catch (Exception e1)
                {
                    var send = new object[2];
                    send[0] = "-1";
                    send[1] = "请求服务器错误:" + re;
                    //e.Result = send;
                    bgWorker.ReportProgress(1, send);
                }

            }
            catch (Exception eo)
            {
                var send = new object[2];
                send[0] = "-1";
                send[1] = "请求服务器错误:" + eo.Message;
                //e.Result = send;
                bgWorker.ReportProgress(1, send);
            }

        }
        /**
         * 导入订单可以指定导入多少次,每次导入20分钟的
         * doTimes导入次数
         * */
        private void doImortTrade1(string start_time, int page, int tradeType, int doTimes, DoWorkEventArgs e, BackgroundWorker bgWorker)
        {

            if (bgWorker.CancellationPending)
            {
                //真正取消进程
                e.Cancel = true;
                return;
            }
            var getUrl = "";
            var tradeTypeStr = "";
            switch (tradeType)
            {
                case 1:
                    getUrl = importUrl + "start_time=" + start_time + "&order_query_type=create_time&page_no=" + page + "&acc=" + acc + "&span=1200";//订单创建
                    tradeTypeStr = "创建订单";
                    break;
                case 2:
                    getUrl = importUrl + "start_time=" + start_time + "&order_query_type=settle_time&page_no=" + page + "&acc=" + acc + "&span=1200";//计算订单
                    tradeTypeStr = "结算订单";
                    break;
            }
           try
            {
                Console.WriteLine(getUrl);
                string re = HttpRequestHelper.HttpGetRequest(getUrl);
                Console.WriteLine(re);
                ReObject Resault = JsonConvert.DeserializeObject<ReObject>(re);
                string ifEnd = Resault.ifEnd;
                string code = Resault.code;
                if (doTimes >= 0)
                {
                    if (code == "-1")
                    {
                        //报错
                        string result = Resault.data;
                        var send = new object[2];
                        send[0] = code;
                        send[1] = result;
                        //e.Result = send;汇报结束
                        bgWorker.ReportProgress(1, send);
                    }
                    else
                    {
                        if (ifEnd == "1")
                        {
                            doTimes = doTimes - 1;
                            
                            //结束
                            string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ": 共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                            var send = new object[2];
                            send[0] = code;
                            send[1] = result;
                            //e.Result = send;
                            bgWorker.ReportProgress(1, send);
                            //handleResult(code, result);
                            //增加20分钟继续
                            DateTime t1 = Convert.ToDateTime(Resault.startTime);
                            t1 = t1.AddMinutes(20);
                            string t2 = t1.ToString("yyyy-MM-dd HH:mm:00");
                            doImortTrade1(t2, 1, tradeType, doTimes, e, bgWorker);
                        }
                        else
                        {
                            //下一页
                            string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ":  共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                            var send = new object[2];
                            send[0] = code;
                            send[1] = result;
                            //e.Result = send;
                            bgWorker.ReportProgress(1, send);
                            //handleResult(code, result);
                            doImortTrade1(start_time, page + 1, tradeType, doTimes, e, bgWorker);
                        }
                    }
                }
            }
            catch (Exception)
            {
                var send = new object[2];
                send[0] = "-1";
                send[1] = "链接服务器出错";
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
            int lineNum=out_text.GetLineFromCharIndex(out_text.Text.Length) + 1;
            if (lineNum > 200)
            {
                out_text.Text = "";
            }
            if (logAcc == "查看所有")
            {
                out_text.Text = " 账号:" + acc + " " + str + out_text.Text;

            }else if(logAcc == acc)
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
                fsAll = File.OpenWrite("logs/all.log");
                fs = File.OpenWrite(logAdd);
                //设定书写的開始位置为文件的末尾  
                fs.Position = fs.Length;
                fsAll.Position = fsAll.Length;
                //将待写入内容追加到文件末尾  
                fs.Write(bytes, 0, bytes.Length);
                fsAll.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件打开失败{0}", ex.ToString());
            }
            finally
            {
                fs.Close();
                fsAll.Close();
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
        }

    }

}

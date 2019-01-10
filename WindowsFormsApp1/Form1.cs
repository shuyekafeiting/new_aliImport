using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<ACC> doAccList = new List<ACC> {
            
        };//选中账户列表
        private List<Trade> Trades = new List<Trade> { };//新建的trade操作类list
        private string AppName;
        private string Version;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadConf();
            out_text.AutoSize = false;
            out_text.Height = 18;
            paintTable();
        }
        //生成数据获取账户数据
        private DataTable InitDt()
        {
            doAccList.Clear();//清空已有数据
            progressBar1.Value = 0;
            DataTable accData = new DataTable();
            accData.Columns.Add(new DataColumn("status", typeof(string)));
            accData.Columns.Add(new DataColumn("acc", typeof(string)));
            accData.Columns.Add(new DataColumn("num", typeof(int)));
            accData.Columns.Add(new DataColumn("lastTime", typeof(string)));
            accData.Columns.Add(new DataColumn("update", typeof(int)));
            accData.Columns.Add(new DataColumn("insert", typeof(int)));
            accData.Columns.Add(new DataColumn("method", typeof(string)));
            DataRow dr;
            MySQL m = new MySQL("taopid", "fanli_");
            m.ConnectionString = "server=rm-wz951u7s1jvhkz883so.mysql.rds.aliyuncs.com;User Id=www_xfz178;password=XL00Fc@iDSC8NbZH;Database=xfz178_com;Charset=utf8";
            m.Open();
            bool fetch = false; //返回SQL字符串, 并不执行
            string whereSql = "1";
            if (accWord.Text != "")
            {
                whereSql = whereSql + " and tp.nick like '%" + accWord.Text + "%'";
            }
            switch (accOwner.Text.ToString())
            {
                case "全部所有":  break;
                case "公司账号": whereSql = whereSql + " and tp.owner = 0"; break;
                case "会员账号": whereSql = whereSql + " and tp.owner > 0"; break;
            }
            if(checkBox1.CheckState == CheckState.Checked)
            {
                whereSql = whereSql + " and tp.if_ok = 1";
            }
            else
            {
                whereSql = whereSql + " and tp.if_ok = 0";
            }
            int pagenum = Convert.ToInt32(page.Text);
            int pageSize = 50;
            //string sql= (string)m.Alias("tp").Where(whereSql).Field("tp.nick,cc.time0,cc.num0,cc.num1,tp.if_ok").Join("left join fanli_cookie as cc on cc.nick=tp.nick").Distinct(true).FetchSql(fetch).Order("tp.id DESC").Limit((pagenum-1)*pageSize, pageSize).Select();
            //Interaction.InputBox("该程序的最新版本已经发布,手动复制并打开浏览器进行下载?", "下载最新版", sql);
            DataTable dt = (DataTable)m.Alias("tp").Where(whereSql).Field("tp.nick,cc.time0,cc.num0,cc.num1,tp.if_ok,tp.use_method").Join("left join fanli_cookie as cc on cc.nick=tp.nick").Distinct(true).FetchSql(fetch).Order("tp.id ASC").Limit((pagenum-1)*pageSize, pageSize).Select();
            int i = (pagenum-1)*pageSize+1;
            foreach (DataRow item in dt.Rows)
            {
                dr = accData.NewRow();
                dr["num"] = i;
                dr["acc"] = item["nick"];
                dr["status"] = (int)item["if_ok"]==1?"使用":"不使用";
                dr["lastTime"] = item["time0"].ToString()==""?"无": item["time0"];
                dr["update"] = item["num1"].ToString() == "" ? 0 : item["num1"];
                dr["insert"] = item["num0"].ToString() == "" ? 0 : item["num0"];
                switch (item["use_method"])
                {
                    case "first_buy":dr["method"] = "首单购买";break;
                    case "share":dr["method"] = "分享购买";break;
                    case "normal":dr["method"] = "正常购买";break;
                }
                accData.Rows.Add(dr);
                i = i + 1;
            }

            DataTable totalDt = (DataTable)m.Where(whereSql).Field("nick, time, addtime,if_ok").Distinct(true).FetchSql(fetch).Order("id DESC").Select();//总数据计算分页
            int totalNum = totalDt.Rows.Count;
            totalPage.Text = Math.Ceiling(((float)totalNum / pageSize)).ToString();
            return accData;
        }
        //绘制表格
        private void paintTable()
        {
            dataGridView1.Rows.Clear();//清除数据
            DataTable accData = InitDt();
            foreach (DataRow dr in accData.Rows)
            {
                //创建行
                DataGridViewRow drRow1 = new DataGridViewRow();
                drRow1.CreateCells(this.dataGridView1);
                //设置单元格的值
                drRow1.Cells[dataGridView1.Columns["status"].Index].Value = dr["status"];
                drRow1.Cells[dataGridView1.Columns["acc"].Index].Value = dr["acc"];
                drRow1.Cells[dataGridView1.Columns["num"].Index].Value = dr["num"];
                drRow1.Cells[dataGridView1.Columns["lastTime"].Index].Value = dr["lastTime"];
                drRow1.Cells[dataGridView1.Columns["update"].Index].Value = dr["update"];
                drRow1.Cells[dataGridView1.Columns["insert"].Index].Value = dr["insert"];
                drRow1.Cells[dataGridView1.Columns["method"].Index].Value = dr["method"];

                if (dr["status"] == "使用")
                {
                    drRow1.Cells[dataGridView1.Columns["status"].Index].Style.ForeColor = Color.Green;
                }
                else
                {
                    drRow1.Cells[dataGridView1.Columns["status"].Index].Style.ForeColor = Color.Red;
                }
                
                drRow1.Cells[dataGridView1.Columns["status"].Index].Style.Font = new Font("宋体", 9, FontStyle.Bold); ;
                //将新创建的行添加到DataGridView中
                this.dataGridView1.Rows.Add(drRow1);
            }
            try
            {
                dataGridView1.Rows[0].Selected = false;
            }catch(Exception ee)
            {

            }
            
        }

        //单行点击事件
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex; //获取当前列的索引
            //开始导单按钮
            if (CIndex == dataGridView1.Columns["action"].Index)
            {

                int row = dataGridView1.Rows.Count;//得到总行数 
                int total = doAccList.Count();
                doAccList.RemoveRange(0, total);
                for (int i = 0; i < row; i++)//得到总行数并在之内循环  
                {
                   dataGridView1.Rows[i].Cells[dataGridView1.Columns["choose"].Index].Value = null;
                }

                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["choose"].Index].Value = true;
                ACC acc = new ACC();
                acc.id = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["num"].Index].Value.ToString();
                acc.nick = (string)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["acc"].Index].Value;
                acc.start_time = "2018-12-02 12:00:00";
                doAccList.Clear();
                doAccList.Add(acc);
                beginImport();
            }
            //点击复选按钮的操作
            if (CIndex == dataGridView1.Columns["choose"].Index)
            {
                var ifChecked = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["choose"].Index].Value;
                if (ifChecked is null)
                {
                   
                    //添加导单账户
                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["choose"].Index].Value = true;
                    ACC acc = new ACC();
                    acc.id = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["num"].Index].Value.ToString();
                    acc.nick = (string)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["acc"].Index].Value;
                    acc.start_time = "2018-12-02 12:00:00";
                    doAccList.Add(acc);
                }
                else
                {

                    ACC acc = new ACC();
                    string num = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["num"].Index].Value.ToString();
                    acc = doAccList.Where(aa => aa.id == num).FirstOrDefault();
                    doAccList.Remove(acc);
                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["choose"].Index].Value = null; 
                }

            }
        }
        //账户类
        public class ACC
        {
            public string id { get; set; }
            public string nick { get; set; }
            public string start_time { get; set; }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
        //开始导单
        private void button1_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value == 0 || progressBar1.Value==progressBar1.Maximum)
            {
                beginImport();
                button1.Text = "停止";
            }
            else
            {
                Trades.ForEach(delegate (Trade value)
                {
                    value.Cancel_import();
                });
                button1.Text = "停止中.";
                button1.Font= new Font("宋体",10);
                
            }
            
        }
        //全选
        private void button5_Click(object sender, EventArgs e)
        {
            //全选
            int row = dataGridView1.Rows.Count;//得到总行数 
            for (int i = 0; i < row; i++)//得到总行数并在之内循环  
            {
                dataGridView1.Rows[i].Cells[dataGridView1.Columns["choose"].Index].Value = true;
                ACC acc = new ACC();
                acc.id = dataGridView1.Rows[i].Cells[dataGridView1.Columns["num"].Index].Value.ToString();
                acc.nick = (string)dataGridView1.Rows[i].Cells[dataGridView1.Columns["acc"].Index].Value;
                acc.start_time = "2018-12-02 12:00:00";
                doAccList.Add(acc);
            }

        }
        //反选
        private void button6_Click(object sender, EventArgs e)
        {
            //反选
            int row = dataGridView1.Rows.Count;//得到总行数 
            int total = doAccList.Count();
            doAccList.RemoveRange(0,total);
            for (int i = 0; i < row; i++)//得到总行数并在之内循环  
            {
                var ifChecked = dataGridView1.Rows[i].Cells[dataGridView1.Columns["choose"].Index].Value;
                if (ifChecked is null)
                {
                    //添加导单账户
                    dataGridView1.Rows[i].Cells[dataGridView1.Columns["choose"].Index].Value = true;
                    ACC acc = new ACC();
                    acc.id = dataGridView1.Rows[i].Cells[dataGridView1.Columns["num"].Index].Value.ToString();
                    acc.nick = (string)dataGridView1.Rows[i].Cells[dataGridView1.Columns["acc"].Index].Value;
                    acc.start_time = "2018-12-02 12:00:00";
                    doAccList.Add(acc);
                }
                else
                {
                    ACC acc = new ACC();
                    string num = dataGridView1.Rows[i].Cells[dataGridView1.Columns["num"].Index].Value.ToString();
                    acc = doAccList.Where(aa => aa.id == num).FirstOrDefault();
                    doAccList.Remove(acc);
                    dataGridView1.Rows[i].Cells[dataGridView1.Columns["choose"].Index].Value = null;
                }
            }
        }
        //搜索按钮
        private void button2_Click(object sender, EventArgs e)
        {
            tabPage.SelectedTab = tabPage1;
            Trades.Clear();
            //清空数据
            page.Text = "1";
            int row = dataGridView1.Rows.Count;//得到总行数 
            int total = doAccList.Count();
            doAccList.RemoveRange(0, total);
            paintTable();
        }

        //定义选定账户列表格式
        private void outPutAccList_DrawItem(object sender, DrawItemEventArgs e)
        {
            RectangleF rf = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(outPutAccList.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }
        //开始导单
        private void beginImport() {
            outPutAccList.Items.Clear();
            outPutAccList.Items.Add("查看所有");//添加选中账户列表

            if (doAccList.Count > 0)
            {

                int totalTimes = 0;
                tabPage.SelectedTab = tabPage2;
                string logStr = " 开始执行...";
                
                doAccList.ForEach(delegate (ACC value)
                {
                    outPutAccList.Items.Add(value.nick);//添加选中账户列表
                    string acc = value.nick;
                    string start_time = DateTimePicker_start.Value.ToString("yyyy-MM-dd HH:00:00");
                    //计算开始和结束时间相差的分钟数
                    DateTime startTime = Convert.ToDateTime(DateTimePicker_start.Value.ToString("yyyy-MM-dd HH:00:00"));
                    DateTime endTime = Convert.ToDateTime(DateTimePicker_end.Value.ToString("yyyy-MM-dd HH:00:00"));
                    TimeSpan ts = endTime - startTime;
                    string days = ts.Days.ToString();
                    string fz = ts.Minutes.ToString();
                    string xs = ts.Hours.ToString();
                    int totalfz = int.Parse(days) * 1440 + int.Parse(xs) * 60 + int.Parse(fz);
                    int times = totalfz / 20;
                    if (times < 0)
                    {
                        MessageBox.Show("时间选择有误");
                        return;
                    }
                    if (times == 0)
                    {
                        totalTimes = totalTimes + 1;
                    }
                    else
                    {
                        totalTimes = totalTimes + 1 + times;
                    }

                    //定义参数,导入创建时间订单 
                    out_text.Visible = true;
                    //导入创建时间订单
                    var send = new object[4];
                    send[0] = start_time;
                    send[1] = 1;//page参数
                    send[2] = 1;//订单类别
                    send[3] = times;//请求次数
                    Trade trade = new Trade(acc,out_text, progressBar1, button1);
                    Trades.Add(trade);
                    trade.beginImportPress(send);
                });
                progressBar1.Value = 0;//进度条归零
                progressBar1.Maximum = totalTimes;//设置进度条总长度
                //开始执行日志
                out_text.Text = logStr;

            }
            else
            {
                MessageBox.Show("请选择账号");
            }
        }
        private void outPutAccList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trade.logAcc = outPutAccList.Text;
        }
        private void progressBar1_ParentChanged(object sender, EventArgs e)
        {
            MessageBox.Show("oh yes");
            if (progressBar1.Value == progressBar1.Maximum)
            {
                progressBar1.BackColor = Color.Gray;
            }
        }
        //上一页
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(page.Text) != 1)
            {
                page.Text = (Convert.ToInt32(page.Text) - 1).ToString();
                paintTable();
            }
            else
            {
                //已经到第一页了

            }
            
        }
        //下一页
        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(page.Text) != Convert.ToInt32(totalPage.Text))
            {
                page.Text = (Convert.ToInt32(page.Text) + 1).ToString();
                paintTable();
            }
            else
            {
                //已经到第一页了

            }
        }
        //加载配置
        private void loadConf() {
            //获取线上版本
            DataTable exeData = new DataTable();
            exeData.Columns.Add(new DataColumn("exe_vesion", typeof(string)));
            exeData.Columns.Add(new DataColumn("exe_url", typeof(string)));
            MySQL m = new MySQL("vesion", "ali_");
            m.ConnectionString = "server=rm-wz9i5dzzu3sz83ko90o.mysql.rds.aliyuncs.com;User Id=xiatian;password=*lrx5X&1&aV33Vr6;Database=jdexe;Charset=utf8";
            m.Open();
            bool fetch = false; //返回SQL字符串, 并不执行
            string whereSql = "1";
            exeData = (DataTable)m.Where(whereSql).Field("exe_vesion,exe_url").Distinct(true).FetchSql(fetch).Order("id DESC").Select();
            //检查线上版本
            string onlineVersion = exeData.Rows[0]["exe_vesion"].ToString();
            string onlineExeurl = exeData.Rows[0]["exe_url"].ToString();
            string localVersion = ConfigHelper.GetAppConfig("Version");
            if(onlineVersion != localVersion)
            {
               //版本不一致处理
               string jg = Interaction.InputBox("该程序的最新版本已经发布,手动复制并打开浏览器进行下载?", "下载最新版", onlineExeurl);
               Application.Exit();
            }
            label_version.Text = "Version_" + localVersion;
            this.Text = ConfigHelper.GetAppConfig("AppName") + "_" + localVersion;
        }
        //用时钟监控，是否所有线程都跑完了
        private void statu_Tick(object sender, EventArgs e)
        {
            int st = 0;
            Trades.ForEach(delegate (Trade value)
            {
                if (value.runStatus != 0) {
                    st = 1;
                }
            });
            if (st == 0)
            {
                button1.Text = "开始";
                progressBar1.Value = 0;
                button1.Font = new Font("宋体", 14);
            }
        }
    }
}

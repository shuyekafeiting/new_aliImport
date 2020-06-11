using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    class TradeCheck
    {
        private string checkDetailUrl;//检查订单区别url
        private string updateTradeUrl;//更新结算订单url
        private string order_sn;
        private string item_id;
        public TradeCheck(string order_sn,string item_id)
        {
            this.checkDetailUrl = ConfigHelper.GetAppConfig("tradetUrl") + "/index/Taobao/checkoutTrade";
            this.updateTradeUrl = ConfigHelper.GetAppConfig("tradetUrl") + "/index/Taobao/foceUpdateTrade";
            this.order_sn = order_sn;
            this.item_id = item_id;
        }
        //查看订单
        public Root getCheckDetail()
        {
            string _url = this.checkDetailUrl + "?trade_id_former=" + this.order_sn+"&item_id="+this.item_id;
            Console.WriteLine(_url);
            string re = HttpRequestHelper.HttpGetRequest(_url);
            Console.WriteLine(re);
            Root Resault = JsonConvert.DeserializeObject<Root>(re);
            return Resault;
        }
        //更新订单
        public Root updateTrade()
        {
            string _url = this.updateTradeUrl + "?trade_id_former=" + this.order_sn + "&item_id=" + this.item_id;
            Console.WriteLine(_url);
            string re = HttpRequestHelper.HttpGetRequest(_url);
            Console.WriteLine(re);
            Root Resault = JsonConvert.DeserializeObject<Root>(re);
            return Resault;
        }
        public class Meta
        {
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 成功
            /// </summary>
            public string msg { get; set; }
        }

        public class LocalTrade
        {
            /// <summary>
            /// 
            /// </summary>
            public string num_iid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pay_price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string real_pay_fee { get; set; }
            /// <summary>
            /// 审核成功
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string commission { get; set; }
        }

        public class OnlineTrade
        {
            /// <summary>
            /// 
            /// </summary>
            public string num_iid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string real_pay_fee { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pay_price { get; set; }
            /// <summary>
            /// 审核成功
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string commission { get; set; }
        }

        public class CheckResults
        {
            /// <summary>
            /// 
            /// </summary>
            public LocalTrade localTrade { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public OnlineTrade onlineTrade { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public bool same { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public Meta meta { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Object results { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string if_end { get; set; }
        }

    }
}

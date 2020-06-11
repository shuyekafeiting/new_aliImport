using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1

{
    public partial class 订单检查 : Form
    {
        private bool ifSame = true;
        private string order_on;
        private string item_id;
        public 订单检查()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order_on = order_snBox.Text;
            item_id = itemId.Text;
            //try
            //{
                TradeCheck tradeCheck = new TradeCheck(order_on, item_id);
                TradeCheck.Root root = tradeCheck.getCheckDetail();
                if (root.meta.code != 200)
                {
                    Messagecs.showMessageBox("error", root.meta.msg);
                }
                else
                {
                    //解析result
                    string result = JsonConvert.SerializeObject(root.results, Formatting.Indented);
                    TradeCheck.CheckResults checkResults = JsonConvert.DeserializeObject<TradeCheck.CheckResults>(result);
                    showDetil(checkResults);
                }
            //}
            //catch (Exception ee)
            //{
              //  Messagecs.showMessageBox("error", ee.Message);
           // }

        }
        //显示查询结果
        private void showDetil(TradeCheck.CheckResults results)
        {
            bool ifGoodsPriceSame = results.localTrade.pay_price == results.onlineTrade.pay_price;
            if (!ifGoodsPriceSame)
            {
                local_goods_price_label.ForeColor = Color.Crimson;
                online_goods_price_label.ForeColor = Color.Crimson;
            }
            bool ifUsernameSame = results.localTrade.uid == results.onlineTrade.uid;
            if (!ifUsernameSame)
            {
                local_username_label.ForeColor = Color.Crimson;
                online_username_label.ForeColor = Color.Crimson;
            }
            bool ifOrderStatusSame = results.localTrade.status == results.onlineTrade.status;
            if (!ifOrderStatusSame)
            {
                local_order_status_label.ForeColor = Color.Crimson;
                online_order_status_label.ForeColor = Color.Crimson;
            }
            bool ifPromotionAmountSame = results.localTrade.real_pay_fee == results.onlineTrade.real_pay_fee;
            if (!ifPromotionAmountSame)
            {
                local_promotion_amount_label.ForeColor = Color.Crimson;
                online_promotion_amount_label.ForeColor = Color.Crimson;
            }
            bool ifOrderAmountSame = results.localTrade.commission == results.onlineTrade.commission;
            if (!ifOrderAmountSame)
            {
                local_order_amount_label.ForeColor = Color.Crimson;
                online_order_amount_label.ForeColor = Color.Crimson;
            }
            //本地数据
            this.local_goods_price_label.Text = results.localTrade.pay_price;
            this.local_username_label.Text = results.localTrade.uid;
            this.local_order_status_label.Text = results.localTrade.status;
            this.local_promotion_amount_label.Text = results.localTrade.real_pay_fee;
            this.local_order_amount_label.Text = results.localTrade.commission;
            //线上数据
            this.online_goods_price_label.Text = results.onlineTrade.pay_price;
            this.online_username_label.Text = results.onlineTrade.uid;
            this.online_order_status_label.Text = results.onlineTrade.status;
            this.online_promotion_amount_label.Text = results.onlineTrade.real_pay_fee;
            this.online_order_amount_label.Text = results.onlineTrade.commission;
            //数据是否相同
            ifSame = results.same;
        }

        //更新订单
        private void button2_Click(object sender, EventArgs e)
        {
            if (ifSame)
            {
                Messagecs.showMessageBox("error", "状态不变不能更新");
                return;
            }
            else
            {
                try
                {
                    TradeCheck tradeCheck = new TradeCheck(order_on,item_id);
                    TradeCheck.Root result = tradeCheck.updateTrade();
                   
                    if (result.meta.code != 200)
                    {
                        Messagecs.showMessageBox("error", result.meta.msg);
                    }
                    else
                    {
                        Messagecs.showMessageBox("ok", "更新成功");
                        ifSame = true;
                    }
                }
                catch (Exception ee)
                {
                    Messagecs.showMessageBox("error", ee.Message);
                }

            }
        }
    
    }

}

namespace WindowsFormsApp1
{
    partial class 订单检查
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(订单检查));
            this.order_snBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.local_order_status_label = new System.Windows.Forms.Label();
            this.local_username_label = new System.Windows.Forms.Label();
            this.local_promotion_amount_label = new System.Windows.Forms.Label();
            this.local_order_amount_label = new System.Windows.Forms.Label();
            this.local_goods_price_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.online_order_status_label = new System.Windows.Forms.Label();
            this.online_username_label = new System.Windows.Forms.Label();
            this.online_promotion_amount_label = new System.Windows.Forms.Label();
            this.online_order_amount_label = new System.Windows.Forms.Label();
            this.online_goods_price_label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.itemId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // order_snBox
            // 
            this.order_snBox.Location = new System.Drawing.Point(98, 26);
            this.order_snBox.Name = "order_snBox";
            this.order_snBox.Size = new System.Drawing.Size(207, 21);
            this.order_snBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "订单号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.local_order_status_label);
            this.groupBox1.Controls.Add(this.local_username_label);
            this.groupBox1.Controls.Add(this.local_promotion_amount_label);
            this.groupBox1.Controls.Add(this.local_order_amount_label);
            this.groupBox1.Controls.Add(this.local_goods_price_label);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(35, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 235);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地数据";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "订单状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "用户id：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "佣金:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "支付金额：";
            // 
            // local_order_status_label
            // 
            this.local_order_status_label.AutoSize = true;
            this.local_order_status_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.local_order_status_label.Location = new System.Drawing.Point(86, 202);
            this.local_order_status_label.Name = "local_order_status_label";
            this.local_order_status_label.Size = new System.Drawing.Size(23, 12);
            this.local_order_status_label.TabIndex = 1;
            this.local_order_status_label.Text = "- -";
            // 
            // local_username_label
            // 
            this.local_username_label.AutoSize = true;
            this.local_username_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.local_username_label.Location = new System.Drawing.Point(74, 161);
            this.local_username_label.Name = "local_username_label";
            this.local_username_label.Size = new System.Drawing.Size(23, 12);
            this.local_username_label.TabIndex = 1;
            this.local_username_label.Text = "- -";
            // 
            // local_promotion_amount_label
            // 
            this.local_promotion_amount_label.AutoSize = true;
            this.local_promotion_amount_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.local_promotion_amount_label.Location = new System.Drawing.Point(57, 120);
            this.local_promotion_amount_label.Name = "local_promotion_amount_label";
            this.local_promotion_amount_label.Size = new System.Drawing.Size(23, 12);
            this.local_promotion_amount_label.TabIndex = 1;
            this.local_promotion_amount_label.Text = "- -";
            // 
            // local_order_amount_label
            // 
            this.local_order_amount_label.AutoSize = true;
            this.local_order_amount_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.local_order_amount_label.Location = new System.Drawing.Point(82, 79);
            this.local_order_amount_label.Name = "local_order_amount_label";
            this.local_order_amount_label.Size = new System.Drawing.Size(23, 12);
            this.local_order_amount_label.TabIndex = 1;
            this.local_order_amount_label.Text = "- -";
            // 
            // local_goods_price_label
            // 
            this.local_goods_price_label.AutoSize = true;
            this.local_goods_price_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.local_goods_price_label.Location = new System.Drawing.Point(68, 38);
            this.local_goods_price_label.Name = "local_goods_price_label";
            this.local_goods_price_label.Size = new System.Drawing.Size(23, 12);
            this.local_goods_price_label.TabIndex = 1;
            this.local_goods_price_label.Text = "- -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "单价：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.online_order_status_label);
            this.groupBox2.Controls.Add(this.online_username_label);
            this.groupBox2.Controls.Add(this.online_promotion_amount_label);
            this.groupBox2.Controls.Add(this.online_order_amount_label);
            this.groupBox2.Controls.Add(this.online_goods_price_label);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(352, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 235);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "线上数据";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "订单状态：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "支付金额：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "用户id：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "单价：";
            // 
            // online_order_status_label
            // 
            this.online_order_status_label.AutoSize = true;
            this.online_order_status_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.online_order_status_label.Location = new System.Drawing.Point(86, 202);
            this.online_order_status_label.Name = "online_order_status_label";
            this.online_order_status_label.Size = new System.Drawing.Size(23, 12);
            this.online_order_status_label.TabIndex = 1;
            this.online_order_status_label.Text = "- -";
            // 
            // online_username_label
            // 
            this.online_username_label.AutoSize = true;
            this.online_username_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.online_username_label.Location = new System.Drawing.Point(74, 161);
            this.online_username_label.Name = "online_username_label";
            this.online_username_label.Size = new System.Drawing.Size(23, 12);
            this.online_username_label.TabIndex = 1;
            this.online_username_label.Text = "- -";
            // 
            // online_promotion_amount_label
            // 
            this.online_promotion_amount_label.AutoSize = true;
            this.online_promotion_amount_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.online_promotion_amount_label.Location = new System.Drawing.Point(57, 120);
            this.online_promotion_amount_label.Name = "online_promotion_amount_label";
            this.online_promotion_amount_label.Size = new System.Drawing.Size(23, 12);
            this.online_promotion_amount_label.TabIndex = 1;
            this.online_promotion_amount_label.Text = "- -";
            // 
            // online_order_amount_label
            // 
            this.online_order_amount_label.AutoSize = true;
            this.online_order_amount_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.online_order_amount_label.Location = new System.Drawing.Point(86, 79);
            this.online_order_amount_label.Name = "online_order_amount_label";
            this.online_order_amount_label.Size = new System.Drawing.Size(23, 12);
            this.online_order_amount_label.TabIndex = 1;
            this.online_order_amount_label.Text = "- -";
            // 
            // online_goods_price_label
            // 
            this.online_goods_price_label.AutoSize = true;
            this.online_goods_price_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.online_goods_price_label.Location = new System.Drawing.Point(66, 38);
            this.online_goods_price_label.Name = "online_goods_price_label";
            this.online_goods_price_label.Size = new System.Drawing.Size(23, 12);
            this.online_goods_price_label.TabIndex = 1;
            this.online_goods_price_label.Text = "- -";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "佣金:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "更新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(436, 341);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "返回";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "商品id：";
            // 
            // itemId
            // 
            this.itemId.Location = new System.Drawing.Point(387, 26);
            this.itemId.Name = "itemId";
            this.itemId.Size = new System.Drawing.Size(100, 21);
            this.itemId.TabIndex = 0;
            // 
            // 订单检查
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 396);
            this.Controls.Add(this.itemId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.order_snBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "订单检查";
            this.Text = "订单检测-爱客宝";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox order_snBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label local_order_status_label;
        private System.Windows.Forms.Label local_username_label;
        private System.Windows.Forms.Label local_promotion_amount_label;
        private System.Windows.Forms.Label local_order_amount_label;
        private System.Windows.Forms.Label local_goods_price_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label online_order_status_label;
        private System.Windows.Forms.Label online_username_label;
        private System.Windows.Forms.Label online_promotion_amount_label;
        private System.Windows.Forms.Label online_order_amount_label;
        private System.Windows.Forms.Label online_goods_price_label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemId;
    }
}
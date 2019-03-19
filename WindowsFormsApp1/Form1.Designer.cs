namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.choose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ifuseing = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.accOwner = new System.Windows.Forms.ComboBox();
            this.accWord = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.page = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.totalPage = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outPutAccList = new System.Windows.Forms.ListBox();
            this.out_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.statu = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlxBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.qulyBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.choose,
            this.num,
            this.acc,
            this.update,
            this.insert,
            this.method,
            this.lastTime,
            this.status,
            this.action});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(808, 365);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // choose
            // 
            this.choose.HeaderText = "选择";
            this.choose.Name = "choose";
            this.choose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.choose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // num
            // 
            this.num.HeaderText = "序号";
            this.num.Name = "num";
            this.num.Width = 60;
            // 
            // acc
            // 
            this.acc.HeaderText = "账户名";
            this.acc.Name = "acc";
            // 
            // update
            // 
            this.update.HeaderText = "更新";
            this.update.Name = "update";
            this.update.Width = 60;
            // 
            // insert
            // 
            this.insert.HeaderText = "插入";
            this.insert.Name = "insert";
            this.insert.Width = 60;
            // 
            // method
            // 
            this.method.HeaderText = "用途 ";
            this.method.Name = "method";
            this.method.Width = 80;
            // 
            // lastTime
            // 
            this.lastTime.HeaderText = "最后更新时间";
            this.lastTime.Name = "lastTime";
            this.lastTime.Width = 160;
            // 
            // status
            // 
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.Width = 90;
            // 
            // action
            // 
            this.action.HeaderText = "操作";
            this.action.Name = "action";
            this.action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.action.Text = "单个导单";
            this.action.UseColumnTextForButtonValue = true;
            this.action.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ifuseing);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.accOwner);
            this.groupBox1.Controls.Add(this.accWord);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选条件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "是否使用";
            // 
            // ifuseing
            // 
            this.ifuseing.FormattingEnabled = true;
            this.ifuseing.Items.AddRange(new object[] {
            "全部所有",
            "正在使用",
            "不在使用"});
            this.ifuseing.Location = new System.Drawing.Point(376, 18);
            this.ifuseing.Name = "ifuseing";
            this.ifuseing.Size = new System.Drawing.Size(78, 20);
            this.ifuseing.TabIndex = 5;
            this.ifuseing.Text = "全部所有";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(480, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "搜";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "关键字";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "账户类型";
            // 
            // accOwner
            // 
            this.accOwner.FormattingEnabled = true;
            this.accOwner.Items.AddRange(new object[] {
            "全部所有",
            "公司账号",
            "会员账号"});
            this.accOwner.Location = new System.Drawing.Point(62, 18);
            this.accOwner.Name = "accOwner";
            this.accOwner.Size = new System.Drawing.Size(78, 20);
            this.accOwner.TabIndex = 1;
            this.accOwner.Text = "全部所有";
            // 
            // accWord
            // 
            this.accWord.Location = new System.Drawing.Point(204, 17);
            this.accWord.Name = "accWord";
            this.accWord.Size = new System.Drawing.Size(110, 21);
            this.accWord.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DateTimePicker_end);
            this.groupBox2.Controls.Add(this.DateTimePicker_start);
            this.groupBox2.Location = new System.Drawing.Point(568, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 118);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择时间";
            // 
            // DateTimePicker_end
            // 
            this.DateTimePicker_end.CustomFormat = "yyyy-MM-dd HH";
            this.DateTimePicker_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_end.Location = new System.Drawing.Point(14, 78);
            this.DateTimePicker_end.Name = "DateTimePicker_end";
            this.DateTimePicker_end.Size = new System.Drawing.Size(120, 21);
            this.DateTimePicker_end.TabIndex = 2;
            // 
            // DateTimePicker_start
            // 
            this.DateTimePicker_start.CustomFormat = " yyyy-MM-dd HH";
            this.DateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_start.Location = new System.Drawing.Point(12, 23);
            this.DateTimePicker_start.Name = "DateTimePicker_start";
            this.DateTimePicker_start.Size = new System.Drawing.Size(121, 21);
            this.DateTimePicker_start.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(730, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(560, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "上一页";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(737, 372);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "下一页";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 553F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_version, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 581);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 26);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Blue;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(44, 5);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(81, 16);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.ParentChanged += new System.EventHandler(this.progressBar1_ParentChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 6, 0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "状态";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_version.Location = new System.Drawing.Point(744, 6);
            this.label_version.Margin = new System.Windows.Forms.Padding(5, 6, 3, 0);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(89, 20);
            this.label_version.TabIndex = 2;
            this.label_version.Text = "Viserion:1.0.1";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(2, 372);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "全选";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(47, 372);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "反选";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Controls.Add(this.tabPage2);
            this.tabPage.Location = new System.Drawing.Point(9, 129);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Drawing.Point(0, 0);
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(822, 424);
            this.tabPage.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(814, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "账户列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel3.Controls.Add(this.page, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.totalPage, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(636, 377);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(98, 22);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // page
            // 
            this.page.AutoSize = true;
            this.page.Dock = System.Windows.Forms.DockStyle.Right;
            this.page.Location = new System.Drawing.Point(26, 0);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(11, 22);
            this.page.TabIndex = 0;
            this.page.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(43, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(5, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "/";
            // 
            // totalPage
            // 
            this.totalPage.AutoSize = true;
            this.totalPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.totalPage.Location = new System.Drawing.Point(54, 0);
            this.totalPage.Name = "totalPage";
            this.totalPage.Size = new System.Drawing.Size(17, 22);
            this.totalPage.TabIndex = 2;
            this.totalPage.Text = "10";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(814, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "运行输出";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08911F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.91089F));
            this.tableLayoutPanel2.Controls.Add(this.outPutAccList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.out_text, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 367F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(808, 392);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // outPutAccList
            // 
            this.outPutAccList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.outPutAccList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outPutAccList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.outPutAccList.Font = new System.Drawing.Font("宋体", 10F);
            this.outPutAccList.FormattingEnabled = true;
            this.outPutAccList.ItemHeight = 15;
            this.outPutAccList.Location = new System.Drawing.Point(3, 28);
            this.outPutAccList.Name = "outPutAccList";
            this.outPutAccList.Size = new System.Drawing.Size(124, 361);
            this.outPutAccList.TabIndex = 0;
            this.outPutAccList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.outPutAccList_DrawItem);
            this.outPutAccList.SelectedIndexChanged += new System.EventHandler(this.outPutAccList_SelectedIndexChanged);
            // 
            // out_text
            // 
            this.out_text.BackColor = System.Drawing.SystemColors.MenuBar;
            this.out_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out_text.Font = new System.Drawing.Font("宋体", 10F);
            this.out_text.ForeColor = System.Drawing.Color.Green;
            this.out_text.Location = new System.Drawing.Point(133, 28);
            this.out_text.Multiline = true;
            this.out_text.Name = "out_text";
            this.out_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.out_text.Size = new System.Drawing.Size(672, 361);
            this.out_text.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 11, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "*选择账户";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 11, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "*运行日志";
            // 
            // statu
            // 
            this.statu.Enabled = true;
            this.statu.Tick += new System.EventHandler(this.statu_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.ddlxBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.qulyBox);
            this.groupBox3.Location = new System.Drawing.Point(9, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 55);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "导入选项";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "订单类型";
            // 
            // ddlxBox
            // 
            this.ddlxBox.FormattingEnabled = true;
            this.ddlxBox.Items.AddRange(new object[] {
            "2方订单",
            "3方订单"});
            this.ddlxBox.Location = new System.Drawing.Point(215, 19);
            this.ddlxBox.Name = "ddlxBox";
            this.ddlxBox.Size = new System.Drawing.Size(78, 20);
            this.ddlxBox.TabIndex = 4;
            this.ddlxBox.Text = "2方订单";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "渠道来源";
            // 
            // qulyBox
            // 
            this.qulyBox.FormattingEnabled = true;
            this.qulyBox.Items.AddRange(new object[] {
            "常规订单",
            "渠道ID",
            "会员ID"});
            this.qulyBox.Location = new System.Drawing.Point(61, 19);
            this.qulyBox.Name = "qulyBox";
            this.qulyBox.Size = new System.Drawing.Size(78, 20);
            this.qulyBox.TabIndex = 2;
            this.qulyBox.Text = "常规订单";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(836, 607);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabPage);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "阿里导单";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox accOwner;
        private System.Windows.Forms.TextBox accWord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker DateTimePicker_end;
        private System.Windows.Forms.DateTimePicker DateTimePicker_start;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox outPutAccList;
        private System.Windows.Forms.TextBox out_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label page;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label totalPage;
        private System.Windows.Forms.Timer statu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn update;
        private System.Windows.Forms.DataGridViewTextBoxColumn insert;
        private System.Windows.Forms.DataGridViewTextBoxColumn method;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn action;
        private System.Windows.Forms.ComboBox ifuseing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox qulyBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlxBox;
        private System.Windows.Forms.Label label8;
    }
}


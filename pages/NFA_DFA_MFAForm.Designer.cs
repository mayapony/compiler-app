namespace CompilerApp.pages
{
    partial class NFA_DFA_MFAForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnValidFormal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFormal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGenMFA = new System.Windows.Forms.Button();
            this.dgMFA = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMFATail = new System.Windows.Forms.Label();
            this.tbMFAHead = new System.Windows.Forms.Label();
            this.gruopBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenNFA = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnOpenNFA = new System.Windows.Forms.Button();
            this.tbNFATail = new System.Windows.Forms.Label();
            this.tbNFAHead = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgNFA = new System.Windows.Forms.DataGridView();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGenDFA = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dgDFA = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOpenDFA = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDFATail = new System.Windows.Forms.Label();
            this.tbDFAHead = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMFA)).BeginInit();
            this.gruopBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNFA)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDFA)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.36364F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnValidFormal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbFormal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表达式";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(637, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnValidFormal
            // 
            this.btnValidFormal.Location = new System.Drawing.Point(556, 12);
            this.btnValidFormal.Name = "btnValidFormal";
            this.btnValidFormal.Size = new System.Drawing.Size(75, 23);
            this.btnValidFormal.TabIndex = 3;
            this.btnValidFormal.Text = "验证正规式";
            this.btnValidFormal.UseVisualStyleBackColor = true;
            this.btnValidFormal.Click += new System.EventHandler(this.btnValidFormal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "例如：(a*|b)*";
            // 
            // tbFormal
            // 
            this.tbFormal.Location = new System.Drawing.Point(120, 14);
            this.tbFormal.Name = "tbFormal";
            this.tbFormal.Size = new System.Drawing.Size(341, 21);
            this.tbFormal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入一个正规式：";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.07681F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.92319F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 317F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.gruopBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 79);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(951, 479);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnGenMFA);
            this.groupBox4.Controls.Add(this.dgMFA);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.tbMFATail);
            this.groupBox4.Controls.Add(this.tbMFAHead);
            this.groupBox4.Location = new System.Drawing.Point(636, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 473);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DFA->MFA";
            // 
            // btnGenMFA
            // 
            this.btnGenMFA.Location = new System.Drawing.Point(7, 415);
            this.btnGenMFA.Name = "btnGenMFA";
            this.btnGenMFA.Size = new System.Drawing.Size(75, 23);
            this.btnGenMFA.TabIndex = 22;
            this.btnGenMFA.Text = "生成MFA文件";
            this.btnGenMFA.UseVisualStyleBackColor = true;
            this.btnGenMFA.Click += new System.EventHandler(this.btnGenMFA_Click);
            // 
            // dgMFA
            // 
            this.dgMFA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMFA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMFA.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgMFA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgMFA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMFA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgMFA.Location = new System.Drawing.Point(6, 20);
            this.dgMFA.Name = "dgMFA";
            this.dgMFA.RowHeadersVisible = false;
            this.dgMFA.RowTemplate.Height = 23;
            this.dgMFA.Size = new System.Drawing.Size(299, 334);
            this.dgMFA.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 366);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 18;
            this.label14.Text = "初始状态集：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 382);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "终止状态集：";
            // 
            // tbMFATail
            // 
            this.tbMFATail.AutoSize = true;
            this.tbMFATail.Location = new System.Drawing.Point(81, 383);
            this.tbMFATail.Name = "tbMFATail";
            this.tbMFATail.Size = new System.Drawing.Size(29, 12);
            this.tbMFATail.TabIndex = 21;
            this.tbMFATail.Text = "暂无";
            // 
            // tbMFAHead
            // 
            this.tbMFAHead.AutoSize = true;
            this.tbMFAHead.Location = new System.Drawing.Point(80, 366);
            this.tbMFAHead.Name = "tbMFAHead";
            this.tbMFAHead.Size = new System.Drawing.Size(29, 12);
            this.tbMFAHead.TabIndex = 20;
            this.tbMFAHead.Text = "暂无";
            // 
            // gruopBox2
            // 
            this.gruopBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gruopBox2.Controls.Add(this.btnGenNFA);
            this.gruopBox2.Controls.Add(this.button4);
            this.gruopBox2.Controls.Add(this.btnOpenNFA);
            this.gruopBox2.Controls.Add(this.tbNFATail);
            this.gruopBox2.Controls.Add(this.tbNFAHead);
            this.gruopBox2.Controls.Add(this.label4);
            this.gruopBox2.Controls.Add(this.label3);
            this.gruopBox2.Controls.Add(this.dgNFA);
            this.gruopBox2.Location = new System.Drawing.Point(3, 3);
            this.gruopBox2.Name = "gruopBox2";
            this.gruopBox2.Size = new System.Drawing.Size(311, 473);
            this.gruopBox2.TabIndex = 0;
            this.gruopBox2.TabStop = false;
            this.gruopBox2.Text = "正规式->NFA";
            // 
            // btnGenNFA
            // 
            this.btnGenNFA.Enabled = false;
            this.btnGenNFA.Location = new System.Drawing.Point(105, 413);
            this.btnGenNFA.Name = "btnGenNFA";
            this.btnGenNFA.Size = new System.Drawing.Size(101, 23);
            this.btnGenNFA.TabIndex = 9;
            this.btnGenNFA.Text = "生成NFA文件";
            this.btnGenNFA.UseVisualStyleBackColor = true;
            this.btnGenNFA.Click += new System.EventHandler(this.btnGenNFA_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnOpenNFA
            // 
            this.btnOpenNFA.Location = new System.Drawing.Point(6, 413);
            this.btnOpenNFA.Name = "btnOpenNFA";
            this.btnOpenNFA.Size = new System.Drawing.Size(93, 23);
            this.btnOpenNFA.TabIndex = 6;
            this.btnOpenNFA.Text = "读入NFA文件";
            this.btnOpenNFA.UseVisualStyleBackColor = true;
            this.btnOpenNFA.Click += new System.EventHandler(this.btnOpenNFA_Click);
            // 
            // tbNFATail
            // 
            this.tbNFATail.AutoSize = true;
            this.tbNFATail.Location = new System.Drawing.Point(78, 383);
            this.tbNFATail.Name = "tbNFATail";
            this.tbNFATail.Size = new System.Drawing.Size(29, 12);
            this.tbNFATail.TabIndex = 5;
            this.tbNFATail.Text = "暂无";
            // 
            // tbNFAHead
            // 
            this.tbNFAHead.AutoSize = true;
            this.tbNFAHead.Location = new System.Drawing.Point(78, 366);
            this.tbNFAHead.Name = "tbNFAHead";
            this.tbNFAHead.Size = new System.Drawing.Size(29, 12);
            this.tbNFAHead.TabIndex = 4;
            this.tbNFAHead.Text = "暂无";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "终止状态集：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "初始状态集：";
            // 
            // dgNFA
            // 
            this.dgNFA.AllowUserToAddRows = false;
            this.dgNFA.AllowUserToDeleteRows = false;
            this.dgNFA.AllowUserToResizeColumns = false;
            this.dgNFA.AllowUserToResizeRows = false;
            this.dgNFA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNFA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNFA.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgNFA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgNFA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNFA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.start,
            this.val,
            this.end});
            this.dgNFA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgNFA.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgNFA.Location = new System.Drawing.Point(6, 20);
            this.dgNFA.MultiSelect = false;
            this.dgNFA.Name = "dgNFA";
            this.dgNFA.ReadOnly = true;
            this.dgNFA.RowHeadersVisible = false;
            this.dgNFA.RowTemplate.Height = 23;
            this.dgNFA.ShowCellErrors = false;
            this.dgNFA.ShowCellToolTips = false;
            this.dgNFA.ShowEditingIcon = false;
            this.dgNFA.ShowRowErrors = false;
            this.dgNFA.Size = new System.Drawing.Size(299, 334);
            this.dgNFA.TabIndex = 1;
            this.dgNFA.TabStop = false;
            // 
            // start
            // 
            this.start.DataPropertyName = "start";
            this.start.HeaderText = "起始状态";
            this.start.Name = "start";
            this.start.ReadOnly = true;
            // 
            // val
            // 
            this.val.DataPropertyName = "val";
            this.val.HeaderText = "接受符号";
            this.val.Name = "val";
            this.val.ReadOnly = true;
            // 
            // end
            // 
            this.end.DataPropertyName = "end";
            this.end.HeaderText = "到达状态";
            this.end.Name = "end";
            this.end.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnGenDFA);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.dgDFA);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnOpenDFA);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbDFATail);
            this.groupBox3.Controls.Add(this.tbDFAHead);
            this.groupBox3.Location = new System.Drawing.Point(320, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 473);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NFA->DFA";
            // 
            // btnGenDFA
            // 
            this.btnGenDFA.Enabled = false;
            this.btnGenDFA.Location = new System.Drawing.Point(104, 415);
            this.btnGenDFA.Name = "btnGenDFA";
            this.btnGenDFA.Size = new System.Drawing.Size(101, 23);
            this.btnGenDFA.TabIndex = 10;
            this.btnGenDFA.Text = "生成DFA文件";
            this.btnGenDFA.UseVisualStyleBackColor = true;
            this.btnGenDFA.Click += new System.EventHandler(this.btnGenDFA_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(211, 415);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "保存";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dgDFA
            // 
            this.dgDFA.AllowUserToAddRows = false;
            this.dgDFA.AllowUserToDeleteRows = false;
            this.dgDFA.AllowUserToResizeColumns = false;
            this.dgDFA.AllowUserToResizeRows = false;
            this.dgDFA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDFA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDFA.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgDFA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgDFA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDFA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgDFA.Location = new System.Drawing.Point(5, 20);
            this.dgDFA.MultiSelect = false;
            this.dgDFA.Name = "dgDFA";
            this.dgDFA.ReadOnly = true;
            this.dgDFA.RowHeadersVisible = false;
            this.dgDFA.RowTemplate.Height = 23;
            this.dgDFA.Size = new System.Drawing.Size(299, 334);
            this.dgDFA.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "start";
            this.dataGridViewTextBoxColumn1.HeaderText = "起始状态";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "val";
            this.dataGridViewTextBoxColumn2.HeaderText = "接受符号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "end";
            this.dataGridViewTextBoxColumn3.HeaderText = "到达状态";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 366);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "初始状态集：";
            // 
            // btnOpenDFA
            // 
            this.btnOpenDFA.Location = new System.Drawing.Point(5, 413);
            this.btnOpenDFA.Name = "btnOpenDFA";
            this.btnOpenDFA.Size = new System.Drawing.Size(93, 23);
            this.btnOpenDFA.TabIndex = 14;
            this.btnOpenDFA.Text = "读入DFA文件";
            this.btnOpenDFA.UseVisualStyleBackColor = true;
            this.btnOpenDFA.Click += new System.EventHandler(this.btnOpenDFA_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "终止状态集：";
            // 
            // tbDFATail
            // 
            this.tbDFATail.AutoSize = true;
            this.tbDFATail.Location = new System.Drawing.Point(81, 383);
            this.tbDFATail.Name = "tbDFATail";
            this.tbDFATail.Size = new System.Drawing.Size(29, 12);
            this.tbDFATail.TabIndex = 13;
            this.tbDFATail.Text = "暂无";
            // 
            // tbDFAHead
            // 
            this.tbDFAHead.AutoSize = true;
            this.tbDFAHead.Location = new System.Drawing.Point(80, 366);
            this.tbDFAHead.Name = "tbDFAHead";
            this.tbDFAHead.Size = new System.Drawing.Size(29, 12);
            this.tbDFAHead.TabIndex = 12;
            this.tbDFAHead.Text = "暂无";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "start";
            this.dataGridViewTextBoxColumn4.HeaderText = "起始状态";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "val";
            this.dataGridViewTextBoxColumn5.HeaderText = "接受符号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "end";
            this.dataGridViewTextBoxColumn6.HeaderText = "到达状态";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // NFA_DFA_MFAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NFA_DFA_MFAForm";
            this.Text = "NFA_DFA_MFAForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMFA)).EndInit();
            this.gruopBox2.ResumeLayout(false);
            this.gruopBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNFA)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDFA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gruopBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnValidFormal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFormal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgNFA;
        private System.Windows.Forms.Label tbNFATail;
        private System.Windows.Forms.Label tbNFAHead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenMFA;
        private System.Windows.Forms.DataGridView dgMFA;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label tbMFATail;
        private System.Windows.Forms.Label tbMFAHead;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnOpenNFA;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dgDFA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOpenDFA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label tbDFATail;
        private System.Windows.Forms.Label tbDFAHead;
        private System.Windows.Forms.Button btnGenNFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn val;
        private System.Windows.Forms.DataGridViewTextBoxColumn end;
        private System.Windows.Forms.Button btnGenDFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
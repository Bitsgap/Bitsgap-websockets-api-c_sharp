namespace TestForm
{
    partial class PublicAPI
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
            this.clbName = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bClear = new System.Windows.Forms.Button();
            this.bUnsubsAll = new System.Windows.Forms.Button();
            this.bSendSubs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.clbType = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPairs = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMarkets = new System.Windows.Forms.ListBox();
            this.tabData = new System.Windows.Forms.TabControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbName
            // 
            this.clbName.FormattingEnabled = true;
            this.clbName.Items.AddRange(new object[] {
            "Market and Pairs",
            "Pairs configuration",
            "Orderbook",
            "Recent trades",
            "Last price",
            "Historical price"});
            this.clbName.Location = new System.Drawing.Point(6, 36);
            this.clbName.Name = "clbName";
            this.clbName.Size = new System.Drawing.Size(133, 94);
            this.clbName.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bClear);
            this.groupBox1.Controls.Add(this.bUnsubsAll);
            this.groupBox1.Controls.Add(this.bSendSubs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.clbType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clbName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 140);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subs";
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(288, 107);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 8;
            this.bClear.Text = "Clear Data";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // bUnsubsAll
            // 
            this.bUnsubsAll.Location = new System.Drawing.Point(288, 65);
            this.bUnsubsAll.Name = "bUnsubsAll";
            this.bUnsubsAll.Size = new System.Drawing.Size(75, 23);
            this.bUnsubsAll.TabIndex = 7;
            this.bUnsubsAll.Text = "Unsubs All";
            this.bUnsubsAll.UseVisualStyleBackColor = true;
            this.bUnsubsAll.Click += new System.EventHandler(this.UnsubsAll_Click);
            // 
            // bSendSubs
            // 
            this.bSendSubs.Location = new System.Drawing.Point(288, 36);
            this.bSendSubs.Name = "bSendSubs";
            this.bSendSubs.Size = new System.Drawing.Size(75, 23);
            this.bSendSubs.TabIndex = 6;
            this.bSendSubs.Text = "Send Subs";
            this.bSendSubs.UseVisualStyleBackColor = true;
            this.bSendSubs.Click += new System.EventHandler(this.SendSubs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subs Type";
            // 
            // clbType
            // 
            this.clbType.FormattingEnabled = true;
            this.clbType.Items.AddRange(new object[] {
            "Only get",
            "Subscribe and get",
            "Subscribe and get next",
            "Unsubscribe",
            "Unsubscribe and get"});
            this.clbType.Location = new System.Drawing.Point(145, 36);
            this.clbType.Name = "clbType";
            this.clbType.Size = new System.Drawing.Size(137, 94);
            this.clbType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Subs Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 161);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbPairs);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbMarkets);
            this.groupBox2.Location = new System.Drawing.Point(390, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 140);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Params";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pairs";
            // 
            // lbPairs
            // 
            this.lbPairs.FormattingEnabled = true;
            this.lbPairs.Location = new System.Drawing.Point(137, 35);
            this.lbPairs.Name = "lbPairs";
            this.lbPairs.Size = new System.Drawing.Size(122, 95);
            this.lbPairs.Sorted = true;
            this.lbPairs.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Markets";
            // 
            // lbMarkets
            // 
            this.lbMarkets.FormattingEnabled = true;
            this.lbMarkets.Location = new System.Drawing.Point(6, 36);
            this.lbMarkets.Name = "lbMarkets";
            this.lbMarkets.Size = new System.Drawing.Size(125, 95);
            this.lbMarkets.Sorted = true;
            this.lbMarkets.TabIndex = 4;
            this.lbMarkets.SelectedValueChanged += new System.EventHandler(this.Markets_SelectedValueChanged);
            // 
            // tabData
            // 
            this.tabData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabData.Location = new System.Drawing.Point(0, 161);
            this.tabData.Name = "tabData";
            this.tabData.SelectedIndex = 0;
            this.tabData.Size = new System.Drawing.Size(800, 289);
            this.tabData.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbMonth);
            this.groupBox3.Controls.Add(this.rbWeek);
            this.groupBox3.Controls.Add(this.rbDay);
            this.groupBox3.Location = new System.Drawing.Point(265, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(68, 114);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Period";
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Checked = true;
            this.rbDay.Location = new System.Drawing.Point(8, 20);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(44, 17);
            this.rbDay.TabIndex = 0;
            this.rbDay.TabStop = true;
            this.rbDay.Text = "Day";
            this.rbDay.UseVisualStyleBackColor = true;
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Location = new System.Drawing.Point(8, 43);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(54, 17);
            this.rbWeek.TabIndex = 1;
            this.rbWeek.Text = "Week";
            this.rbWeek.UseVisualStyleBackColor = true;
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(8, 66);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(55, 17);
            this.rbMonth.TabIndex = 2;
            this.rbMonth.Text = "Month";
            this.rbMonth.UseVisualStyleBackColor = true;
            // 
            // PublicAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabData);
            this.Controls.Add(this.panel1);
            this.Name = "PublicAPI";
            this.Text = "Test Public API";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PublicAPI_FormClosed);
            this.Load += new System.EventHandler(this.PublicAPI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckedListBox clbName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSendSubs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbMarkets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbPairs;
        private System.Windows.Forms.Button bUnsubsAll;
        private System.Windows.Forms.TabControl tabData;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbDay;
    }
}
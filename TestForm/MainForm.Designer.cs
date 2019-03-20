namespace TestForm
{
    partial class MainForm
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
            this.bConnect = new System.Windows.Forms.Button();
            this.clbSocketFlag = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bDisconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrivate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPublic = new System.Windows.Forms.TextBox();
            this.bUserAPI = new System.Windows.Forms.Button();
            this.bPublicAPI = new System.Windows.Forms.Button();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(6, 74);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(75, 23);
            this.bConnect.TabIndex = 0;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // clbSocketFlag
            // 
            this.clbSocketFlag.BackColor = System.Drawing.SystemColors.Control;
            this.clbSocketFlag.Enabled = false;
            this.clbSocketFlag.FormattingEnabled = true;
            this.clbSocketFlag.Items.AddRange(new object[] {
            "Socket Open",
            "Authorization Request",
            "Authorization Success",
            "Authorization Fail",
            "Socket Error"});
            this.clbSocketFlag.Location = new System.Drawing.Point(198, 19);
            this.clbSocketFlag.Name = "clbSocketFlag";
            this.clbSocketFlag.Size = new System.Drawing.Size(168, 79);
            this.clbSocketFlag.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bDisconnect);
            this.groupBox1.Controls.Add(this.clbSocketFlag);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPrivate);
            this.groupBox1.Controls.Add(this.bConnect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPublic);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 107);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "API key";
            // 
            // bDisconnect
            // 
            this.bDisconnect.Location = new System.Drawing.Point(113, 74);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(75, 23);
            this.bDisconnect.TabIndex = 7;
            this.bDisconnect.Text = "Disconnect";
            this.bDisconnect.UseVisualStyleBackColor = true;
            this.bDisconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Private API key";
            // 
            // tbPrivate
            // 
            this.tbPrivate.Location = new System.Drawing.Point(6, 48);
            this.tbPrivate.Name = "tbPrivate";
            this.tbPrivate.Size = new System.Drawing.Size(100, 20);
            this.tbPrivate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Public API key";
            // 
            // tbPublic
            // 
            this.tbPublic.Location = new System.Drawing.Point(6, 21);
            this.tbPublic.Name = "tbPublic";
            this.tbPublic.Size = new System.Drawing.Size(100, 20);
            this.tbPublic.TabIndex = 3;
            // 
            // bUserAPI
            // 
            this.bUserAPI.Location = new System.Drawing.Point(393, 58);
            this.bUserAPI.Name = "bUserAPI";
            this.bUserAPI.Size = new System.Drawing.Size(106, 23);
            this.bUserAPI.TabIndex = 4;
            this.bUserAPI.Text = "Test user API";
            this.bUserAPI.UseVisualStyleBackColor = true;
            this.bUserAPI.Click += new System.EventHandler(this.UserAPI_Click);
            // 
            // bPublicAPI
            // 
            this.bPublicAPI.Location = new System.Drawing.Point(393, 26);
            this.bPublicAPI.Name = "bPublicAPI";
            this.bPublicAPI.Size = new System.Drawing.Size(106, 23);
            this.bPublicAPI.TabIndex = 3;
            this.bPublicAPI.Text = "Test public API";
            this.bPublicAPI.UseVisualStyleBackColor = true;
            this.bPublicAPI.Click += new System.EventHandler(this.PublicAPI_Click);
            // 
            // rtLog
            // 
            this.rtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtLog.Location = new System.Drawing.Point(0, 0);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(800, 321);
            this.rtLog.TabIndex = 3;
            this.rtLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bUserAPI);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.bPublicAPI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 129);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 321);
            this.panel2.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Bitsgap Test WebSocket API";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.CheckedListBox clbSocketFlag;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bDisconnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPrivate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPublic;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bUserAPI;
        private System.Windows.Forms.Button bPublicAPI;
    }
}


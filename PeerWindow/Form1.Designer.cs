namespace PeerWindow
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.EventLogDisplay = new System.Windows.Forms.TextBox();
            this.EventLog = new System.Windows.Forms.Label();
            this.KnownPeers = new System.Windows.Forms.TextBox();
            this.KnownPeersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(481, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Insert music name...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 517);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // EventLogDisplay
            // 
            this.EventLogDisplay.Location = new System.Drawing.Point(616, 76);
            this.EventLogDisplay.Multiline = true;
            this.EventLogDisplay.Name = "EventLogDisplay";
            this.EventLogDisplay.ReadOnly = true;
            this.EventLogDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EventLogDisplay.Size = new System.Drawing.Size(527, 381);
            this.EventLogDisplay.TabIndex = 3;
            // 
            // EventLog
            // 
            this.EventLog.AutoSize = true;
            this.EventLog.Location = new System.Drawing.Point(857, 45);
            this.EventLog.Name = "EventLog";
            this.EventLog.Size = new System.Drawing.Size(56, 13);
            this.EventLog.TabIndex = 4;
            this.EventLog.Text = "Event Log";
            // 
            // KnownPeers
            // 
            this.KnownPeers.Location = new System.Drawing.Point(28, 209);
            this.KnownPeers.Multiline = true;
            this.KnownPeers.Name = "KnownPeers";
            this.KnownPeers.ReadOnly = true;
            this.KnownPeers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KnownPeers.Size = new System.Drawing.Size(481, 248);
            this.KnownPeers.TabIndex = 5;
            // 
            // KnownPeersLabel
            // 
            this.KnownPeersLabel.AutoSize = true;
            this.KnownPeersLabel.Location = new System.Drawing.Point(245, 160);
            this.KnownPeersLabel.Name = "KnownPeersLabel";
            this.KnownPeersLabel.Size = new System.Drawing.Size(70, 13);
            this.KnownPeersLabel.TabIndex = 6;
            this.KnownPeersLabel.Text = "Known Peers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1219, 517);
            this.Controls.Add(this.KnownPeersLabel);
            this.Controls.Add(this.KnownPeers);
            this.Controls.Add(this.EventLog);
            this.Controls.Add(this.EventLogDisplay);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Music Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox EventLogDisplay;
        private System.Windows.Forms.Label EventLog;
        private System.Windows.Forms.TextBox KnownPeers;
        private System.Windows.Forms.Label KnownPeersLabel;
    }
}


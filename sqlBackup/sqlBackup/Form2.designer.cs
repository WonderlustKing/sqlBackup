namespace BackUpDb
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.emailnotcheckBox = new System.Windows.Forms.CheckBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailtextBox = new System.Windows.Forms.TextBox();
            this.SchedulecheckBox = new System.Windows.Forms.CheckBox();
            this.ScheduleLabel = new System.Windows.Forms.Label();
            this.ScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.Runbutton = new System.Windows.Forms.Button();
            this.getBackuplinkLabel = new System.Windows.Forms.LinkLabel();
            this.selectDestLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(572, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConnectionToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newConnectionToolStripMenuItem
            // 
            this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
            this.newConnectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newConnectionToolStripMenuItem.Text = "Change Connection";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logFileToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // logFileToolStripMenuItem
            // 
            this.logFileToolStripMenuItem.Name = "logFileToolStripMenuItem";
            this.logFileToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.logFileToolStripMenuItem.Text = "Log File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect to MySQL Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 142);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(178, 190);
            this.treeView1.TabIndex = 2;
            // 
            // emailnotcheckBox
            // 
            this.emailnotcheckBox.AutoSize = true;
            this.emailnotcheckBox.Location = new System.Drawing.Point(6, 19);
            this.emailnotcheckBox.Name = "emailnotcheckBox";
            this.emailnotcheckBox.Size = new System.Drawing.Size(135, 17);
            this.emailnotcheckBox.TabIndex = 3;
            this.emailnotcheckBox.Text = "Send e-mail notification";
            this.emailnotcheckBox.UseVisualStyleBackColor = true;
            this.emailnotcheckBox.CheckedChanged += new System.EventHandler(this.emailnotcheckBox_CheckedChanged);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Enabled = false;
            this.emailLabel.Location = new System.Drawing.Point(6, 63);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(80, 13);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Send e-mail to :";
            // 
            // emailtextBox
            // 
            this.emailtextBox.Enabled = false;
            this.emailtextBox.Location = new System.Drawing.Point(92, 60);
            this.emailtextBox.Name = "emailtextBox";
            this.emailtextBox.Size = new System.Drawing.Size(143, 20);
            this.emailtextBox.TabIndex = 5;
            // 
            // SchedulecheckBox
            // 
            this.SchedulecheckBox.AutoSize = true;
            this.SchedulecheckBox.Location = new System.Drawing.Point(9, 19);
            this.SchedulecheckBox.Name = "SchedulecheckBox";
            this.SchedulecheckBox.Size = new System.Drawing.Size(71, 17);
            this.SchedulecheckBox.TabIndex = 6;
            this.SchedulecheckBox.Text = "Schedule";
            this.SchedulecheckBox.UseVisualStyleBackColor = true;
            this.SchedulecheckBox.CheckedChanged += new System.EventHandler(this.SchedulecheckBox_CheckedChanged);
            // 
            // ScheduleLabel
            // 
            this.ScheduleLabel.AutoSize = true;
            this.ScheduleLabel.Enabled = false;
            this.ScheduleLabel.Location = new System.Drawing.Point(3, 48);
            this.ScheduleLabel.Name = "ScheduleLabel";
            this.ScheduleLabel.Size = new System.Drawing.Size(110, 13);
            this.ScheduleLabel.TabIndex = 7;
            this.ScheduleLabel.Text = "Start backup daily at :";
            // 
            // ScheduleTime
            // 
            this.ScheduleTime.CustomFormat = "hh:mm tt";
            this.ScheduleTime.Enabled = false;
            this.ScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ScheduleTime.Location = new System.Drawing.Point(132, 48);
            this.ScheduleTime.Name = "ScheduleTime";
            this.ScheduleTime.ShowUpDown = true;
            this.ScheduleTime.Size = new System.Drawing.Size(85, 20);
            this.ScheduleTime.TabIndex = 9;
            this.ScheduleTime.Value = new System.DateTime(2015, 10, 27, 12, 25, 0, 0);
            // 
            // Runbutton
            // 
            this.Runbutton.Location = new System.Drawing.Point(6, 71);
            this.Runbutton.Name = "Runbutton";
            this.Runbutton.Size = new System.Drawing.Size(107, 23);
            this.Runbutton.TabIndex = 10;
            this.Runbutton.Text = "Run";
            this.Runbutton.UseVisualStyleBackColor = true;
            this.Runbutton.Click += new System.EventHandler(this.Runbutton_Click);
            // 
            // getBackuplinkLabel
            // 
            this.getBackuplinkLabel.AutoSize = true;
            this.getBackuplinkLabel.Location = new System.Drawing.Point(13, 344);
            this.getBackuplinkLabel.Name = "getBackuplinkLabel";
            this.getBackuplinkLabel.Size = new System.Drawing.Size(64, 13);
            this.getBackuplinkLabel.TabIndex = 11;
            this.getBackuplinkLabel.TabStop = true;
            this.getBackuplinkLabel.Text = "Get Backup";
            this.getBackuplinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getBackuplinkLabel_LinkClicked);
            // 
            // selectDestLabel
            // 
            this.selectDestLabel.AutoSize = true;
            this.selectDestLabel.Location = new System.Drawing.Point(6, 34);
            this.selectDestLabel.Name = "selectDestLabel";
            this.selectDestLabel.Size = new System.Drawing.Size(117, 13);
            this.selectDestLabel.TabIndex = 12;
            this.selectDestLabel.Text = "Store Backup with FTP";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 77);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Backup Destination";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectDestLabel);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Location = new System.Drawing.Point(281, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.emailnotcheckBox);
            this.groupBox2.Controls.Add(this.emailLabel);
            this.groupBox2.Controls.Add(this.emailtextBox);
            this.groupBox2.Location = new System.Drawing.Point(281, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SchedulecheckBox);
            this.groupBox3.Controls.Add(this.ScheduleLabel);
            this.groupBox3.Controls.Add(this.ScheduleTime);
            this.groupBox3.Controls.Add(this.Runbutton);
            this.groupBox3.Location = new System.Drawing.Point(281, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 100);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 369);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.getBackuplinkLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Control Panel";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox emailnotcheckBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailtextBox;
        private System.Windows.Forms.CheckBox SchedulecheckBox;
        private System.Windows.Forms.Label ScheduleLabel;
        private System.Windows.Forms.DateTimePicker ScheduleTime;
        private System.Windows.Forms.Button Runbutton;
        private System.Windows.Forms.ToolStripMenuItem newConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logFileToolStripMenuItem;
        private System.Windows.Forms.LinkLabel getBackuplinkLabel;
        private System.Windows.Forms.Label selectDestLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

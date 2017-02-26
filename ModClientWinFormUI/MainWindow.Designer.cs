namespace ModClientWinFormUI
{
    partial class MainWindow
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabButton = new System.Windows.Forms.Button();
            this.startTab = new System.Windows.Forms.TabPage();
            this.defaultStartButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.newChatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.startTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(358, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChatToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeTabButton
            // 
            this.closeTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTabButton.Image = global::ModClientWinFormUI.Properties.Resources.cross;
            this.closeTabButton.Location = new System.Drawing.Point(333, 0);
            this.closeTabButton.Name = "closeTabButton";
            this.closeTabButton.Size = new System.Drawing.Size(25, 25);
            this.closeTabButton.TabIndex = 2;
            this.closeTabButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeTabButton.UseVisualStyleBackColor = true;
            this.closeTabButton.Click += new System.EventHandler(this.closeTabButton_Click);
            // 
            // startTab
            // 
            this.startTab.Controls.Add(this.label1);
            this.startTab.Controls.Add(this.pictureBox1);
            this.startTab.Controls.Add(this.defaultStartButton);
            this.startTab.Location = new System.Drawing.Point(4, 22);
            this.startTab.Margin = new System.Windows.Forms.Padding(0);
            this.startTab.Name = "startTab";
            this.startTab.Size = new System.Drawing.Size(350, 163);
            this.startTab.TabIndex = 0;
            this.startTab.Text = "Start";
            this.startTab.UseVisualStyleBackColor = true;
            // 
            // defaultStartButton
            // 
            this.defaultStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultStartButton.Location = new System.Drawing.Point(3, 137);
            this.defaultStartButton.Name = "defaultStartButton";
            this.defaultStartButton.Size = new System.Drawing.Size(344, 23);
            this.defaultStartButton.TabIndex = 0;
            this.defaultStartButton.Text = "New Chat";
            this.defaultStartButton.UseVisualStyleBackColor = true;
            this.defaultStartButton.Click += new System.EventHandler(this.addTab_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.startTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(358, 189);
            this.tabControl1.TabIndex = 1;
            // 
            // newChatMenuItem
            // 
            this.newChatMenuItem.Image = global::ModClientWinFormUI.Properties.Resources.add;
            this.newChatMenuItem.Name = "newChatMenuItem";
            this.newChatMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newChatMenuItem.Text = "New Chat";
            this.newChatMenuItem.Click += new System.EventHandler(this.addTab_Click);
            // 
            // newChatToolStripMenuItem
            // 
            this.newChatToolStripMenuItem.Image = global::ModClientWinFormUI.Properties.Resources.add;
            this.newChatToolStripMenuItem.Name = "newChatToolStripMenuItem";
            this.newChatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newChatToolStripMenuItem.Text = "New Chat";
            this.newChatToolStripMenuItem.Click += new System.EventHandler(this.addTab_Click);
            // 
            // newChatToolStripMenuItem1
            // 
            this.newChatToolStripMenuItem1.Image = global::ModClientWinFormUI.Properties.Resources.add;
            this.newChatToolStripMenuItem1.Name = "newChatToolStripMenuItem1";
            this.newChatToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.newChatToolStripMenuItem1.Text = "New Chat";
            this.newChatToolStripMenuItem1.Click += new System.EventHandler(this.addTab_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ModClientWinFormUI.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(0, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ModClient v0.1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 216);
            this.Controls.Add(this.closeTabButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(197, 255);
            this.Name = "MainWindow";
            this.Text = "ModClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.startTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newChatMenuItem;
        private System.Windows.Forms.Button closeTabButton;
        private System.Windows.Forms.TabPage startTab;
        private System.Windows.Forms.Button defaultStartButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChatToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}


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
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.startTab = new System.Windows.Forms.TabPage();
            this.defaultStartButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chatView1 = new ModClientWinFormUI.ChatView();
            this.mainMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.startTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(284, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChatMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // newChatMenuItem
            // 
            this.newChatMenuItem.Name = "newChatMenuItem";
            this.newChatMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newChatMenuItem.Text = "New Chat";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.startTab);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 235);
            this.tabControl1.TabIndex = 1;
            // 
            // startTab
            // 
            this.startTab.Controls.Add(this.defaultStartButton);
            this.startTab.Location = new System.Drawing.Point(4, 22);
            this.startTab.Name = "startTab";
            this.startTab.Padding = new System.Windows.Forms.Padding(3);
            this.startTab.Size = new System.Drawing.Size(276, 209);
            this.startTab.TabIndex = 0;
            this.startTab.Text = "Start";
            this.startTab.UseVisualStyleBackColor = true;
            // 
            // defaultStartButton
            // 
            this.defaultStartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.defaultStartButton.Location = new System.Drawing.Point(103, 21);
            this.defaultStartButton.Name = "defaultStartButton";
            this.defaultStartButton.Size = new System.Drawing.Size(75, 23);
            this.defaultStartButton.TabIndex = 0;
            this.defaultStartButton.Text = "New Chat";
            this.defaultStartButton.UseVisualStyleBackColor = true;
            this.defaultStartButton.Click += new System.EventHandler(this.defaultStartButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chatView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 209);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chatView1
            // 
            this.chatView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatView1.Location = new System.Drawing.Point(7, 7);
            this.chatView1.Name = "chatView1";
            this.chatView1.Size = new System.Drawing.Size(261, 193);
            this.chatView1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainWindow";
            this.Text = "-";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.startTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChatMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage startTab;
        private System.Windows.Forms.Button defaultStartButton;
        private System.Windows.Forms.TabPage tabPage1;
        private ChatView chatView1;
    }
}


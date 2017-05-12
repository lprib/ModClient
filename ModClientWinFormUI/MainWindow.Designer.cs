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
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.devChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTab = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.defaultStartButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.closeTabButton = new System.Windows.Forms.Button();
            this.newChatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.startTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(350, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChatToolStripMenuItem1,
            this.devChatToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newChatToolStripMenuItem1
            // 
            this.newChatToolStripMenuItem1.Image = global::ModClientWinFormUI.Properties.Resources.add;
            this.newChatToolStripMenuItem1.Name = "newChatToolStripMenuItem1";
            this.newChatToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.newChatToolStripMenuItem1.Text = "&New Chat...";
            this.newChatToolStripMenuItem1.Click += new System.EventHandler(this.addTab_Click);
            // 
            // devChatToolStripMenuItem
            // 
            this.devChatToolStripMenuItem.Image = global::ModClientWinFormUI.Properties.Resources.bug_add;
            this.devChatToolStripMenuItem.Name = "devChatToolStripMenuItem";
            this.devChatToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.devChatToolStripMenuItem.Text = "&Dev Chat";
            this.devChatToolStripMenuItem.Click += new System.EventHandler(this.devChatToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::ModClientWinFormUI.Properties.Resources.cog;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginManagerToolStripMenuItem,
            this.importToolStripMenuItem});
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pluginsToolStripMenuItem.Text = "&Plugins";
            // 
            // pluginManagerToolStripMenuItem
            // 
            this.pluginManagerToolStripMenuItem.Image = global::ModClientWinFormUI.Properties.Resources.script_edit;
            this.pluginManagerToolStripMenuItem.Name = "pluginManagerToolStripMenuItem";
            this.pluginManagerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.pluginManagerToolStripMenuItem.Text = "&Plugin Manager";
            this.pluginManagerToolStripMenuItem.Click += new System.EventHandler(this.pluginManagerToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::ModClientWinFormUI.Properties.Resources.script_go;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.importToolStripMenuItem.Text = "&Import...";
            // 
            // startTab
            // 
            this.startTab.Controls.Add(this.linkLabel1);
            this.startTab.Controls.Add(this.label1);
            this.startTab.Controls.Add(this.pictureBox1);
            this.startTab.Controls.Add(this.defaultStartButton);
            this.startTab.Location = new System.Drawing.Point(4, 22);
            this.startTab.Margin = new System.Windows.Forms.Padding(0);
            this.startTab.Name = "startTab";
            this.startTab.Size = new System.Drawing.Size(342, 214);
            this.startTab.TabIndex = 0;
            this.startTab.Text = "Start";
            this.startTab.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Location = new System.Drawing.Point(3, 168);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkLabel1.Size = new System.Drawing.Size(336, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Github";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(0, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ModClient v0.1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ModClientWinFormUI.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // defaultStartButton
            // 
            this.defaultStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultStartButton.Image = global::ModClientWinFormUI.Properties.Resources.add;
            this.defaultStartButton.Location = new System.Drawing.Point(3, 188);
            this.defaultStartButton.Name = "defaultStartButton";
            this.defaultStartButton.Size = new System.Drawing.Size(336, 23);
            this.defaultStartButton.TabIndex = 0;
            this.defaultStartButton.Text = "New Chat";
            this.defaultStartButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.defaultStartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.tabControl1.Size = new System.Drawing.Size(350, 240);
            this.tabControl1.TabIndex = 1;
            // 
            // closeTabButton
            // 
            this.closeTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTabButton.Image = global::ModClientWinFormUI.Properties.Resources.cancel;
            this.closeTabButton.Location = new System.Drawing.Point(325, 0);
            this.closeTabButton.Name = "closeTabButton";
            this.closeTabButton.Size = new System.Drawing.Size(25, 25);
            this.closeTabButton.TabIndex = 2;
            this.closeTabToolTip.SetToolTip(this.closeTabButton, "Close Tab");
            this.closeTabButton.UseVisualStyleBackColor = true;
            this.closeTabButton.Click += new System.EventHandler(this.closeTabButton_Click);
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 267);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newChatMenuItem;
        private System.Windows.Forms.TabPage startTab;
        private System.Windows.Forms.Button defaultStartButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChatToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem devChatToolStripMenuItem;
        private System.Windows.Forms.Button closeTabButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolTip closeTabToolTip;
    }
}


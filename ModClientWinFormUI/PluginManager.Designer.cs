namespace ModClientWinFormUI
{
    partial class PluginManager
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
            this.activePluginsList = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.newPluginComboBox = new System.Windows.Forms.ComboBox();
            this.pluginOptionsPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.removePluginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // activePluginsList
            // 
            this.activePluginsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.activePluginsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activePluginsList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.activePluginsList.Location = new System.Drawing.Point(13, 25);
            this.activePluginsList.Name = "activePluginsList";
            this.activePluginsList.Size = new System.Drawing.Size(307, 280);
            this.activePluginsList.TabIndex = 0;
            this.activePluginsList.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Plugins";
            // 
            // newPluginComboBox
            // 
            this.newPluginComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newPluginComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newPluginComboBox.FormattingEnabled = true;
            this.newPluginComboBox.Location = new System.Drawing.Point(76, 320);
            this.newPluginComboBox.Name = "newPluginComboBox";
            this.newPluginComboBox.Size = new System.Drawing.Size(164, 21);
            this.newPluginComboBox.TabIndex = 4;
            // 
            // pluginOptionsPanel
            // 
            this.pluginOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginOptionsPanel.Location = new System.Drawing.Point(326, 25);
            this.pluginOptionsPanel.Name = "pluginOptionsPanel";
            this.pluginOptionsPanel.Size = new System.Drawing.Size(367, 323);
            this.pluginOptionsPanel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add Plugin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Plugin Options";
            // 
            // removePluginButton
            // 
            this.removePluginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removePluginButton.Image = global::ModClientWinFormUI.Properties.Resources.script_delete;
            this.removePluginButton.Location = new System.Drawing.Point(246, 315);
            this.removePluginButton.Name = "removePluginButton";
            this.removePluginButton.Size = new System.Drawing.Size(74, 28);
            this.removePluginButton.TabIndex = 2;
            this.removePluginButton.Text = "Remove";
            this.removePluginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.removePluginButton.UseVisualStyleBackColor = true;
            this.removePluginButton.Click += new System.EventHandler(this.removePluginButton_Click);
            // 
            // PluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 360);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pluginOptionsPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPluginComboBox);
            this.Controls.Add(this.removePluginButton);
            this.Controls.Add(this.activePluginsList);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(490, 324);
            this.Name = "PluginManager";
            this.Text = "OldPlugin Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel activePluginsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removePluginButton;
        private System.Windows.Forms.ComboBox newPluginComboBox;
        private System.Windows.Forms.Panel pluginOptionsPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
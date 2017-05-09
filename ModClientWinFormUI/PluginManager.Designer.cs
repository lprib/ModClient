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
            this.pluginListView = new System.Windows.Forms.ListView();
            this.removePluginButton = new System.Windows.Forms.Button();
            this.pluginOptions = new System.Windows.Forms.TableLayoutPanel();
            this.saveOptionsButton = new System.Windows.Forms.Button();
            this.addPluginSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // pluginListView
            // 
            this.pluginListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginListView.Location = new System.Drawing.Point(13, 13);
            this.pluginListView.Name = "pluginListView";
            this.pluginListView.Size = new System.Drawing.Size(346, 164);
            this.pluginListView.TabIndex = 0;
            this.pluginListView.UseCompatibleStateImageBehavior = false;
            // 
            // removePluginButton
            // 
            this.removePluginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removePluginButton.Image = global::ModClientWinFormUI.Properties.Resources.cancel;
            this.removePluginButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.removePluginButton.Location = new System.Drawing.Point(365, 42);
            this.removePluginButton.Name = "removePluginButton";
            this.removePluginButton.Size = new System.Drawing.Size(258, 23);
            this.removePluginButton.TabIndex = 2;
            this.removePluginButton.Text = "Remove";
            this.removePluginButton.UseVisualStyleBackColor = true;
            // 
            // pluginOptions
            // 
            this.pluginOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginOptions.ColumnCount = 2;
            this.pluginOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pluginOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pluginOptions.Location = new System.Drawing.Point(13, 184);
            this.pluginOptions.Name = "pluginOptions";
            this.pluginOptions.RowCount = 1;
            this.pluginOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pluginOptions.Size = new System.Drawing.Size(610, 146);
            this.pluginOptions.TabIndex = 3;
            // 
            // saveOptionsButton
            // 
            this.saveOptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveOptionsButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.saveOptionsButton.Location = new System.Drawing.Point(13, 336);
            this.saveOptionsButton.Name = "saveOptionsButton";
            this.saveOptionsButton.Size = new System.Drawing.Size(610, 23);
            this.saveOptionsButton.TabIndex = 4;
            this.saveOptionsButton.Text = "Done";
            this.saveOptionsButton.UseVisualStyleBackColor = true;
            this.saveOptionsButton.Click += new System.EventHandler(this.saveOptionsButton_Click);
            // 
            // addPluginSelect
            // 
            this.addPluginSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPluginSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addPluginSelect.FormattingEnabled = true;
            this.addPluginSelect.Location = new System.Drawing.Point(365, 15);
            this.addPluginSelect.Name = "addPluginSelect";
            this.addPluginSelect.Size = new System.Drawing.Size(257, 21);
            this.addPluginSelect.TabIndex = 5;
            // 
            // PluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 371);
            this.Controls.Add(this.addPluginSelect);
            this.Controls.Add(this.saveOptionsButton);
            this.Controls.Add(this.pluginOptions);
            this.Controls.Add(this.removePluginButton);
            this.Controls.Add(this.pluginListView);
            this.Name = "PluginManager";
            this.Text = "PluginManager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView pluginListView;
        private System.Windows.Forms.Button removePluginButton;
        private System.Windows.Forms.TableLayoutPanel pluginOptions;
        private System.Windows.Forms.Button saveOptionsButton;
        private System.Windows.Forms.ComboBox addPluginSelect;
    }
}
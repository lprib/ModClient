namespace ModClientWinFormUI
{
    partial class Username
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameDisplay = new System.Windows.Forms.TextBox();
            this.tripDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usernameDisplay
            // 
            this.usernameDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameDisplay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.usernameDisplay.Location = new System.Drawing.Point(79, 3);
            this.usernameDisplay.Name = "usernameDisplay";
            this.usernameDisplay.ReadOnly = true;
            this.usernameDisplay.Size = new System.Drawing.Size(68, 13);
            this.usernameDisplay.TabIndex = 0;
            this.usernameDisplay.Text = "Username";
            // 
            // tripDisplay
            // 
            this.tripDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tripDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tripDisplay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tripDisplay.Location = new System.Drawing.Point(5, 3);
            this.tripDisplay.Name = "tripDisplay";
            this.tripDisplay.ReadOnly = true;
            this.tripDisplay.Size = new System.Drawing.Size(68, 13);
            this.tripDisplay.TabIndex = 1;
            this.tripDisplay.Text = "Trip";
            // 
            // Username
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tripDisplay);
            this.Controls.Add(this.usernameDisplay);
            this.Name = "Username";
            this.Size = new System.Drawing.Size(150, 236);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameDisplay;
        private System.Windows.Forms.TextBox tripDisplay;
    }
}

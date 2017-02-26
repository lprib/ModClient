namespace ModClientWinFormUI
{
    partial class ChatView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatView));
            this.messageInputBox = new System.Windows.Forms.TextBox();
            this.chatBox = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chatBox)).BeginInit();
            this.SuspendLayout();
            // 
            // messageInputBox
            // 
            this.messageInputBox.AcceptsReturn = true;
            this.messageInputBox.AllowDrop = true;
            this.messageInputBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.messageInputBox.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageInputBox.Location = new System.Drawing.Point(0, 378);
            this.messageInputBox.Margin = new System.Windows.Forms.Padding(0);
            this.messageInputBox.Multiline = true;
            this.messageInputBox.Name = "messageInputBox";
            this.messageInputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageInputBox.Size = new System.Drawing.Size(626, 64);
            this.messageInputBox.TabIndex = 0;
            this.messageInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageInputBox_KeyDown);
            // 
            // chatBox
            // 
            this.chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.chatBox.AutoScrollMinSize = new System.Drawing.Size(0, 19);
            this.chatBox.BackBrush = null;
            this.chatBox.CaretVisible = false;
            this.chatBox.CharHeight = 19;
            this.chatBox.CharWidth = 9;
            this.chatBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.chatBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.chatBox.Font = new System.Drawing.Font("Everson Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBox.IsReplaceMode = false;
            this.chatBox.Location = new System.Drawing.Point(0, 0);
            this.chatBox.Name = "chatBox";
            this.chatBox.Paddings = new System.Windows.Forms.Padding(0);
            this.chatBox.ReadOnly = true;
            this.chatBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.chatBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("chatBox.ServiceColors")));
            this.chatBox.ShowLineNumbers = false;
            this.chatBox.Size = new System.Drawing.Size(626, 375);
            this.chatBox.TabIndex = 1;
            this.chatBox.WordWrap = true;
            this.chatBox.WordWrapIndent = 4;
            this.chatBox.Zoom = 100;
            // 
            // ChatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.messageInputBox);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ChatView";
            this.Size = new System.Drawing.Size(626, 442);
            ((System.ComponentModel.ISupportInitialize)(this.chatBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageInputBox;
        private FastColoredTextBoxNS.FastColoredTextBox chatBox;
    }
}

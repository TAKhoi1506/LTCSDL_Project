namespace BloodBankManagement.Donor
{
    partial class UC_Notifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Notifications));
            this.lbTitle = new Bunifu.UI.WinForms.BunifuLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewMessage = new System.Windows.Forms.ListView();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.MessageContent = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AllowParentOverrides = false;
            this.lbTitle.AutoEllipsis = false;
            this.lbTitle.AutoSize = false;
            this.lbTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTitle.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F);
            this.lbTitle.Location = new System.Drawing.Point(496, 56);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbTitle.Size = new System.Drawing.Size(612, 62);
            this.lbTitle.TabIndex = 48;
            this.lbTitle.Text = "Notifications";
            this.lbTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(133, 217);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewMessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MessageContent);
            this.splitContainer1.Size = new System.Drawing.Size(1330, 665);
            this.splitContainer1.SplitterDistance = 443;
            this.splitContainer1.TabIndex = 54;
            // 
            // listViewMessage
            // 
            this.listViewMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMessage.HideSelection = false;
            this.listViewMessage.Location = new System.Drawing.Point(0, 0);
            this.listViewMessage.Name = "listViewMessage";
            this.listViewMessage.Size = new System.Drawing.Size(443, 665);
            this.listViewMessage.TabIndex = 0;
            this.listViewMessage.UseCompatibleStateImageBehavior = false;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuLabel3.Location = new System.Drawing.Point(133, 164);
            this.bunifuLabel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(205, 34);
            this.bunifuLabel3.TabIndex = 18;
            this.bunifuLabel3.Text = "List Messages";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // MessageContent
            // 
            this.MessageContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageContent.Location = new System.Drawing.Point(0, 0);
            this.MessageContent.Name = "MessageContent";
            this.MessageContent.Size = new System.Drawing.Size(883, 665);
            this.MessageContent.TabIndex = 0;
            this.MessageContent.Text = "";
            // 
            // UC_Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbTitle);
            this.Name = "UC_Notifications";
            this.Size = new System.Drawing.Size(1587, 911);
            this.Load += new System.EventHandler(this.UC_Notifications_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel lbTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewMessage;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private System.Windows.Forms.RichTextBox MessageContent;
    }
}

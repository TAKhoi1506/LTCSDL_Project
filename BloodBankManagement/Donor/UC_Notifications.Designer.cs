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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewMessage = new System.Windows.Forms.ListView();
            this.MessageContent = new System.Windows.Forms.RichTextBox();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.btRefresh = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bunifuLabel19 = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.splitContainer1.Location = new System.Drawing.Point(163, 271);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewMessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MessageContent);
            this.splitContainer1.Size = new System.Drawing.Size(1787, 1154);
            this.splitContainer1.SplitterDistance = 595;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 54;
            // 
            // listViewMessage
            // 
            this.listViewMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMessage.HideSelection = false;
            this.listViewMessage.Location = new System.Drawing.Point(0, 0);
            this.listViewMessage.Margin = new System.Windows.Forms.Padding(4);
            this.listViewMessage.Name = "listViewMessage";
            this.listViewMessage.Size = new System.Drawing.Size(595, 1154);
            this.listViewMessage.TabIndex = 0;
            this.listViewMessage.UseCompatibleStateImageBehavior = false;
            this.listViewMessage.SelectedIndexChanged += new System.EventHandler(this.ListViewMessages_SelectedIndexChanged);
            // 
            // MessageContent
            // 
            this.MessageContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageContent.Location = new System.Drawing.Point(0, 0);
            this.MessageContent.Margin = new System.Windows.Forms.Padding(4);
            this.MessageContent.Name = "MessageContent";
            this.MessageContent.Size = new System.Drawing.Size(1187, 1154);
            this.MessageContent.TabIndex = 0;
            this.MessageContent.Text = "";
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuLabel3.Location = new System.Drawing.Point(177, 205);
            this.bunifuLabel3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(269, 46);
            this.bunifuLabel3.TabIndex = 18;
            this.bunifuLabel3.Text = "List Messages";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btRefresh
            // 
            this.btRefresh.AllowAnimations = true;
            this.btRefresh.AllowMouseEffects = true;
            this.btRefresh.AllowToggling = false;
            this.btRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btRefresh.AnimationSpeed = 200;
            this.btRefresh.AutoGenerateColors = false;
            this.btRefresh.AutoRoundBorders = false;
            this.btRefresh.AutoSizeLeftIcon = true;
            this.btRefresh.AutoSizeRightIcon = true;
            this.btRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btRefresh.BackColor1 = System.Drawing.Color.Azure;
            this.btRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btRefresh.BackgroundImage")));
            this.btRefresh.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.ButtonText = "Refresh";
            this.btRefresh.ButtonTextMarginLeft = 0;
            this.btRefresh.ColorContrastOnClick = 45;
            this.btRefresh.ColorContrastOnHover = 45;
            this.btRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btRefresh.CustomizableEdges = borderEdges1;
            this.btRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btRefresh.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btRefresh.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btRefresh.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btRefresh.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btRefresh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.Black;
            this.btRefresh.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btRefresh.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btRefresh.IconMarginLeft = 11;
            this.btRefresh.IconPadding = 10;
            this.btRefresh.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRefresh.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btRefresh.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btRefresh.IconSize = 25;
            this.btRefresh.IdleBorderColor = System.Drawing.Color.White;
            this.btRefresh.IdleBorderRadius = 1;
            this.btRefresh.IdleBorderThickness = 1;
            this.btRefresh.IdleFillColor = System.Drawing.Color.Azure;
            this.btRefresh.IdleIconLeftImage = null;
            this.btRefresh.IdleIconRightImage = null;
            this.btRefresh.IndicateFocus = false;
            this.btRefresh.Location = new System.Drawing.Point(1751, 199);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btRefresh.OnDisabledState.BorderRadius = 1;
            this.btRefresh.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.OnDisabledState.BorderThickness = 1;
            this.btRefresh.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btRefresh.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btRefresh.OnDisabledState.IconLeftImage = null;
            this.btRefresh.OnDisabledState.IconRightImage = null;
            this.btRefresh.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btRefresh.onHoverState.BorderRadius = 1;
            this.btRefresh.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.onHoverState.BorderThickness = 1;
            this.btRefresh.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btRefresh.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btRefresh.onHoverState.IconLeftImage = null;
            this.btRefresh.onHoverState.IconRightImage = null;
            this.btRefresh.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.btRefresh.OnIdleState.BorderRadius = 1;
            this.btRefresh.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.OnIdleState.BorderThickness = 1;
            this.btRefresh.OnIdleState.FillColor = System.Drawing.Color.Azure;
            this.btRefresh.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btRefresh.OnIdleState.IconLeftImage = null;
            this.btRefresh.OnIdleState.IconRightImage = null;
            this.btRefresh.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btRefresh.OnPressedState.BorderRadius = 1;
            this.btRefresh.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.OnPressedState.BorderThickness = 1;
            this.btRefresh.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btRefresh.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btRefresh.OnPressedState.IconLeftImage = null;
            this.btRefresh.OnPressedState.IconRightImage = null;
            this.btRefresh.Size = new System.Drawing.Size(200, 49);
            this.btRefresh.TabIndex = 55;
            this.btRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btRefresh.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btRefresh.TextMarginLeft = 0;
            this.btRefresh.TextPadding = new System.Windows.Forms.Padding(0);
            this.btRefresh.UseDefaultRadiusAndThickness = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // bunifuLabel19
            // 
            this.bunifuLabel19.AllowParentOverrides = false;
            this.bunifuLabel19.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuLabel19.AutoEllipsis = false;
            this.bunifuLabel19.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel19.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22.125F);
            this.bunifuLabel19.Location = new System.Drawing.Point(876, 97);
            this.bunifuLabel19.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuLabel19.Name = "bunifuLabel19";
            this.bunifuLabel19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel19.Size = new System.Drawing.Size(365, 68);
            this.bunifuLabel19.TabIndex = 86;
            this.bunifuLabel19.Text = "Notifications";
            this.bunifuLabel19.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel19.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // UC_Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuLabel19);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Notifications";
            this.Size = new System.Drawing.Size(2116, 1500);
            this.Load += new System.EventHandler(this.UC_Notifications_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewMessage;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private System.Windows.Forms.RichTextBox MessageContent;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btRefresh;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel19;
    }
}

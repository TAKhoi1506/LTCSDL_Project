namespace BloodBankManagement.Admin
{
    partial class UC_SendEmail
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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_SendEmail));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewMessage = new System.Windows.Forms.ListView();
            this.lbTitle = new Bunifu.UI.WinForms.BunifuLabel();
            this.btRefresh = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.lbList = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtTitle = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.btSend = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtEmail = new Bunifu.UI.WinForms.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.splitContainer1.Location = new System.Drawing.Point(108, 231);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewMessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtMessage);
            this.splitContainer1.Panel2.Controls.Add(this.txtTitle);
            this.splitContainer1.Size = new System.Drawing.Size(1340, 801);
            this.splitContainer1.SplitterDistance = 446;
            this.splitContainer1.TabIndex = 88;
            // 
            // listViewMessage
            // 
            this.listViewMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMessage.HideSelection = false;
            this.listViewMessage.Location = new System.Drawing.Point(0, 0);
            this.listViewMessage.Name = "listViewMessage";
            this.listViewMessage.Size = new System.Drawing.Size(446, 801);
            this.listViewMessage.TabIndex = 0;
            this.listViewMessage.UseCompatibleStateImageBehavior = false;
            this.listViewMessage.SelectedIndexChanged += new System.EventHandler(this.listViewMessage_SelectedIndexChanged);
            // 
            // lbTitle
            // 
            this.lbTitle.AllowParentOverrides = false;
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.AutoEllipsis = false;
            this.lbTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTitle.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22.125F);
            this.lbTitle.Location = new System.Drawing.Point(657, 69);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbTitle.Size = new System.Drawing.Size(300, 51);
            this.lbTitle.TabIndex = 90;
            this.lbTitle.Text = "Sent Message";
            this.lbTitle.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lbTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
            this.btRefresh.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
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
            this.btRefresh.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.btRefresh.IdleBorderRadius = 20;
            this.btRefresh.IdleBorderThickness = 1;
            this.btRefresh.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.btRefresh.IdleIconLeftImage = null;
            this.btRefresh.IdleIconRightImage = null;
            this.btRefresh.IndicateFocus = false;
            this.btRefresh.Location = new System.Drawing.Point(1270, 130);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btRefresh.OnDisabledState.BorderRadius = 20;
            this.btRefresh.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.OnDisabledState.BorderThickness = 1;
            this.btRefresh.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btRefresh.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btRefresh.OnDisabledState.IconLeftImage = null;
            this.btRefresh.OnDisabledState.IconRightImage = null;
            this.btRefresh.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btRefresh.onHoverState.BorderRadius = 20;
            this.btRefresh.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.onHoverState.BorderThickness = 1;
            this.btRefresh.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btRefresh.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btRefresh.onHoverState.IconLeftImage = null;
            this.btRefresh.onHoverState.IconRightImage = null;
            this.btRefresh.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.btRefresh.OnIdleState.BorderRadius = 20;
            this.btRefresh.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.OnIdleState.BorderThickness = 1;
            this.btRefresh.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.btRefresh.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btRefresh.OnIdleState.IconLeftImage = null;
            this.btRefresh.OnIdleState.IconRightImage = null;
            this.btRefresh.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btRefresh.OnPressedState.BorderRadius = 20;
            this.btRefresh.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btRefresh.OnPressedState.BorderThickness = 1;
            this.btRefresh.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btRefresh.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btRefresh.OnPressedState.IconLeftImage = null;
            this.btRefresh.OnPressedState.IconRightImage = null;
            this.btRefresh.Size = new System.Drawing.Size(194, 59);
            this.btRefresh.TabIndex = 89;
            this.btRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btRefresh.TextMarginLeft = 0;
            this.btRefresh.TextPadding = new System.Windows.Forms.Padding(0);
            this.btRefresh.UseDefaultRadiusAndThickness = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // lbList
            // 
            this.lbList.AllowParentOverrides = false;
            this.lbList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbList.AutoEllipsis = false;
            this.lbList.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbList.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbList.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbList.Location = new System.Drawing.Point(133, 155);
            this.lbList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbList.Name = "lbList";
            this.lbList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbList.Size = new System.Drawing.Size(146, 34);
            this.lbList.TabIndex = 87;
            this.lbList.Text = "List Users";
            this.lbList.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lbList.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtTitle
            // 
            this.txtTitle.AcceptsReturn = false;
            this.txtTitle.AcceptsTab = false;
            this.txtTitle.AnimationSpeed = 200;
            this.txtTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTitle.AutoSizeHeight = true;
            this.txtTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTitle.BackgroundImage")));
            this.txtTitle.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtTitle.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtTitle.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtTitle.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtTitle.BorderRadius = 1;
            this.txtTitle.BorderThickness = 1;
            this.txtTitle.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.DefaultText = "";
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.FillColor = System.Drawing.Color.White;
            this.txtTitle.HideSelection = true;
            this.txtTitle.IconLeft = null;
            this.txtTitle.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.IconPadding = 10;
            this.txtTitle.IconRight = null;
            this.txtTitle.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.Lines = new string[0];
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.MaxLength = 32767;
            this.txtTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTitle.Modified = false;
            this.txtTitle.Multiline = false;
            this.txtTitle.Name = "txtTitle";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTitle.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtTitle.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTitle.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTitle.OnIdleState = stateProperties4;
            this.txtTitle.Padding = new System.Windows.Forms.Padding(3);
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtTitle.PlaceholderText = "Enter Title";
            this.txtTitle.ReadOnly = false;
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTitle.SelectedText = "";
            this.txtTitle.SelectionLength = 0;
            this.txtTitle.SelectionStart = 0;
            this.txtTitle.ShortcutsEnabled = true;
            this.txtTitle.Size = new System.Drawing.Size(890, 54);
            this.txtTitle.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTitle.TextMarginBottom = 0;
            this.txtTitle.TextMarginLeft = 3;
            this.txtTitle.TextMarginTop = 1;
            this.txtTitle.TextPlaceholder = "Enter Title";
            this.txtTitle.UseSystemPasswordChar = false;
            this.txtTitle.WordWrap = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 54);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(890, 747);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "";
            // 
            // btSend
            // 
            this.btSend.AllowAnimations = true;
            this.btSend.AllowMouseEffects = true;
            this.btSend.AllowToggling = false;
            this.btSend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btSend.AnimationSpeed = 200;
            this.btSend.AutoGenerateColors = false;
            this.btSend.AutoRoundBorders = false;
            this.btSend.AutoSizeLeftIcon = true;
            this.btSend.AutoSizeRightIcon = true;
            this.btSend.BackColor = System.Drawing.Color.Transparent;
            this.btSend.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSend.BackgroundImage")));
            this.btSend.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSend.ButtonText = "Send";
            this.btSend.ButtonTextMarginLeft = 0;
            this.btSend.ColorContrastOnClick = 45;
            this.btSend.ColorContrastOnHover = 45;
            this.btSend.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btSend.CustomizableEdges = borderEdges2;
            this.btSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSend.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btSend.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btSend.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btSend.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btSend.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ForeColor = System.Drawing.Color.White;
            this.btSend.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSend.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btSend.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btSend.IconMarginLeft = 11;
            this.btSend.IconPadding = 10;
            this.btSend.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSend.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btSend.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btSend.IconSize = 25;
            this.btSend.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSend.IdleBorderRadius = 20;
            this.btSend.IdleBorderThickness = 1;
            this.btSend.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSend.IdleIconLeftImage = null;
            this.btSend.IdleIconRightImage = null;
            this.btSend.IndicateFocus = false;
            this.btSend.Location = new System.Drawing.Point(995, 129);
            this.btSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSend.Name = "btSend";
            this.btSend.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btSend.OnDisabledState.BorderRadius = 20;
            this.btSend.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSend.OnDisabledState.BorderThickness = 1;
            this.btSend.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btSend.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btSend.OnDisabledState.IconLeftImage = null;
            this.btSend.OnDisabledState.IconRightImage = null;
            this.btSend.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btSend.onHoverState.BorderRadius = 20;
            this.btSend.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSend.onHoverState.BorderThickness = 1;
            this.btSend.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btSend.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btSend.onHoverState.IconLeftImage = null;
            this.btSend.onHoverState.IconRightImage = null;
            this.btSend.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSend.OnIdleState.BorderRadius = 20;
            this.btSend.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSend.OnIdleState.BorderThickness = 1;
            this.btSend.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSend.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btSend.OnIdleState.IconLeftImage = null;
            this.btSend.OnIdleState.IconRightImage = null;
            this.btSend.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btSend.OnPressedState.BorderRadius = 20;
            this.btSend.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSend.OnPressedState.BorderThickness = 1;
            this.btSend.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btSend.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btSend.OnPressedState.IconLeftImage = null;
            this.btSend.OnPressedState.IconRightImage = null;
            this.btSend.Size = new System.Drawing.Size(231, 60);
            this.btSend.TabIndex = 91;
            this.btSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btSend.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btSend.TextMarginLeft = 0;
            this.btSend.TextPadding = new System.Windows.Forms.Padding(0);
            this.btSend.UseDefaultRadiusAndThickness = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.AcceptsReturn = false;
            this.txtEmail.AcceptsTab = false;
            this.txtEmail.AnimationSpeed = 200;
            this.txtEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEmail.AutoSizeHeight = true;
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtEmail.BackgroundImage")));
            this.txtEmail.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtEmail.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtEmail.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtEmail.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtEmail.BorderRadius = 1;
            this.txtEmail.BorderThickness = 1;
            this.txtEmail.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.DefaultText = "";
            this.txtEmail.FillColor = System.Drawing.Color.White;
            this.txtEmail.HideSelection = true;
            this.txtEmail.IconLeft = null;
            this.txtEmail.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.IconPadding = 10;
            this.txtEmail.IconRight = null;
            this.txtEmail.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Lines = new string[0];
            this.txtEmail.Location = new System.Drawing.Point(513, 135);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEmail.Modified = false;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtEmail.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtEmail.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtEmail.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtEmail.OnIdleState = stateProperties8;
            this.txtEmail.Padding = new System.Windows.Forms.Padding(3);
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtEmail.PlaceholderText = "Send to Email";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(463, 54);
            this.txtEmail.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtEmail.TabIndex = 92;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.TextMarginBottom = 0;
            this.txtEmail.TextMarginLeft = 3;
            this.txtEmail.TextMarginTop = 1;
            this.txtEmail.TextPlaceholder = "Send to Email";
            this.txtEmail.UseSystemPasswordChar = false;
            this.txtEmail.WordWrap = true;
            // 
            // UC_SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.lbList);
            this.Name = "UC_SendEmail";
            this.Size = new System.Drawing.Size(1587, 1200);
            this.Load += new System.EventHandler(this.UC_SendEmail_Load);
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
        private Bunifu.UI.WinForms.BunifuLabel lbTitle;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btRefresh;
        private Bunifu.UI.WinForms.BunifuLabel lbList;
        private System.Windows.Forms.RichTextBox txtMessage;
        private Bunifu.UI.WinForms.BunifuTextBox txtTitle;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btSend;
        private Bunifu.UI.WinForms.BunifuTextBox txtEmail;
    }
}

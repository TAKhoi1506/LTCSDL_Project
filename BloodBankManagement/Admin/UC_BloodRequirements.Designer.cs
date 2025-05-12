namespace BloodBankManagement.Admin
{
    partial class UC_BloodRequirements
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_BloodRequirements));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.dgvBloodRequirement = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RU_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BloodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lbSortBy = new Bunifu.UI.WinForms.BunifuLabel();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.btSearch = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            this.bunifuLabel11 = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodRequirement)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBloodRequirement
            // 
            this.dgvBloodRequirement.AllowCustomTheming = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvBloodRequirement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBloodRequirement.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvBloodRequirement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBloodRequirement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBloodRequirement.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBloodRequirement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBloodRequirement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBloodRequirement.ColumnHeadersHeight = 40;
            this.dgvBloodRequirement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.RU_ID,
            this.RequestDate,
            this.SupplyDate,
            this.BloodType,
            this.Amount,
            this.Status});
            this.dgvBloodRequirement.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvBloodRequirement.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvBloodRequirement.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBloodRequirement.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvBloodRequirement.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBloodRequirement.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvBloodRequirement.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvBloodRequirement.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvBloodRequirement.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvBloodRequirement.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBloodRequirement.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvBloodRequirement.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBloodRequirement.CurrentTheme.Name = null;
            this.dgvBloodRequirement.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBloodRequirement.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvBloodRequirement.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBloodRequirement.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvBloodRequirement.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBloodRequirement.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBloodRequirement.EnableHeadersVisualStyles = false;
            this.dgvBloodRequirement.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvBloodRequirement.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvBloodRequirement.HeaderForeColor = System.Drawing.Color.White;
            this.dgvBloodRequirement.Location = new System.Drawing.Point(224, 535);
            this.dgvBloodRequirement.Margin = new System.Windows.Forms.Padding(6);
            this.dgvBloodRequirement.Name = "dgvBloodRequirement";
            this.dgvBloodRequirement.RowHeadersVisible = false;
            this.dgvBloodRequirement.RowHeadersWidth = 82;
            this.dgvBloodRequirement.RowTemplate.Height = 40;
            this.dgvBloodRequirement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBloodRequirement.Size = new System.Drawing.Size(1966, 707);
            this.dgvBloodRequirement.TabIndex = 64;
            this.dgvBloodRequirement.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dgvBloodRequirement.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBloodRequirement_CellValueChanged);
            this.dgvBloodRequirement.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvBloodRequirement_CurrentCellDirtyStateChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 10;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // RU_ID
            // 
            this.RU_ID.HeaderText = "Unit ID";
            this.RU_ID.MinimumWidth = 10;
            this.RU_ID.Name = "RU_ID";
            this.RU_ID.ReadOnly = true;
            // 
            // RequestDate
            // 
            this.RequestDate.HeaderText = "Request Date";
            this.RequestDate.MinimumWidth = 10;
            this.RequestDate.Name = "RequestDate";
            this.RequestDate.ReadOnly = true;
            // 
            // SupplyDate
            // 
            this.SupplyDate.HeaderText = "Supply Date";
            this.SupplyDate.MinimumWidth = 10;
            this.SupplyDate.Name = "SupplyDate";
            this.SupplyDate.ReadOnly = true;
            // 
            // BloodType
            // 
            this.BloodType.HeaderText = "Blood Type";
            this.BloodType.MinimumWidth = 10;
            this.BloodType.Name = "BloodType";
            this.BloodType.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 10;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "Approved",
            "Completed",
            "Pending",
            "Rejected"});
            this.Status.MinimumWidth = 10;
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lbSortBy
            // 
            this.lbSortBy.AllowParentOverrides = false;
            this.lbSortBy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbSortBy.AutoEllipsis = false;
            this.lbSortBy.AutoSize = false;
            this.lbSortBy.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbSortBy.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbSortBy.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lbSortBy.Location = new System.Drawing.Point(1561, 398);
            this.lbSortBy.Margin = new System.Windows.Forms.Padding(4);
            this.lbSortBy.Name = "lbSortBy";
            this.lbSortBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSortBy.Size = new System.Drawing.Size(140, 48);
            this.lbSortBy.TabIndex = 62;
            this.lbSortBy.Text = "Sort by";
            this.lbSortBy.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbSortBy.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cbSort
            // 
            this.cbSort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbSort.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbSort.Font = new System.Drawing.Font("Arial", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSort.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "Unit ID",
            "Request date",
            "Supply date",
            "Blood type",
            "Amount",
            "Status"});
            this.cbSort.Location = new System.Drawing.Point(1731, 398);
            this.cbSort.Margin = new System.Windows.Forms.Padding(4);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(284, 48);
            this.cbSort.TabIndex = 61;
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            // 
            // btSearch
            // 
            this.btSearch.AllowAnimations = true;
            this.btSearch.AllowMouseEffects = true;
            this.btSearch.AllowToggling = false;
            this.btSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSearch.AnimationSpeed = 200;
            this.btSearch.AutoGenerateColors = false;
            this.btSearch.AutoRoundBorders = false;
            this.btSearch.AutoSizeLeftIcon = true;
            this.btSearch.AutoSizeRightIcon = true;
            this.btSearch.BackColor = System.Drawing.Color.Transparent;
            this.btSearch.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSearch.BackgroundImage")));
            this.btSearch.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSearch.ButtonText = "Search";
            this.btSearch.ButtonTextMarginLeft = 0;
            this.btSearch.ColorContrastOnClick = 45;
            this.btSearch.ColorContrastOnHover = 45;
            this.btSearch.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btSearch.CustomizableEdges = borderEdges2;
            this.btSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSearch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btSearch.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btSearch.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btSearch.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.ForeColor = System.Drawing.Color.White;
            this.btSearch.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSearch.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btSearch.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btSearch.IconMarginLeft = 11;
            this.btSearch.IconPadding = 10;
            this.btSearch.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSearch.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btSearch.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btSearch.IconSize = 25;
            this.btSearch.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(41)))), ((int)(((byte)(185)))));
            this.btSearch.IdleBorderRadius = 20;
            this.btSearch.IdleBorderThickness = 1;
            this.btSearch.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSearch.IdleIconLeftImage = null;
            this.btSearch.IdleIconRightImage = null;
            this.btSearch.IndicateFocus = false;
            this.btSearch.Location = new System.Drawing.Point(1026, 382);
            this.btSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btSearch.Name = "btSearch";
            this.btSearch.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btSearch.OnDisabledState.BorderRadius = 20;
            this.btSearch.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSearch.OnDisabledState.BorderThickness = 1;
            this.btSearch.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btSearch.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btSearch.OnDisabledState.IconLeftImage = null;
            this.btSearch.OnDisabledState.IconRightImage = null;
            this.btSearch.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btSearch.onHoverState.BorderRadius = 20;
            this.btSearch.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSearch.onHoverState.BorderThickness = 1;
            this.btSearch.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btSearch.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btSearch.onHoverState.IconLeftImage = null;
            this.btSearch.onHoverState.IconRightImage = null;
            this.btSearch.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(41)))), ((int)(((byte)(185)))));
            this.btSearch.OnIdleState.BorderRadius = 20;
            this.btSearch.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSearch.OnIdleState.BorderThickness = 1;
            this.btSearch.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btSearch.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btSearch.OnIdleState.IconLeftImage = null;
            this.btSearch.OnIdleState.IconRightImage = null;
            this.btSearch.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btSearch.OnPressedState.BorderRadius = 20;
            this.btSearch.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btSearch.OnPressedState.BorderThickness = 1;
            this.btSearch.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btSearch.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btSearch.OnPressedState.IconLeftImage = null;
            this.btSearch.OnPressedState.IconRightImage = null;
            this.btSearch.Size = new System.Drawing.Size(186, 63);
            this.btSearch.TabIndex = 65;
            this.btSearch.TabStop = false;
            this.btSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btSearch.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btSearch.TextMarginLeft = 0;
            this.btSearch.TextPadding = new System.Windows.Forms.Padding(0);
            this.btSearch.UseDefaultRadiusAndThickness = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = false;
            this.txtSearch.AcceptsTab = false;
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSearch.AnimationSpeed = 200;
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSearch.AutoSizeHeight = true;
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            this.txtSearch.BorderColorActive = System.Drawing.Color.White;
            this.txtSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.BorderColorHover = System.Drawing.Color.White;
            this.txtSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.BorderThickness = 1;
            this.txtSearch.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtSearch.HideSelection = true;
            this.txtSearch.IconLeft = global::BloodBankManagement.Properties.Resources.loupe;
            this.txtSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.IconPadding = 10;
            this.txtSearch.IconRight = null;
            this.txtSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(315, 382);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.MinimumSize = new System.Drawing.Size(2, 2);
            this.txtSearch.Modified = false;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            stateProperties5.BorderColor = System.Drawing.Color.White;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtSearch.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.White;
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnIdleState = stateProperties8;
            this.txtSearch.Padding = new System.Windows.Forms.Padding(4);
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtSearch.PlaceholderText = "Search by unit ID";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(676, 63);
            this.txtSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtSearch.TabIndex = 60;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.TextMarginBottom = 0;
            this.txtSearch.TextMarginLeft = 3;
            this.txtSearch.TextMarginTop = 1;
            this.txtSearch.TextPlaceholder = "Search by unit ID";
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WordWrap = true;
            // 
            // bunifuLabel11
            // 
            this.bunifuLabel11.AllowParentOverrides = false;
            this.bunifuLabel11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuLabel11.AutoEllipsis = false;
            this.bunifuLabel11.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel11.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel11.Location = new System.Drawing.Point(754, 121);
            this.bunifuLabel11.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuLabel11.Name = "bunifuLabel11";
            this.bunifuLabel11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel11.Size = new System.Drawing.Size(823, 80);
            this.bunifuLabel11.TabIndex = 66;
            this.bunifuLabel11.Text = "List Blood Requirements";
            this.bunifuLabel11.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel11.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // UC_BloodRequirements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbSortBy);
            this.Controls.Add(this.bunifuLabel11);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.dgvBloodRequirement);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.txtSearch);
            this.Name = "UC_BloodRequirements";
            this.Size = new System.Drawing.Size(2330, 1311);
            this.Load += new System.EventHandler(this.UC_BloodRequirements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodRequirement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btSearch;
        protected Bunifu.UI.WinForms.BunifuDataGridView dgvBloodRequirement;
        private Bunifu.UI.WinForms.BunifuLabel lbSortBy;
        private System.Windows.Forms.ComboBox cbSort;
        private Bunifu.UI.WinForms.BunifuTextBox txtSearch;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RU_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BloodType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
    }
}

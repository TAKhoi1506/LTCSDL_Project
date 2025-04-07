namespace BloodBankManagement
{
    partial class UC_Donations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Donations));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dgvDonation = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuLabel14 = new Bunifu.UI.WinForms.BunifuLabel();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.bunifuLabel18 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel15 = new Bunifu.UI.WinForms.BunifuLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFullName = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btAddDonation = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.Location = new System.Drawing.Point(447, 16);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(164, 28);
            this.bunifuLabel2.TabIndex = 1;
            this.bunifuLabel2.Text = "Donations List";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel3.Location = new System.Drawing.Point(30, 69);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(92, 22);
            this.bunifuLabel3.TabIndex = 17;
            this.bunifuLabel3.Text = "Username:";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dgvDonation
            // 
            this.dgvDonation.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvDonation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDonation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDonation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDonation.ColumnHeadersHeight = 40;
            this.dgvDonation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.donorID,
            this.eventID});
            this.dgvDonation.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvDonation.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDonation.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonation.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvDonation.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDonation.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvDonation.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvDonation.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvDonation.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvDonation.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDonation.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvDonation.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDonation.CurrentTheme.Name = null;
            this.dgvDonation.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonation.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDonation.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonation.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvDonation.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDonation.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDonation.EnableHeadersVisualStyles = false;
            this.dgvDonation.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvDonation.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvDonation.HeaderForeColor = System.Drawing.Color.White;
            this.dgvDonation.Location = new System.Drawing.Point(30, 267);
            this.dgvDonation.Name = "dgvDonation";
            this.dgvDonation.RowHeadersVisible = false;
            this.dgvDonation.RowTemplate.Height = 40;
            this.dgvDonation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonation.Size = new System.Drawing.Size(991, 297);
            this.dgvDonation.TabIndex = 19;
            this.dgvDonation.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuLabel14
            // 
            this.bunifuLabel14.AllowParentOverrides = false;
            this.bunifuLabel14.AutoEllipsis = false;
            this.bunifuLabel14.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel14.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel14.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel14.Location = new System.Drawing.Point(559, 69);
            this.bunifuLabel14.Name = "bunifuLabel14";
            this.bunifuLabel14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel14.Size = new System.Drawing.Size(183, 22);
            this.bunifuLabel14.TabIndex = 44;
            this.bunifuLabel14.Text = "Blood donation event:";
            this.bunifuLabel14.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel14.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // listEvents
            // 
            this.listEvents.FormattingEnabled = true;
            this.listEvents.Location = new System.Drawing.Point(772, 60);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(249, 121);
            this.listEvents.TabIndex = 45;
            // 
            // bunifuLabel18
            // 
            this.bunifuLabel18.AllowParentOverrides = false;
            this.bunifuLabel18.AutoEllipsis = false;
            this.bunifuLabel18.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel18.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel18.Font = new System.Drawing.Font("Arial", 9.75F);
            this.bunifuLabel18.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bunifuLabel18.Location = new System.Drawing.Point(295, 112);
            this.bunifuLabel18.Name = "bunifuLabel18";
            this.bunifuLabel18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel18.Size = new System.Drawing.Size(157, 33);
            this.bunifuLabel18.TabIndex = 62;
            this.bunifuLabel18.Text = "Condition: Female >= 42kg\r\n                    Male >= 45kg";
            this.bunifuLabel18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuLabel18.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel15
            // 
            this.bunifuLabel15.AllowParentOverrides = false;
            this.bunifuLabel15.AutoEllipsis = false;
            this.bunifuLabel15.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel15.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel15.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel15.Location = new System.Drawing.Point(30, 109);
            this.bunifuLabel15.Name = "bunifuLabel15";
            this.bunifuLabel15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel15.Size = new System.Drawing.Size(65, 22);
            this.bunifuLabel15.TabIndex = 61;
            this.bunifuLabel15.Text = "Weight:";
            this.bunifuLabel15.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel15.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(178, 112);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 22);
            this.numericUpDown1.TabIndex = 60;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel1.Location = new System.Drawing.Point(236, 109);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(20, 22);
            this.bunifuLabel1.TabIndex = 64;
            this.bunifuLabel1.Text = "kg";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // id
            // 
            this.id.HeaderText = "Donation ID";
            this.id.Name = "id";
            // 
            // donorID
            // 
            this.donorID.HeaderText = "Donor ID";
            this.donorID.Name = "donorID";
            // 
            // eventID
            // 
            this.eventID.HeaderText = "Event ID";
            this.eventID.Name = "eventID";
            // 
            // txtFullName
            // 
            this.txtFullName.AcceptsReturn = false;
            this.txtFullName.AcceptsTab = false;
            this.txtFullName.AnimationSpeed = 200;
            this.txtFullName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtFullName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtFullName.AutoSizeHeight = true;
            this.txtFullName.BackColor = System.Drawing.Color.Transparent;
            this.txtFullName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtFullName.BackgroundImage")));
            this.txtFullName.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtFullName.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtFullName.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtFullName.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtFullName.BorderRadius = 25;
            this.txtFullName.BorderThickness = 1;
            this.txtFullName.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtFullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.DefaultText = "";
            this.txtFullName.FillColor = System.Drawing.Color.White;
            this.txtFullName.HideSelection = true;
            this.txtFullName.IconLeft = null;
            this.txtFullName.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.IconPadding = 10;
            this.txtFullName.IconRight = null;
            this.txtFullName.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.Lines = new string[0];
            this.txtFullName.Location = new System.Drawing.Point(178, 63);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFullName.MaxLength = 32767;
            this.txtFullName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFullName.Modified = false;
            this.txtFullName.Multiline = false;
            this.txtFullName.Name = "txtFullName";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFullName.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtFullName.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFullName.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFullName.OnIdleState = stateProperties4;
            this.txtFullName.Padding = new System.Windows.Forms.Padding(2);
            this.txtFullName.PasswordChar = '\0';
            this.txtFullName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtFullName.PlaceholderText = "Enter username";
            this.txtFullName.ReadOnly = false;
            this.txtFullName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFullName.SelectedText = "";
            this.txtFullName.SelectionLength = 0;
            this.txtFullName.SelectionStart = 0;
            this.txtFullName.ShortcutsEnabled = true;
            this.txtFullName.Size = new System.Drawing.Size(274, 32);
            this.txtFullName.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtFullName.TabIndex = 63;
            this.txtFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFullName.TextMarginBottom = 0;
            this.txtFullName.TextMarginLeft = 3;
            this.txtFullName.TextMarginTop = 1;
            this.txtFullName.TextPlaceholder = "Enter username";
            this.txtFullName.UseSystemPasswordChar = false;
            this.txtFullName.WordWrap = true;
            // 
            // btAddDonation
            // 
            this.btAddDonation.AllowAnimations = true;
            this.btAddDonation.AllowMouseEffects = true;
            this.btAddDonation.AllowToggling = false;
            this.btAddDonation.AnimationSpeed = 200;
            this.btAddDonation.AutoGenerateColors = false;
            this.btAddDonation.AutoRoundBorders = false;
            this.btAddDonation.AutoSizeLeftIcon = true;
            this.btAddDonation.AutoSizeRightIcon = true;
            this.btAddDonation.BackColor = System.Drawing.Color.Transparent;
            this.btAddDonation.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAddDonation.BackgroundImage")));
            this.btAddDonation.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonation.ButtonText = "Add new donation";
            this.btAddDonation.ButtonTextMarginLeft = 0;
            this.btAddDonation.ColorContrastOnClick = 45;
            this.btAddDonation.ColorContrastOnHover = 45;
            this.btAddDonation.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btAddDonation.CustomizableEdges = borderEdges1;
            this.btAddDonation.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btAddDonation.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btAddDonation.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btAddDonation.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btAddDonation.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btAddDonation.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddDonation.ForeColor = System.Drawing.Color.White;
            this.btAddDonation.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddDonation.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btAddDonation.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btAddDonation.IconMarginLeft = 11;
            this.btAddDonation.IconPadding = 10;
            this.btAddDonation.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddDonation.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btAddDonation.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btAddDonation.IconSize = 25;
            this.btAddDonation.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonation.IdleBorderRadius = 20;
            this.btAddDonation.IdleBorderThickness = 1;
            this.btAddDonation.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonation.IdleIconLeftImage = null;
            this.btAddDonation.IdleIconRightImage = null;
            this.btAddDonation.IndicateFocus = false;
            this.btAddDonation.Location = new System.Drawing.Point(862, 200);
            this.btAddDonation.Name = "btAddDonation";
            this.btAddDonation.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btAddDonation.OnDisabledState.BorderRadius = 20;
            this.btAddDonation.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonation.OnDisabledState.BorderThickness = 1;
            this.btAddDonation.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btAddDonation.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btAddDonation.OnDisabledState.IconLeftImage = null;
            this.btAddDonation.OnDisabledState.IconRightImage = null;
            this.btAddDonation.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btAddDonation.onHoverState.BorderRadius = 20;
            this.btAddDonation.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonation.onHoverState.BorderThickness = 1;
            this.btAddDonation.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btAddDonation.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btAddDonation.onHoverState.IconLeftImage = null;
            this.btAddDonation.onHoverState.IconRightImage = null;
            this.btAddDonation.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonation.OnIdleState.BorderRadius = 20;
            this.btAddDonation.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonation.OnIdleState.BorderThickness = 1;
            this.btAddDonation.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonation.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btAddDonation.OnIdleState.IconLeftImage = null;
            this.btAddDonation.OnIdleState.IconRightImage = null;
            this.btAddDonation.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btAddDonation.OnPressedState.BorderRadius = 20;
            this.btAddDonation.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonation.OnPressedState.BorderThickness = 1;
            this.btAddDonation.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btAddDonation.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btAddDonation.OnPressedState.IconLeftImage = null;
            this.btAddDonation.OnPressedState.IconRightImage = null;
            this.btAddDonation.Size = new System.Drawing.Size(159, 39);
            this.btAddDonation.TabIndex = 32;
            this.btAddDonation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btAddDonation.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btAddDonation.TextMarginLeft = 0;
            this.btAddDonation.TextPadding = new System.Windows.Forms.Padding(0);
            this.btAddDonation.UseDefaultRadiusAndThickness = true;
            // 
            // UC_Donations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.bunifuLabel18);
            this.Controls.Add(this.bunifuLabel15);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.listEvents);
            this.Controls.Add(this.bunifuLabel14);
            this.Controls.Add(this.btAddDonation);
            this.Controls.Add(this.dgvDonation);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.bunifuLabel2);
            this.Name = "UC_Donations";
            this.Size = new System.Drawing.Size(1058, 592);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvDonation;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btAddDonation;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel14;
        private System.Windows.Forms.ListBox listEvents;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel18;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel15;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Bunifu.UI.WinForms.BunifuTextBox txtFullName;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn donorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventID;
    }
}

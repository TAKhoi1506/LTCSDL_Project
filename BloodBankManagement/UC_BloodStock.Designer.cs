namespace BloodBankManagement
{
    partial class UC_BloodStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_BloodStock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dgvStock = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.btAddDonor = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.dgvBloodDetails = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bloodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloodAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.bunifuLabel2.Location = new System.Drawing.Point(460, 19);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(139, 28);
            this.bunifuLabel2.TabIndex = 1;
            this.bunifuLabel2.Text = "Blood Stock";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStock.ColumnHeadersHeight = 40;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bloodType,
            this.bloodAmount});
            this.dgvStock.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvStock.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvStock.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvStock.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvStock.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvStock.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvStock.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvStock.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvStock.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvStock.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStock.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvStock.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvStock.CurrentTheme.Name = null;
            this.dgvStock.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStock.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvStock.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvStock.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvStock.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStock.EnableHeadersVisualStyles = false;
            this.dgvStock.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvStock.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvStock.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvStock.HeaderForeColor = System.Drawing.Color.White;
            this.dgvStock.Location = new System.Drawing.Point(39, 242);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.RowTemplate.Height = 40;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(273, 318);
            this.dgvStock.TabIndex = 8;
            this.dgvStock.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cbGender.Location = new System.Drawing.Point(183, 68);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(91, 21);
            this.cbGender.TabIndex = 26;
            // 
            // bunifuLabel7
            // 
            this.bunifuLabel7.AllowParentOverrides = false;
            this.bunifuLabel7.AutoEllipsis = false;
            this.bunifuLabel7.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel7.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel7.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel7.Location = new System.Drawing.Point(39, 67);
            this.bunifuLabel7.Name = "bunifuLabel7";
            this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel7.Size = new System.Drawing.Size(96, 22);
            this.bunifuLabel7.TabIndex = 25;
            this.bunifuLabel7.Text = "Blood type:";
            this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel1.Location = new System.Drawing.Point(39, 205);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(48, 22);
            this.bunifuLabel1.TabIndex = 30;
            this.bunifuLabel1.Text = "Stock";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(183, 107);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(91, 22);
            this.numericUpDown1.TabIndex = 31;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel3.Location = new System.Drawing.Point(39, 107);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(70, 22);
            this.bunifuLabel3.TabIndex = 32;
            this.bunifuLabel3.Text = "Amount:";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btAddDonor
            // 
            this.btAddDonor.AllowAnimations = true;
            this.btAddDonor.AllowMouseEffects = true;
            this.btAddDonor.AllowToggling = false;
            this.btAddDonor.AnimationSpeed = 200;
            this.btAddDonor.AutoGenerateColors = false;
            this.btAddDonor.AutoRoundBorders = false;
            this.btAddDonor.AutoSizeLeftIcon = true;
            this.btAddDonor.AutoSizeRightIcon = true;
            this.btAddDonor.BackColor = System.Drawing.Color.Transparent;
            this.btAddDonor.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAddDonor.BackgroundImage")));
            this.btAddDonor.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonor.ButtonText = "Add";
            this.btAddDonor.ButtonTextMarginLeft = 0;
            this.btAddDonor.ColorContrastOnClick = 45;
            this.btAddDonor.ColorContrastOnHover = 45;
            this.btAddDonor.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btAddDonor.CustomizableEdges = borderEdges1;
            this.btAddDonor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btAddDonor.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btAddDonor.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btAddDonor.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btAddDonor.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btAddDonor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddDonor.ForeColor = System.Drawing.Color.White;
            this.btAddDonor.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddDonor.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btAddDonor.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btAddDonor.IconMarginLeft = 11;
            this.btAddDonor.IconPadding = 10;
            this.btAddDonor.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddDonor.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btAddDonor.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btAddDonor.IconSize = 25;
            this.btAddDonor.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonor.IdleBorderRadius = 1;
            this.btAddDonor.IdleBorderThickness = 1;
            this.btAddDonor.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonor.IdleIconLeftImage = null;
            this.btAddDonor.IdleIconRightImage = null;
            this.btAddDonor.IndicateFocus = false;
            this.btAddDonor.Location = new System.Drawing.Point(197, 149);
            this.btAddDonor.Name = "btAddDonor";
            this.btAddDonor.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btAddDonor.OnDisabledState.BorderRadius = 1;
            this.btAddDonor.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonor.OnDisabledState.BorderThickness = 1;
            this.btAddDonor.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btAddDonor.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btAddDonor.OnDisabledState.IconLeftImage = null;
            this.btAddDonor.OnDisabledState.IconRightImage = null;
            this.btAddDonor.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btAddDonor.onHoverState.BorderRadius = 1;
            this.btAddDonor.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonor.onHoverState.BorderThickness = 1;
            this.btAddDonor.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btAddDonor.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btAddDonor.onHoverState.IconLeftImage = null;
            this.btAddDonor.onHoverState.IconRightImage = null;
            this.btAddDonor.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonor.OnIdleState.BorderRadius = 1;
            this.btAddDonor.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonor.OnIdleState.BorderThickness = 1;
            this.btAddDonor.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btAddDonor.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btAddDonor.OnIdleState.IconLeftImage = null;
            this.btAddDonor.OnIdleState.IconRightImage = null;
            this.btAddDonor.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btAddDonor.OnPressedState.BorderRadius = 1;
            this.btAddDonor.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btAddDonor.OnPressedState.BorderThickness = 1;
            this.btAddDonor.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btAddDonor.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btAddDonor.OnPressedState.IconLeftImage = null;
            this.btAddDonor.OnPressedState.IconRightImage = null;
            this.btAddDonor.Size = new System.Drawing.Size(77, 32);
            this.btAddDonor.TabIndex = 33;
            this.btAddDonor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btAddDonor.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btAddDonor.TextMarginLeft = 0;
            this.btAddDonor.TextPadding = new System.Windows.Forms.Padding(0);
            this.btAddDonor.UseDefaultRadiusAndThickness = true;
            // 
            // dgvBloodDetails
            // 
            this.dgvBloodDetails.AllowCustomTheming = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvBloodDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBloodDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBloodDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBloodDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBloodDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBloodDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBloodDetails.ColumnHeadersHeight = 40;
            this.dgvBloodDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bloodName,
            this.amount,
            this.collectionDate,
            this.expiredDate,
            this.status});
            this.dgvBloodDetails.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvBloodDetails.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvBloodDetails.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBloodDetails.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvBloodDetails.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBloodDetails.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvBloodDetails.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvBloodDetails.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvBloodDetails.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvBloodDetails.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBloodDetails.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvBloodDetails.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBloodDetails.CurrentTheme.Name = null;
            this.dgvBloodDetails.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBloodDetails.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvBloodDetails.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBloodDetails.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvBloodDetails.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBloodDetails.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBloodDetails.EnableHeadersVisualStyles = false;
            this.dgvBloodDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvBloodDetails.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvBloodDetails.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvBloodDetails.HeaderForeColor = System.Drawing.Color.White;
            this.dgvBloodDetails.Location = new System.Drawing.Point(347, 242);
            this.dgvBloodDetails.Name = "dgvBloodDetails";
            this.dgvBloodDetails.RowHeadersVisible = false;
            this.dgvBloodDetails.RowTemplate.Height = 40;
            this.dgvBloodDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBloodDetails.Size = new System.Drawing.Size(634, 318);
            this.dgvBloodDetails.TabIndex = 34;
            this.dgvBloodDetails.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AllowParentOverrides = false;
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel4.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel4.Font = new System.Drawing.Font("Arial", 14.25F);
            this.bunifuLabel4.Location = new System.Drawing.Point(347, 205);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(110, 22);
            this.bunifuLabel4.TabIndex = 35;
            this.bunifuLabel4.Text = "Blood details";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bloodType
            // 
            this.bloodType.HeaderText = "Blood type";
            this.bloodType.Name = "bloodType";
            // 
            // bloodAmount
            // 
            this.bloodAmount.HeaderText = "Amount";
            this.bloodAmount.Name = "bloodAmount";
            // 
            // bloodName
            // 
            this.bloodName.FillWeight = 61.54822F;
            this.bloodName.HeaderText = "Blood name";
            this.bloodName.Name = "bloodName";
            // 
            // amount
            // 
            this.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.amount.FillWeight = 253.8071F;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.Width = 92;
            // 
            // collectionDate
            // 
            this.collectionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.collectionDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.collectionDate.FillWeight = 61.54822F;
            this.collectionDate.HeaderText = "Collection date";
            this.collectionDate.Name = "collectionDate";
            this.collectionDate.Width = 144;
            // 
            // expiredDate
            // 
            this.expiredDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.expiredDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.expiredDate.FillWeight = 61.54822F;
            this.expiredDate.HeaderText = "Expired date";
            this.expiredDate.Name = "expiredDate";
            this.expiredDate.Width = 125;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.status.FillWeight = 61.54822F;
            this.status.HeaderText = "Status";
            this.status.Items.AddRange(new object[] {
            "Expired",
            "Unexpired"});
            this.status.Name = "status";
            this.status.Width = 70;
            // 
            // UC_BloodStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuLabel4);
            this.Controls.Add(this.dgvBloodDetails);
            this.Controls.Add(this.btAddDonor);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.bunifuLabel7);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.bunifuLabel2);
            this.Name = "UC_BloodStock";
            this.Size = new System.Drawing.Size(1058, 592);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvStock;
        private System.Windows.Forms.ComboBox cbGender;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel7;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btAddDonor;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvBloodDetails;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloodType;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloodAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiredDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn status;
    }
}

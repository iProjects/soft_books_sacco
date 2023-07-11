namespace CustomerModule.Views
{
    partial class SavingsWithdrawOperationsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavingsWithdrawOperationsForm));
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnWithdraw = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMinDepositAmount = new System.Windows.Forms.Label();
            this.lblMaxDepositAmount = new System.Windows.Forms.Label();
            this.lblMinDepositFees = new System.Windows.Forms.Label();
            this.lblMaxDepositFees = new System.Windows.Forms.Label();
            this.chkSetTransactionasPending = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtTransactionFees = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDepositDate = new System.Windows.Forms.DateTimePicker();
            this.label39 = new System.Windows.Forms.Label();
            this.txtAmountToPay = new System.Windows.Forms.NumericUpDown();
            this.txtNetAmount = new System.Windows.Forms.NumericUpDown();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "close_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "close_date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "contractid";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnWithdraw);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(562, 39);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.AutoSize = true;
            this.btnWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnWithdraw.LinkColor = System.Drawing.Color.Yellow;
            this.btnWithdraw.Location = new System.Drawing.Point(187, 12);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(78, 18);
            this.btnWithdraw.TabIndex = 17;
            this.btnWithdraw.TabStop = true;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnWithdraw_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(279, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblMinDepositAmount);
            this.groupBox3.Controls.Add(this.lblMaxDepositAmount);
            this.groupBox3.Controls.Add(this.lblMinDepositFees);
            this.groupBox3.Controls.Add(this.lblMaxDepositFees);
            this.groupBox3.Controls.Add(this.chkSetTransactionasPending);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.txtTransactionFees);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpDepositDate);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.txtAmountToPay);
            this.groupBox3.Controls.Add(this.txtNetAmount);
            this.groupBox3.Controls.Add(this.cboPaymentMethod);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(562, 258);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // lblMinDepositAmount
            // 
            this.lblMinDepositAmount.AutoSize = true;
            this.lblMinDepositAmount.Location = new System.Drawing.Point(390, 78);
            this.lblMinDepositAmount.Name = "lblMinDepositAmount";
            this.lblMinDepositAmount.Size = new System.Drawing.Size(24, 13);
            this.lblMinDepositAmount.TabIndex = 49;
            this.lblMinDepositAmount.Text = "Min";
            // 
            // lblMaxDepositAmount
            // 
            this.lblMaxDepositAmount.AutoSize = true;
            this.lblMaxDepositAmount.Location = new System.Drawing.Point(390, 91);
            this.lblMaxDepositAmount.Name = "lblMaxDepositAmount";
            this.lblMaxDepositAmount.Size = new System.Drawing.Size(27, 13);
            this.lblMaxDepositAmount.TabIndex = 48;
            this.lblMaxDepositAmount.Text = "Max";
            // 
            // lblMinDepositFees
            // 
            this.lblMinDepositFees.AutoSize = true;
            this.lblMinDepositFees.Location = new System.Drawing.Point(390, 118);
            this.lblMinDepositFees.Name = "lblMinDepositFees";
            this.lblMinDepositFees.Size = new System.Drawing.Size(24, 13);
            this.lblMinDepositFees.TabIndex = 47;
            this.lblMinDepositFees.Text = "Min";
            // 
            // lblMaxDepositFees
            // 
            this.lblMaxDepositFees.AutoSize = true;
            this.lblMaxDepositFees.Location = new System.Drawing.Point(390, 131);
            this.lblMaxDepositFees.Name = "lblMaxDepositFees";
            this.lblMaxDepositFees.Size = new System.Drawing.Size(27, 13);
            this.lblMaxDepositFees.TabIndex = 46;
            this.lblMaxDepositFees.Text = "Max";
            // 
            // chkSetTransactionasPending
            // 
            this.chkSetTransactionasPending.AutoSize = true;
            this.chkSetTransactionasPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSetTransactionasPending.Location = new System.Drawing.Point(176, 224);
            this.chkSetTransactionasPending.Name = "chkSetTransactionasPending";
            this.chkSetTransactionasPending.Size = new System.Drawing.Size(154, 17);
            this.chkSetTransactionasPending.TabIndex = 45;
            this.chkSetTransactionasPending.Text = "Set Transaction as Pending";
            this.chkSetTransactionasPending.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(176, 155);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(182, 20);
            this.txtDescription.TabIndex = 43;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(110, 158);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 13);
            this.label31.TabIndex = 44;
            this.label31.Text = "Description*";
            // 
            // txtTransactionFees
            // 
            this.txtTransactionFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionFees.Location = new System.Drawing.Point(176, 121);
            this.txtTransactionFees.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtTransactionFees.Name = "txtTransactionFees";
            this.txtTransactionFees.Size = new System.Drawing.Size(185, 20);
            this.txtTransactionFees.TabIndex = 41;
            this.txtTransactionFees.ThousandsSeparator = true;
            this.txtTransactionFees.ValueChanged += new System.EventHandler(this.txtTransactionFees_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Transaction Fees*";
            // 
            // dtpDepositDate
            // 
            this.dtpDepositDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepositDate.Location = new System.Drawing.Point(176, 19);
            this.dtpDepositDate.Name = "dtpDepositDate";
            this.dtpDepositDate.Size = new System.Drawing.Size(185, 20);
            this.dtpDepositDate.TabIndex = 39;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(141, 23);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(34, 13);
            this.label39.TabIndex = 40;
            this.label39.Text = "Date*";
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountToPay.Location = new System.Drawing.Point(176, 53);
            this.txtAmountToPay.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Size = new System.Drawing.Size(185, 20);
            this.txtAmountToPay.TabIndex = 29;
            this.txtAmountToPay.ThousandsSeparator = true;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetAmount.Location = new System.Drawing.Point(176, 87);
            this.txtNetAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(185, 20);
            this.txtNetAmount.TabIndex = 31;
            this.txtNetAmount.ThousandsSeparator = true;
            this.txtNetAmount.ValueChanged += new System.EventHandler(this.txtNetAmount_ValueChanged);
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(176, 189);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(182, 21);
            this.cboPaymentMethod.TabIndex = 33;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(82, 193);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(91, 13);
            this.label36.TabIndex = 34;
            this.label36.Text = "Payment Method*";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(107, 90);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(67, 13);
            this.label35.TabIndex = 32;
            this.label35.Text = "Net Amount*";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(90, 57);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 13);
            this.label34.TabIndex = 30;
            this.label34.Text = "Amount To Pay*";
            // 
            // SavingsWithdrawOperationsForm
            // 
            this.AcceptButton = this.btnWithdraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(562, 297);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavingsWithdrawOperationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WithDraw";
            this.Load += new System.EventHandler(this.SavingsFirstDepositForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnWithdraw;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMinDepositAmount;
        private System.Windows.Forms.Label lblMaxDepositAmount;
        private System.Windows.Forms.Label lblMinDepositFees;
        private System.Windows.Forms.Label lblMaxDepositFees;
        private System.Windows.Forms.CheckBox chkSetTransactionasPending;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown txtTransactionFees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDepositDate;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown txtAmountToPay;
        private System.Windows.Forms.NumericUpDown txtNetAmount;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;


    }
}
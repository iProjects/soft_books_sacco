namespace CustomerModule.Views
{
    partial class SavingsTransferOperationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavingsTransferOperationsForm));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnTransfer = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.LinkLabel();
            this.txtTransactionAccount = new System.Windows.Forms.TextBox();
            this.lblAccountOwner = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnTransfer
            // 
            this.btnTransfer.AutoSize = true;
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.LinkColor = System.Drawing.Color.Yellow;
            this.btnTransfer.Location = new System.Drawing.Point(129, 12);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(71, 18);
            this.btnTransfer.TabIndex = 17;
            this.btnTransfer.TabStop = true;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnTransfer_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTransfer);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(455, 39);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(221, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txtTransactionAccount);
            this.groupBox3.Controls.Add(this.lblAccountOwner);
            this.groupBox3.Controls.Add(this.label2);
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
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(455, 274);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearch.LinkColor = System.Drawing.Color.Yellow;
            this.btnSearch.Location = new System.Drawing.Point(322, 182);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 18);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.TabStop = true;
            this.btnSearch.Text = "Search";
            this.btnSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSearch_LinkClicked);
            // 
            // txtTransactionAccount
            // 
            this.txtTransactionAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionAccount.Location = new System.Drawing.Point(114, 180);
            this.txtTransactionAccount.Name = "txtTransactionAccount";
            this.txtTransactionAccount.Size = new System.Drawing.Size(182, 20);
            this.txtTransactionAccount.TabIndex = 53;
            // 
            // lblAccountOwner
            // 
            this.lblAccountOwner.AutoSize = true;
            this.lblAccountOwner.Location = new System.Drawing.Point(112, 212);
            this.lblAccountOwner.Name = "lblAccountOwner";
            this.lblAccountOwner.Size = new System.Drawing.Size(27, 13);
            this.lblAccountOwner.TabIndex = 52;
            this.lblAccountOwner.Text = "Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "To Account*";
            // 
            // lblMinDepositAmount
            // 
            this.lblMinDepositAmount.AutoSize = true;
            this.lblMinDepositAmount.Location = new System.Drawing.Point(312, 78);
            this.lblMinDepositAmount.Name = "lblMinDepositAmount";
            this.lblMinDepositAmount.Size = new System.Drawing.Size(24, 13);
            this.lblMinDepositAmount.TabIndex = 49;
            this.lblMinDepositAmount.Text = "Min";
            // 
            // lblMaxDepositAmount
            // 
            this.lblMaxDepositAmount.AutoSize = true;
            this.lblMaxDepositAmount.Location = new System.Drawing.Point(312, 91);
            this.lblMaxDepositAmount.Name = "lblMaxDepositAmount";
            this.lblMaxDepositAmount.Size = new System.Drawing.Size(27, 13);
            this.lblMaxDepositAmount.TabIndex = 48;
            this.lblMaxDepositAmount.Text = "Max";
            // 
            // lblMinDepositFees
            // 
            this.lblMinDepositFees.AutoSize = true;
            this.lblMinDepositFees.Location = new System.Drawing.Point(312, 118);
            this.lblMinDepositFees.Name = "lblMinDepositFees";
            this.lblMinDepositFees.Size = new System.Drawing.Size(24, 13);
            this.lblMinDepositFees.TabIndex = 47;
            this.lblMinDepositFees.Text = "Min";
            // 
            // lblMaxDepositFees
            // 
            this.lblMaxDepositFees.AutoSize = true;
            this.lblMaxDepositFees.Location = new System.Drawing.Point(312, 131);
            this.lblMaxDepositFees.Name = "lblMaxDepositFees";
            this.lblMaxDepositFees.Size = new System.Drawing.Size(27, 13);
            this.lblMaxDepositFees.TabIndex = 46;
            this.lblMaxDepositFees.Text = "Max";
            // 
            // chkSetTransactionasPending
            // 
            this.chkSetTransactionasPending.AutoSize = true;
            this.chkSetTransactionasPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSetTransactionasPending.Location = new System.Drawing.Point(115, 237);
            this.chkSetTransactionasPending.Name = "chkSetTransactionasPending";
            this.chkSetTransactionasPending.Size = new System.Drawing.Size(154, 17);
            this.chkSetTransactionasPending.TabIndex = 45;
            this.chkSetTransactionasPending.Text = "Set Transaction as Pending";
            this.chkSetTransactionasPending.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(115, 147);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(182, 20);
            this.txtDescription.TabIndex = 43;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(49, 151);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 13);
            this.label31.TabIndex = 44;
            this.label31.Text = "Description*";
            // 
            // txtTransactionFees
            // 
            this.txtTransactionFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionFees.Location = new System.Drawing.Point(115, 115);
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
            this.label1.Location = new System.Drawing.Point(20, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Transaction Fees*";
            // 
            // dtpDepositDate
            // 
            this.dtpDepositDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepositDate.Location = new System.Drawing.Point(115, 19);
            this.dtpDepositDate.Name = "dtpDepositDate";
            this.dtpDepositDate.Size = new System.Drawing.Size(185, 20);
            this.dtpDepositDate.TabIndex = 39;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(80, 23);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(34, 13);
            this.label39.TabIndex = 40;
            this.label39.Text = "Date*";
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountToPay.Location = new System.Drawing.Point(115, 51);
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
            this.txtNetAmount.Location = new System.Drawing.Point(115, 83);
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
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(46, 87);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(67, 13);
            this.label35.TabIndex = 32;
            this.label35.Text = "Net Amount*";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(29, 55);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 13);
            this.label34.TabIndex = 30;
            this.label34.Text = "Amount To Pay*";
            // 
            // SavingsTransferOperationsForm
            // 
            this.AcceptButton = this.btnTransfer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(455, 313);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavingsTransferOperationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer";
            this.Load += new System.EventHandler(this.SavingsTransferOperationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnTransfer;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAccountOwner;
        private System.Windows.Forms.LinkLabel btnSearch;
        private System.Windows.Forms.TextBox txtTransactionAccount;

    }
}
namespace CustomerModule.Views
{
    partial class SavingsSpecialOperationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavingsSpecialOperationsForm));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSetTransactionasPending = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dtpDepositDate = new System.Windows.Forms.DateTimePicker();
            this.label39 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.NumericUpDown();
            this.cboTransactionAccount = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConfirmOperation = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.radioButtonCredit = new System.Windows.Forms.RadioButton();
            this.radioButtonDebit = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "contractid";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "close_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "close_date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonCredit);
            this.groupBox3.Controls.Add(this.radioButtonDebit);
            this.groupBox3.Controls.Add(this.chkSetTransactionasPending);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.dtpDepositDate);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.txtNetAmount);
            this.groupBox3.Controls.Add(this.cboTransactionAccount);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 232);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // chkSetTransactionasPending
            // 
            this.chkSetTransactionasPending.AutoSize = true;
            this.chkSetTransactionasPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSetTransactionasPending.Location = new System.Drawing.Point(116, 197);
            this.chkSetTransactionasPending.Name = "chkSetTransactionasPending";
            this.chkSetTransactionasPending.Size = new System.Drawing.Size(154, 17);
            this.chkSetTransactionasPending.TabIndex = 45;
            this.chkSetTransactionasPending.Text = "Set Transaction as Pending";
            this.chkSetTransactionasPending.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(116, 128);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(221, 20);
            this.txtDescription.TabIndex = 43;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(50, 131);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 13);
            this.label31.TabIndex = 44;
            this.label31.Text = "Description*";
            // 
            // dtpDepositDate
            // 
            this.dtpDepositDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepositDate.Location = new System.Drawing.Point(116, 18);
            this.dtpDepositDate.Name = "dtpDepositDate";
            this.dtpDepositDate.Size = new System.Drawing.Size(224, 20);
            this.dtpDepositDate.TabIndex = 39;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(81, 22);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(34, 13);
            this.label39.TabIndex = 40;
            this.label39.Text = "Date*";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetAmount.Location = new System.Drawing.Point(116, 58);
            this.txtNetAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(224, 20);
            this.txtNetAmount.TabIndex = 31;
            this.txtNetAmount.ThousandsSeparator = true;
            // 
            // cboTransactionAccount
            // 
            this.cboTransactionAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTransactionAccount.FormattingEnabled = true;
            this.cboTransactionAccount.Location = new System.Drawing.Point(116, 162);
            this.cboTransactionAccount.Name = "cboTransactionAccount";
            this.cboTransactionAccount.Size = new System.Drawing.Size(362, 21);
            this.cboTransactionAccount.TabIndex = 33;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(46, 165);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(67, 13);
            this.label36.TabIndex = 34;
            this.label36.Text = "To Account*";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(47, 61);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(67, 13);
            this.label35.TabIndex = 32;
            this.label35.Text = "Net Amount*";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConfirmOperation);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(526, 39);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // btnConfirmOperation
            // 
            this.btnConfirmOperation.AutoSize = true;
            this.btnConfirmOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirmOperation.LinkColor = System.Drawing.Color.Yellow;
            this.btnConfirmOperation.Location = new System.Drawing.Point(120, 13);
            this.btnConfirmOperation.Name = "btnConfirmOperation";
            this.btnConfirmOperation.Size = new System.Drawing.Size(147, 18);
            this.btnConfirmOperation.TabIndex = 17;
            this.btnConfirmOperation.TabStop = true;
            this.btnConfirmOperation.Text = "Confirm Operation";
            this.btnConfirmOperation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnConfirmOperation_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(292, 13);
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
            // radioButtonCredit
            // 
            this.radioButtonCredit.AutoSize = true;
            this.radioButtonCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonCredit.Location = new System.Drawing.Point(196, 95);
            this.radioButtonCredit.Name = "radioButtonCredit";
            this.radioButtonCredit.Size = new System.Drawing.Size(51, 17);
            this.radioButtonCredit.TabIndex = 47;
            this.radioButtonCredit.TabStop = true;
            this.radioButtonCredit.Text = "Credit";
            this.radioButtonCredit.UseVisualStyleBackColor = true;
            // 
            // radioButtonDebit
            // 
            this.radioButtonDebit.AutoSize = true;
            this.radioButtonDebit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonDebit.Location = new System.Drawing.Point(116, 95);
            this.radioButtonDebit.Name = "radioButtonDebit";
            this.radioButtonDebit.Size = new System.Drawing.Size(49, 17);
            this.radioButtonDebit.TabIndex = 46;
            this.radioButtonDebit.TabStop = true;
            this.radioButtonDebit.Text = "Debit";
            this.radioButtonDebit.UseVisualStyleBackColor = true;
            // 
            // SavingsSpecialOperationsForm
            // 
            this.AcceptButton = this.btnConfirmOperation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(526, 271);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavingsSpecialOperationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Special Operation";
            this.Load += new System.EventHandler(this.SavingsFirstDepositForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkSetTransactionasPending;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker dtpDepositDate;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown txtNetAmount;
        private System.Windows.Forms.ComboBox cboTransactionAccount;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnConfirmOperation;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton radioButtonCredit;
        private System.Windows.Forms.RadioButton radioButtonDebit;

    }
}
namespace AdminstratorModule.Views
{
    partial class GeneralLedgerForm
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
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.bindingSourceGeneralLedger = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewGeneralLedger = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDisplay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.Column1date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3is_exported = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4event_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5contract_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6debit_local_account_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7credit_local_account_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8exchange_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGeneralLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneralLedger)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(67, 311);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 29);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 373);
            this.splitContainer1.SplitterDistance = 723;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewGeneralLedger);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(723, 373);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // dataGridViewGeneralLedger
            // 
            this.dataGridViewGeneralLedger.AllowUserToAddRows = false;
            this.dataGridViewGeneralLedger.AllowUserToDeleteRows = false;
            this.dataGridViewGeneralLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGeneralLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1date,
            this.Column2amount,
            this.Column3is_exported,
            this.Column4event_code,
            this.Column5contract_code,
            this.Column6debit_local_account_number,
            this.Column7credit_local_account_number,
            this.Column8exchange_rate});
            this.dataGridViewGeneralLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGeneralLedger.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewGeneralLedger.MultiSelect = false;
            this.dataGridViewGeneralLedger.Name = "dataGridViewGeneralLedger";
            this.dataGridViewGeneralLedger.ReadOnly = true;
            this.dataGridViewGeneralLedger.Size = new System.Drawing.Size(717, 354);
            this.dataGridViewGeneralLedger.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboCurrency);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboBranch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboDisplay);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboAccount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 373);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Currency";
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(72, 136);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(197, 21);
            this.cboCurrency.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.LinkColor = System.Drawing.Color.Yellow;
            this.btnRefresh.Location = new System.Drawing.Point(67, 266);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 25);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.TabStop = true;
            this.btnRefresh.Text = "Refresh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "End Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Begin Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Location = new System.Drawing.Point(72, 210);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(193, 20);
            this.dtpEndDate.TabIndex = 6;
            this.dtpEndDate.Value = new System.DateTime(2013, 2, 7, 0, 0, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Location = new System.Drawing.Point(72, 170);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(193, 20);
            this.dtpStartDate.TabIndex = 5;
            this.dtpStartDate.Value = new System.DateTime(2013, 3, 7, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Branch";
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(72, 100);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(197, 21);
            this.cboBranch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Display";
            // 
            // cboDisplay
            // 
            this.cboDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDisplay.FormattingEnabled = true;
            this.cboDisplay.Location = new System.Drawing.Point(72, 59);
            this.cboDisplay.Name = "cboDisplay";
            this.cboDisplay.Size = new System.Drawing.Size(197, 21);
            this.cboDisplay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account";
            // 
            // cboAccount
            // 
            this.cboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(72, 19);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(197, 21);
            this.cboAccount.TabIndex = 0;
            this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.cboAccount_SelectedIndexChanged);
            // 
            // Column1date
            // 
            this.Column1date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1date.DataPropertyName = "date";
            this.Column1date.HeaderText = "date";
            this.Column1date.Name = "Column1date";
            this.Column1date.ReadOnly = true;
            this.Column1date.Width = 60;
            // 
            // Column2amount
            // 
            this.Column2amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2amount.DataPropertyName = "amount";
            this.Column2amount.HeaderText = "amount";
            this.Column2amount.Name = "Column2amount";
            this.Column2amount.ReadOnly = true;
            this.Column2amount.Width = 80;
            // 
            // Column3is_exported
            // 
            this.Column3is_exported.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3is_exported.DataPropertyName = "is_exported";
            this.Column3is_exported.HeaderText = "is_exported";
            this.Column3is_exported.Name = "Column3is_exported";
            this.Column3is_exported.ReadOnly = true;
            this.Column3is_exported.Width = 50;
            // 
            // Column4event_code
            // 
            this.Column4event_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4event_code.DataPropertyName = "event_code";
            this.Column4event_code.HeaderText = "event_code";
            this.Column4event_code.Name = "Column4event_code";
            this.Column4event_code.ReadOnly = true;
            this.Column4event_code.Width = 50;
            // 
            // Column5contract_code
            // 
            this.Column5contract_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5contract_code.DataPropertyName = "contract_code";
            this.Column5contract_code.HeaderText = "contract_code";
            this.Column5contract_code.Name = "Column5contract_code";
            this.Column5contract_code.ReadOnly = true;
            // 
            // Column6debit_local_account_number
            // 
            this.Column6debit_local_account_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6debit_local_account_number.DataPropertyName = "debit_local_account_number";
            this.Column6debit_local_account_number.HeaderText = "debit_local_account_number";
            this.Column6debit_local_account_number.Name = "Column6debit_local_account_number";
            this.Column6debit_local_account_number.ReadOnly = true;
            // 
            // Column7credit_local_account_number
            // 
            this.Column7credit_local_account_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7credit_local_account_number.DataPropertyName = "credit_local_account_number";
            this.Column7credit_local_account_number.HeaderText = "credit_local_account_number";
            this.Column7credit_local_account_number.Name = "Column7credit_local_account_number";
            this.Column7credit_local_account_number.ReadOnly = true;
            // 
            // Column8exchange_rate
            // 
            this.Column8exchange_rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8exchange_rate.DataPropertyName = "exchange_rate";
            this.Column8exchange_rate.HeaderText = "exchange_rate";
            this.Column8exchange_rate.Name = "Column8exchange_rate";
            this.Column8exchange_rate.ReadOnly = true;
            // 
            // GeneralLedgerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1030, 373);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GeneralLedgerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Ledger";
            this.Load += new System.EventHandler(this.GeneralLedgerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGeneralLedger)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneralLedger)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceGeneralLedger;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewGeneralLedger;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnRefresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3is_exported;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4event_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5contract_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6debit_local_account_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7credit_local_account_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8exchange_rate;
    }
}
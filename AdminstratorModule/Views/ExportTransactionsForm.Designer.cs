namespace AdminstratorModule.Views
{
    partial class ExportTransactionsForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRunExports = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.progressBarExports = new System.Windows.Forms.ProgressBar();
            this.btnDeSelectAll = new System.Windows.Forms.LinkLabel();
            this.btnSelectAll = new System.Windows.Forms.LinkLabel();
            this.btnPrepareExports = new System.Windows.Forms.LinkLabel();
            this.lblCheckedRowsCounter = new System.Windows.Forms.Label();
            this.chkQuote = new System.Windows.Forms.CheckBox();
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.cboOptions = new System.Windows.Forms.ComboBox();
            this.cboExportProcedure = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewExportTransactions = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bindingSourceExportTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExportTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewResults);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 373);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // listViewResults
            // 
            this.listViewResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewResults.CheckBoxes = true;
            this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.GridLines = true;
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(3, 259);
            this.listViewResults.MultiSelect = false;
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.ShowItemToolTips = true;
            this.listViewResults.Size = new System.Drawing.Size(299, 111);
            this.listViewResults.TabIndex = 3;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewResults_ItemChecked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnRunExports);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpEndDate);
            this.groupBox3.Controls.Add(this.dtpStartDate);
            this.groupBox3.Controls.Add(this.progressBarExports);
            this.groupBox3.Controls.Add(this.btnDeSelectAll);
            this.groupBox3.Controls.Add(this.btnSelectAll);
            this.groupBox3.Controls.Add(this.btnPrepareExports);
            this.groupBox3.Controls.Add(this.lblCheckedRowsCounter);
            this.groupBox3.Controls.Add(this.chkQuote);
            this.groupBox3.Controls.Add(this.txtSeparator);
            this.groupBox3.Controls.Add(this.cboOptions);
            this.groupBox3.Controls.Add(this.cboExportProcedure);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 243);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(235, 217);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 26;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "StartDate";
            // 
            // btnRunExports
            // 
            this.btnRunExports.AutoSize = true;
            this.btnRunExports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnRunExports.LinkColor = System.Drawing.Color.Yellow;
            this.btnRunExports.Location = new System.Drawing.Point(132, 217);
            this.btnRunExports.Name = "btnRunExports";
            this.btnRunExports.Size = new System.Drawing.Size(101, 18);
            this.btnRunExports.TabIndex = 13;
            this.btnRunExports.TabStop = true;
            this.btnRunExports.Text = "Run Exports";
            this.btnRunExports.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRunExports_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "EndDate";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(153, 131);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(127, 20);
            this.dtpEndDate.TabIndex = 16;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(150, 81);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(127, 20);
            this.dtpStartDate.TabIndex = 15;
            // 
            // progressBarExports
            // 
            this.progressBarExports.Location = new System.Drawing.Point(135, 191);
            this.progressBarExports.Name = "progressBarExports";
            this.progressBarExports.Size = new System.Drawing.Size(145, 20);
            this.progressBarExports.TabIndex = 14;
            // 
            // btnDeSelectAll
            // 
            this.btnDeSelectAll.AutoSize = true;
            this.btnDeSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btnDeSelectAll.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeSelectAll.Location = new System.Drawing.Point(16, 218);
            this.btnDeSelectAll.Name = "btnDeSelectAll";
            this.btnDeSelectAll.Size = new System.Drawing.Size(76, 13);
            this.btnDeSelectAll.TabIndex = 12;
            this.btnDeSelectAll.TabStop = true;
            this.btnDeSelectAll.Text = "DeSelect All";
            this.btnDeSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeSelectAll_LinkClicked);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AutoSize = true;
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.LinkColor = System.Drawing.Color.Yellow;
            this.btnSelectAll.Location = new System.Drawing.Point(16, 195);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(60, 13);
            this.btnSelectAll.TabIndex = 11;
            this.btnSelectAll.TabStop = true;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSelectAll_LinkClicked);
            // 
            // btnPrepareExports
            // 
            this.btnPrepareExports.AutoSize = true;
            this.btnPrepareExports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrepareExports.LinkColor = System.Drawing.Color.Yellow;
            this.btnPrepareExports.Location = new System.Drawing.Point(8, 56);
            this.btnPrepareExports.Name = "btnPrepareExports";
            this.btnPrepareExports.Size = new System.Drawing.Size(117, 17);
            this.btnPrepareExports.TabIndex = 10;
            this.btnPrepareExports.TabStop = true;
            this.btnPrepareExports.Text = "Prepare Export";
            this.btnPrepareExports.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPrepareExports_LinkClicked);
            // 
            // lblCheckedRowsCounter
            // 
            this.lblCheckedRowsCounter.AutoSize = true;
            this.lblCheckedRowsCounter.Location = new System.Drawing.Point(21, 150);
            this.lblCheckedRowsCounter.Name = "lblCheckedRowsCounter";
            this.lblCheckedRowsCounter.Size = new System.Drawing.Size(101, 13);
            this.lblCheckedRowsCounter.TabIndex = 9;
            this.lblCheckedRowsCounter.Text = "0 selected out of : 0";
            // 
            // chkQuote
            // 
            this.chkQuote.AutoSize = true;
            this.chkQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkQuote.Location = new System.Drawing.Point(20, 165);
            this.chkQuote.Name = "chkQuote";
            this.chkQuote.Size = new System.Drawing.Size(147, 17);
            this.chkQuote.TabIndex = 8;
            this.chkQuote.Text = "Qoute Non-Numeric Fields";
            this.chkQuote.UseVisualStyleBackColor = true;
            // 
            // txtSeparator
            // 
            this.txtSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeparator.Location = new System.Drawing.Point(75, 125);
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(17, 20);
            this.txtSeparator.TabIndex = 7;
            // 
            // cboOptions
            // 
            this.cboOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOptions.FormattingEnabled = true;
            this.cboOptions.Location = new System.Drawing.Point(9, 97);
            this.cboOptions.Name = "cboOptions";
            this.cboOptions.Size = new System.Drawing.Size(113, 21);
            this.cboOptions.TabIndex = 6;
            // 
            // cboExportProcedure
            // 
            this.cboExportProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExportProcedure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboExportProcedure.FormattingEnabled = true;
            this.cboExportProcedure.Location = new System.Drawing.Point(6, 30);
            this.cboExportProcedure.Name = "cboExportProcedure";
            this.cboExportProcedure.Size = new System.Drawing.Size(227, 21);
            this.cboExportProcedure.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Separator:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Export Procedure";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewExportTransactions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 373);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewExportTransactions
            // 
            this.dataGridViewExportTransactions.AllowUserToAddRows = false;
            this.dataGridViewExportTransactions.AllowUserToDeleteRows = false;
            this.dataGridViewExportTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExportTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExportTransactions.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewExportTransactions.MultiSelect = false;
            this.dataGridViewExportTransactions.Name = "dataGridViewExportTransactions";
            this.dataGridViewExportTransactions.Size = new System.Drawing.Size(665, 354);
            this.dataGridViewExportTransactions.TabIndex = 3;
            this.dataGridViewExportTransactions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewExportTransactions_DataError);
            this.dataGridViewExportTransactions.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExportTransactions_RowValidated);
            this.dataGridViewExportTransactions.Validated += new System.EventHandler(this.dataGridViewExportTransactions_Validated);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(980, 373);
            this.splitContainer1.SplitterDistance = 671;
            this.splitContainer1.TabIndex = 4;
            // 
            // ExportTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(980, 373);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ExportTransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Transactions";
            this.Load += new System.EventHandler(this.ExportTransactionsForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportTransactions)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExportTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBarExports;
        private System.Windows.Forms.LinkLabel btnRunExports;
        private System.Windows.Forms.LinkLabel btnDeSelectAll;
        private System.Windows.Forms.LinkLabel btnSelectAll;
        private System.Windows.Forms.LinkLabel btnPrepareExports;
        private System.Windows.Forms.Label lblCheckedRowsCounter;
        private System.Windows.Forms.CheckBox chkQuote;
        private System.Windows.Forms.TextBox txtSeparator;
        private System.Windows.Forms.ComboBox cboOptions;
        private System.Windows.Forms.ComboBox cboExportProcedure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewExportTransactions;
        private System.Windows.Forms.BindingSource bindingSourceExportTransactions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;

    }
}
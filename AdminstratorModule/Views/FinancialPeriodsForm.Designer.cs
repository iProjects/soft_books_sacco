namespace AdminstratorModule.Views
{
    partial class FinancialPeriodsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinancialPeriodsForm));
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.LinkLabel();
            this.btnOpen = new System.Windows.Forms.LinkLabel();
            this.btnClosePeriod = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFiscalYears = new System.Windows.Forms.DataGridView();
            this.bindingSourceFiscalYears = new System.Windows.Forms.BindingSource(this.components);
            this.Columnfiscalyearid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnopen_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnclose_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiscalYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFiscalYears)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(389, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnClosePeriod);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 60);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreate.AutoSize = true;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreate.LinkColor = System.Drawing.Color.Yellow;
            this.btnCreate.Location = new System.Drawing.Point(88, 20);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(63, 20);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.TabStop = true;
            this.btnCreate.Text = "Create";
            this.btnCreate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCreate_LinkClicked);
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSize = true;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpen.LinkColor = System.Drawing.Color.Yellow;
            this.btnOpen.Location = new System.Drawing.Point(156, 20);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(52, 20);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.TabStop = true;
            this.btnOpen.Text = "Open";
            this.btnOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnOpen_LinkClicked);
            // 
            // btnClosePeriod
            // 
            this.btnClosePeriod.AutoSize = true;
            this.btnClosePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClosePeriod.LinkColor = System.Drawing.Color.Yellow;
            this.btnClosePeriod.Location = new System.Drawing.Point(216, 20);
            this.btnClosePeriod.Name = "btnClosePeriod";
            this.btnClosePeriod.Size = new System.Drawing.Size(110, 20);
            this.btnClosePeriod.TabIndex = 0;
            this.btnClosePeriod.TabStop = true;
            this.btnClosePeriod.Text = "Close Period";
            this.btnClosePeriod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClosePeriod_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewFiscalYears);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 196);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewFiscalYears
            // 
            this.dataGridViewFiscalYears.AllowUserToAddRows = false;
            this.dataGridViewFiscalYears.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFiscalYears.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFiscalYears.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiscalYears.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnfiscalyearid,
            this.Columnname,
            this.Columnopen_date,
            this.Columnclose_date});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFiscalYears.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewFiscalYears.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFiscalYears.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewFiscalYears.Name = "dataGridViewFiscalYears";
            this.dataGridViewFiscalYears.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFiscalYears.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewFiscalYears.Size = new System.Drawing.Size(447, 177);
            this.dataGridViewFiscalYears.TabIndex = 1;
            // 
            // Columnfiscalyearid
            // 
            this.Columnfiscalyearid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnfiscalyearid.DataPropertyName = "fiscalyearid";
            this.Columnfiscalyearid.HeaderText = "Id";
            this.Columnfiscalyearid.Name = "Columnfiscalyearid";
            this.Columnfiscalyearid.ReadOnly = true;
            this.Columnfiscalyearid.Width = 40;
            // 
            // Columnname
            // 
            this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnname.DataPropertyName = "name";
            this.Columnname.HeaderText = "Name";
            this.Columnname.Name = "Columnname";
            this.Columnname.ReadOnly = true;
            this.Columnname.Width = 150;
            // 
            // Columnopen_date
            // 
            this.Columnopen_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnopen_date.DataPropertyName = "open_date";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Columnopen_date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Columnopen_date.HeaderText = "open_date";
            this.Columnopen_date.Name = "Columnopen_date";
            this.Columnopen_date.ReadOnly = true;
            // 
            // Columnclose_date
            // 
            this.Columnclose_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnclose_date.DataPropertyName = "close_date";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Columnclose_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.Columnclose_date.HeaderText = "close_date";
            this.Columnclose_date.Name = "Columnclose_date";
            this.Columnclose_date.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(327, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 20);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // FinancialPeriodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(453, 256);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FinancialPeriodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial Periods";
            this.Load += new System.EventHandler(this.FinancialPeriodsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiscalYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFiscalYears)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnClosePeriod;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnCreate;
        private System.Windows.Forms.LinkLabel btnOpen;
        private System.Windows.Forms.DataGridView dataGridViewFiscalYears;
        private System.Windows.Forms.BindingSource bindingSourceFiscalYears;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnfiscalyearid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnopen_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnclose_date;
        private System.Windows.Forms.LinkLabel btnDelete;
    }
}
namespace AdminstratorModule.Views
{
    partial class FundingLinesListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnViewDetails = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFundingLines = new System.Windows.Forms.DataGridView();
            this.bindingSourceFundingLines = new System.Windows.Forms.BindingSource(this.components);
            this.Columnfundinglineid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInitialAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFundingLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFundingLines)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnViewDetails);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(568, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 20);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.LinkColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(528, 17);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(41, 20);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.TabStop = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEdit_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(488, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(41, 20);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(736, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 20);
            this.btnClose.TabIndex = 19;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.AutoSize = true;
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.LinkColor = System.Drawing.Color.Yellow;
            this.btnViewDetails.Location = new System.Drawing.Point(629, 17);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(108, 20);
            this.btnViewDetails.TabIndex = 18;
            this.btnViewDetails.TabStop = true;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnViewDetails_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewFundingLines);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(802, 321);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dataGridViewFundingLines
            // 
            this.dataGridViewFundingLines.AllowUserToAddRows = false;
            this.dataGridViewFundingLines.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFundingLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFundingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFundingLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnfundinglineid,
            this.Columnname,
            this.Columncode,
            this.ColumnBeginDate,
            this.ColumnEndDate,
            this.ColumnInitialAmount});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFundingLines.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewFundingLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFundingLines.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewFundingLines.Name = "dataGridViewFundingLines";
            this.dataGridViewFundingLines.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFundingLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewFundingLines.Size = new System.Drawing.Size(796, 302);
            this.dataGridViewFundingLines.TabIndex = 0;
            this.dataGridViewFundingLines.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFundingLines_CellContentDoubleClick);
            // 
            // Columnfundinglineid
            // 
            this.Columnfundinglineid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnfundinglineid.DataPropertyName = "fundinglineid";
            this.Columnfundinglineid.HeaderText = "Id";
            this.Columnfundinglineid.Name = "Columnfundinglineid";
            this.Columnfundinglineid.ReadOnly = true;
            this.Columnfundinglineid.Width = 40;
            // 
            // Columnname
            // 
            this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnname.DataPropertyName = "purpose";
            this.Columnname.HeaderText = "Name";
            this.Columnname.Name = "Columnname";
            this.Columnname.ReadOnly = true;
            this.Columnname.Width = 150;
            // 
            // Columncode
            // 
            this.Columncode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columncode.DataPropertyName = "name";
            this.Columncode.HeaderText = "Code";
            this.Columncode.Name = "Columncode";
            this.Columncode.ReadOnly = true;
            // 
            // ColumnBeginDate
            // 
            this.ColumnBeginDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnBeginDate.DataPropertyName = "begin_date";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnBeginDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnBeginDate.HeaderText = "Begin Date";
            this.ColumnBeginDate.Name = "ColumnBeginDate";
            this.ColumnBeginDate.ReadOnly = true;
            // 
            // ColumnEndDate
            // 
            this.ColumnEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnEndDate.DataPropertyName = "end_date";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnEndDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnEndDate.HeaderText = "End Date";
            this.ColumnEndDate.Name = "ColumnEndDate";
            this.ColumnEndDate.ReadOnly = true;
            // 
            // ColumnInitialAmount
            // 
            this.ColumnInitialAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnInitialAmount.DataPropertyName = "amount";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnInitialAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnInitialAmount.HeaderText = "Amount";
            this.ColumnInitialAmount.Name = "ColumnInitialAmount";
            this.ColumnInitialAmount.ReadOnly = true;
            // 
            // FundingLinesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(802, 373);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FundingLinesListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funding Lines";
            this.Load += new System.EventHandler(this.FundingLinesListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFundingLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFundingLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnViewDetails;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewFundingLines;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnEdit;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.BindingSource bindingSourceFundingLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnfundinglineid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInitialAmount;
    }
}
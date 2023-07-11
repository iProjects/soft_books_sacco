namespace AdminstratorModule.Views
{
    partial class PaymentMethodsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.bindingSourcePaymentMethods = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewPaymentMethods = new System.Windows.Forms.DataGridView();
            this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columndescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnis_active_for_loans = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Columnis_pending_for_loans = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Columnis_active_for_savings = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Columnis_pending_for_savings = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePaymentMethods)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentMethods)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(867, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(737, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 20);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.LinkColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(694, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(41, 20);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.TabStop = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEdit_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(651, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(41, 20);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(801, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridViewPaymentMethods);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(867, 319);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // dataGridViewPaymentMethods
            // 
            this.dataGridViewPaymentMethods.AllowUserToAddRows = false;
            this.dataGridViewPaymentMethods.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPaymentMethods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPaymentMethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPaymentMethods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnid,
            this.Columnname,
            this.Columndescription,
            this.Columnis_active_for_loans,
            this.Columnis_pending_for_loans,
            this.Columnis_active_for_savings,
            this.Columnis_pending_for_savings});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPaymentMethods.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPaymentMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPaymentMethods.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewPaymentMethods.MultiSelect = false;
            this.dataGridViewPaymentMethods.Name = "dataGridViewPaymentMethods";
            this.dataGridViewPaymentMethods.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPaymentMethods.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPaymentMethods.Size = new System.Drawing.Size(861, 300);
            this.dataGridViewPaymentMethods.TabIndex = 0;
            this.dataGridViewPaymentMethods.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPaymentMethods_CellContentDoubleClick);
            this.dataGridViewPaymentMethods.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewPaymentMethods_DataError);
            // 
            // Columnid
            // 
            this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnid.DataPropertyName = "paymentmethodid";
            this.Columnid.HeaderText = "Id";
            this.Columnid.Name = "Columnid";
            this.Columnid.ReadOnly = true;
            this.Columnid.Width = 50;
            // 
            // Columnname
            // 
            this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnname.DataPropertyName = "name";
            this.Columnname.HeaderText = "Name";
            this.Columnname.Name = "Columnname";
            this.Columnname.ReadOnly = true;
            // 
            // Columndescription
            // 
            this.Columndescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columndescription.DataPropertyName = "description";
            this.Columndescription.HeaderText = "Description";
            this.Columndescription.Name = "Columndescription";
            this.Columndescription.ReadOnly = true;
            // 
            // Columnis_active_for_loans
            // 
            this.Columnis_active_for_loans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnis_active_for_loans.DataPropertyName = "is_active_for_loans";
            this.Columnis_active_for_loans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Columnis_active_for_loans.HeaderText = "is_active_for_loans";
            this.Columnis_active_for_loans.Name = "Columnis_active_for_loans";
            this.Columnis_active_for_loans.ReadOnly = true;
            this.Columnis_active_for_loans.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Columnis_active_for_loans.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Columnis_pending_for_loans
            // 
            this.Columnis_pending_for_loans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnis_pending_for_loans.DataPropertyName = "is_pending_for_loans";
            this.Columnis_pending_for_loans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Columnis_pending_for_loans.HeaderText = "is_pending_for_loans";
            this.Columnis_pending_for_loans.Name = "Columnis_pending_for_loans";
            this.Columnis_pending_for_loans.ReadOnly = true;
            this.Columnis_pending_for_loans.Width = 110;
            // 
            // Columnis_active_for_savings
            // 
            this.Columnis_active_for_savings.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnis_active_for_savings.DataPropertyName = "is_active_for_savings";
            this.Columnis_active_for_savings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Columnis_active_for_savings.HeaderText = "is_active_for_savings";
            this.Columnis_active_for_savings.Name = "Columnis_active_for_savings";
            this.Columnis_active_for_savings.ReadOnly = true;
            this.Columnis_active_for_savings.Width = 110;
            // 
            // Columnis_pending_for_savings
            // 
            this.Columnis_pending_for_savings.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnis_pending_for_savings.DataPropertyName = "is_pending_for_savings";
            this.Columnis_pending_for_savings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Columnis_pending_for_savings.HeaderText = "is_pending_for_savings";
            this.Columnis_pending_for_savings.Name = "Columnis_pending_for_savings";
            this.Columnis_pending_for_savings.ReadOnly = true;
            // 
            // PaymentMethodsForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(867, 373);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "PaymentMethodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Methods";
            this.Load += new System.EventHandler(this.PaymentMethodsForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePaymentMethods)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentMethods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource bindingSourcePaymentMethods;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridViewPaymentMethods;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnEdit;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Columnis_active_for_loans;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Columnis_pending_for_loans;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Columnis_active_for_savings;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Columnis_pending_for_savings;

    }
}
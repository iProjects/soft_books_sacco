namespace AdminstratorModule.Views
{
    partial class AccountingRulesForm
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
            this.btnImport = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAccountingRules = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.LinkLabel();
            this.bindingSourceAccountingRules = new System.Windows.Forms.BindingSource(this.components);
            this.Columnaccountingruleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnevent_type_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnevent_attribute_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columncraccount_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columndraccount_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columndescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountingRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountingRules)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.LinkColor = System.Drawing.Color.Yellow;
            this.btnImport.Location = new System.Drawing.Point(590, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(61, 20);
            this.btnImport.TabIndex = 4;
            this.btnImport.TabStop = true;
            this.btnImport.Text = "Import";
            this.btnImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnImport_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewAccountingRules);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 399);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewAccountingRules
            // 
            this.dataGridViewAccountingRules.AllowUserToAddRows = false;
            this.dataGridViewAccountingRules.AllowUserToDeleteRows = false;
            this.dataGridViewAccountingRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccountingRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnaccountingruleid,
            this.Columnevent_type_description,
            this.Columnevent_attribute_name,
            this.Columncraccount_description,
            this.Columndraccount_description,
            this.Columndescription,
            this.Columnorder});
            this.dataGridViewAccountingRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAccountingRules.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewAccountingRules.Name = "dataGridViewAccountingRules";
            this.dataGridViewAccountingRules.ReadOnly = true;
            this.dataGridViewAccountingRules.Size = new System.Drawing.Size(788, 380);
            this.dataGridViewAccountingRules.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.AutoSize = true;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.LinkColor = System.Drawing.Color.Yellow;
            this.btnExport.Location = new System.Drawing.Point(659, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(61, 20);
            this.btnExport.TabIndex = 5;
            this.btnExport.TabStop = true;
            this.btnExport.Text = "Export";
            this.btnExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnExport_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(520, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 20);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 60);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(728, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(422, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(41, 20);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.LinkColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(471, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(41, 20);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.TabStop = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEdit_LinkClicked);
            // 
            // Columnaccountingruleid
            // 
            this.Columnaccountingruleid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnaccountingruleid.DataPropertyName = "accountingruleid";
            this.Columnaccountingruleid.HeaderText = "Id";
            this.Columnaccountingruleid.Name = "Columnaccountingruleid";
            this.Columnaccountingruleid.ReadOnly = true;
            this.Columnaccountingruleid.Width = 40;
            // 
            // Columnevent_type_description
            // 
            this.Columnevent_type_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnevent_type_description.DataPropertyName = "event_type_description";
            this.Columnevent_type_description.HeaderText = "Event Type ";
            this.Columnevent_type_description.Name = "Columnevent_type_description";
            this.Columnevent_type_description.ReadOnly = true;
            this.Columnevent_type_description.Width = 90;
            // 
            // Columnevent_attribute_name
            // 
            this.Columnevent_attribute_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnevent_attribute_name.DataPropertyName = "event_attribute_name";
            this.Columnevent_attribute_name.HeaderText = "Event Attribute";
            this.Columnevent_attribute_name.Name = "Columnevent_attribute_name";
            this.Columnevent_attribute_name.ReadOnly = true;
            this.Columnevent_attribute_name.Width = 120;
            // 
            // Columncraccount_description
            // 
            this.Columncraccount_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columncraccount_description.DataPropertyName = "craccount_description";
            this.Columncraccount_description.HeaderText = "Credit Account";
            this.Columncraccount_description.Name = "Columncraccount_description";
            this.Columncraccount_description.ReadOnly = true;
            this.Columncraccount_description.Width = 120;
            // 
            // Columndraccount_description
            // 
            this.Columndraccount_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columndraccount_description.DataPropertyName = "draccount_description";
            this.Columndraccount_description.HeaderText = "Debit Account";
            this.Columndraccount_description.Name = "Columndraccount_description";
            this.Columndraccount_description.ReadOnly = true;
            this.Columndraccount_description.Width = 120;
            // 
            // Columndescription
            // 
            this.Columndescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columndescription.DataPropertyName = "description";
            this.Columndescription.HeaderText = "Description";
            this.Columndescription.Name = "Columndescription";
            this.Columndescription.ReadOnly = true;
            this.Columndescription.Width = 180;
            // 
            // Columnorder
            // 
            this.Columnorder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnorder.DataPropertyName = "order";
            this.Columnorder.HeaderText = "Order";
            this.Columnorder.Name = "Columnorder";
            this.Columnorder.ReadOnly = true;
            // 
            // AccountingRulesForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(794, 459);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AccountingRulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounting Rules";
            this.Load += new System.EventHandler(this.AccountingRulesForm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountingRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountingRules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnImport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnExport;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnEdit;
        private System.Windows.Forms.BindingSource bindingSourceAccountingRules;
        private System.Windows.Forms.DataGridView dataGridViewAccountingRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnaccountingruleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnevent_type_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnevent_attribute_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columncraccount_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndraccount_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnorder;
    }
}
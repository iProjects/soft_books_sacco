namespace AdminstratorModule.Views
{
    partial class InstallmentTypesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoofDays = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnCancel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.txtNoofMonths = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.bindingSourceInstallmentTypes = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewInstallmentTypes = new System.Windows.Forms.DataGridView();
            this.Columninstallmenttypesid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnnb_of_days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnnb_of_months = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInstallmentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstallmentTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNoofDays);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtNoofMonths);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "No of Days*\r\n";
            // 
            // txtNoofDays
            // 
            this.txtNoofDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoofDays.Location = new System.Drawing.Point(148, 95);
            this.txtNoofDays.MaxLength = 4;
            this.txtNoofDays.Name = "txtNoofDays";
            this.txtNoofDays.Size = new System.Drawing.Size(182, 20);
            this.txtNoofDays.TabIndex = 25;
            this.txtNoofDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoofDays_KeyDown);
            this.txtNoofDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofDays_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(469, 72);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 20);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.LinkColor = System.Drawing.Color.Yellow;
            this.btnCancel.Location = new System.Drawing.Point(467, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 20);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.TabStop = true;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCancel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "No of Months*\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = " Name*";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(469, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(41, 20);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSave_LinkClicked);
            // 
            // txtNoofMonths
            // 
            this.txtNoofMonths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoofMonths.Location = new System.Drawing.Point(148, 60);
            this.txtNoofMonths.MaxLength = 4;
            this.txtNoofMonths.Name = "txtNoofMonths";
            this.txtNoofMonths.Size = new System.Drawing.Size(182, 20);
            this.txtNoofMonths.TabIndex = 1;
            this.txtNoofMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoofMonths_KeyDown);
            this.txtNoofMonths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofMonths_KeyPress);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(148, 24);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(469, 102);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 19;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewInstallmentTypes);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 241);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewInstallmentTypes
            // 
            this.dataGridViewInstallmentTypes.AllowUserToAddRows = false;
            this.dataGridViewInstallmentTypes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInstallmentTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewInstallmentTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInstallmentTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columninstallmenttypesid,
            this.Columnname,
            this.Columnnb_of_days,
            this.Columnnb_of_months});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInstallmentTypes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewInstallmentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInstallmentTypes.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewInstallmentTypes.MultiSelect = false;
            this.dataGridViewInstallmentTypes.Name = "dataGridViewInstallmentTypes";
            this.dataGridViewInstallmentTypes.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInstallmentTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewInstallmentTypes.Size = new System.Drawing.Size(584, 222);
            this.dataGridViewInstallmentTypes.TabIndex = 3;
            this.dataGridViewInstallmentTypes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInstallmentTypes_CellContentClick);
            // 
            // Columninstallmenttypesid
            // 
            this.Columninstallmenttypesid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columninstallmenttypesid.DataPropertyName = "installmenttypesid";
            this.Columninstallmenttypesid.HeaderText = "Id";
            this.Columninstallmenttypesid.Name = "Columninstallmenttypesid";
            this.Columninstallmenttypesid.ReadOnly = true;
            this.Columninstallmenttypesid.Width = 40;
            // 
            // Columnname
            // 
            this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnname.DataPropertyName = "name";
            this.Columnname.HeaderText = "Name";
            this.Columnname.Name = "Columnname";
            this.Columnname.ReadOnly = true;
            this.Columnname.Width = 200;
            // 
            // Columnnb_of_days
            // 
            this.Columnnb_of_days.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnnb_of_days.DataPropertyName = "nb_of_days";
            this.Columnnb_of_days.HeaderText = "nb_of_days";
            this.Columnnb_of_days.Name = "Columnnb_of_days";
            this.Columnnb_of_days.ReadOnly = true;
            // 
            // Columnnb_of_months
            // 
            this.Columnnb_of_months.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnnb_of_months.DataPropertyName = "nb_of_months";
            this.Columnnb_of_months.HeaderText = "nb_of_months";
            this.Columnnb_of_months.Name = "Columnnb_of_months";
            this.Columnnb_of_months.ReadOnly = true;
            this.Columnnb_of_months.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // InstallmentTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(590, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "InstallmentTypesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installment Types";
            this.Load += new System.EventHandler(this.InstallmentTypesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInstallmentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstallmentTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.TextBox txtNoofMonths;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.BindingSource bindingSourceInstallmentTypes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoofDays;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewInstallmentTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columninstallmenttypesid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnnb_of_days;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnnb_of_months;

    }
}
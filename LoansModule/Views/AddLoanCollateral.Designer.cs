namespace LoansModule.Views
{
    partial class AddLoanCollateral
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLoanCollateral));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSelectCollateralOwner = new System.Windows.Forms.LinkLabel();
            this.btnClearCollateralOwner = new System.Windows.Forms.LinkLabel();
            this.btnAddCollateralOwner = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCollateralProperties = new System.Windows.Forms.DataGridView();
            this.ColumnPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnfirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnlastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDateofBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnloan_cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columncity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnidentification_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollateralProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 341);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(633, 32);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(315, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 16);
            this.btnClose.TabIndex = 14;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(247, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 16);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSelectCollateralOwner);
            this.groupBox3.Controls.Add(this.btnClearCollateralOwner);
            this.groupBox3.Controls.Add(this.btnAddCollateralOwner);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(633, 40);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Owner Management";
            // 
            // btnSelectCollateralOwner
            // 
            this.btnSelectCollateralOwner.AutoSize = true;
            this.btnSelectCollateralOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectCollateralOwner.LinkColor = System.Drawing.Color.Yellow;
            this.btnSelectCollateralOwner.Location = new System.Drawing.Point(259, 14);
            this.btnSelectCollateralOwner.Name = "btnSelectCollateralOwner";
            this.btnSelectCollateralOwner.Size = new System.Drawing.Size(104, 17);
            this.btnSelectCollateralOwner.TabIndex = 17;
            this.btnSelectCollateralOwner.TabStop = true;
            this.btnSelectCollateralOwner.Text = "Select Owner";
            // 
            // btnClearCollateralOwner
            // 
            this.btnClearCollateralOwner.AutoSize = true;
            this.btnClearCollateralOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCollateralOwner.LinkColor = System.Drawing.Color.Yellow;
            this.btnClearCollateralOwner.Location = new System.Drawing.Point(384, 14);
            this.btnClearCollateralOwner.Name = "btnClearCollateralOwner";
            this.btnClearCollateralOwner.Size = new System.Drawing.Size(97, 17);
            this.btnClearCollateralOwner.TabIndex = 16;
            this.btnClearCollateralOwner.TabStop = true;
            this.btnClearCollateralOwner.Text = "Clear Owner";
            // 
            // btnAddCollateralOwner
            // 
            this.btnAddCollateralOwner.AutoSize = true;
            this.btnAddCollateralOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddCollateralOwner.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddCollateralOwner.Location = new System.Drawing.Point(153, 14);
            this.btnAddCollateralOwner.Name = "btnAddCollateralOwner";
            this.btnAddCollateralOwner.Size = new System.Drawing.Size(87, 17);
            this.btnAddCollateralOwner.TabIndex = 15;
            this.btnAddCollateralOwner.TabStop = true;
            this.btnAddCollateralOwner.Text = "Add Owner";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 49);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewCollateralProperties);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 252);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewCollateralProperties
            // 
            this.dataGridViewCollateralProperties.AllowUserToAddRows = false;
            this.dataGridViewCollateralProperties.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCollateralProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCollateralProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCollateralProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPersonID,
            this.ColumnfirstName,
            this.Columnlastname,
            this.ColumnActive,
            this.ColumnDateofBirth,
            this.Columnloan_cycle,
            this.Columncity,
            this.Columnidentification_data});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCollateralProperties.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCollateralProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCollateralProperties.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewCollateralProperties.MultiSelect = false;
            this.dataGridViewCollateralProperties.Name = "dataGridViewCollateralProperties";
            this.dataGridViewCollateralProperties.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCollateralProperties.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCollateralProperties.Size = new System.Drawing.Size(627, 233);
            this.dataGridViewCollateralProperties.TabIndex = 1;
            // 
            // ColumnPersonID
            // 
            this.ColumnPersonID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnPersonID.DataPropertyName = "tierid";
            this.ColumnPersonID.HeaderText = "Id";
            this.ColumnPersonID.Name = "ColumnPersonID";
            this.ColumnPersonID.ReadOnly = true;
            this.ColumnPersonID.Width = 50;
            // 
            // ColumnfirstName
            // 
            this.ColumnfirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnfirstName.DataPropertyName = "first_name";
            this.ColumnfirstName.HeaderText = "First Name";
            this.ColumnfirstName.Name = "ColumnfirstName";
            this.ColumnfirstName.ReadOnly = true;
            // 
            // Columnlastname
            // 
            this.Columnlastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnlastname.DataPropertyName = "last_name";
            this.Columnlastname.HeaderText = "Last Name";
            this.Columnlastname.Name = "Columnlastname";
            this.Columnlastname.ReadOnly = true;
            // 
            // ColumnActive
            // 
            this.ColumnActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnActive.DataPropertyName = "active";
            this.ColumnActive.HeaderText = "Active";
            this.ColumnActive.Name = "ColumnActive";
            this.ColumnActive.ReadOnly = true;
            this.ColumnActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnDateofBirth
            // 
            this.ColumnDateofBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnDateofBirth.DataPropertyName = "birth_date";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnDateofBirth.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnDateofBirth.HeaderText = "Date of Birth";
            this.ColumnDateofBirth.Name = "ColumnDateofBirth";
            this.ColumnDateofBirth.ReadOnly = true;
            // 
            // Columnloan_cycle
            // 
            this.Columnloan_cycle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnloan_cycle.DataPropertyName = "loan_cycle";
            this.Columnloan_cycle.HeaderText = "Loan Cycle";
            this.Columnloan_cycle.Name = "Columnloan_cycle";
            this.Columnloan_cycle.ReadOnly = true;
            // 
            // Columncity
            // 
            this.Columncity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columncity.DataPropertyName = "city";
            this.Columncity.HeaderText = "City";
            this.Columncity.Name = "Columncity";
            this.Columncity.ReadOnly = true;
            this.Columncity.Width = 70;
            // 
            // Columnidentification_data
            // 
            this.Columnidentification_data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnidentification_data.DataPropertyName = "identification_data";
            this.Columnidentification_data.HeaderText = "Identification Data";
            this.Columnidentification_data.Name = "Columnidentification_data";
            this.Columnidentification_data.ReadOnly = true;
            // 
            // AddLoanCollateral
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(633, 373);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddLoanCollateral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Collateral";
            this.Load += new System.EventHandler(this.AddLoanCollateral_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollateralProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel btnSelectCollateralOwner;
        private System.Windows.Forms.LinkLabel btnClearCollateralOwner;
        private System.Windows.Forms.LinkLabel btnAddCollateralOwner;
        private System.Windows.Forms.DataGridView dataGridViewCollateralProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnfirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnlastname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateofBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnloan_cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columncity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnidentification_data;
    }
}
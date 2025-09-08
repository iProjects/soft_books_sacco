namespace SearchModule.Views
{
    partial class SearchPersonClientForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtpersonname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkactive = new System.Windows.Forms.CheckBox();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.dataGridViewPersons = new System.Windows.Forms.DataGridView();
            this.ColumnPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnfirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnlastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnidentification_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columncreated_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPager = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewPersons);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1018, 469);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtpersonname
            // 
            this.txtpersonname.Location = new System.Drawing.Point(86, 19);
            this.txtpersonname.Name = "txtpersonname";
            this.txtpersonname.Size = new System.Drawing.Size(462, 20);
            this.txtpersonname.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkInactive);
            this.groupBox2.Controls.Add(this.chkactive);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtpersonname);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1018, 63);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlPager);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 532);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1018, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Name";
            // 
            // chkactive
            // 
            this.chkactive.AutoSize = true;
            this.chkactive.Location = new System.Drawing.Point(799, 19);
            this.chkactive.Name = "chkactive";
            this.chkactive.Size = new System.Drawing.Size(56, 17);
            this.chkactive.TabIndex = 2;
            this.chkactive.Text = "Active";
            this.chkactive.UseVisualStyleBackColor = true;
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.Location = new System.Drawing.Point(900, 18);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(65, 17);
            this.chkInactive.TabIndex = 3;
            this.chkInactive.Text = "InActive";
            this.chkInactive.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPersons
            // 
            this.dataGridViewPersons.AllowUserToAddRows = false;
            this.dataGridViewPersons.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPersons.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPersonID,
            this.ColumnfirstName,
            this.Columnlastname,
            this.Columnidentification_data,
            this.Columnstatus,
            this.Columncreated_date});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPersons.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPersons.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewPersons.MultiSelect = false;
            this.dataGridViewPersons.Name = "dataGridViewPersons";
            this.dataGridViewPersons.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPersons.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPersons.Size = new System.Drawing.Size(1012, 450);
            this.dataGridViewPersons.TabIndex = 1;
            // 
            // ColumnPersonID
            // 
            this.ColumnPersonID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnPersonID.DataPropertyName = "id";
            this.ColumnPersonID.HeaderText = "Id";
            this.ColumnPersonID.Name = "ColumnPersonID";
            this.ColumnPersonID.ReadOnly = true;
            this.ColumnPersonID.Width = 40;
            // 
            // ColumnfirstName
            // 
            this.ColumnfirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnfirstName.DataPropertyName = "first_name";
            this.ColumnfirstName.HeaderText = "First Name";
            this.ColumnfirstName.Name = "ColumnfirstName";
            this.ColumnfirstName.ReadOnly = true;
            this.ColumnfirstName.Width = 150;
            // 
            // Columnlastname
            // 
            this.Columnlastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnlastname.DataPropertyName = "last_name";
            this.Columnlastname.HeaderText = "Last Name";
            this.Columnlastname.Name = "Columnlastname";
            this.Columnlastname.ReadOnly = true;
            this.Columnlastname.Width = 150;
            // 
            // Columnidentification_data
            // 
            this.Columnidentification_data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnidentification_data.DataPropertyName = "identification_data";
            this.Columnidentification_data.HeaderText = "ID";
            this.Columnidentification_data.Name = "Columnidentification_data";
            this.Columnidentification_data.ReadOnly = true;
            // 
            // Columnstatus
            // 
            this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnstatus.DataPropertyName = "status";
            this.Columnstatus.HeaderText = "Status";
            this.Columnstatus.Name = "Columnstatus";
            this.Columnstatus.ReadOnly = true;
            // 
            // Columncreated_date
            // 
            this.Columncreated_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columncreated_date.DataPropertyName = "created_date";
            this.Columncreated_date.HeaderText = "Created Date";
            this.Columncreated_date.Name = "Columncreated_date";
            this.Columncreated_date.ReadOnly = true;
            // 
            // pnlPager
            // 
            this.pnlPager.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlPager.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPager.Location = new System.Drawing.Point(3, 16);
            this.pnlPager.Name = "pnlPager";
            this.pnlPager.Size = new System.Drawing.Size(1012, 50);
            this.pnlPager.TabIndex = 0;
            // 
            // SearchPersonClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1018, 632);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchPersonClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Clients";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtpersonname;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.CheckBox chkactive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewPersons;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnfirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnlastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnidentification_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columncreated_date;
        private System.Windows.Forms.Panel pnlPager;


    }
}
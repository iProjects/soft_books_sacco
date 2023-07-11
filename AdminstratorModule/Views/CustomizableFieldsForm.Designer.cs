namespace AdminstratorModule.Views
{
    partial class CustomizableFieldsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnViewDetails = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCustomizableFields = new System.Windows.Forms.DataGridView();
            this.Columnadvfieldsid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnfieldscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnfieldnameslist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceCustomizableFields = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomizableFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomizableFields)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnViewDetails);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(570, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 18);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.AutoSize = true;
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.LinkColor = System.Drawing.Color.Yellow;
            this.btnViewDetails.Location = new System.Drawing.Point(461, 18);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(100, 18);
            this.btnViewDetails.TabIndex = 10;
            this.btnViewDetails.TabStop = true;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnViewDetails_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(635, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 9;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(370, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.LinkColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(415, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(37, 18);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.TabStop = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEdit_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewCustomizableFields);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 319);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewCustomizableFields
            // 
            this.dataGridViewCustomizableFields.AllowUserToAddRows = false;
            this.dataGridViewCustomizableFields.AllowUserToDeleteRows = false;
            this.dataGridViewCustomizableFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomizableFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnadvfieldsid,
            this.Columnfieldscount,
            this.Columnfieldnameslist});
            this.dataGridViewCustomizableFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomizableFields.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewCustomizableFields.Name = "dataGridViewCustomizableFields";
            this.dataGridViewCustomizableFields.ReadOnly = true;
            this.dataGridViewCustomizableFields.Size = new System.Drawing.Size(693, 300);
            this.dataGridViewCustomizableFields.TabIndex = 0;
            this.dataGridViewCustomizableFields.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCustomizableFields_CellContentDoubleClick);
            // 
            // Columnadvfieldsid
            // 
            this.Columnadvfieldsid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnadvfieldsid.DataPropertyName = "advfieldsid";
            this.Columnadvfieldsid.HeaderText = "Id";
            this.Columnadvfieldsid.Name = "Columnadvfieldsid";
            this.Columnadvfieldsid.ReadOnly = true;
            this.Columnadvfieldsid.Width = 40;
            // 
            // Columnfieldscount
            // 
            this.Columnfieldscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnfieldscount.DataPropertyName = "fieldscount";
            this.Columnfieldscount.HeaderText = "Fields Number";
            this.Columnfieldscount.Name = "Columnfieldscount";
            this.Columnfieldscount.ReadOnly = true;
            // 
            // Columnfieldnameslist
            // 
            this.Columnfieldnameslist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnfieldnameslist.DataPropertyName = "fieldnameslist";
            this.Columnfieldnameslist.HeaderText = "Fields";
            this.Columnfieldnameslist.Name = "Columnfieldnameslist";
            this.Columnfieldnameslist.ReadOnly = true;
            // 
            // CustomizableFieldsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(699, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomizableFieldsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customizable Fields";
            this.Load += new System.EventHandler(this.CustomizableFieldsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomizableFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomizableFields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnViewDetails;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnEdit;
        private System.Windows.Forms.DataGridView dataGridViewCustomizableFields;
        private System.Windows.Forms.BindingSource bindingSourceCustomizableFields;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnadvfieldsid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnfieldscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnfieldnameslist;
    }
}
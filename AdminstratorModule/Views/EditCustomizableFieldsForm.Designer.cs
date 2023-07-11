namespace AdminstratorModule.Views
{
    partial class EditCustomizableFieldsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCustomizableFieldsForm));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAdvancedFields = new System.Windows.Forms.DataGridView();
            this.Column_advnsdfldid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columndesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnis_mandatory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Columnis_unique = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboAdvancedFieldEntities = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.txtattFieldDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkattUnique = new System.Windows.Forms.CheckBox();
            this.chkattMandatory = new System.Windows.Forms.CheckBox();
            this.lblattFieldName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboAdvancedFieldTypes = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkUnique = new System.Windows.Forms.CheckBox();
            this.chkMandatory = new System.Windows.Forms.CheckBox();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.btnDeleteField = new System.Windows.Forms.LinkLabel();
            this.btnAddField = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstCollections = new System.Windows.Forms.ListBox();
            this.btnDeleteItem = new System.Windows.Forms.LinkLabel();
            this.btnAddItem = new System.Windows.Forms.LinkLabel();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceAdvancedFields = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceAdvancedFieldsCollections = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdvancedFields)).BeginInit();
            this.gbAttributes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAdvancedFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAdvancedFieldsCollections)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 461);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(622, 56);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(315, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(206, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(81, 25);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = true;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpdate_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewAdvancedFields);
            this.groupBox1.Controls.Add(this.cboAdvancedFieldEntities);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewAdvancedFields
            // 
            this.dataGridViewAdvancedFields.AllowUserToAddRows = false;
            this.dataGridViewAdvancedFields.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAdvancedFields.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAdvancedFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdvancedFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_advnsdfldid,
            this.Columnname,
            this.Columndesc,
            this.Columnis_mandatory,
            this.Columnis_unique});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAdvancedFields.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAdvancedFields.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewAdvancedFields.Location = new System.Drawing.Point(3, 46);
            this.dataGridViewAdvancedFields.Name = "dataGridViewAdvancedFields";
            this.dataGridViewAdvancedFields.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAdvancedFields.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAdvancedFields.Size = new System.Drawing.Size(616, 139);
            this.dataGridViewAdvancedFields.TabIndex = 1;
            this.dataGridViewAdvancedFields.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAdvancedFields_CellClick);
            this.dataGridViewAdvancedFields.SelectionChanged += new System.EventHandler(this.dataGridViewAdvancedFields_SelectionChanged);
            // 
            // Column_advnsdfldid
            // 
            this.Column_advnsdfldid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_advnsdfldid.DataPropertyName = "_advnsdfldid";
            this.Column_advnsdfldid.HeaderText = "Id";
            this.Column_advnsdfldid.Name = "Column_advnsdfldid";
            this.Column_advnsdfldid.ReadOnly = true;
            this.Column_advnsdfldid.Width = 40;
            // 
            // Columnname
            // 
            this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnname.DataPropertyName = "name";
            this.Columnname.HeaderText = "Name";
            this.Columnname.Name = "Columnname";
            this.Columnname.ReadOnly = true;
            // 
            // Columndesc
            // 
            this.Columndesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columndesc.DataPropertyName = "desc";
            this.Columndesc.HeaderText = "Description";
            this.Columndesc.Name = "Columndesc";
            this.Columndesc.ReadOnly = true;
            // 
            // Columnis_mandatory
            // 
            this.Columnis_mandatory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnis_mandatory.DataPropertyName = "is_mandatory";
            this.Columnis_mandatory.HeaderText = "Mandatory";
            this.Columnis_mandatory.Name = "Columnis_mandatory";
            this.Columnis_mandatory.ReadOnly = true;
            this.Columnis_mandatory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Columnis_mandatory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Columnis_mandatory.Width = 80;
            // 
            // Columnis_unique
            // 
            this.Columnis_unique.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnis_unique.DataPropertyName = "is_unique";
            this.Columnis_unique.HeaderText = "Unique";
            this.Columnis_unique.Name = "Columnis_unique";
            this.Columnis_unique.ReadOnly = true;
            this.Columnis_unique.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Columnis_unique.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboAdvancedFieldEntities
            // 
            this.cboAdvancedFieldEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdvancedFieldEntities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAdvancedFieldEntities.FormattingEnabled = true;
            this.cboAdvancedFieldEntities.Location = new System.Drawing.Point(140, 19);
            this.cboAdvancedFieldEntities.Name = "cboAdvancedFieldEntities";
            this.cboAdvancedFieldEntities.Size = new System.Drawing.Size(354, 21);
            this.cboAdvancedFieldEntities.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customizable Fields For:*";
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.txtattFieldDescription);
            this.gbAttributes.Controls.Add(this.label6);
            this.gbAttributes.Controls.Add(this.label8);
            this.gbAttributes.Controls.Add(this.chkattUnique);
            this.gbAttributes.Controls.Add(this.chkattMandatory);
            this.gbAttributes.Controls.Add(this.lblattFieldName);
            this.gbAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAttributes.Location = new System.Drawing.Point(0, 188);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(622, 96);
            this.gbAttributes.TabIndex = 3;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Attributes";
            // 
            // txtattFieldDescription
            // 
            this.txtattFieldDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtattFieldDescription.Location = new System.Drawing.Point(83, 34);
            this.txtattFieldDescription.Multiline = true;
            this.txtattFieldDescription.Name = "txtattFieldDescription";
            this.txtattFieldDescription.Size = new System.Drawing.Size(186, 52);
            this.txtattFieldDescription.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Name:";
            // 
            // chkattUnique
            // 
            this.chkattUnique.AutoSize = true;
            this.chkattUnique.Enabled = false;
            this.chkattUnique.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkattUnique.Location = new System.Drawing.Point(275, 69);
            this.chkattUnique.Name = "chkattUnique";
            this.chkattUnique.Size = new System.Drawing.Size(57, 17);
            this.chkattUnique.TabIndex = 2;
            this.chkattUnique.Text = "Unique";
            this.chkattUnique.UseVisualStyleBackColor = true;
            // 
            // chkattMandatory
            // 
            this.chkattMandatory.AutoSize = true;
            this.chkattMandatory.Enabled = false;
            this.chkattMandatory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkattMandatory.Location = new System.Drawing.Point(275, 49);
            this.chkattMandatory.Name = "chkattMandatory";
            this.chkattMandatory.Size = new System.Drawing.Size(73, 17);
            this.chkattMandatory.TabIndex = 1;
            this.chkattMandatory.Text = "Mandatory";
            this.chkattMandatory.UseVisualStyleBackColor = true;
            // 
            // lblattFieldName
            // 
            this.lblattFieldName.AutoSize = true;
            this.lblattFieldName.Location = new System.Drawing.Point(80, 17);
            this.lblattFieldName.Name = "lblattFieldName";
            this.lblattFieldName.Size = new System.Drawing.Size(35, 13);
            this.lblattFieldName.TabIndex = 2;
            this.lblattFieldName.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboAdvancedFieldTypes);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.chkUnique);
            this.groupBox2.Controls.Add(this.chkMandatory);
            this.groupBox2.Controls.Add(this.txtFieldName);
            this.groupBox2.Controls.Add(this.btnDeleteField);
            this.groupBox2.Controls.Add(this.btnAddField);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add New Field";
            // 
            // cboAdvancedFieldTypes
            // 
            this.cboAdvancedFieldTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdvancedFieldTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAdvancedFieldTypes.FormattingEnabled = true;
            this.cboAdvancedFieldTypes.Location = new System.Drawing.Point(83, 85);
            this.cboAdvancedFieldTypes.Name = "cboAdvancedFieldTypes";
            this.cboAdvancedFieldTypes.Size = new System.Drawing.Size(153, 21);
            this.cboAdvancedFieldTypes.TabIndex = 2;
            this.cboAdvancedFieldTypes.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(83, 56);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(153, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // chkUnique
            // 
            this.chkUnique.AutoSize = true;
            this.chkUnique.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUnique.Location = new System.Drawing.Point(188, 125);
            this.chkUnique.Name = "chkUnique";
            this.chkUnique.Size = new System.Drawing.Size(57, 17);
            this.chkUnique.TabIndex = 4;
            this.chkUnique.Text = "Unique";
            this.chkUnique.UseVisualStyleBackColor = true;
            // 
            // chkMandatory
            // 
            this.chkMandatory.AutoSize = true;
            this.chkMandatory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMandatory.Location = new System.Drawing.Point(92, 125);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(73, 17);
            this.chkMandatory.TabIndex = 3;
            this.chkMandatory.Text = "Mandatory";
            this.chkMandatory.UseVisualStyleBackColor = true;
            // 
            // txtFieldName
            // 
            this.txtFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFieldName.Location = new System.Drawing.Point(83, 23);
            this.txtFieldName.MaxLength = 100;
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(153, 20);
            this.txtFieldName.TabIndex = 0;
            this.txtFieldName.TextChanged += new System.EventHandler(this.txtFieldName_TextChanged);
            // 
            // btnDeleteField
            // 
            this.btnDeleteField.AutoSize = true;
            this.btnDeleteField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteField.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteField.Location = new System.Drawing.Point(151, 152);
            this.btnDeleteField.Name = "btnDeleteField";
            this.btnDeleteField.Size = new System.Drawing.Size(54, 16);
            this.btnDeleteField.TabIndex = 6;
            this.btnDeleteField.TabStop = true;
            this.btnDeleteField.Text = "Delete";
            this.btnDeleteField.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteField_LinkClicked);
            // 
            // btnAddField
            // 
            this.btnAddField.AutoSize = true;
            this.btnAddField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddField.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddField.Location = new System.Drawing.Point(92, 152);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(36, 16);
            this.btnAddField.TabIndex = 5;
            this.btnAddField.TabStop = true;
            this.btnAddField.Text = "Add";
            this.btnAddField.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddField_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Attributes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Type:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Description:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Field Name:*";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstCollections);
            this.groupBox3.Controls.Add(this.btnDeleteItem);
            this.groupBox3.Controls.Add(this.btnAddItem);
            this.groupBox3.Controls.Add(this.txtItem);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(275, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 177);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Collection Items";
            // 
            // lstCollections
            // 
            this.lstCollections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCollections.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstCollections.FormattingEnabled = true;
            this.lstCollections.Location = new System.Drawing.Point(3, 16);
            this.lstCollections.Name = "lstCollections";
            this.lstCollections.Size = new System.Drawing.Size(153, 158);
            this.lstCollections.TabIndex = 3;
            this.lstCollections.SelectedIndexChanged += new System.EventHandler(this.lstCollections_SelectedIndexChanged);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.AutoSize = true;
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteItem.Location = new System.Drawing.Point(232, 108);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(54, 16);
            this.btnDeleteItem.TabIndex = 2;
            this.btnDeleteItem.TabStop = true;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteItem_LinkClicked);
            // 
            // btnAddItem
            // 
            this.btnAddItem.AutoSize = true;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddItem.Location = new System.Drawing.Point(182, 108);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(36, 16);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.TabStop = true;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddItem_LinkClicked);
            // 
            // txtItem
            // 
            this.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItem.Location = new System.Drawing.Point(178, 46);
            this.txtItem.MaxLength = 100;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(109, 20);
            this.txtItem.TabIndex = 0;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Item Name:*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditCustomizableFieldsForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(622, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbAttributes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditCustomizableFieldsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
                "                                                                            ";
            this.Load += new System.EventHandler(this.EditCustomizableFieldsForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdvancedFields)).EndInit();
            this.gbAttributes.ResumeLayout(false);
            this.gbAttributes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAdvancedFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAdvancedFieldsCollections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewAdvancedFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_advnsdfldid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndesc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Columnis_mandatory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Columnis_unique;
        private System.Windows.Forms.ComboBox cboAdvancedFieldEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.TextBox txtattFieldDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkattUnique;
        private System.Windows.Forms.CheckBox chkattMandatory;
        private System.Windows.Forms.Label lblattFieldName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboAdvancedFieldTypes;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkUnique;
        private System.Windows.Forms.CheckBox chkMandatory;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.LinkLabel btnDeleteField;
        private System.Windows.Forms.LinkLabel btnAddField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstCollections;
        private System.Windows.Forms.LinkLabel btnDeleteItem;
        private System.Windows.Forms.LinkLabel btnAddItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSourceAdvancedFields;
        private System.Windows.Forms.BindingSource bindingSourceAdvancedFieldsCollections;


    }
}
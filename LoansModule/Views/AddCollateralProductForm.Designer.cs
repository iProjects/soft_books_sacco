namespace LoansModule.Views
{
    partial class AddCollateralProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCollateralProductForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewCollateralProperties = new System.Windows.Forms.DataGridView();
            this.Column_collateralpropertyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columndesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPropertyDescription = new System.Windows.Forms.TextBox();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.txtattPropertyDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblattPropertyName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCollateralPropertyTypes = new System.Windows.Forms.ComboBox();
            this.btnDeleteProperty = new System.Windows.Forms.LinkLabel();
            this.btnAddProperty = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstCollections = new System.Windows.Forms.ListBox();
            this.btnDeleteItem = new System.Windows.Forms.LinkLabel();
            this.btnAddItem = new System.Windows.Forms.LinkLabel();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bindingSourceCollateralPropertyCollections = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceCollateralProperties = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollateralProperties)).BeginInit();
            this.gbAttributes.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollateralPropertyCollections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollateralProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProductDescription);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridViewCollateralProperties);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductDescription.Location = new System.Drawing.Point(133, 51);
            this.txtProductDescription.MaxLength = 100;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(382, 20);
            this.txtProductDescription.TabIndex = 1;
            this.txtProductDescription.TextChanged += new System.EventHandler(this.txtProductDescription_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Location = new System.Drawing.Point(133, 18);
            this.txtProductName.MaxLength = 100;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(382, 20);
            this.txtProductName.TabIndex = 0;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name*";
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
            this.Column_collateralpropertyid,
            this.Columnname,
            this.Columndesc});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCollateralProperties.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCollateralProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewCollateralProperties.Location = new System.Drawing.Point(3, 83);
            this.dataGridViewCollateralProperties.Name = "dataGridViewCollateralProperties";
            this.dataGridViewCollateralProperties.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCollateralProperties.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCollateralProperties.Size = new System.Drawing.Size(616, 139);
            this.dataGridViewCollateralProperties.TabIndex = 2;
            this.dataGridViewCollateralProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCollateralProperties_CellClick);
            this.dataGridViewCollateralProperties.SelectionChanged += new System.EventHandler(this.dataGridViewCollateralProperties_SelectionChanged);
            // 
            // Column_collateralpropertyid
            // 
            this.Column_collateralpropertyid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_collateralpropertyid.DataPropertyName = "_collateralpropertyid";
            this.Column_collateralpropertyid.HeaderText = "Id";
            this.Column_collateralpropertyid.Name = "Column_collateralpropertyid";
            this.Column_collateralpropertyid.ReadOnly = true;
            this.Column_collateralpropertyid.Width = 40;
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
            // Columndesc
            // 
            this.Columndesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columndesc.DataPropertyName = "desc";
            this.Columndesc.HeaderText = "Description";
            this.Columndesc.Name = "Columndesc";
            this.Columndesc.ReadOnly = true;
            this.Columndesc.Width = 200;
            // 
            // txtPropertyDescription
            // 
            this.txtPropertyDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPropertyDescription.Location = new System.Drawing.Point(83, 53);
            this.txtPropertyDescription.MaxLength = 100;
            this.txtPropertyDescription.Name = "txtPropertyDescription";
            this.txtPropertyDescription.Size = new System.Drawing.Size(153, 20);
            this.txtPropertyDescription.TabIndex = 1;
            this.txtPropertyDescription.TextChanged += new System.EventHandler(this.txtPropertyDescription_TextChanged);
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPropertyName.Location = new System.Drawing.Point(83, 20);
            this.txtPropertyName.MaxLength = 100;
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(153, 20);
            this.txtPropertyName.TabIndex = 0;
            this.txtPropertyName.TextChanged += new System.EventHandler(this.txtPropertyName_TextChanged);
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.txtattPropertyDescription);
            this.gbAttributes.Controls.Add(this.label6);
            this.gbAttributes.Controls.Add(this.label8);
            this.gbAttributes.Controls.Add(this.lblattPropertyName);
            this.gbAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAttributes.Location = new System.Drawing.Point(0, 225);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(622, 96);
            this.gbAttributes.TabIndex = 4;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Attributes";
            // 
            // txtattPropertyDescription
            // 
            this.txtattPropertyDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtattPropertyDescription.Location = new System.Drawing.Point(83, 34);
            this.txtattPropertyDescription.Multiline = true;
            this.txtattPropertyDescription.Name = "txtattPropertyDescription";
            this.txtattPropertyDescription.Size = new System.Drawing.Size(186, 52);
            this.txtattPropertyDescription.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Name:";
            // 
            // lblattPropertyName
            // 
            this.lblattPropertyName.AutoSize = true;
            this.lblattPropertyName.Location = new System.Drawing.Point(80, 17);
            this.lblattPropertyName.Name = "lblattPropertyName";
            this.lblattPropertyName.Size = new System.Drawing.Size(35, 13);
            this.lblattPropertyName.TabIndex = 2;
            this.lblattPropertyName.Text = "Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 481);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(622, 36);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(308, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 17);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(229, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 17);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPropertyDescription);
            this.groupBox2.Controls.Add(this.cboCollateralPropertyTypes);
            this.groupBox2.Controls.Add(this.txtPropertyName);
            this.groupBox2.Controls.Add(this.btnDeleteProperty);
            this.groupBox2.Controls.Add(this.btnAddProperty);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add New Property";
            // 
            // cboCollateralPropertyTypes
            // 
            this.cboCollateralPropertyTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCollateralPropertyTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCollateralPropertyTypes.FormattingEnabled = true;
            this.cboCollateralPropertyTypes.Location = new System.Drawing.Point(83, 85);
            this.cboCollateralPropertyTypes.Name = "cboCollateralPropertyTypes";
            this.cboCollateralPropertyTypes.Size = new System.Drawing.Size(153, 21);
            this.cboCollateralPropertyTypes.TabIndex = 2;
            this.cboCollateralPropertyTypes.SelectedIndexChanged += new System.EventHandler(this.cboCollateralPropertyTypes_SelectedIndexChanged);
            // 
            // btnDeleteProperty
            // 
            this.btnDeleteProperty.AutoSize = true;
            this.btnDeleteProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProperty.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteProperty.Location = new System.Drawing.Point(153, 114);
            this.btnDeleteProperty.Name = "btnDeleteProperty";
            this.btnDeleteProperty.Size = new System.Drawing.Size(54, 16);
            this.btnDeleteProperty.TabIndex = 4;
            this.btnDeleteProperty.TabStop = true;
            this.btnDeleteProperty.Text = "Delete";
            this.btnDeleteProperty.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteProperty_LinkClicked);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.AutoSize = true;
            this.btnAddProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProperty.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddProperty.Location = new System.Drawing.Point(94, 114);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(36, 16);
            this.btnAddProperty.TabIndex = 3;
            this.btnAddProperty.TabStop = true;
            this.btnAddProperty.Text = "Add";
            this.btnAddProperty.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddProperty_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Type*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name*";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstCollections);
            this.groupBox3.Controls.Add(this.btnDeleteItem);
            this.groupBox3.Controls.Add(this.btnAddItem);
            this.groupBox3.Controls.Add(this.txtItem);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(275, 321);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 160);
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
            this.lstCollections.Size = new System.Drawing.Size(153, 141);
            this.lstCollections.TabIndex = 3;
            this.lstCollections.SelectedIndexChanged += new System.EventHandler(this.lstCollections_SelectedIndexChanged);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.AutoSize = true;
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteItem.Location = new System.Drawing.Point(228, 90);
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
            this.btnAddItem.Location = new System.Drawing.Point(178, 90);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Item Name*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "_collateralpropertyid";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "desc";
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // AddCollateralProductForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(622, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbAttributes);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCollateralProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Collateral";
            this.Load += new System.EventHandler(this.AddCollateralProductForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollateralProperties)).EndInit();
            this.gbAttributes.ResumeLayout(false);
            this.gbAttributes.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollateralPropertyCollections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollateralProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewCollateralProperties;
        private System.Windows.Forms.TextBox txtPropertyDescription;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.TextBox txtattPropertyDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblattPropertyName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCollateralPropertyTypes;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.LinkLabel btnDeleteProperty;
        private System.Windows.Forms.LinkLabel btnAddProperty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstCollections;
        private System.Windows.Forms.LinkLabel btnDeleteItem;
        private System.Windows.Forms.LinkLabel btnAddItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bindingSourceCollateralPropertyCollections;
        private System.Windows.Forms.BindingSource bindingSourceCollateralProperties;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_collateralpropertyid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;


    }
}
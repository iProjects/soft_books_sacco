namespace SearchModule.Views
{
    partial class SearchPersonClientsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpConjuction = new System.Windows.Forms.GroupBox();
            this.rbOr = new System.Windows.Forms.RadioButton();
            this.rbAnd = new System.Windows.Forms.RadioButton();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstCriteria = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.cbField = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.ColumnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateofBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIDNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.bindingSourceClients = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbGroupsandPersons = new System.Windows.Forms.RadioButton();
            this.rdbCorporate = new System.Windows.Forms.RadioButton();
            this.chkPersons = new System.Windows.Forms.CheckBox();
            this.chkSolidarity = new System.Windows.Forms.CheckBox();
            this.chkNonSolidarity = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpConjuction.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClients)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.grpConjuction);
            this.groupBox1.Controls.Add(this.btnRetrieve);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.lstCriteria);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.cbOperator);
            this.groupBox1.Controls.Add(this.cbField);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Please define a criteria";
            // 
            // grpConjuction
            // 
            this.grpConjuction.BackColor = System.Drawing.Color.CornflowerBlue;
            this.grpConjuction.Controls.Add(this.rbOr);
            this.grpConjuction.Controls.Add(this.rbAnd);
            this.grpConjuction.Location = new System.Drawing.Point(462, 19);
            this.grpConjuction.Name = "grpConjuction";
            this.grpConjuction.Size = new System.Drawing.Size(104, 92);
            this.grpConjuction.TabIndex = 25;
            this.grpConjuction.TabStop = false;
            this.grpConjuction.Text = "Conjuction";
            // 
            // rbOr
            // 
            this.rbOr.AutoSize = true;
            this.rbOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOr.Location = new System.Drawing.Point(24, 52);
            this.rbOr.Name = "rbOr";
            this.rbOr.Size = new System.Drawing.Size(47, 20);
            this.rbOr.TabIndex = 1;
            this.rbOr.Text = "OR";
            this.rbOr.UseVisualStyleBackColor = true;
            // 
            // rbAnd
            // 
            this.rbAnd.AutoSize = true;
            this.rbAnd.Checked = true;
            this.rbAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnd.Location = new System.Drawing.Point(24, 20);
            this.rbAnd.Name = "rbAnd";
            this.rbAnd.Size = new System.Drawing.Size(57, 20);
            this.rbAnd.TabIndex = 0;
            this.rbAnd.TabStop = true;
            this.rbAnd.Text = "AND";
            this.rbAnd.UseVisualStyleBackColor = true;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRetrieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetrieve.Location = new System.Drawing.Point(823, 197);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 24;
            this.btnRetrieve.Text = "Preview";
            this.btnRetrieve.UseVisualStyleBackColor = false;
            this.btnRetrieve.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(823, 125);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstCriteria
            // 
            this.lstCriteria.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lstCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCriteria.DisplayMember = "CriteriaString";
            this.lstCriteria.FormattingEnabled = true;
            this.lstCriteria.Location = new System.Drawing.Point(30, 152);
            this.lstCriteria.Name = "lstCriteria";
            this.lstCriteria.Size = new System.Drawing.Size(536, 80);
            this.lstCriteria.TabIndex = 22;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(823, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtValue
            // 
            this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValue.Location = new System.Drawing.Point(322, 119);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(244, 20);
            this.txtValue.TabIndex = 20;
            // 
            // cbOperator
            // 
            this.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperator.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Location = new System.Drawing.Point(170, 118);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(133, 21);
            this.cbOperator.TabIndex = 19;
            // 
            // cbField
            // 
            this.cbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbField.FormattingEnabled = true;
            this.cbField.Location = new System.Drawing.Point(30, 118);
            this.cbField.Name = "cbField";
            this.cbField.Size = new System.Drawing.Size(121, 21);
            this.cbField.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewClients);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(912, 313);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.AllowUserToAddRows = false;
            this.dataGridViewClients.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFirstName,
            this.ColumnLastName,
            this.ColumnDateofBirth,
            this.ColumnGender,
            this.ColumnIDNo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewClients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClients.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewClients.MultiSelect = false;
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewClients.Size = new System.Drawing.Size(797, 294);
            this.dataGridViewClients.TabIndex = 27;
            // 
            // ColumnFirstName
            // 
            this.ColumnFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnFirstName.DataPropertyName = "FirstName";
            this.ColumnFirstName.HeaderText = "First Name";
            this.ColumnFirstName.MinimumWidth = 10;
            this.ColumnFirstName.Name = "ColumnFirstName";
            this.ColumnFirstName.ReadOnly = true;
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnLastName.DataPropertyName = "LastName";
            this.ColumnLastName.HeaderText = "Last Name";
            this.ColumnLastName.MinimumWidth = 10;
            this.ColumnLastName.Name = "ColumnLastName";
            this.ColumnLastName.ReadOnly = true;
            // 
            // ColumnDateofBirth
            // 
            this.ColumnDateofBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnDateofBirth.DataPropertyName = "DateofBirth";
            this.ColumnDateofBirth.HeaderText = "Date of Birth";
            this.ColumnDateofBirth.MinimumWidth = 10;
            this.ColumnDateofBirth.Name = "ColumnDateofBirth";
            this.ColumnDateofBirth.ReadOnly = true;
            // 
            // ColumnGender
            // 
            this.ColumnGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnGender.DataPropertyName = "Gender";
            this.ColumnGender.HeaderText = "Gender";
            this.ColumnGender.MinimumWidth = 10;
            this.ColumnGender.Name = "ColumnGender";
            this.ColumnGender.ReadOnly = true;
            // 
            // ColumnIDNo
            // 
            this.ColumnIDNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIDNo.DataPropertyName = "IDNo";
            this.ColumnIDNo.HeaderText = "ID No";
            this.ColumnIDNo.MinimumWidth = 10;
            this.ColumnIDNo.Name = "ColumnIDNo";
            this.ColumnIDNo.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSubmit);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(800, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 294);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(23, 109);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(23, 60);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox4.Controls.Add(this.chkNonSolidarity);
            this.groupBox4.Controls.Add(this.chkSolidarity);
            this.groupBox4.Controls.Add(this.chkPersons);
            this.groupBox4.Controls.Add(this.rdbCorporate);
            this.groupBox4.Controls.Add(this.rdbGroupsandPersons);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(297, 92);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Client Type";
            // 
            // rdbGroupsandPersons
            // 
            this.rdbGroupsandPersons.AutoSize = true;
            this.rdbGroupsandPersons.Checked = true;
            this.rdbGroupsandPersons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbGroupsandPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbGroupsandPersons.Location = new System.Drawing.Point(24, 16);
            this.rdbGroupsandPersons.Name = "rdbGroupsandPersons";
            this.rdbGroupsandPersons.Size = new System.Drawing.Size(137, 20);
            this.rdbGroupsandPersons.TabIndex = 0;
            this.rdbGroupsandPersons.Text = "Groups/Persons";
            this.rdbGroupsandPersons.UseVisualStyleBackColor = true;
            // 
            // rdbCorporate
            // 
            this.rdbCorporate.AutoSize = true;
            this.rdbCorporate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbCorporate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCorporate.Location = new System.Drawing.Point(24, 65);
            this.rdbCorporate.Name = "rdbCorporate";
            this.rdbCorporate.Size = new System.Drawing.Size(94, 20);
            this.rdbCorporate.TabIndex = 3;
            this.rdbCorporate.Text = "Corporate";
            this.rdbCorporate.UseVisualStyleBackColor = true;
            // 
            // chkPersons
            // 
            this.chkPersons.AutoSize = true;
            this.chkPersons.Checked = true;
            this.chkPersons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPersons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPersons.Location = new System.Drawing.Point(24, 44);
            this.chkPersons.Name = "chkPersons";
            this.chkPersons.Size = new System.Drawing.Size(61, 17);
            this.chkPersons.TabIndex = 4;
            this.chkPersons.Text = "Persons";
            this.chkPersons.UseVisualStyleBackColor = true;
            // 
            // chkSolidarity
            // 
            this.chkSolidarity.AutoSize = true;
            this.chkSolidarity.Checked = true;
            this.chkSolidarity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSolidarity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSolidarity.Location = new System.Drawing.Point(111, 44);
            this.chkSolidarity.Name = "chkSolidarity";
            this.chkSolidarity.Size = new System.Drawing.Size(65, 17);
            this.chkSolidarity.TabIndex = 5;
            this.chkSolidarity.Text = "Solidarity";
            this.chkSolidarity.UseVisualStyleBackColor = true;
            // 
            // chkNonSolidarity
            // 
            this.chkNonSolidarity.AutoSize = true;
            this.chkNonSolidarity.Checked = true;
            this.chkNonSolidarity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNonSolidarity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNonSolidarity.Location = new System.Drawing.Point(194, 44);
            this.chkNonSolidarity.Name = "chkNonSolidarity";
            this.chkNonSolidarity.Size = new System.Drawing.Size(88, 17);
            this.chkNonSolidarity.TabIndex = 6;
            this.chkNonSolidarity.Text = "Non-Solidarity";
            this.chkNonSolidarity.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Location = new System.Drawing.Point(322, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(118, 92);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Client Type";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Location = new System.Drawing.Point(24, 55);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(73, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Not-Active";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Location = new System.Drawing.Point(24, 23);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(53, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Active";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(605, 35);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(22, 13);
            this.lblMessage.TabIndex = 28;
            this.lblMessage.Text = ":::::";
            // 
            // SearchPersonClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(912, 551);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchPersonClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Clients";
            this.Load += new System.EventHandler(this.SearchClientsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpConjuction.ResumeLayout(false);
            this.grpConjuction.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClients)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpConjuction;
        private System.Windows.Forms.RadioButton rbOr;
        private System.Windows.Forms.RadioButton rbAnd;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstCriteria;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cbOperator;
        private System.Windows.Forms.ComboBox cbField;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.BindingSource bindingSourceClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateofBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIDNo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkNonSolidarity;
        private System.Windows.Forms.CheckBox chkSolidarity;
        private System.Windows.Forms.CheckBox chkPersons;
        private System.Windows.Forms.RadioButton rdbCorporate;
        private System.Windows.Forms.RadioButton rdbGroupsandPersons;
        private System.Windows.Forms.Label lblMessage;

    }
}
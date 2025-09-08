namespace CustomerModule.Views
{
    partial class AddPersonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPersonForm));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceProvinces = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNoofYears = new System.Windows.Forms.Label();
            this.cboEconomicActivity = new System.Windows.Forms.ComboBox();
            this.dtpDateofBirth = new System.Windows.Forms.DateTimePicker();
            this.chkHeadofHouseHold = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUploadPersonPhoto = new System.Windows.Forms.LinkLabel();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.txtLoanCycle = new System.Windows.Forms.TextBox();
            this.txtCitizenShip = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtPlaceofBirth = new System.Windows.Forms.TextBox();
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkdisability = new System.Windows.Forms.CheckBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtphone_no = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProvinces)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblMessage);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(0, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(882, 49);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblMessage.Location = new System.Drawing.Point(335, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(304, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(373, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtphone_no);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.chkdisability);
            this.groupBox1.Controls.Add(this.cboBranch);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblNoofYears);
            this.groupBox1.Controls.Add(this.cboEconomicActivity);
            this.groupBox1.Controls.Add(this.dtpDateofBirth);
            this.groupBox1.Controls.Add(this.chkHeadofHouseHold);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtLoanCycle);
            this.groupBox1.Controls.Add(this.txtCitizenShip);
            this.groupBox1.Controls.Add(this.txtFatherName);
            this.groupBox1.Controls.Add(this.txtPlaceofBirth);
            this.groupBox1.Controls.Add(this.txtIDNo);
            this.groupBox1.Controls.Add(this.cboGender);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(376, 25);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(147, 21);
            this.cboBranch.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(329, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 452;
            this.label10.Text = "Branch*";
            // 
            // lblNoofYears
            // 
            this.lblNoofYears.AutoSize = true;
            this.lblNoofYears.Location = new System.Drawing.Point(228, 124);
            this.lblNoofYears.Name = "lblNoofYears";
            this.lblNoofYears.Size = new System.Drawing.Size(44, 13);
            this.lblNoofYears.TabIndex = 272;
            this.lblNoofYears.Text = "0  years";
            // 
            // cboEconomicActivity
            // 
            this.cboEconomicActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEconomicActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEconomicActivity.FormattingEnabled = true;
            this.cboEconomicActivity.Location = new System.Drawing.Point(376, 59);
            this.cboEconomicActivity.Name = "cboEconomicActivity";
            this.cboEconomicActivity.Size = new System.Drawing.Size(147, 21);
            this.cboEconomicActivity.TabIndex = 9;
            // 
            // dtpDateofBirth
            // 
            this.dtpDateofBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateofBirth.Location = new System.Drawing.Point(93, 118);
            this.dtpDateofBirth.Name = "dtpDateofBirth";
            this.dtpDateofBirth.Size = new System.Drawing.Size(129, 20);
            this.dtpDateofBirth.TabIndex = 3;
            this.dtpDateofBirth.ValueChanged += new System.EventHandler(this.dtpDateofBirth_ValueChanged);
            // 
            // chkHeadofHouseHold
            // 
            this.chkHeadofHouseHold.AutoSize = true;
            this.chkHeadofHouseHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHeadofHouseHold.Location = new System.Drawing.Point(376, 192);
            this.chkHeadofHouseHold.Name = "chkHeadofHouseHold";
            this.chkHeadofHouseHold.Size = new System.Drawing.Size(120, 17);
            this.chkHeadofHouseHold.TabIndex = 14;
            this.chkHeadofHouseHold.Text = "Head of House Hold";
            this.chkHeadofHouseHold.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUploadPersonPhoto);
            this.groupBox2.Controls.Add(this.pbPhoto);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(566, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 273);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PHOTO";
            // 
            // btnUploadPersonPhoto
            // 
            this.btnUploadPersonPhoto.AutoSize = true;
            this.btnUploadPersonPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPersonPhoto.LinkColor = System.Drawing.Color.Yellow;
            this.btnUploadPersonPhoto.Location = new System.Drawing.Point(17, 243);
            this.btnUploadPersonPhoto.Name = "btnUploadPersonPhoto";
            this.btnUploadPersonPhoto.Size = new System.Drawing.Size(59, 16);
            this.btnUploadPersonPhoto.TabIndex = 0;
            this.btnUploadPersonPhoto.TabStop = true;
            this.btnUploadPersonPhoto.Text = "Upload";
            this.btnUploadPersonPhoto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpload_LinkClicked);
            // 
            // pbPhoto
            // 
            this.pbPhoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPhoto.ErrorImage = global::CustomerModule.Properties.Resources.defaultphoto;
            this.pbPhoto.Location = new System.Drawing.Point(3, 16);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(307, 224);
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // txtLoanCycle
            // 
            this.txtLoanCycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoanCycle.Location = new System.Drawing.Point(376, 93);
            this.txtLoanCycle.MaxLength = 4;
            this.txtLoanCycle.Name = "txtLoanCycle";
            this.txtLoanCycle.Size = new System.Drawing.Size(147, 20);
            this.txtLoanCycle.TabIndex = 10;
            // 
            // txtCitizenShip
            // 
            this.txtCitizenShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCitizenShip.Location = new System.Drawing.Point(376, 159);
            this.txtCitizenShip.MaxLength = 50;
            this.txtCitizenShip.Name = "txtCitizenShip";
            this.txtCitizenShip.Size = new System.Drawing.Size(147, 20);
            this.txtCitizenShip.TabIndex = 12;
            // 
            // txtFatherName
            // 
            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherName.Location = new System.Drawing.Point(93, 85);
            this.txtFatherName.MaxLength = 50;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(129, 20);
            this.txtFatherName.TabIndex = 2;
            // 
            // txtPlaceofBirth
            // 
            this.txtPlaceofBirth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaceofBirth.Location = new System.Drawing.Point(376, 126);
            this.txtPlaceofBirth.MaxLength = 50;
            this.txtPlaceofBirth.Name = "txtPlaceofBirth";
            this.txtPlaceofBirth.Size = new System.Drawing.Size(147, 20);
            this.txtPlaceofBirth.TabIndex = 11;
            // 
            // txtIDNo
            // 
            this.txtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDNo.Location = new System.Drawing.Point(93, 188);
            this.txtIDNo.MaxLength = 50;
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(129, 20);
            this.txtIDNo.TabIndex = 5;
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(93, 153);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(129, 21);
            this.cboGender.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Location = new System.Drawing.Point(93, 51);
            this.txtLastName.MaxLength = 100;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(129, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(93, 17);
            this.txtFirstName.MaxLength = 100;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(129, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(310, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 102;
            this.label11.Text = "Loan Cycle*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Citizenship*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Father\'s Name*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Place of Birth*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Economic Activity*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "ID No*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Gender*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Date of Birth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Last Name*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "First Name*";
            // 
            // chkdisability
            // 
            this.chkdisability.AutoSize = true;
            this.chkdisability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkdisability.Location = new System.Drawing.Point(377, 218);
            this.chkdisability.Name = "chkdisability";
            this.chkdisability.Size = new System.Drawing.Size(64, 17);
            this.chkdisability.TabIndex = 15;
            this.chkdisability.Text = "Disability";
            this.chkdisability.UseVisualStyleBackColor = true;
            // 
            // txtemail
            // 
            this.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtemail.Location = new System.Drawing.Point(93, 224);
            this.txtemail.MaxLength = 50;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(129, 20);
            this.txtemail.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 455;
            this.label12.Text = "Email*";
            // 
            // txtphone_no
            // 
            this.txtphone_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtphone_no.Location = new System.Drawing.Point(93, 260);
            this.txtphone_no.MaxLength = 50;
            this.txtphone_no.Name = "txtphone_no";
            this.txtphone_no.Size = new System.Drawing.Size(129, 20);
            this.txtphone_no.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 457;
            this.label13.Text = "Phone No*";
            // 
            // AddPersonForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(882, 341);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPersonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Person";
            this.Load += new System.EventHandler(this.AddPersonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProvinces)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bindingSourceProvinces;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNoofYears;
        private System.Windows.Forms.ComboBox cboEconomicActivity;
        private System.Windows.Forms.DateTimePicker dtpDateofBirth;
        private System.Windows.Forms.CheckBox chkHeadofHouseHold;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnUploadPersonPhoto;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.TextBox txtLoanCycle;
        private System.Windows.Forms.TextBox txtCitizenShip;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtPlaceofBirth;
        private System.Windows.Forms.TextBox txtIDNo;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.TextBox txtphone_no;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkdisability;
    }
}
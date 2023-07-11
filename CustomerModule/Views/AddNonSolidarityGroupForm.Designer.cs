namespace CustomerModule.Views
{
    partial class AddNonSolidarityGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNonSolidarityGroupForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboGroupOfficer = new System.Windows.Forms.ComboBox();
            this.cboMeetingDate = new System.Windows.Forms.ComboBox();
            this.chkSetMeetingDate = new System.Windows.Forms.CheckBox();
            this.dtpEstablishmentDate = new System.Windows.Forms.DateTimePicker();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUploadNonSolidarityGroupPhoto = new System.Windows.Forms.LinkLabel();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceBank = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceOfficers = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOfficers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 329);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(900, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboBranch);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboGroupOfficer);
            this.groupBox1.Controls.Add(this.cboMeetingDate);
            this.groupBox1.Controls.Add(this.chkSetMeetingDate);
            this.groupBox1.Controls.Add(this.dtpEstablishmentDate);
            this.groupBox1.Controls.Add(this.txtGroupName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 236);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Non - Solidarity Group";
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(143, 178);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(178, 21);
            this.cboBranch.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Branch";
            // 
            // cboGroupOfficer
            // 
            this.cboGroupOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroupOfficer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGroupOfficer.FormattingEnabled = true;
            this.cboGroupOfficer.Location = new System.Drawing.Point(143, 102);
            this.cboGroupOfficer.Name = "cboGroupOfficer";
            this.cboGroupOfficer.Size = new System.Drawing.Size(178, 21);
            this.cboGroupOfficer.TabIndex = 62;
            // 
            // cboMeetingDate
            // 
            this.cboMeetingDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeetingDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMeetingDate.FormattingEnabled = true;
            this.cboMeetingDate.Location = new System.Drawing.Point(143, 140);
            this.cboMeetingDate.Name = "cboMeetingDate";
            this.cboMeetingDate.Size = new System.Drawing.Size(178, 21);
            this.cboMeetingDate.TabIndex = 61;
            // 
            // chkSetMeetingDate
            // 
            this.chkSetMeetingDate.AutoSize = true;
            this.chkSetMeetingDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSetMeetingDate.Location = new System.Drawing.Point(345, 137);
            this.chkSetMeetingDate.Name = "chkSetMeetingDate";
            this.chkSetMeetingDate.Size = new System.Drawing.Size(106, 17);
            this.chkSetMeetingDate.TabIndex = 60;
            this.chkSetMeetingDate.Text = "Set Meeting Date";
            this.chkSetMeetingDate.UseVisualStyleBackColor = true;
            this.chkSetMeetingDate.CheckedChanged += new System.EventHandler(this.chkSetMeetingDate_CheckedChanged);
            // 
            // dtpEstablishmentDate
            // 
            this.dtpEstablishmentDate.Location = new System.Drawing.Point(143, 65);
            this.dtpEstablishmentDate.Name = "dtpEstablishmentDate";
            this.dtpEstablishmentDate.Size = new System.Drawing.Size(175, 20);
            this.dtpEstablishmentDate.TabIndex = 59;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Location = new System.Drawing.Point(143, 28);
            this.txtGroupName.MaxLength = 200;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(339, 20);
            this.txtGroupName.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Meeting Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Group Officer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Date of Establishment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Name*";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUploadNonSolidarityGroupPhoto);
            this.groupBox3.Controls.Add(this.pbPhoto);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(521, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 217);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PHOTO";
            // 
            // btnUploadNonSolidarityGroupPhoto
            // 
            this.btnUploadNonSolidarityGroupPhoto.AutoSize = true;
            this.btnUploadNonSolidarityGroupPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadNonSolidarityGroupPhoto.LinkColor = System.Drawing.Color.Yellow;
            this.btnUploadNonSolidarityGroupPhoto.Location = new System.Drawing.Point(16, 192);
            this.btnUploadNonSolidarityGroupPhoto.Name = "btnUploadNonSolidarityGroupPhoto";
            this.btnUploadNonSolidarityGroupPhoto.Size = new System.Drawing.Size(59, 16);
            this.btnUploadNonSolidarityGroupPhoto.TabIndex = 1;
            this.btnUploadNonSolidarityGroupPhoto.TabStop = true;
            this.btnUploadNonSolidarityGroupPhoto.Text = "Upload";
            this.btnUploadNonSolidarityGroupPhoto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUploadNonSolidarityGroupPhoto_LinkClicked);
            // 
            // pbPhoto
            // 
            this.pbPhoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPhoto.ErrorImage = global::CustomerModule.Properties.Resources.defaultphoto;
            this.pbPhoto.Location = new System.Drawing.Point(3, 16);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(364, 169);
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(894, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(155, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 25);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(263, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddNonSolidarityGroupForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(908, 329);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNonSolidarityGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add NonSolidarity Group";
            this.Load += new System.EventHandler(this.AddNewNonSolidarityGroupForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOfficers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSourceBank;
        private System.Windows.Forms.BindingSource bindingSourceOfficers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboGroupOfficer;
        private System.Windows.Forms.ComboBox cboMeetingDate;
        private System.Windows.Forms.CheckBox chkSetMeetingDate;
        private System.Windows.Forms.DateTimePicker dtpEstablishmentDate;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel btnUploadNonSolidarityGroupPhoto;
        private System.Windows.Forms.PictureBox pbPhoto;
    }
}
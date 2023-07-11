namespace AdminstratorModule.Views
{
    partial class ContractCodeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCodeTemplate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkContractId = new System.Windows.Forms.CheckBox();
            this.chkClientId = new System.Windows.Forms.CheckBox();
            this.chkProjectCycle = new System.Windows.Forms.CheckBox();
            this.chkLoanCycle = new System.Windows.Forms.CheckBox();
            this.chkProductCode = new System.Windows.Forms.CheckBox();
            this.chkLoanOfficer = new System.Windows.Forms.CheckBox();
            this.chkYear = new System.Windows.Forms.CheckBox();
            this.chkDistrict = new System.Windows.Forms.CheckBox();
            this.chkBranchCode = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnOk.LinkColor = System.Drawing.Color.Yellow;
            this.btnOk.Location = new System.Drawing.Point(121, 16);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(36, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.TabStop = true;
            this.btnOk.Text = "Ok";
            this.btnOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnOk_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(184, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCodeTemplate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkContractId);
            this.groupBox2.Controls.Add(this.chkClientId);
            this.groupBox2.Controls.Add(this.chkProjectCycle);
            this.groupBox2.Controls.Add(this.chkLoanCycle);
            this.groupBox2.Controls.Add(this.chkProductCode);
            this.groupBox2.Controls.Add(this.chkLoanOfficer);
            this.groupBox2.Controls.Add(this.chkYear);
            this.groupBox2.Controls.Add(this.chkDistrict);
            this.groupBox2.Controls.Add(this.chkBranchCode);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 328);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Include the following Fields";
            // 
            // txtCodeTemplate
            // 
            this.txtCodeTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodeTemplate.Location = new System.Drawing.Point(21, 288);
            this.txtCodeTemplate.Name = "txtCodeTemplate";
            this.txtCodeTemplate.Size = new System.Drawing.Size(314, 21);
            this.txtCodeTemplate.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Contract Code Template";
            // 
            // chkContractId
            // 
            this.chkContractId.AutoSize = true;
            this.chkContractId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkContractId.Location = new System.Drawing.Point(20, 228);
            this.chkContractId.Name = "chkContractId";
            this.chkContractId.Size = new System.Drawing.Size(94, 19);
            this.chkContractId.TabIndex = 8;
            this.chkContractId.Text = "Contract ID";
            this.chkContractId.UseVisualStyleBackColor = true;
            this.chkContractId.CheckedChanged += new System.EventHandler(this.chkContractId_CheckedChanged);
            // 
            // chkClientId
            // 
            this.chkClientId.AutoSize = true;
            this.chkClientId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkClientId.Location = new System.Drawing.Point(21, 203);
            this.chkClientId.Name = "chkClientId";
            this.chkClientId.Size = new System.Drawing.Size(78, 19);
            this.chkClientId.TabIndex = 7;
            this.chkClientId.Text = "Client ID";
            this.chkClientId.UseVisualStyleBackColor = true;
            this.chkClientId.CheckedChanged += new System.EventHandler(this.chkClientId_CheckedChanged);
            // 
            // chkProjectCycle
            // 
            this.chkProjectCycle.AutoSize = true;
            this.chkProjectCycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProjectCycle.Location = new System.Drawing.Point(21, 178);
            this.chkProjectCycle.Name = "chkProjectCycle";
            this.chkProjectCycle.Size = new System.Drawing.Size(106, 19);
            this.chkProjectCycle.TabIndex = 6;
            this.chkProjectCycle.Text = "Project Cycle";
            this.chkProjectCycle.UseVisualStyleBackColor = true;
            this.chkProjectCycle.CheckedChanged += new System.EventHandler(this.chkProjectCycle_CheckedChanged);
            // 
            // chkLoanCycle
            // 
            this.chkLoanCycle.AutoSize = true;
            this.chkLoanCycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoanCycle.Location = new System.Drawing.Point(21, 155);
            this.chkLoanCycle.Name = "chkLoanCycle";
            this.chkLoanCycle.Size = new System.Drawing.Size(93, 19);
            this.chkLoanCycle.TabIndex = 5;
            this.chkLoanCycle.Text = "Loan Cycle";
            this.chkLoanCycle.UseVisualStyleBackColor = true;
            this.chkLoanCycle.CheckedChanged += new System.EventHandler(this.chkLoanCycle_CheckedChanged);
            // 
            // chkProductCode
            // 
            this.chkProductCode.AutoSize = true;
            this.chkProductCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProductCode.Location = new System.Drawing.Point(21, 132);
            this.chkProductCode.Name = "chkProductCode";
            this.chkProductCode.Size = new System.Drawing.Size(109, 19);
            this.chkProductCode.TabIndex = 4;
            this.chkProductCode.Text = "Product Code";
            this.chkProductCode.UseVisualStyleBackColor = true;
            this.chkProductCode.CheckedChanged += new System.EventHandler(this.chkProductCode_CheckedChanged);
            // 
            // chkLoanOfficer
            // 
            this.chkLoanOfficer.AutoSize = true;
            this.chkLoanOfficer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoanOfficer.Location = new System.Drawing.Point(21, 109);
            this.chkLoanOfficer.Name = "chkLoanOfficer";
            this.chkLoanOfficer.Size = new System.Drawing.Size(101, 19);
            this.chkLoanOfficer.TabIndex = 3;
            this.chkLoanOfficer.Text = "Loan Officer";
            this.chkLoanOfficer.UseVisualStyleBackColor = true;
            this.chkLoanOfficer.CheckedChanged += new System.EventHandler(this.chkLoanOfficer_CheckedChanged);
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkYear.Location = new System.Drawing.Point(21, 88);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(52, 19);
            this.chkYear.TabIndex = 2;
            this.chkYear.Text = "Year";
            this.chkYear.UseVisualStyleBackColor = true;
            this.chkYear.CheckedChanged += new System.EventHandler(this.chkYear_CheckedChanged);
            // 
            // chkDistrict
            // 
            this.chkDistrict.AutoSize = true;
            this.chkDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDistrict.Location = new System.Drawing.Point(21, 62);
            this.chkDistrict.Name = "chkDistrict";
            this.chkDistrict.Size = new System.Drawing.Size(68, 19);
            this.chkDistrict.TabIndex = 1;
            this.chkDistrict.Text = "District";
            this.chkDistrict.UseVisualStyleBackColor = true;
            this.chkDistrict.CheckedChanged += new System.EventHandler(this.chkDistrict_CheckedChanged);
            // 
            // chkBranchCode
            // 
            this.chkBranchCode.AutoSize = true;
            this.chkBranchCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBranchCode.Location = new System.Drawing.Point(21, 39);
            this.chkBranchCode.Name = "chkBranchCode";
            this.chkBranchCode.Size = new System.Drawing.Size(105, 19);
            this.chkBranchCode.TabIndex = 0;
            this.chkBranchCode.Text = "Branch Code";
            this.chkBranchCode.UseVisualStyleBackColor = true;
            this.chkBranchCode.CheckedChanged += new System.EventHandler(this.chkBranchCode_CheckedChanged);
            // 
            // ContractCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(371, 381);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContractCodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contract Code";
            this.Load += new System.EventHandler(this.ContractCodeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnOk;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.CheckBox chkContractId;
        private System.Windows.Forms.CheckBox chkClientId;
        private System.Windows.Forms.CheckBox chkProjectCycle;
        private System.Windows.Forms.CheckBox chkLoanCycle;
        private System.Windows.Forms.CheckBox chkProductCode;
        private System.Windows.Forms.CheckBox chkLoanOfficer;
        private System.Windows.Forms.CheckBox chkYear;
        private System.Windows.Forms.CheckBox chkDistrict;
        private System.Windows.Forms.CheckBox chkBranchCode;
        private System.Windows.Forms.TextBox txtCodeTemplate;
        private System.Windows.Forms.Label label1;
    }
}
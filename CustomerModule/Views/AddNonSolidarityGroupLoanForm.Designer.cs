namespace CustomerModule.Views
{
    partial class AddNonSolidarityGroupLoanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNonSolidarityGroupLoanForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnClose = new System.Windows.Forms.LinkLabel();
            this.btnConfirmLoanCreation = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewNonSolidarityGroupLoan = new System.Windows.Forms.ListView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnClose);
            this.groupBox2.Controls.Add(this.btnConfirmLoanCreation);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 430);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // bnClose
            // 
            this.bnClose.AutoSize = true;
            this.bnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnClose.LinkColor = System.Drawing.Color.Yellow;
            this.bnClose.Location = new System.Drawing.Point(621, 22);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(72, 25);
            this.bnClose.TabIndex = 9;
            this.bnClose.TabStop = true;
            this.bnClose.Text = "Close";
            this.bnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnConfirmLoanCreation
            // 
            this.btnConfirmLoanCreation.AutoSize = true;
            this.btnConfirmLoanCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmLoanCreation.LinkColor = System.Drawing.Color.Yellow;
            this.btnConfirmLoanCreation.Location = new System.Drawing.Point(421, 22);
            this.btnConfirmLoanCreation.Name = "btnConfirmLoanCreation";
            this.btnConfirmLoanCreation.Size = new System.Drawing.Size(189, 25);
            this.btnConfirmLoanCreation.TabIndex = 8;
            this.btnConfirmLoanCreation.TabStop = true;
            this.btnConfirmLoanCreation.Text = "Confirm Creation";
            this.btnConfirmLoanCreation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnConfirmLoanCreation_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewNonSolidarityGroupLoan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 430);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // listViewNonSolidarityGroupLoan
            // 
            this.listViewNonSolidarityGroupLoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewNonSolidarityGroupLoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNonSolidarityGroupLoan.Location = new System.Drawing.Point(3, 16);
            this.listViewNonSolidarityGroupLoan.Name = "listViewNonSolidarityGroupLoan";
            this.listViewNonSolidarityGroupLoan.Size = new System.Drawing.Size(726, 411);
            this.listViewNonSolidarityGroupLoan.TabIndex = 0;
            this.listViewNonSolidarityGroupLoan.UseCompatibleStateImageBehavior = false;
            // 
            // AddNonSolidarityGroupLoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(732, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNonSolidarityGroupLoanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Loan";
            this.Load += new System.EventHandler(this.AddNonSolidarityGroupLoanForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel bnClose;
        private System.Windows.Forms.LinkLabel btnConfirmLoanCreation;
        private System.Windows.Forms.ListView listViewNonSolidarityGroupLoan;
    }
}
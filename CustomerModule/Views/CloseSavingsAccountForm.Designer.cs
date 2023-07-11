namespace CustomerModule.Views
{
    partial class CloseSavingsAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseSavingsAccountForm));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCloseAccount = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblCloseFees = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.LinkLabel();
            this.txtTransactionAccount = new System.Windows.Forms.TextBox();
            this.lblAccountOwner = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonTransfer = new System.Windows.Forms.RadioButton();
            this.radioButtonWithdraw = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMinFees = new System.Windows.Forms.Label();
            this.lblMaxFees = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.NumericUpDown();
            this.chkDisableFees = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFees)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCloseAccount);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(515, 39);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // btnCloseAccount
            // 
            this.btnCloseAccount.AutoSize = true;
            this.btnCloseAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnCloseAccount.LinkColor = System.Drawing.Color.Yellow;
            this.btnCloseAccount.Location = new System.Drawing.Point(150, 12);
            this.btnCloseAccount.Name = "btnCloseAccount";
            this.btnCloseAccount.Size = new System.Drawing.Size(94, 18);
            this.btnCloseAccount.TabIndex = 17;
            this.btnCloseAccount.TabStop = true;
            this.btnCloseAccount.Text = "Close Fees";
            this.btnCloseAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCloseAccount_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(272, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.lblCloseFees);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Amount to Withdraw/Transfer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Close Fees:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(211, 13);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(147, 13);
            this.lblAmount.TabIndex = 49;
            this.lblAmount.Text = "Amount to Withdraw/Transfer";
            // 
            // lblCloseFees
            // 
            this.lblCloseFees.AutoSize = true;
            this.lblCloseFees.Location = new System.Drawing.Point(211, 36);
            this.lblCloseFees.Name = "lblCloseFees";
            this.lblCloseFees.Size = new System.Drawing.Size(59, 13);
            this.lblCloseFees.TabIndex = 48;
            this.lblCloseFees.Text = "Close Fees";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.radioButtonTransfer);
            this.groupBox2.Controls.Add(this.radioButtonWithdraw);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 92);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Which Action with the Amount";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSearch);
            this.groupBox5.Controls.Add(this.txtTransactionAccount);
            this.groupBox5.Controls.Add(this.lblAccountOwner);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(509, 47);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearch.LinkColor = System.Drawing.Color.Yellow;
            this.btnSearch.Location = new System.Drawing.Point(366, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 18);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.TabStop = true;
            this.btnSearch.Text = "Search";
            this.btnSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSearch_LinkClicked);
            // 
            // txtTransactionAccount
            // 
            this.txtTransactionAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionAccount.Location = new System.Drawing.Point(74, 10);
            this.txtTransactionAccount.Name = "txtTransactionAccount";
            this.txtTransactionAccount.Size = new System.Drawing.Size(277, 20);
            this.txtTransactionAccount.TabIndex = 57;
            // 
            // lblAccountOwner
            // 
            this.lblAccountOwner.AutoSize = true;
            this.lblAccountOwner.Location = new System.Drawing.Point(77, 31);
            this.lblAccountOwner.Name = "lblAccountOwner";
            this.lblAccountOwner.Size = new System.Drawing.Size(81, 13);
            this.lblAccountOwner.TabIndex = 56;
            this.lblAccountOwner.Text = "Account Owner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "To Account*";
            // 
            // radioButtonTransfer
            // 
            this.radioButtonTransfer.AutoSize = true;
            this.radioButtonTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonTransfer.Location = new System.Drawing.Point(173, 19);
            this.radioButtonTransfer.Name = "radioButtonTransfer";
            this.radioButtonTransfer.Size = new System.Drawing.Size(63, 17);
            this.radioButtonTransfer.TabIndex = 49;
            this.radioButtonTransfer.TabStop = true;
            this.radioButtonTransfer.Text = "Transfer";
            this.radioButtonTransfer.UseVisualStyleBackColor = true;
            this.radioButtonTransfer.CheckedChanged += new System.EventHandler(this.radioButtonTransfer_CheckedChanged);
            // 
            // radioButtonWithdraw
            // 
            this.radioButtonWithdraw.AutoSize = true;
            this.radioButtonWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonWithdraw.Location = new System.Drawing.Point(82, 19);
            this.radioButtonWithdraw.Name = "radioButtonWithdraw";
            this.radioButtonWithdraw.Size = new System.Drawing.Size(69, 17);
            this.radioButtonWithdraw.TabIndex = 48;
            this.radioButtonWithdraw.TabStop = true;
            this.radioButtonWithdraw.Text = "Withdraw";
            this.radioButtonWithdraw.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox3.Controls.Add(this.lblMinFees);
            this.groupBox3.Controls.Add(this.lblMaxFees);
            this.groupBox3.Controls.Add(this.txtFees);
            this.groupBox3.Controls.Add(this.chkDisableFees);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 61);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Close Fees";
            // 
            // lblMinFees
            // 
            this.lblMinFees.AutoSize = true;
            this.lblMinFees.Location = new System.Drawing.Point(349, 18);
            this.lblMinFees.Name = "lblMinFees";
            this.lblMinFees.Size = new System.Drawing.Size(24, 13);
            this.lblMinFees.TabIndex = 49;
            this.lblMinFees.Text = "Min";
            // 
            // lblMaxFees
            // 
            this.lblMaxFees.AutoSize = true;
            this.lblMaxFees.Location = new System.Drawing.Point(349, 38);
            this.lblMaxFees.Name = "lblMaxFees";
            this.lblMaxFees.Size = new System.Drawing.Size(27, 13);
            this.lblMaxFees.TabIndex = 48;
            this.lblMaxFees.Text = "Max";
            // 
            // txtFees
            // 
            this.txtFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFees.Location = new System.Drawing.Point(149, 24);
            this.txtFees.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(187, 20);
            this.txtFees.TabIndex = 32;
            this.txtFees.ThousandsSeparator = true;
            this.txtFees.ValueChanged += new System.EventHandler(this.txtFees_ValueChanged);
            // 
            // chkDisableFees
            // 
            this.chkDisableFees.AutoSize = true;
            this.chkDisableFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDisableFees.Location = new System.Drawing.Point(18, 26);
            this.chkDisableFees.Name = "chkDisableFees";
            this.chkDisableFees.Size = new System.Drawing.Size(113, 17);
            this.chkDisableFees.TabIndex = 24;
            this.chkDisableFees.Text = "Disable Close Fees";
            this.chkDisableFees.UseVisualStyleBackColor = true;
            this.chkDisableFees.CheckedChanged += new System.EventHandler(this.chkDisableFees_CheckedChanged);
            // 
            // CloseSavingsAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(515, 250);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CloseSavingsAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Close Account";
            this.Load += new System.EventHandler(this.CloseSavingsAccountForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnCloseAccount;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonTransfer;
        private System.Windows.Forms.RadioButton radioButtonWithdraw;
        private System.Windows.Forms.CheckBox chkDisableFees;
        private System.Windows.Forms.NumericUpDown txtFees;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblCloseFees;
        private System.Windows.Forms.Label lblMinFees;
        private System.Windows.Forms.Label lblMaxFees;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel btnSearch;
        private System.Windows.Forms.TextBox txtTransactionAccount;
        private System.Windows.Forms.Label lblAccountOwner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;



    }
}
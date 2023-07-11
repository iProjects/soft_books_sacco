namespace AdminstratorModule.Views
{
    partial class AddManualEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddManualEntryForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboEntryBranch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEntryDescription = new System.Windows.Forms.TextBox();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cboCreditAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDebitAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboBookingBranch = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBookingDescription = new System.Windows.Forms.TextBox();
            this.cboBookingCurrency = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBookingAmount = new System.Windows.Forms.TextBox();
            this.cboBookingType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(307, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(193, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 310);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.cboEntryBranch);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtEntryDescription);
            this.tabPage1.Controls.Add(this.cboCurrency);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtAmount);
            this.tabPage1.Controls.Add(this.cboCreditAccount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboDebitAccount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entry";
            // 
            // cboEntryBranch
            // 
            this.cboEntryBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntryBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEntryBranch.FormattingEnabled = true;
            this.cboEntryBranch.Location = new System.Drawing.Point(96, 234);
            this.cboEntryBranch.Name = "cboEntryBranch";
            this.cboEntryBranch.Size = new System.Drawing.Size(340, 21);
            this.cboEntryBranch.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Branch*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description*";
            // 
            // txtEntryDescription
            // 
            this.txtEntryDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntryDescription.Location = new System.Drawing.Point(96, 193);
            this.txtEntryDescription.MaxLength = 200;
            this.txtEntryDescription.Name = "txtEntryDescription";
            this.txtEntryDescription.Size = new System.Drawing.Size(340, 20);
            this.txtEntryDescription.TabIndex = 4;
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(96, 151);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(340, 21);
            this.cboCurrency.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Currency*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount*";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(96, 110);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(340, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // cboCreditAccount
            // 
            this.cboCreditAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCreditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCreditAccount.FormattingEnabled = true;
            this.cboCreditAccount.Location = new System.Drawing.Point(96, 68);
            this.cboCreditAccount.Name = "cboCreditAccount";
            this.cboCreditAccount.Size = new System.Drawing.Size(340, 21);
            this.cboCreditAccount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Credit*";
            // 
            // cboDebitAccount
            // 
            this.cboDebitAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDebitAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDebitAccount.FormattingEnabled = true;
            this.cboDebitAccount.Location = new System.Drawing.Point(96, 26);
            this.cboDebitAccount.Name = "cboDebitAccount";
            this.cboDebitAccount.Size = new System.Drawing.Size(340, 21);
            this.cboDebitAccount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Debit*";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage2.Controls.Add(this.cboBookingBranch);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtBookingDescription);
            this.tabPage2.Controls.Add(this.cboBookingCurrency);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtBookingAmount);
            this.tabPage2.Controls.Add(this.cboBookingType);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Standard Bookings";
            // 
            // cboBookingBranch
            // 
            this.cboBookingBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBookingBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBookingBranch.FormattingEnabled = true;
            this.cboBookingBranch.Location = new System.Drawing.Point(81, 214);
            this.cboBookingBranch.Name = "cboBookingBranch";
            this.cboBookingBranch.Size = new System.Drawing.Size(368, 21);
            this.cboBookingBranch.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Branch*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Description*";
            // 
            // txtBookingDescription
            // 
            this.txtBookingDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookingDescription.Location = new System.Drawing.Point(81, 170);
            this.txtBookingDescription.MaxLength = 200;
            this.txtBookingDescription.Name = "txtBookingDescription";
            this.txtBookingDescription.Size = new System.Drawing.Size(368, 20);
            this.txtBookingDescription.TabIndex = 3;
            // 
            // cboBookingCurrency
            // 
            this.cboBookingCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBookingCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBookingCurrency.FormattingEnabled = true;
            this.cboBookingCurrency.Location = new System.Drawing.Point(81, 125);
            this.cboBookingCurrency.Name = "cboBookingCurrency";
            this.cboBookingCurrency.Size = new System.Drawing.Size(368, 21);
            this.cboBookingCurrency.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Currency*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Amount*";
            // 
            // txtBookingAmount
            // 
            this.txtBookingAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookingAmount.Location = new System.Drawing.Point(81, 81);
            this.txtBookingAmount.MaxLength = 8;
            this.txtBookingAmount.Name = "txtBookingAmount";
            this.txtBookingAmount.Size = new System.Drawing.Size(368, 20);
            this.txtBookingAmount.TabIndex = 1;
            this.txtBookingAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBookingAmount_KeyDown);
            this.txtBookingAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBookingAmount_KeyPress);
            // 
            // cboBookingType
            // 
            this.cboBookingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBookingType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBookingType.FormattingEnabled = true;
            this.cboBookingType.Location = new System.Drawing.Point(81, 36);
            this.cboBookingType.Name = "cboBookingType";
            this.cboBookingType.Size = new System.Drawing.Size(368, 21);
            this.cboBookingType.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Booking*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddManualEntryForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(526, 388);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddManualEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Manual EntryForm";
            this.Load += new System.EventHandler(this.AddManualEntryForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.ComboBox cboEntryBranch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEntryDescription;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cboCreditAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDebitAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBookingBranch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBookingDescription;
        private System.Windows.Forms.ComboBox cboBookingCurrency;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBookingAmount;
        private System.Windows.Forms.ComboBox cboBookingType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
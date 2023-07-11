namespace TellersModule.Views
{
    partial class AddTellerForm
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkVault = new System.Windows.Forms.CheckBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMinTellerBalance = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMaxTellerBalance = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMinAmountCashIn = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaxAmountCashIn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMinAmountCashOut = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaxAmountCashOut = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMinAmountWithdraw = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaxAmountWithdraw = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMinAmountDeposit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaxAmountDeposit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinAmountTeller = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaxAmountTeller = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(161, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(282, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 410);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(493, 391);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.chkVault);
            this.tabPage1.Controls.Add(this.cboBranch);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cboUsers);
            this.tabPage1.Controls.Add(this.label78);
            this.tabPage1.Controls.Add(this.cboCurrency);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboAccount);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDescription);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(485, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic";
            // 
            // chkVault
            // 
            this.chkVault.AutoSize = true;
            this.chkVault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVault.Location = new System.Drawing.Point(123, 247);
            this.chkVault.Name = "chkVault";
            this.chkVault.Size = new System.Drawing.Size(47, 17);
            this.chkVault.TabIndex = 6;
            this.chkVault.Text = "Vault";
            this.chkVault.UseVisualStyleBackColor = true;
            this.chkVault.CheckedChanged += new System.EventHandler(this.chkVault_CheckedChanged);
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(123, 208);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(282, 21);
            this.cboBranch.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Branch";
            // 
            // cboUsers
            // 
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(123, 169);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(282, 21);
            this.cboUsers.TabIndex = 4;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(88, 172);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(29, 13);
            this.label78.TabIndex = 17;
            this.label78.Text = "User";
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(123, 130);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(282, 21);
            this.cboCurrency.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Currency";
            // 
            // cboAccount
            // 
            this.cboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(123, 91);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(282, 21);
            this.cboAccount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(123, 15);
            this.txtName.MaxLength = 250;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(282, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(123, 53);
            this.txtDescription.MaxLength = 250;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(282, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txtMinTellerBalance);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtMaxTellerBalance);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtMinAmountCashIn);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.txtMaxAmountCashIn);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtMinAmountCashOut);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtMaxAmountCashOut);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtMinAmountWithdraw);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtMaxAmountWithdraw);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtMinAmountDeposit);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtMaxAmountDeposit);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtMinAmountTeller);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtMaxAmountTeller);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(485, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(45, 308);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Minimum Teller Balance";
            // 
            // txtMinTellerBalance
            // 
            this.txtMinTellerBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinTellerBalance.Location = new System.Drawing.Point(170, 308);
            this.txtMinTellerBalance.MaxLength = 250;
            this.txtMinTellerBalance.Name = "txtMinTellerBalance";
            this.txtMinTellerBalance.Size = new System.Drawing.Size(262, 20);
            this.txtMinTellerBalance.TabIndex = 10;
            this.txtMinTellerBalance.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(42, 338);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "Maximum Teller Balance";
            // 
            // txtMaxTellerBalance
            // 
            this.txtMaxTellerBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxTellerBalance.Location = new System.Drawing.Point(170, 338);
            this.txtMaxTellerBalance.MaxLength = 250;
            this.txtMaxTellerBalance.Name = "txtMaxTellerBalance";
            this.txtMaxTellerBalance.Size = new System.Drawing.Size(262, 20);
            this.txtMaxTellerBalance.TabIndex = 11;
            this.txtMaxTellerBalance.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Minimum Amount per Cash In";
            // 
            // txtMinAmountCashIn
            // 
            this.txtMinAmountCashIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinAmountCashIn.Location = new System.Drawing.Point(170, 248);
            this.txtMinAmountCashIn.MaxLength = 250;
            this.txtMinAmountCashIn.Name = "txtMinAmountCashIn";
            this.txtMinAmountCashIn.Size = new System.Drawing.Size(262, 20);
            this.txtMinAmountCashIn.TabIndex = 8;
            this.txtMinAmountCashIn.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 278);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Maximum Amount per Cash In";
            // 
            // txtMaxAmountCashIn
            // 
            this.txtMaxAmountCashIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxAmountCashIn.Location = new System.Drawing.Point(170, 278);
            this.txtMaxAmountCashIn.MaxLength = 250;
            this.txtMaxAmountCashIn.Name = "txtMaxAmountCashIn";
            this.txtMaxAmountCashIn.Size = new System.Drawing.Size(262, 20);
            this.txtMaxAmountCashIn.TabIndex = 9;
            this.txtMaxAmountCashIn.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Minimum Amount per Cash Out";
            // 
            // txtMinAmountCashOut
            // 
            this.txtMinAmountCashOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinAmountCashOut.Location = new System.Drawing.Point(170, 188);
            this.txtMinAmountCashOut.MaxLength = 250;
            this.txtMinAmountCashOut.Name = "txtMinAmountCashOut";
            this.txtMinAmountCashOut.Size = new System.Drawing.Size(262, 20);
            this.txtMinAmountCashOut.TabIndex = 6;
            this.txtMinAmountCashOut.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Maximum Amount per Cash Out";
            // 
            // txtMaxAmountCashOut
            // 
            this.txtMaxAmountCashOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxAmountCashOut.Location = new System.Drawing.Point(170, 218);
            this.txtMaxAmountCashOut.MaxLength = 250;
            this.txtMaxAmountCashOut.Name = "txtMaxAmountCashOut";
            this.txtMaxAmountCashOut.Size = new System.Drawing.Size(262, 20);
            this.txtMaxAmountCashOut.TabIndex = 7;
            this.txtMaxAmountCashOut.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Minimum Amount per Withdraw";
            // 
            // txtMinAmountWithdraw
            // 
            this.txtMinAmountWithdraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinAmountWithdraw.Location = new System.Drawing.Point(170, 128);
            this.txtMinAmountWithdraw.MaxLength = 250;
            this.txtMinAmountWithdraw.Name = "txtMinAmountWithdraw";
            this.txtMinAmountWithdraw.Size = new System.Drawing.Size(262, 20);
            this.txtMinAmountWithdraw.TabIndex = 4;
            this.txtMinAmountWithdraw.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Maximum Amount per Withdraw";
            // 
            // txtMaxAmountWithdraw
            // 
            this.txtMaxAmountWithdraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxAmountWithdraw.Location = new System.Drawing.Point(170, 158);
            this.txtMaxAmountWithdraw.MaxLength = 250;
            this.txtMaxAmountWithdraw.Name = "txtMaxAmountWithdraw";
            this.txtMaxAmountWithdraw.Size = new System.Drawing.Size(262, 20);
            this.txtMaxAmountWithdraw.TabIndex = 5;
            this.txtMaxAmountWithdraw.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Minimum Amount per Deposit";
            // 
            // txtMinAmountDeposit
            // 
            this.txtMinAmountDeposit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinAmountDeposit.Location = new System.Drawing.Point(170, 68);
            this.txtMinAmountDeposit.MaxLength = 250;
            this.txtMinAmountDeposit.Name = "txtMinAmountDeposit";
            this.txtMinAmountDeposit.Size = new System.Drawing.Size(262, 20);
            this.txtMinAmountDeposit.TabIndex = 2;
            this.txtMinAmountDeposit.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Maximum Amount per Deposit";
            // 
            // txtMaxAmountDeposit
            // 
            this.txtMaxAmountDeposit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxAmountDeposit.Location = new System.Drawing.Point(170, 98);
            this.txtMaxAmountDeposit.MaxLength = 250;
            this.txtMaxAmountDeposit.Name = "txtMaxAmountDeposit";
            this.txtMaxAmountDeposit.Size = new System.Drawing.Size(262, 20);
            this.txtMaxAmountDeposit.TabIndex = 3;
            this.txtMaxAmountDeposit.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Minimum Amount in Teller";
            // 
            // txtMinAmountTeller
            // 
            this.txtMinAmountTeller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinAmountTeller.Location = new System.Drawing.Point(170, 8);
            this.txtMinAmountTeller.MaxLength = 250;
            this.txtMinAmountTeller.Name = "txtMinAmountTeller";
            this.txtMinAmountTeller.Size = new System.Drawing.Size(262, 20);
            this.txtMinAmountTeller.TabIndex = 0;
            this.txtMinAmountTeller.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Maximum Amount in Teller";
            // 
            // txtMaxAmountTeller
            // 
            this.txtMaxAmountTeller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxAmountTeller.Location = new System.Drawing.Point(170, 38);
            this.txtMaxAmountTeller.MaxLength = 250;
            this.txtMaxAmountTeller.Name = "txtMaxAmountTeller";
            this.txtMaxAmountTeller.Size = new System.Drawing.Size(262, 20);
            this.txtMaxAmountTeller.TabIndex = 1;
            this.txtMaxAmountTeller.Text = "0";
            // 
            // AddTellerForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(499, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddTellerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Teller";
            this.Load += new System.EventHandler(this.AddTellerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkVault;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMinTellerBalance;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMaxTellerBalance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMinAmountCashIn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaxAmountCashIn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMinAmountCashOut;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMaxAmountCashOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMinAmountWithdraw;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaxAmountWithdraw;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMinAmountDeposit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaxAmountDeposit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMinAmountTeller;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaxAmountTeller;

    }
}
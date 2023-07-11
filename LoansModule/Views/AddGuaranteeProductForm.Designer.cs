namespace LoansModule.Views
{
    partial class AddGuaranteeProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGuaranteeProductForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaxFeeGuaranteeAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMinFeeGuaranteeAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValueFeeGuaranteeAmount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxGuaranteeAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinGuaranteeAmount = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtValueGuaranteeAmount = new System.Windows.Forms.TextBox();
            this.groupBoxInterestRateType = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMaxAmounttobeguaranteed = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtMinAmounttobeguaranteed = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtValueAmounttobeguaranteed = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboFundingLine = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.groupBoxClientType = new System.Windows.Forms.GroupBox();
            this.chkCorporateClient = new System.Windows.Forms.CheckBox();
            this.chkIndividualClient = new System.Windows.Forms.CheckBox();
            this.chkGroupClient = new System.Windows.Forms.CheckBox();
            this.chkAllClients = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnSaver = new System.Windows.Forms.LinkLabel();
            this.btnCloser = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxInterestRateType.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxClientType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(724, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBoxInterestRateType);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBoxClientType);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(716, 403);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Main Parameters";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtMaxFeeGuaranteeAmount);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtMinFeeGuaranteeAmount);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtValueFeeGuaranteeAmount);
            this.groupBox5.Location = new System.Drawing.Point(9, 276);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(349, 113);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fee( % Amount of Guarantee)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Or";
            // 
            // txtMaxFeeGuaranteeAmount
            // 
            this.txtMaxFeeGuaranteeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxFeeGuaranteeAmount.Location = new System.Drawing.Point(48, 69);
            this.txtMaxFeeGuaranteeAmount.Name = "txtMaxFeeGuaranteeAmount";
            this.txtMaxFeeGuaranteeAmount.Size = new System.Drawing.Size(92, 20);
            this.txtMaxFeeGuaranteeAmount.TabIndex = 21;
            this.txtMaxFeeGuaranteeAmount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Min";
            // 
            // txtMinFeeGuaranteeAmount
            // 
            this.txtMinFeeGuaranteeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinFeeGuaranteeAmount.Location = new System.Drawing.Point(49, 24);
            this.txtMinFeeGuaranteeAmount.Name = "txtMinFeeGuaranteeAmount";
            this.txtMinFeeGuaranteeAmount.Size = new System.Drawing.Size(96, 20);
            this.txtMinFeeGuaranteeAmount.TabIndex = 19;
            this.txtMinFeeGuaranteeAmount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Max";
            // 
            // txtValueFeeGuaranteeAmount
            // 
            this.txtValueFeeGuaranteeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValueFeeGuaranteeAmount.Location = new System.Drawing.Point(219, 49);
            this.txtValueFeeGuaranteeAmount.Name = "txtValueFeeGuaranteeAmount";
            this.txtValueFeeGuaranteeAmount.Size = new System.Drawing.Size(85, 20);
            this.txtValueFeeGuaranteeAmount.TabIndex = 17;
            this.txtValueFeeGuaranteeAmount.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtMaxGuaranteeAmount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtMinGuaranteeAmount);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtValueGuaranteeAmount);
            this.groupBox3.Location = new System.Drawing.Point(364, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 113);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Guarantee Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Or";
            // 
            // txtMaxGuaranteeAmount
            // 
            this.txtMaxGuaranteeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxGuaranteeAmount.Location = new System.Drawing.Point(48, 69);
            this.txtMaxGuaranteeAmount.Name = "txtMaxGuaranteeAmount";
            this.txtMaxGuaranteeAmount.Size = new System.Drawing.Size(92, 20);
            this.txtMaxGuaranteeAmount.TabIndex = 21;
            this.txtMaxGuaranteeAmount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Min";
            // 
            // txtMinGuaranteeAmount
            // 
            this.txtMinGuaranteeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinGuaranteeAmount.Location = new System.Drawing.Point(49, 24);
            this.txtMinGuaranteeAmount.Name = "txtMinGuaranteeAmount";
            this.txtMinGuaranteeAmount.Size = new System.Drawing.Size(96, 20);
            this.txtMinGuaranteeAmount.TabIndex = 19;
            this.txtMinGuaranteeAmount.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(18, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(27, 13);
            this.label23.TabIndex = 18;
            this.label23.Text = "Max";
            // 
            // txtValueGuaranteeAmount
            // 
            this.txtValueGuaranteeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValueGuaranteeAmount.Location = new System.Drawing.Point(219, 49);
            this.txtValueGuaranteeAmount.Name = "txtValueGuaranteeAmount";
            this.txtValueGuaranteeAmount.Size = new System.Drawing.Size(85, 20);
            this.txtValueGuaranteeAmount.TabIndex = 17;
            this.txtValueGuaranteeAmount.Text = "0";
            // 
            // groupBoxInterestRateType
            // 
            this.groupBoxInterestRateType.Controls.Add(this.label22);
            this.groupBoxInterestRateType.Controls.Add(this.label19);
            this.groupBoxInterestRateType.Controls.Add(this.txtMaxAmounttobeguaranteed);
            this.groupBoxInterestRateType.Controls.Add(this.label20);
            this.groupBoxInterestRateType.Controls.Add(this.txtMinAmounttobeguaranteed);
            this.groupBoxInterestRateType.Controls.Add(this.label21);
            this.groupBoxInterestRateType.Controls.Add(this.txtValueAmounttobeguaranteed);
            this.groupBoxInterestRateType.Location = new System.Drawing.Point(9, 157);
            this.groupBoxInterestRateType.Name = "groupBoxInterestRateType";
            this.groupBoxInterestRateType.Size = new System.Drawing.Size(349, 113);
            this.groupBoxInterestRateType.TabIndex = 8;
            this.groupBoxInterestRateType.TabStop = false;
            this.groupBoxInterestRateType.Text = "Amount to be Guaranted";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(172, 50);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 16;
            this.label22.Text = "Value";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(138, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 13);
            this.label19.TabIndex = 15;
            this.label19.Text = "Or";
            // 
            // txtMaxAmounttobeguaranteed
            // 
            this.txtMaxAmounttobeguaranteed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxAmounttobeguaranteed.Location = new System.Drawing.Point(37, 68);
            this.txtMaxAmounttobeguaranteed.Name = "txtMaxAmounttobeguaranteed";
            this.txtMaxAmounttobeguaranteed.Size = new System.Drawing.Size(92, 20);
            this.txtMaxAmounttobeguaranteed.TabIndex = 14;
            this.txtMaxAmounttobeguaranteed.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "Min";
            // 
            // txtMinAmounttobeguaranteed
            // 
            this.txtMinAmounttobeguaranteed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinAmounttobeguaranteed.Location = new System.Drawing.Point(38, 23);
            this.txtMinAmounttobeguaranteed.Name = "txtMinAmounttobeguaranteed";
            this.txtMinAmounttobeguaranteed.Size = new System.Drawing.Size(96, 20);
            this.txtMinAmounttobeguaranteed.TabIndex = 12;
            this.txtMinAmounttobeguaranteed.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 71);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(27, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "Max";
            // 
            // txtValueAmounttobeguaranteed
            // 
            this.txtValueAmounttobeguaranteed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValueAmounttobeguaranteed.Location = new System.Drawing.Point(208, 48);
            this.txtValueAmounttobeguaranteed.Name = "txtValueAmounttobeguaranteed";
            this.txtValueAmounttobeguaranteed.Size = new System.Drawing.Size(85, 20);
            this.txtValueAmounttobeguaranteed.TabIndex = 10;
            this.txtValueAmounttobeguaranteed.Text = "0";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboFundingLine);
            this.groupBox6.Location = new System.Drawing.Point(10, 96);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(414, 59);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attach Product to Funding Line*";
            // 
            // cboFundingLine
            // 
            this.cboFundingLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFundingLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFundingLine.FormattingEnabled = true;
            this.cboFundingLine.Location = new System.Drawing.Point(6, 19);
            this.cboFundingLine.Name = "cboFundingLine";
            this.cboFundingLine.Size = new System.Drawing.Size(370, 21);
            this.cboFundingLine.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboCurrency);
            this.groupBox4.Location = new System.Drawing.Point(430, 100);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 57);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Attach Product to Currency*";
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(6, 19);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(232, 21);
            this.cboCurrency.TabIndex = 0;
            // 
            // groupBoxClientType
            // 
            this.groupBoxClientType.Controls.Add(this.chkCorporateClient);
            this.groupBoxClientType.Controls.Add(this.chkIndividualClient);
            this.groupBoxClientType.Controls.Add(this.chkGroupClient);
            this.groupBoxClientType.Controls.Add(this.chkAllClients);
            this.groupBoxClientType.Location = new System.Drawing.Point(9, 41);
            this.groupBoxClientType.Name = "groupBoxClientType";
            this.groupBoxClientType.Size = new System.Drawing.Size(702, 53);
            this.groupBoxClientType.TabIndex = 4;
            this.groupBoxClientType.TabStop = false;
            this.groupBoxClientType.Text = "Attach Product to a Specific Client Type";
            // 
            // chkCorporateClient
            // 
            this.chkCorporateClient.AutoSize = true;
            this.chkCorporateClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCorporateClient.Location = new System.Drawing.Point(280, 19);
            this.chkCorporateClient.Name = "chkCorporateClient";
            this.chkCorporateClient.Size = new System.Drawing.Size(69, 17);
            this.chkCorporateClient.TabIndex = 3;
            this.chkCorporateClient.Text = "Corporate";
            this.chkCorporateClient.UseVisualStyleBackColor = true;
            // 
            // chkIndividualClient
            // 
            this.chkIndividualClient.AutoSize = true;
            this.chkIndividualClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIndividualClient.Location = new System.Drawing.Point(160, 19);
            this.chkIndividualClient.Name = "chkIndividualClient";
            this.chkIndividualClient.Size = new System.Drawing.Size(97, 17);
            this.chkIndividualClient.TabIndex = 2;
            this.chkIndividualClient.Text = "Individual Client";
            this.chkIndividualClient.UseVisualStyleBackColor = true;
            // 
            // chkGroupClient
            // 
            this.chkGroupClient.AutoSize = true;
            this.chkGroupClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkGroupClient.Location = new System.Drawing.Point(71, 19);
            this.chkGroupClient.Name = "chkGroupClient";
            this.chkGroupClient.Size = new System.Drawing.Size(55, 17);
            this.chkGroupClient.TabIndex = 1;
            this.chkGroupClient.Text = " Group";
            this.chkGroupClient.UseVisualStyleBackColor = true;
            // 
            // chkAllClients
            // 
            this.chkAllClients.AutoSize = true;
            this.chkAllClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAllClients.Location = new System.Drawing.Point(18, 19);
            this.chkAllClients.Name = "chkAllClients";
            this.chkAllClients.Size = new System.Drawing.Size(34, 17);
            this.chkAllClients.TabIndex = 0;
            this.chkAllClients.Text = "All";
            this.chkAllClients.UseVisualStyleBackColor = true;
            this.chkAllClients.CheckedChanged += new System.EventHandler(this.chkAllClients_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name*";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(73, 13);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(552, 20);
            this.txtName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 448);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(430, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 29);
            this.btnClose.TabIndex = 17;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(246, 455);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 29);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnSaver
            // 
            this.btnSaver.AutoSize = true;
            this.btnSaver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaver.LinkColor = System.Drawing.Color.Yellow;
            this.btnSaver.Location = new System.Drawing.Point(567, 16);
            this.btnSaver.Name = "btnSaver";
            this.btnSaver.Size = new System.Drawing.Size(65, 25);
            this.btnSaver.TabIndex = 8;
            this.btnSaver.TabStop = true;
            this.btnSaver.Text = "Save";
            // 
            // btnCloser
            // 
            this.btnCloser.AutoSize = true;
            this.btnCloser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloser.LinkColor = System.Drawing.Color.Yellow;
            this.btnCloser.Location = new System.Drawing.Point(647, 16);
            this.btnCloser.Name = "btnCloser";
            this.btnCloser.Size = new System.Drawing.Size(72, 25);
            this.btnCloser.TabIndex = 7;
            this.btnCloser.TabStop = true;
            this.btnCloser.Text = "Close";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnSaver);
            this.groupBox2.Controls.Add(this.btnCloser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 493);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddGuaranteeProductForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(730, 493);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddGuaranteeProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Guarantee";
            this.Load += new System.EventHandler(this.AddNewGuaranteeProductForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxInterestRateType.ResumeLayout(false);
            this.groupBoxInterestRateType.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBoxClientType.ResumeLayout(false);
            this.groupBoxClientType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnSaver;
        private System.Windows.Forms.LinkLabel btnCloser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaxFeeGuaranteeAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMinFeeGuaranteeAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValueFeeGuaranteeAmount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaxGuaranteeAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMinGuaranteeAmount;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtValueGuaranteeAmount;
        private System.Windows.Forms.GroupBox groupBoxInterestRateType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMaxAmounttobeguaranteed;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtMinAmounttobeguaranteed;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtValueAmounttobeguaranteed;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboFundingLine;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.GroupBox groupBoxClientType;
        private System.Windows.Forms.CheckBox chkCorporateClient;
        private System.Windows.Forms.CheckBox chkIndividualClient;
        private System.Windows.Forms.CheckBox chkGroupClient;
        private System.Windows.Forms.CheckBox chkAllClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;

    }
}
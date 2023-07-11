namespace CustomerModule.Views
{
    partial class SavingsFirstDepositForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavingsFirstDepositForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInitialAmount = new System.Windows.Forms.Label();
            this.lblEntryFees = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInitialAmount = new System.Windows.Forms.NumericUpDown();
            this.txtEntryFees = new System.Windows.Forms.NumericUpDown();
            this.lblMinInitialAmount = new System.Windows.Forms.Label();
            this.lblMaxInitialAmount = new System.Windows.Forms.Label();
            this.lblMinEntryFees = new System.Windows.Forms.Label();
            this.lblMaxEntryFees = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.bindingSourceCollaterals = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollaterals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblInitialAmount);
            this.groupBox1.Controls.Add(this.lblEntryFees);
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Initial Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Entry Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total Amount:";
            // 
            // lblInitialAmount
            // 
            this.lblInitialAmount.AutoSize = true;
            this.lblInitialAmount.Location = new System.Drawing.Point(170, 15);
            this.lblInitialAmount.Name = "lblInitialAmount";
            this.lblInitialAmount.Size = new System.Drawing.Size(70, 13);
            this.lblInitialAmount.TabIndex = 5;
            this.lblInitialAmount.Text = "Initial Amount";
            // 
            // lblEntryFees
            // 
            this.lblEntryFees.AutoSize = true;
            this.lblEntryFees.Location = new System.Drawing.Point(170, 36);
            this.lblEntryFees.Name = "lblEntryFees";
            this.lblEntryFees.Size = new System.Drawing.Size(57, 13);
            this.lblEntryFees.TabIndex = 4;
            this.lblEntryFees.Text = "Entry Fees";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(170, 57);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(70, 13);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(562, 39);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(187, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(249, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtInitialAmount);
            this.groupBox3.Controls.Add(this.txtEntryFees);
            this.groupBox3.Controls.Add(this.lblMinInitialAmount);
            this.groupBox3.Controls.Add(this.lblMaxInitialAmount);
            this.groupBox3.Controls.Add(this.lblMinEntryFees);
            this.groupBox3.Controls.Add(this.lblMaxEntryFees);
            this.groupBox3.Controls.Add(this.cboPaymentMethod);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(562, 146);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modify Initial Amount and Entry Fees";
            // 
            // txtInitialAmount
            // 
            this.txtInitialAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInitialAmount.Location = new System.Drawing.Point(104, 29);
            this.txtInitialAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtInitialAmount.Name = "txtInitialAmount";
            this.txtInitialAmount.Size = new System.Drawing.Size(185, 20);
            this.txtInitialAmount.TabIndex = 29;
            this.txtInitialAmount.ThousandsSeparator = true;
            this.txtInitialAmount.ValueChanged += new System.EventHandler(this.txtInitialAmount_ValueChanged);
            // 
            // txtEntryFees
            // 
            this.txtEntryFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntryFees.Location = new System.Drawing.Point(104, 66);
            this.txtEntryFees.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtEntryFees.Name = "txtEntryFees";
            this.txtEntryFees.Size = new System.Drawing.Size(185, 20);
            this.txtEntryFees.TabIndex = 31;
            this.txtEntryFees.ThousandsSeparator = true;
            this.txtEntryFees.ValueChanged += new System.EventHandler(this.txtEntryFees_ValueChanged);
            // 
            // lblMinInitialAmount
            // 
            this.lblMinInitialAmount.AutoSize = true;
            this.lblMinInitialAmount.Location = new System.Drawing.Point(307, 23);
            this.lblMinInitialAmount.Name = "lblMinInitialAmount";
            this.lblMinInitialAmount.Size = new System.Drawing.Size(24, 13);
            this.lblMinInitialAmount.TabIndex = 38;
            this.lblMinInitialAmount.Text = "Min";
            // 
            // lblMaxInitialAmount
            // 
            this.lblMaxInitialAmount.AutoSize = true;
            this.lblMaxInitialAmount.Location = new System.Drawing.Point(307, 36);
            this.lblMaxInitialAmount.Name = "lblMaxInitialAmount";
            this.lblMaxInitialAmount.Size = new System.Drawing.Size(27, 13);
            this.lblMaxInitialAmount.TabIndex = 37;
            this.lblMaxInitialAmount.Text = "Max";
            // 
            // lblMinEntryFees
            // 
            this.lblMinEntryFees.AutoSize = true;
            this.lblMinEntryFees.Location = new System.Drawing.Point(307, 63);
            this.lblMinEntryFees.Name = "lblMinEntryFees";
            this.lblMinEntryFees.Size = new System.Drawing.Size(24, 13);
            this.lblMinEntryFees.TabIndex = 36;
            this.lblMinEntryFees.Text = "Min";
            // 
            // lblMaxEntryFees
            // 
            this.lblMaxEntryFees.AutoSize = true;
            this.lblMaxEntryFees.Location = new System.Drawing.Point(307, 76);
            this.lblMaxEntryFees.Name = "lblMaxEntryFees";
            this.lblMaxEntryFees.Size = new System.Drawing.Size(27, 13);
            this.lblMaxEntryFees.TabIndex = 35;
            this.lblMaxEntryFees.Text = "Max";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(104, 106);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(188, 21);
            this.cboPaymentMethod.TabIndex = 33;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(14, 109);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(91, 13);
            this.label36.TabIndex = 34;
            this.label36.Text = "Payment Method*";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(42, 68);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(61, 13);
            this.label35.TabIndex = 32;
            this.label35.Text = "Entry Fees*";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(30, 32);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(74, 13);
            this.label34.TabIndex = 30;
            this.label34.Text = "Initial Amount*";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "contractid";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "close_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "close_date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SavingsFirstDepositForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(562, 276);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavingsFirstDepositForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings First Deposit";
            this.Load += new System.EventHandler(this.SavingsFirstDepositForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollaterals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.BindingSource bindingSourceCollaterals;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lblInitialAmount;
        private System.Windows.Forms.Label lblEntryFees;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.NumericUpDown txtInitialAmount;
        private System.Windows.Forms.NumericUpDown txtEntryFees;
        private System.Windows.Forms.Label lblMinInitialAmount;
        private System.Windows.Forms.Label lblMaxInitialAmount;
        private System.Windows.Forms.Label lblMinEntryFees;
        private System.Windows.Forms.Label lblMaxEntryFees;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
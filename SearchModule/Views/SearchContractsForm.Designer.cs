namespace SearchModule.Views
{
    partial class SearchContractsForm
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
            this.radioButtonTransfer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonWithdraw = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTransactionAccount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSavingsEvents = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSavingsEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Controls.Add(this.radioButtonTransfer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonWithdraw);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTransactionAccount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 47);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonTransfer
            // 
            this.radioButtonTransfer.AutoSize = true;
            this.radioButtonTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonTransfer.Location = new System.Drawing.Point(610, 15);
            this.radioButtonTransfer.Name = "radioButtonTransfer";
            this.radioButtonTransfer.Size = new System.Drawing.Size(105, 17);
            this.radioButtonTransfer.TabIndex = 51;
            this.radioButtonTransfer.TabStop = true;
            this.radioButtonTransfer.Text = "Savings Contract";
            this.radioButtonTransfer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Client Name";
            // 
            // radioButtonWithdraw
            // 
            this.radioButtonWithdraw.AutoSize = true;
            this.radioButtonWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonWithdraw.Location = new System.Drawing.Point(493, 15);
            this.radioButtonWithdraw.Name = "radioButtonWithdraw";
            this.radioButtonWithdraw.Size = new System.Drawing.Size(99, 17);
            this.radioButtonWithdraw.TabIndex = 50;
            this.radioButtonWithdraw.TabStop = true;
            this.radioButtonWithdraw.Text = "Credit Contracts";
            this.radioButtonWithdraw.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(296, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 20);
            this.textBox1.TabIndex = 61;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(804, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 60;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Contract Code";
            // 
            // txtTransactionAccount
            // 
            this.txtTransactionAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionAccount.Location = new System.Drawing.Point(93, 13);
            this.txtTransactionAccount.Name = "txtTransactionAccount";
            this.txtTransactionAccount.Size = new System.Drawing.Size(118, 20);
            this.txtTransactionAccount.TabIndex = 58;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox3.Controls.Add(this.dataGridViewSavingsEvents);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(868, 326);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // dataGridViewSavingsEvents
            // 
            this.dataGridViewSavingsEvents.AllowUserToAddRows = false;
            this.dataGridViewSavingsEvents.AllowUserToDeleteRows = false;
            this.dataGridViewSavingsEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSavingsEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSavingsEvents.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewSavingsEvents.MultiSelect = false;
            this.dataGridViewSavingsEvents.Name = "dataGridViewSavingsEvents";
            this.dataGridViewSavingsEvents.ReadOnly = true;
            this.dataGridViewSavingsEvents.Size = new System.Drawing.Size(862, 307);
            this.dataGridViewSavingsEvents.TabIndex = 2;
            // 
            // SearchContractsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(868, 373);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchContractsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Contracts";
            this.Load += new System.EventHandler(this.SearchContractsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSavingsEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewSavingsEvents;
        private System.Windows.Forms.RadioButton radioButtonTransfer;
        private System.Windows.Forms.RadioButton radioButtonWithdraw;
        private System.Windows.Forms.TextBox txtTransactionAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel btnClose;


    }
}
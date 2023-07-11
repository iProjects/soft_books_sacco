namespace AdminstratorModule.Views
{
    partial class EditFundingLineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFundingLineForm));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnticipatedReminder = new System.Windows.Forms.TextBox();
            this.txtInitialAmount = new System.Windows.Forms.TextBox();
            this.txtRealReminder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFundingLineEvents = new System.Windows.Forms.DataGridView();
            this.Column1FundingLineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddFundingEvent = new System.Windows.Forms.LinkLabel();
            this.btnDeleteFundingEvent = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bindingSourceFundingLineEvents = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFundingLineEvents)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFundingLineEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(82, 19);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Code*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Name*";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpEndDate);
            this.groupBox5.Controls.Add(this.txtCode);
            this.groupBox5.Controls.Add(this.dtpBeginDate);
            this.groupBox5.Controls.Add(this.txtName);
            this.groupBox5.Controls.Add(this.cboCurrency);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtAnticipatedReminder);
            this.groupBox5.Controls.Add(this.txtInitialAmount);
            this.groupBox5.Controls.Add(this.txtRealReminder);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(733, 199);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(82, 164);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(207, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(82, 55);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(207, 20);
            this.txtCode.TabIndex = 1;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(82, 128);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(207, 20);
            this.dtpBeginDate.TabIndex = 3;
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(82, 90);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(207, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Anticipated Reminder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Currency*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Real Reminder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Begin Date";
            // 
            // txtAnticipatedReminder
            // 
            this.txtAnticipatedReminder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnticipatedReminder.Enabled = false;
            this.txtAnticipatedReminder.Location = new System.Drawing.Point(465, 104);
            this.txtAnticipatedReminder.Name = "txtAnticipatedReminder";
            this.txtAnticipatedReminder.Size = new System.Drawing.Size(235, 20);
            this.txtAnticipatedReminder.TabIndex = 7;
            this.txtAnticipatedReminder.Text = "0";
            // 
            // txtInitialAmount
            // 
            this.txtInitialAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInitialAmount.Enabled = false;
            this.txtInitialAmount.Location = new System.Drawing.Point(465, 34);
            this.txtInitialAmount.Name = "txtInitialAmount";
            this.txtInitialAmount.Size = new System.Drawing.Size(235, 20);
            this.txtInitialAmount.TabIndex = 5;
            this.txtInitialAmount.Text = "0";
            // 
            // txtRealReminder
            // 
            this.txtRealReminder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRealReminder.Enabled = false;
            this.txtRealReminder.Location = new System.Drawing.Point(465, 68);
            this.txtRealReminder.Name = "txtRealReminder";
            this.txtRealReminder.Size = new System.Drawing.Size(235, 20);
            this.txtRealReminder.TabIndex = 6;
            this.txtRealReminder.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Initial Amount";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(558, 16);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(68, 20);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.TabStop = true;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpdate_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 368);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewFundingLineEvents);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(733, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funding Events";
            // 
            // dataGridViewFundingLineEvents
            // 
            this.dataGridViewFundingLineEvents.AllowUserToAddRows = false;
            this.dataGridViewFundingLineEvents.AllowUserToDeleteRows = false;
            this.dataGridViewFundingLineEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFundingLineEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1FundingLineCode,
            this.Column2CreationDate,
            this.Column3Amount,
            this.ColumnDirection,
            this.Column5Type});
            this.dataGridViewFundingLineEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFundingLineEvents.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewFundingLineEvents.MultiSelect = false;
            this.dataGridViewFundingLineEvents.Name = "dataGridViewFundingLineEvents";
            this.dataGridViewFundingLineEvents.ReadOnly = true;
            this.dataGridViewFundingLineEvents.Size = new System.Drawing.Size(621, 131);
            this.dataGridViewFundingLineEvents.TabIndex = 1;
            this.dataGridViewFundingLineEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFundingLineEvents_CellContentClick);
            // 
            // Column1FundingLineCode
            // 
            this.Column1FundingLineCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1FundingLineCode.DataPropertyName = "code";
            this.Column1FundingLineCode.HeaderText = "Code";
            this.Column1FundingLineCode.Name = "Column1FundingLineCode";
            this.Column1FundingLineCode.ReadOnly = true;
            // 
            // Column2CreationDate
            // 
            this.Column2CreationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2CreationDate.DataPropertyName = "creation_date";
            this.Column2CreationDate.HeaderText = "Creation Date";
            this.Column2CreationDate.Name = "Column2CreationDate";
            this.Column2CreationDate.ReadOnly = true;
            // 
            // Column3Amount
            // 
            this.Column3Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3Amount.DataPropertyName = "amount";
            this.Column3Amount.HeaderText = "Amount";
            this.Column3Amount.Name = "Column3Amount";
            this.Column3Amount.ReadOnly = true;
            // 
            // ColumnDirection
            // 
            this.ColumnDirection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnDirection.DataPropertyName = "direction";
            this.ColumnDirection.HeaderText = "Direction";
            this.ColumnDirection.Name = "ColumnDirection";
            this.ColumnDirection.ReadOnly = true;
            // 
            // Column5Type
            // 
            this.Column5Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5Type.DataPropertyName = "Type";
            this.Column5Type.HeaderText = "Type";
            this.Column5Type.Name = "Column5Type";
            this.Column5Type.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddFundingEvent);
            this.groupBox4.Controls.Add(this.btnDeleteFundingEvent);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(624, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(106, 131);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // btnAddFundingEvent
            // 
            this.btnAddFundingEvent.AutoSize = true;
            this.btnAddFundingEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFundingEvent.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddFundingEvent.Location = new System.Drawing.Point(9, 27);
            this.btnAddFundingEvent.Name = "btnAddFundingEvent";
            this.btnAddFundingEvent.Size = new System.Drawing.Size(67, 15);
            this.btnAddFundingEvent.TabIndex = 0;
            this.btnAddFundingEvent.TabStop = true;
            this.btnAddFundingEvent.Text = "Add Entry";
            this.btnAddFundingEvent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddFundingEvent_LinkClicked);
            // 
            // btnDeleteFundingEvent
            // 
            this.btnDeleteFundingEvent.AutoSize = true;
            this.btnDeleteFundingEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFundingEvent.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteFundingEvent.Location = new System.Drawing.Point(8, 67);
            this.btnDeleteFundingEvent.Name = "btnDeleteFundingEvent";
            this.btnDeleteFundingEvent.Size = new System.Drawing.Size(85, 15);
            this.btnDeleteFundingEvent.TabIndex = 1;
            this.btnDeleteFundingEvent.TabStop = true;
            this.btnDeleteFundingEvent.Text = "Delete Entry";
            this.btnDeleteFundingEvent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteFundingEvent_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(655, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 20);
            this.btnClose.TabIndex = 19;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(739, 55);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // EditFundingLineForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(739, 423);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditFundingLineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditFundingLineForm_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFundingLineEvents)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFundingLineEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnticipatedReminder;
        private System.Windows.Forms.TextBox txtInitialAmount;
        private System.Windows.Forms.TextBox txtRealReminder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.BindingSource bindingSourceFundingLineEvents;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewFundingLineEvents;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnAddFundingEvent;
        private System.Windows.Forms.LinkLabel btnDeleteFundingEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1FundingLineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5Type;


    }
}
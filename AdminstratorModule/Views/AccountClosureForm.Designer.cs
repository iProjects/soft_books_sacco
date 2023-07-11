namespace AdminstratorModule.Views
{
    partial class AccountClosureForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnGenerateEvents = new System.Windows.Forms.LinkLabel();
            this.btnView = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnPostBookings = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAccountClosure = new System.Windows.Forms.DataGridView();
            this.Columnaccountingclosureid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columndate_of_closure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columncount_of_transactions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnis_deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceAccountClosure = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountClosure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountClosure)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Controls.Add(this.btnGenerateEvents);
            this.groupBox4.Controls.Add(this.btnView);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.btnPostBookings);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(722, 47);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(591, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 18);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnGenerateEvents
            // 
            this.btnGenerateEvents.AutoSize = true;
            this.btnGenerateEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerateEvents.LinkColor = System.Drawing.Color.Yellow;
            this.btnGenerateEvents.Location = new System.Drawing.Point(278, 16);
            this.btnGenerateEvents.Name = "btnGenerateEvents";
            this.btnGenerateEvents.Size = new System.Drawing.Size(133, 18);
            this.btnGenerateEvents.TabIndex = 2;
            this.btnGenerateEvents.TabStop = true;
            this.btnGenerateEvents.Text = "Generate Events";
            this.btnGenerateEvents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnGenerateEvents_LinkClicked);
            // 
            // btnView
            // 
            this.btnView.AutoSize = true;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnView.LinkColor = System.Drawing.Color.Yellow;
            this.btnView.Location = new System.Drawing.Point(542, 16);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(43, 18);
            this.btnView.TabIndex = 0;
            this.btnView.TabStop = true;
            this.btnView.Text = "View";
            this.btnView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnView_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(653, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnPostBookings
            // 
            this.btnPostBookings.AutoSize = true;
            this.btnPostBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnPostBookings.LinkColor = System.Drawing.Color.Yellow;
            this.btnPostBookings.Location = new System.Drawing.Point(417, 16);
            this.btnPostBookings.Name = "btnPostBookings";
            this.btnPostBookings.Size = new System.Drawing.Size(119, 18);
            this.btnPostBookings.TabIndex = 1;
            this.btnPostBookings.TabStop = true;
            this.btnPostBookings.Text = "Post Bookings";
            this.btnPostBookings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPostBookings_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewAccountClosure);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 268);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewAccountClosure
            // 
            this.dataGridViewAccountClosure.AllowUserToAddRows = false;
            this.dataGridViewAccountClosure.AllowUserToDeleteRows = false;
            this.dataGridViewAccountClosure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccountClosure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnaccountingclosureid,
            this.Columndate_of_closure,
            this.Columncount_of_transactions,
            this.Columnis_deleted});
            this.dataGridViewAccountClosure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAccountClosure.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewAccountClosure.Name = "dataGridViewAccountClosure";
            this.dataGridViewAccountClosure.ReadOnly = true;
            this.dataGridViewAccountClosure.Size = new System.Drawing.Size(716, 249);
            this.dataGridViewAccountClosure.TabIndex = 2;
            // 
            // Columnaccountingclosureid
            // 
            this.Columnaccountingclosureid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnaccountingclosureid.DataPropertyName = "accountingclosureid";
            this.Columnaccountingclosureid.HeaderText = "Id";
            this.Columnaccountingclosureid.Name = "Columnaccountingclosureid";
            this.Columnaccountingclosureid.ReadOnly = true;
            this.Columnaccountingclosureid.Width = 40;
            // 
            // Columndate_of_closure
            // 
            this.Columndate_of_closure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columndate_of_closure.DataPropertyName = "date_of_closure";
            this.Columndate_of_closure.HeaderText = "date_of_closure";
            this.Columndate_of_closure.Name = "Columndate_of_closure";
            this.Columndate_of_closure.ReadOnly = true;
            this.Columndate_of_closure.Width = 120;
            // 
            // Columncount_of_transactions
            // 
            this.Columncount_of_transactions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columncount_of_transactions.DataPropertyName = "count_of_transactions";
            this.Columncount_of_transactions.HeaderText = "count_of_transactions";
            this.Columncount_of_transactions.Name = "Columncount_of_transactions";
            this.Columncount_of_transactions.ReadOnly = true;
            this.Columncount_of_transactions.Width = 120;
            // 
            // Columnis_deleted
            // 
            this.Columnis_deleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnis_deleted.DataPropertyName = "is_deleted";
            this.Columnis_deleted.HeaderText = "is_deleted";
            this.Columnis_deleted.Name = "Columnis_deleted";
            this.Columnis_deleted.ReadOnly = true;
            this.Columnis_deleted.Width = 120;
            // 
            // AccountClosureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(722, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "AccountClosureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Closures";
            this.Load += new System.EventHandler(this.AccountClosureForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountClosure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountClosure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnGenerateEvents;
        private System.Windows.Forms.LinkLabel btnView;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnPostBookings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewAccountClosure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnaccountingclosureid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndate_of_closure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columncount_of_transactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnis_deleted;
        private System.Windows.Forms.BindingSource bindingSourceAccountClosure;

    }
}
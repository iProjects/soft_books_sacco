using System;

namespace AdminstratorModule.Views
{
    partial class AuditTrailForm
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
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnRefresh = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAccountingRules = new System.Windows.Forms.DataGridView();
            this.Columnaccountingruleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columndescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerEndPeriod = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerStartPeriod = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIncludeDeleted = new System.Windows.Forms.CheckBox();
            this.btnCheckAll = new System.Windows.Forms.LinkLabel();
            this.btnUnCheckAll = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listViewEventTypes = new System.Windows.Forms.ListView();
            this.bindingSourceUsers = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceBankBranch = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountingRules)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBankBranch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(245, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 16);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.LinkColor = System.Drawing.Color.Yellow;
            this.btnRefresh.Location = new System.Drawing.Point(179, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(62, 16);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.TabStop = true;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRefresh_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewAccountingRules);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 373);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewAccountingRules
            // 
            this.dataGridViewAccountingRules.AllowUserToAddRows = false;
            this.dataGridViewAccountingRules.AllowUserToDeleteRows = false;
            this.dataGridViewAccountingRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccountingRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnaccountingruleid,
            this.Columndescription});
            this.dataGridViewAccountingRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAccountingRules.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewAccountingRules.Name = "dataGridViewAccountingRules";
            this.dataGridViewAccountingRules.ReadOnly = true;
            this.dataGridViewAccountingRules.Size = new System.Drawing.Size(547, 354);
            this.dataGridViewAccountingRules.TabIndex = 3;
            // 
            // Columnaccountingruleid
            // 
            this.Columnaccountingruleid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnaccountingruleid.DataPropertyName = "accountingruleid";
            this.Columnaccountingruleid.HeaderText = "Id";
            this.Columnaccountingruleid.Name = "Columnaccountingruleid";
            this.Columnaccountingruleid.ReadOnly = true;
            this.Columnaccountingruleid.Width = 40;
            // 
            // Columndescription
            // 
            this.Columndescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columndescription.DataPropertyName = "description";
            this.Columndescription.HeaderText = "Description";
            this.Columndescription.Name = "Columndescription";
            this.Columndescription.ReadOnly = true;
            this.Columndescription.Width = 180;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(553, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 373);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.btnRefresh);
            this.groupBox5.Controls.Add(this.chkIncludeDeleted);
            this.groupBox5.Controls.Add(this.btnCheckAll);
            this.groupBox5.Controls.Add(this.btnUnCheckAll);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 143);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(344, 227);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dateTimePickerEndPeriod);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.dateTimePickerStartPeriod);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.cboBranch);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.cboUsers);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(3, 65);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(338, 159);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            // 
            // dateTimePickerEndPeriod
            // 
            this.dateTimePickerEndPeriod.Location = new System.Drawing.Point(187, 121);
            this.dateTimePickerEndPeriod.Name = "dateTimePickerEndPeriod";
            this.dateTimePickerEndPeriod.Size = new System.Drawing.Size(134, 20);
            this.dateTimePickerEndPeriod.TabIndex = 7;
            this.dateTimePickerEndPeriod.Value = new System.DateTime(2013, 1, 29, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "__";
            // 
            // dateTimePickerStartPeriod
            // 
            this.dateTimePickerStartPeriod.Location = new System.Drawing.Point(13, 121);
            this.dateTimePickerStartPeriod.Name = "dateTimePickerStartPeriod";
            this.dateTimePickerStartPeriod.Size = new System.Drawing.Size(143, 20);
            this.dateTimePickerStartPeriod.TabIndex = 5;
            this.dateTimePickerStartPeriod.Value = new System.DateTime(2012, 1, 29, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Period";
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(52, 58);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(197, 21);
            this.cboBranch.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Branch";
            // 
            // cboUsers
            // 
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(52, 17);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(197, 21);
            this.cboUsers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            // 
            // chkIncludeDeleted
            // 
            this.chkIncludeDeleted.AutoSize = true;
            this.chkIncludeDeleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIncludeDeleted.Location = new System.Drawing.Point(16, 41);
            this.chkIncludeDeleted.Name = "chkIncludeDeleted";
            this.chkIncludeDeleted.Size = new System.Drawing.Size(98, 17);
            this.chkIncludeDeleted.TabIndex = 4;
            this.chkIncludeDeleted.Text = "Include Deleted";
            this.chkIncludeDeleted.UseVisualStyleBackColor = true;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.AutoSize = true;
            this.btnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAll.LinkColor = System.Drawing.Color.Yellow;
            this.btnCheckAll.Location = new System.Drawing.Point(11, 14);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(73, 16);
            this.btnCheckAll.TabIndex = 3;
            this.btnCheckAll.TabStop = true;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCheckAll_LinkClicked);
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.AutoSize = true;
            this.btnUnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnCheckAll.LinkColor = System.Drawing.Color.Yellow;
            this.btnUnCheckAll.Location = new System.Drawing.Point(86, 14);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(92, 16);
            this.btnUnCheckAll.TabIndex = 2;
            this.btnUnCheckAll.TabStop = true;
            this.btnUnCheckAll.Text = "UnCheck All";
            this.btnUnCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUnCheckAll_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listViewEventTypes);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(344, 127);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // listViewEventTypes
            // 
            this.listViewEventTypes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewEventTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewEventTypes.CheckBoxes = true;
            this.listViewEventTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEventTypes.FullRowSelect = true;
            this.listViewEventTypes.HideSelection = false;
            this.listViewEventTypes.HotTracking = true;
            this.listViewEventTypes.HoverSelection = true;
            this.listViewEventTypes.Location = new System.Drawing.Point(3, 16);
            this.listViewEventTypes.MultiSelect = false;
            this.listViewEventTypes.Name = "listViewEventTypes";
            this.listViewEventTypes.ShowItemToolTips = true;
            this.listViewEventTypes.Size = new System.Drawing.Size(338, 108);
            this.listViewEventTypes.TabIndex = 0;
            this.listViewEventTypes.UseCompatibleStateImageBehavior = false;
            // 
            // AuditTrailForm
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(903, 373);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "AuditTrailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audit Trail";
            this.Load += new System.EventHandler(this.AuditTrailForm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountingRules)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBankBranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listViewEventTypes;
        private System.Windows.Forms.CheckBox chkIncludeDeleted;
        private System.Windows.Forms.LinkLabel btnCheckAll;
        private System.Windows.Forms.LinkLabel btnUnCheckAll;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnRefresh;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSourceUsers;
        private System.Windows.Forms.BindingSource bindingSourceBankBranch;
        private System.Windows.Forms.DataGridView dataGridViewAccountingRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnaccountingruleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndescription;
    }
}
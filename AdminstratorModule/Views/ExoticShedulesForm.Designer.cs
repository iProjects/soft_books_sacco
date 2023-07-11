using System;

namespace AdminstratorModule.Views
{
    partial class ExoticShedulesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteName = new System.Windows.Forms.LinkLabel();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAddName = new System.Windows.Forms.LinkLabel();
            this.cboExoticShedules = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.dataGridViewExoticInstallments = new System.Windows.Forms.DataGridView();
            this.Column1CycleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnprincipal_coeff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columninterest_coeff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.lblTotalInterest = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.LinkLabel();
            this.lblTotalPrincipal = new System.Windows.Forms.Label();
            this.btnDeleteInstallment = new System.Windows.Forms.LinkLabel();
            this.btnUp = new System.Windows.Forms.LinkLabel();
            this.btnAddInstallment = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceExotics = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceExoticInstallments = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox28.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExoticInstallments)).BeginInit();
            this.groupBox30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExotics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExoticInstallments)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.btnSave);
            this.groupBox28.Controls.Add(this.btnClose);
            this.groupBox28.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox28.Location = new System.Drawing.Point(0, 339);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(648, 34);
            this.groupBox28.TabIndex = 19;
            this.groupBox28.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.LinkColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(231, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 18);
            this.btnSave.TabIndex = 16;
            this.btnSave.TabStop = true;
            this.btnSave.Text = "Save";
            this.btnSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSave_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(342, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 17;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteName);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.btnAddName);
            this.groupBox2.Controls.Add(this.cboExoticShedules);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 62);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Template Name";
            // 
            // btnDeleteName
            // 
            this.btnDeleteName.AutoSize = true;
            this.btnDeleteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteName.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteName.Location = new System.Drawing.Point(537, 23);
            this.btnDeleteName.Name = "btnDeleteName";
            this.btnDeleteName.Size = new System.Drawing.Size(49, 15);
            this.btnDeleteName.TabIndex = 18;
            this.btnDeleteName.TabStop = true;
            this.btnDeleteName.Text = "Delete";
            this.btnDeleteName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteName_LinkClicked);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "Description*";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(84, 20);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(126, 20);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // btnAddName
            // 
            this.btnAddName.AutoSize = true;
            this.btnAddName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddName.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddName.Location = new System.Drawing.Point(252, 23);
            this.btnAddName.Name = "btnAddName";
            this.btnAddName.Size = new System.Drawing.Size(31, 15);
            this.btnAddName.TabIndex = 15;
            this.btnAddName.TabStop = true;
            this.btnAddName.Text = "Add";
            this.btnAddName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddName_LinkClicked);
            // 
            // cboExoticShedules
            // 
            this.cboExoticShedules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExoticShedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboExoticShedules.FormattingEnabled = true;
            this.cboExoticShedules.Location = new System.Drawing.Point(323, 20);
            this.cboExoticShedules.Name = "cboExoticShedules";
            this.cboExoticShedules.Size = new System.Drawing.Size(178, 21);
            this.cboExoticShedules.TabIndex = 2;
            this.cboExoticShedules.SelectedIndexChanged += new System.EventHandler(this.cboExoticShedules_SelectedIndexChanged);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.dataGridViewExoticInstallments);
            this.groupBox15.Controls.Add(this.groupBox30);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox15.Location = new System.Drawing.Point(0, 62);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(648, 277);
            this.groupBox15.TabIndex = 22;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Installment Configuration";
            // 
            // dataGridViewExoticInstallments
            // 
            this.dataGridViewExoticInstallments.AllowUserToAddRows = false;
            this.dataGridViewExoticInstallments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExoticInstallments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExoticInstallments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExoticInstallments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1CycleId,
            this.Columnprincipal_coeff,
            this.Columninterest_coeff});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewExoticInstallments.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewExoticInstallments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExoticInstallments.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewExoticInstallments.MultiSelect = false;
            this.dataGridViewExoticInstallments.Name = "dataGridViewExoticInstallments";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExoticInstallments.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewExoticInstallments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExoticInstallments.Size = new System.Drawing.Size(482, 258);
            this.dataGridViewExoticInstallments.TabIndex = 0;
            this.dataGridViewExoticInstallments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCycleObjectParameters_CellClick);
            this.dataGridViewExoticInstallments.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewCycleObjectParameters_DataError);
            // 
            // Column1CycleId
            // 
            this.Column1CycleId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1CycleId.DataPropertyName = "number";
            this.Column1CycleId.HeaderText = "Id";
            this.Column1CycleId.Name = "Column1CycleId";
            this.Column1CycleId.ReadOnly = true;
            this.Column1CycleId.Width = 50;
            // 
            // Columnprincipal_coeff
            // 
            this.Columnprincipal_coeff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnprincipal_coeff.DataPropertyName = "principal_coeff";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Columnprincipal_coeff.DefaultCellStyle = dataGridViewCellStyle2;
            this.Columnprincipal_coeff.HeaderText = "Principal(%)";
            this.Columnprincipal_coeff.Name = "Columnprincipal_coeff";
            this.Columnprincipal_coeff.Width = 150;
            // 
            // Columninterest_coeff
            // 
            this.Columninterest_coeff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columninterest_coeff.DataPropertyName = "interest_coeff";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Columninterest_coeff.DefaultCellStyle = dataGridViewCellStyle3;
            this.Columninterest_coeff.HeaderText = "Interest(%)";
            this.Columninterest_coeff.Name = "Columninterest_coeff";
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.lblTotalInterest);
            this.groupBox30.Controls.Add(this.btnDown);
            this.groupBox30.Controls.Add(this.lblTotalPrincipal);
            this.groupBox30.Controls.Add(this.btnDeleteInstallment);
            this.groupBox30.Controls.Add(this.btnUp);
            this.groupBox30.Controls.Add(this.btnAddInstallment);
            this.groupBox30.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox30.Location = new System.Drawing.Point(485, 16);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(160, 258);
            this.groupBox30.TabIndex = 1;
            this.groupBox30.TabStop = false;
            // 
            // lblTotalInterest
            // 
            this.lblTotalInterest.AutoSize = true;
            this.lblTotalInterest.Location = new System.Drawing.Point(6, 213);
            this.lblTotalInterest.Name = "lblTotalInterest";
            this.lblTotalInterest.Size = new System.Drawing.Size(69, 13);
            this.lblTotalInterest.TabIndex = 19;
            this.lblTotalInterest.Text = "Total Interest";
            // 
            // btnDown
            // 
            this.btnDown.AutoSize = true;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.LinkColor = System.Drawing.Color.Yellow;
            this.btnDown.Location = new System.Drawing.Point(9, 103);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(43, 15);
            this.btnDown.TabIndex = 18;
            this.btnDown.TabStop = true;
            this.btnDown.Text = "Down";
            this.btnDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDown_LinkClicked);
            // 
            // lblTotalPrincipal
            // 
            this.lblTotalPrincipal.AutoSize = true;
            this.lblTotalPrincipal.Location = new System.Drawing.Point(6, 179);
            this.lblTotalPrincipal.Name = "lblTotalPrincipal";
            this.lblTotalPrincipal.Size = new System.Drawing.Size(74, 13);
            this.lblTotalPrincipal.TabIndex = 17;
            this.lblTotalPrincipal.Text = "Total Principal";
            // 
            // btnDeleteInstallment
            // 
            this.btnDeleteInstallment.AutoSize = true;
            this.btnDeleteInstallment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInstallment.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteInstallment.Location = new System.Drawing.Point(89, 103);
            this.btnDeleteInstallment.Name = "btnDeleteInstallment";
            this.btnDeleteInstallment.Size = new System.Drawing.Size(49, 15);
            this.btnDeleteInstallment.TabIndex = 18;
            this.btnDeleteInstallment.TabStop = true;
            this.btnDeleteInstallment.Text = "Delete";
            this.btnDeleteInstallment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteInstallment_LinkClicked);
            // 
            // btnUp
            // 
            this.btnUp.AutoSize = true;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.LinkColor = System.Drawing.Color.Yellow;
            this.btnUp.Location = new System.Drawing.Point(9, 72);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(25, 15);
            this.btnUp.TabIndex = 15;
            this.btnUp.TabStop = true;
            this.btnUp.Text = "Up";
            this.btnUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUp_LinkClicked);
            // 
            // btnAddInstallment
            // 
            this.btnAddInstallment.AutoSize = true;
            this.btnAddInstallment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInstallment.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddInstallment.Location = new System.Drawing.Point(89, 72);
            this.btnAddInstallment.Name = "btnAddInstallment";
            this.btnAddInstallment.Size = new System.Drawing.Size(31, 15);
            this.btnAddInstallment.TabIndex = 15;
            this.btnAddInstallment.TabStop = true;
            this.btnAddInstallment.Text = "Add";
            this.btnAddInstallment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddInstallment_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "_cycle_parameter_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "min";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Principal(%)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "max";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Interest(%)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // ExoticShedulesForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(648, 373);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox28);
            this.Name = "ExoticShedulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exotic Schedule Template";
            this.Load += new System.EventHandler(this.ExoticShedulesForm_Load);
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExoticInstallments)).EndInit();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExotics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExoticInstallments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.LinkLabel btnSave;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.ComboBox cboExoticShedules;
        private System.Windows.Forms.LinkLabel btnDeleteName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.LinkLabel btnAddName;
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.DataGridView dataGridViewExoticInstallments;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTotalInterest;
        private System.Windows.Forms.LinkLabel btnDown;
        private System.Windows.Forms.Label lblTotalPrincipal;
        private System.Windows.Forms.LinkLabel btnDeleteInstallment;
        private System.Windows.Forms.LinkLabel btnUp;
        private System.Windows.Forms.LinkLabel btnAddInstallment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource bindingSourceExotics;
        private System.Windows.Forms.BindingSource bindingSourceExoticInstallments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1CycleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnprincipal_coeff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columninterest_coeff;

    }
}
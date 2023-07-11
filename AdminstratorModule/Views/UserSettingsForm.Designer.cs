namespace AdminstratorModule.Views
{
    partial class UserSettingsForm
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
            this.chkcheckUpdates = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConsolidationExportPath = new System.Windows.Forms.Button();
            this.btnBackupExportPath = new System.Windows.Forms.Button();
            this.txtConsolidationExportPath = new System.Windows.Forms.TextBox();
            this.txtBackupExportPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkcheckUpdates
            // 
            this.chkcheckUpdates.AutoSize = true;
            this.chkcheckUpdates.Checked = true;
            this.chkcheckUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkcheckUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkcheckUpdates.Location = new System.Drawing.Point(76, 19);
            this.chkcheckUpdates.Name = "chkcheckUpdates";
            this.chkcheckUpdates.Size = new System.Drawing.Size(415, 17);
            this.chkcheckUpdates.TabIndex = 0;
            this.chkcheckUpdates.Text = "Check for updates and share anonymous information to improve Soft Books Sacco ";
            this.chkcheckUpdates.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 35);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(289, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.LinkColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(222, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 18);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = true;
            this.btnSave.Text = "Save";
            this.btnSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSave_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnConsolidationExportPath);
            this.groupBox3.Controls.Add(this.btnBackupExportPath);
            this.groupBox3.Controls.Add(this.chkcheckUpdates);
            this.groupBox3.Controls.Add(this.txtConsolidationExportPath);
            this.groupBox3.Controls.Add(this.txtBackupExportPath);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 123);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paths";
            // 
            // btnConsolidationExportPath
            // 
            this.btnConsolidationExportPath.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnConsolidationExportPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsolidationExportPath.Location = new System.Drawing.Point(462, 88);
            this.btnConsolidationExportPath.Name = "btnConsolidationExportPath";
            this.btnConsolidationExportPath.Size = new System.Drawing.Size(29, 23);
            this.btnConsolidationExportPath.TabIndex = 4;
            this.btnConsolidationExportPath.Text = ":::";
            this.btnConsolidationExportPath.UseVisualStyleBackColor = false;
            this.btnConsolidationExportPath.Click += new System.EventHandler(this.btnConsolidationExportPath_Click);
            // 
            // btnBackupExportPath
            // 
            this.btnBackupExportPath.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBackupExportPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupExportPath.Location = new System.Drawing.Point(463, 51);
            this.btnBackupExportPath.Name = "btnBackupExportPath";
            this.btnBackupExportPath.Size = new System.Drawing.Size(29, 23);
            this.btnBackupExportPath.TabIndex = 3;
            this.btnBackupExportPath.Text = ":::";
            this.btnBackupExportPath.UseVisualStyleBackColor = false;
            this.btnBackupExportPath.Click += new System.EventHandler(this.btnBackupExportPath_Click);
            // 
            // txtConsolidationExportPath
            // 
            this.txtConsolidationExportPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsolidationExportPath.Location = new System.Drawing.Point(141, 89);
            this.txtConsolidationExportPath.Name = "txtConsolidationExportPath";
            this.txtConsolidationExportPath.Size = new System.Drawing.Size(295, 20);
            this.txtConsolidationExportPath.TabIndex = 2;
            this.txtConsolidationExportPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsolidationExportPath_KeyPress);
            // 
            // txtBackupExportPath
            // 
            this.txtBackupExportPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBackupExportPath.Location = new System.Drawing.Point(141, 52);
            this.txtBackupExportPath.Name = "txtBackupExportPath";
            this.txtBackupExportPath.Size = new System.Drawing.Size(295, 20);
            this.txtBackupExportPath.TabIndex = 1;
            this.txtBackupExportPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBackupExportPath_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Consolidation Export Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Export Path";
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(524, 158);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "UserSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Settings";
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkcheckUpdates;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel btnSave;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.Button btnConsolidationExportPath;
        private System.Windows.Forms.Button btnBackupExportPath;
        private System.Windows.Forms.TextBox txtConsolidationExportPath;
        private System.Windows.Forms.TextBox txtBackupExportPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
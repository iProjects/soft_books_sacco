namespace DatabaseAdministrationModule.Views
{
    partial class DatabaseMaintenanceForm
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
            this.btnRebuildLoanCycle = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShrinkDatabase = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddAllMissingCashFlows = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnRebuildConsolidations = new System.Windows.Forms.LinkLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRunSQL = new System.Windows.Forms.LinkLabel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRebuildLoanCycle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loan Cycle";
            // 
            // btnRebuildLoanCycle
            // 
            this.btnRebuildLoanCycle.AutoSize = true;
            this.btnRebuildLoanCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRebuildLoanCycle.LinkColor = System.Drawing.Color.Yellow;
            this.btnRebuildLoanCycle.Location = new System.Drawing.Point(131, 33);
            this.btnRebuildLoanCycle.Name = "btnRebuildLoanCycle";
            this.btnRebuildLoanCycle.Size = new System.Drawing.Size(172, 20);
            this.btnRebuildLoanCycle.TabIndex = 18;
            this.btnRebuildLoanCycle.TabStop = true;
            this.btnRebuildLoanCycle.Text = "Rebuild Loan Cycles";
            this.btnRebuildLoanCycle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRebuildLoanCycle_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnShrinkDatabase);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Disk Usage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Database Size:";
            // 
            // btnShrinkDatabase
            // 
            this.btnShrinkDatabase.AutoSize = true;
            this.btnShrinkDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShrinkDatabase.LinkColor = System.Drawing.Color.Yellow;
            this.btnShrinkDatabase.Location = new System.Drawing.Point(131, 49);
            this.btnShrinkDatabase.Name = "btnShrinkDatabase";
            this.btnShrinkDatabase.Size = new System.Drawing.Size(143, 20);
            this.btnShrinkDatabase.TabIndex = 18;
            this.btnShrinkDatabase.TabStop = true;
            this.btnShrinkDatabase.Text = "Shrink Database";
            this.btnShrinkDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnShrinkDatabase_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddAllMissingCashFlows);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cash-Flows";
            // 
            // btnAddAllMissingCashFlows
            // 
            this.btnAddAllMissingCashFlows.AutoSize = true;
            this.btnAddAllMissingCashFlows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAllMissingCashFlows.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddAllMissingCashFlows.Location = new System.Drawing.Point(131, 31);
            this.btnAddAllMissingCashFlows.Name = "btnAddAllMissingCashFlows";
            this.btnAddAllMissingCashFlows.Size = new System.Drawing.Size(227, 20);
            this.btnAddAllMissingCashFlows.TabIndex = 18;
            this.btnAddAllMissingCashFlows.TabStop = true;
            this.btnAddAllMissingCashFlows.Text = "Add all Missing Cash-Flows";
            this.btnAddAllMissingCashFlows.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddAllMissingCashFlows_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.btnRebuildConsolidations);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 264);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 93);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Consolidations";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(135, 58);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(178, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Overwrite Existing Consolidations";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnRebuildConsolidations
            // 
            this.btnRebuildConsolidations.AutoSize = true;
            this.btnRebuildConsolidations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRebuildConsolidations.LinkColor = System.Drawing.Color.Yellow;
            this.btnRebuildConsolidations.Location = new System.Drawing.Point(131, 16);
            this.btnRebuildConsolidations.Name = "btnRebuildConsolidations";
            this.btnRebuildConsolidations.Size = new System.Drawing.Size(193, 20);
            this.btnRebuildConsolidations.TabIndex = 18;
            this.btnRebuildConsolidations.TabStop = true;
            this.btnRebuildConsolidations.Text = "Rebuild Consolidations";
            this.btnRebuildConsolidations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRebuildConsolidations_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRunSQL);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 357);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(461, 80);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SQL Maintenance";
            // 
            // btnRunSQL
            // 
            this.btnRunSQL.AutoSize = true;
            this.btnRunSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSQL.LinkColor = System.Drawing.Color.Yellow;
            this.btnRunSQL.Location = new System.Drawing.Point(131, 30);
            this.btnRunSQL.Name = "btnRunSQL";
            this.btnRunSQL.Size = new System.Drawing.Size(82, 20);
            this.btnRunSQL.TabIndex = 18;
            this.btnRunSQL.TabStop = true;
            this.btnRunSQL.Text = "Run SQL";
            this.btnRunSQL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRunSQL_LinkClicked);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnClose);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 437);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(461, 47);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(365, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 18;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // DatabaseMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(461, 484);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Name = "DatabaseMaintenanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Maintenance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.LinkLabel btnRebuildLoanCycle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel btnShrinkDatabase;
        private System.Windows.Forms.LinkLabel btnAddAllMissingCashFlows;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.LinkLabel btnRebuildConsolidations;
        private System.Windows.Forms.LinkLabel btnRunSQL;
        private System.Windows.Forms.LinkLabel btnClose;
    }
}
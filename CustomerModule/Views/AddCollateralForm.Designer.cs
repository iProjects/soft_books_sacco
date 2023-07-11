namespace CustomerModule.Views
{
    partial class AddCollateralForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCollateralForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCollaterals = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCollateralDescription = new System.Windows.Forms.Label();
            this.lblCollateralName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSelectOwner = new System.Windows.Forms.LinkLabel();
            this.btnClearOwner = new System.Windows.Forms.LinkLabel();
            this.btnAddOwner = new System.Windows.Forms.LinkLabel();
            this.bindingSourceCollaterals = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollaterals)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollaterals)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewCollaterals);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewCollaterals
            // 
            this.dataGridViewCollaterals.AllowUserToAddRows = false;
            this.dataGridViewCollaterals.AllowUserToDeleteRows = false;
            this.dataGridViewCollaterals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCollaterals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCollaterals.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewCollaterals.MultiSelect = false;
            this.dataGridViewCollaterals.Name = "dataGridViewCollaterals";
            this.dataGridViewCollaterals.Size = new System.Drawing.Size(639, 342);
            this.dataGridViewCollaterals.TabIndex = 0;
            this.dataGridViewCollaterals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCollaterals_CellClick);
            this.dataGridViewCollaterals.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewCollaterals_DataError);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCollateralDescription);
            this.groupBox2.Controls.Add(this.lblCollateralName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 73);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblCollateralDescription
            // 
            this.lblCollateralDescription.AutoSize = true;
            this.lblCollateralDescription.Location = new System.Drawing.Point(13, 46);
            this.lblCollateralDescription.Name = "lblCollateralDescription";
            this.lblCollateralDescription.Size = new System.Drawing.Size(64, 13);
            this.lblCollateralDescription.TabIndex = 1;
            this.lblCollateralDescription.Text = "Description*";
            // 
            // lblCollateralName
            // 
            this.lblCollateralName.AutoSize = true;
            this.lblCollateralName.Location = new System.Drawing.Point(13, 20);
            this.lblCollateralName.Name = "lblCollateralName";
            this.lblCollateralName.Size = new System.Drawing.Size(39, 13);
            this.lblCollateralName.TabIndex = 0;
            this.lblCollateralName.Text = "Name*";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 474);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(645, 39);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(247, 9);
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
            this.btnClose.Location = new System.Drawing.Point(309, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSelectOwner);
            this.groupBox3.Controls.Add(this.btnClearOwner);
            this.groupBox3.Controls.Add(this.btnAddOwner);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 434);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(645, 40);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Owner Management";
            // 
            // btnSelectOwner
            // 
            this.btnSelectOwner.AutoSize = true;
            this.btnSelectOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSelectOwner.LinkColor = System.Drawing.Color.Yellow;
            this.btnSelectOwner.Location = new System.Drawing.Point(276, 9);
            this.btnSelectOwner.Name = "btnSelectOwner";
            this.btnSelectOwner.Size = new System.Drawing.Size(109, 18);
            this.btnSelectOwner.TabIndex = 15;
            this.btnSelectOwner.TabStop = true;
            this.btnSelectOwner.Text = "Select Owner";
            this.btnSelectOwner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSelectOwner_LinkClicked);
            // 
            // btnClearOwner
            // 
            this.btnClearOwner.AutoSize = true;
            this.btnClearOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClearOwner.LinkColor = System.Drawing.Color.Yellow;
            this.btnClearOwner.Location = new System.Drawing.Point(396, 9);
            this.btnClearOwner.Name = "btnClearOwner";
            this.btnClearOwner.Size = new System.Drawing.Size(102, 18);
            this.btnClearOwner.TabIndex = 14;
            this.btnClearOwner.TabStop = true;
            this.btnClearOwner.Text = "Clear Owner";
            this.btnClearOwner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClearOwner_LinkClicked);
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.AutoSize = true;
            this.btnAddOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddOwner.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddOwner.Location = new System.Drawing.Point(175, 9);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(90, 18);
            this.btnAddOwner.TabIndex = 16;
            this.btnAddOwner.TabStop = true;
            this.btnAddOwner.Text = "Add Owner";
            this.btnAddOwner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddOwner_LinkClicked);
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
            // AddCollateralForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(645, 513);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCollateralForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Collateral";
            this.Load += new System.EventHandler(this.AddCollateralForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollaterals)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCollaterals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCollateralDescription;
        private System.Windows.Forms.Label lblCollateralName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnSelectOwner;
        private System.Windows.Forms.LinkLabel btnClearOwner;
        private System.Windows.Forms.LinkLabel btnAddOwner;
        private System.Windows.Forms.BindingSource bindingSourceCollaterals;
        private System.Windows.Forms.DataGridView dataGridViewCollaterals;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
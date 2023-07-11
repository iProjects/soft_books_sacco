namespace AdminstratorModule.Views
{
    partial class CurrenciesForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.bindingSourceCurrencies = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCurrencies = new System.Windows.Forms.DataGridView();
            this.ColumnCurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrencyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUseCents = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsPivot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsSwapped = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCurrencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrencies)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 49);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(508, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 18);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.LinkColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(461, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(37, 18);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.TabStop = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEdit_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(415, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(574, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewCurrencies);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 324);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewCurrencies
            // 
            this.dataGridViewCurrencies.AllowUserToAddRows = false;
            this.dataGridViewCurrencies.AllowUserToDeleteRows = false;
            this.dataGridViewCurrencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCurrencyName,
            this.ColumnCurrencyCode,
            this.ColumnUseCents,
            this.ColumnIsPivot,
            this.ColumnIsSwapped});
            this.dataGridViewCurrencies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCurrencies.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewCurrencies.MultiSelect = false;
            this.dataGridViewCurrencies.Name = "dataGridViewCurrencies";
            this.dataGridViewCurrencies.ReadOnly = true;
            this.dataGridViewCurrencies.Size = new System.Drawing.Size(632, 305);
            this.dataGridViewCurrencies.TabIndex = 0;
            this.dataGridViewCurrencies.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCurrencies_CellContentDoubleClick);
            // 
            // ColumnCurrencyName
            // 
            this.ColumnCurrencyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCurrencyName.DataPropertyName = "name";
            this.ColumnCurrencyName.HeaderText = "Name";
            this.ColumnCurrencyName.Name = "ColumnCurrencyName";
            this.ColumnCurrencyName.ReadOnly = true;
            this.ColumnCurrencyName.Width = 150;
            // 
            // ColumnCurrencyCode
            // 
            this.ColumnCurrencyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCurrencyCode.DataPropertyName = "code";
            this.ColumnCurrencyCode.HeaderText = "Code";
            this.ColumnCurrencyCode.Name = "ColumnCurrencyCode";
            this.ColumnCurrencyCode.ReadOnly = true;
            // 
            // ColumnUseCents
            // 
            this.ColumnUseCents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnUseCents.DataPropertyName = "use_cents";
            this.ColumnUseCents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnUseCents.HeaderText = "Use Cents";
            this.ColumnUseCents.Name = "ColumnUseCents";
            this.ColumnUseCents.ReadOnly = true;
            this.ColumnUseCents.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUseCents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnIsPivot
            // 
            this.ColumnIsPivot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnIsPivot.DataPropertyName = "is_pivot";
            this.ColumnIsPivot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnIsPivot.HeaderText = "Is Pivot";
            this.ColumnIsPivot.Name = "ColumnIsPivot";
            this.ColumnIsPivot.ReadOnly = true;
            // 
            // ColumnIsSwapped
            // 
            this.ColumnIsSwapped.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIsSwapped.DataPropertyName = "is_swapped";
            this.ColumnIsSwapped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnIsSwapped.HeaderText = "Is Swapped";
            this.ColumnIsSwapped.Name = "ColumnIsSwapped";
            this.ColumnIsSwapped.ReadOnly = true;
            // 
            // CurrenciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(638, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "CurrenciesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Currencies";
            this.Load += new System.EventHandler(this.CurrenciesForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCurrencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrencies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.BindingSource bindingSourceCurrencies;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnEdit;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewCurrencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurrencyCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUseCents;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsPivot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsSwapped;
    }
}
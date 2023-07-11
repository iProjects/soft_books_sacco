namespace AdminstratorModule.Views
{
    partial class EditCurrencyForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUseCents = new System.Windows.Forms.CheckBox();
            this.chkIsPivot = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsSwapped = new System.Windows.Forms.CheckBox();
            this.txtCurrencyCode = new System.Windows.Forms.TextBox();
            this.txtCurrencyName = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(204, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(115, 16);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(68, 20);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = true;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpdate_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUseCents);
            this.groupBox1.Controls.Add(this.chkIsPivot);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkIsSwapped);
            this.groupBox1.Controls.Add(this.txtCurrencyCode);
            this.groupBox1.Controls.Add(this.txtCurrencyName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkUseCents
            // 
            this.chkUseCents.AutoSize = true;
            this.chkUseCents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseCents.Location = new System.Drawing.Point(103, 173);
            this.chkUseCents.Name = "chkUseCents";
            this.chkUseCents.Size = new System.Drawing.Size(72, 17);
            this.chkUseCents.TabIndex = 4;
            this.chkUseCents.Text = "Use Cents";
            this.chkUseCents.UseVisualStyleBackColor = true;
            // 
            // chkIsPivot
            // 
            this.chkIsPivot.AutoSize = true;
            this.chkIsPivot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsPivot.Location = new System.Drawing.Point(103, 138);
            this.chkIsPivot.Name = "chkIsPivot";
            this.chkIsPivot.Size = new System.Drawing.Size(58, 17);
            this.chkIsPivot.TabIndex = 3;
            this.chkIsPivot.Text = "Is Pivot";
            this.chkIsPivot.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Currency Code*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Currency Name*";
            // 
            // chkIsSwapped
            // 
            this.chkIsSwapped.AutoSize = true;
            this.chkIsSwapped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsSwapped.Location = new System.Drawing.Point(103, 99);
            this.chkIsSwapped.Name = "chkIsSwapped";
            this.chkIsSwapped.Size = new System.Drawing.Size(79, 17);
            this.chkIsSwapped.TabIndex = 2;
            this.chkIsSwapped.Text = "Is Swapped";
            this.chkIsSwapped.UseVisualStyleBackColor = true;
            // 
            // txtCurrencyCode
            // 
            this.txtCurrencyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrencyCode.Location = new System.Drawing.Point(103, 60);
            this.txtCurrencyCode.MaxLength = 5;
            this.txtCurrencyCode.Name = "txtCurrencyCode";
            this.txtCurrencyCode.Size = new System.Drawing.Size(182, 20);
            this.txtCurrencyCode.TabIndex = 1;
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrencyName.Location = new System.Drawing.Point(103, 24);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(182, 20);
            this.txtCurrencyName.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditCurrencyForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(315, 274);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "EditCurrencyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditCurrencyForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUseCents;
        private System.Windows.Forms.CheckBox chkIsPivot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsSwapped;
        private System.Windows.Forms.TextBox txtCurrencyCode;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
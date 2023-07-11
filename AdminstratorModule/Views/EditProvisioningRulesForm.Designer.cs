namespace AdminstratorModule.Views
{
    partial class EditProvisioningRulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProvisioningRulesForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtnumber_of_days_max = new System.Windows.Forms.TextBox();
            this.txtnumber_of_days_min = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtprovisioning_value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtprovisioning_value);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtnumber_of_days_max);
            this.groupBox2.Controls.Add(this.txtnumber_of_days_min);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 133);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtnumber_of_days_max
            // 
            this.txtnumber_of_days_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnumber_of_days_max.Location = new System.Drawing.Point(134, 63);
            this.txtnumber_of_days_max.MaxLength = 4;
            this.txtnumber_of_days_max.Name = "txtnumber_of_days_max";
            this.txtnumber_of_days_max.Size = new System.Drawing.Size(195, 20);
            this.txtnumber_of_days_max.TabIndex = 1;
            this.txtnumber_of_days_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnumber_of_days_max_KeyDown);
            this.txtnumber_of_days_max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnumber_of_days_max_KeyPress);
            // 
            // txtnumber_of_days_min
            // 
            this.txtnumber_of_days_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnumber_of_days_min.Location = new System.Drawing.Point(134, 25);
            this.txtnumber_of_days_min.MaxLength = 4;
            this.txtnumber_of_days_min.Name = "txtnumber_of_days_min";
            this.txtnumber_of_days_min.Size = new System.Drawing.Size(195, 20);
            this.txtnumber_of_days_min.TabIndex = 0;
            this.txtnumber_of_days_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnumber_of_days_min_KeyDown);
            this.txtnumber_of_days_min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnumber_of_days_min_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "number_of_days_max*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "number_of_days_min*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(247, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(123, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtprovisioning_value
            // 
            this.txtprovisioning_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtprovisioning_value.Location = new System.Drawing.Point(134, 100);
            this.txtprovisioning_value.MaxLength = 8;
            this.txtprovisioning_value.Name = "txtprovisioning_value";
            this.txtprovisioning_value.Size = new System.Drawing.Size(195, 20);
            this.txtprovisioning_value.TabIndex = 2;
            this.txtprovisioning_value.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtprovisioning_value_KeyDown);
            this.txtprovisioning_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprovisioning_value_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "provisioning_value*";
            // 
            // EditProvisioningRulesForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(397, 196);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditProvisioningRulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditProvisioningRulesForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtnumber_of_days_max;
        private System.Windows.Forms.TextBox txtnumber_of_days_min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtprovisioning_value;
        private System.Windows.Forms.Label label3;

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class PaymentMethodsForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int _userid;
        #endregion "Private Fields"

        #region "Constructor"
        public PaymentMethodsForm(int userid,string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _userid = userid;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewPaymentMethods.SelectedRows.Count != 0)
            {
                try
                {
                    PaymentMethodModel pay = (PaymentMethodModel)bindingSourcePaymentMethods.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Payment\n" + pay.description.ToUpper().Trim(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeletePaymentMethod(pay);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewPaymentMethods.SelectedRows.Count != 0)
            {
                try
                {
                    PaymentMethodModel pay = (PaymentMethodModel)bindingSourcePaymentMethods.Current;
                    Views.EditPaymentMethods edu = new EditPaymentMethods(pay, connection) { Owner = this };
                    edu.Text = pay.name.ToUpper().Trim();
                    edu.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }

        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddPaymentMethod usf = new AddPaymentMethod(connection) { Owner = this };
                usf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void dataGridViewPaymentMethods_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPaymentMethods.SelectedRows.Count != 0)
            {
                try
                {
                    PaymentMethodModel pay = (PaymentMethodModel)bindingSourcePaymentMethods.Current;
                    Views.EditPaymentMethods edu = new EditPaymentMethods(pay, connection) { Owner = this };
                    edu.Text = pay.name.ToUpper().Trim();
                    edu.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }

        } 
        public void RefreshGrid()
        {
            if (dataGridViewPaymentMethods.SelectedRows.Count != 0)
            {
                try
                { 
                    bindingSourcePaymentMethods.DataSource = null;
                    bindingSourcePaymentMethods.DataSource = rep.GetNonDeletedPaymentMethods();
                    groupBox4.Text = bindingSourcePaymentMethods.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewPaymentMethods.Rows)
                    {
                        dataGridViewPaymentMethods.Rows[dataGridViewPaymentMethods.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewPaymentMethods.Rows.Count - 1;
                        bindingSourcePaymentMethods.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void PaymentMethodsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                DataGridViewComboBoxColumn colCboxcrAccount = new DataGridViewComboBoxColumn();
                colCboxcrAccount.HeaderText = "Account";
                colCboxcrAccount.Name = "cbcrAccount";
                colCboxcrAccount.DataSource = _crAccounts;
                // The display member is the name column in the column datasource  
                colCboxcrAccount.DisplayMember = "label";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxcrAccount.DataPropertyName = "account_id";
                // The value member is the primary key of the parent table  
                colCboxcrAccount.ValueMember = "accountid";
                colCboxcrAccount.MaxDropDownItems = 10;
                colCboxcrAccount.Width = 100;
                colCboxcrAccount.DisplayIndex = 3;
                colCboxcrAccount.MinimumWidth = 5;
                colCboxcrAccount.FlatStyle = FlatStyle.Flat;
                colCboxcrAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxcrAccount.ReadOnly = true;
                //colCboxcrAccount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewPaymentMethods.Columns.Contains("cbcrAccount"))
                {
                    dataGridViewPaymentMethods.Columns.Add(colCboxcrAccount);
                }

                bindingSourcePaymentMethods.DataSource = rep.GetNonDeletedPaymentMethods();
                dataGridViewPaymentMethods.AutoGenerateColumns = false;
                dataGridViewPaymentMethods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewPaymentMethods.DataSource = bindingSourcePaymentMethods;
                groupBox4.Text = bindingSourcePaymentMethods.Count.ToString(); 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewPaymentMethods_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        #endregion "Private Methods"

        



    }
}
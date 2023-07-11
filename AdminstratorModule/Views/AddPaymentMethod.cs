using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace AdminstratorModule.Views
{
    public partial class AddPaymentMethod : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        public AddPaymentMethod(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

        }

        public bool IsPaymentMethodValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (cboAccounts.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboAccounts, "Select Account!");
                return false;
            }
            return noerror;
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsPaymentMethodValid())
            {
                try
                {
                    PaymentMethodModel _pay = new PaymentMethodModel();

                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _pay.name = txtName.Text;
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _pay.description = txtDescription.Text.ToString();
                    }
                    if (cboAccounts.SelectedIndex != -1)
                    {
                        _pay.account_id = int.Parse(cboAccounts.SelectedValue.ToString());
                    }
                    _pay.is_active_for_loans = chkActiveLoans.Checked;
                    _pay.is_active_for_savings = chkActiveSavings.Checked;
                    _pay.is_pending_for_loans = chkPendingLoans.Checked;
                    _pay.is_pending_for_savings = chkPendingSavings.Checked;
                    _pay.is_deleted = false;

                    rep.AddNewPaymentMethod(_pay);

                    PaymentMethodsForm ulf = (PaymentMethodsForm)this.Owner;
                    ulf.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void AddPaymentMethod_Load(object sender, EventArgs e)
        {
            try
            {
                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                cboAccounts.DataSource = _crAccounts;
                cboAccounts.ValueMember = "accountid";
                cboAccounts.DisplayMember = "label";
                cboAccounts.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

    }
}

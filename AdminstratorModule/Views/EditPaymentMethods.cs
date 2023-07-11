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
    public partial class EditPaymentMethods : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        DAL.PaymentMethodModel _pay;

        public EditPaymentMethods(DAL.PaymentMethodModel pay, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _pay = pay;

        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsPaymentMethodValid())
            {
                try
                {
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

                    rep.UpdatePaymentMethod(_pay);

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
        private void EditPaymentMethods_Load(object sender, EventArgs e)
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

                InitializeControls();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void InitializeControls()
        {
            try
            {
                if (_pay.name != null)
                {
                    txtName.Text = _pay.name;
                }
                if (_pay.description != null)
                {
                    txtDescription.Text = _pay.description;
                }
                if (_pay.account_id != null)
                {
                    cboAccounts.SelectedValue = _pay.account_id;
                }
                if (_pay.is_active_for_loans != null)
                {
                    chkActiveLoans.Checked = _pay.is_active_for_loans;
                }
                if (_pay.is_active_for_savings != null)
                {
                    chkActiveSavings.Checked = _pay.is_active_for_savings;
                }
                if (_pay.is_pending_for_loans != null)
                {
                    chkPendingLoans.Checked = _pay.is_pending_for_loans;
                }
                if (_pay.is_pending_for_savings != null)
                {
                    chkPendingSavings.Checked = _pay.is_pending_for_savings;
                }
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

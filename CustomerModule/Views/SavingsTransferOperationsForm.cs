using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SearchModule.Views;
using CommonLib;
using DAL;

namespace CustomerModule.Views
{
    public partial class SavingsTransferOperationsForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        ClientSavingContractModel _saving_contract;
        CurrencyModel _currencymodel;
        int _user_id;
        #endregion "Private Fields"

        #region "Constructor"
        public SavingsTransferOperationsForm(ClientSavingContractModel saving_contract, CurrencyModel currencymodel, int userid, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _saving_contract = saving_contract;

            _currencymodel = currencymodel;

            _user_id = userid;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void SavingsTransferOperationsForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblMinDepositAmount.Text = string.Empty;
                lblMaxDepositAmount.Text = string.Empty;
                lblMinDepositFees.Text = string.Empty;
                lblMaxDepositFees.Text = string.Empty;
                lblAccountOwner.Text = string.Empty;
                txtDescription.Text = "Transfer";
                txtTransactionAccount.Enabled = false;
                txtAmountToPay.Enabled = false;

                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {
            try
            { 
                if (_saving_contract.deposit_min != null)
                {
                    lblMinDepositAmount.Text = "Min: " + _saving_contract.deposit_min.ToString() + "  " + _currencymodel.code;
                    txtNetAmount.Minimum = decimal.Parse(_saving_contract.deposit_min.ToString());
                }
                if (_saving_contract.deposit_max != null)
                {
                    lblMaxDepositAmount.Text = "Max: " + _saving_contract.deposit_max.ToString() + "  " + _currencymodel.code;
                    txtNetAmount.Maximum = decimal.Parse(_saving_contract.deposit_max.ToString());
                }
                if (_saving_contract.deposit_fees_min != null)
                {
                    lblMinDepositFees.Text = "Min: " + _saving_contract.deposit_fees_min.ToString() + "  " + _currencymodel.code;
                    txtTransactionFees.Maximum = decimal.Parse(_saving_contract.deposit_fees_min.ToString());
                }
                if (_saving_contract.deposit_fees_max != null)
                {
                    lblMaxDepositFees.Text = "Max: " + _saving_contract.deposit_fees_max.ToString() + "  " + _currencymodel.code;
                    txtTransactionFees.Maximum = decimal.Parse(_saving_contract.deposit_fees_max.ToString());
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnTransfer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsSavingsDepositValid())
            {
                try
                {
                    SavingsEventsModel _savingseventcredit = new SavingsEventsModel();
                    _savingseventcredit.user_id = _user_id;
                    _savingseventcredit.contract_id = _saving_contract.savingcontractid;
                    _savingseventcredit.code = "SCTE";
                    if (!string.IsNullOrEmpty(txtAmountToPay.Value.ToString()))
                    {
                        _savingseventcredit.amount = decimal.Parse(txtAmountToPay.Value.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _savingseventcredit.description = txtDescription.Text.Trim();
                    } 
                    _savingseventcredit.deleted = false;
                    _savingseventcredit.creation_date = DateTime.Now;
                    _savingseventcredit.cancelable = false;
                    _savingseventcredit.is_fired = true;
                    _savingseventcredit.related_contract_code = _saving_contract.code;
                    if (!string.IsNullOrEmpty(txtNetAmount.Value.ToString()))
                    {
                        _savingseventcredit.fees = decimal.Parse(txtNetAmount.Value.ToString());
                    }
                    _savingseventcredit.is_exported = false;
                    _savingseventcredit.savings_method = null;
                    _savingseventcredit.pending = chkSetTransactionasPending.Checked;
                    _savingseventcredit.pending_event_id = null;
                    _savingseventcredit.teller_id = null;
                    _savingseventcredit.loan_event_id = null;
                    _savingseventcredit.cancel_date = null;

                    rep.AddNewSavingsContractEvent(_savingseventcredit);

                    SavingsEventsModel _savingseventdebit = new SavingsEventsModel();
                    _savingseventdebit.user_id = _user_id;
                    _savingseventdebit.contract_id = _saving_contract.savingcontractid;
                    _savingseventdebit.code = "SDTE";
                    if (!string.IsNullOrEmpty(txtAmountToPay.Value.ToString()))
                    {
                        _savingseventdebit.amount = decimal.Parse(txtAmountToPay.Value.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _savingseventdebit.description = txtDescription.Text.Trim();
                    }
                    _savingseventdebit.deleted = false;
                    _savingseventdebit.creation_date = DateTime.Now;
                    _savingseventdebit.cancelable = false;
                    _savingseventdebit.is_fired = true;
                    _savingseventdebit.related_contract_code = _saving_contract.code;
                    if (!string.IsNullOrEmpty(txtNetAmount.Value.ToString()))
                    {
                        _savingseventdebit.fees = decimal.Parse(txtNetAmount.Value.ToString());
                    }
                    _savingseventdebit.is_exported = false;
                    _savingseventdebit.savings_method = null;
                    _savingseventdebit.pending = chkSetTransactionasPending.Checked;
                    _savingseventdebit.pending_event_id = null;
                    _savingseventdebit.teller_id = null;
                    _savingseventdebit.loan_event_id = null;
                    _savingseventdebit.cancel_date = null;

                    rep.AddNewSavingsContractEvent(_savingseventdebit);

                    EditPersonForm cf = (EditPersonForm)this.Owner;
                    cf.RefreshSavingsContractEventsGrid();
                    cf.InitializeSavingsContractBalance();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsSavingsDepositValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtAmountToPay.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmountToPay, "Amount To Pay cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNetAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNetAmount, "Net Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTransactionFees.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTransactionFees, "Transaction Fees cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTransactionAccount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTransactionAccount, "Transaction Account cannot be null!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"
        private void txtNetAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmountToPay.Value = txtNetAmount.Value + txtTransactionFees.Value;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtTransactionFees_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmountToPay.Value = txtNetAmount.Value + txtTransactionFees.Value;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SearchContractsForm sfdf = new SearchContractsForm(_user_id, connection) { Owner = this };
                sfdf.ShowDialog(); 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        #endregion "Private Methods"
 























    }
}
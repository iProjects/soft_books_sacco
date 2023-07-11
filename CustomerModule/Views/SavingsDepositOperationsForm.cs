using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace CustomerModule.Views
{
    public partial class SavingsDepositOperationsForm : Form
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
        public SavingsDepositOperationsForm(ClientSavingContractModel saving_contract, CurrencyModel currencymodel, int userid, string Conn)
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
        private void SavingsFirstDepositForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _paymentmenthodsquery = from pm in rep.GetAllPaymentMethods()
                                            select pm;
                List<PaymentMethodModel> _paymentmethods = _paymentmenthodsquery.ToList();
                cboPaymentMethod.DataSource = _paymentmethods;
                cboPaymentMethod.ValueMember = "paymentmethodid";
                cboPaymentMethod.DisplayMember = "name";
                cboPaymentMethod.SelectedIndex = -1; 

                lblMinDepositAmount.Text = string.Empty;
                lblMaxDepositAmount.Text = string.Empty;
                lblMinDepositFees.Text = string.Empty;
                lblMaxDepositFees.Text = string.Empty;
                txtDescription.Text = "Deposit";
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
        private void btnDeposit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsSavingsDepositValid())
            {
                try
                {
                    SavingsEventsModel _savingsevent = new SavingsEventsModel();
                    _savingsevent.user_id = _user_id;
                    _savingsevent.contract_id = _saving_contract.savingcontractid;
                    _savingsevent.code = "SPDE";
                    if(!string.IsNullOrEmpty(txtAmountToPay.Value.ToString()))
                    {
                    _savingsevent.amount = decimal.Parse(txtAmountToPay.Value.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _savingsevent.description =  txtDescription.Text.Trim();
                    } 
                    _savingsevent.deleted = false;
                    _savingsevent.creation_date =DateTime.Now;
                    _savingsevent.cancelable = false;
                    _savingsevent.is_fired = true;
                    _savingsevent.related_contract_code = null;
                    if (!string.IsNullOrEmpty(txtNetAmount.Value.ToString()))
                    {
                        _savingsevent.fees = decimal.Parse(txtNetAmount.Value.ToString());
                    }
                    _savingsevent.is_exported = false;
                    if (cboPaymentMethod.SelectedIndex != -1)
                    {
                        _savingsevent.savings_method = short.Parse(cboPaymentMethod.SelectedValue.ToString());
                    }
                    _savingsevent.pending = chkSetTransactionasPending.Checked;
                    _savingsevent.pending_event_id = null;
                    _savingsevent.teller_id = null;
                    _savingsevent.loan_event_id = null;
                    _savingsevent.cancel_date = null;

                    rep.AddNewSavingsContractEvent(_savingsevent);

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
            if (cboPaymentMethod.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboPaymentMethod, "Select Payment Method!");
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
        #endregion "Private Methods"





















    }
}
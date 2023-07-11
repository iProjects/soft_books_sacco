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
    public partial class SavingsFirstDepositForm : Form
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
        public SavingsFirstDepositForm(ClientSavingContractModel saving_contract,CurrencyModel currencymodel,int userid, string Conn)
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

                lblEntryFees.Text = string.Empty;
                lblInitialAmount.Text = string.Empty;
                lblTotalAmount.Text = string.Empty;

                lblMinInitialAmount.Text = string.Empty;
                lblMaxInitialAmount.Text = string.Empty;
                lblMinEntryFees.Text = string.Empty;
                lblMaxEntryFees.Text = string.Empty;
                
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
                lblEntryFees.Text = txtEntryFees.Value.ToString() + "  " + _currencymodel.code;
                lblInitialAmount.Text = txtInitialAmount.Value.ToString() + "  " + _currencymodel.code;
                lblTotalAmount.Text = (txtInitialAmount.Value + txtEntryFees.Value).ToString() + "  " + _currencymodel.code;
                if (_saving_contract.initial_amount_min != null)
                {
                    lblMinInitialAmount.Text = "Min: " + _saving_contract.initial_amount_min.ToString() + "  " + _currencymodel.code;
                    txtInitialAmount.Minimum = decimal.Parse(_saving_contract.initial_amount_min.ToString());
                }
                if (_saving_contract.initial_amount_max != null)
                {
                    lblMaxInitialAmount.Text = "Max: " + _saving_contract.initial_amount_max.ToString() + "  " + _currencymodel.code;
                    txtInitialAmount.Maximum = decimal.Parse(_saving_contract.initial_amount_max.ToString());
                }
                if (_saving_contract.entry_fees_min != null)
                {
                    lblMinEntryFees.Text = "Min: " + _saving_contract.entry_fees_min.ToString() + "  " + _currencymodel.code;
                    txtEntryFees.Minimum = decimal.Parse(_saving_contract.entry_fees_min.ToString());
                }
                if (_saving_contract.entry_fees_max != null)
                {
                    lblMaxEntryFees.Text = "Max: " + _saving_contract.entry_fees_max.ToString() + "  " + _currencymodel.code;
                    txtEntryFees.Maximum = decimal.Parse(_saving_contract.entry_fees_max.ToString());
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsSavingsFirstDepositValid())
            {
                try
                {
                    SavingsEventsModel _savingsevent = new SavingsEventsModel();
                    _savingsevent.user_id = _user_id;
                    _savingsevent.contract_id = _saving_contract.savingcontractid;
                    _savingsevent.code = "SVIE";
                    if(!string.IsNullOrEmpty(txtInitialAmount.Value.ToString()))
                    {
                    _savingsevent.amount = decimal.Parse(txtInitialAmount.Value.ToString());
                    }
                    _savingsevent.description = "First Deposit";
                    _savingsevent.deleted = false;
                    _savingsevent.creation_date =DateTime.Now;
                    _savingsevent.cancelable = false;
                    _savingsevent.is_fired = true;
                    _savingsevent.related_contract_code = null;
                    if (!string.IsNullOrEmpty(txtEntryFees.Value.ToString()))
                    {
                        _savingsevent.fees = decimal.Parse(txtEntryFees.Value.ToString());
                    }
                    _savingsevent.is_exported = false;
                    if (cboPaymentMethod.SelectedIndex != -1)
                    {
                        _savingsevent.savings_method = short.Parse(cboPaymentMethod.SelectedValue.ToString());
                    }
                    _savingsevent.pending = false;
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
        private bool IsSavingsFirstDepositValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtInitialAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtInitialAmount, "Initial Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtEntryFees.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEntryFees, "Entry Fees cannot be null!");
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
        private void txtInitialAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblInitialAmount.Text =  txtInitialAmount.Value.ToString() + "  " + _currencymodel.code;
                lblTotalAmount.Text = (txtInitialAmount.Value + txtEntryFees.Value).ToString() + "  " + _currencymodel.code;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtEntryFees_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblEntryFees.Text = txtEntryFees.Value.ToString() + "  " + _currencymodel.code;
                lblTotalAmount.Text =  (txtInitialAmount.Value + txtEntryFees.Value).ToString() + "  " + _currencymodel.code;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"





















    }
}
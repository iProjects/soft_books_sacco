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
    public partial class SavingsSpecialOperationsForm : Form
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
        public SavingsSpecialOperationsForm(ClientSavingContractModel saving_contract, CurrencyModel currencymodel, int userid, string Conn)
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
                var _standardbookingsquery = from br in rep.GetAllStandardBookings()
                                             select br;
                List<StandardBookingsModel> _StandardBookings = _standardbookingsquery.ToList();
                cboTransactionAccount.DataSource = _StandardBookings;
                cboTransactionAccount.ValueMember = "standardbookingid";
                cboTransactionAccount.DisplayMember = "description";
                cboTransactionAccount.SelectedIndex = -1;

                txtDescription.Text = "Special Operation";

                radioButtonDebit.Checked = true;                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnConfirmOperation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsSavingsDepositValid())
            {
                try
                {
                    SavingsEventsModel _savingsevent = new SavingsEventsModel();
                    _savingsevent.user_id = _user_id;
                    _savingsevent.contract_id = _saving_contract.savingcontractid;
                    _savingsevent.code = "SOCE";
                    if (!string.IsNullOrEmpty(txtNetAmount.Value.ToString()))
                    {
                        _savingsevent.amount = decimal.Parse(txtNetAmount.Value.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _savingsevent.description = txtDescription.Text.Trim();
                    } 
                    _savingsevent.deleted = false;
                    _savingsevent.creation_date = DateTime.Now;
                    _savingsevent.cancelable = true;
                    _savingsevent.is_fired = true;
                    _savingsevent.related_contract_code = null;
                    _savingsevent.fees = null; 
                    _savingsevent.is_exported = false;
                    _savingsevent.savings_method = null;
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
        private bool IsSavingsDepositValid()
        {
            bool noerror = true; 
            if (string.IsNullOrEmpty(txtNetAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNetAmount, "Net Amount cannot be null!");
                return false;
            } 
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (cboTransactionAccount.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboTransactionAccount, "Select Payment Method!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation" 
        #endregion "Private Methods"
 





















    }
}
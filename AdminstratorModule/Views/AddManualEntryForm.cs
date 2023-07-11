using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class AddManualEntryForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public AddManualEntryForm(int _user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void AddManualEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                var draccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _drAccounts = draccountsquery.ToList();
                cboDebitAccount.DataSource = _drAccounts;
                cboDebitAccount.ValueMember = "accountid";
                cboDebitAccount.DisplayMember = "label";
                cboDebitAccount.SelectedIndex = -1;

                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                cboCreditAccount.DataSource = _crAccounts;
                cboCreditAccount.ValueMember = "accountid";
                cboCreditAccount.DisplayMember = "label";
                cboCreditAccount.SelectedIndex = -1;

                var _entrybranchesquery = from br in rep.GetNonDeletedBranches()
                                          select br;
                List<BranchModel> _EntryBranches = _entrybranchesquery.ToList();
                cboEntryBranch.DataSource = _EntryBranches;
                cboEntryBranch.ValueMember = "branchid";
                cboEntryBranch.DisplayMember = "name";
                cboEntryBranch.SelectedIndex = -1;

                var _bookingbranchesquery = from br in rep.GetNonDeletedBranches()
                                            select br;
                List<BranchModel> _BookingBranches = _bookingbranchesquery.ToList();
                cboBookingBranch.DataSource = _BookingBranches;
                cboBookingBranch.ValueMember = "branchid";
                cboBookingBranch.DisplayMember = "name";
                cboBookingBranch.SelectedIndex = -1;

                var _currenciesquery = from br in rep.GetCurrenciesList()
                                       select br;
                List<CurrencyModel> _Currencies = _currenciesquery.ToList();
                cboCurrency.DataSource = _Currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;

                var _bookingcurrenciesquery = from br in rep.GetCurrenciesList()
                                              select br;
                List<CurrencyModel> _BookingCurrencies = _bookingcurrenciesquery.ToList();
                cboBookingCurrency.DataSource = _BookingCurrencies;
                cboBookingCurrency.ValueMember = "currencyid";
                cboBookingCurrency.DisplayMember = "name";
                cboBookingCurrency.SelectedIndex = -1;

                var _standardbookingsquery = from br in rep.GetAllStandardBookings()
                                              select br;
                List<StandardBookingsModel> _StandardBookings = _standardbookingsquery.ToList();
                cboBookingType.DataSource = _StandardBookings;
                cboBookingType.ValueMember = "standardbookingid";
                cboBookingType.DisplayMember = "description";
                cboBookingType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsManualAccountingMovementValid())
            {
                try
                {
                    ManualAccountingMovementModel _mam = new ManualAccountingMovementModel();
                    _mam.debit_account_number_id = int.Parse(cboDebitAccount.SelectedValue.ToString());
                    _mam.credit_account_number_id = int.Parse(cboCreditAccount.SelectedValue.ToString());
                    _mam.amount = decimal.Parse(txtAmount.Text);
                    _mam.transaction_date = DateTime.Now;
                    _mam.export_date = null;
                    _mam.is_exported = false;
                    _mam.currency_id = int.Parse(cboCurrency.SelectedValue.ToString());
                    _mam.exchange_rate = 0;
                    _mam.description = txtEntryDescription.Text;
                    _mam.user_id = user;
                    _mam.event_id = 0;
                    _mam.branch_id = int.Parse(cboEntryBranch.SelectedValue.ToString());
                    _mam.closure_id = 0;
                    _mam.fiscal_year_id = 1;

                    rep.AddNewManualEntry(_mam);


                    ManualEntriesForm mef = (ManualEntriesForm)this.Owner;
                    mef.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsManualAccountingMovementValid()
        {
            bool noerror = true;
            if (cboDebitAccount.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboDebitAccount, "Select Debit Account!");
                return false;
            }
            if (cboCreditAccount.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCreditAccount, "Select Credit Account!");
                return false;
            }
            if (cboDebitAccount.SelectedIndex != -1 && cboCreditAccount.SelectedIndex != -1)
            {
                AccountModel drAcc = (AccountModel)cboDebitAccount.SelectedItem;
                AccountModel crAcc = (AccountModel)cboCreditAccount.SelectedItem;
                if (drAcc.accountid == crAcc.accountid)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cboCreditAccount, "Accounts cannot be Equal!");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount cannot be null!");
                return false;
            }
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCurrency, "Select Currency!");
                return false;
            }
            if (cboEntryBranch.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboEntryBranch, "Select Branch!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtBookingAmount_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }

        private void txtBookingAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        #endregion "Private Methods"



    }
}
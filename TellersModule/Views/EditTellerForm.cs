using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using Infrastructure.Models;

namespace TellersModule.Views
{
    public partial class EditTellerForm : Form
    {
        #region "Private Fields"
        SBSaccoDBEntities db;
        Repository rep;
        string connection;
        TellerModel _teller;
        #endregion "Private Fields"

         #region "Constructor"
        public EditTellerForm(TellerModel teller, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (teller == null)
                throw new ArgumentNullException("TellerModel");
            _teller = teller;
        }
        #endregion "Constructor"

        private void EditTellerForm_Load(object sender, EventArgs e)
        {
            try
            {
                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                cboAccount.DataSource = _crAccounts;
                cboAccount.ValueMember = "accountid";
                cboAccount.DisplayMember = "label";
                cboAccount.SelectedIndex = -1;

                var currenciesquery = from cr in rep.GetCurrenciesList()
                                      select cr;
                List<CurrencyModel> currencies = currenciesquery.ToList();
                cboCurrency.DataSource = currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;

                var _usersquery = from br in rep.GetUserList()
                                          select br;
                List<UserModel> _Users = _usersquery.ToList();
                cboUsers.DataSource = _Users;
                cboUsers.ValueMember = "userid";
                cboUsers.DisplayMember = "full_name";
                cboUsers.SelectedIndex = -1;

                var _entrybranchesquery = from br in rep.GetNonDeletedBranches()
                                          select br;
                List<BranchModel> _EntryBranches = _entrybranchesquery.ToList();
                cboBranch.DataSource = _EntryBranches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                cboBranch.SelectedIndex = -1;

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
                if (_teller.name != null)
                {
                    txtName.Text = _teller.name;
                }
                if (_teller.desc != null)
                {
                    txtDescription.Text = _teller.desc;
                }
                if (_teller.account_id != null)
                {
                    cboAccount.SelectedValue = _teller.account_id;
                }
                if (_teller.branch_id != null)
                {
                    cboBranch.SelectedValue = _teller.branch_id;
                }
                if (_teller.currency_id != null)
                {
                    cboCurrency.SelectedValue = _teller.currency_id;
                }
                if (_teller.user_id != null)
                {
                    cboUsers.SelectedValue = _teller.user_id;
                }
                if (_teller.account_id != null)
                {
                    cboAccount.SelectedValue = _teller.account_id;
                }
                if (_teller.amount_min != null)
                {
                    txtMinAmountTeller.Text = _teller.amount_min.ToString();
                }
                if (_teller.amount_max != null)
                {
                    txtMaxAmountTeller.Text = _teller.amount_max.ToString();
                }
                if (_teller.deposit_amount_min != null)
                {
                    txtMinAmountDeposit.Text = _teller.deposit_amount_min.ToString();
                }
                if (_teller.deposit_amount_max != null)
                {
                    txtMaxAmountDeposit.Text = _teller.deposit_amount_max.ToString();
                }
                if (_teller.withdrawal_amount_min != null)
                {
                    txtMinAmountWithdraw.Text = _teller.withdrawal_amount_min.ToString();
                }
                if (_teller.withdrawal_amount_max != null)
                {
                    txtMaxAmountWithdraw.Text = _teller.withdrawal_amount_max.ToString();
                }
                if (_teller.cash_in_min != null)
                {
                    txtMinAmountCashIn.Text = _teller.cash_in_min.ToString();
                }
                if (_teller.cash_in_max != null)
                {
                    txtMaxAmountCashIn.Text = _teller.cash_in_max.ToString();
                }
                if (_teller.cash_out_min != null)
                {
                    txtMinAmountCashOut.Text = _teller.cash_out_min.ToString();
                }
                if (_teller.cash_out_max != null)
                {
                    txtMaxAmountCashOut.Text = _teller.cash_out_max.ToString();
                }
                if (_teller.balance_min != null)
                {
                    txtMinTellerBalance.Text = _teller.balance_min.ToString();
                }
                if (_teller.balance_max != null)
                {
                    txtMaxTellerBalance.Text = _teller.balance_max.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableControls()
        {
            try
            { 
                txtName.Enabled = false; 
                txtDescription.Enabled = false; 
                cboAccount.Enabled = false; 
                cboBranch.Enabled = false;
                cboCurrency.Enabled = false;
                cboUsers.Enabled = false;
                cboAccount.Enabled = false;
                txtMinAmountTeller.Enabled = false;
                txtMaxAmountTeller.Enabled = false;
                txtMinAmountDeposit.Enabled = false;
                txtMaxAmountDeposit.Enabled = false;
                txtMinAmountWithdraw.Enabled = false;
                txtMaxAmountWithdraw.Enabled = false;
                txtMinAmountCashIn.Enabled = false;
                txtMaxAmountCashIn.Enabled = false;
                txtMinAmountCashOut.Enabled = false;
                txtMaxAmountCashOut.Enabled = false;
                txtMinTellerBalance.Enabled = false;
                txtMaxTellerBalance.Enabled = false;
                chkVault.Enabled = false;
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

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsTellerValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _teller.name = Utils.ConvertFirstLetterToUpper(txtName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _teller.desc = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    }
                    if (cboAccount.SelectedIndex != -1)
                    {
                        _teller.account_id = int.Parse(cboAccount.SelectedValue.ToString());
                    }
                    _teller.deleted = false;
                    if (cboBranch.SelectedIndex != -1)
                    {
                        _teller.branch_id = int.Parse(cboBranch.SelectedValue.ToString());
                    }
                    if (cboCurrency.SelectedIndex != -1)
                    {
                        _teller.currency_id = int.Parse(cboCurrency.SelectedValue.ToString());
                    }
                    if (cboUsers.SelectedIndex != -1)
                    {
                        _teller.user_id = int.Parse(cboUsers.SelectedValue.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtMinAmountTeller.Text))
                    {
                        _teller.amount_min = decimal.Parse(txtMinAmountTeller.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMaxAmountTeller.Text))
                    {
                        _teller.amount_max = decimal.Parse(txtMaxAmountTeller.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMinAmountDeposit.Text))
                    {
                        _teller.deposit_amount_min = decimal.Parse(txtMinAmountDeposit.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMaxAmountDeposit.Text))
                    {
                        _teller.deposit_amount_max = decimal.Parse(txtMaxAmountDeposit.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMinAmountWithdraw.Text))
                    {
                        _teller.withdrawal_amount_min = decimal.Parse(txtMinAmountWithdraw.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMaxAmountWithdraw.Text))
                    {
                        _teller.withdrawal_amount_max = decimal.Parse(txtMaxAmountWithdraw.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMinAmountCashIn.Text))
                    {
                        _teller.cash_in_min = decimal.Parse(txtMinAmountCashIn.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMaxAmountCashIn.Text))
                    {
                        _teller.cash_in_max = decimal.Parse(txtMaxAmountCashIn.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMinAmountCashOut.Text))
                    {
                        _teller.cash_out_min = decimal.Parse(txtMinAmountCashOut.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMaxAmountCashOut.Text))
                    {
                        _teller.cash_out_max = decimal.Parse(txtMaxAmountCashOut.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMinTellerBalance.Text))
                    {
                        _teller.balance_min = decimal.Parse(txtMinTellerBalance.Text);
                    }
                    if (!string.IsNullOrEmpty(txtMaxTellerBalance.Text))
                    {
                        _teller.balance_max = decimal.Parse(txtMaxTellerBalance.Text);
                    }

                    rep.UpdateTeller(_teller);

                    TellerListForm br = (TellerListForm)this.Owner;
                    br.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsTellerValid()
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
            if (cboAccount.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboAccount, "Select Account!");
                return false;
            }  
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCurrency, "Select Currency!");
                return false;
            }
            if (cboUsers.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboUsers, "Select User!");
                return false;
            }
            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboBranch, "Select Branch!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"

        private void chkVault_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }





    }
}

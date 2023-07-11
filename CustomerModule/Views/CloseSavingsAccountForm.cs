using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using SearchModule.Views;
using DAL;

namespace CustomerModule.Views
{
    public partial class CloseSavingsAccountForm : Form
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
        public CloseSavingsAccountForm(ClientSavingContractModel saving_contract, CurrencyModel currencymodel, int userid, string Conn)
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
        private void CloseSavingsAccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtonWithdraw.Checked = true;
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
                lblAmount.Text = string.Empty;
                lblCloseFees.Text = string.Empty;
                lblAccountOwner.Text = string.Empty;

                groupBox5.Visible = false;

                string _stringfees = String.Format("{0:0.00}", txtFees.Value);
                string _stringbalance = String.Format("{0:0.00}", _saving_contract.Available_Balance);
                lblCloseFees.Text = _stringfees;
                lblAmount.Text = _stringbalance;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCloseAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsCloseSavingsValid())
            {
                try
                {
                    SavingsEventsModel _savingsevent = new SavingsEventsModel();
                    _savingsevent.user_id = _user_id;
                    _savingsevent.contract_id = _saving_contract.savingcontractid;
                    _savingsevent.code = "SVCE";
                    if (!string.IsNullOrEmpty(lblAmount.Text.ToString()))
                    {
                        _savingsevent.amount = decimal.Parse(lblAmount.Text.ToString());
                    }
                    _savingsevent.description = "Close savings contract";
                    _savingsevent.deleted = false;
                    _savingsevent.creation_date = DateTime.Now;
                    _savingsevent.cancelable = false;
                    _savingsevent.is_fired = true;
                    _savingsevent.related_contract_code = null;
                    if (!string.IsNullOrEmpty(txtFees.Value.ToString()))
                    {
                        _savingsevent.fees = decimal.Parse(txtFees.Value.ToString());
                    }
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
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsCloseSavingsValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtFees, "Fees cannot be null!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"
        private void txtFees_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblAmount.Text = lblAmount.Text + lblCloseFees.Text;
                lblCloseFees.Text = txtFees.Value.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkDisableFees_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDisableFees.Checked)
                {
                    txtFees.Enabled = false;
                    lblCloseFees.Text = "0";
                }
                if (chkDisableFees.Checked == false)
                {
                    txtFees.Enabled = true;
                    lblCloseFees.Text = txtFees.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonTransfer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonTransfer.Checked)
                {
                    groupBox5.Visible = true;
                }
                if (radioButtonTransfer.Checked == false)
                {
                    groupBox5.Visible = false;
                }
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
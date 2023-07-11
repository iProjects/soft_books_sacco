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
    public partial class EditStandardBookingsForm : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        DAL.StandardBookingsModel _standardbooking;

        public EditStandardBookingsForm(DAL.StandardBookingsModel stanbook, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _standardbooking = stanbook;
        }

        private void EditStandardBooikngsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var draccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _drAccounts = draccountsquery.ToList();
                cboDebitAccount.DataSource = _drAccounts;
                cboDebitAccount.ValueMember = "accountid";
                cboDebitAccount.DisplayMember = "type_code";
                cboDebitAccount.SelectedIndex = -1;

                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                cboCreditAccount.DataSource = _crAccounts;
                cboCreditAccount.ValueMember = "accountid";
                cboCreditAccount.DisplayMember = "type_code";
                cboCreditAccount.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        public bool IsStandardBookingValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
            } 
            if ( cboDebitAccount.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboDebitAccount, "Select Debit Account!");
            }
            if (cboCreditAccount.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCreditAccount, "Select Credit Account!");
            } 
            return noerror;
        } 
        public void InitializeControls()
        {
            try
            {
                if (_standardbooking.Name != null)
                {
                    txtName.Text = _standardbooking.Name; 
                }
                if (_standardbooking.debit_account_id != null)
                {
                    cboDebitAccount.SelectedValue = _standardbooking.debit_account_id;
                }
                if (_standardbooking.credit_account_id != null)
                {
                    cboCreditAccount.SelectedValue = _standardbooking.credit_account_id;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();

            try
            {
                if (IsStandardBookingValid())
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _standardbooking.Name = txtName.Text.ToString();
                    }
                    if (cboDebitAccount.SelectedIndex != -1)
                    {
                        _standardbooking.debit_account_id = int.Parse(cboDebitAccount.SelectedValue.ToString());
                    }
                    if (cboCreditAccount.SelectedIndex != -1)
                    {
                        _standardbooking.credit_account_id = int.Parse(cboCreditAccount.SelectedValue.ToString());
                    }

                    rep.UpdateStandardBooking(_standardbooking);

                    StandardBookingsForm ulf = (StandardBookingsForm)this.Owner;
                    ulf.RefreshGrid();
                    this.Close();
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

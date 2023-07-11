using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AdminstratorModule.Views
{
    public partial class GeneralLedgerForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        private decimal _BalanceAmount;
        CurrencyModel _currency;
        #endregion "Private Fields"

        #region "Constructor"
        public GeneralLedgerForm(int _user, string Conn)
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
        private void btnRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

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
        private void GeneralLedgerForm_Load(object sender, EventArgs e)
        {
            try
            {

                // Set the column header names.
                dataGridViewGeneralLedger.Columns[0].Name = "date";
                dataGridViewGeneralLedger.Columns[1].Name = "amount";
                dataGridViewGeneralLedger.Columns[2].Name = "is_exported";
                dataGridViewGeneralLedger.Columns[3].Name = "event_code";
                dataGridViewGeneralLedger.Columns[4].Name = "contract_code";
                dataGridViewGeneralLedger.Columns[5].Name = "debit_local_account_number";
                dataGridViewGeneralLedger.Columns[6].Name = "credit_local_account_number";
                dataGridViewGeneralLedger.Columns[7].Name = "exchange_rate";



                //Display Combox
                var DisplayType = new BindingList<KeyValuePair<string, string>>();
                DisplayType.Add(new KeyValuePair<string, string>("ALL", "All"));
                DisplayType.Add(new KeyValuePair<string, string>("NYE", "Not Yet Exported"));
                DisplayType.Add(new KeyValuePair<string, string>("OXP", "Only Exported"));
                cboDisplay.DataSource = DisplayType;
                cboDisplay.ValueMember = "Key";
                cboDisplay.DisplayMember = "Value";

                var draccountsquery = from et in rep.GetGeneralLedgerAccountsList()
                                      select et;
                List<AccountModel> _drAccounts = draccountsquery.ToList();
                cboAccount.DataSource = _drAccounts;
                cboAccount.ValueMember = "accountid";
                cboAccount.DisplayMember = "label";
                //cboAccount.SelectedIndex = -1;

                var _branchesquery = from br in rep.GetNonDeletedBranches()
                                         select br;
                List<BranchModel> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                //cboBranch.SelectedIndex = -1;

                var _curenciesquery = from br in rep.GetCurrenciesList()
                                     select br;
                List<CurrencyModel> _curencies = _curenciesquery.ToList();
                cboCurrency.DataSource = _curencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                //cboBranch.SelectedIndex = -1;

                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = dtpStartDate.Value.AddMonths(1);
                 

                dataGridViewGeneralLedger.AutoGenerateColumns = false;
                this.dataGridViewGeneralLedger.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
                dataGridViewGeneralLedger.DataSource = bindingSourceGeneralLedger;
                groupBox3.Text = bindingSourceGeneralLedger.Count.ToString(); 

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindingSourceGeneralLedger.DataSource = null;
            if (cboAccount.SelectedIndex != -1 && cboBranch.SelectedIndex != -1 && cboDisplay.SelectedIndex != -1)
            {
                try
                {
                    AccountModel _account = (AccountModel)cboAccount.SelectedItem;
                    BranchModel _branch = (BranchModel)cboBranch.SelectedItem;
                     _currency = (CurrencyModel)cboCurrency.SelectedItem;
                    DateTime _startdate = dtpStartDate.Value;
                    DateTime _enddate = dtpEndDate.Value; 
                    var _display = (KeyValuePair<string, string>)cboDisplay.SelectedItem;
                    bool isexported=true;

                    switch (_display.Key)
                        {
                            case "ALL":
                                isexported=true;
                                break;
                            case "NYE":
                                isexported=false;
                                break;
                            case "OXP":
                                isexported=true;
                                break;
                        }                    
                    var _generalParameteresquery = from gp in rep.GetAccountBookings(_startdate, _enddate, _account.accountid, _currency.currencyid, isexported, _branch.branchid)
                                                   select gp;                     
                        bindingSourceGeneralLedger.DataSource = _generalParameteresquery;
                        groupBox3.Text = bindingSourceGeneralLedger.Count.ToString();
                        ComputeTotal();                     
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ComputeTotal()
        {
            try
            {
                _BalanceAmount = 0;
                decimal rowAmount = 0;
                foreach (DataGridViewRow row in dataGridViewGeneralLedger.Rows)
                {
                    decimal _amount = 0; 
                    if (row.Cells["amount"].Value != null)
                    {
                        _amount = (decimal)row.Cells["amount"].Value;
                    }
                    rowAmount = _amount;
                    _BalanceAmount += rowAmount;
                }

                groupBox3.Text += "  Balance " + _BalanceAmount.ToString() + "  " + _currency.name;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"



    }
}

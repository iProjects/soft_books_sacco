using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class ManualEntriesForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user; 
        #endregion "Private Fields"

        #region "Constructor"
        public ManualEntriesForm(int _user, string Conn)
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddManualEntryForm amef = new AddManualEntryForm(user, connection) { Owner = this };
                amef.ShowDialog();
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
        public void RefreshGrid()
        {
            try
            {
                bindingSourceManualEntries.DataSource = null;
                var rightsquery = from rts in rep.GetAllManualEntries()
                                  select rts;
                bindingSourceManualEntries.DataSource = rightsquery.ToList();
                dataGridViewManualEntries.AutoGenerateColumns = false;
                dataGridViewManualEntries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewManualEntries.DataSource = bindingSourceManualEntries;
                groupBox1.Text = bindingSourceManualEntries.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewManualEntries.Rows)
                {
                    dataGridViewManualEntries.Rows[dataGridViewManualEntries.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewManualEntries.Rows.Count - 1;
                    bindingSourceManualEntries.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void ManualEntriesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var draccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _drAccounts = draccountsquery.ToList();
                DataGridViewComboBoxColumn colCboxdrAccount = new DataGridViewComboBoxColumn();
                colCboxdrAccount.HeaderText = "Debit Account";
                colCboxdrAccount.Name = "cbdrAccount";
                colCboxdrAccount.DataSource = _drAccounts;
                // The display member is the name column in the column datasource  
                colCboxdrAccount.DisplayMember = "label";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxdrAccount.DataPropertyName = "debit_account_number_id";
                // The value member is the primary key of the parent table  
                colCboxdrAccount.ValueMember = "accountid";
                colCboxdrAccount.MaxDropDownItems = 10;
                colCboxdrAccount.Width = 150;
                colCboxdrAccount.DisplayIndex = 1;
                colCboxdrAccount.MinimumWidth = 5;
                colCboxdrAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxdrAccount.FlatStyle = FlatStyle.Flat;
                colCboxdrAccount.ReadOnly = true;
                //colCboxRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewManualEntries.Columns.Contains("cbdrAccount"))
                {
                    dataGridViewManualEntries.Columns.Add(colCboxdrAccount);
                }

                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                DataGridViewComboBoxColumn colCboxcrAccount = new DataGridViewComboBoxColumn();
                colCboxcrAccount.HeaderText = "Credit Account";
                colCboxcrAccount.Name = "cbcrAccount";
                colCboxcrAccount.DataSource = _crAccounts;
                // The display member is the name column in the column datasource  
                colCboxcrAccount.DisplayMember = "label";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxcrAccount.DataPropertyName = "credit_account_number_id";
                // The value member is the primary key of the parent table  
                colCboxcrAccount.ValueMember = "accountid";
                colCboxcrAccount.MaxDropDownItems = 10;
                colCboxcrAccount.Width = 150;
                colCboxcrAccount.DisplayIndex = 2;
                colCboxcrAccount.MinimumWidth = 5;
                colCboxcrAccount.FlatStyle = FlatStyle.Flat;
                colCboxcrAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxcrAccount.ReadOnly = true;
                //colCboxcrAccount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewManualEntries.Columns.Contains("cbcrAccount"))
                {
                    dataGridViewManualEntries.Columns.Add(colCboxcrAccount);
                }

                var _currenciesquery = from br in rep.GetCurrenciesList()
                                       select br;
                List<CurrencyModel> _Currencies = _currenciesquery.ToList();
                DataGridViewComboBoxColumn colCboxCurrency = new DataGridViewComboBoxColumn();
                colCboxCurrency.HeaderText = "Currency";
                colCboxCurrency.Name = "cbCurrency";
                colCboxCurrency.DataSource = _Currencies;
                // The display member is the name column in the column datasource  
                colCboxCurrency.DisplayMember = "name";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxCurrency.DataPropertyName = "currency_id";
                // The value member is the primary key of the parent table  
                colCboxCurrency.ValueMember = "currencyid";
                colCboxCurrency.MaxDropDownItems = 10;
                colCboxCurrency.Width = 80;
                colCboxCurrency.DisplayIndex = 5;
                colCboxCurrency.MinimumWidth = 5;
                colCboxCurrency.FlatStyle = FlatStyle.Flat;
                colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxCurrency.ReadOnly = true;
                //colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewManualEntries.Columns.Contains("cbCurrency"))
                {
                    dataGridViewManualEntries.Columns.Add(colCboxCurrency);
                }

                var _usersquery = from br in rep.GetUserList()
                                       select br;
                List<UserModel> _Users = _usersquery.ToList();
                DataGridViewComboBoxColumn colCboxUser = new DataGridViewComboBoxColumn();
                colCboxUser.HeaderText = "User";
                colCboxUser.Name = "cbUser";
                colCboxUser.DataSource = _Users;
                // The display member is the name column in the column datasource  
                colCboxUser.DisplayMember = "full_name";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxUser.DataPropertyName = "user_id";
                // The value member is the primary key of the parent table  
                colCboxUser.ValueMember = "userid";
                colCboxUser.MaxDropDownItems = 10;
                colCboxUser.Width = 80;
                colCboxUser.DisplayIndex = 6;
                colCboxUser.MinimumWidth = 5;
                colCboxUser.FlatStyle = FlatStyle.Flat;
                colCboxUser.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxUser.ReadOnly = true;
                //colCboxUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewManualEntries.Columns.Contains("cbUser"))
                {
                    dataGridViewManualEntries.Columns.Add(colCboxUser);
                } 

                var _branchesquery = from br in rep.GetNonDeletedBranches()
                                     select br;
                List<BranchModel> _Branches = _branchesquery.ToList();
                DataGridViewComboBoxColumn colCboxBranch = new DataGridViewComboBoxColumn();
                colCboxBranch.HeaderText = "Branch";
                colCboxBranch.Name = "cbBranch";
                colCboxBranch.DataSource = _Branches;
                // The display member is the name column in the column datasource  
                colCboxBranch.DisplayMember = "name";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxBranch.DataPropertyName = "branch_id";
                // The value member is the primary key of the parent table  
                colCboxBranch.ValueMember = "branchid";
                colCboxBranch.MaxDropDownItems = 10;
                colCboxBranch.Width = 80;
                colCboxBranch.DisplayIndex = 7;
                colCboxBranch.MinimumWidth = 5;
                colCboxBranch.FlatStyle = FlatStyle.Flat;
                colCboxBranch.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxBranch.ReadOnly = true;
                colCboxBranch.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewManualEntries.Columns.Contains("cbBranch"))
                {
                    dataGridViewManualEntries.Columns.Add(colCboxBranch);
                } 


                var rightsquery = from rts in rep.GetAllManualEntries()
                                  select rts;
                bindingSourceManualEntries.DataSource = rightsquery.ToList();
                dataGridViewManualEntries.AutoGenerateColumns = false;
                dataGridViewManualEntries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewManualEntries.DataSource = bindingSourceManualEntries;
                groupBox1.Text = bindingSourceManualEntries.Count.ToString();
                 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"

        
        
    }
}
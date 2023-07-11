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
    public partial class TellerListForm : Form
    {
        #region "Private Fields"
        SBSaccoDBEntities db;
        Repository rep;
        string connection;
        int _userid;
        #endregion "Private Fields"

        #region "Constructor"
        public TellerListForm(int userid,string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _userid = userid;
        }
        #endregion "Constructor"


        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void TellerListForm_Load(object sender, EventArgs e)
        {
            try
            {

                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                DataGridViewComboBoxColumn colCboxcrAccount = new DataGridViewComboBoxColumn();
                colCboxcrAccount.HeaderText = "Account";
                colCboxcrAccount.Name = "cbcrAccount";
                colCboxcrAccount.DataSource = _crAccounts;
                // The display member is the name column in the column datasource  
                colCboxcrAccount.DisplayMember = "label";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxcrAccount.DataPropertyName = "account_id";
                // The value member is the primary key of the parent table  
                colCboxcrAccount.ValueMember = "accountid";
                colCboxcrAccount.MaxDropDownItems = 10;
                colCboxcrAccount.Width = 100;
                colCboxcrAccount.DisplayIndex = 3;
                colCboxcrAccount.MinimumWidth = 5;
                colCboxcrAccount.FlatStyle = FlatStyle.Flat;
                colCboxcrAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxcrAccount.ReadOnly = true;
                //colCboxcrAccount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTellers.Columns.Contains("cbcrAccount"))
                {
                    dataGridViewTellers.Columns.Add(colCboxcrAccount);
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
                colCboxCurrency.DisplayIndex = 4;
                colCboxCurrency.MinimumWidth = 5;
                colCboxCurrency.FlatStyle = FlatStyle.Flat;
                colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxCurrency.ReadOnly = true;
                //colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTellers.Columns.Contains("cbCurrency"))
                {
                    dataGridViewTellers.Columns.Add(colCboxCurrency);
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
                colCboxUser.DisplayIndex = 5;
                colCboxUser.MinimumWidth = 5;
                colCboxUser.FlatStyle = FlatStyle.Flat;
                colCboxUser.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxUser.ReadOnly = true;
                //colCboxUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTellers.Columns.Contains("cbUser"))
                {
                    dataGridViewTellers.Columns.Add(colCboxUser);
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
                colCboxBranch.DisplayIndex = 6;
                colCboxBranch.MinimumWidth = 5;
                colCboxBranch.FlatStyle = FlatStyle.Flat;
                colCboxBranch.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxBranch.ReadOnly = true;
                colCboxBranch.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTellers.Columns.Contains("cbBranch"))
                {
                    dataGridViewTellers.Columns.Add(colCboxBranch);
                } 

                var _Tellersquery = from br in rep.GetAllTellers()
                                     where br.deleted == false
                                     select br;
                bindingSourceTellers.DataSource = _Tellersquery.ToList();
                groupBox2.Text = bindingSourceTellers.Count.ToString();
                dataGridViewTellers.AutoGenerateColumns = false;
                this.dataGridViewTellers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTellers.DataSource = bindingSourceTellers;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            try
            {
                if (chkIsDeleted.Checked)
                {
                    bindingSourceTellers.DataSource = null;
                    var _Tellersquery = from br in rep.GetAllTellers()
                                         select br;
                    bindingSourceTellers.DataSource = _Tellersquery.ToList();
                    groupBox2.Text = bindingSourceTellers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewTellers.Rows)
                    {
                        dataGridViewTellers.Rows[dataGridViewTellers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewTellers.Rows.Count - 1;
                        bindingSourceTellers.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceTellers.DataSource = null;
                    var _Tellersquery = from br in rep.GetAllTellers()
                                         where br.deleted == false
                                         select br;
                    bindingSourceTellers.DataSource = _Tellersquery.ToList();
                    groupBox2.Text = bindingSourceTellers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewTellers.Rows)
                    {
                        dataGridViewTellers.Rows[dataGridViewTellers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewTellers.Rows.Count - 1;
                        bindingSourceTellers.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTellers.SelectedRows.Count != 0)
            {
                try
                {
                    TellerModel teller = (TellerModel)bindingSourceTellers.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Branch\n" + teller.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteTeller(teller); 
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTellers.SelectedRows.Count != 0)
            {
                try
                {
                    TellerModel branch = (TellerModel)bindingSourceTellers.Current;
                    EditTellerForm ebf = new EditTellerForm(branch, connection) { Owner = this };
                    ebf.Text = branch.name.ToString().ToUpper();
                    ebf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddTellerForm abf = new AddTellerForm(connection) { Owner = this };
                abf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void chkIsDeleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsDeleted.Checked)
                {
                    bindingSourceTellers.DataSource = null;
                    var _Tellersquery = from br in rep.GetAllTellers()
                                         select br;
                    bindingSourceTellers.DataSource = _Tellersquery.ToList();
                    groupBox2.Text = bindingSourceTellers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewTellers.Rows)
                    {
                        dataGridViewTellers.Rows[dataGridViewTellers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewTellers.Rows.Count - 1;
                        bindingSourceTellers.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceTellers.DataSource = null;
                    var _Tellersquery = from br in rep.GetNonDeletedTellers()
                                         where br.deleted == false
                                         select br;
                    bindingSourceTellers.DataSource = _Tellersquery.ToList();
                    groupBox2.Text = bindingSourceTellers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewTellers.Rows)
                    {
                        dataGridViewTellers.Rows[dataGridViewTellers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewTellers.Rows.Count - 1;
                        bindingSourceTellers.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewTellers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTellers.SelectedRows.Count != 0)
            {
                try
                {
                    TellerModel branch = (TellerModel)bindingSourceTellers.Current;
                    EditTellerForm ebf = new EditTellerForm(branch, connection) { Owner = this };
                    ebf.Text = branch.name.ToString().ToUpper();
                    ebf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTellers.SelectedRows.Count != 0)
            {
                try
                {
                    TellerModel branch = (TellerModel)bindingSourceTellers.Current;
                    EditTellerForm ebf = new EditTellerForm(branch, connection) { Owner = this };
                    ebf.Text = branch.name.ToString().ToUpper();
                    ebf.DisableControls();
                    ebf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }






    }
}

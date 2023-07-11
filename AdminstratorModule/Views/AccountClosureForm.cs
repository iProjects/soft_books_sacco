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
    public partial class AccountClosureForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AccountClosureForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnGenerateEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AccountingJournalsForm ajf = new AccountingJournalsForm(connection) { Owner = this };
                ajf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnPostBookings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AccountingJournalsForm ajf = new AccountingJournalsForm(connection) { Owner = this };
                ajf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewAccountClosure.SelectedRows.Count != 0)
            {
                try
                {
                    AccountingClosureModel _accountingclosure = (AccountingClosureModel)bindingSourceAccountClosure.Current;
                    BookingsForm bf = new BookingsForm(connection) { Owner = this };
                    bf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewAccountClosure.SelectedRows.Count != 0)
            {
                try
                {
                    AccountingClosureModel _accountingclosure = (AccountingClosureModel)bindingSourceAccountClosure.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Accounting Closure", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteAccountingClosure(_accountingclosure); 
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AccountClosureForm_Load(object sender, EventArgs e)
        {
            try
            {

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
                colCboxUser.Width = 100;
                colCboxUser.DisplayIndex = 6;
                colCboxUser.MinimumWidth = 5;
                colCboxUser.FlatStyle = FlatStyle.Flat;
                colCboxUser.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxUser.ReadOnly = true;
                colCboxUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewAccountClosure.Columns.Contains("cbUser"))
                {
                    dataGridViewAccountClosure.Columns.Add(colCboxUser);
                }

                var _accountingclosurequery = from rts in rep.GetNonDeletedAccountingClosures()
                                  select rts;
                bindingSourceAccountClosure.DataSource = _accountingclosurequery.ToList();
                dataGridViewAccountClosure.AutoGenerateColumns = false;
                this.dataGridViewAccountClosure.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewAccountClosure.DataSource = bindingSourceAccountClosure;
                groupBox1.Text = bindingSourceAccountClosure.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshGrid()
        {
            try
            {
                bindingSourceAccountClosure.DataSource = null;
                var _accountingclosurequery = from rts in rep.GetNonDeletedAccountingClosures()
                                              select rts;
                bindingSourceAccountClosure.DataSource = _accountingclosurequery.ToList();
                groupBox1.Text = bindingSourceAccountClosure.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"


    }
}

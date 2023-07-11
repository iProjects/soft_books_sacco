using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class AccountingRulesForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user; 
        #endregion "Private Fields"

        #region "Constructor"
        public AccountingRulesForm(int _user, string Conn)
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
                AddAccountingRulesForm aaf = new AddAccountingRulesForm(connection);
                aaf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        private void AccountingRulesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _accountingrulesquery = rep.GetAccountingRulesList();
                dataGridViewAccountingRules.AutoGenerateColumns = false;
                this.dataGridViewAccountingRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceAccountingRules.DataSource = _accountingrulesquery;
                dataGridViewAccountingRules.DataSource = bindingSourceAccountingRules;
                groupBox2.Text = bindingSourceAccountingRules.Count.ToString();
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
                bindingSourceAccountingRules.DataSource = null;
                var _accountingrulesquery = rep.GetAccountingRulesList();
                bindingSourceAccountingRules.DataSource = _accountingrulesquery; 
                groupBox2.Text = bindingSourceAccountingRules.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"
    }
}

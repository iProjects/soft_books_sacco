using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class ChartofAccountsForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        List<AccountCategoryModel> _accountCategories;
        #endregion "Private Fields"

        #region "Constructor"
        public ChartofAccountsForm(int _user, string Conn)
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

        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void btnImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void btnExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void ChartofAccountsForm_Load(object sender, EventArgs e)
        {
            try
            {
                BuildTree();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void BuildTree()
        {
            try
            {
                treeViewChartofAccounts.Nodes.Clear(); // Clear any existing items
                treeViewChartofAccounts.BeginUpdate(); // prevent overhead and flicker 

                 var _accountmodelsquery = from ea in rep.GetAllAccountCategoriesList()
                                          select ea;
                List<AccountCategoryModel> _accountmodels = _accountmodelsquery.ToList(); 
                TreeNode root = new TreeNode();
                foreach (var ac in _accountmodels)
                {
                    if (ac != null)
                    {
                        AccountsDTO i = new AccountsDTO
                        {
                            Key = ac.accountcategoryid.ToString() ,
                            Table = "AccountCategoryModel",
                            Item = ac.name
                        };
                        root.Text = ac.name;
                        root.Tag = i;
                        PopulateTreeViewChartofAccounts(root,ac);
                    }
                } 

                treeViewChartofAccounts.Nodes.Add(root);
                treeViewChartofAccounts.EndUpdate(); // re-enable the tree
                treeViewChartofAccounts.Refresh(); // refresh the treeview display
                treeViewChartofAccounts.ExpandAll(); // expand all nodes
                if (treeViewChartofAccounts.Nodes.Count > 0)
                {
                    // Select the root node
                    treeViewChartofAccounts.SelectedNode = treeViewChartofAccounts.Nodes[0];
                }
                int count = treeViewChartofAccounts.GetNodeCount(true);
                groupBox2.Text = "Chart of Accounts  " + count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeViewChartofAccounts(TreeNode node,AccountCategoryModel accountcategory)
        {
            try
            {
                var _accountsquery = from pr in rep.GetAccountCategoryAccountsList(accountcategory.accountcategoryid) 
                                               select pr;
                List<AccountModel> _Accounts = _accountsquery.ToList();
                foreach (var _account in _Accounts)
                {
                    AccountsDTO i = new AccountsDTO(_account.accountid.ToString(),
                                              "AccountModel",
                                              _account);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _account.account_number + "-" + _account.label;
                    node.Nodes.Add(clnode);

                    PopulateTreeViewChartofAccountsChildren(clnode, _account);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeViewChartofAccountsChildren(TreeNode node, AccountModel account)
        {
            try
            {
                var _accountsquery = from pr in rep.GetAccountCategoryAccountsList(account.accountid)
                                     select pr;
                List<AccountModel> _Accounts = _accountsquery.ToList();
                foreach (var _account in _Accounts)
                {
                    AccountsDTO i = new AccountsDTO(_account.accountid.ToString(),
                                              "AccountModel",
                                              _account);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _account.account_number + "-" + _account.label;
                    node.Nodes.Add(clnode);

                    PopulateTreeViewChartofAccountsChildren(clnode, _account);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void treeViewChartofAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        #endregion "Private Methods"















    }








    public class AccountsDTO
    {
        public string Key { get; set; }
        public string Table { get; set; }
        public object Item { get; set; }

        public AccountsDTO()
        {

        }
        public AccountsDTO(string key, string table, object payload)
        {
            this.Key = key;
            this.Table = table;
            this.Item = payload;
        }
    }

}

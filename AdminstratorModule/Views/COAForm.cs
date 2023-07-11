using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class COAForm : Form
    {
        string connection;
        SBSaccoDBEntities db;
        Repository rep; 
        List<int> ids = new List<int>(); 

        public COAForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSaccoDBEntities(connection);
            rep = new Repository(connection);
        }

        public void BuildTree()
        {
            try
            {
                treeViewChartofAccounts.Nodes.Clear(); // Clear any existing items
                treeViewChartofAccounts.BeginUpdate(); // prevent overhead and flicker
                // load all the lowest tree nodes
                TreeBuilder tb = new TreeBuilder();
                //        List<Item> coa = (from s in db.gl_COA
                //                          select new Item
                //                          {
                //                              ItemID = s.Id,
                //                              ParentID = s.Parent,
                //                              Text = s.Description,
                //                              //Payload = null
                //                          }).ToList();

                //        tb.PopulateTreeViewEnumerable(treeViewChartofAccounts, coa);
                treeViewChartofAccounts.EndUpdate(); // re-enable the tree
                treeViewChartofAccounts.Refresh(); // refresh the treeview display
                //        groupBox9.Text = coa.Count.ToString();
                if (treeViewChartofAccounts.Nodes.Count > 0)
                {
                    // Select the root node
                    treeViewChartofAccounts.SelectedNode = treeViewChartofAccounts.Nodes[0];
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ComputeBookBalanceTotal(List<AccountModel> _Accounts)
        {
            try
            {

                if (_Accounts != null)
                {
                    //            decimal _totalCredits = _Accounts
                    //               .Where(t => t.BookBalance > 0)
                    //               .Select(t => t.BookBalance).Sum();
                    //            txtTotalCredits.Text = _totalCredits.ToString("C2");

                    //            decimal _totalDebits = _Accounts
                    //              .Where(t => t.BookBalance < 0)
                    //              .Select(t => t.BookBalance).Sum();
                    //            txtTotalDebits.Text = _totalDebits.ToString("C2");

                    //            decimal _totalBalance = _totalCredits + _totalDebits;
                    //            txtBalance.Text = _totalBalance.ToString("C2");
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void COAForm_Load(object sender, EventArgs e)
        {
            try
            {
                BuildTree();

                //var coasQuery = db.ChartOfAccounts.Include("gl_Accounts");
                //coas = coasQuery.ToList();
                //bindingSourceAccounts.DataSource = db.;
                var _accountsquery = from ac in rep.GetAccountsList()
                                     select ac;
                List<AccountModel> _Accounts = _accountsquery.ToList();
                dataGridViewAccounts.AutoGenerateColumns = false;
                this.dataGridViewAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewAccounts.DataSource = bindingSourceAccounts;

            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void CreateIdList(int ParentId, List<int> Ids)
        {
            try
            {
                List<int> ChildIds = (from i in rep.GetAccountsList()
                                      where i.parent_account_id == ParentId
                                      select i.accountid).ToList();
                Ids.Add(ParentId);
                foreach (int child in ChildIds)
                {
                    CreateIdList(child, Ids);
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void CreateIdList(TreeNode node)
        {
            try
            {
                int itemId = int.Parse(node.Name);
                ids.Add(itemId);
                foreach (TreeNode child in node.Nodes)
                {
                    CreateIdList(child);
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
                // Get the node that was Selected
                TreeNode selectedNode = e.Node;
                if (selectedNode != null)
                {
                    ids.Clear();
                    int itemId = int.Parse(selectedNode.Name);
                    CreateIdList(itemId, ids);
                    var accQuery = rep.GetAccountsList().Where(crtu => ids.Contains(crtu.account_category_id));
                    bindingSourceAccounts.DataSource = accQuery;
                    groupBox8.Text = bindingSourceAccounts.Count.ToString();
                    List<AccountModel> _Accounts = accQuery.ToList();
                    ComputeBookBalanceTotal(_Accounts);
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void addChartOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewChartofAccounts.SelectedNode;
                //int itemId = int.Parse(selectedNode.Name);
                //var _coaquery = (from coa in db.gl_COA
                //                where coa.Id == itemId
                //                select coa).FirstOrDefault();
                //gl_COA _Coa = _coaquery;
                //AddCOAForm f = new AddCOAForm(_Coa, connection) { Owner = this };
                //f.ShowDialog();
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
                //bindingSourceCOA.DataSource = null;
                //var coasQuery = db.gl_COA.Include("gl_Accounts");
                //coas = coasQuery.ToList();
                //bindingSourceCOA.DataSource = coas;
                groupBox9.Text = bindingSourceCOA.Count.ToString();

                BuildTree();
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        private void editChartOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //TreeNode selectedNode = treeViewChartofAccounts.SelectedNode;
                //int itemId = int.Parse(selectedNode.Name);
                //var _COAquery = (from coa in db.gl_COA
                //                 where coa.Id == itemId
                //                 select coa).FirstOrDefault();
                //DAL.gl_COA _COA = _COAquery;
                //EditCOAForm f = new EditCOAForm(itemId, _COA, connection) { Owner = this };
                //f.Text = selectedNode.Text.ToString().Trim().ToUpper();
                //f.ShowDialog();
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //TreeNode selectedNode = treeViewChartofAccounts.SelectedNode;
                //int itemId = int.Parse(selectedNode.Name);
                //var _COAquery = (from coa in db.gl_COA
                //                 where coa.Id == itemId
                //                 select coa).FirstOrDefault();
                //DAL.gl_COA _COA = _COAquery;
                //EditCOAForm f = new EditCOAForm(itemId, _COA, connection) { Owner = this };
                //f.Text = selectedNode.Text.ToString().Trim().ToUpper();
                //f.DisableControls();
                //f.ShowDialog();
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }

        private void deleteChartOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //TreeNode selectedNode = treeViewChartofAccounts.SelectedNode;

                //StringBuilder strb = new StringBuilder();
                //printTree(selectedNode, strb);
                //string message = "Are you sure you want to delete Chart of Accounts with the following children \n";
                //message += strb.ToString();

                //if (DialogResult.Yes == MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                //{
                //    //confirm first no FK constraint
                //    int itemId = int.Parse(selectedNode.Name);
                //    var _COAquery = (from coa in db.gl_COA
                //                     where coa.Id == itemId
                //                     select coa).FirstOrDefault();
                //    gl_COA _COA = _COAquery;
                //    var _Accountsquery = from acnts in db.gl_Accounts
                //                         where acnts.COAId == _COA.Id
                //                         select acnts;
                //    List<gl_Accounts> _Accounts = _Accountsquery.ToList();
                //    if (_Accounts.Count > 0)
                //    {
                //        MessageBox.Show("There is an Account Associated with this Chart of Accounts.\n Remove the Account Reference First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    }
                //    //delete now
                //    deleteTree(selectedNode);
                //    MessageBox.Show("Deleted all", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    RefreshGrid();
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewChartofAccounts.SelectedNode;
                int itemId = int.Parse(selectedNode.Name);
                AddAccountForm f = new AddAccountForm(itemId, connection) { Owner = this };
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);

            }
        }
        private void printTree(TreeNode node, StringBuilder str)
        {
            try
            {
                printNode(node, 0, str);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void printNode(TreeNode node, int level, StringBuilder str)
        {
            try
            {
                //printTitle(node.title);
                string indent = "".PadLeft(level * 2, '-');
                str.AppendLine(indent + "  " + node.Name + " / " + node.Text + "\n");
                foreach (TreeNode child in node.Nodes)
                {
                    printNode(child, level + 1, str); //<-- recursive
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void deleteTree(TreeNode node)
        {
            try
            {
                deleteNode(node, 0);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void deleteNode(TreeNode node, int level)
        {
            try
            {
                ////delete gl_COA Item 
                //int itemid = int.Parse(node.Name);
                //var coa = (from c in db.gl_COA
                //           where c.Id == itemid
                //           select c).SingleOrDefault();
                //gl_COA _COA = coa;
                //var _Accountsquery = from acnts in db.gl_Accounts
                //                     where acnts.COAId == _COA.Id
                //                     select acnts;
                //List<gl_Accounts> _Accounts = _Accountsquery.ToList();
                //if (_Accounts.Count > 0)
                //{
                //    MessageBox.Show("There is an Account Associated with this Chart of gl_Accounts.\n" + node.Text + "\n Remove the Account Reference First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //}
                //db.DeleteObject(coa);
                //db.SaveChanges();

                ////delete others
                //foreach (TreeNode child in node.Nodes)
                //{
                //    deleteNode(child, level + 1); //<-- recursive
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private decimal ComputeCoaAccTotals(int coaid)
        {
            try
            {
                decimal res = 0;
                //List<int> lstIds = new List<int>();
                //CreateIdList(coaid, lstIds);
                //var accQuery = db.gl_Accounts.Where(crtu => lstIds.Contains(crtu.COAId));
                //if (accQuery.Count() > 0)
                //    res = accQuery.Sum(i => i.BookBalance);

                return res;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private void dataGridViewAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count != 0)
            {
                try
                {
                    //gl_Accounts _Account = (gl_Accounts)bindingSourceAccounts.Current;
                    //WinSBSchool.Reports.Views.Screen.EnquiryViewForm f = new WinSBSchool.Reports.Views.Screen.EnquiryViewForm(connection, _Account);
                    //f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }



    }
}
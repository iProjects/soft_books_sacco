using System; 
using System.Collections.Generic;
using System.ComponentModel; 
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq; 
using System.Windows.Forms;
using CommonLib; 
using DAL;

namespace AdminstratorModule.Views
{
    public partial class EconomicActivityForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        bool busy = false;
        #endregion "Private Fields"

        #region "Constructor"
        public EconomicActivityForm(string Conn)
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void EconomicActivityForm_Load(object sender, EventArgs e)
        {
            try
            {
                treeViewEconomicActivities.CheckBoxes = true;
                treeViewEconomicActivities.FullRowSelect = true;
                treeViewEconomicActivities.HideSelection = false;
                treeViewEconomicActivities.HotTracking = true;
                treeViewEconomicActivities.ShowLines = true;
                treeViewEconomicActivities.ShowNodeToolTips = true;
                treeViewEconomicActivities.ShowPlusMinus = true;
                treeViewEconomicActivities.ShowRootLines = true; 
                
                BuildTree();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewEconomicActivities.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootActivity":
                            int ritemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            MessageBox.Show("Cannot Edit Root Node", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                    string _text = selectedNode.Text.ToString().Split('-')[1];
                    var _EconomicActivityquery = (from loc in rep.GetNonDeletedEconomicActivitiesList()
                                                  where loc.activityid == itemId
                                                  where loc.name == _text
                                                  select loc).FirstOrDefault();
                    ActivityModel _EconomicActivity = _EconomicActivityquery;
                    if (_EconomicActivity != null)
                    {
                        EditEconomicActivityForm f = new EditEconomicActivityForm(_EconomicActivity, connection) { Owner = this };
                        f.Text = _EconomicActivity.name.Trim().ToUpper();
                        f.ShowDialog();
                    }
                             
                            break;
                    } 

                    
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewEconomicActivities.SelectedNode;
                if (selectedNode != null)
                {
                    int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                    AddEconomicActivityForm f = new AddEconomicActivityForm(itemId, connection) { Owner = this };
                    f.ShowDialog();
                }
                else
                {
                    int _itemId = 0;
                    AddEconomicActivityForm f = new AddEconomicActivityForm(_itemId, connection) { Owner = this };
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewEconomicActivities.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootActivity":
                            int ritemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            MessageBox.Show("Cannot Delete Root Node", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break; 
                       default:
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                    string _text = selectedNode.Text.ToString().Split('-')[1];
                    var _EconomicActivityquery = (from loc in rep.GetNonDeletedEconomicActivitiesList()
                                                  where loc.activityid == itemId
                                                  where loc.name == _text
                                                  select loc).FirstOrDefault();
                    ActivityModel _EconomicActivity = _EconomicActivityquery;

                    var _EconomicActivityChildrenquery = from loc in rep.GetNonDeletedEconomicActivitiesList()
                                                         where loc.parent_id == _EconomicActivity.activityid
                                                         select loc;
                    List<ActivityModel> _EconomicActivityChildren = _EconomicActivityChildrenquery.ToList();
                    if (_EconomicActivity.name.Equals("Economic Activity"))
                    {
                        MessageBox.Show("You cannot Delete the Root Economic Activity!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (_EconomicActivityChildren.Count > 0)
                    {
                        MessageBox.Show("There is an Economic Activity Associated with this Economic Activity as its Parent.\n Delete the Child Economic Activity First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Economic Activity \n" + _EconomicActivity.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteEconomicActivity(_EconomicActivity);
                            RefreshGrid();
                        }
                    }
                            break;
                    } 
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void treeViewEconomicActivities_AfterSelect(object sender, TreeViewEventArgs e)
        {

            try
            {

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
                treeViewEconomicActivities.Nodes.Clear(); // Clear any existing items
                treeViewEconomicActivities.BeginUpdate(); // prevent overhead and flicker 

                TreeNode root = new TreeNode();
                ActivityModel _economicActivity = new ActivityModel() { name = "Economic Activity", activityid = 0 };
                LocationNode i = new LocationNode("0",
                                          "RootActivity",
                                          _economicActivity);
                root.Text = i.Key + "-" + "Economic Activity";
                root.Tag = i; 
                PopulateTreeViewEconomicActivities(root);
                treeViewEconomicActivities.Nodes.Add(root);

                treeViewEconomicActivities.EndUpdate(); // re-enable the tree
                treeViewEconomicActivities.Refresh(); // refresh the treeview display
                treeViewEconomicActivities.ExpandAll(); // expand all nodes
                if (treeViewEconomicActivities.Nodes.Count > 0)
                {
                    // Select the root node
                    treeViewEconomicActivities.SelectedNode = treeViewEconomicActivities.Nodes[0];
                }
                int count = treeViewEconomicActivities.GetNodeCount(true);
                groupBox3.Text =   count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeViewEconomicActivities(TreeNode node)
        {
            try
            {
                var _economicActivitiesquery = from pr in rep.GetNonDeletedEconomicActivitiesList()
                                               where pr.parent_id == null
                                               select pr;
                List<ActivityModel> _ecnmcActivities = _economicActivitiesquery.ToList();
                foreach (var _economicActivity in _ecnmcActivities)
                {
                    LocationNode i = new LocationNode(_economicActivity.activityid.ToString(),
                                              "ActivityModel",
                                              _economicActivity);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _economicActivity.name; 
                    node.Nodes.Add(clnode);

                    PopulateTreeViewEconomicActivitiesChildren(clnode, _economicActivity);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeViewEconomicActivitiesChildren(TreeNode node, ActivityModel economicActivity)
        {
            try
            {
                var _economicActivitiesquery = from ds in rep.GetNonDeletedEconomicActivitiesList()
                                               where ds.parent_id == economicActivity.activityid
                                               select ds;
                List<ActivityModel> _ecnmcActivities = _economicActivitiesquery.ToList();
                foreach (var _economicActivity in _ecnmcActivities)
                {
                    LocationNode i = new LocationNode(_economicActivity.activityid.ToString(),
                                              "ActivityModel",
                                              _economicActivity);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _economicActivity.name; 
                    node.Nodes.Add(clnode);

                    PopulateTreeViewEconomicActivitiesGrandChildren(node, _economicActivity);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeViewEconomicActivitiesGrandChildren(TreeNode node, ActivityModel economicActivity)
        {
            try
            {
                var _economicActivitiesquery = from ds in rep.GetNonDeletedEconomicActivitiesList()
                                               where ds.parent_id == economicActivity.activityid
                                               select ds;
                List<ActivityModel> _ecnmcActivities = _economicActivitiesquery.ToList();
                foreach (var _economicActivity in _ecnmcActivities)
                {
                    LocationNode i = new LocationNode(_economicActivity.activityid.ToString(),
                                              "ActivityModel",
                                              _economicActivity);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _economicActivity.name;
                    node.Nodes.Add(clnode);

                    PopulateTreeViewEconomicActivitiesGrandChildren(node, _economicActivity);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnExpandAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                treeViewEconomicActivities.ExpandAll();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCollapseAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                treeViewEconomicActivities.CollapseAll();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }        
        private void treeViewEconomicActivities_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (busy) return;
            busy = true;
            try
            {
                checkNodes(e.Node, e.Node.Checked);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
            finally
            {
                busy = false;
            }
        }
        private void checkNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                checkNodes(child, check);
            }
        }
        #endregion "Private Methods"


    }
}
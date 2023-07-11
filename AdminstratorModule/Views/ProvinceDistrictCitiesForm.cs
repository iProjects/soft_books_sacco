using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class ProvinceDistrictCitiesForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        bool busy = false;
        #endregion "Private Fields"

        #region "Constructor"
        public ProvinceDistrictCitiesForm(string Conn)
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
        public void BuildTree()
        {
            try
            {
                treeViewProvincesDistricts.Nodes.Clear(); // Clear any existing items
                treeViewProvincesDistricts.BeginUpdate(); // prevent overhead and flicker 

                TreeNode root = new TreeNode();
                ProvinceModel Province = new ProvinceModel() { name = "Provinces and Districts", provinceid = 0 };
                LocationNode i = new LocationNode("0",
                                          "RootLocation",
                                          Province);
                root.Text = i.Key + "-" + "Provinces and Districts";
                root.Tag = i; 
                PopulateTreeWithProvinces(root);
                treeViewProvincesDistricts.Nodes.Add(root); 

                treeViewProvincesDistricts.EndUpdate(); // re-enable the tree
                treeViewProvincesDistricts.Refresh(); // refresh the treeview display
                treeViewProvincesDistricts.ExpandAll(); // expand all nodes
                if (treeViewProvincesDistricts.Nodes.Count > 0)
                {
                    // Select the root node
                    treeViewProvincesDistricts.SelectedNode = treeViewProvincesDistricts.Nodes[0];
                }
                int count = treeViewProvincesDistricts.GetNodeCount(true);
                groupBox2.Text =   count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeWithProvinces(TreeNode node)
        {
            try
            {
                var _provincequery = from pr in rep.GetNonDeletedProvinces()
                                     select pr;
                List<ProvinceModel> _provinces = _provincequery.ToList();
                foreach (var _province in _provinces)
                {
                    LocationNode i = new LocationNode(_province.provinceid.ToString(),
                                              "ProvinceModel",
                                              _province);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _province.name; 
                    node.Nodes.Add(clnode);

                    PopulateTreeWithDistricts(clnode, _province);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeWithDistricts(TreeNode node, ProvinceModel _province)
        {
            try
            {
                var _districtsquery = from ds in rep.GetNonDeletedDistricts(_province.provinceid)
                                      select ds;
                List<DistrictModel> _districts = _districtsquery.ToList();
                foreach (var _district in _districts)
                {
                    LocationNode i = new LocationNode(_district.districtid.ToString(),
                                                  "DistrictModel",
                                                  _district);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _district.name; 
                    node.Nodes.Add(clnode);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void treeViewProvincesDistricts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewProvincesDistricts.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {

                        case "ProvinceModel":
                            addToolStripMenuItem.Enabled = true;
                            break;
                        case "RootLocation":
                            addToolStripMenuItem.Enabled = true;
                            break;
                        case "DistrictModel":
                            addToolStripMenuItem.Enabled = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ProvinceDistrictCitiesForm_Load(object sender, EventArgs e)
        {
            try
            {
                treeViewProvincesDistricts.CheckBoxes = true;
                treeViewProvincesDistricts.FullRowSelect = true;
                treeViewProvincesDistricts.HideSelection = false;
                treeViewProvincesDistricts.HotTracking = true;
                treeViewProvincesDistricts.ShowLines = true;
                treeViewProvincesDistricts.ShowNodeToolTips = true;
                treeViewProvincesDistricts.ShowPlusMinus = true;
                treeViewProvincesDistricts.ShowRootLines = true; 
                
                BuildTree();
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
                TreeNode selectedNode = treeViewProvincesDistricts.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootLocation":
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            AddProvinceDistrictCityForm f = new AddProvinceDistrictCityForm(itemId, connection) { Owner = this };
                            f.ShowDialog();
                            break;
                        case "ProvinceModel":
                            int ditemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            ProvinceModel pm = rep.GetProvince(ditemId);
                            AddProvinceDistrictCityForm df = new AddProvinceDistrictCityForm(pm, connection) { Owner = this };
                            df.ShowDialog();
                            break;
                        case "DistrictModel":
                            addToolStripMenuItem.Enabled = false;
                            break;
                    }
                }
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
                TreeNode selectedNode = treeViewProvincesDistricts.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootLocation":
                            int ritemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            MessageBox.Show("Cannot Edit Root Node", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "ProvinceModel":
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            ProvinceModel pm = rep.GetProvince(itemId);
                            EditProvinceDistrictCityForm f = new EditProvinceDistrictCityForm(pm, connection) { Owner = this };
                            f.Text = pm.name.Trim().ToUpper();
                            f.ShowDialog();
                            break;
                        case "DistrictModel":
                            int ditemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            DistrictModel dm = rep.GetDistrict(ditemId);
                            EditProvinceDistrictCityForm df = new EditProvinceDistrictCityForm(dm, connection) { Owner = this };
                            df.Text = dm.name.Trim().ToUpper();
                            df.ShowDialog();
                            break;
                    }
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
                TreeNode selectedNode = treeViewProvincesDistricts.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootLocation":
                            int ritemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            MessageBox.Show("Cannot Delete Root Node", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "ProvinceModel":
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            ProvinceModel pm = rep.GetProvince(itemId);
                            if (pm != null)
                            {
                                var _districtsquery = from loc in rep.GetNonDeletedDistricts(pm.provinceid)
                                                      select loc;
                                List<DistrictModel> _provincedistricts = _districtsquery.ToList();
                                if (_provincedistricts.Count > 0)
                                {
                                    MessageBox.Show("There is a District Associated with this Province as its Parent.\n Delete the District First!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Province \n" + pm.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                                    {
                                        rep.DeleteProvince(pm);
                                        RefreshGrid();
                                    }
                                }
                            }
                            break;
                        case "DistrictModel":
                            int ditemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            DistrictModel dm = rep.GetDistrict(ditemId);
                            if (dm != null)
                            {
                                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete District \n" + dm.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                                {
                                    rep.DeleteDistrict(dm);
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
        private void btnExpandAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                treeViewProvincesDistricts.ExpandAll();
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
                treeViewProvincesDistricts.CollapseAll();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void treeViewProvincesDistricts_AfterCheck(object sender, TreeViewEventArgs e)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;

namespace DAL
{
    public class TreeBuilder
    {

        #region "EconomicActivities tree"
        public void PopulateTreeViewEconomicActivities(TreeView tree, List<ActivityModel> _economicActivities)
        {
            try
            {
                Item first = new Item
                {
                    ItemID = 0,
                    Text = "Economic Activity",
                    Payload = null
                };

                List<Item> i = (from s in _economicActivities
                                select new Item
                                {
                                    ItemID = s.activityid,
                                    ParentID = s.parent_id ?? 0,
                                    Text = s.name
                                }).ToList();

                List<Item> all = new List<Item>();
                all.AddRange(i);


                TreeNode root = new TreeNode();
                LocationNode _i = new LocationNode("0",
                                          "ActivityModel",
                                          first);
                root.Text = "Economic Activity";
                root.Tag = _i;
                tree.Nodes.Add(root);

                PopulateTreeViewEnumerable(tree, all);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "EconomicActivities tree"

        #region "ChartOfAccounts tree"
        public void PopulateTreeViewChartOfAccounts(TreeView tree, List<AccountCategoryModel> _accountCategories)
        {
            try
            {
                List<Item> i = (from s in _accountCategories
                                select new Item
                                {
                                    ItemID = s.accountcategoryid,
                                    ParentID = s.accountcategoryid,
                                    Text = s.name
                                }).ToList();

                List<Item> all = new List<Item>();
                all.AddRange(i); 

                PopulateTreeViewEnumerable(tree, all);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "ChartOfAccounts tree"

        #region "Settings tree"
        public void PopulateTreeView(TreeView tree, List<DAL.SettingsGroup> settingsGroup)
        {
            try
            {
                Item first = new Item
                {
                    ItemID = 0,
                    Text = "Settings",
                    Payload = null
                };

                List<Item> i = (from s in settingsGroup
                                select new Item
                                {
                                    ItemID = s.Id,
                                    ParentID = s.Parent ?? 0,
                                    Text = s.GroupName,
                                    Payload = s.Settings
                                }).ToList();

                List<Item> all = new List<Item>();
                all.AddRange(i);

                PopulateTreeViewEnumerable(tree, all);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Settings tree"

        #region "generic tree"
        public void PopulateTreeViewEnumerable(TreeView tree, IEnumerable<Item> items)
        {
            try
            {
            Dictionary<int, Tuple<Item, TreeNode>> allNodes = new Dictionary<int, Tuple<Item, TreeNode>>();

            foreach (var item in items)
            {
                var node = CreateTreeNode(item);
                allNodes.Add(item.ItemID, Tuple.New(item, node));
            }

            foreach (var kvp in allNodes)
            { 
                if (kvp.Value.First.ParentID != 0)
                {
                    allNodes[kvp.Value.First.ParentID].Second.Nodes.Add(kvp.Value.Second);
                }
                else
                {
                    tree.Nodes.Add(kvp.Value.Second);
                }
            }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "generic tree"

        private TreeNode CreateTreeNode(Item item)
        {
            var node = new TreeNode();
            node.Text = item.Text;
            node.Name = item.ItemID.ToString();
            return node;
        }

    }

    public class Item
    {
        public int ItemID { get; set; }
        public int ParentID { get; set; }
        public string Text { get; set; }
        public object Payload { get; set; }
    }

    public class Tuple<T>
    {
        public Tuple(T first)
        {
            First = first;
        }

        public T First { get; set; }
    }

    public class Tuple<T, T2> : Tuple<T>
    {
        public Tuple(T first, T2 second)
            : base(first)
        {
            Second = second;
        }

        public T2 Second { get; set; }
    }

    public static class Tuple
    {
        //Allows Tuple.New(1, "2") instead of new Tuple<int, string>(1, "2")
        public static Tuple<T1> New<T1>(T1 t1)
        {
            return new Tuple<T1>(t1);
        }

        public static Tuple<T1, T2> New<T1, T2>(T1 t1, T2 t2)
        {
            return new Tuple<T1, T2>(t1, t2);
        }
    }

    public class LocationNode
    {
        public string Key { get; set; }
        public string Table { get; set; }
        public object Item { get; set; }

        public LocationNode()
        {

        }
        public LocationNode(string key, string table, object payload)
        {
            this.Key = key;
            this.Table = table;
            this.Item = payload;
        }
    }
}

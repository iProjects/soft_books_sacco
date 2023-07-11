using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class AuditTrailForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public AuditTrailForm(int _user, string Conn)
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AuditTrailForm_Load(object sender, EventArgs e)
        {
            try
            {
                IList<UserModel_dto> loanoficers = rep.GetUsersModelwithRolesList();
                cboUsers.DataSource = loanoficers;
                cboUsers.DisplayMember = "full_name";
                cboUsers.ValueMember = "userid";
                cboUsers.SelectedIndex = -1;

                var _branchesquery = from br in rep.GetNonDeletedBranches()
                                     select br;
                List<BranchModel> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                cboBranch.SelectedIndex = -1;

                listViewEventTypes.View = View.Details;
                listViewEventTypes.GridLines = true;
                listViewEventTypes.FullRowSelect = true;
                listViewEventTypes.MultiSelect = false;
                listViewEventTypes.HideSelection = false;
                listViewEventTypes.Columns.Add("EventType", 100, HorizontalAlignment.Left);
                // Width of -2 indicates auto-size.
                listViewEventTypes.Columns.Add("Description", -2, HorizontalAlignment.Left);
                listViewEventTypes.Items.Clear();

                ImageList photoList = new ImageList();
                photoList.TransparentColor = Color.Blue;
                photoList.ColorDepth = ColorDepth.Depth32Bit;
                photoList.ImageSize = new Size(10, 10);
                photoList.Images.Add(Image.FromFile("Resources/greenmage.jpg"));
                listViewEventTypes.SmallImageList = photoList;

                PopulateListView();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateListView()
        {
            try
            {

                var _EventTypesquery = (from sc in rep.GetEventTypesList()
                                        select sc).Distinct().ToList();
                List<EventTypesModel> _EventTypes = _EventTypesquery.ToList();

                listViewEventTypes.Items.Clear(); 
                foreach (var sc in _EventTypes)
                { 
                    listViewEventTypes.Items.Add(new ListViewItem(new string[]
                       {
                          sc.event_type,sc.description
                       }));
                }

                foreach (ListViewItem item in listViewEventTypes.Items)
                {
                    item.ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in listViewEventTypes.Items)
                {
                    lvi.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUnCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in listViewEventTypes.Items)
                {
                    lvi.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
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
        #endregion "Private Methods"




    }
}

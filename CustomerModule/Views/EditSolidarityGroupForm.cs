using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using SearchModule.Views;

namespace CustomerModule.Views
{
    public partial class EditSolidarityGroupForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        //gl_SolidarityGroup solidarityGroup;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public EditSolidarityGroupForm( int _user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
            //solidarityGroup = _solidaritygroup;
            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUploadSolidarityGroupPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Create OpenFileDialog 
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Title = "Please select an image file.";
                // Set filter for file extension 
                //ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;
                foreach (var c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, codecName, c.FilenameExtension);
                    sep = "|";
                }
                ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, "All Files", "*.*");
                // Default file extension
                ofd.DefaultExt = ".jpg";
                // Display OpenFileDialog by calling ShowDialog method
                Nullable<bool> result = ofd.ShowDialog();
                // Process open file dialog box results
                if (result == true)
                {
                    // Get the selected file name and display in a TextBox 
                    string filename = ofd.FileName.Trim().ToString();
                    System.IO.FileInfo fileinfo = new System.IO.FileInfo(ofd.FileName);
                    if (!string.IsNullOrEmpty(filename) && !string.IsNullOrWhiteSpace(filename))
                    {
                        string imagepath = fileinfo.FullName;
                        pbPhoto.ImageLocation = imagepath;
                        pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }

        private void EditSolidarityGroupForm_Load(object sender, EventArgs e)
        {
            try
            {
                listViewSolidarityGroupDocuments.View = View.Details;
                listViewSolidarityGroupDocuments.GridLines = true;
                listViewSolidarityGroupDocuments.FullRowSelect = true;
                listViewSolidarityGroupDocuments.MultiSelect = false;
                listViewSolidarityGroupDocuments.Columns.Add("", "File", 100);
                listViewSolidarityGroupDocuments.Columns.Add("", "Doc Name", 200);
                listViewSolidarityGroupDocuments.Columns.Add("", "User", 100);
                listViewSolidarityGroupDocuments.Columns.Add("", "Comment", 100);
                listViewSolidarityGroupDocuments.Columns.Add("", "Date", 100);
                listViewSolidarityGroupDocuments.Columns.Add("", "Size", -2);

                ImageList photoListSolidarityGroupDocuments = new ImageList();
                photoListSolidarityGroupDocuments.TransparentColor = Color.Blue;
                photoListSolidarityGroupDocuments.ColorDepth = ColorDepth.Depth32Bit;
                photoListSolidarityGroupDocuments.ImageSize = new Size(10, 10);
                photoListSolidarityGroupDocuments.Images.Add(Image.FromFile("Resources/greenmage.jpg"));
                listViewSolidarityGroupDocuments.SmallImageList = photoListSolidarityGroupDocuments;

                listViewGroupMembers.View = View.Details;
                listViewGroupMembers.GridLines = true;
                listViewGroupMembers.FullRowSelect = true;
                listViewGroupMembers.MultiSelect = false;
                listViewGroupMembers.Columns.Add("", "FirstName", 200);
                listViewGroupMembers.Columns.Add("", "LastName", 100);
                listViewGroupMembers.Columns.Add("", "FatherName", 100);
                listViewGroupMembers.Columns.Add("", "DateofBirth", -2);

                ImageList photoListGroupMembers = new ImageList();
                photoListGroupMembers.TransparentColor = Color.Blue;
                photoListGroupMembers.ColorDepth = ColorDepth.Depth32Bit;
                photoListGroupMembers.ImageSize = new Size(10, 10);
                photoListGroupMembers.Images.Add(Image.FromFile("Resources/leafmage.jpg"));
                listViewGroupMembers.SmallImageList = photoListGroupMembers;

                //RefreshGroupMembersListView();

                //RefreshSolidarityGroupDocumentsListView();

                //pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                //var _branchesquery = from af in db.gl_Branches
                //                     where af.Isdeleted == false
                //                     select af;
                //List<gl_Branches> _Branches = _branchesquery.ToList();
                //cboBranch.DataSource = _Branches;
                //cboBranch.ValueMember = "Id";
                //cboBranch.DisplayMember = "BranchName";
                //cboBranch.SelectedIndex = -1;

                //chkSetMeetingDate.Checked = false;
                //cboMeetingDate.Enabled = false;

                //var _UsersQuery = from us in db.sec_Users
                //                  select us;
                //List<sec_Users> _Users = _UsersQuery.ToList();

                //cboGroupOfficer.DataSource = _Users;
                //cboGroupOfficer.DisplayMember = "FullNames";
                //cboGroupOfficer.ValueMember = "UserName";               
                //cboGroupOfficer.SelectedIndex = -1;

                cboMeetingDate.DataSource = GetDayNames();
                cboMeetingDate.SelectedIndex = -1;

                //InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        public string[] GetDayNames()
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
        }


        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsSolidarityGroupValid())
            {
                try
                {
                    //if (!string.IsNullOrEmpty(txtGroupName.Text))
                    //{
                    //    solidarityGroup.Description = Utils.ConvertFirstLetterToUpper(txtGroupName.Text.Trim());
                    //}
                    //solidarityGroup.sDateofEstablishment = dtpEstablishmentDate.Value;
                    //if (cboGroupOfficer.SelectedIndex != -1)
                    //{
                    //    solidarityGroup.sGroupOfficer = cboGroupOfficer.SelectedValue.ToString();
                    //}
                    //solidarityGroup.sSetMeetingDate = chkSetMeetingDate.Checked;
                    //if (cboMeetingDate.SelectedIndex != -1)
                    //{
                    //    solidarityGroup.sMeetingDate = cboMeetingDate.Text;
                    //}
                    //if (cboBranch.SelectedIndex != -1)
                    //{
                    //    solidarityGroup.BranchId = int.Parse(cboBranch.SelectedValue.ToString());
                    //}
                    //if (pbPhoto.ImageLocation != null)
                    //{
                    //    solidarityGroup.sPhoto = pbPhoto.ImageLocation.ToString().Trim();
                    //} 
                    //if (cboHAProvince.SelectedIndex != -1)
                    //{
                    //    solidarityGroup.sHomeProvince = cboHAProvince.SelectedValue.ToString();
                    //}
                    //if (cboHADistrict.SelectedIndex != -1)
                    //{
                    //    solidarityGroup.sHomeDistrict = cboHADistrict.SelectedValue.ToString();
                    //}
                    //if (!string.IsNullOrEmpty(txtHACity.Text))
                    //{
                    //    solidarityGroup.sHomeCity = txtHACity.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHAdress.Text))
                    //{
                    //    solidarityGroup.sHomeAddress = txtHAdress.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHAZipCode.Text))
                    //{
                    //    solidarityGroup.sHomeZipCode = txtHAZipCode.Text;
                    //}
                    //if (cboHAHomeType.SelectedIndex != -1)
                    //{
                    //    solidarityGroup.sHomeType = cboHAHomeType.SelectedValue.ToString();
                    //}
                    //if (!string.IsNullOrEmpty(txtHAHomePhone.Text))
                    //{
                    //    solidarityGroup.sHomePhone = txtHAHomePhone.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHACellPhone.Text))
                    //{
                    //    solidarityGroup.sHomeCellPhone = txtHACellPhone.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHAEmail.Text))
                    //{
                    //    solidarityGroup.sHomeEmail = txtHAEmail.Text;
                    //}

                    //rep.UpdateSolidarityGroup(solidarityGroup);

                    //SolidarityGroupsListForm f = (SolidarityGroupsListForm)this.Owner;
                    //f.RefreshGrid();
                    //this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }


        #region "Validation"
        private bool IsSolidarityGroupValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtGroupName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtGroupName, "Group Name cannot be null!");
                return false;
            }
            if (chkSetMeetingDate.Checked && cboMeetingDate.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboMeetingDate, "Select Meeting Day!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"

        private void chkSetMeetingDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetMeetingDate.Checked)
            {
                cboMeetingDate.Enabled = true;
            }
            else
            {
                cboMeetingDate.Enabled = false;
                cboMeetingDate.SelectedIndex = -1;
            }

        }
        //private void InitializeControls()
        //{

        //    try
        //    {
        //        if (solidarityGroup.Description != null)
        //        {
        //            txtGroupName.Text = solidarityGroup.Description;
        //        }
        //        if (solidarityGroup.sDateofEstablishment != null)
        //        {
        //            dtpEstablishmentDate.Value = solidarityGroup.sDateofEstablishment.Value;
        //        }
        //        if (solidarityGroup.sGroupOfficer != null)
        //        {
        //            cboGroupOfficer.SelectedValue = solidarityGroup.sGroupOfficer;
        //        }
        //        if (solidarityGroup.sSetMeetingDate != null)
        //        {
        //            chkSetMeetingDate.Checked = solidarityGroup.sSetMeetingDate.Value;
        //        }
        //        if (solidarityGroup.sMeetingDate != null)
        //        {
        //            cboMeetingDate.Text = solidarityGroup.sMeetingDate;
        //        }
        //        if (solidarityGroup.BranchId != null)
        //        {
        //            cboBranch.SelectedValue = solidarityGroup.BranchId;
        //        }
        //        if (solidarityGroup.sPhoto != null)
        //        {
        //            pbPhoto.ImageLocation = solidarityGroup.sPhoto;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //    }

        //}
        public void DisableControls()
        {

            try
            {
                txtGroupName.Enabled = false;
                dtpEstablishmentDate.Enabled = false;
                cboGroupOfficer.Enabled = false;
                cboMeetingDate.Enabled = false;
                chkSetMeetingDate.Enabled = false;
                btnUploadSolidarityGroupPhoto.Enabled = false;
                cboBranch.Enabled = false;
                pbPhoto.Enabled = false;
                btnUpdate.Enabled = false;
                btnUpdate.Visible = false;
                btnClose.Location = btnUpdate.Location;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        #endregion "Private Methods"

        private void btnAddSolidarityGroupDocuments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                const string ObjectContainer = "listViewSolidarityGroupDocuments";

                //AddDocumentForm adf = new AddDocumentForm(solidarityGroup.Id, ObjectContainer, _user, connection) { Owner = this };
                //adf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewSolidarityGroupDocuments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewSolidarityGroupDocuments.SelectedItems != null)
            {
                try
                {
                    //const string ObjectContainer = "listViewSolidarityGroupDocuments";

                    //int ObjectId = solidarityGroup.Id;

                    //ListViewItem lviSelectedDocument = listViewSolidarityGroupDocuments.SelectedItems[0];

                    //foreach (ListViewItem lvi in listViewSolidarityGroupDocuments.SelectedItems)
                    //{
                    //    ListViewItem.ListViewSubItem SubItem = lvi.SubItems[1];

                    //    gl_Documents doc = this.GetDocument(SubItem.Text, ObjectId, ObjectContainer);

                    //    string filepath = doc.DocFilePath;

                    //    if (File.Exists(filepath))
                    //    {
                    //        Process p = null;
                    //        if (p == null)
                    //        {
                    //            p = new Process();
                    //            p.StartInfo.FileName = filepath;
                    //            p.Start();
                    //            p.WaitForExit();
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        //private gl_Documents GetDocument(string docname, int ObjectId, string ObjectContainer)
        //{
        //    try
        //    {
        //        var doc = (from dc in db.gl_Documents
        //                   where dc.DocName == docname
        //                   where dc.ObjectId == ObjectId
        //                   where dc.ObjectContainer == ObjectContainer
        //                   select dc).FirstOrDefault();
        //        return doc;

        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //        return null;
        //    }
        //}
        private void btnDeleteSolidarityGroupDocuments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewSolidarityGroupDocuments.SelectedItems != null)
            {
                try
                {
                    //const string ObjectContainer = "listViewSolidarityGroupDocuments";

                    //int ObjectId = solidarityGroup.Id;


                    //foreach (ListViewItem lvi in listViewSolidarityGroupDocuments.SelectedItems)
                    //{
                    //    ListViewItem.ListViewSubItem SubItem = lvi.SubItems[1];

                    //    gl_Documents doc = this.GetDocument(SubItem.Text, ObjectId, ObjectContainer);

                    //    gl_Documents d = db.gl_Documents.Where(r => r.Id == doc.Id).Single();

                    //    db.gl_Documents.DeleteObject(d);

                    //    db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

                    //    RefreshSolidarityGroupDocumentsListView();
                    //}

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnSearchExistingClients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SearchPersonClientForm saf = new SearchPersonClientForm(connection) { Owner = this };
                saf.OnPersonClientListSelected += new SearchPersonClientForm.PersonClientSelectHandler(saf_OnPersonClientSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void saf_OnPersonClientSelected(object sender, PersonClientSelectEventArgs e)
        {
            SetPersonClient(e._Client);
        }
        private void SetPersonClient(Person _Client)
        {
            //if (_Client != null)
            //{
            //    _Client.GroupId = solidarityGroup.Id;

            //    rep.UpdatePersonGroup(_Client);

            //    RefreshGroupMembersListView();
            //}
        }
        //private void RefreshGroupMembersListView()
        //{
        //    try
        //    {
        //        listViewGroupMembers.Items.Clear();

        //        var groupmembersquery = from gm in db.Person
        //                                where gm.GroupId == solidarityGroup.Id
        //                                select gm;
        //        List<Person> NonSolidarityGroupDetailsDocuments = groupmembersquery.ToList();

        //        foreach (Person d in NonSolidarityGroupDetailsDocuments)
        //        {
        //            listViewGroupMembers.Items.Add(new ListViewItem(new string[]
        //        {
        //            //d.FirstName.ToString() ,d.LastName.ToString(),d.FatherName,d.DateofBirth.ToString()
        //        }));
        //        }

        //        foreach (ListViewItem item in listViewGroupMembers.Items)
        //        {
        //            item.ImageIndex = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //    }
        //}
        public void RefreshSolidarityGroupDocumentsListView()
        {
            try
            {
                //listViewSolidarityGroupDocuments.Items.Clear();

                //const string ObjectContainer = "listViewSolidarityGroupDocuments";

                //int ObjectId = solidarityGroup.Id;

                //var documentsquery = from dc in db.gl_Documents
                //                     where dc.ObjectId == ObjectId
                //                     where dc.ObjectContainer == ObjectContainer
                //                     select dc;

                //List<gl_Documents> SolidarityGroupDocuments = documentsquery.ToList();

                //foreach (gl_Documents d in SolidarityGroupDocuments)
                //{
                //    listViewSolidarityGroupDocuments.Items.Add(new ListViewItem(new string[]
                //{
                //     d.DocFileName,d.DocName ,d.dUser,d.Comment,
                //    d.UploadDate.ToString(),d.DocFileSize.ToString() + "  bytes" 
                //}));
                //}
                //foreach (ListViewItem item in listViewSolidarityGroupDocuments.Items)
                //{
                //    item.ImageIndex = 0;
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddGroupMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SearchPersonClientForm saf = new SearchPersonClientForm(connection) { Owner = this };
                saf.OnPersonClientListSelected += new SearchPersonClientForm.PersonClientSelectHandler(saf_OnPersonClientSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



    }
}

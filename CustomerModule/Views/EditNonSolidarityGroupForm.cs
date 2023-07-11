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
    public partial class EditNonSolidarityGroupForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        //gl_NonSolidarityGroup nonsolidaritygroup; 
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public EditNonSolidarityGroupForm( int _user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            user = _user;
            //nonsolidaritygroup = _nonsolidaritygroup;
        }
        #endregion "Constructor"

        #region "Private Methods"
        //private void btnDeleteNonSolidarityGroupDetailsDocuments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{

        //    if (listViewNonSolidarityGroupDocuments.SelectedItems != null)
        //    {
        //        try
        //        {
        //            const string ObjectContainer = "listViewNonSolidarityGroupDocuments";

        //            int ObjectId = nonsolidaritygroup.Id;

        //            foreach (ListViewItem lvi in listViewNonSolidarityGroupDocuments.SelectedItems)
        //            {
        //                ListViewItem.ListViewSubItem SubItem = lvi.SubItems[1];

        //                gl_Documents doc = this.GetDocument(SubItem.Text, ObjectId, ObjectContainer);

        //                gl_Documents d = db.gl_Documents.Where(r => r.Id == doc.Id).Single();

        //                db.gl_Documents.DeleteObject(d);

        //                db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

        //                RefreshNonSolidarityGroupDocumentsListView();
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Utils.ShowError(ex);
        //        }
        //    }
        //}
        //private void btnAddNonSolidarityGroupDetailsDocuments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        const string ObjectContainer = "listViewNonSolidarityGroupDocuments";

        //        AddDocumentForm adf = new AddDocumentForm(nonsolidaritygroup.Id, ObjectContainer, _user, connection) { Owner = this };
        //        adf.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //    }
        //}
        
        //private void btnViewNonSolidarityGroupDetailsDocuments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        const string ObjectContainer = "listViewNonSolidarityGroupDocuments";

        //        int ObjectId = nonsolidaritygroup.Id;

        //        ListViewItem lviSelectedDocument = listViewNonSolidarityGroupDocuments.SelectedItems[0];

        //        foreach (ListViewItem lvi in listViewNonSolidarityGroupDocuments.SelectedItems)
        //        {
        //            ListViewItem.ListViewSubItem SubItem = lvi.SubItems[1];

        //            gl_Documents doc = this.GetDocument(SubItem.Text, ObjectId, ObjectContainer);

        //            string filepath = doc.DocFilePath;

        //            if (File.Exists(filepath))
        //            {
        //                Process p = null;
        //                if (p == null)
        //                {
        //                    p = new Process();
        //                    p.StartInfo.FileName = filepath;
        //                    p.Start();
        //                    p.WaitForExit();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //    }
        //}
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnSearchExistingClents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            //SetPersonClient(e._Client);
        }
        //private void SetPersonClient(Person _Client)
        //{
        //    if (_Client != null)
        //    {
        //        //_Client.GroupId = nonsolidaritygroup.Id;

        //        rep.UpdatePersonGroup(_Client);

        //        //RefreshGroupMembersListView();
        //    }
        //}
        ////private void RefreshGroupMembersListView()
        //{
        //    try
        //    {      
        //        listViewGroupMembers.Items.Clear();

        //        var groupmembersquery = from gm in db.Person
        //                                where gm.GroupId == nonsolidaritygroup.Id
        //                                select gm;
        //        List<Person> NonSolidarityGroupDetailsDocuments = groupmembersquery.ToList();

        //        foreach (Person d in NonSolidarityGroupDetailsDocuments)
        //        {
        //            listViewGroupMembers.Items.Add(new ListViewItem(new string[]
        //        {
        //            d.FirstName.ToString() ,d.LastName.ToString(),d.FatherName,d.DateofBirth.ToString()
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
        //public void RefreshNonSolidarityGroupDocumentsListView()
        //{
        //    try
        //    {
        //        listViewNonSolidarityGroupDocuments.Items.Clear();

        //        const string ObjectContainer = "listViewNonSolidarityGroupDocuments";

        //        //int ObjectId = nonsolidaritygroup.Id;

        //        //var documentsquery = from dc in db.gl_Documents
        //        //                     where dc.ObjectId == ObjectId
        //        //                     where dc.ObjectContainer == ObjectContainer
        //        //                     select dc;

        //        //List<gl_Documents> NonSolidarityGroupDocuments = documentsquery.ToList();
                 
        //        //foreach (gl_Documents d in NonSolidarityGroupDocuments)
        //        //{
        //        //    listViewNonSolidarityGroupDocuments.Items.Add(new ListViewItem(new string[]
        //        //{
        //        //    d.DocFileName,d.DocName ,d.dUser,d.Comment,
        //        //    d.UploadDate.ToString(),d.DocFileSize.ToString() + "  bytes" 
        //        //}));
        //        //}
        //        //foreach (ListViewItem item in listViewNonSolidarityGroupDocuments.Items)
        //        //{
        //        //    item.ImageIndex = 0;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //    }
        //}
        private void btnUploadNonSolidarityGroupPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                        pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        string imagepath = fileinfo.FullName;
                        pbPhoto.ImageLocation = imagepath;

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsNonSolidarityGroupValid())
            {
                try
                {

                    //if (!string.IsNullOrEmpty(txtGroupName.Text))
                    //{
                    //    nonsolidaritygroup.Description = Utils.ConvertFirstLetterToUpper(txtGroupName.Text.Trim());
                    //}
                    //nonsolidaritygroup.nDateofEstablishment = dtpEstablishmentDate.Value;
                    //if (cboGroupOfficer.SelectedIndex != -1)
                    //{
                    //    nonsolidaritygroup.nGroupOfficer = cboGroupOfficer.SelectedValue.ToString();
                    //}
                    //nonsolidaritygroup.nSetMeetingDate = chkSetMeetingDate.Checked;
                    //if (cboMeetingDate.SelectedIndex != -1)
                    //{
                    //    nonsolidaritygroup.nMeetingDate = cboMeetingDate.Text;
                    //}
                    //if (cboBranch.SelectedIndex != -1)
                    //{
                    //    nonsolidaritygroup.BranchId = int.Parse(cboBranch.SelectedValue.ToString());
                    //}
                    //if (pbPhoto.ImageLocation != null)
                    //{
                    //    nonsolidaritygroup.nPhoto = pbPhoto.ImageLocation.Trim();
                    //}
                    //if (cboProvince.SelectedIndex != -1)
                    //{
                    //    nonsolidaritygroup.nProvince = cboProvince.SelectedValue.ToString();
                    //}
                    //if (cboDistrict.SelectedIndex != -1)
                    //{
                    //    nonsolidaritygroup.nDistrict = cboDistrict.SelectedValue.ToString();
                    //}
                    //if (!string.IsNullOrEmpty(txtCity.Text))
                    //{
                    //    nonsolidaritygroup.nCity = txtCity.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtAddress.Text))
                    //{
                    //    nonsolidaritygroup.nAddress = txtAddress.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtZipCode.Text))
                    //{
                    //    nonsolidaritygroup.nZipCode = txtZipCode.Text;
                    //}

                    //rep.UpdateNonSolidarityGroup(nonsolidaritygroup);

                    NonSolidarityGroupsListForm f = (NonSolidarityGroupsListForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }


        #region "Validation"
        private bool IsNonSolidarityGroupValid()
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

        private void EditNonSolidarityGroupForm_Load(object sender, EventArgs e)
        {
            try
            {

                listViewNonSolidarityGroupDocuments.View = View.Details;
                listViewNonSolidarityGroupDocuments.GridLines = true;
                listViewNonSolidarityGroupDocuments.FullRowSelect = true;
                listViewNonSolidarityGroupDocuments.MultiSelect = false;
                listViewNonSolidarityGroupDocuments.Columns.Add("", "File", 100);
                listViewNonSolidarityGroupDocuments.Columns.Add("", "Doc Name", 200);
                listViewNonSolidarityGroupDocuments.Columns.Add("", "User", 100);
                listViewNonSolidarityGroupDocuments.Columns.Add("", "Comment", 100);
                listViewNonSolidarityGroupDocuments.Columns.Add("", "Date", 100);
                listViewNonSolidarityGroupDocuments.Columns.Add("", "Size", -2); 
                
                ImageList photoList = new ImageList();
                photoList.TransparentColor = Color.Blue;
                photoList.ColorDepth = ColorDepth.Depth32Bit;
                photoList.ImageSize = new Size(10, 10);
                photoList.Images.Add(Image.FromFile("Resources/greenmage.jpg"));
                listViewNonSolidarityGroupDocuments.SmallImageList = photoList;

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
                photoListGroupMembers.Images.Add(Image.FromFile("Resources/colormager.jpg"));
                listViewGroupMembers.SmallImageList = photoListGroupMembers;

                //RefreshGroupMembersListView();

                //RefreshNonSolidarityGroupDocumentsListView();

                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                //List<vwBankBranch> banks = rep.GetBankBranches();
                //bindingSourceBank.DataSource = banks;

                //cbBank.DisplayMember = "BankBranchName";
                //cbBank.ValueMember = "BankSortCode";
                //cbBank.DataSource = bindingSourceBank;
                //cbBank.SelectedIndex = -1;

                //Autocomplete for cbBank
                //string[] strBanks = banks.Select(b => b.BankBranchName).ToArray();
                //AutoCompleteStringCollection eacsc = new AutoCompleteStringCollection();
                //eacsc.AddRange(strBanks);
                ////this.cbBank.AutoCompleteCustomSource = eacsc;

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

                cboNonSolidarityGroupMeetingDate.DataSource = GetDayNames();
                cboNonSolidarityGroupMeetingDate.SelectedIndex = -1;
                
                //InitializeControls();

                //List<Package> loans = rep.GetLoanPackagesList();
                //foreach (Package p in loans)
                //{
                //    ToolStripMenuItem loanmenu = new ToolStripMenuItem("", Properties.Resources.defaultphoto);
                //    //loanmenu.Text = p.Description.Trim();
                //    loanmenu.Click += new EventHandler(loanmenu_Click);
                //    AddNonSolidarityGroupLoanToolstripMenuItem.DropDownItems.Add(loanmenu);
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void loanmenu_Click(object sender, EventArgs e)
        {
            try
            { 
                ToolStripItem item = (ToolStripItem)sender;
                 
                //Package _loanpackage = this.GetLoan(item.Text);
                AddNonSolidarityGroupLoanForm ansgf = new AddNonSolidarityGroupLoanForm(connection);
                ansgf.ShowDialog();

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
        //private Package GetLoan(string loanname)
        //{
        //    try
        //    {
        //        return db.Package.Where(i => i.Description.Equals(loanname)).Single();

        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //        return null;
        //    }
        //}
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
        //        if (nonsolidaritygroup.Description != null)
        //        {
        //            txtGroupName.Text = nonsolidaritygroup.Description;
        //        }
        //        if (nonsolidaritygroup.nDateofEstablishment != null)
        //        {
        //            dtpEstablishmentDate.Value = nonsolidaritygroup.nDateofEstablishment.Value;
        //        }
        //        if (nonsolidaritygroup.nGroupOfficer != null)
        //        {
        //            cboGroupOfficer.SelectedValue = nonsolidaritygroup.nGroupOfficer;
        //        }
        //        if (nonsolidaritygroup.nSetMeetingDate != null)
        //        {
        //            chkSetMeetingDate.Checked = nonsolidaritygroup.nSetMeetingDate.Value;
        //        }
        //        if (nonsolidaritygroup.nMeetingDate != null)
        //        {
        //            cboMeetingDate.Text = nonsolidaritygroup.nMeetingDate;
        //        }
        //        if (nonsolidaritygroup.BranchId != null)
        //        {
        //            cboBranch.SelectedValue = nonsolidaritygroup.BranchId;
        //        }
        //        if (nonsolidaritygroup.nPhoto != null)
        //        {
        //            pbPhoto.ImageLocation = nonsolidaritygroup.nPhoto;
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
                btnUploadNonSolidarityGroupPhoto.Enabled = false;
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
        private void btnAddNewNonSolidarityGroupMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddPersonForm anpf = new AddPersonForm(connection) { Owner = this };
                anpf.ShowDialog();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnRemoveNonSolidarityGroupMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnSetMemberasGroupLeader_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUpdateNonSolidarityGroupMeetingDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        #endregion "Private Methods"

        

        

         


    }
}
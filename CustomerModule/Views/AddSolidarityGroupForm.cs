using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using SearchModule.Views;

namespace CustomerModule.Views
{
    public partial class AddSolidarityGroupForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddSolidarityGroupForm(string Conn)
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
        private void btnSearchExistingPersons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SearchPersonClientForm spcf = new SearchPersonClientForm(connection) { Owner = this };
                spcf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnAddNewSolidarityGroupMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void btnRemoveSolidarityGroupMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnViewSolidarityGroupMemberDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        private void AddNewSolidarityGroupForm_Load(object sender, EventArgs e)
        {
            try
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                //var _branchesquery = from af in db.gl_Branches
                //                     where af.Isdeleted == false
                //                     select af;
                //List<gl_Branches> _Branches = _branchesquery.ToList();
                //cboBranch.DataSource = _Branches;
                //cboBranch.ValueMember = "Id";
                //cboBranch.DisplayMember = "BranchName";
                //cboBranch.SelectedIndex = -1;

                //var _UsersQuery = from us in db.sec_Users
                //                  select us;
                //List<sec_Users> _Users = _UsersQuery.ToList();

                //cboGroupOfficer.DataSource = _Users;
                //cboGroupOfficer.DisplayMember = "FullNames";
                //cboGroupOfficer.ValueMember = "UserName";               
                //cboGroupOfficer.SelectedIndex = -1;

                cboMeetingDate.DataSource = GetDayNames();
                cboMeetingDate.SelectedIndex = -1;

                chkSetMeetingDate.Checked = false;
                cboMeetingDate.Enabled = false;
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

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsSolidarityGroupValid())
            {
                try
                {
                    //gl_SolidarityGroup solidarityGroup = new gl_SolidarityGroup();

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

                    //if (!db.gl_SolidarityGroup.Any(i => i.Description == solidarityGroup.Description))
                    //{
                    //    db.gl_SolidarityGroup.AddObject(solidarityGroup);
                    //    db.SaveChanges();
                    //}

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
                errorProvider1.SetError(txtGroupName, "Name cannot be null!");
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

        #endregion "Private Methods"

      

    }
}
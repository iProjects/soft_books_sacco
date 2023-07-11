using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace CustomerModule.Views
{
    public partial class AddNonSolidarityGroupForm : Form
    {
        //Repository rep;
        SBSaccoDBEntities db;
        string connection;

        #region "Private Fields"
        Repository rep;
        #endregion "Private Fields"

        #region "Constructor"
        public AddNonSolidarityGroupForm(string Conn)
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (IsNonSolidarityGroupValid())
            {
                try
                {
                    //gl_NonSolidarityGroup nonsolidaritygroup = new gl_NonSolidarityGroup();

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
                    //    nonsolidaritygroup.nPhoto = pbPhoto.ImageLocation.ToString().Trim();
                    //}

                    //if (!db.gl_NonSolidarityGroup.Any(i => i.Description == nonsolidaritygroup.Description))
                    //{
                    //    db.gl_NonSolidarityGroup.AddObject(nonsolidaritygroup);
                    //    db.SaveChanges();
                    //}

                    //NonSolidarityGroupsListForm f = (NonSolidarityGroupsListForm)this.Owner;
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
        private void AddNewNonSolidarityGroupForm_Load(object sender, EventArgs e)
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
using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;

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

                for (int i = 0; i < codecs.Count(); i++)
                {
                    var temp1 = codecs[0];
                    var temp2 = codecs[1];
                    var temp3 = codecs[2];
                    var temp4 = codecs[3];
                    var temp5 = codecs[4];

                    codecs[0] = temp5;
                    codecs[1] = temp2;
                    codecs[2] = temp1;
                    codecs[3] = temp3;
                    codecs[4] = temp4;
                }

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

            errorProvider.Clear();
            if (IsNonSolidarityGroupValid())
            {
                try
                {
                    tbl_non_solidarity_groups nonsolidaritygroup = new tbl_non_solidarity_groups();

                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        nonsolidaritygroup.name = Utils.ConvertFirstLetterToUpper(txtName.Text.Trim());
                    }
                    nonsolidaritygroup.establishment_date = dtpEstablishmentDate.Value.ToString("dd-MM-yyyy HH:mm:ss tt");
                    if (cboGroupOfficer.SelectedIndex != -1)
                    {
                        nonsolidaritygroup.group_officer = cboGroupOfficer.SelectedValue.ToString();
                    }
                    if (chkSetMeetingDate.Checked)
                    {
                        if (cboMeetingDate.SelectedIndex != -1)
                        {
                            nonsolidaritygroup.meeting_day = cboMeetingDate.Text;
                        }
                    }
                    if (cboBranch.SelectedIndex != -1)
                    {
                        nonsolidaritygroup.branch_id = cboBranch.SelectedValue.ToString();
                    }
                    if (pbPhoto.ImageLocation != null)
                    {
                        nonsolidaritygroup.photo = pbPhoto.ImageLocation.ToString().Trim();
                    }
                    nonsolidaritygroup.status = "active";
                    nonsolidaritygroup.created_date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                    if (!db.tbl_non_solidarity_groups.Any(i => i.name == nonsolidaritygroup.name))
                    {
                        db.tbl_non_solidarity_groups.AddObject(nonsolidaritygroup);
                        db.SaveChanges();
                    }

                    NonSolidarityGroupsListForm f = (NonSolidarityGroupsListForm)this.Owner;
                    f.RefreshGrid(1);
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

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider.SetError(txtName, "Name cannot be null!");
                noerror = false;
            }
            if (cboGroupOfficer.SelectedIndex == -1)
            {
                errorProvider.SetError(cboGroupOfficer, "Select Group Officer!");
                noerror = false;
            }
            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider.SetError(cboBranch, "Select Branch!");
                noerror = false;
            }
            if (chkSetMeetingDate.Checked && cboMeetingDate.SelectedIndex == -1)
            {
                errorProvider.SetError(cboMeetingDate, "Select Meeting Day!");
                noerror = false;
            }
            return noerror;
        }

        #endregion "Validation"
        private void AddNewNonSolidarityGroupForm_Load(object sender, EventArgs e)
        {
            try
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                var _branchesquery = from af in db.Branches
                                     where af.deleted == false
                                     select af;
                List<Branch> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "id";
                cboBranch.DisplayMember = "name";
                //cboBranch.SelectedIndex = -1;

                var _UsersQuery = from us in db.spUsers
                                  select us;
                List<spUser> _Users = _UsersQuery.ToList();

                cboGroupOfficer.DataSource = _Users;
                cboGroupOfficer.ValueMember = "Id";
                cboGroupOfficer.DisplayMember = "UserName";
                //cboGroupOfficer.SelectedIndex = -1;

                cboMeetingDate.DataSource = GetDayNames();
                //cboMeetingDate.SelectedIndex = -1;

                chkSetMeetingDate.Checked = false;
                cboMeetingDate.Enabled = false;

                string default_image = "defaultphoto.jpg";

                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string image_path = Path.Combine(base_directory, "Resources");
                string image_file_path = Path.Combine(image_path, default_image);

                FileInfo image_file = new FileInfo(image_file_path);

                if (image_file.Exists)
                {
                    string imagepath = image_file.FullName;
                    pbPhoto.ImageLocation = imagepath;
                    pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }

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
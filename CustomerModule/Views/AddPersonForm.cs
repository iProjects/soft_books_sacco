using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SearchModule.Views;
using System.IO;

namespace CustomerModule.Views
{
    public partial class AddPersonForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddPersonForm(string Conn)
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
        private void AddPersonForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtFirstName.Focus();
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                lblNoofYears.Text = string.Empty;
                txtLoanCycle.Text = "0";
                txtCitizenShip.Text = RegionAndLanguageHelper.GetMachineCurrentLocation();
                txtCitizenShip.Text = "Kenya";
                dtpDateofBirth.Value = DateTime.Now.AddYears(-18);

                //Gender Combox
                var gender = new BindingList<KeyValuePair<string, string>>();
                gender.Add(new KeyValuePair<string, string>("M", "Male"));
                gender.Add(new KeyValuePair<string, string>("F", "Female"));
                cboGender.DataSource = gender;
                cboGender.ValueMember = "Key";
                cboGender.DisplayMember = "Value";
                //cboGender.SelectedIndex = -1;

                List<ActivityModel> _EconomicActivities = rep.GetEconomicActivitiesList();
                cboEconomicActivity.DataSource = _EconomicActivities;
                cboEconomicActivity.ValueMember = "activityid";
                cboEconomicActivity.DisplayMember = "name";
                //cboEconomicActivity.SelectedIndex = -1;

                var _branchesquery = from br in rep.GetNonDeletedBranches()
                                     select br;
                List<BranchModel> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                //cboBranch.SelectedIndex = -1;

                //var _haprovincesquery = from ds in rep.GetNonDeletedProvinces()
                //                        select ds;
                //List<ProvinceModel> _haProvinces = _haprovincesquery.ToList();
                //cboHAProvince.DataSource = _haProvinces;
                //cboHAProvince.ValueMember = "provinceid";
                //cboHAProvince.DisplayMember = "name";
                //cboHAProvince.SelectedIndex = -1;

                //var _baprovincesquery = from ds in rep.GetNonDeletedProvinces()
                //                        select ds;
                //List<ProvinceModel> _baProvinces = _baprovincesquery.ToList();
                //cboBAProvince.DataSource = _baProvinces;
                //cboBAProvince.ValueMember = "provinceid";
                //cboBAProvince.DisplayMember = "name";
                //cboBAProvince.SelectedIndex = -1;

                //lblCustomFieldsName.Text = string.Empty;
                //lblCustomFieldsDescription.Text = string.Empty;
                //chkattMandatory.Checked = false;
                //chkattUnique.Checked = false;

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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (IsPersonValid())
            {
                try
                {
                    Tier _Tier = new Tier();
                    _Tier.client_type_code = "I";
                    if (!string.IsNullOrEmpty(txtphone_no.Text))
                    {
                        _Tier.personal_phone = txtphone_no.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtemail.Text))
                    {
                        _Tier.email = txtemail.Text.Trim();
                    }
                    _Tier.active = true;
                    _Tier.status = rep.GetDefaultStatus();
                    _Tier.scoring = 0.99;
                    _Tier.email = txtemail.Text;
                    _Tier.creation_date = DateTime.Now;
                    _Tier.created_date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");
                    int cycle;
                    if (!string.IsNullOrEmpty(txtLoanCycle.Text) && int.TryParse(txtLoanCycle.Text, out cycle))
                    {
                        _Tier.loan_cycle = int.Parse(txtLoanCycle.Text.Trim());
                    }
                    if (cboBranch.SelectedIndex != -1)
                    {
                        _Tier.branch_id = int.Parse(cboBranch.SelectedValue.ToString());
                    }

                    if (!db.Tiers.Any(i => i.email == _Tier.email))
                    {
                        db.Tiers.AddObject(_Tier);
                        db.SaveChanges();
                    }

                    Person _Person = new Person();
                    _Person.id = _Tier.id;
                    if (!string.IsNullOrEmpty(txtFirstName.Text))
                    {
                        _Person.first_name = Utils.ConvertFirstLetterToUpper(txtFirstName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtLastName.Text))
                    {
                        _Person.last_name = Utils.ConvertFirstLetterToUpper(txtLastName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtFatherName.Text))
                    {
                        _Person.father_name = Utils.ConvertFirstLetterToUpper(txtFatherName.Text.Trim());
                    }
                    _Person.birth_date = dtpDateofBirth.Value;
                    if (cboGender.SelectedIndex != -1)
                    {
                        _Person.sex = cboGender.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtIDNo.Text))
                    {
                        _Person.identification_data = txtIDNo.Text.Trim();
                    }

                    if (cboEconomicActivity.SelectedIndex != -1)
                    {
                        _Person.activity_id = int.Parse(cboEconomicActivity.SelectedValue.ToString());
                    }

                    if (!string.IsNullOrEmpty(txtPlaceofBirth.Text))
                    {
                        _Person.birth_place = Utils.ConvertFirstLetterToUpper(txtPlaceofBirth.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtCitizenShip.Text))
                    {
                        _Person.nationality = Utils.ConvertFirstLetterToUpper(txtCitizenShip.Text.Trim());
                    }
                    _Person.household_head = chkHeadofHouseHold.Checked;
                    if (pbPhoto.ImageLocation != null)
                    {
                        _Person.image_path = pbPhoto.ImageLocation.ToString();
                    }
                    _Person.handicapped = chkdisability.Checked;
                    _Person.created_date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");
                    _Person.status = "active";
                    _Person.deleted = false;

                    if (!db.Persons.Any(i => i.first_name == _Person.first_name && i.last_name == _Person.last_name))
                    {
                        db.Persons.AddObject(_Person);
                        db.SaveChanges();
                    }

                    PersonsListForm f = (PersonsListForm)this.Owner;
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
        private bool IsPersonValid()
        {
            bool noerror = true;
            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, "First Name cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Last Name cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                errorProvider.SetError(txtFatherName, "Father Name cannot be null!");
                noerror = false;
            }
            if (dtpDateofBirth.Value == null)
            {
                errorProvider.SetError(txtFatherName, "Father Name cannot be null!");
                noerror = false;
            }
            else
            {
                DateTime dob = dtpDateofBirth.Value;
                int age = DateTime.Now.Year - dob.Year;
                if (age < 18)
                {
                    errorProvider.SetError(dtpDateofBirth, "Must be 18 years and above!");
                    noerror = false;
                }
            }
            if (cboGender.SelectedIndex == -1)
            {
                errorProvider.SetError(cboGender, "Select Gender!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtIDNo.Text))
            {
                errorProvider.SetError(txtIDNo, "Id No cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                errorProvider.SetError(txtemail, "Email cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtphone_no.Text))
            {
                errorProvider.SetError(txtphone_no, "Phone No cannot be null!");
                noerror = false;
            }
            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider.SetError(cboBranch, "Select Branch!");
                noerror = false;
            }
            if (cboEconomicActivity.SelectedIndex == -1)
            {
                errorProvider.SetError(cboEconomicActivity, "Select Economic Activity!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtPlaceofBirth.Text))
            {
                errorProvider.SetError(txtPlaceofBirth, "Place of Birth cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtCitizenShip.Text))
            {
                errorProvider.SetError(txtCitizenShip, "CitizenShip cannot be null!");
                noerror = false;
            }
            return noerror;
        }
        #endregion "Validation"
        private void dtpDateofBirth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int datetoday = DateTime.Today.Year;
                int selecteddate = dtpDateofBirth.Value.Year;
                int noofyrs = datetoday - selecteddate;
                lblNoofYears.Text = noofyrs.ToString() + "  Years";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
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

                //codecs = codecs.OrderByDescending(r => r.CodecName).ToArray();
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

        private void cboHAProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboHAProvince.SelectedIndex != -1)
            //{
            //    try
            //    {
            //        ProvinceModel _Province = (ProvinceModel)cboHAProvince.SelectedItem;
            //        var _hadistrictsquery = from ds in rep.GetNonDeletedDistricts(_Province.provinceid)
            //                                select ds;
            //        List<DistrictModel> _haDistricts = _hadistrictsquery.ToList();
            //        cboHADistrict.DataSource = _haDistricts;
            //        cboHADistrict.ValueMember = "districtid";
            //        cboHADistrict.DisplayMember = "name";
            //        cboHADistrict.SelectedIndex = -1;
            //    }
            //    catch (Exception ex)
            //    {
            //        Utils.ShowError(ex);
            //    }
            //}
        }
        private void cboBAProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboBAProvince.SelectedIndex != -1)
            //{
            //    try
            //    {
            //        ProvinceModel _Province = (ProvinceModel)cboBAProvince.SelectedItem;
            //        var _badistrictsquery = from ds in rep.GetNonDeletedDistricts(_Province.provinceid)
            //                                select ds;
            //        List<DistrictModel> _baDistricts = _badistrictsquery.ToList();
            //        cboBADistrict.DataSource = _baDistricts;
            //        cboBADistrict.ValueMember = "districtid";
            //        cboBADistrict.DisplayMember = "name";
            //        cboBADistrict.SelectedIndex = -1;
            //    }
            //    catch (Exception ex)
            //    {
            //        Utils.ShowError(ex);
            //    }
            //}
        }
        #endregion "Private Methods"







    }
}
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (IsPersonValid())
            {
                try
                {
                    ClientModel _clientModel = new ClientModel();
                    _clientModel.client_type_code = "I";
                    if (!string.IsNullOrEmpty(txtFirstName.Text))
                    {
                        _clientModel.first_name = Utils.ConvertFirstLetterToUpper(txtFirstName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtLastName.Text))
                    {
                        _clientModel.last_name = Utils.ConvertFirstLetterToUpper(txtLastName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtFatherName.Text))
                    {
                        _clientModel.father_name = Utils.ConvertFirstLetterToUpper(txtFatherName.Text.Trim());
                    }
                    _clientModel.birth_date = dtpDateofBirth.Value;
                    if (cboGender.SelectedIndex != -1)
                    {
                        _clientModel.sex = cboGender.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtIDNo.Text))
                    {
                        _clientModel.identification_data = txtIDNo.Text.Trim();
                    }
                    if (cboBranch.SelectedIndex != -1)
                    {
                        _clientModel.branch_id = int.Parse(cboBranch.SelectedValue.ToString());
                    }
                    if (cboEconomicActivity.SelectedIndex != -1)
                    {
                        _clientModel.activity_id = int.Parse(cboEconomicActivity.SelectedValue.ToString());
                    }
                    int cycle;
                    if (!string.IsNullOrEmpty(txtLoanCycle.Text) && int.TryParse(txtLoanCycle.Text, out cycle))
                    {
                        _clientModel.loan_cycle = int.Parse(txtLoanCycle.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtPlaceofBirth.Text))
                    {
                        _clientModel.birth_place = Utils.ConvertFirstLetterToUpper(txtPlaceofBirth.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtCitizenShip.Text))
                    {
                        _clientModel.nationality = Utils.ConvertFirstLetterToUpper(txtCitizenShip.Text.Trim());
                    }
                    _clientModel.household_head = chkHeadofHouseHold.Checked;
                    if (pbPhoto.ImageLocation != null)
                    {
                        _clientModel.image_path = pbPhoto.ImageLocation.ToString();
                    }
                    _clientModel.status = rep.GetDefaultStatus();
                    _clientModel.active = false;
                    _clientModel.bad_client = false;
                    _clientModel.scoring = 0.599;
                    _clientModel.creation_date = DateTime.Now;

                    #region "Home Address"
                    if (cboHAProvince.SelectedIndex != -1)
                    {
                        _clientModel.province_id = int.Parse(cboHAProvince.SelectedValue.ToString());
                    }
                    if (cboHADistrict.SelectedIndex != -1)
                    {
                        _clientModel.district_id = int.Parse(cboHADistrict.SelectedValue.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtHACity.Text))
                    {
                        _clientModel.city = txtHACity.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtHAdress.Text))
                    {
                        _clientModel.address = txtHAdress.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtHAZipCode.Text))
                    {
                        _clientModel.zipCode = txtHAZipCode.Text.Trim();
                    }
                    if (cboHAHomeType.SelectedIndex != -1)
                    {
                        _clientModel.home_type = cboHAHomeType.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtHAHomePhone.Text))
                    {
                        _clientModel.home_phone = txtHAHomePhone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtHACellPhone.Text))
                    {
                        _clientModel.personal_phone = txtHACellPhone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtHAEmail.Text))
                    {
                        _clientModel.e_mail = txtHAEmail.Text.Trim();
                    }
                    #endregion "Home Address"

                    #region "Business Address"
                    if (cboBAProvince.SelectedIndex != -1)
                    {
                        _clientModel.secondary_province_id = int.Parse(cboBAProvince.SelectedValue.ToString());
                    }
                    if (cboBADistrict.SelectedIndex != -1)
                    {
                        _clientModel.secondary_district_id = int.Parse(cboBADistrict.SelectedValue.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtBACity.Text))
                    {
                        _clientModel.secondary_city = txtBACity.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBAAddress.Text))
                    {
                        _clientModel.secondary_address = txtBAAddress.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBAZipCode.Text))
                    {
                        _clientModel.secondary_zipCode = txtBAZipCode.Text.Trim();
                    }
                    if (cboBAHomeType.SelectedIndex != -1)
                    {
                        _clientModel.secondary_homeType = cboBAHomeType.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtBAHomePhone.Text))
                    {
                        _clientModel.secondary_home_phone = txtBAHomePhone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBACellPhone.Text))
                    {
                        _clientModel.secondary_personal_phone = txtBACellPhone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBAEmail.Text))
                    {
                        _clientModel.secondary_e_mail = txtBAEmail.Text.Trim();
                    }
                    #endregion "Business Address"

                    rep.AddNewPerson(_clientModel);

                    PersonsListForm f = (PersonsListForm)this.Owner;
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
        private bool IsPersonValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtFirstName, "First Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLastName, "Last Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtFatherName, "Father Name cannot be null!");
                return false;
            }
            if (cboGender.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboGender, "Select Gender!");
                return false;
            }
            if (string.IsNullOrEmpty(txtIDNo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtIDNo, "Id No cannot be null!");
                return false;
            }
            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboBranch, "Select Branch!");
                return false;
            }
            if (cboEconomicActivity.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboEconomicActivity, "Select Economic Activity!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPlaceofBirth.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPlaceofBirth, "Place of Birth cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCitizenShip.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCitizenShip, "CitizenShip cannot be null!");
                return false;
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
        private void AddPersonForm_Load(object sender, EventArgs e)
        {
            try
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                lblNoofYears.Text = string.Empty;
                txtCitizenShip.Text = RegionAndLanguageHelper.GetMachineCurrentLocation();

                //Gender Combox
                var gender = new BindingList<KeyValuePair<string, string>>();
                gender.Add(new KeyValuePair<string, string>("M", "Male"));
                gender.Add(new KeyValuePair<string, string>("F", "Female"));
                cboGender.DataSource = gender;
                cboGender.ValueMember = "Key";
                cboGender.DisplayMember = "Value";
                cboGender.SelectedIndex = -1;

                List<ActivityModel> _EconomicActivities = rep.GetEconomicActivitiesList();
                cboEconomicActivity.DataSource = _EconomicActivities;
                cboEconomicActivity.ValueMember = "activityid";
                cboEconomicActivity.DisplayMember = "name";
                cboEconomicActivity.SelectedIndex = -1;

                var _branchesquery = from br in rep.GetNonDeletedBranches()
                                     select br;
                List<BranchModel> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                cboBranch.SelectedIndex = -1;

                var _haprovincesquery = from ds in rep.GetNonDeletedProvinces()
                                        select ds;
                List<ProvinceModel> _haProvinces = _haprovincesquery.ToList();
                cboHAProvince.DataSource = _haProvinces;
                cboHAProvince.ValueMember = "provinceid";
                cboHAProvince.DisplayMember = "name";
                cboHAProvince.SelectedIndex = -1;

                var _baprovincesquery = from ds in rep.GetNonDeletedProvinces()
                                        select ds;
                List<ProvinceModel> _baProvinces = _baprovincesquery.ToList();
                cboBAProvince.DataSource = _baProvinces;
                cboBAProvince.ValueMember = "provinceid";
                cboBAProvince.DisplayMember = "name";
                cboBAProvince.SelectedIndex = -1;

                lblCustomFieldsName.Text = string.Empty;
                lblCustomFieldsDescription.Text = string.Empty;
                chkattMandatory.Checked = false;
                chkattUnique.Checked = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboHAProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHAProvince.SelectedIndex != -1)
            {
                try
                {
                    ProvinceModel _Province = (ProvinceModel)cboHAProvince.SelectedItem;
                    var _hadistrictsquery = from ds in rep.GetNonDeletedDistricts(_Province.provinceid)
                                            select ds;
                    List<DistrictModel> _haDistricts = _hadistrictsquery.ToList();
                    cboHADistrict.DataSource = _haDistricts;
                    cboHADistrict.ValueMember = "districtid";
                    cboHADistrict.DisplayMember = "name";
                    cboHADistrict.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboBAProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBAProvince.SelectedIndex != -1)
            {
                try
                {
                    ProvinceModel _Province = (ProvinceModel)cboBAProvince.SelectedItem;
                    var _badistrictsquery = from ds in rep.GetNonDeletedDistricts(_Province.provinceid)
                                            select ds;
                    List<DistrictModel> _baDistricts = _badistrictsquery.ToList();
                    cboBADistrict.DataSource = _baDistricts;
                    cboBADistrict.ValueMember = "districtid";
                    cboBADistrict.DisplayMember = "name";
                    cboBADistrict.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #endregion "Private Methods"







    }
}
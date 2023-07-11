using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using CommonLib;
using DAL;
using ReportsModule.Viewer;
using SearchModule.Views;

namespace CustomerModule.Views
{
    public partial class EditPersonForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user_id;
        ClientModel _clientModel;
        CurrencyModel _currencymodel;
        BranchModel _branchmodel;
        LoanPackageModel _loanpackage;
        SavingProductModel _savingsproduct;
        CollateralProduct _collateralproduct;
        ClientLoanContractModel _loancontract;
        ClientSavingContractModel _savingscontract;
        List<ClientCustomizableFieldsModel> _clientcustomfields;
        List<ClientCustomizableFieldsModel> _loancontractcustomfields;
        List<ClientCustomizableFieldsModel> _savingcontractcustomfields;
        List<InstallmentsModel> _installments;
        List<ClientContractCollateralsModel> _contractcollaterals;
        List<LoanGuarantorsModel> _loanguarantors;
        List<CreditEntryFeesModel> _credit_entryfees;
        List<ClientSavingContractModel> _savingscontractslist;
        #endregion "Private Fields"

        #region "Constructor"
        public EditPersonForm(ClientModel clientModel, int _user, string Conn)
        {

            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _clientModel = clientModel;

            user_id = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        #region "Controls"
        private void EditPersonForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadControls();

                InitializeControls();

                GenerateMenuItems();

                LoadClientLoanContracts();

                LoadClientSavingsContracts();

                InitializeContractsDefaults();

                LoadCustomizableFields();

                ClearLoanDetailsControls();

                ClearSavingDetailsControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsPersonValid())
            {
                try
                {
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
                        _clientModel.loan_cycle = int.Parse(txtLoanCycle.Text);
                    }
                    if (!string.IsNullOrEmpty(txtPlaceofBirth.Text.Trim()))
                    {
                        _clientModel.birth_place = Utils.ConvertFirstLetterToUpper(txtPlaceofBirth.Text);
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
                    if (cboHADistrict.SelectedIndex != -1)
                    {
                        _clientModel.district_id = int.Parse(cboHADistrict.SelectedValue.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtHACity.Text))
                    {
                        _clientModel.city = txtHACity.Text;
                    }
                    if (!string.IsNullOrEmpty(txtHAdress.Text))
                    {
                        _clientModel.address = txtHAdress.Text;
                    }
                    if (!string.IsNullOrEmpty(txtHAZipCode.Text))
                    {
                        _clientModel.zipCode = txtHAZipCode.Text;
                    }
                    if (cboHAHomeType.SelectedIndex != -1)
                    {
                        _clientModel.home_type = cboHAHomeType.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtHAHomePhone.Text))
                    {
                        _clientModel.home_phone = txtHAHomePhone.Text;
                    }
                    if (!string.IsNullOrEmpty(txtHACellPhone.Text))
                    {
                        _clientModel.personal_phone = txtHACellPhone.Text;
                    }
                    if (!string.IsNullOrEmpty(txtHAEmail.Text))
                    {
                        _clientModel.e_mail = txtHAEmail.Text;
                    }

                    rep.UpdatePerson(_clientModel);

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
        private void dtpDisbursementDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblSelectedDisbursementDayName.Text = dtpDisbursementDate.Value.ToString("dddd");
                dtpPreferredFirstInstallmentDate.Value = dtpDisbursementDate.Value.AddMonths(1);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dtpPreferredFirstInstallmentDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                lblSelectedFirstInstallmentDayName.Text = dtpPreferredFirstInstallmentDate.Value.ToString("dddd");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
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
        private void btnPreviewInstallments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsInstallmentDetailsValid())
            {
                try
                {
                    CreateLoanContractsInstallments();
                    //RefreshLoanContractsInstallmentsGrid();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDisburse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_loancontract != null)
                {
                    if (_loancontract.status == 2)
                    {
                        _loancontract.status = 5;

                        rep.UpdateLoanContractOnDisbursement(_loancontract);

                        RefreshLoanContractsGrid();

                        RefreshSavingsContractsLoanGrid();

                        if (!tabControlClients.Contains(tabPageLoanRepayment))
                        {
                            tabControlClients.TabPages.Add(tabPageLoanRepayment);
                        }
                        tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageLoanRepayment)];
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSaveLoanDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsLoanDetailsValid() && IsInstallmentDetailsValid())
            {
                try
                {
                    CreateLoanContractsInstallments();
                    //RefreshLoanContractsInstallmentsGrid();

                    cboLoanStatus.SelectedValue = 1;

                    if (!tabControlClients.Contains(tabPageAdvancedSettings))
                    {
                        tabControlClients.TabPages.Add(tabPageAdvancedSettings);
                    }
                    tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageAdvancedSettings)];
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnAddLoanGuarantor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnLoanLinkSavingsDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsLoanLinkSavingsValid())
            {
                try
                {
                    _savingscontract = (ClientSavingContractModel)cboLoanLinkSavings.SelectedItem;

                    ClearSavingDetailsControls();

                    PopulateSavingsDetailsfromSavingsContract(_savingscontract);

                    if (!tabControlClients.Contains(tabPageSavingsDetails))
                    {
                        tabControlClients.TabPages.Add(tabPageSavingsDetails);
                    }
                    tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageSavingsDetails)];
                    tabControlSavingsDetails.SelectedTab = tabControlSavingsDetails.TabPages[tabControlSavingsDetails.TabPages.IndexOf(tabPageFeesandLimits)];

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnSavingsContractFirstDeposit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_savingscontract != null && _currencymodel != null)
                {
                    SavingsFirstDepositForm sfdf = new SavingsFirstDepositForm(_savingscontract, _currencymodel, user_id, connection) { Owner = this };
                    sfdf.ShowDialog();

                    btnSavingsContractCloseAccount.Visible = true;
                    btnSavingsContractFirstDeposit.Visible = false;
                    btnSavingsContractSaveAccount.Visible = false;
                    btnSavingsContractCloseAccount.Location = btnSavingsContractSaveAccount.Location;

                    if (!tabControlClients.Contains(tabPageSavingsDetails))
                    {
                        tabControlClients.TabPages.Add(tabPageSavingsDetails);
                    }
                    tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageSavingsDetails)];
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSaveAdvancedSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsLoanAdvancedSettingsValid())
            {
                try
                {
                    if (string.IsNullOrEmpty(txtLoanContractCode.Text))
                    {
                        if (_loanpackage != null)
                        {
                            _loancontract = new ClientLoanContractModel();

                            #region "project"
                            _loancontract.tiers_id = _clientModel.tierid;
                            if (cboLoanStatus.SelectedIndex != -1)
                            {
                                _loancontract.project_status = short.Parse(cboLoanStatus.SelectedValue.ToString());
                            }
                            _loancontract.project_name = _clientModel.first_name.Trim() + "  " + _clientModel.last_name.Trim();
                            if (_clientModel.father_name != null)
                            {
                                _loancontract.project_name += "  " + _clientModel.father_name.Trim();
                            }
                            _loancontract.project_code = _branchmodel.code.Trim() + "/" + DateTime.Now.ToString("yy") + "/" + _clientModel.loan_cycle.ToString() + "/" + _clientModel.tierid.ToString();
                            _loancontract.aim = "NotSet";
                            _loancontract.project_begin_date = DateTime.Now;
                            _loancontract.abilities = "NotSet";
                            _loancontract.experience = "NotSet";
                            _loancontract.market = "NotSet";
                            _loancontract.concurrence = "NotSet";
                            _loancontract.purpose = "NotSet";
                            _loancontract.corporate_name = rep.SettingLookup("COMPANYNAME").Trim();
                            _loancontract.corporate_juridicStatus = "NotSet";
                            _loancontract.corporate_FiscalStatus = "NotSet";
                            _loancontract.corporate_siret = "NotSet";
                            _loancontract.corporate_CA = 0;
                            _loancontract.corporate_nbOfJobs = 0;
                            _loancontract.corporate_financialPlanType = "NotSet";
                            _loancontract.corporateFinancialPlanAmount = 0;
                            _loancontract.corporate_financialPlanTotalAmount = 0;
                            if (!string.IsNullOrEmpty(txtHAdress.Text))
                            {
                                _loancontract.address = txtHAdress.Text.Trim();
                            }
                            if (!string.IsNullOrEmpty(txtHACity.Text))
                            {
                                _loancontract.city = txtHACity.Text.Trim();
                            }
                            if (!string.IsNullOrEmpty(txtHAZipCode.Text))
                            {
                                _loancontract.zipCode = txtHAZipCode.Text.Trim();
                            }
                            if (cboHADistrict.SelectedIndex != -1)
                            {
                                _loancontract.district_id = int.Parse(cboHADistrict.SelectedValue.ToString());
                            }
                            if (!string.IsNullOrEmpty(txtHAHomePhone.Text))
                            {
                                _loancontract.home_phone = txtHAHomePhone.Text.Trim();
                            }
                            if (!string.IsNullOrEmpty(txtHACellPhone.Text))
                            {
                                _loancontract.personalPhone = txtHACellPhone.Text.Trim();
                            }
                            if (!string.IsNullOrEmpty(txtHAEmail.Text))
                            {
                                _loancontract.Email = txtHAEmail.Text.Trim();
                            }
                            if (cboHAHomeType.SelectedIndex != -1)
                            {
                                _loancontract.hometype = cboHAHomeType.SelectedValue.ToString();
                            }
                            _loancontract.corporate_registre = "NotSet";
                            _loancontract.projectid = rep.AddNewLoanProject(_loancontract);
                            #endregion "project"

                            #region "contract"
                            _loancontract.branch_code = _branchmodel.code.Trim();
                            _loancontract.creation_date = DateTime.Now;
                            _loancontract.start_date = dtpPreferredFirstInstallmentDate.Value;
                            _loancontract.close_date = dtpPreferredFirstInstallmentDate.Value.AddDays(double.Parse(txtNoofInstallments.Text.Trim()));
                            _loancontract.closed = false;
                            _loancontract.project_id = _loancontract.projectid;
                            if (cboLoanStatus.SelectedIndex != -1)
                            {
                                _loancontract.status = short.Parse(cboLoanStatus.SelectedValue.ToString());
                            }
                            _loancontract.credit_commitee_date = dtpCreditCommiteeDate.Value;
                            if (!string.IsNullOrEmpty(txtCreditComitteComment.Text))
                            {
                                _loancontract.credit_commitee_comment = txtCreditComitteComment.Text.Trim();
                            }
                            if (!string.IsNullOrEmpty(txtCreditCommitteCode.Text))
                            {
                                _loancontract.credit_commitee_code = txtCreditCommitteCode.Text.Trim();
                            }
                            _loancontract.align_disbursed_date = dtpDisbursementDate.Value;
                            if (!string.IsNullOrEmpty(txtLoanPurpose.Text))
                            {
                                _loancontract.loan_purpose = txtLoanPurpose.Text.Trim();
                            }
                            if (!string.IsNullOrEmpty(txtAdvancedSettingsComment.Text))
                            {
                                _loancontract.comments = txtAdvancedSettingsComment.Text.Trim();
                            }
                            if (cboLoanEconomicActivity.SelectedIndex != -1)
                            {
                                _loancontract.activity_id = int.Parse(cboLoanEconomicActivity.SelectedValue.ToString());
                            }
                            _loancontract.first_installment_date = dtpPreferredFirstInstallmentDate.Value;
                            _loancontract.contract_code = _loanpackage.code.Trim();

                            _loancontract.contractid = rep.AddNewLoanContract(_loancontract);

                            _clientModel.loan_cycle += 1;

                            rep.UpdateClientLoanCycle(_clientModel);

                            _loancontract.contract_code += "/" +
                                _clientModel.loan_cycle.ToString() + "/" +
                                _clientModel.tierid.ToString() + "/" +
                                DateTime.Now.ToString("yy") + "/" +
                                _loancontract.contractid.ToString();

                            rep.UpdateLoanContractCode(_loancontract);

                            txtLoanContractCode.Text = _loancontract.contract_code.Trim();
                            #endregion "contract"

                            #region "credit"
                            _loancontract.package_id = _loanpackage.packageid;
                            _loancontract.creditid = _loancontract.contractid;
                            if (!string.IsNullOrEmpty(txtLoanAmount.Text))
                            {
                                _loancontract.amount = decimal.Parse(txtLoanAmount.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtInterestRatePerPeriod.Text))
                            {
                                _loancontract.interest_rate = decimal.Parse(txtInterestRatePerPeriod.Text.Trim());
                            }
                            if (cboInstallmentTypes.SelectedIndex != -1)
                            {
                                _loancontract.installment_type = int.Parse(cboInstallmentTypes.SelectedValue.ToString());
                            }
                            if (!string.IsNullOrEmpty(txtNoofInstallments.Text))
                            {
                                _loancontract.nb_of_installment = int.Parse(txtNoofInstallments.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtNoofInstallments.Text))
                            {
                                _loancontract.anticipated_total_repayment_penalties = double.Parse(txtEarlyFeesATR.Text.Trim());
                            }
                            _loancontract.disbursed = false;
                            if (cboLoanOfficer.SelectedIndex != -1)
                            {
                                _loancontract.loanofficer_id = int.Parse(cboLoanOfficer.SelectedValue.ToString());
                            }
                            if (!string.IsNullOrEmpty(txtNoofInstallments.Text))
                            {
                                _loancontract.anticipated_total_repayment_penalties = double.Parse(txtEarlyFeesATR.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtGracePeriod.Text))
                            {
                                _loancontract.grace_period = int.Parse(txtGracePeriod.Text.Trim());
                            }
                            _loancontract.written_off = false;
                            _loancontract.rescheduled = false;
                            _loancontract.bad_loan = false;
                            if (!string.IsNullOrEmpty(txtOverduePrincipal.Text))
                            {
                                _loancontract.non_repayment_penalties_based_on_overdue_principal = double.Parse(txtOverduePrincipal.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtTotalLoanAmount.Text))
                            {
                                _loancontract.non_repayment_penalties_based_on_initial_amount = double.Parse(txtTotalLoanAmount.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtOLB.Text))
                            {
                                _loancontract.non_repayment_penalties_based_on_olb = double.Parse(txtOLB.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtOverDueInterest.Text))
                            {
                                _loancontract.non_repayment_penalties_based_on_overdue_interest = double.Parse(txtOverDueInterest.Text.Trim());
                            }
                            if (cboFundingLine.SelectedIndex != -1)
                            {
                                _loancontract.fundingLine_id = int.Parse(cboFundingLine.SelectedValue.ToString());
                            }
                            _loancontract.synchronize = false;
                            _loancontract.interest = 0;
                            _loancontract.grace_period_of_latefees = 0;
                            _loancontract.anticipated_partial_repayment_penalties = 0;
                            _loancontract.number_of_drawings_loc = 0;
                            if (!string.IsNullOrEmpty(txtLineOfCredit.Text))
                            {
                                _loancontract.amount_under_loc = decimal.Parse(txtLineOfCredit.Text.Trim());
                            }
                            if (_loanpackage.maturity_loc != null)
                            {
                                _loancontract.maturity_loc = _loanpackage.maturity_loc;
                            }
                            if (_loanpackage.maturity_loc == null)
                            {
                                _loancontract.maturity_loc = _loanpackage.maturity_loc_min;
                            }
                            if (_loanpackage.anticipated_partial_repayment_base != null)
                            {
                                _loancontract.anticipated_partial_repayment_base = short.Parse(_loanpackage.anticipated_partial_repayment_base.ToString());
                            }
                            if (_loanpackage.anticipated_partial_repayment_base == null)
                            {
                                _loancontract.anticipated_partial_repayment_base = 0;
                            }
                            if (_loanpackage.anticipated_total_repayment_base != null)
                            {
                                _loancontract.anticipated_total_repayment_base = short.Parse(_loanpackage.anticipated_total_repayment_base.ToString());
                            }
                            if (_loanpackage.anticipated_total_repayment_base == null)
                            {
                                _loancontract.anticipated_total_repayment_base = 0;
                            }
                            _loancontract.schedule_changed = false;
                            _loancontract.amount_min = 0;
                            _loancontract.amount_max = 0;
                            _loancontract.ir_min = 0;
                            _loancontract.ir_max = 0;
                            _loancontract.nmb_of_inst_min = 0;
                            _loancontract.nmb_of_inst_max = 0;
                            _loancontract.loan_cycle = 0;
                            _loancontract.insurance = 0;
                            _loancontract.exotic_id = 0;
                            rep.AddNewLoanCredit(_loancontract);
                            #endregion "credit"

                            #region "Entry Fees"
                            SaveLoanEntryFeesinCreditEntryFees(_loancontract.creditid);
                            #endregion "Entry Fees"

                            #region "Installments"
                            SaveLoansContractInstallments(_loancontract);
                            #endregion "Installments"

                            #region "Loans Link Savings"
                            if (cboLoanLinkSavings.SelectedIndex == -1)
                            {
                                MessageBox.Show("Select Savings Link", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (cboLoanLinkSavings.SelectedIndex != -1)
                            {
                                ClientSavingContractModel _savings_contract = (ClientSavingContractModel)cboLoanLinkSavings.SelectedItem;

                                if (_loancontract.contractid == -1)
                                {
                                    MessageBox.Show("Loan Contract Id cannot be -1", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if (_savings_contract == null)
                                {
                                    MessageBox.Show("Savings Contract  cannot be null", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if (_loancontract.contractid != -1 && _savings_contract != null)
                                {
                                    SaveLoansLinkSavings(_loancontract.contractid, _savings_contract.savingcontractid);
                                }
                            }
                            #endregion "Loans Link Savings"

                            RefreshLoanContractsGrid();

                            RefreshSavingsContractsLoanGrid();

                            if (!tabControlClients.Contains(tabPageGuarantorsandCollaterals))
                            {
                                tabControlClients.TabPages.Add(tabPageGuarantorsandCollaterals);
                            }
                            if (!tabControlClients.Contains(tabPageCreditCommittee))
                            {
                                tabControlClients.TabPages.Add(tabPageCreditCommittee);
                            }
                            tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageGuarantorsandCollaterals)];
                        }
                    }
                    if (!string.IsNullOrEmpty(txtLoanContractCode.Text))
                    {

                        #region "contract"
                        _loancontract.start_date = dtpPreferredFirstInstallmentDate.Value;
                        _loancontract.close_date = dtpPreferredFirstInstallmentDate.Value.AddDays(double.Parse(txtNoofInstallments.Text.Trim()));
                        _loancontract.align_disbursed_date = dtpDisbursementDate.Value;
                        if (!string.IsNullOrEmpty(txtLoanPurpose.Text))
                        {
                            _loancontract.loan_purpose = txtLoanPurpose.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(txtAdvancedSettingsComment.Text))
                        {
                            _loancontract.comments = txtAdvancedSettingsComment.Text.Trim();
                        }
                        if (cboLoanEconomicActivity.SelectedIndex != -1)
                        {
                            _loancontract.activity_id = int.Parse(cboLoanEconomicActivity.SelectedValue.ToString());
                        }
                        _loancontract.first_installment_date = dtpPreferredFirstInstallmentDate.Value;

                        rep.UpdateLoanContract(_loancontract);
                        #endregion "contract"

                        #region "credit"
                        if (!string.IsNullOrEmpty(txtLoanAmount.Text))
                        {
                            _loancontract.amount = decimal.Parse(txtLoanAmount.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtInterestRatePerPeriod.Text))
                        {
                            _loancontract.interest_rate = decimal.Parse(txtInterestRatePerPeriod.Text.Trim());
                        }
                        if (cboInstallmentTypes.SelectedIndex != -1)
                        {
                            _loancontract.installment_type = int.Parse(cboInstallmentTypes.SelectedValue.ToString());
                        }
                        if (!string.IsNullOrEmpty(txtNoofInstallments.Text))
                        {
                            _loancontract.nb_of_installment = int.Parse(txtNoofInstallments.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtNoofInstallments.Text))
                        {
                            _loancontract.anticipated_total_repayment_penalties = double.Parse(txtEarlyFeesATR.Text.Trim());
                        }
                        if (cboLoanOfficer.SelectedIndex != -1)
                        {
                            _loancontract.loanofficer_id = int.Parse(cboLoanOfficer.SelectedValue.ToString());
                        }
                        if (!string.IsNullOrEmpty(txtNoofInstallments.Text))
                        {
                            _loancontract.anticipated_total_repayment_penalties = double.Parse(txtEarlyFeesATR.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtGracePeriod.Text))
                        {
                            _loancontract.grace_period = int.Parse(txtGracePeriod.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtOverduePrincipal.Text))
                        {
                            _loancontract.non_repayment_penalties_based_on_overdue_principal = double.Parse(txtOverduePrincipal.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtTotalLoanAmount.Text))
                        {
                            _loancontract.non_repayment_penalties_based_on_initial_amount = double.Parse(txtTotalLoanAmount.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtOLB.Text))
                        {
                            _loancontract.non_repayment_penalties_based_on_olb = double.Parse(txtOLB.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtOverDueInterest.Text))
                        {
                            _loancontract.non_repayment_penalties_based_on_overdue_interest = double.Parse(txtOverDueInterest.Text.Trim());
                        }
                        if (cboFundingLine.SelectedIndex != -1)
                        {
                            _loancontract.fundingLine_id = int.Parse(cboFundingLine.SelectedValue.ToString());
                        }
                        if (!string.IsNullOrEmpty(txtLineOfCredit.Text))
                        {
                            _loancontract.amount_under_loc = decimal.Parse(txtLineOfCredit.Text.Trim());
                        }
                        rep.UpdateLoanCredit(_loancontract);
                        #endregion "credit"

                        #region "Credit Entry Fees"
                        SaveLoanEntryFeesinCreditEntryFees(_loancontract.creditid);
                        #endregion "Credit Entry Fees"

                        #region "Installments"
                        UpdateLoansContractInstallments();
                        #endregion "Installments"

                        #region "Loans Link Savings"
                        if (cboLoanLinkSavings.SelectedIndex == -1)
                        {
                            MessageBox.Show("Select Savings Link", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (cboLoanLinkSavings.SelectedIndex != -1)
                        {
                            ClientSavingContractModel _savings_contract = (ClientSavingContractModel)cboLoanLinkSavings.SelectedItem;

                            if (_loancontract.contractid == -1)
                            {
                                MessageBox.Show("Loan Contract Id cannot be -1", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (_savings_contract == null)
                            {
                                MessageBox.Show("Savings Contract  cannot be null", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (_loancontract.contractid != -1 && _savings_contract != null)
                            {
                                UpdateLoansLinkSavings(_loancontract.contractid, _savings_contract.savingcontractid);
                            }
                        }
                        #endregion "Loans Link Savings"

                        if (!tabControlClients.Contains(tabPageGuarantorsandCollaterals))
                        {
                            tabControlClients.TabPages.Add(tabPageGuarantorsandCollaterals);
                        }
                        if (!tabControlClients.Contains(tabPageCreditCommittee))
                        {
                            tabControlClients.TabPages.Add(tabPageCreditCommittee);
                        }
                        tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageGuarantorsandCollaterals)];
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnViewSavingContractDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewSavingContracts.SelectedRows.Count != 0)
            {
                try
                {
                    InitializeSavingsContractsDetails();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnUpdateLoanContractCustomFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewLoanContractDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                InitializeLoanContractDetails();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUpdateSavingsCustomFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSaveCommitteeDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsLoanCreditCommitteeValid())
            {
                try
                {
                    if (_loancontract != null)
                    {
                        if (cboLoanStatus.SelectedIndex != -1)
                        {
                            _loancontract.status = short.Parse(cboLoanStatus.SelectedValue.ToString());
                        }
                        _loancontract.credit_commitee_date = dtpCreditCommiteeDate.Value;
                        if (!string.IsNullOrEmpty(txtCreditCommitteCode.Text))
                        {
                            _loancontract.credit_commitee_code = txtCreditCommitteCode.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(txtCreditComitteComment.Text))
                        {
                            _loancontract.credit_commitee_comment = txtCreditComitteComment.Text.Trim();
                        }
                        _loancontract.contractid = rep.AddNewLoanContract(_loancontract);

                        rep.UpdateLoanContractCreditCommittee(_loancontract);

                        if (!tabControlClients.Contains(tabPageLoansDetails))
                        {
                            tabControlClients.TabPages.Add(tabPageLoansDetails);
                        }
                        btnDisburse.Enabled = true;
                        tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageLoansDetails)];
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnEditSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteLoanGuarantor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCloseSavingsAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_savingscontract != null && _currencymodel != null)
                {
                    CloseSavingsAccountForm sfdf = new CloseSavingsAccountForm(_savingscontract, _currencymodel, user_id, connection) { Owner = this };
                    sfdf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewLoanGuarantor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnModifyLoanGuarantor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnWaiveLateFees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteRecentRepaymentEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnRepay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnReschedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEditRepaymentSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddTranche_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnWriteOffLoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSaveSavingsDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsSavingsContractValid())
            {
                try
                {
                    if (_savingsproduct != null)
                    {
                        _savingscontract = new ClientSavingContractModel();

                        #region "savingscontracts"
                        _savingscontract.product_id = _savingsproduct.savingproductid;
                        _savingscontract.user_id = user_id;
                        if (!string.IsNullOrEmpty(txtSavingsCode.Text))
                        {
                            _savingscontract.code = txtSavingsCode.Text.Trim();
                        }
                        _savingscontract.tiers_id = _clientModel.tierid;
                        _savingscontract.creation_date = DateTime.Now;
                        if (!string.IsNullOrEmpty(txtSavingsInterestRate.Text))
                        {
                            _savingscontract.interest_rate = double.Parse(txtSavingsInterestRate.Text.Trim());
                        }
                        _savingscontract.status = 1;
                        if (cboSavingsOfficer.SelectedIndex != -1)
                        {
                            _savingscontract.savings_officer_id = int.Parse(cboSavingsOfficer.SelectedValue.ToString());
                        }
                        if (!string.IsNullOrEmpty(txtSavingsInitialAmount.Text))
                        {
                            _savingscontract.initial_amount = decimal.Parse(txtSavingsInitialAmount.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtSavingsEntryFees.Text))
                        {
                            _savingscontract.entry_fees = decimal.Parse(txtSavingsEntryFees.Text.Trim());
                        }
                        _savingscontract.savingcontractid = rep.AddNewSavingContract(_savingscontract);
                        _savingscontract.savingbookcontractid = _savingscontract.savingcontractid;
                        #endregion "savingscontracts"

                        #region "savingsbookcontracts"
                        if (!string.IsNullOrEmpty(txtWithdrawFees.Text))
                        {
                            _savingscontract.flat_withdraw_fees = decimal.Parse(txtWithdrawFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtTransferFees.Text))
                        {
                            _savingscontract.flat_transfer_fees = decimal.Parse(txtTransferFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtCashDepositFees.Text))
                        {
                            _savingscontract.flat_deposit_fees = decimal.Parse(txtCashDepositFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtCloseFees.Text))
                        {
                            _savingscontract.flat_close_fees = decimal.Parse(txtCloseFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtManagementFees.Text))
                        {
                            _savingscontract.flat_management_fees = decimal.Parse(txtManagementFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtOverDraftFees.Text))
                        {
                            _savingscontract.flat_overdraft_fees = decimal.Parse(txtOverDraftFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtOverDraftFees.Text))
                        {
                            _savingscontract.flat_overdraft_fees = decimal.Parse(txtOverDraftFees.Text.Trim());
                        }
                        _savingscontract.in_overdraft = false;
                        if (!string.IsNullOrEmpty(txtAgioFees.Text))
                        {
                            _savingscontract.rate_agio_fees = double.Parse(txtAgioFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtChequeDepositFees.Text))
                        {
                            _savingscontract.cheque_deposit_fees = decimal.Parse(txtChequeDepositFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtReopenFees.Text))
                        {
                            _savingscontract.flat_reopen_fees = decimal.Parse(txtReopenFees.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtInterBranchTransferFees.Text))
                        {
                            _savingscontract.flat_ibt_fee = decimal.Parse(txtInterBranchTransferFees.Text.Trim());
                        }
                        _savingscontract.use_term_deposit = _savingsproduct.use_term_deposit;
                        _savingscontract.term_deposit_period = 0;
                        _savingscontract.term_deposit_period_min = _savingsproduct.term_deposit_period_min;
                        _savingscontract.term_deposit_period_max = _savingsproduct.term_deposit_period_max;
                        _savingscontract.transfer_account = null;
                        _savingscontract.rollover = 0;
                        _savingscontract.next_maturity = null;

                        rep.AddNewSavingBookContract(_savingscontract);
                        #endregion "savingsbookcontracts"

                        #region "savingsproduct"
                        _savingscontract.term_deposit_period_min = _savingsproduct.term_deposit_period_min;
                        _savingscontract.term_deposit_period_max = _savingsproduct.term_deposit_period_max;
                        _savingscontract.agio_fees = _savingsproduct.agio_fees;
                        _savingscontract.agio_fees_freq = _savingsproduct.agio_fees_freq;
                        _savingscontract.agio_fees_max = _savingsproduct.agio_fees_max;
                        _savingscontract.agio_fees_min = _savingsproduct.agio_fees_min;
                        _savingscontract.balance_max = _savingsproduct.balance_max;
                        _savingscontract.balance_min = _savingsproduct.balance_min;
                        _savingscontract.calcul_amount_base = _savingsproduct.calcul_amount_base;
                        _savingscontract.cheque_deposit_fees_max = _savingsproduct.cheque_deposit_fees_max;
                        _savingscontract.cheque_deposit_fees_min = _savingsproduct.cheque_deposit_fees_min;
                        _savingscontract.cheque_deposit_max = _savingsproduct.cheque_deposit_max;
                        _savingscontract.cheque_deposit_min = _savingsproduct.cheque_deposit_min;
                        _savingscontract.client_type = _savingsproduct.client_type;
                        _savingscontract.close_fees = _savingsproduct.close_fees;
                        _savingscontract.close_fees_max = _savingsproduct.close_fees_max;
                        _savingscontract.close_fees_min = _savingsproduct.close_fees_min;
                        _savingscontract.currency_id = _savingsproduct.currency_id;
                        _savingscontract.deposit_fees = _savingsproduct.deposit_fees;
                        _savingscontract.deposit_fees_max = _savingsproduct.deposit_fees_max;
                        _savingscontract.deposit_fees_min = _savingsproduct.deposit_fees_min;
                        _savingscontract.deposit_max = _savingsproduct.deposit_max;
                        _savingscontract.deposit_min = _savingsproduct.deposit_min;
                        _savingscontract.entry_fees_max = _savingsproduct.entry_fees_max;
                        _savingscontract.entry_fees_min = _savingsproduct.entry_fees_min;
                        _savingscontract.flat_transfer_fees_max = _savingsproduct.flat_transfer_fees_max;
                        _savingscontract.flat_transfer_fees_min = _savingsproduct.flat_transfer_fees_min;
                        _savingscontract.flat_withdraw_fees_max = _savingsproduct.flat_withdraw_fees_max;
                        _savingscontract.flat_withdraw_fees_min = _savingsproduct.flat_withdraw_fees_min;
                        _savingscontract.ibt_fee = _savingsproduct.ibt_fee;
                        _savingscontract.ibt_fee_max = _savingsproduct.ibt_fee_max;
                        _savingscontract.ibt_fee_min = _savingsproduct.ibt_fee_min;
                        _savingscontract.initial_amount_max = _savingsproduct.initial_amount_max;
                        _savingscontract.initial_amount_min = _savingsproduct.initial_amount_min;
                        _savingscontract.interest_base = _savingsproduct.interest_base;
                        _savingscontract.interest_frequency = _savingsproduct.interest_frequency;
                        _savingscontract.interest_rate_max = _savingsproduct.interest_rate_max;
                        _savingscontract.interest_rate_min = _savingsproduct.interest_rate_min;
                        _savingscontract.is_ibt_fee_flat = _savingsproduct.is_ibt_fee_flat;
                        _savingscontract.management_fees = _savingsproduct.management_fees;
                        _savingscontract.management_fees_freq = _savingsproduct.management_fees_freq;
                        _savingscontract.management_fees_max = _savingsproduct.management_fees_max;
                        _savingscontract.management_fees_min = _savingsproduct.management_fees_min;
                        _savingscontract.overdraft_fees = _savingsproduct.overdraft_fees;
                        _savingscontract.overdraft_fees_max = _savingsproduct.overdraft_fees_max;
                        _savingscontract.overdraft_fees_min = _savingsproduct.overdraft_fees_min;
                        _savingscontract.posting_frequency = _savingsproduct.posting_frequency;
                        _savingscontract.product_type = _savingsproduct.product_type;
                        _savingscontract.rate_transfer_fees_max = _savingsproduct.rate_transfer_fees_max;
                        _savingscontract.rate_transfer_fees_min = _savingsproduct.rate_transfer_fees_min;
                        _savingscontract.rate_withdraw_fees_max = _savingsproduct.rate_withdraw_fees_max;
                        _savingscontract.rate_withdraw_fees_min = _savingsproduct.rate_withdraw_fees_min;
                        _savingscontract.reopen_fees = _savingsproduct.reopen_fees;
                        _savingscontract.reopen_fees_max = _savingsproduct.reopen_fees_max;
                        _savingscontract.reopen_fees_min = _savingsproduct.reopen_fees_min;
                        _savingscontract.transfer_fees_type = _savingsproduct.transfer_fees_type;
                        _savingscontract.transfer_max = _savingsproduct.transfer_max;
                        _savingscontract.transfer_min = _savingsproduct.transfer_min;
                        _savingscontract.withdraw_fees_type = _savingsproduct.withdraw_fees_type;
                        _savingscontract.withdraw_max = _savingsproduct.withdraw_max;
                        _savingscontract.withdraw_min = _savingsproduct.withdraw_min;
                        #endregion "savingsproduct"

                        DisableSavingsDetailsControls();

                        RefreshSavingsContractsGrid();

                        btnSavingsContractCloseAccount.Visible = false;
                        btnSavingsContractFirstDeposit.Visible = true;
                        btnSavingsContractSaveAccount.Visible = false;
                        btnSavingsContractFirstDeposit.Location = btnSavingsContractSaveAccount.Location;

                        if (!tabControlClients.Contains(tabPageSavingsDetails))
                        {
                            tabControlClients.TabPages.Add(tabPageSavingsDetails);
                        }
                        tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageSavingsDetails)];
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnCancelLastOperation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteCollateral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewCollateral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnModifyCollateral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void tabControlClients_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (tabControlClients.SelectedTab == this.tabPageGuarantorsandCollaterals)
                {
                    InitializeContractsDefaults();
                    RefreshLoanContractCollateralsGrid();
                }
                if (tabControlClients.SelectedTab == this.tabPageSavingsDetails)
                {
                    if (_clientModel != null && _savingscontract != null)
                    {
                        InitializeSavingsContractBalance();
                    }
                }
                if (tabControlClients.SelectedTab == this.tabPageAdvancedSettings)
                {
                    var _savingscontractsquery = from af in rep.GetAllClientSavingContracts(_clientModel.tierid)
                                                 select af;
                    List<ClientSavingContractModel> _clientsavingcontracts = _savingscontractsquery.ToList();
                    cboLoanLinkSavings.DataSource = _clientsavingcontracts;
                    cboLoanLinkSavings.ValueMember = "savingcontractid";
                    cboLoanLinkSavings.DisplayMember = "code";

                }
                if (tabControlClients.SelectedTab == this.tabPageLoansDetails)
                {
                    RefreshLoanContractCustomizableFieldsGrid();
                    if (_loancontract == null)
                    {
                        btnDisburse.Enabled = false;
                    }
                    if (_loancontract != null)
                    {
                        if (_loancontract.status != 2)
                        {
                            btnDisburse.Enabled = false;
                        }
                        if (_loancontract.status == 2)
                        {
                            btnDisburse.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Controls"
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
        private bool IsLoanDetailsValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtLoanAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLoanAmount, "Loan Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtInterestRatePerPeriod.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtInterestRatePerPeriod, "Interest Rate Per Period cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtGracePeriod.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtGracePeriod, "Grace Period cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNoofInstallments.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoofInstallments, "No of Installments cannot be null!");
                return false;
            }
            if (cboInstallmentTypes.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboInstallmentTypes, "Select Installment Type!");
                return false;
            }
            if (cboFundingLine.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboFundingLine, "Select Funding Line!");
                return false;
            }
            if (cboLoanOfficer.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboLoanOfficer, "Select Loan Officer!");
                return false;
            }
            if (cboLoanEconomicActivity.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboLoanEconomicActivity, "Select Economic Activity!");
                return false;
            }
            return noerror;
        }
        private bool IsInstallmentDetailsValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtLoanAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLoanAmount, "Loan Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtInterestRatePerPeriod.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtInterestRatePerPeriod, "Interest Rate Per Period cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNoofInstallments.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoofInstallments, "No of Installments cannot be null!");
                return false;
            }
            if (cboInstallmentTypes.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboInstallmentTypes, "Select Installment Type!");
                return false;
            }
            if (cboFundingLine.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboFundingLine, "Select Funding Line!");
                return false;
            }
            return noerror;
        }
        private bool IsLoanAdvancedSettingsValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtLineOfCredit.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLineOfCredit, "Line Of Credit cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCreditInsurance.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCreditInsurance, "Credit Insurance cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtEarlyFeesATR.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEarlyFeesATR, "Early Fees ATR cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtEarlyFeesAPR.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEarlyFeesAPR, "Early Fees APR cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTotalLoanAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTotalLoanAmount, "Late Fees on Total Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtOverduePrincipal.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOverduePrincipal, "Late Fees on Overdue Principal cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtOLB.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOLB, "Late Fees on OLB cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtOverDueInterest.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOverDueInterest, "Late Fees on Over Due Interest cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCompulsorySavingsAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCompulsorySavingsAmount, "Compulsory Savings Amount cannot be null!");
                return false;
            }
            if (cboLoanLinkSavings.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboLoanLinkSavings, "Select Loan Link Savings!");
                return false;
            }
            return noerror;
        }
        private bool IsLoanLinkSavingsValid()
        {
            bool noerror = true;
            if (cboLoanLinkSavings.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboLoanLinkSavings, "Select Loan Link Savings!");
                return false;
            }
            return noerror;
        }
        private bool IsLoanCreditCommitteeValid()
        {
            bool noerror = true;
            if (cboLoanStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboLoanStatus, "Select Loan Status!");
                return false;
            }
            return noerror;
        }
        private bool IsSavingsContractValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtSavingsCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSavingsCode, "Savings Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtSavingsInitialAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSavingsInitialAmount, "Savings Initial Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtSavingsEntryFees.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSavingsEntryFees, "Savings Entry Fees cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtWithdrawFees.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtWithdrawFees, "Withdraw Fees cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtSavingsInterestRate.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSavingsInterestRate, "Savings Interest Rate cannot be null!");
                return false;
            }
            if (cboSavingsOfficer.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboSavingsOfficer, "Select Savings Officer!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"
        #region "Initialization"
        private void LoadControls()
        {
            try
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                lblSelectedDisbursementDayName.Text = string.Empty;
                lblSelectedFirstInstallmentDayName.Text = string.Empty;
                lblNoofYears.Text = string.Empty;
                txtCitizenShip.Text = RegionAndLanguageHelper.GetMachineCurrentLocation();

                _currencymodel = rep.GetDefaultCurrency();

                _branchmodel = rep.GetDefaultBranch();

                //Gender Combox
                var gender = new BindingList<KeyValuePair<string, string>>();
                gender.Add(new KeyValuePair<string, string>("M", "Male"));
                gender.Add(new KeyValuePair<string, string>("F", "Female"));
                cboGender.DataSource = gender;
                cboGender.ValueMember = "Key";
                cboGender.DisplayMember = "Value";
                cboGender.SelectedIndex = -1;

                var LoanStatusquery = from s in rep.GetAllStatuses()
                                      select s;
                List<StatusModel> LoanStatuses = LoanStatusquery.ToList();
                cboLoanStatus.DataSource = LoanStatuses;
                cboLoanStatus.ValueMember = "statusid";
                cboLoanStatus.DisplayMember = "status_name";
                cboLoanStatus.SelectedIndex = -1;

                IList<UserModel_dto> loanoficers = rep.GetUsersModelwithRolesList();
                cboLoanOfficer.DataSource = loanoficers;
                cboLoanOfficer.DisplayMember = "full_name";
                cboLoanOfficer.ValueMember = "userid";
                cboLoanOfficer.SelectedIndex = -1;

                IList<UserModel_dto> savingsofficers = rep.GetUsersModelwithRolesList();
                cboSavingsOfficer.DataSource = savingsofficers;
                cboSavingsOfficer.DisplayMember = "full_name";
                cboSavingsOfficer.ValueMember = "userid";
                cboSavingsOfficer.SelectedIndex = -1;

                var installmenttypesquery = from it in rep.GetAllInstallmentTypes()
                                            select it;
                List<InstallmentTypesModel> InstallmentTypes = installmenttypesquery.ToList();
                cboInstallmentTypes.DataSource = InstallmentTypes;
                cboInstallmentTypes.ValueMember = "installmenttypesid";
                cboInstallmentTypes.DisplayMember = "name";
                cboInstallmentTypes.SelectedIndex = -1;

                var fundinglinesquery = from fl in rep.GetFundingLinesList()
                                        where fl.deleted == false
                                        select fl;
                List<FundingLineModel> FundingLines = fundinglinesquery.ToList();
                cboFundingLine.DataSource = FundingLines;
                cboFundingLine.ValueMember = "fundinglineid";
                cboFundingLine.DisplayMember = "name";
                cboFundingLine.SelectedIndex = -1;

                List<ActivityModel> _EconomicActivities = rep.GetEconomicActivitiesList();
                cboEconomicActivity.DataSource = _EconomicActivities;
                cboEconomicActivity.ValueMember = "activityid";
                cboEconomicActivity.DisplayMember = "name";
                cboEconomicActivity.SelectedIndex = -1;

                List<ActivityModel> _loanEconomicActivities = rep.GetEconomicActivitiesList();
                cboLoanEconomicActivity.DataSource = _loanEconomicActivities;
                cboLoanEconomicActivity.ValueMember = "activityid";
                cboLoanEconomicActivity.DisplayMember = "name";
                cboLoanEconomicActivity.SelectedIndex = -1;

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

                tabControlClients.TabPages.Remove(tabPageLoansDetails);
                tabControlClients.TabPages.Remove(tabPageAdvancedSettings);
                tabControlClients.TabPages.Remove(tabPageGuarantorsandCollaterals);
                tabControlClients.TabPages.Remove(tabPageCreditCommittee);
                tabControlClients.TabPages.Remove(tabPageLoanRepayment);
                tabControlClients.TabPages.Remove(tabPageSavingsDetails);

                lblCustomFieldsName.Text = string.Empty;
                lblCustomFieldsDescription.Text = string.Empty;
                chkattMandatory.Checked = false;
                chkattUnique.Checked = false;
                lblEntryFeeMax.Text = string.Empty;
                lblEntryFeesMin.Text = string.Empty;
                chkRate.Checked = false;
                lblLoanContractCustomFieldName.Text = string.Empty;
                lblLoanContractCustomFieldDescription.Text = string.Empty;
                chkLoanContractCustomFieldMandatory.Checked = false;
                chkLoanContractCustomFieldUnique.Checked = false;
                lblSavingContractCustomFieldName.Text = string.Empty;
                lblSavingContractCustomFieldDescription.Text = string.Empty;
                chkSavingContractCustomFieldMandatory.Checked = false;
                chkSavingContractCustomFieldUnique.Checked = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void LoadCustomizableFields()
        {
            try
            {
                var advancedfieldsquery = from af in rep.GetClientCustomizableFields(1, _clientModel.tierid)
                                          select af;
                _clientcustomfields = advancedfieldsquery.ToList();

                InitializedataGridViewClientCustomizableFields();
                groupBox44.Text = _clientcustomfields.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void LoadClientLoanContracts()
        {
            try
            {
                if (_clientModel != null)
                {
                    List<ClientLoanContractModel> _loan_contracts_list = new List<ClientLoanContractModel>();
                    bindingSourceLoanContracts.DataSource = null;

                    if (_clientModel != null)
                    {
                        var _statusquery = from rl in rep.GetAllStatuses()
                                           select rl;
                        List<StatusModel> _statuses = _statusquery.ToList();
                        DataGridViewComboBoxColumn colCboxLoanStatus = new DataGridViewComboBoxColumn();
                        colCboxLoanStatus.HeaderText = "Status";
                        colCboxLoanStatus.Name = "cbLoanStatus";
                        colCboxLoanStatus.DataSource = _statuses;
                        // The display member is the name column in the column datasource  
                        colCboxLoanStatus.DisplayMember = "status_name";
                        // The DataPropertyName refers to the foreign key column on the datagridview datasource
                        colCboxLoanStatus.DataPropertyName = "status";
                        // The value member is the primary key of the parent table  
                        colCboxLoanStatus.ValueMember = "statusid";
                        colCboxLoanStatus.MaxDropDownItems = 10;
                        colCboxLoanStatus.Width = 60;
                        colCboxLoanStatus.DisplayIndex = 6;
                        colCboxLoanStatus.MinimumWidth = 5;
                        colCboxLoanStatus.FlatStyle = FlatStyle.Flat;
                        colCboxLoanStatus.DefaultCellStyle.NullValue = "--- Select ---";
                        colCboxLoanStatus.ReadOnly = true;
                        colCboxLoanStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (!this.dataGridViewLoanContracts.Columns.Contains("cbLoanStatus"))
                        {
                            dataGridViewLoanContracts.Columns.Add(colCboxLoanStatus);
                        }

                        var _installmenttypesquery = from rl in rep.GetAllInstallmentTypes()
                                                     select rl;
                        List<InstallmentTypesModel> _installmenttyes = _installmenttypesquery.ToList();
                        DataGridViewComboBoxColumn colCboxInstallmentType = new DataGridViewComboBoxColumn();
                        colCboxInstallmentType.HeaderText = "installment_type";
                        colCboxInstallmentType.Name = "cbInstallmentType";
                        colCboxInstallmentType.DataSource = _installmenttyes;
                        // The display member is the name column in the column datasource  
                        colCboxInstallmentType.DisplayMember = "name";
                        // The DataPropertyName refers to the foreign key column on the datagridview datasource
                        colCboxInstallmentType.DataPropertyName = "installment_type";
                        // The value member is the primary key of the parent table  
                        colCboxInstallmentType.ValueMember = "installmenttypesid";
                        colCboxInstallmentType.MaxDropDownItems = 10;
                        colCboxInstallmentType.Width = 100;
                        colCboxInstallmentType.DisplayIndex = 7;
                        colCboxInstallmentType.MinimumWidth = 5;
                        colCboxInstallmentType.FlatStyle = FlatStyle.Flat;
                        colCboxInstallmentType.DefaultCellStyle.NullValue = "--- Select ---";
                        colCboxInstallmentType.ReadOnly = true;
                        colCboxInstallmentType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (!this.dataGridViewLoanContracts.Columns.Contains("cbInstallmentType"))
                        {
                            dataGridViewLoanContracts.Columns.Add(colCboxInstallmentType);
                        }

                        var _currenciesquery = from rl in rep.GetCurrenciesList()
                                               select rl;
                        List<CurrencyModel> _currencies = _currenciesquery.ToList();
                        DataGridViewComboBoxColumn colCboxCurrency = new DataGridViewComboBoxColumn();
                        colCboxCurrency.HeaderText = "Currency";
                        colCboxCurrency.Name = "cbCurrency";
                        colCboxCurrency.DataSource = _currencies;
                        // The display member is the name column in the column datasource  
                        colCboxCurrency.DisplayMember = "code";
                        // The DataPropertyName refers to the foreign key column on the datagridview datasource
                        colCboxCurrency.DataPropertyName = "currency_id";
                        // The value member is the primary key of the parent table  
                        colCboxCurrency.ValueMember = "currencyid";
                        colCboxCurrency.MaxDropDownItems = 10;
                        colCboxCurrency.Width = 70;
                        colCboxCurrency.DisplayIndex = 8;
                        colCboxCurrency.MinimumWidth = 5;
                        colCboxCurrency.FlatStyle = FlatStyle.Flat;
                        colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                        colCboxCurrency.ReadOnly = true;
                        //colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (!this.dataGridViewLoanContracts.Columns.Contains("cbCurrency"))
                        {
                            //dataGridViewLoanContracts.Columns.Add(colCboxCurrency);
                        }

                        var _contractsquery = from af in rep.GetAllClientLoanContracts(_clientModel.tierid)
                                              select af;
                        _loan_contracts_list = _contractsquery.ToList();
                        bindingSourceLoanContracts.DataSource = _loan_contracts_list;
                        dataGridViewLoanContracts.AutoGenerateColumns = false;
                        dataGridViewLoanContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridViewLoanContracts.DataSource = bindingSourceLoanContracts;
                        groupBoxLoans.Text = "Loans     " + bindingSourceLoanContracts.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void LoadClientSavingsContracts()
        {
            try
            {
                if (_clientModel != null)
                {
                    _savingscontractslist = new List<ClientSavingContractModel>();
                    bindingSourceSavingContracts.DataSource = null;

                    var _statusquery = from rl in rep.GetAllStatuses()
                                       select rl;
                    List<StatusModel> _statuses = _statusquery.ToList();
                    DataGridViewComboBoxColumn colCboxStatuses = new DataGridViewComboBoxColumn();
                    colCboxStatuses.HeaderText = "Status";
                    colCboxStatuses.Name = "cbStatus";
                    colCboxStatuses.DataSource = _statuses;
                    // The display member is the name column in the column datasource  
                    colCboxStatuses.DisplayMember = "status_name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxStatuses.DataPropertyName = "status";
                    // The value member is the primary key of the parent table  
                    colCboxStatuses.ValueMember = "statusid";
                    colCboxStatuses.MaxDropDownItems = 10;
                    colCboxStatuses.Width = 80;
                    colCboxStatuses.DisplayIndex = 4;
                    colCboxStatuses.MinimumWidth = 5;
                    colCboxStatuses.FlatStyle = FlatStyle.Flat;
                    colCboxStatuses.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxStatuses.ReadOnly = true;
                    //colCboxStatuses.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingContracts.Columns.Contains("cbStatus"))
                    {
                        dataGridViewSavingContracts.Columns.Add(colCboxStatuses);
                    }

                    var _currenciesquery = from rl in rep.GetCurrenciesList()
                                           select rl;
                    List<CurrencyModel> _currencies = _currenciesquery.ToList();
                    DataGridViewComboBoxColumn colCboxCurrency = new DataGridViewComboBoxColumn();
                    colCboxCurrency.HeaderText = "Currency";
                    colCboxCurrency.Name = "cbCurrency";
                    colCboxCurrency.DataSource = _currencies;
                    // The display member is the name column in the column datasource  
                    colCboxCurrency.DisplayMember = "code";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxCurrency.DataPropertyName = "currency_id";
                    // The value member is the primary key of the parent table  
                    colCboxCurrency.ValueMember = "currencyid";
                    colCboxCurrency.MaxDropDownItems = 10;
                    colCboxCurrency.Width = 100;
                    colCboxCurrency.DisplayIndex = 5;
                    colCboxCurrency.MinimumWidth = 5;
                    colCboxCurrency.FlatStyle = FlatStyle.Flat;
                    colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxCurrency.ReadOnly = true;
                    colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingContracts.Columns.Contains("cbCurrency"))
                    {
                        dataGridViewSavingContracts.Columns.Add(colCboxCurrency);
                    }

                    var _savingscontractsquery = from af in rep.GetAllClientSavingContracts(_clientModel.tierid)
                                                 select af;
                    _savingscontractslist = _savingscontractsquery.ToList();
                    bindingSourceSavingContracts.DataSource = _savingscontractslist;
                    dataGridViewSavingContracts.AutoGenerateColumns = false;
                    dataGridViewSavingContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewSavingContracts.DataSource = bindingSourceSavingContracts;
                    groupBoxSavings.Text = "Savings     " + bindingSourceSavingContracts.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {

            try
            {
                if (_clientModel.first_name != null)
                {
                    txtFirstName.Text = _clientModel.first_name.Trim();
                }
                if (_clientModel.last_name != null)
                {
                    txtLastName.Text = _clientModel.last_name.Trim();
                }
                if (_clientModel.father_name != null)
                {
                    txtFatherName.Text = _clientModel.father_name.Trim();
                }
                if (_clientModel.birth_date != null)
                {
                    dtpDateofBirth.Value = _clientModel.birth_date ?? DateTime.Now;
                }
                if (_clientModel.sex != null)
                {
                    cboGender.SelectedValue = _clientModel.sex.Trim();
                }
                if (_clientModel.identification_data != null)
                {
                    txtIDNo.Text = _clientModel.identification_data.Trim();
                }
                if (_clientModel.branch_id != null)
                {
                    cboBranch.SelectedValue = _clientModel.branch_id;
                }
                if (_clientModel.activity_id != null)
                {
                    cboEconomicActivity.SelectedValue = _clientModel.activity_id;
                }
                if (_clientModel.loan_cycle != null)
                {
                    txtLoanCycle.Text = _clientModel.loan_cycle.ToString();
                    txtLoanCycle.Enabled = false;
                }
                if (_clientModel.birth_place != null)
                {
                    txtPlaceofBirth.Text = _clientModel.birth_place.Trim();
                }
                if (_clientModel.nationality != null)
                {
                    txtCitizenShip.Text = _clientModel.nationality.Trim();
                }
                if (_clientModel.household_head != null)
                {
                    chkHeadofHouseHold.Checked = _clientModel.household_head;
                }
                if (_clientModel.image_path != null)
                {
                    pbPhoto.ImageLocation = _clientModel.image_path.Trim();
                }

                #region "Home Address"
                if (_clientModel.province_id != null)
                {
                    cboHAProvince.SelectedValue = _clientModel.province_id;
                }
                if (_clientModel.district_id != null)
                {
                    cboHADistrict.SelectedValue = _clientModel.district_id;
                }
                if (_clientModel.city != null)
                {
                    txtHACity.Text = _clientModel.city.Trim();
                }
                if (_clientModel.address != null)
                {
                    txtHAdress.Text = _clientModel.address.Trim();
                }
                if (_clientModel.zipCode != null)
                {
                    txtHAZipCode.Text = _clientModel.zipCode.Trim();
                }
                if (_clientModel.home_type != null)
                {
                    cboHAHomeType.SelectedValue = _clientModel.home_type.Trim();
                }
                if (_clientModel.home_phone != null)
                {
                    txtHAHomePhone.Text = _clientModel.home_phone.Trim();
                }
                if (_clientModel.personal_phone != null)
                {
                    txtHACellPhone.Text = _clientModel.personal_phone.Trim();
                }
                if (_clientModel.e_mail != null)
                {
                    txtHAEmail.Text = _clientModel.e_mail.Trim();
                }
                #endregion "Home Address"

                #region "Business Address"
                if (_clientModel.secondary_province_id != null)
                {
                    cboBAProvince.SelectedValue = _clientModel.secondary_province_id;
                }
                if (_clientModel.secondary_district_id != null)
                {
                    cboBADistrict.SelectedValue = _clientModel.secondary_district_id;
                }
                if (_clientModel.secondary_city != null)
                {
                    txtBACity.Text = _clientModel.secondary_city.Trim();
                }
                if (_clientModel.secondary_address != null)
                {
                    txtBAAddress.Text = _clientModel.secondary_address.Trim();
                }
                if (_clientModel.secondary_zipCode != null)
                {
                    txtBAZipCode.Text = _clientModel.secondary_zipCode.Trim();
                }
                if (_clientModel.secondary_homeType != null)
                {
                    cboBAHomeType.SelectedValue = _clientModel.secondary_homeType.Trim();
                }
                if (_clientModel.secondary_home_phone != null)
                {
                    txtBAHomePhone.Text = _clientModel.secondary_home_phone.Trim();
                }
                if (_clientModel.secondary_personal_phone != null)
                {
                    txtBACellPhone.Text = _clientModel.secondary_personal_phone.Trim();
                }
                if (_clientModel.secondary_e_mail != null)
                {
                    txtBAEmail.Text = _clientModel.secondary_e_mail.Trim();
                }
                #endregion "Business Address"
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeContractsDefaults()
        {
            try
            {
                if (dataGridViewLoanContracts.SelectedRows.Count != 0)
                {
                    ClientLoanContractModel _selectedloancontract = (ClientLoanContractModel)bindingSourceLoanContracts.Current;
                    _loancontract = _selectedloancontract;
                }
                if (dataGridViewSavingContracts.SelectedRows.Count != 0)
                {
                    ClientSavingContractModel _selectedsavingcontract = (ClientSavingContractModel)bindingSourceSavingContracts.Current;
                    _savingscontract = _selectedsavingcontract;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void InitializeSavingsContractBalance()
        {
            try
            {
                if (_savingscontract == null)
                {
                    decimal _balance = 0M;
                    string _stringbalance = String.Format("{0:0.0000}", _balance);
                    lblSavingsBalanceAmount.Text = "Balance " + _stringbalance.ToString() + "  " + _currencymodel.code;
                    lblSavingsAvailableBalance.Text = "Available Balance " + _stringbalance.ToString() + "  " + _currencymodel.code;
                }
                if (_clientModel != null && _savingscontract != null)
                {
                    lblSavingsBalanceAmount.Text = "Balance " + this.GetSavingsContractBalance(_clientModel.tierid, _savingscontract.savingcontractid).ToString() + "  " + _currencymodel.code;
                    lblSavingsAvailableBalance.Text = "Available Balance " + this.GetSavingsContractBalance(_clientModel.tierid, _savingscontract.savingcontractid).ToString() + "  " + _currencymodel.code;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeSavingsContractsDetails()
        {
            if (dataGridViewSavingContracts.SelectedRows.Count != 0)
            {
                try
                {
                    _savingscontract = new ClientSavingContractModel();

                    DAL.ClientSavingContractModel _selectedsavingcontract = (DAL.ClientSavingContractModel)bindingSourceSavingContracts.Current;

                    _savingscontract = _selectedsavingcontract;

                    ClearSavingDetailsControls();

                    DisableSavingsDetailsControls();

                    PopulateSavingsDetailsfromSavingsContract(_savingscontract);

                    RefreshSavingsContractEventsGrid();

                    RefreshSavingContractCustomizableFieldsGrid();

                    RefreshSavingsContractsLoanGrid();

                    InitializeSavingsContractBalance();

                    btnSavingsContractCloseAccount.Visible = true;
                    btnSavingsContractFirstDeposit.Visible = false;
                    btnSavingsContractSaveAccount.Visible = false;
                    btnSavingsContractCloseAccount.Location = btnSavingsContractSaveAccount.Location;

                    if (!tabControlClients.Contains(tabPageSavingsDetails))
                    {
                        tabControlClients.TabPages.Add(tabPageSavingsDetails);
                    }
                    tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageSavingsDetails)];
                    tabControlSavingsDetails.SelectedTab = tabControlSavingsDetails.TabPages[tabControlSavingsDetails.TabPages.IndexOf(tabPageFeesandLimits)];
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void InitializeLoanContractDetails()
        {
            if (dataGridViewLoanContracts.SelectedRows.Count != 0)
            {
                try
                {
                    _loancontract = (DAL.ClientLoanContractModel)bindingSourceLoanContracts.Current;

                    switch (_loancontract.status)
                    {
                        case 1:
                            ClearLoanDetailsControls();

                            EnableLoanDetailsControls();

                            PopulateLoansContractInstallmentsGrid(_loancontract);

                            PopulateLoanDetailsfromContract(_loancontract);

                            if (!tabControlClients.Contains(tabPageLoansDetails))
                            {
                                tabControlClients.TabPages.Add(tabPageLoansDetails);
                            }
                            if (!tabControlClients.Contains(tabPageAdvancedSettings))
                            {
                                tabControlClients.TabPages.Add(tabPageAdvancedSettings);
                            }
                            if (!tabControlClients.Contains(tabPageGuarantorsandCollaterals))
                            {
                                tabControlClients.TabPages.Add(tabPageGuarantorsandCollaterals);
                            }
                            if (!tabControlClients.Contains(tabPageCreditCommittee))
                            {
                                tabControlClients.TabPages.Add(tabPageCreditCommittee);
                            }
                            tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageLoansDetails)];
                            break;
                        default:
                            ClearLoanDetailsControls();

                            DisableLoanDetailsControls();

                            PopulateLoansContractInstallmentsGrid(_loancontract);

                            PopulateLoanDetailsfromContract(_loancontract);

                            if (!tabControlClients.Contains(tabPageLoansDetails))
                            {
                                tabControlClients.TabPages.Add(tabPageLoansDetails);
                            }
                            if (!tabControlClients.Contains(tabPageAdvancedSettings))
                            {
                                tabControlClients.TabPages.Add(tabPageAdvancedSettings);
                            }
                            if (!tabControlClients.Contains(tabPageGuarantorsandCollaterals))
                            {
                                tabControlClients.TabPages.Add(tabPageGuarantorsandCollaterals);
                            }
                            if (!tabControlClients.Contains(tabPageCreditCommittee))
                            {
                                tabControlClients.TabPages.Add(tabPageCreditCommittee);
                            }
                            if (!tabControlClients.Contains(tabPageLoanRepayment))
                            {
                                tabControlClients.TabPages.Add(tabPageLoanRepayment);
                            }
                            tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageLoanRepayment)];
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void InitializedataGridViewClientCustomizableFields()
        {
            try
            {
                dataGridViewClientCustomizableFields.Rows.Clear();
                dataGridViewClientCustomizableFields.AutoGenerateColumns = false;
                dataGridViewClientCustomizableFields.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewClientCustomizableFields.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewClientCustomizableFields.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                int _rowid = 1;
                foreach (var c in _clientcustomfields)
                {
                    switch (c.type_id)
                    {
                        case 1:
                            DataGridViewRow _booleanrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _booleanidcell = new DataGridViewTextBoxCell();
                            _booleanidcell.Value = _rowid.ToString();
                            _booleanrow.Cells.Add(_booleanidcell);

                            DataGridViewColumn _booleaniddataGridViewColumn = new DataGridViewColumn();
                            _booleaniddataGridViewColumn.DataPropertyName = "_rowid";
                            _booleaniddataGridViewColumn.HeaderText = "Id";
                            _booleaniddataGridViewColumn.CellTemplate = _booleanidcell;
                            _booleaniddataGridViewColumn.Name = "columnId";
                            _booleaniddataGridViewColumn.ReadOnly = true;
                            _booleaniddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_booleaniddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleannamecell = new DataGridViewTextBoxCell();
                            _booleannamecell.Value = c.name.Trim();
                            _booleanrow.Cells.Add(_booleannamecell);

                            DataGridViewColumn _booleannamedataGridViewColumn = new DataGridViewColumn();
                            _booleannamedataGridViewColumn.DataPropertyName = "name";
                            _booleannamedataGridViewColumn.HeaderText = "Field";
                            _booleannamedataGridViewColumn.CellTemplate = _booleannamecell;
                            _booleannamedataGridViewColumn.Name = "columnName";
                            _booleannamedataGridViewColumn.ReadOnly = true;
                            _booleannamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_booleannamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleandesccell = new DataGridViewTextBoxCell();
                            _booleandesccell.Value = c.desc.Trim();
                            _booleanrow.Cells.Add(_booleandesccell);

                            DataGridViewColumn _booleandescdataGridViewColumn = new DataGridViewColumn();
                            _booleandescdataGridViewColumn.DataPropertyName = "desc";
                            _booleandescdataGridViewColumn.HeaderText = "Desc";
                            _booleandescdataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleandescdataGridViewColumn.Name = "columnDesc";
                            _booleandescdataGridViewColumn.ReadOnly = true;
                            _booleandescdataGridViewColumn.Visible = false;
                            _booleandescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_booleandescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _booleanis_mandatorycell = new DataGridViewCheckBoxCell();
                            _booleanis_mandatorycell.Value = c.is_mandatory;
                            _booleanrow.Cells.Add(_booleanis_mandatorycell);

                            DataGridViewColumn _booleanis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _booleanis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _booleanis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _booleanis_mandatorydataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleanis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _booleanis_mandatorydataGridViewColumn.ReadOnly = true;
                            _booleanis_mandatorydataGridViewColumn.Visible = false;
                            _booleanis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_booleanis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleanis_uniquecell = new DataGridViewTextBoxCell();
                            _booleanis_uniquecell.Value = c.is_unique;
                            _booleanrow.Cells.Add(_booleanis_uniquecell);

                            DataGridViewColumn _booleanis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _booleanis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _booleanis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _booleanis_uniquedataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleanis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _booleanis_uniquedataGridViewColumn.ReadOnly = true;
                            _booleanis_uniquedataGridViewColumn.Visible = false;
                            _booleanis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_booleanis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleanvaluecell = new DataGridViewTextBoxCell();
                            _booleanvaluecell.Value = c.value;
                            _booleanrow.Cells.Add(_booleanvaluecell);

                            DataGridViewColumn _booleanvaluedataGridViewColumn = new DataGridViewColumn();
                            _booleanvaluedataGridViewColumn.DataPropertyName = "value";
                            _booleanvaluedataGridViewColumn.HeaderText = "Value";
                            _booleanvaluedataGridViewColumn.CellTemplate = _booleannamecell;
                            _booleanvaluedataGridViewColumn.Name = "columnValue";
                            _booleanvaluedataGridViewColumn.ReadOnly = false;
                            _booleanvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            _booleanvaluedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_booleanvaluedataGridViewColumn);
                            }

                            dataGridViewClientCustomizableFields.Rows.Add(_booleanrow);
                            break;
                        case 2:
                            DataGridViewRow _numberrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _numberidcell = new DataGridViewTextBoxCell();
                            _numberidcell.Value = _rowid.ToString();
                            _numberrow.Cells.Add(_numberidcell);

                            DataGridViewColumn _numberiddataGridViewColumn = new DataGridViewColumn();
                            _numberiddataGridViewColumn.DataPropertyName = "_rowid";
                            _numberiddataGridViewColumn.HeaderText = "Id";
                            _numberiddataGridViewColumn.CellTemplate = _numberidcell;
                            _numberiddataGridViewColumn.Name = "columnId";
                            _numberiddataGridViewColumn.ReadOnly = true;
                            _numberiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_numberiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbernamecell = new DataGridViewTextBoxCell();
                            _numbernamecell.Value = c.name.Trim();
                            _numberrow.Cells.Add(_numbernamecell);

                            DataGridViewColumn _numbernamedataGridViewColumn = new DataGridViewColumn();
                            _numbernamedataGridViewColumn.DataPropertyName = "name";
                            _numbernamedataGridViewColumn.HeaderText = "Field";
                            _numbernamedataGridViewColumn.CellTemplate = _numbernamecell;
                            _numbernamedataGridViewColumn.Name = "columnName";
                            _numbernamedataGridViewColumn.ReadOnly = true;
                            _numbernamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_numbernamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numberdesccell = new DataGridViewTextBoxCell();
                            _numberdesccell.Value = c.desc.Trim();
                            _numberrow.Cells.Add(_numberdesccell);

                            DataGridViewColumn _numberdescdataGridViewColumn = new DataGridViewColumn();
                            _numberdescdataGridViewColumn.DataPropertyName = "desc";
                            _numberdescdataGridViewColumn.HeaderText = "Desc";
                            _numberdescdataGridViewColumn.CellTemplate = _numberdesccell;
                            _numberdescdataGridViewColumn.Name = "columnDesc";
                            _numberdescdataGridViewColumn.ReadOnly = true;
                            _numberdescdataGridViewColumn.Visible = false;
                            _numberdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_numberdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _numberis_mandatorycell = new DataGridViewCheckBoxCell();
                            _numberis_mandatorycell.Value = c.is_mandatory;
                            _numberrow.Cells.Add(_numberis_mandatorycell);

                            DataGridViewColumn _numberis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _numberis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _numberis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _numberis_mandatorydataGridViewColumn.CellTemplate = _numberis_mandatorycell;
                            _numberis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _numberis_mandatorydataGridViewColumn.ReadOnly = true;
                            _numberis_mandatorydataGridViewColumn.Visible = false;
                            _numberis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_numberis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numberis_uniquecell = new DataGridViewTextBoxCell();
                            _numberis_uniquecell.Value = c.is_unique;
                            _numberrow.Cells.Add(_numberis_uniquecell);

                            DataGridViewColumn _numberis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _numberis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _numberis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _numberis_uniquedataGridViewColumn.CellTemplate = _numberis_uniquecell;
                            _numberis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _numberis_uniquedataGridViewColumn.ReadOnly = true;
                            _numberis_uniquedataGridViewColumn.Visible = false;
                            _numberis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_numberis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbervaluecell = new DataGridViewTextBoxCell();
                            _numbervaluecell.Value = c.value;
                            _numberrow.Cells.Add(_numbervaluecell);

                            DataGridViewColumn _numbervaluedataGridViewColumn = new DataGridViewColumn();
                            _numbervaluedataGridViewColumn.DataPropertyName = "value";
                            _numbervaluedataGridViewColumn.HeaderText = "Value";
                            _numbervaluedataGridViewColumn.CellTemplate = _numbervaluecell;
                            _numbervaluedataGridViewColumn.Name = "columnValue";
                            _numbervaluedataGridViewColumn.ReadOnly = false;
                            _numbervaluedataGridViewColumn.Width = 150;
                            _numbervaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_numbervaluedataGridViewColumn);
                            }

                            dataGridViewClientCustomizableFields.Rows.Add(_numberrow);
                            break;
                        case 3:
                            DataGridViewRow _stringrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _stringidcell = new DataGridViewTextBoxCell();
                            _stringidcell.Value = _rowid.ToString();
                            _stringrow.Cells.Add(_stringidcell);

                            DataGridViewColumn _stringiddataGridViewColumn = new DataGridViewColumn();
                            _stringiddataGridViewColumn.DataPropertyName = "_rowid";
                            _stringiddataGridViewColumn.HeaderText = "Id";
                            _stringiddataGridViewColumn.CellTemplate = _stringidcell;
                            _stringiddataGridViewColumn.Name = "columnId";
                            _stringiddataGridViewColumn.ReadOnly = true;
                            _stringiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_stringiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringnamecell = new DataGridViewTextBoxCell();
                            _stringnamecell.Value = c.name.Trim();
                            _stringrow.Cells.Add(_stringnamecell);

                            DataGridViewColumn _stringnamedataGridViewColumn = new DataGridViewColumn();
                            _stringnamedataGridViewColumn.DataPropertyName = "name";
                            _stringnamedataGridViewColumn.HeaderText = "Field";
                            _stringnamedataGridViewColumn.CellTemplate = _stringnamecell;
                            _stringnamedataGridViewColumn.Name = "columnName";
                            _stringnamedataGridViewColumn.ReadOnly = true;
                            _stringnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_stringnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringdesccell = new DataGridViewTextBoxCell();
                            _stringdesccell.Value = c.desc.Trim();
                            _stringrow.Cells.Add(_stringdesccell);

                            DataGridViewColumn _stringdescdataGridViewColumn = new DataGridViewColumn();
                            _stringdescdataGridViewColumn.DataPropertyName = "desc";
                            _stringdescdataGridViewColumn.HeaderText = "Desc";
                            _stringdescdataGridViewColumn.CellTemplate = _stringdesccell;
                            _stringdescdataGridViewColumn.Name = "columnDesc";
                            _stringdescdataGridViewColumn.ReadOnly = true;
                            _stringdescdataGridViewColumn.Visible = false;
                            _stringdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_stringdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _stringis_mandatorycell = new DataGridViewCheckBoxCell();
                            _stringis_mandatorycell.Value = c.is_mandatory;
                            _stringrow.Cells.Add(_stringis_mandatorycell);

                            DataGridViewColumn _stringis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _stringis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _stringis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _stringis_mandatorydataGridViewColumn.CellTemplate = _stringis_mandatorycell;
                            _stringis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _stringis_mandatorydataGridViewColumn.ReadOnly = true;
                            _stringis_mandatorydataGridViewColumn.Visible = false;
                            _stringis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_stringis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringis_uniquecell = new DataGridViewTextBoxCell();
                            _stringis_uniquecell.Value = c.is_unique;
                            _stringrow.Cells.Add(_stringis_uniquecell);

                            DataGridViewColumn _stringis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _stringis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _stringis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _stringis_uniquedataGridViewColumn.CellTemplate = _stringis_uniquecell;
                            _stringis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _stringis_uniquedataGridViewColumn.ReadOnly = true;
                            _stringis_uniquedataGridViewColumn.Visible = false;
                            _stringis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_stringis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringvaluecell = new DataGridViewTextBoxCell();
                            _stringvaluecell.Value = c.value;
                            _stringrow.Cells.Add(_stringvaluecell);

                            DataGridViewColumn _stringvaluedataGridViewColumn = new DataGridViewColumn();
                            _stringvaluedataGridViewColumn.DataPropertyName = "value";
                            _stringvaluedataGridViewColumn.HeaderText = "Value";
                            _stringvaluedataGridViewColumn.CellTemplate = _stringvaluecell;
                            _stringvaluedataGridViewColumn.Name = "columnValue";
                            _stringvaluedataGridViewColumn.ReadOnly = false;
                            _stringvaluedataGridViewColumn.Width = 150;
                            _stringvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_stringvaluedataGridViewColumn);
                            }

                            dataGridViewClientCustomizableFields.Rows.Add(_stringrow);
                            break;
                        case 4:
                            DataGridViewRow _daterow = new DataGridViewRow();

                            DataGridViewTextBoxCell _dateidcell = new DataGridViewTextBoxCell();
                            _dateidcell.Value = _rowid.ToString();
                            _daterow.Cells.Add(_dateidcell);

                            DataGridViewColumn _dateiddataGridViewColumn = new DataGridViewColumn();
                            _dateiddataGridViewColumn.DataPropertyName = "_rowid";
                            _dateiddataGridViewColumn.HeaderText = "Id";
                            _dateiddataGridViewColumn.CellTemplate = _dateidcell;
                            _dateiddataGridViewColumn.Name = "columnId";
                            _dateiddataGridViewColumn.ReadOnly = true;
                            _dateiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_dateiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datenamecell = new DataGridViewTextBoxCell();
                            _datenamecell.Value = c.name.Trim();
                            _daterow.Cells.Add(_datenamecell);

                            DataGridViewColumn _datenamedataGridViewColumn = new DataGridViewColumn();
                            _datenamedataGridViewColumn.DataPropertyName = "name";
                            _datenamedataGridViewColumn.HeaderText = "Field";
                            _datenamedataGridViewColumn.CellTemplate = _datenamecell;
                            _datenamedataGridViewColumn.Name = "columnName";
                            _datenamedataGridViewColumn.ReadOnly = true;
                            _datenamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_datenamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datedesccell = new DataGridViewTextBoxCell();
                            _datedesccell.Value = c.desc.Trim();
                            _daterow.Cells.Add(_datedesccell);

                            DataGridViewColumn _datedescdataGridViewColumn = new DataGridViewColumn();
                            _datedescdataGridViewColumn.DataPropertyName = "desc";
                            _datedescdataGridViewColumn.HeaderText = "Desc";
                            _datedescdataGridViewColumn.CellTemplate = _datedesccell;
                            _datedescdataGridViewColumn.Name = "columnDesc";
                            _datedescdataGridViewColumn.ReadOnly = true;
                            _datedescdataGridViewColumn.Visible = false;
                            _datedescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_datedescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _dateis_mandatorycell = new DataGridViewCheckBoxCell();
                            _dateis_mandatorycell.Value = c.is_mandatory;
                            _daterow.Cells.Add(_dateis_mandatorycell);

                            DataGridViewColumn _dateis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _dateis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _dateis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _dateis_mandatorydataGridViewColumn.CellTemplate = _dateis_mandatorycell;
                            _dateis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _dateis_mandatorydataGridViewColumn.ReadOnly = true;
                            _dateis_mandatorydataGridViewColumn.Visible = false;
                            _dateis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_dateis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _dateis_uniquecell = new DataGridViewTextBoxCell();
                            _dateis_uniquecell.Value = c.is_unique;
                            _daterow.Cells.Add(_dateis_uniquecell);

                            DataGridViewColumn _dateis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _dateis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _dateis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _dateis_uniquedataGridViewColumn.CellTemplate = _dateis_uniquecell;
                            _dateis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _dateis_uniquedataGridViewColumn.ReadOnly = true;
                            _dateis_uniquedataGridViewColumn.Visible = false;
                            _dateis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_dateis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datevaluecell = new DataGridViewTextBoxCell();
                            _datevaluecell.Value = c.value;
                            _daterow.Cells.Add(_datevaluecell);

                            DataGridViewColumn _datevaluedataGridViewColumn = new DataGridViewColumn();
                            _datevaluedataGridViewColumn.DataPropertyName = "value";
                            _datevaluedataGridViewColumn.HeaderText = "Value";
                            _datevaluedataGridViewColumn.CellTemplate = _datevaluecell;
                            _datevaluedataGridViewColumn.Name = "columnValue";
                            _datevaluedataGridViewColumn.ReadOnly = false;
                            _datevaluedataGridViewColumn.Width = 150;
                            _datevaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_datevaluedataGridViewColumn);
                            }

                            dataGridViewClientCustomizableFields.Rows.Add(_daterow);
                            break;
                        case 5:
                            List<AdvancedFieldsCollectionsModel> colpropsitems = rep.GetAdvancedFieldsCollectionsforField(c.field_id);

                            DataGridViewRow _collectionrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _collectionidcell = new DataGridViewTextBoxCell();
                            _collectionidcell.Value = _rowid.ToString();
                            _collectionrow.Cells.Add(_collectionidcell);

                            DataGridViewColumn _collectioniddataGridViewColumn = new DataGridViewColumn();
                            _collectioniddataGridViewColumn.DataPropertyName = "_rowid";
                            _collectioniddataGridViewColumn.HeaderText = "Id";
                            _collectioniddataGridViewColumn.CellTemplate = _collectionidcell;
                            _collectioniddataGridViewColumn.Name = "columnId";
                            _collectioniddataGridViewColumn.ReadOnly = true;
                            _collectioniddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_collectioniddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectionnamecell = new DataGridViewTextBoxCell();
                            _collectionnamecell.Value = c.name.Trim();
                            _collectionrow.Cells.Add(_collectionnamecell);

                            DataGridViewColumn _collectionnamedataGridViewColumn = new DataGridViewColumn();
                            _collectionnamedataGridViewColumn.DataPropertyName = "name";
                            _collectionnamedataGridViewColumn.HeaderText = "Field";
                            _collectionnamedataGridViewColumn.CellTemplate = _collectionnamecell;
                            _collectionnamedataGridViewColumn.Name = "columnName";
                            _collectionnamedataGridViewColumn.ReadOnly = true;
                            _collectionnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_collectionnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectiondesccell = new DataGridViewTextBoxCell();
                            _collectiondesccell.Value = c.desc.Trim();
                            _collectionrow.Cells.Add(_collectiondesccell);

                            DataGridViewColumn _collectiondescdataGridViewColumn = new DataGridViewColumn();
                            _collectiondescdataGridViewColumn.DataPropertyName = "desc";
                            _collectiondescdataGridViewColumn.HeaderText = "Desc";
                            _collectiondescdataGridViewColumn.CellTemplate = _collectiondesccell;
                            _collectiondescdataGridViewColumn.Name = "columnDesc";
                            _collectiondescdataGridViewColumn.ReadOnly = true;
                            _collectiondescdataGridViewColumn.Visible = false;
                            _collectiondescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_collectiondescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _collectionis_mandatorycell = new DataGridViewCheckBoxCell();
                            _collectionis_mandatorycell.Value = c.is_mandatory;
                            _collectionis_mandatorycell.FlatStyle = FlatStyle.Flat;
                            _collectionrow.Cells.Add(_collectionis_mandatorycell);

                            DataGridViewColumn _collectionis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _collectionis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _collectionis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _collectionis_mandatorydataGridViewColumn.CellTemplate = _collectionis_mandatorycell;
                            _collectionis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _collectionis_mandatorydataGridViewColumn.ReadOnly = true;
                            _collectionis_mandatorydataGridViewColumn.Visible = false;
                            _collectionis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_collectionis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectionis_uniquecell = new DataGridViewTextBoxCell();
                            _collectionis_uniquecell.Value = c.is_unique;
                            _collectionrow.Cells.Add(_collectionis_uniquecell);

                            DataGridViewColumn _collectionis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _collectionis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _collectionis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _collectionis_uniquedataGridViewColumn.CellTemplate = _collectionis_uniquecell;
                            _collectionis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _collectionis_uniquedataGridViewColumn.ReadOnly = true;
                            _collectionis_uniquedataGridViewColumn.Visible = false;
                            _collectionis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_collectionis_uniquedataGridViewColumn);
                            }

                            DataGridViewComboBoxCell _collectionvaluecell = new DataGridViewComboBoxCell();
                            _collectionvaluecell.DataSource = colpropsitems;
                            _collectionvaluecell.ValueMember = "advfieldscollectionid";
                            _collectionvaluecell.DisplayMember = "value";
                            _collectionvaluecell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                            _collectionvaluecell.FlatStyle = FlatStyle.Flat;
                            _collectionrow.Cells.Add(_collectionvaluecell);

                            DataGridViewColumn _collectionvaluedataGridViewColumn = new DataGridViewColumn();
                            _collectionvaluedataGridViewColumn.DataPropertyName = "value";
                            _collectionvaluedataGridViewColumn.HeaderText = "Value";
                            _collectionvaluedataGridViewColumn.CellTemplate = _collectionvaluecell;
                            _collectionvaluedataGridViewColumn.Name = "columnValue";
                            _collectionvaluedataGridViewColumn.ReadOnly = false;
                            _collectionvaluedataGridViewColumn.Width = 150;
                            _collectionvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_collectionvaluedataGridViewColumn);
                            }

                            dataGridViewClientCustomizableFields.Rows.Add(_collectionrow);
                            break;
                        case 6:
                            DataGridViewRow _clientrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _clientidcell = new DataGridViewTextBoxCell();
                            _clientidcell.Value = _rowid.ToString();
                            _clientrow.Cells.Add(_clientidcell);

                            DataGridViewColumn _clientiddataGridViewColumn = new DataGridViewColumn();
                            _clientiddataGridViewColumn.DataPropertyName = "_rowid";
                            _clientiddataGridViewColumn.HeaderText = "Id";
                            _clientiddataGridViewColumn.CellTemplate = _clientidcell;
                            _clientiddataGridViewColumn.Name = "columnId";
                            _clientiddataGridViewColumn.ReadOnly = true;
                            _clientiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_clientiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientnamecell = new DataGridViewTextBoxCell();
                            _clientnamecell.Value = c.name.Trim();
                            _clientrow.Cells.Add(_clientnamecell);

                            DataGridViewColumn _clientnamedataGridViewColumn = new DataGridViewColumn();
                            _clientnamedataGridViewColumn.DataPropertyName = "name";
                            _clientnamedataGridViewColumn.HeaderText = "Field";
                            _clientnamedataGridViewColumn.CellTemplate = _clientnamecell;
                            _clientnamedataGridViewColumn.Name = "columnName";
                            _clientnamedataGridViewColumn.ReadOnly = true;
                            _clientnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_clientnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientdesccell = new DataGridViewTextBoxCell();
                            _clientdesccell.Value = c.desc.Trim();
                            _clientrow.Cells.Add(_clientdesccell);

                            DataGridViewColumn _clientdescdataGridViewColumn = new DataGridViewColumn();
                            _clientdescdataGridViewColumn.DataPropertyName = "desc";
                            _clientdescdataGridViewColumn.HeaderText = "Desc";
                            _clientdescdataGridViewColumn.CellTemplate = _clientdesccell;
                            _clientdescdataGridViewColumn.Name = "columnDesc";
                            _clientdescdataGridViewColumn.ReadOnly = true;
                            _clientdescdataGridViewColumn.Visible = false;
                            _clientdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_clientdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _clientis_mandatorycell = new DataGridViewCheckBoxCell();
                            _clientis_mandatorycell.Value = c.is_mandatory;
                            _clientis_mandatorycell.FlatStyle = FlatStyle.Flat;
                            _clientrow.Cells.Add(_clientis_mandatorycell);

                            DataGridViewColumn _clientis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _clientis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _clientis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _clientis_mandatorydataGridViewColumn.CellTemplate = _clientis_mandatorycell;
                            _clientis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _clientis_mandatorydataGridViewColumn.ReadOnly = true;
                            _clientis_mandatorydataGridViewColumn.Visible = false;
                            _clientis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_clientis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientis_uniquecell = new DataGridViewTextBoxCell();
                            _clientis_uniquecell.Value = c.is_unique;
                            _clientrow.Cells.Add(_clientis_uniquecell);

                            DataGridViewColumn _clientis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _clientis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _clientis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _clientis_uniquedataGridViewColumn.CellTemplate = _clientis_uniquecell;
                            _clientis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _clientis_uniquedataGridViewColumn.ReadOnly = true;
                            _clientis_uniquedataGridViewColumn.Visible = false;
                            _clientis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_clientis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientvaluecell = new DataGridViewTextBoxCell();
                            _clientvaluecell.Value = c.value;
                            _clientrow.Cells.Add(_clientvaluecell);

                            DataGridViewColumn _clientvaluedataGridViewColumn = new DataGridViewColumn();
                            _clientvaluedataGridViewColumn.DataPropertyName = "value";
                            _clientvaluedataGridViewColumn.HeaderText = "Value";
                            _clientvaluedataGridViewColumn.CellTemplate = _clientvaluecell;
                            _clientvaluedataGridViewColumn.Name = "columnValue";
                            _clientvaluedataGridViewColumn.ReadOnly = false;
                            _clientvaluedataGridViewColumn.Width = 150;
                            _clientvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewClientCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewClientCustomizableFields.Columns.Add(_clientvaluedataGridViewColumn);
                            }

                            dataGridViewClientCustomizableFields.Rows.Add(_clientrow);
                            break;
                    }
                    _rowid++;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializedataGridViewLoanContractCustomizableFields()
        {
            try
            {
                dataGridViewLoanCustomizableFields.Rows.Clear();
                dataGridViewLoanCustomizableFields.AutoGenerateColumns = false;
                dataGridViewLoanCustomizableFields.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewLoanCustomizableFields.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewLoanCustomizableFields.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                int _rowid = 1;
                foreach (var c in _loancontractcustomfields)
                {
                    switch (c.type_id)
                    {
                        case 1:
                            DataGridViewRow _booleanrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _booleanidcell = new DataGridViewTextBoxCell();
                            _booleanidcell.Value = _rowid.ToString();
                            _booleanrow.Cells.Add(_booleanidcell);

                            DataGridViewColumn _booleaniddataGridViewColumn = new DataGridViewColumn();
                            _booleaniddataGridViewColumn.DataPropertyName = "_rowid";
                            _booleaniddataGridViewColumn.HeaderText = "Id";
                            _booleaniddataGridViewColumn.CellTemplate = _booleanidcell;
                            _booleaniddataGridViewColumn.Name = "columnId";
                            _booleaniddataGridViewColumn.ReadOnly = true;
                            _booleaniddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_booleaniddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleannamecell = new DataGridViewTextBoxCell();
                            _booleannamecell.Value = c.name.Trim();
                            _booleanrow.Cells.Add(_booleannamecell);

                            DataGridViewColumn _booleannamedataGridViewColumn = new DataGridViewColumn();
                            _booleannamedataGridViewColumn.DataPropertyName = "name";
                            _booleannamedataGridViewColumn.HeaderText = "Field";
                            _booleannamedataGridViewColumn.CellTemplate = _booleannamecell;
                            _booleannamedataGridViewColumn.Name = "columnName";
                            _booleannamedataGridViewColumn.ReadOnly = true;
                            _booleannamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_booleannamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleandesccell = new DataGridViewTextBoxCell();
                            _booleandesccell.Value = c.desc.Trim();
                            _booleanrow.Cells.Add(_booleandesccell);

                            DataGridViewColumn _booleandescdataGridViewColumn = new DataGridViewColumn();
                            _booleandescdataGridViewColumn.DataPropertyName = "desc";
                            _booleandescdataGridViewColumn.HeaderText = "Desc";
                            _booleandescdataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleandescdataGridViewColumn.Name = "columnDesc";
                            _booleandescdataGridViewColumn.ReadOnly = true;
                            _booleandescdataGridViewColumn.Visible = false;
                            _booleandescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_booleandescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _booleanis_mandatorycell = new DataGridViewCheckBoxCell();
                            _booleanis_mandatorycell.Value = c.is_mandatory;
                            _booleanis_mandatorycell.FlatStyle = FlatStyle.Flat;
                            _booleanrow.Cells.Add(_booleanis_mandatorycell);

                            DataGridViewColumn _booleanis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _booleanis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _booleanis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _booleanis_mandatorydataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleanis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _booleanis_mandatorydataGridViewColumn.ReadOnly = true;
                            _booleanis_mandatorydataGridViewColumn.Visible = false;
                            _booleanis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_booleanis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleanis_uniquecell = new DataGridViewTextBoxCell();
                            _booleanis_uniquecell.Value = c.is_unique;
                            _booleanrow.Cells.Add(_booleanis_uniquecell);

                            DataGridViewColumn _booleanis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _booleanis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _booleanis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _booleanis_uniquedataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleanis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _booleanis_uniquedataGridViewColumn.ReadOnly = true;
                            _booleanis_uniquedataGridViewColumn.Visible = false;
                            _booleanis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_booleanis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleanvaluecell = new DataGridViewTextBoxCell();
                            _booleanvaluecell.Value = c.value;
                            _booleanrow.Cells.Add(_booleanvaluecell);

                            DataGridViewColumn _booleanvaluedataGridViewColumn = new DataGridViewColumn();
                            _booleanvaluedataGridViewColumn.DataPropertyName = "value";
                            _booleanvaluedataGridViewColumn.HeaderText = "Value";
                            _booleanvaluedataGridViewColumn.CellTemplate = _booleannamecell;
                            _booleanvaluedataGridViewColumn.Name = "columnValue";
                            _booleanvaluedataGridViewColumn.ReadOnly = false;
                            _booleanvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            _booleanvaluedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_booleanvaluedataGridViewColumn);
                            }

                            dataGridViewLoanCustomizableFields.Rows.Add(_booleanrow);
                            break;
                        case 2:
                            DataGridViewRow _numberrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _numberidcell = new DataGridViewTextBoxCell();
                            _numberidcell.Value = _rowid.ToString();
                            _numberrow.Cells.Add(_numberidcell);

                            DataGridViewColumn _numberiddataGridViewColumn = new DataGridViewColumn();
                            _numberiddataGridViewColumn.DataPropertyName = "_rowid";
                            _numberiddataGridViewColumn.HeaderText = "Id";
                            _numberiddataGridViewColumn.CellTemplate = _numberidcell;
                            _numberiddataGridViewColumn.Name = "columnId";
                            _numberiddataGridViewColumn.ReadOnly = true;
                            _numberiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_numberiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbernamecell = new DataGridViewTextBoxCell();
                            _numbernamecell.Value = c.name.Trim();
                            _numberrow.Cells.Add(_numbernamecell);

                            DataGridViewColumn _numbernamedataGridViewColumn = new DataGridViewColumn();
                            _numbernamedataGridViewColumn.DataPropertyName = "name";
                            _numbernamedataGridViewColumn.HeaderText = "Field";
                            _numbernamedataGridViewColumn.CellTemplate = _numbernamecell;
                            _numbernamedataGridViewColumn.Name = "columnName";
                            _numbernamedataGridViewColumn.ReadOnly = true;
                            _numbernamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_numbernamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numberdesccell = new DataGridViewTextBoxCell();
                            _numberdesccell.Value = c.desc.Trim();
                            _numberrow.Cells.Add(_numberdesccell);

                            DataGridViewColumn _numberdescdataGridViewColumn = new DataGridViewColumn();
                            _numberdescdataGridViewColumn.DataPropertyName = "desc";
                            _numberdescdataGridViewColumn.HeaderText = "Desc";
                            _numberdescdataGridViewColumn.CellTemplate = _numberdesccell;
                            _numberdescdataGridViewColumn.Name = "columnDesc";
                            _numberdescdataGridViewColumn.ReadOnly = true;
                            _numberdescdataGridViewColumn.Visible = false;
                            _numberdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_numberdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _numberis_mandatorycell = new DataGridViewCheckBoxCell();
                            _numberis_mandatorycell.Value = c.is_mandatory;
                            _numberis_mandatorycell.FlatStyle = FlatStyle.Flat;
                            _numberrow.Cells.Add(_numberis_mandatorycell);

                            DataGridViewColumn _numberis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _numberis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _numberis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _numberis_mandatorydataGridViewColumn.CellTemplate = _numberis_mandatorycell;
                            _numberis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _numberis_mandatorydataGridViewColumn.ReadOnly = true;
                            _numberis_mandatorydataGridViewColumn.Visible = false;
                            _numberis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_numberis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numberis_uniquecell = new DataGridViewTextBoxCell();
                            _numberis_uniquecell.Value = c.is_unique;
                            _numberrow.Cells.Add(_numberis_uniquecell);

                            DataGridViewColumn _numberis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _numberis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _numberis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _numberis_uniquedataGridViewColumn.CellTemplate = _numberis_uniquecell;
                            _numberis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _numberis_uniquedataGridViewColumn.ReadOnly = true;
                            _numberis_uniquedataGridViewColumn.Visible = false;
                            _numberis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_numberis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbervaluecell = new DataGridViewTextBoxCell();
                            _numbervaluecell.Value = c.value;
                            _numberrow.Cells.Add(_numbervaluecell);

                            DataGridViewColumn _numbervaluedataGridViewColumn = new DataGridViewColumn();
                            _numbervaluedataGridViewColumn.DataPropertyName = "value";
                            _numbervaluedataGridViewColumn.HeaderText = "Value";
                            _numbervaluedataGridViewColumn.CellTemplate = _numbervaluecell;
                            _numbervaluedataGridViewColumn.Name = "columnValue";
                            _numbervaluedataGridViewColumn.ReadOnly = false;
                            _numbervaluedataGridViewColumn.Width = 150;
                            _numbervaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_numbervaluedataGridViewColumn);
                            }

                            dataGridViewLoanCustomizableFields.Rows.Add(_numberrow);
                            break;
                        case 3:
                            DataGridViewRow _stringrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _stringidcell = new DataGridViewTextBoxCell();
                            _stringidcell.Value = _rowid.ToString();
                            _stringrow.Cells.Add(_stringidcell);

                            DataGridViewColumn _stringiddataGridViewColumn = new DataGridViewColumn();
                            _stringiddataGridViewColumn.DataPropertyName = "_rowid";
                            _stringiddataGridViewColumn.HeaderText = "Id";
                            _stringiddataGridViewColumn.CellTemplate = _stringidcell;
                            _stringiddataGridViewColumn.Name = "columnId";
                            _stringiddataGridViewColumn.ReadOnly = true;
                            _stringiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_stringiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringnamecell = new DataGridViewTextBoxCell();
                            _stringnamecell.Value = c.name.Trim();
                            _stringrow.Cells.Add(_stringnamecell);

                            DataGridViewColumn _stringnamedataGridViewColumn = new DataGridViewColumn();
                            _stringnamedataGridViewColumn.DataPropertyName = "name";
                            _stringnamedataGridViewColumn.HeaderText = "Field";
                            _stringnamedataGridViewColumn.CellTemplate = _stringnamecell;
                            _stringnamedataGridViewColumn.Name = "columnName";
                            _stringnamedataGridViewColumn.ReadOnly = true;
                            _stringnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_stringnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringdesccell = new DataGridViewTextBoxCell();
                            _stringdesccell.Value = c.desc.Trim();
                            _stringrow.Cells.Add(_stringdesccell);

                            DataGridViewColumn _stringdescdataGridViewColumn = new DataGridViewColumn();
                            _stringdescdataGridViewColumn.DataPropertyName = "desc";
                            _stringdescdataGridViewColumn.HeaderText = "Desc";
                            _stringdescdataGridViewColumn.CellTemplate = _stringdesccell;
                            _stringdescdataGridViewColumn.Name = "columnDesc";
                            _stringdescdataGridViewColumn.ReadOnly = true;
                            _stringdescdataGridViewColumn.Visible = false;
                            _stringdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_stringdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _stringis_mandatorycell = new DataGridViewCheckBoxCell();
                            _stringis_mandatorycell.Value = c.is_mandatory;
                            _stringis_mandatorycell.FlatStyle = FlatStyle.Flat;
                            _stringrow.Cells.Add(_stringis_mandatorycell);

                            DataGridViewColumn _stringis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _stringis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _stringis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _stringis_mandatorydataGridViewColumn.CellTemplate = _stringis_mandatorycell;
                            _stringis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _stringis_mandatorydataGridViewColumn.ReadOnly = true;
                            _stringis_mandatorydataGridViewColumn.Visible = false;
                            _stringis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_stringis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringis_uniquecell = new DataGridViewTextBoxCell();
                            _stringis_uniquecell.Value = c.is_unique;
                            _stringrow.Cells.Add(_stringis_uniquecell);

                            DataGridViewColumn _stringis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _stringis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _stringis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _stringis_uniquedataGridViewColumn.CellTemplate = _stringis_uniquecell;
                            _stringis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _stringis_uniquedataGridViewColumn.ReadOnly = true;
                            _stringis_uniquedataGridViewColumn.Visible = false;
                            _stringis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_stringis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringvaluecell = new DataGridViewTextBoxCell();
                            _stringvaluecell.Value = c.value;
                            _stringrow.Cells.Add(_stringvaluecell);

                            DataGridViewColumn _stringvaluedataGridViewColumn = new DataGridViewColumn();
                            _stringvaluedataGridViewColumn.DataPropertyName = "value";
                            _stringvaluedataGridViewColumn.HeaderText = "Value";
                            _stringvaluedataGridViewColumn.CellTemplate = _stringvaluecell;
                            _stringvaluedataGridViewColumn.Name = "columnValue";
                            _stringvaluedataGridViewColumn.ReadOnly = false;
                            _stringvaluedataGridViewColumn.Width = 150;
                            _stringvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_stringvaluedataGridViewColumn);
                            }

                            dataGridViewLoanCustomizableFields.Rows.Add(_stringrow);
                            break;
                        case 4:
                            DataGridViewRow _daterow = new DataGridViewRow();

                            DataGridViewTextBoxCell _dateidcell = new DataGridViewTextBoxCell();
                            _dateidcell.Value = _rowid.ToString();
                            _daterow.Cells.Add(_dateidcell);

                            DataGridViewColumn _dateiddataGridViewColumn = new DataGridViewColumn();
                            _dateiddataGridViewColumn.DataPropertyName = "_rowid";
                            _dateiddataGridViewColumn.HeaderText = "Id";
                            _dateiddataGridViewColumn.CellTemplate = _dateidcell;
                            _dateiddataGridViewColumn.Name = "columnId";
                            _dateiddataGridViewColumn.ReadOnly = true;
                            _dateiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_dateiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datenamecell = new DataGridViewTextBoxCell();
                            _datenamecell.Value = c.name.Trim();
                            _daterow.Cells.Add(_datenamecell);

                            DataGridViewColumn _datenamedataGridViewColumn = new DataGridViewColumn();
                            _datenamedataGridViewColumn.DataPropertyName = "name";
                            _datenamedataGridViewColumn.HeaderText = "Field";
                            _datenamedataGridViewColumn.CellTemplate = _datenamecell;
                            _datenamedataGridViewColumn.Name = "columnName";
                            _datenamedataGridViewColumn.ReadOnly = true;
                            _datenamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_datenamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datedesccell = new DataGridViewTextBoxCell();
                            _datedesccell.Value = c.desc.Trim();
                            _daterow.Cells.Add(_datedesccell);

                            DataGridViewColumn _datedescdataGridViewColumn = new DataGridViewColumn();
                            _datedescdataGridViewColumn.DataPropertyName = "desc";
                            _datedescdataGridViewColumn.HeaderText = "Desc";
                            _datedescdataGridViewColumn.CellTemplate = _datedesccell;
                            _datedescdataGridViewColumn.Name = "columnDesc";
                            _datedescdataGridViewColumn.ReadOnly = true;
                            _datedescdataGridViewColumn.Visible = false;
                            _datedescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_datedescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _dateis_mandatorycell = new DataGridViewCheckBoxCell();
                            _dateis_mandatorycell.Value = c.is_mandatory;
                            _dateis_mandatorycell.FlatStyle = FlatStyle.Flat;
                            _daterow.Cells.Add(_dateis_mandatorycell);

                            DataGridViewColumn _dateis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _dateis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _dateis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _dateis_mandatorydataGridViewColumn.CellTemplate = _dateis_mandatorycell;
                            _dateis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _dateis_mandatorydataGridViewColumn.ReadOnly = true;
                            _dateis_mandatorydataGridViewColumn.Visible = false;
                            _dateis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_dateis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _dateis_uniquecell = new DataGridViewTextBoxCell();
                            _dateis_uniquecell.Value = c.is_unique;
                            _daterow.Cells.Add(_dateis_uniquecell);

                            DataGridViewColumn _dateis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _dateis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _dateis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _dateis_uniquedataGridViewColumn.CellTemplate = _dateis_uniquecell;
                            _dateis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _dateis_uniquedataGridViewColumn.ReadOnly = true;
                            _dateis_uniquedataGridViewColumn.Visible = false;
                            _dateis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_dateis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datevaluecell = new DataGridViewTextBoxCell();
                            _datevaluecell.Value = c.value;
                            _daterow.Cells.Add(_datevaluecell);

                            DataGridViewColumn _datevaluedataGridViewColumn = new DataGridViewColumn();
                            _datevaluedataGridViewColumn.DataPropertyName = "value";
                            _datevaluedataGridViewColumn.HeaderText = "Value";
                            _datevaluedataGridViewColumn.CellTemplate = _datevaluecell;
                            _datevaluedataGridViewColumn.Name = "columnValue";
                            _datevaluedataGridViewColumn.ReadOnly = false;
                            _datevaluedataGridViewColumn.Width = 150;
                            _datevaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_datevaluedataGridViewColumn);
                            }

                            dataGridViewLoanCustomizableFields.Rows.Add(_daterow);
                            break;
                        case 5:
                            List<AdvancedFieldsCollectionsModel> colpropsitems = rep.GetAdvancedFieldsCollectionsforField(c.field_id);

                            DataGridViewRow _collectionrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _collectionidcell = new DataGridViewTextBoxCell();
                            _collectionidcell.Value = _rowid.ToString();
                            _collectionrow.Cells.Add(_collectionidcell);

                            DataGridViewColumn _collectioniddataGridViewColumn = new DataGridViewColumn();
                            _collectioniddataGridViewColumn.DataPropertyName = "_rowid";
                            _collectioniddataGridViewColumn.HeaderText = "Id";
                            _collectioniddataGridViewColumn.CellTemplate = _collectionidcell;
                            _collectioniddataGridViewColumn.Name = "columnId";
                            _collectioniddataGridViewColumn.ReadOnly = true;
                            _collectioniddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_collectioniddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectionnamecell = new DataGridViewTextBoxCell();
                            _collectionnamecell.Value = c.name.Trim();
                            _collectionrow.Cells.Add(_collectionnamecell);

                            DataGridViewColumn _collectionnamedataGridViewColumn = new DataGridViewColumn();
                            _collectionnamedataGridViewColumn.DataPropertyName = "name";
                            _collectionnamedataGridViewColumn.HeaderText = "Field";
                            _collectionnamedataGridViewColumn.CellTemplate = _collectionnamecell;
                            _collectionnamedataGridViewColumn.Name = "columnName";
                            _collectionnamedataGridViewColumn.ReadOnly = true;
                            _collectionnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_collectionnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectiondesccell = new DataGridViewTextBoxCell();
                            _collectiondesccell.Value = c.desc.Trim();
                            _collectionrow.Cells.Add(_collectiondesccell);

                            DataGridViewColumn _collectiondescdataGridViewColumn = new DataGridViewColumn();
                            _collectiondescdataGridViewColumn.DataPropertyName = "desc";
                            _collectiondescdataGridViewColumn.HeaderText = "Desc";
                            _collectiondescdataGridViewColumn.CellTemplate = _collectiondesccell;
                            _collectiondescdataGridViewColumn.Name = "columnDesc";
                            _collectiondescdataGridViewColumn.ReadOnly = true;
                            _collectiondescdataGridViewColumn.Visible = false;
                            _collectiondescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_collectiondescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _collectionis_mandatorycell = new DataGridViewCheckBoxCell();
                            _collectionis_mandatorycell.Value = c.is_mandatory;
                            _collectionrow.Cells.Add(_collectionis_mandatorycell);

                            DataGridViewColumn _collectionis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _collectionis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _collectionis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _collectionis_mandatorydataGridViewColumn.CellTemplate = _collectionis_mandatorycell;
                            _collectionis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _collectionis_mandatorydataGridViewColumn.ReadOnly = true;
                            _collectionis_mandatorydataGridViewColumn.Visible = false;
                            _collectionis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_collectionis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectionis_uniquecell = new DataGridViewTextBoxCell();
                            _collectionis_uniquecell.Value = c.is_unique;
                            _collectionrow.Cells.Add(_collectionis_uniquecell);

                            DataGridViewColumn _collectionis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _collectionis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _collectionis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _collectionis_uniquedataGridViewColumn.CellTemplate = _collectionis_uniquecell;
                            _collectionis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _collectionis_uniquedataGridViewColumn.ReadOnly = true;
                            _collectionis_uniquedataGridViewColumn.Visible = false;
                            _collectionis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_collectionis_uniquedataGridViewColumn);
                            }

                            DataGridViewComboBoxCell _collectionvaluecell = new DataGridViewComboBoxCell();
                            _collectionvaluecell.DataSource = colpropsitems;
                            _collectionvaluecell.ValueMember = "advfieldscollectionid";
                            _collectionvaluecell.DisplayMember = "value";
                            _collectionvaluecell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                            _collectionvaluecell.FlatStyle = FlatStyle.Flat;
                            _collectionrow.Cells.Add(_collectionvaluecell);

                            DataGridViewColumn _collectionvaluedataGridViewColumn = new DataGridViewColumn();
                            _collectionvaluedataGridViewColumn.DataPropertyName = "value";
                            _collectionvaluedataGridViewColumn.HeaderText = "Value";
                            _collectionvaluedataGridViewColumn.CellTemplate = _collectionvaluecell;
                            _collectionvaluedataGridViewColumn.Name = "columnValue";
                            _collectionvaluedataGridViewColumn.ReadOnly = false;
                            _collectionvaluedataGridViewColumn.Width = 150;
                            _collectionvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_collectionvaluedataGridViewColumn);
                            }

                            dataGridViewLoanCustomizableFields.Rows.Add(_collectionrow);
                            break;
                        case 6:
                            DataGridViewRow _clientrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _clientidcell = new DataGridViewTextBoxCell();
                            _clientidcell.Value = _rowid.ToString();
                            _clientrow.Cells.Add(_clientidcell);

                            DataGridViewColumn _clientiddataGridViewColumn = new DataGridViewColumn();
                            _clientiddataGridViewColumn.DataPropertyName = "_rowid";
                            _clientiddataGridViewColumn.HeaderText = "Id";
                            _clientiddataGridViewColumn.CellTemplate = _clientidcell;
                            _clientiddataGridViewColumn.Name = "columnId";
                            _clientiddataGridViewColumn.ReadOnly = true;
                            _clientiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_clientiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientnamecell = new DataGridViewTextBoxCell();
                            _clientnamecell.Value = c.name.Trim();
                            _clientrow.Cells.Add(_clientnamecell);

                            DataGridViewColumn _clientnamedataGridViewColumn = new DataGridViewColumn();
                            _clientnamedataGridViewColumn.DataPropertyName = "name";
                            _clientnamedataGridViewColumn.HeaderText = "Field";
                            _clientnamedataGridViewColumn.CellTemplate = _clientnamecell;
                            _clientnamedataGridViewColumn.Name = "columnName";
                            _clientnamedataGridViewColumn.ReadOnly = true;
                            _clientnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_clientnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientdesccell = new DataGridViewTextBoxCell();
                            _clientdesccell.Value = c.desc.Trim();
                            _clientrow.Cells.Add(_clientdesccell);

                            DataGridViewColumn _clientdescdataGridViewColumn = new DataGridViewColumn();
                            _clientdescdataGridViewColumn.DataPropertyName = "desc";
                            _clientdescdataGridViewColumn.HeaderText = "Desc";
                            _clientdescdataGridViewColumn.CellTemplate = _clientdesccell;
                            _clientdescdataGridViewColumn.Name = "columnDesc";
                            _clientdescdataGridViewColumn.ReadOnly = true;
                            _clientdescdataGridViewColumn.Visible = false;
                            _clientdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_clientdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _clientis_mandatorycell = new DataGridViewCheckBoxCell();
                            _clientis_mandatorycell.Value = c.is_mandatory;
                            _clientrow.Cells.Add(_clientis_mandatorycell);

                            DataGridViewColumn _clientis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _clientis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _clientis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _clientis_mandatorydataGridViewColumn.CellTemplate = _clientis_mandatorycell;
                            _clientis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _clientis_mandatorydataGridViewColumn.ReadOnly = true;
                            _clientis_mandatorydataGridViewColumn.Visible = false;
                            _clientis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_clientis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientis_uniquecell = new DataGridViewTextBoxCell();
                            _clientis_uniquecell.Value = c.is_unique;
                            _clientrow.Cells.Add(_clientis_uniquecell);

                            DataGridViewColumn _clientis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _clientis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _clientis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _clientis_uniquedataGridViewColumn.CellTemplate = _clientis_uniquecell;
                            _clientis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _clientis_uniquedataGridViewColumn.ReadOnly = true;
                            _clientis_uniquedataGridViewColumn.Visible = false;
                            _clientis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_clientis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientvaluecell = new DataGridViewTextBoxCell();
                            _clientvaluecell.Value = c.value;
                            _clientrow.Cells.Add(_clientvaluecell);

                            DataGridViewColumn _clientvaluedataGridViewColumn = new DataGridViewColumn();
                            _clientvaluedataGridViewColumn.DataPropertyName = "value";
                            _clientvaluedataGridViewColumn.HeaderText = "Value";
                            _clientvaluedataGridViewColumn.CellTemplate = _clientvaluecell;
                            _clientvaluedataGridViewColumn.Name = "columnValue";
                            _clientvaluedataGridViewColumn.ReadOnly = false;
                            _clientvaluedataGridViewColumn.Width = 150;
                            _clientvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewLoanCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewLoanCustomizableFields.Columns.Add(_clientvaluedataGridViewColumn);
                            }

                            dataGridViewLoanCustomizableFields.Rows.Add(_clientrow);
                            break;
                    }
                    _rowid++;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializedataGridViewSavingContractCustomizableFields()
        {
            try
            {
                dataGridViewSavingsCustomizableFields.Rows.Clear();
                dataGridViewSavingsCustomizableFields.AutoGenerateColumns = false;
                dataGridViewSavingsCustomizableFields.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSavingsCustomizableFields.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewSavingsCustomizableFields.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                int _rowid = 1;
                foreach (var c in _savingcontractcustomfields)
                {
                    switch (c.type_id)
                    {
                        case 1:
                            DataGridViewRow _booleanrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _booleanidcell = new DataGridViewTextBoxCell();
                            _booleanidcell.Value = _rowid.ToString();
                            _booleanrow.Cells.Add(_booleanidcell);

                            DataGridViewColumn _booleaniddataGridViewColumn = new DataGridViewColumn();
                            _booleaniddataGridViewColumn.DataPropertyName = "_rowid";
                            _booleaniddataGridViewColumn.HeaderText = "Id";
                            _booleaniddataGridViewColumn.CellTemplate = _booleanidcell;
                            _booleaniddataGridViewColumn.Name = "columnId";
                            _booleaniddataGridViewColumn.ReadOnly = true;
                            _booleaniddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_booleaniddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleannamecell = new DataGridViewTextBoxCell();
                            _booleannamecell.Value = c.name.Trim();
                            _booleanrow.Cells.Add(_booleannamecell);

                            DataGridViewColumn _booleannamedataGridViewColumn = new DataGridViewColumn();
                            _booleannamedataGridViewColumn.DataPropertyName = "name";
                            _booleannamedataGridViewColumn.HeaderText = "Field";
                            _booleannamedataGridViewColumn.CellTemplate = _booleannamecell;
                            _booleannamedataGridViewColumn.Name = "columnName";
                            _booleannamedataGridViewColumn.ReadOnly = true;
                            _booleannamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_booleannamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleandesccell = new DataGridViewTextBoxCell();
                            _booleandesccell.Value = c.desc.Trim();
                            _booleanrow.Cells.Add(_booleandesccell);

                            DataGridViewColumn _booleandescdataGridViewColumn = new DataGridViewColumn();
                            _booleandescdataGridViewColumn.DataPropertyName = "desc";
                            _booleandescdataGridViewColumn.HeaderText = "Desc";
                            _booleandescdataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleandescdataGridViewColumn.Name = "columnDesc";
                            _booleandescdataGridViewColumn.ReadOnly = true;
                            _booleandescdataGridViewColumn.Visible = false;
                            _booleandescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_booleandescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _booleanis_mandatorycell = new DataGridViewCheckBoxCell();
                            _booleanis_mandatorycell.Value = c.is_mandatory;
                            _booleanrow.Cells.Add(_booleanis_mandatorycell);

                            DataGridViewColumn _booleanis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _booleanis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _booleanis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _booleanis_mandatorydataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleanis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _booleanis_mandatorydataGridViewColumn.ReadOnly = true;
                            _booleanis_mandatorydataGridViewColumn.Visible = false;
                            _booleanis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_booleanis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleanis_uniquecell = new DataGridViewTextBoxCell();
                            _booleanis_uniquecell.Value = c.is_unique;
                            _booleanrow.Cells.Add(_booleanis_uniquecell);

                            DataGridViewColumn _booleanis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _booleanis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _booleanis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _booleanis_uniquedataGridViewColumn.CellTemplate = _booleandesccell;
                            _booleanis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _booleanis_uniquedataGridViewColumn.ReadOnly = true;
                            _booleanis_uniquedataGridViewColumn.Visible = false;
                            _booleanis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_booleanis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _booleanvaluecell = new DataGridViewTextBoxCell();
                            _booleanvaluecell.Value = c.value;
                            _booleanrow.Cells.Add(_booleanvaluecell);

                            DataGridViewColumn _booleanvaluedataGridViewColumn = new DataGridViewColumn();
                            _booleanvaluedataGridViewColumn.DataPropertyName = "value";
                            _booleanvaluedataGridViewColumn.HeaderText = "Value";
                            _booleanvaluedataGridViewColumn.CellTemplate = _booleannamecell;
                            _booleanvaluedataGridViewColumn.Name = "columnValue";
                            _booleanvaluedataGridViewColumn.ReadOnly = false;
                            _booleanvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            _booleanvaluedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_booleanvaluedataGridViewColumn);
                            }

                            dataGridViewSavingsCustomizableFields.Rows.Add(_booleanrow);
                            break;
                        case 2:
                            DataGridViewRow _numberrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _numberidcell = new DataGridViewTextBoxCell();
                            _numberidcell.Value = _rowid.ToString();
                            _numberrow.Cells.Add(_numberidcell);

                            DataGridViewColumn _numberiddataGridViewColumn = new DataGridViewColumn();
                            _numberiddataGridViewColumn.DataPropertyName = "_rowid";
                            _numberiddataGridViewColumn.HeaderText = "Id";
                            _numberiddataGridViewColumn.CellTemplate = _numberidcell;
                            _numberiddataGridViewColumn.Name = "columnId";
                            _numberiddataGridViewColumn.ReadOnly = true;
                            _numberiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_numberiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbernamecell = new DataGridViewTextBoxCell();
                            _numbernamecell.Value = c.name.Trim();
                            _numberrow.Cells.Add(_numbernamecell);

                            DataGridViewColumn _numbernamedataGridViewColumn = new DataGridViewColumn();
                            _numbernamedataGridViewColumn.DataPropertyName = "name";
                            _numbernamedataGridViewColumn.HeaderText = "Field";
                            _numbernamedataGridViewColumn.CellTemplate = _numbernamecell;
                            _numbernamedataGridViewColumn.Name = "columnName";
                            _numbernamedataGridViewColumn.ReadOnly = true;
                            _numbernamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_numbernamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numberdesccell = new DataGridViewTextBoxCell();
                            _numberdesccell.Value = c.desc.Trim();
                            _numberrow.Cells.Add(_numberdesccell);

                            DataGridViewColumn _numberdescdataGridViewColumn = new DataGridViewColumn();
                            _numberdescdataGridViewColumn.DataPropertyName = "desc";
                            _numberdescdataGridViewColumn.HeaderText = "Desc";
                            _numberdescdataGridViewColumn.CellTemplate = _numberdesccell;
                            _numberdescdataGridViewColumn.Name = "columnDesc";
                            _numberdescdataGridViewColumn.ReadOnly = true;
                            _numberdescdataGridViewColumn.Visible = false;
                            _numberdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_numberdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _numberis_mandatorycell = new DataGridViewCheckBoxCell();
                            _numberis_mandatorycell.Value = c.is_mandatory;
                            _numberrow.Cells.Add(_numberis_mandatorycell);

                            DataGridViewColumn _numberis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _numberis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _numberis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _numberis_mandatorydataGridViewColumn.CellTemplate = _numberis_mandatorycell;
                            _numberis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _numberis_mandatorydataGridViewColumn.ReadOnly = true;
                            _numberis_mandatorydataGridViewColumn.Visible = false;
                            _numberis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_numberis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numberis_uniquecell = new DataGridViewTextBoxCell();
                            _numberis_uniquecell.Value = c.is_unique;
                            _numberrow.Cells.Add(_numberis_uniquecell);

                            DataGridViewColumn _numberis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _numberis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _numberis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _numberis_uniquedataGridViewColumn.CellTemplate = _numberis_uniquecell;
                            _numberis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _numberis_uniquedataGridViewColumn.ReadOnly = true;
                            _numberis_uniquedataGridViewColumn.Visible = false;
                            _numberis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_numberis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbervaluecell = new DataGridViewTextBoxCell();
                            _numbervaluecell.Value = c.value;
                            _numberrow.Cells.Add(_numbervaluecell);

                            DataGridViewColumn _numbervaluedataGridViewColumn = new DataGridViewColumn();
                            _numbervaluedataGridViewColumn.DataPropertyName = "value";
                            _numbervaluedataGridViewColumn.HeaderText = "Value";
                            _numbervaluedataGridViewColumn.CellTemplate = _numbervaluecell;
                            _numbervaluedataGridViewColumn.Name = "columnValue";
                            _numbervaluedataGridViewColumn.ReadOnly = false;
                            _numbervaluedataGridViewColumn.Width = 150;
                            _numbervaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_numbervaluedataGridViewColumn);
                            }

                            dataGridViewSavingsCustomizableFields.Rows.Add(_numberrow);
                            break;
                        case 3:
                            DataGridViewRow _stringrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _stringidcell = new DataGridViewTextBoxCell();
                            _stringidcell.Value = _rowid.ToString();
                            _stringrow.Cells.Add(_stringidcell);

                            DataGridViewColumn _stringiddataGridViewColumn = new DataGridViewColumn();
                            _stringiddataGridViewColumn.DataPropertyName = "_rowid";
                            _stringiddataGridViewColumn.HeaderText = "Id";
                            _stringiddataGridViewColumn.CellTemplate = _stringidcell;
                            _stringiddataGridViewColumn.Name = "columnId";
                            _stringiddataGridViewColumn.ReadOnly = true;
                            _stringiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_stringiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringnamecell = new DataGridViewTextBoxCell();
                            _stringnamecell.Value = c.name.Trim();
                            _stringrow.Cells.Add(_stringnamecell);

                            DataGridViewColumn _stringnamedataGridViewColumn = new DataGridViewColumn();
                            _stringnamedataGridViewColumn.DataPropertyName = "name";
                            _stringnamedataGridViewColumn.HeaderText = "Field";
                            _stringnamedataGridViewColumn.CellTemplate = _stringnamecell;
                            _stringnamedataGridViewColumn.Name = "columnName";
                            _stringnamedataGridViewColumn.ReadOnly = true;
                            _stringnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_stringnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringdesccell = new DataGridViewTextBoxCell();
                            _stringdesccell.Value = c.desc.Trim();
                            _stringrow.Cells.Add(_stringdesccell);

                            DataGridViewColumn _stringdescdataGridViewColumn = new DataGridViewColumn();
                            _stringdescdataGridViewColumn.DataPropertyName = "desc";
                            _stringdescdataGridViewColumn.HeaderText = "Desc";
                            _stringdescdataGridViewColumn.CellTemplate = _stringdesccell;
                            _stringdescdataGridViewColumn.Name = "columnDesc";
                            _stringdescdataGridViewColumn.ReadOnly = true;
                            _stringdescdataGridViewColumn.Visible = false;
                            _stringdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_stringdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _stringis_mandatorycell = new DataGridViewCheckBoxCell();
                            _stringis_mandatorycell.Value = c.is_mandatory;
                            _stringrow.Cells.Add(_stringis_mandatorycell);

                            DataGridViewColumn _stringis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _stringis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _stringis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _stringis_mandatorydataGridViewColumn.CellTemplate = _stringis_mandatorycell;
                            _stringis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _stringis_mandatorydataGridViewColumn.ReadOnly = true;
                            _stringis_mandatorydataGridViewColumn.Visible = false;
                            _stringis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_stringis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringis_uniquecell = new DataGridViewTextBoxCell();
                            _stringis_uniquecell.Value = c.is_unique;
                            _stringrow.Cells.Add(_stringis_uniquecell);

                            DataGridViewColumn _stringis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _stringis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _stringis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _stringis_uniquedataGridViewColumn.CellTemplate = _stringis_uniquecell;
                            _stringis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _stringis_uniquedataGridViewColumn.ReadOnly = true;
                            _stringis_uniquedataGridViewColumn.Visible = false;
                            _stringis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_stringis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringvaluecell = new DataGridViewTextBoxCell();
                            _stringvaluecell.Value = c.value;
                            _stringrow.Cells.Add(_stringvaluecell);

                            DataGridViewColumn _stringvaluedataGridViewColumn = new DataGridViewColumn();
                            _stringvaluedataGridViewColumn.DataPropertyName = "value";
                            _stringvaluedataGridViewColumn.HeaderText = "Value";
                            _stringvaluedataGridViewColumn.CellTemplate = _stringvaluecell;
                            _stringvaluedataGridViewColumn.Name = "columnValue";
                            _stringvaluedataGridViewColumn.ReadOnly = false;
                            _stringvaluedataGridViewColumn.Width = 150;
                            _stringvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_stringvaluedataGridViewColumn);
                            }

                            dataGridViewSavingsCustomizableFields.Rows.Add(_stringrow);
                            break;
                        case 4:
                            DataGridViewRow _daterow = new DataGridViewRow();

                            DataGridViewTextBoxCell _dateidcell = new DataGridViewTextBoxCell();
                            _dateidcell.Value = _rowid.ToString();
                            _daterow.Cells.Add(_dateidcell);

                            DataGridViewColumn _dateiddataGridViewColumn = new DataGridViewColumn();
                            _dateiddataGridViewColumn.DataPropertyName = "_rowid";
                            _dateiddataGridViewColumn.HeaderText = "Id";
                            _dateiddataGridViewColumn.CellTemplate = _dateidcell;
                            _dateiddataGridViewColumn.Name = "columnId";
                            _dateiddataGridViewColumn.ReadOnly = true;
                            _dateiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_dateiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datenamecell = new DataGridViewTextBoxCell();
                            _datenamecell.Value = c.name.Trim();
                            _daterow.Cells.Add(_datenamecell);

                            DataGridViewColumn _datenamedataGridViewColumn = new DataGridViewColumn();
                            _datenamedataGridViewColumn.DataPropertyName = "name";
                            _datenamedataGridViewColumn.HeaderText = "Field";
                            _datenamedataGridViewColumn.CellTemplate = _datenamecell;
                            _datenamedataGridViewColumn.Name = "columnName";
                            _datenamedataGridViewColumn.ReadOnly = true;
                            _datenamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_datenamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datedesccell = new DataGridViewTextBoxCell();
                            _datedesccell.Value = c.desc.Trim();
                            _daterow.Cells.Add(_datedesccell);

                            DataGridViewColumn _datedescdataGridViewColumn = new DataGridViewColumn();
                            _datedescdataGridViewColumn.DataPropertyName = "desc";
                            _datedescdataGridViewColumn.HeaderText = "Desc";
                            _datedescdataGridViewColumn.CellTemplate = _datedesccell;
                            _datedescdataGridViewColumn.Name = "columnDesc";
                            _datedescdataGridViewColumn.ReadOnly = true;
                            _datedescdataGridViewColumn.Visible = false;
                            _datedescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_datedescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _dateis_mandatorycell = new DataGridViewCheckBoxCell();
                            _dateis_mandatorycell.Value = c.is_mandatory;
                            _daterow.Cells.Add(_dateis_mandatorycell);

                            DataGridViewColumn _dateis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _dateis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _dateis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _dateis_mandatorydataGridViewColumn.CellTemplate = _dateis_mandatorycell;
                            _dateis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _dateis_mandatorydataGridViewColumn.ReadOnly = true;
                            _dateis_mandatorydataGridViewColumn.Visible = false;
                            _dateis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_dateis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _dateis_uniquecell = new DataGridViewTextBoxCell();
                            _dateis_uniquecell.Value = c.is_unique;
                            _daterow.Cells.Add(_dateis_uniquecell);

                            DataGridViewColumn _dateis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _dateis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _dateis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _dateis_uniquedataGridViewColumn.CellTemplate = _dateis_uniquecell;
                            _dateis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _dateis_uniquedataGridViewColumn.ReadOnly = true;
                            _dateis_uniquedataGridViewColumn.Visible = false;
                            _dateis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_dateis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datevaluecell = new DataGridViewTextBoxCell();
                            _datevaluecell.Value = c.value;
                            _daterow.Cells.Add(_datevaluecell);

                            DataGridViewColumn _datevaluedataGridViewColumn = new DataGridViewColumn();
                            _datevaluedataGridViewColumn.DataPropertyName = "value";
                            _datevaluedataGridViewColumn.HeaderText = "Value";
                            _datevaluedataGridViewColumn.CellTemplate = _datevaluecell;
                            _datevaluedataGridViewColumn.Name = "columnValue";
                            _datevaluedataGridViewColumn.ReadOnly = false;
                            _datevaluedataGridViewColumn.Width = 150;
                            _datevaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_datevaluedataGridViewColumn);
                            }

                            dataGridViewSavingsCustomizableFields.Rows.Add(_daterow);
                            break;
                        case 5:
                            List<AdvancedFieldsCollectionsModel> colpropsitems = rep.GetAdvancedFieldsCollectionsforField(c.field_id);

                            DataGridViewRow _collectionrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _collectionidcell = new DataGridViewTextBoxCell();
                            _collectionidcell.Value = _rowid.ToString();
                            _collectionrow.Cells.Add(_collectionidcell);

                            DataGridViewColumn _collectioniddataGridViewColumn = new DataGridViewColumn();
                            _collectioniddataGridViewColumn.DataPropertyName = "_rowid";
                            _collectioniddataGridViewColumn.HeaderText = "Id";
                            _collectioniddataGridViewColumn.CellTemplate = _collectionidcell;
                            _collectioniddataGridViewColumn.Name = "columnId";
                            _collectioniddataGridViewColumn.ReadOnly = true;
                            _collectioniddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_collectioniddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectionnamecell = new DataGridViewTextBoxCell();
                            _collectionnamecell.Value = c.name.Trim();
                            _collectionrow.Cells.Add(_collectionnamecell);

                            DataGridViewColumn _collectionnamedataGridViewColumn = new DataGridViewColumn();
                            _collectionnamedataGridViewColumn.DataPropertyName = "name";
                            _collectionnamedataGridViewColumn.HeaderText = "Field";
                            _collectionnamedataGridViewColumn.CellTemplate = _collectionnamecell;
                            _collectionnamedataGridViewColumn.Name = "columnName";
                            _collectionnamedataGridViewColumn.ReadOnly = true;
                            _collectionnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_collectionnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectiondesccell = new DataGridViewTextBoxCell();
                            _collectiondesccell.Value = c.desc.Trim();
                            _collectionrow.Cells.Add(_collectiondesccell);

                            DataGridViewColumn _collectiondescdataGridViewColumn = new DataGridViewColumn();
                            _collectiondescdataGridViewColumn.DataPropertyName = "desc";
                            _collectiondescdataGridViewColumn.HeaderText = "Desc";
                            _collectiondescdataGridViewColumn.CellTemplate = _collectiondesccell;
                            _collectiondescdataGridViewColumn.Name = "columnDesc";
                            _collectiondescdataGridViewColumn.ReadOnly = true;
                            _collectiondescdataGridViewColumn.Visible = false;
                            _collectiondescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_collectiondescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _collectionis_mandatorycell = new DataGridViewCheckBoxCell();
                            _collectionis_mandatorycell.Value = c.is_mandatory;
                            _collectionrow.Cells.Add(_collectionis_mandatorycell);

                            DataGridViewColumn _collectionis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _collectionis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _collectionis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _collectionis_mandatorydataGridViewColumn.CellTemplate = _collectionis_mandatorycell;
                            _collectionis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _collectionis_mandatorydataGridViewColumn.ReadOnly = true;
                            _collectionis_mandatorydataGridViewColumn.Visible = false;
                            _collectionis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_collectionis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectionis_uniquecell = new DataGridViewTextBoxCell();
                            _collectionis_uniquecell.Value = c.is_unique;
                            _collectionrow.Cells.Add(_collectionis_uniquecell);

                            DataGridViewColumn _collectionis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _collectionis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _collectionis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _collectionis_uniquedataGridViewColumn.CellTemplate = _collectionis_uniquecell;
                            _collectionis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _collectionis_uniquedataGridViewColumn.ReadOnly = true;
                            _collectionis_uniquedataGridViewColumn.Visible = false;
                            _collectionis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_collectionis_uniquedataGridViewColumn);
                            }

                            DataGridViewComboBoxCell _collectionvaluecell = new DataGridViewComboBoxCell();
                            _collectionvaluecell.DataSource = colpropsitems;
                            _collectionvaluecell.ValueMember = "advfieldscollectionid";
                            _collectionvaluecell.DisplayMember = "value";
                            _collectionvaluecell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                            _collectionvaluecell.FlatStyle = FlatStyle.Flat;
                            _collectionrow.Cells.Add(_collectionvaluecell);

                            DataGridViewColumn _collectionvaluedataGridViewColumn = new DataGridViewColumn();
                            _collectionvaluedataGridViewColumn.DataPropertyName = "value";
                            _collectionvaluedataGridViewColumn.HeaderText = "Value";
                            _collectionvaluedataGridViewColumn.CellTemplate = _collectionvaluecell;
                            _collectionvaluedataGridViewColumn.Name = "columnValue";
                            _collectionvaluedataGridViewColumn.ReadOnly = false;
                            _collectionvaluedataGridViewColumn.Width = 150;
                            _collectionvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_collectionvaluedataGridViewColumn);
                            }

                            dataGridViewSavingsCustomizableFields.Rows.Add(_collectionrow);
                            break;
                        case 6:
                            DataGridViewRow _clientrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _clientidcell = new DataGridViewTextBoxCell();
                            _clientidcell.Value = _rowid.ToString();
                            _clientrow.Cells.Add(_clientidcell);

                            DataGridViewColumn _clientiddataGridViewColumn = new DataGridViewColumn();
                            _clientiddataGridViewColumn.DataPropertyName = "_rowid";
                            _clientiddataGridViewColumn.HeaderText = "Id";
                            _clientiddataGridViewColumn.CellTemplate = _clientidcell;
                            _clientiddataGridViewColumn.Name = "columnId";
                            _clientiddataGridViewColumn.ReadOnly = true;
                            _clientiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnId"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_clientiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientnamecell = new DataGridViewTextBoxCell();
                            _clientnamecell.Value = c.name.Trim();
                            _clientrow.Cells.Add(_clientnamecell);

                            DataGridViewColumn _clientnamedataGridViewColumn = new DataGridViewColumn();
                            _clientnamedataGridViewColumn.DataPropertyName = "name";
                            _clientnamedataGridViewColumn.HeaderText = "Field";
                            _clientnamedataGridViewColumn.CellTemplate = _clientnamecell;
                            _clientnamedataGridViewColumn.Name = "columnName";
                            _clientnamedataGridViewColumn.ReadOnly = true;
                            _clientnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnName"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_clientnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientdesccell = new DataGridViewTextBoxCell();
                            _clientdesccell.Value = c.desc.Trim();
                            _clientrow.Cells.Add(_clientdesccell);

                            DataGridViewColumn _clientdescdataGridViewColumn = new DataGridViewColumn();
                            _clientdescdataGridViewColumn.DataPropertyName = "desc";
                            _clientdescdataGridViewColumn.HeaderText = "Desc";
                            _clientdescdataGridViewColumn.CellTemplate = _clientdesccell;
                            _clientdescdataGridViewColumn.Name = "columnDesc";
                            _clientdescdataGridViewColumn.ReadOnly = true;
                            _clientdescdataGridViewColumn.Visible = false;
                            _clientdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnDesc"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_clientdescdataGridViewColumn);
                            }

                            DataGridViewCheckBoxCell _clientis_mandatorycell = new DataGridViewCheckBoxCell();
                            _clientis_mandatorycell.Value = c.is_mandatory;
                            _clientrow.Cells.Add(_clientis_mandatorycell);

                            DataGridViewColumn _clientis_mandatorydataGridViewColumn = new DataGridViewColumn();
                            _clientis_mandatorydataGridViewColumn.DataPropertyName = "is_mandatory";
                            _clientis_mandatorydataGridViewColumn.HeaderText = "Is Mandatory";
                            _clientis_mandatorydataGridViewColumn.CellTemplate = _clientis_mandatorycell;
                            _clientis_mandatorydataGridViewColumn.Name = "columnIsMandatory";
                            _clientis_mandatorydataGridViewColumn.ReadOnly = true;
                            _clientis_mandatorydataGridViewColumn.Visible = false;
                            _clientis_mandatorydataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsMandatory"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_clientis_mandatorydataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientis_uniquecell = new DataGridViewTextBoxCell();
                            _clientis_uniquecell.Value = c.is_unique;
                            _clientrow.Cells.Add(_clientis_uniquecell);

                            DataGridViewColumn _clientis_uniquedataGridViewColumn = new DataGridViewColumn();
                            _clientis_uniquedataGridViewColumn.DataPropertyName = "is_unique";
                            _clientis_uniquedataGridViewColumn.HeaderText = "Is Unique";
                            _clientis_uniquedataGridViewColumn.CellTemplate = _clientis_uniquecell;
                            _clientis_uniquedataGridViewColumn.Name = "columnIsUnique";
                            _clientis_uniquedataGridViewColumn.ReadOnly = true;
                            _clientis_uniquedataGridViewColumn.Visible = false;
                            _clientis_uniquedataGridViewColumn.Width = 150;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnIsUnique"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_clientis_uniquedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientvaluecell = new DataGridViewTextBoxCell();
                            _clientvaluecell.Value = c.value;
                            _clientrow.Cells.Add(_clientvaluecell);

                            DataGridViewColumn _clientvaluedataGridViewColumn = new DataGridViewColumn();
                            _clientvaluedataGridViewColumn.DataPropertyName = "value";
                            _clientvaluedataGridViewColumn.HeaderText = "Value";
                            _clientvaluedataGridViewColumn.CellTemplate = _clientvaluecell;
                            _clientvaluedataGridViewColumn.Name = "columnValue";
                            _clientvaluedataGridViewColumn.ReadOnly = false;
                            _clientvaluedataGridViewColumn.Width = 150;
                            _clientvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewSavingsCustomizableFields.Columns.Contains("columnValue"))
                            {
                                dataGridViewSavingsCustomizableFields.Columns.Add(_clientvaluedataGridViewColumn);
                            }

                            dataGridViewSavingsCustomizableFields.Rows.Add(_clientrow);
                            break;
                    }
                    _rowid++;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshLoanContractCustomizableFieldsGrid()
        {
            try
            {
                _loancontractcustomfields = new List<ClientCustomizableFieldsModel>();

                if (_loancontract != null)
                {
                    var advancedfieldsquery = from af in rep.GetLoanContractCustomizableFields(5, _loancontract.contractid)
                                              select af;
                    _loancontractcustomfields = advancedfieldsquery.ToList();

                    if (_loancontractcustomfields.Count == 0)
                    {
                        var _advancedfieldsquery = from af in rep.GetLoanContractCustomizableFields(5)
                                                   select af;
                        _loancontractcustomfields = _advancedfieldsquery.ToList();
                    }

                    InitializedataGridViewLoanContractCustomizableFields();

                    groupBox49.Text = _loancontractcustomfields.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshSavingContractCustomizableFieldsGrid()
        {
            try
            {
                _savingcontractcustomfields = new List<ClientCustomizableFieldsModel>();

                if (_savingscontract != null)
                {
                    var advancedfieldsquery = from af in rep.GetSavingContractCustomizableFields(9, _savingscontract.savingcontractid)
                                              select af;
                    _savingcontractcustomfields = advancedfieldsquery.ToList();

                    InitializedataGridViewSavingContractCustomizableFields();

                    groupBox33.Text = _savingcontractcustomfields.Count.ToString();
                }
                if (_savingscontract == null)
                {
                    var _advancedfieldsquery = from af in rep.GetSavingContractCustomizableFields(9)
                                               select af;
                    _savingcontractcustomfields = _advancedfieldsquery.ToList();

                    InitializedataGridViewSavingContractCustomizableFields();

                    groupBox33.Text = _savingcontractcustomfields.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshSavingsContractsLoanGrid()
        {
            try
            {
                List<ClientLoanContractModel> _loan_contracts_list = new List<ClientLoanContractModel>();
                bindingSourceSavingsLoanContracts.DataSource = null;

                if (_clientModel != null)
                {

                    var _statusquery = from rl in rep.GetAllStatuses()
                                       select rl;
                    List<StatusModel> _statuses = _statusquery.ToList();
                    DataGridViewComboBoxColumn colCboxLoanStatus = new DataGridViewComboBoxColumn();
                    colCboxLoanStatus.HeaderText = "Status";
                    colCboxLoanStatus.Name = "cbLoanStatus";
                    colCboxLoanStatus.DataSource = _statuses;
                    // The display member is the name column in the column datasource  
                    colCboxLoanStatus.DisplayMember = "status_name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxLoanStatus.DataPropertyName = "status";
                    // The value member is the primary key of the parent table  
                    colCboxLoanStatus.ValueMember = "statusid";
                    colCboxLoanStatus.MaxDropDownItems = 10;
                    colCboxLoanStatus.Width = 50;
                    colCboxLoanStatus.DisplayIndex = 6;
                    colCboxLoanStatus.MinimumWidth = 5;
                    colCboxLoanStatus.FlatStyle = FlatStyle.Flat;
                    colCboxLoanStatus.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxLoanStatus.ReadOnly = true;
                    //colCboxLoanStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingsLoanContracts.Columns.Contains("cbLoanStatus"))
                    {
                        dataGridViewSavingsLoanContracts.Columns.Add(colCboxLoanStatus);
                    }

                    var _installmenttypesquery = from rl in rep.GetAllInstallmentTypes()
                                                 select rl;
                    List<InstallmentTypesModel> _installmenttyes = _installmenttypesquery.ToList();
                    DataGridViewComboBoxColumn colCboxInstallmentType = new DataGridViewComboBoxColumn();
                    colCboxInstallmentType.HeaderText = "Installment Type";
                    colCboxInstallmentType.Name = "cbInstallmentType";
                    colCboxInstallmentType.DataSource = _installmenttyes;
                    // The display member is the name column in the column datasource  
                    colCboxInstallmentType.DisplayMember = "name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxInstallmentType.DataPropertyName = "installment_type";
                    // The value member is the primary key of the parent table  
                    colCboxInstallmentType.ValueMember = "installmenttypesid";
                    colCboxInstallmentType.MaxDropDownItems = 10;
                    colCboxInstallmentType.Width = 100;
                    colCboxInstallmentType.DisplayIndex = 7;
                    colCboxInstallmentType.MinimumWidth = 5;
                    colCboxInstallmentType.FlatStyle = FlatStyle.Flat;
                    colCboxInstallmentType.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxInstallmentType.ReadOnly = true;
                    //colCboxInstallmentType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingsLoanContracts.Columns.Contains("cbInstallmentType"))
                    {
                        dataGridViewSavingsLoanContracts.Columns.Add(colCboxInstallmentType);
                    }

                    var _currenciesquery = from rl in rep.GetCurrenciesList()
                                           select rl;
                    List<CurrencyModel> _currencies = _currenciesquery.ToList();
                    DataGridViewComboBoxColumn colCboxCurrency = new DataGridViewComboBoxColumn();
                    colCboxCurrency.HeaderText = "Currency";
                    colCboxCurrency.Name = "cbCurrency";
                    colCboxCurrency.DataSource = _currencies;
                    // The display member is the name column in the column datasource  
                    colCboxCurrency.DisplayMember = "code";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxCurrency.DataPropertyName = "currency_id";
                    // The value member is the primary key of the parent table  
                    colCboxCurrency.ValueMember = "currencyid";
                    colCboxCurrency.MaxDropDownItems = 10;
                    colCboxCurrency.Width = 50;
                    colCboxCurrency.DisplayIndex = 8;
                    colCboxCurrency.MinimumWidth = 5;
                    colCboxCurrency.FlatStyle = FlatStyle.Flat;
                    colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxCurrency.ReadOnly = true;
                    colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingsLoanContracts.Columns.Contains("cbCurrency"))
                    {
                        dataGridViewSavingsLoanContracts.Columns.Add(colCboxCurrency);
                    }

                    var _contractsquery = from af in rep.GetAllClientLoanContracts(_clientModel.tierid)
                                          select af;
                    _loan_contracts_list = _contractsquery.ToList();
                    bindingSourceSavingsLoanContracts.DataSource = _loan_contracts_list;
                    dataGridViewSavingsLoanContracts.AutoGenerateColumns = false;
                    dataGridViewSavingsLoanContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewSavingsLoanContracts.DataSource = bindingSourceSavingsLoanContracts;
                    groupBox43.Text = bindingSourceSavingsLoanContracts.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshSavingsContractsGrid()
        {
            try
            {
                _savingscontractslist = new List<ClientSavingContractModel>();
                bindingSourceSavingContracts.DataSource = null;

                if (_clientModel != null)
                {
                    var _statusquery = from rl in rep.GetAllStatuses()
                                       select rl;
                    List<StatusModel> _statuses = _statusquery.ToList();
                    DataGridViewComboBoxColumn colCboxStatuses = new DataGridViewComboBoxColumn();
                    colCboxStatuses.HeaderText = "Status";
                    colCboxStatuses.Name = "cbStatus";
                    colCboxStatuses.DataSource = _statuses;
                    // The display member is the name column in the column datasource  
                    colCboxStatuses.DisplayMember = "status_name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxStatuses.DataPropertyName = "status";
                    // The value member is the primary key of the parent table  
                    colCboxStatuses.ValueMember = "statusid";
                    colCboxStatuses.MaxDropDownItems = 10;
                    colCboxStatuses.Width = 80;
                    colCboxStatuses.DisplayIndex = 4;
                    colCboxStatuses.MinimumWidth = 5;
                    colCboxStatuses.FlatStyle = FlatStyle.Flat;
                    colCboxStatuses.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxStatuses.ReadOnly = true;
                    //colCboxStatuses.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingContracts.Columns.Contains("cbStatus"))
                    {
                        dataGridViewSavingContracts.Columns.Add(colCboxStatuses);
                    }

                    var _currenciesquery = from rl in rep.GetCurrenciesList()
                                           select rl;
                    List<CurrencyModel> _currencies = _currenciesquery.ToList();
                    DataGridViewComboBoxColumn colCboxCurrency = new DataGridViewComboBoxColumn();
                    colCboxCurrency.HeaderText = "Currency";
                    colCboxCurrency.Name = "cbCurrency";
                    colCboxCurrency.DataSource = _currencies;
                    // The display member is the name column in the column datasource  
                    colCboxCurrency.DisplayMember = "code";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxCurrency.DataPropertyName = "currency_id";
                    // The value member is the primary key of the parent table  
                    colCboxCurrency.ValueMember = "currencyid";
                    colCboxCurrency.MaxDropDownItems = 10;
                    colCboxCurrency.Width = 100;
                    colCboxCurrency.DisplayIndex = 5;
                    colCboxCurrency.MinimumWidth = 5;
                    colCboxCurrency.FlatStyle = FlatStyle.Flat;
                    colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxCurrency.ReadOnly = true;
                    colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingContracts.Columns.Contains("cbCurrency"))
                    {
                        dataGridViewSavingContracts.Columns.Add(colCboxCurrency);
                    }

                    var _savingscontractsquery = from af in rep.GetAllClientSavingContracts(_clientModel.tierid)
                                                 select af;
                    _savingscontractslist = _savingscontractsquery.ToList();
                    bindingSourceSavingContracts.DataSource = _savingscontractslist;
                    dataGridViewSavingContracts.AutoGenerateColumns = false;
                    dataGridViewSavingContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewSavingContracts.DataSource = bindingSourceSavingContracts;
                    groupBoxSavings.Text = "Savings     " + bindingSourceSavingContracts.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshLoanContractsGrid()
        {
            try
            {
                List<ClientLoanContractModel> _loan_contracts_list = new List<ClientLoanContractModel>();
                bindingSourceLoanContracts.DataSource = null;

                if (_clientModel != null)
                {
                    var _statusquery = from rl in rep.GetAllStatuses()
                                       select rl;
                    List<StatusModel> _statuses = _statusquery.ToList();
                    DataGridViewComboBoxColumn colCboxLoanStatus = new DataGridViewComboBoxColumn();
                    colCboxLoanStatus.HeaderText = "Status";
                    colCboxLoanStatus.Name = "cbLoanStatus";
                    colCboxLoanStatus.DataSource = _statuses;
                    // The display member is the name column in the column datasource  
                    colCboxLoanStatus.DisplayMember = "status_name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxLoanStatus.DataPropertyName = "status";
                    // The value member is the primary key of the parent table  
                    colCboxLoanStatus.ValueMember = "statusid";
                    colCboxLoanStatus.MaxDropDownItems = 10;
                    colCboxLoanStatus.Width = 60;
                    colCboxLoanStatus.DisplayIndex = 6;
                    colCboxLoanStatus.MinimumWidth = 5;
                    colCboxLoanStatus.FlatStyle = FlatStyle.Flat;
                    colCboxLoanStatus.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxLoanStatus.ReadOnly = true;
                    colCboxLoanStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewLoanContracts.Columns.Contains("cbLoanStatus"))
                    {
                        dataGridViewLoanContracts.Columns.Add(colCboxLoanStatus);
                    }

                    var _installmenttypesquery = from rl in rep.GetAllInstallmentTypes()
                                                 select rl;
                    List<InstallmentTypesModel> _installmenttyes = _installmenttypesquery.ToList();
                    DataGridViewComboBoxColumn colCboxInstallmentType = new DataGridViewComboBoxColumn();
                    colCboxInstallmentType.HeaderText = "installment_type";
                    colCboxInstallmentType.Name = "cbInstallmentType";
                    colCboxInstallmentType.DataSource = _installmenttyes;
                    // The display member is the name column in the column datasource  
                    colCboxInstallmentType.DisplayMember = "name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxInstallmentType.DataPropertyName = "installment_type";
                    // The value member is the primary key of the parent table  
                    colCboxInstallmentType.ValueMember = "installmenttypesid";
                    colCboxInstallmentType.MaxDropDownItems = 10;
                    colCboxInstallmentType.Width = 100;
                    colCboxInstallmentType.DisplayIndex = 7;
                    colCboxInstallmentType.MinimumWidth = 5;
                    colCboxInstallmentType.FlatStyle = FlatStyle.Flat;
                    colCboxInstallmentType.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxInstallmentType.ReadOnly = true;
                    colCboxInstallmentType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewLoanContracts.Columns.Contains("cbInstallmentType"))
                    {
                        dataGridViewLoanContracts.Columns.Add(colCboxInstallmentType);
                    }

                    var _currenciesquery = from rl in rep.GetCurrenciesList()
                                           select rl;
                    List<CurrencyModel> _currencies = _currenciesquery.ToList();
                    DataGridViewComboBoxColumn colCboxCurrency = new DataGridViewComboBoxColumn();
                    colCboxCurrency.HeaderText = "Currency";
                    colCboxCurrency.Name = "cbCurrency";
                    colCboxCurrency.DataSource = _currencies;
                    // The display member is the name column in the column datasource  
                    colCboxCurrency.DisplayMember = "code";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxCurrency.DataPropertyName = "currency_id";
                    // The value member is the primary key of the parent table  
                    colCboxCurrency.ValueMember = "currencyid";
                    colCboxCurrency.MaxDropDownItems = 10;
                    colCboxCurrency.Width = 70;
                    colCboxCurrency.DisplayIndex = 8;
                    colCboxCurrency.MinimumWidth = 5;
                    colCboxCurrency.FlatStyle = FlatStyle.Flat;
                    colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxCurrency.ReadOnly = true;
                    //colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewLoanContracts.Columns.Contains("cbCurrency"))
                    {
                        //dataGridViewLoanContracts.Columns.Add(colCboxCurrency);
                    }

                    var _contractsquery = from af in rep.GetAllClientLoanContracts(_clientModel.tierid)
                                          select af;
                    _loan_contracts_list = _contractsquery.ToList();
                    bindingSourceLoanContracts.DataSource = _loan_contracts_list;
                    dataGridViewLoanContracts.AutoGenerateColumns = false;
                    dataGridViewLoanContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewLoanContracts.DataSource = bindingSourceLoanContracts;
                    groupBoxLoans.Text = "Loans     " + bindingSourceLoanContracts.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshLoanContractCollateralsGrid()
        {
            try
            {
                bindingSourceLoanCollaterals.DataSource = null;
                if (_loancontract != null)
                {
                    var _contractcollateralsquery = from ds in rep.GetCollateralPropertyValuesforContract(_loancontract.contractid)
                                                    select ds;
                    _contractcollaterals = _contractcollateralsquery.ToList();
                    bindingSourceLoanCollaterals.DataSource = _contractcollaterals;
                    dataGridViewLoanCollaterals.AutoGenerateColumns = false;
                    dataGridViewLoanCollaterals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewLoanCollaterals.DataSource = bindingSourceLoanCollaterals;
                    groupBox11.Text = "Collaterals  " + bindingSourceLoanCollaterals.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewLoanCollaterals.Rows)
                    {
                        dataGridViewLoanCollaterals.Rows[dataGridViewLoanCollaterals.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewLoanCollaterals.Rows.Count - 1;
                        bindingSourceLoanCollaterals.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshSavingsContractEventsGrid()
        {
            try
            {
                bindingSourceSavingsEvents.DataSource = null;
                if (_savingscontract != null)
                {
                    List<SavingsEventsModel> _savingsevents = new List<SavingsEventsModel>();

                    var _paymentmethodsquery = from rl in rep.GetAllPaymentMethods()
                                               select rl;
                    List<PaymentMethodModel> _paymentmethods = _paymentmethodsquery.ToList();
                    DataGridViewComboBoxColumn colCboxPaymentMethod = new DataGridViewComboBoxColumn();
                    colCboxPaymentMethod.HeaderText = "Payment_Method";
                    colCboxPaymentMethod.Name = "cbPaymentMethod";
                    colCboxPaymentMethod.DataSource = _paymentmethods;
                    // The display member is the name column in the column datasource  
                    colCboxPaymentMethod.DisplayMember = "name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxPaymentMethod.DataPropertyName = "savings_method";
                    // The value member is the primary key of the parent table  
                    colCboxPaymentMethod.ValueMember = "paymentmethodid";
                    colCboxPaymentMethod.MaxDropDownItems = 10;
                    colCboxPaymentMethod.Width = 100;
                    colCboxPaymentMethod.DisplayIndex = 7;
                    colCboxPaymentMethod.MinimumWidth = 5;
                    colCboxPaymentMethod.FlatStyle = FlatStyle.Flat;
                    //colCboxPaymentMethod.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxPaymentMethod.ReadOnly = true;
                    //colCboxPaymentMethod.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingsEvents.Columns.Contains("cbPaymentMethod"))
                    {
                        dataGridViewSavingsEvents.Columns.Add(colCboxPaymentMethod);
                    }

                    var _usersquery = from rl in rep.GetCombinedUserModelList()
                                      select rl;
                    List<UserModel_dto> _users = _usersquery.ToList();
                    DataGridViewComboBoxColumn colCboxUser = new DataGridViewComboBoxColumn();
                    colCboxUser.HeaderText = "User";
                    colCboxUser.Name = "cbUser";
                    colCboxUser.DataSource = _users;
                    // The display member is the name column in the column datasource  
                    colCboxUser.DisplayMember = "full_name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxUser.DataPropertyName = "user_id";
                    // The value member is the primary key of the parent table  
                    colCboxUser.ValueMember = "userid";
                    colCboxUser.MaxDropDownItems = 10;
                    colCboxUser.Width = 80;
                    colCboxUser.DisplayIndex = 8;
                    colCboxUser.MinimumWidth = 5;
                    colCboxUser.FlatStyle = FlatStyle.Flat;
                    colCboxUser.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxUser.ReadOnly = true;
                    //colCboxUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewSavingsEvents.Columns.Contains("cbUser"))
                    {
                        dataGridViewSavingsEvents.Columns.Add(colCboxUser);
                    }

                    var _savingseventsquery = from se in rep.GetSavingsContractEvents(_savingscontract.savingcontractid)
                                              select se;
                    _savingsevents = _savingseventsquery.ToList();
                    bindingSourceSavingsEvents.DataSource = _savingsevents;
                    dataGridViewSavingsEvents.AutoGenerateColumns = false;
                    dataGridViewSavingsEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewSavingsEvents.DataSource = bindingSourceSavingsEvents;
                    groupBox46.Text = bindingSourceSavingsEvents.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSavingsEvents.Rows)
                    {
                        dataGridViewSavingsEvents.Rows[dataGridViewSavingsEvents.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSavingsEvents.Rows.Count - 1;
                        bindingSourceSavingsEvents.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshLoanContractsInstallmentsGrid()
        {
            errorProvider1.Clear();
            if (IsInstallmentDetailsValid())
            {
                try
                {

                    InstallmentTypesModel _installment_type = (InstallmentTypesModel)cboInstallmentTypes.SelectedItem;
                    _installments = null;

                    switch (_installment_type.installmenttypesid)
                    {
                        case 1:
                            if (_loancontract != null)
                            {
                                bindingSourceInstallments.DataSource = null;
                                _installments = new List<InstallmentsModel>();
                                double principle = double.Parse(txtLoanAmount.Text.Trim());
                                double interest = double.Parse(txtInterestRatePerPeriod.Text.Trim());
                                int months = int.Parse(txtNoofInstallments.Text.Trim());
                                double monthly = principle / months;
                                DateTime start_date = DateTime.Parse(dtpPreferredFirstInstallmentDate.Value.ToString());

                                var endingBalance = principle;
                                var rate = interest;
                                var count = 1;
                                var _start_date = start_date;

                                while (count <= months)
                                {
                                    var interestPaid = endingBalance * (rate / 100);
                                    var _totalprinciplePaid = monthly + interestPaid;
                                    endingBalance -= _totalprinciplePaid;

                                    InstallmentsModel _installment = new InstallmentsModel();
                                    _installment.expected_date = _start_date.AddMonths(1);
                                    _installment._expected_date = _start_date.AddMonths(1);
                                    _installment.interest_repayment = decimal.Parse(interestPaid.ToString());
                                    _installment.capital_repayment = decimal.Parse(monthly.ToString());
                                    _installment.contract_id = _loancontract.contractid;
                                    _installment.number = count;
                                    _installment.paid_interest = 0M;
                                    _installment.paid_capital = 0M;
                                    _installment.fees_unpaid = 0M;
                                    _installment.paid_date = null;
                                    _installment.paid_fees = 0M;
                                    if (!string.IsNullOrEmpty(txtLoanPurpose.Text))
                                    {
                                        _installment.comment = Utils.ConvertFirstLetterToUpper(txtLoanPurpose.Text.Trim());
                                    }
                                    _installment.pending = false;
                                    _installment.start_date = _start_date;
                                    _installment._start_date = _start_date;
                                    _installment.olb = decimal.Parse(endingBalance.ToString());
                                    _installment._olb = decimal.Parse(endingBalance.ToString());
                                    _installment.installment_monthly_total = _totalprinciplePaid;
                                    _installment.installmentid = count;

                                    count++;

                                    _installments.Add(_installment);

                                    _start_date = _start_date.AddMonths(1);
                                }

                                groupBox13.Text = _installments.Count.ToString();

                                InstallmentsModel _installment_totals = new InstallmentsModel();
                                _installment_totals.installmentid = null;
                                _installment_totals.interest_repayment = _installments.Sum(i => i.paid_interest);
                                _installment_totals.capital_repayment = _installments.Sum(i => i.paid_capital);
                                _installment_totals.installment_monthly_total = _installments.Sum(i => i.installment_monthly_total);
                                _installment_totals._olb = null;
                                _installment_totals._expected_date = null;

                                _installments.Add(_installment_totals);

                                bindingSourceInstallments.DataSource = _installments;
                                dataGridViewInstallments.AutoGenerateColumns = false;
                                dataGridViewInstallments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                dataGridViewInstallments.DataSource = bindingSourceInstallments;
                            }
                            break;
                        case 5:
                            if (_loancontract != null)
                            {
                                bindingSourceInstallments.DataSource = null;
                                _installments = new List<InstallmentsModel>();
                                double principle = double.Parse(txtLoanAmount.Text.Trim());
                                double interest = double.Parse(txtInterestRatePerPeriod.Text.Trim());
                                int months = int.Parse(txtNoofInstallments.Text.Trim());
                                double monthly = principle / months;
                                DateTime start_date = DateTime.Parse(dtpPreferredFirstInstallmentDate.Value.ToString());

                                var endingBalance = principle;
                                var rate = interest;
                                var count = 1;
                                var _start_date = start_date;

                                while (count <= months)
                                {
                                    var interestPaid = endingBalance * (rate / 100);
                                    var _totalprinciplePaid = monthly + interestPaid;
                                    endingBalance -= _totalprinciplePaid;

                                    InstallmentsModel _installment = new InstallmentsModel();
                                    _installment.expected_date = _start_date.AddYears(1);
                                    _installment._expected_date = _start_date.AddYears(1);
                                    _installment.interest_repayment = decimal.Parse(interestPaid.ToString());
                                    _installment.capital_repayment = decimal.Parse(monthly.ToString());
                                    _installment.contract_id = _loancontract.contractid;
                                    _installment.number = count;
                                    _installment.paid_interest = 0M;
                                    _installment.paid_capital = 0M;
                                    _installment.fees_unpaid = 0M;
                                    _installment.paid_date = null;
                                    _installment.paid_fees = 0M;
                                    if (!string.IsNullOrEmpty(txtLoanPurpose.Text))
                                    {
                                        _installment.comment = Utils.ConvertFirstLetterToUpper(txtLoanPurpose.Text.Trim());
                                    }
                                    _installment.pending = false;
                                    _installment.start_date = _start_date;
                                    _installment._start_date = _start_date;
                                    _installment.olb = decimal.Parse(endingBalance.ToString());
                                    _installment._olb = decimal.Parse(endingBalance.ToString());
                                    _installment.installment_monthly_total = _totalprinciplePaid;
                                    _installment.installmentid = count;

                                    count++;

                                    _installments.Add(_installment);

                                    _start_date = _start_date.AddYears(1);
                                }

                                groupBox13.Text = _installments.Count.ToString();

                                InstallmentsModel _installment_totals = new InstallmentsModel();
                                _installment_totals.installmentid = null;
                                _installment_totals.interest_repayment = _installments.Sum(i => i.paid_interest);
                                _installment_totals.capital_repayment = _installments.Sum(i => i.paid_capital);
                                _installment_totals.installment_monthly_total = _installments.Sum(i => i.installment_monthly_total);
                                _installment_totals._olb = null;
                                _installment_totals._expected_date = null;

                                _installments.Add(_installment_totals);

                                bindingSourceInstallments.DataSource = _installments;
                                dataGridViewInstallments.AutoGenerateColumns = false;
                                dataGridViewInstallments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                dataGridViewInstallments.DataSource = bindingSourceInstallments;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SaveLoanEntryFeesinCreditEntryFees(int credit_id)
        {
            if (dataGridViewLoanEntryFees.SelectedRows.Count != 0)
            {
                try
                {
                    foreach (var _fee in _credit_entryfees)
                    {
                        _fee.credit_id = credit_id;
                        rep.AddNewCreditEntryFee(_fee);
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SaveLoansLinkSavings(int contractid, int savingcontractid)
        {
            try
            {
                LoansLinkSavingsBookModel _loanslinksavings = new LoansLinkSavingsBookModel();
                _loanslinksavings.loan_id = contractid;
                _loanslinksavings.savings_id = savingcontractid;
                _loanslinksavings.loan_percentage = 0;

                rep.AddNewLoansLinkSavingsBook(_loanslinksavings);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SaveLoansContractInstallments(ClientLoanContractModel  _loan_contract )
        {
            try
            {
                foreach (var installment in _installments)
                {
                    installment.contract_id = _loan_contract.contractid;
                    rep.AddNewInstallment(installment);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void UpdateLoansLinkSavings(int contractid, int savingcontractid)
        {
            try
            {
                LoansLinkSavingsBookModel _loanslinksavings = new LoansLinkSavingsBookModel();
                _loanslinksavings.loan_id = contractid;
                _loanslinksavings.savings_id = savingcontractid;
                _loanslinksavings.loan_percentage = 0;

                rep.UpdateLoansLinkSavingsBook(_loanslinksavings);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void UpdateLoansContractInstallments()
        {
            try
            {
                foreach (var installment in _installments)
                {
                    rep.UpdateInstallment(installment);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void CreateLoanContractsInstallments()
        {
            errorProvider1.Clear();
            if (IsInstallmentDetailsValid())
            {
                try
                {

                    InstallmentTypesModel _installment_type = (InstallmentTypesModel)cboInstallmentTypes.SelectedItem;
                    _installments = null;

                    switch (_installment_type.installmenttypesid)
                    {
                        case 1:
                            if (_loancontract == null)
                            {
                                bindingSourceInstallments.DataSource = null;
                                _installments = new List<InstallmentsModel>();
                                double principle = double.Parse(txtLoanAmount.Text.Trim());
                                double interest = double.Parse(txtInterestRatePerPeriod.Text.Trim());
                                int months = int.Parse(txtNoofInstallments.Text.Trim());
                                double monthly = principle / months;
                                DateTime start_date = DateTime.Parse(dtpPreferredFirstInstallmentDate.Value.ToString());

                                var endingBalance = principle;
                                var rate = interest;
                                var count = 1;
                                var _start_date = start_date;

                                while (count <= months)
                                {
                                    var interestPaid = endingBalance * (rate / 100);
                                    var _totalprinciplePaid = monthly + interestPaid;
                                    endingBalance -= _totalprinciplePaid;

                                    InstallmentsModel _installment = new InstallmentsModel();
                                    _installment.expected_date = _start_date.AddMonths(1);
                                    _installment._expected_date = _start_date.AddMonths(1);
                                    _installment.interest_repayment = decimal.Parse(interestPaid.ToString());
                                    _installment.capital_repayment = decimal.Parse(monthly.ToString()); 
                                    _installment.number = count;
                                    _installment.paid_interest = 0M;
                                    _installment.paid_capital = 0M;
                                    _installment.fees_unpaid = 0M;
                                    _installment.paid_date = null;
                                    _installment.paid_fees = 0M;
                                    if (!string.IsNullOrEmpty(txtLoanPurpose.Text))
                                    {
                                        _installment.comment = Utils.ConvertFirstLetterToUpper(txtLoanPurpose.Text.Trim());
                                    }
                                    _installment.pending = false;
                                    _installment.start_date = _start_date;
                                    _installment._start_date = _start_date;
                                    _installment.olb = decimal.Parse(endingBalance.ToString());
                                    _installment._olb = decimal.Parse(endingBalance.ToString());
                                    _installment.installment_monthly_total = _totalprinciplePaid;
                                    _installment.installmentid = count;

                                    count++;

                                    _installments.Add(_installment);

                                    _start_date = _start_date.AddMonths(1);
                                }

                                groupBox13.Text = _installments.Count.ToString();

                                InstallmentsModel _installment_totals = new InstallmentsModel();
                                _installment_totals.installmentid = null;
                                _installment_totals.interest_repayment = _installments.Sum(i => i.interest_repayment);
                                _installment_totals.capital_repayment = _installments.Sum(i => i.capital_repayment);
                                _installment_totals.installment_monthly_total = _installments.Sum(i => i.installment_monthly_total);
                                _installment_totals._olb = null;
                                _installment_totals._expected_date = null;

                                _installments.Add(_installment_totals);

                                bindingSourceInstallments.DataSource = _installments;
                                dataGridViewInstallments.AutoGenerateColumns = false;
                                dataGridViewInstallments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                dataGridViewInstallments.DataSource = bindingSourceInstallments;
                            }
                            break;
                        case 5:
                            if (_loancontract == null)
                            {
                                bindingSourceInstallments.DataSource = null;
                                _installments = new List<InstallmentsModel>();
                                double principle = double.Parse(txtLoanAmount.Text.Trim());
                                double interest = double.Parse(txtInterestRatePerPeriod.Text.Trim());
                                int months = int.Parse(txtNoofInstallments.Text.Trim());
                                double monthly = principle / months;
                                DateTime start_date = DateTime.Parse(dtpPreferredFirstInstallmentDate.Value.ToString());

                                var endingBalance = principle;
                                var rate = interest;
                                var count = 1;
                                var _start_date = start_date;

                                while (count <= months)
                                {
                                    var interestPaid = endingBalance * (rate / 100);
                                    var _totalprinciplePaid = monthly + interestPaid;
                                    endingBalance -= _totalprinciplePaid;

                                    InstallmentsModel _installment = new InstallmentsModel();
                                    _installment.expected_date = _start_date.AddYears(1);
                                    _installment._expected_date = _start_date.AddYears(1);
                                    _installment.interest_repayment = decimal.Parse(interestPaid.ToString());
                                    _installment.capital_repayment = decimal.Parse(monthly.ToString()); 
                                    _installment.number = count;
                                    _installment.paid_interest = 0M;
                                    _installment.paid_capital = 0M;
                                    _installment.fees_unpaid = 0M;
                                    _installment.paid_date = null;
                                    _installment.paid_fees = 0M;
                                    if (!string.IsNullOrEmpty(txtLoanPurpose.Text))
                                    {
                                        _installment.comment = Utils.ConvertFirstLetterToUpper(txtLoanPurpose.Text.Trim());
                                    }
                                    _installment.pending = false;
                                    _installment.start_date = _start_date;
                                    _installment._start_date = _start_date;
                                    _installment.olb = decimal.Parse(endingBalance.ToString());
                                    _installment._olb = decimal.Parse(endingBalance.ToString());
                                    _installment.installment_monthly_total = _totalprinciplePaid;
                                    _installment.installmentid = count;

                                    count++;

                                    _installments.Add(_installment);

                                    _start_date = _start_date.AddYears(1);
                                }

                                groupBox13.Text = _installments.Count.ToString();

                                InstallmentsModel _installment_totals = new InstallmentsModel();
                                _installment_totals.installmentid = null;
                                _installment_totals.interest_repayment = _installments.Sum(i => i.interest_repayment);
                                _installment_totals.capital_repayment = _installments.Sum(i => i.capital_repayment);
                                _installment_totals.installment_monthly_total = _installments.Sum(i => i.installment_monthly_total);
                                _installment_totals._olb = null;
                                _installment_totals._expected_date = null;

                                _installments.Add(_installment_totals);

                                bindingSourceInstallments.DataSource = _installments;
                                dataGridViewInstallments.AutoGenerateColumns = false;
                                dataGridViewInstallments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                dataGridViewInstallments.DataSource = bindingSourceInstallments;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ClearLoanDetailsControls()
        {
            try
            {
                groupBoxContracts.Text = string.Empty;
                txtLoanContractCode.Text = string.Empty;
                txtLoanAmount.Text = string.Empty;
                lblMinAmount.Text = string.Empty;
                lblMaxAmount.Text = string.Empty;
                txtInterestRatePerPeriod.Text = string.Empty;
                lblMinInterestRate.Text = string.Empty;
                lblMaxInterestRate.Text = string.Empty;
                txtGracePeriod.Text = string.Empty;
                lblMinGracePeriod.Text = string.Empty;
                lblMaxGracePeriod.Text = string.Empty;
                txtNoofInstallments.Text = string.Empty;
                lblMinnoofInstallments.Text = string.Empty;
                lblMaxnoofInstallments.Text = string.Empty;
                cboInstallmentTypes.SelectedIndex = -1;
                dtpDisbursementDate.Value = DateTime.Now;
                lblSelectedDisbursementDayName.Text = string.Empty;
                lblSelectedFirstInstallmentDayName.Text = string.Empty;
                cboFundingLine.SelectedIndex = -1;
                cboLoanOfficer.SelectedIndex = -1;
                cboLoanEconomicActivity.SelectedIndex = -1;
                txtLoanPurpose.Text = string.Empty;
                txtLineOfCredit.Text = string.Empty;
                txtCreditInsurance.Text = string.Empty;
                lblMinCreditInsurance.Text = string.Empty;
                lblMaxCreditInsurance.Text = string.Empty;
                txtEarlyFeesATR.Text = string.Empty;
                lblATREntryFees.Text = string.Empty;
                txtEarlyFeesAPR.Text = string.Empty;
                lblAPREntryFees.Text = string.Empty;
                txtTotalLoanAmount.Text = string.Empty;
                txtOLB.Text = string.Empty;
                txtOverDueInterest.Text = string.Empty;
                lblEntryFeeMax.Text = string.Empty;
                lblEntryFeesMin.Text = string.Empty;
                chkRate.Checked = false;
                txtCompulsorySavingsAmount.Text = string.Empty;
                cboLoanLinkSavings.SelectedIndex = -1;
                lblSavingCurrency.Text = string.Empty;
                txtAdvancedSettingsComment.Text = string.Empty;
                cboLoanStatus.SelectedIndex = -1;
                dtpCreditCommiteeDate.Value = DateTime.Now;
                txtCreditCommitteCode.Text = string.Empty;
                txtCreditComitteComment.Text = string.Empty;
                lblCurrency.Text = string.Empty;
                lblOLB.Text = string.Empty;
                lblInterestDue.Text = string.Empty;
                _installments = new List<InstallmentsModel>();
                bindingSourceInstallments.DataSource = null;
                _credit_entryfees = new List<CreditEntryFeesModel>();
                bindingSourceEntryFees.DataSource = null;
                _contractcollaterals = new List<ClientContractCollateralsModel>();
                bindingSourceLoanCollaterals.DataSource = null;
                _loanguarantors = new List<LoanGuarantorsModel>();
                bindingSourceLoanGuarantors.DataSource = null;
                groupBox13.Text = "Installments";
                groupBox23.Text = "Entry Fees";
                groupBox11.Text = "Collaterals";
                groupBox9.Text = "Guarantors";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearSavingDetailsControls()
        {
            try
            {
                lblMaxChequeDepositFees.Text = string.Empty;
                lblMinChequeDepositFees.Text = string.Empty;
                lblMaxInterBranchTransferFees.Text = string.Empty;
                lblMinInterBranchTransferFees.Text = string.Empty;
                lblMaxReOpenFees.Text = string.Empty;
                lblMinReOpenFees.Text = string.Empty;
                lblMaxAgio.Text = string.Empty;
                lblMinAgio.Text = string.Empty;
                lblMaxOverDraftFees.Text = string.Empty;
                lblMinOverDraftFees.Text = string.Empty;
                lblMaxManagementFees.Text = string.Empty;
                lblMinManagementFees.Text = string.Empty;
                lblMaxCloseFees.Text = string.Empty;
                lblMinCloseFees.Text = string.Empty;
                lblMaxCashDepositFees.Text = string.Empty;
                lblMinCashDepositFees.Text = string.Empty;
                lblMaxTransferFees.Text = string.Empty;
                lblMinTransferFees.Text = string.Empty;
                lblSavingsWithdrawFees.Text = string.Empty;
                lblMaxSavingsEntryFees.Text = string.Empty;
                lblMinSavingsEntryFees.Text = string.Empty;
                lblMaxSavingsInitialAmount.Text = string.Empty;
                lblMinSavingsInitialAmount.Text = string.Empty;
                lblSavingsBalanceAmount.Text = string.Empty;
                lblSavingsAvailableBalance.Text = string.Empty;
                lblSavingsInterestRate.Text = string.Empty;
                lblMinDepositAmount.Text = string.Empty;
                lblMaxDepositAmount.Text = string.Empty;
                lblMinTransferAmount.Text = string.Empty;
                lblMaxTransferAmount.Text = string.Empty;
                lblMinBalanceAmount.Text = string.Empty;
                lblMaxBalanceAmount.Text = string.Empty;
                lblInterestAccrual.Text = string.Empty;
                lblInterestPosting.Text = string.Empty;
                lblInterestBasedOn.Text = string.Empty;
                lblMinWithDrawAmount.Text = string.Empty;
                lblMaxWithDrawAmount.Text = string.Empty;
                txtChequeDepositFees.Text = string.Empty;
                txtInterBranchTransferFees.Text = string.Empty;
                txtReopenFees.Text = string.Empty;
                txtAgioFees.Text = string.Empty;
                txtOverDraftFees.Text = string.Empty;
                txtManagementFees.Text = string.Empty;
                txtCloseFees.Text = string.Empty;
                txtCashDepositFees.Text = string.Empty;
                txtTransferFees.Text = string.Empty;
                txtSavingsInterestRate.Text = string.Empty;
                txtWithdrawFees.Text = string.Empty;
                txtSavingsEntryFees.Text = string.Empty;
                txtSavingsInitialAmount.Text = string.Empty;
                cboSavingsOfficer.SelectedIndex = -1;
                groupBoxSavingDetails.Text = string.Empty;
                groupBox33.Text = string.Empty;
                groupBox43.Text = string.Empty;
                groupBox46.Text = string.Empty;
                bindingSourceSavingsEvents.DataSource = null;
                bindingSourceSavingsCustomizableFields.DataSource = null;
                bindingSourceSavingsLoanContracts.DataSource = null;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableControls()
        {

            try
            {
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                dtpDateofBirth.Enabled = false;
                cboGender.Enabled = false;
                txtIDNo.Enabled = false;
                cboEconomicActivity.Enabled = false;
                txtLoanCycle.Enabled = false;
                chkHeadofHouseHold.Enabled = false;
                txtPlaceofBirth.Enabled = false;
                txtFatherName.Enabled = false;
                txtCitizenShip.Enabled = false;
                pbPhoto.Enabled = false;
                btnUploadPersonPhoto.Enabled = false;
                cboBranch.Enabled = false;

                #region "Home Address"
                cboHAProvince.Enabled = false;
                cboHADistrict.Enabled = false;
                txtHACity.Enabled = false;
                txtHAdress.Enabled = false;
                txtHAZipCode.Enabled = false;
                cboHAHomeType.Enabled = false;
                txtHAHomePhone.Enabled = false;
                txtHACellPhone.Enabled = false;
                txtHAEmail.Enabled = false;
                #endregion "Home Address"

                #region "Business Address"
                cboBAProvince.Enabled = false;
                cboBADistrict.Enabled = false;
                txtBACity.Enabled = false;
                txtBAAddress.Enabled = false;
                txtBAZipCode.Enabled = false;
                cboBAHomeType.Enabled = false;
                txtBAHomePhone.Enabled = false;
                txtBACellPhone.Enabled = false;
                txtBAEmail.Enabled = false;
                #endregion "Business Address"

                btnUpdate.Enabled = false;
                btnUpdate.Visible = false;
                btnClose.Location = btnUpdate.Location;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DisableLoanDetailsControls()
        {
            try
            {
                groupBoxContracts.Enabled = false;
                groupBox7.Enabled = false;
                groupBox23.Enabled = false;
                groupBox21.Enabled = false;
                groupBox24.Enabled = false;
                btnSaveCommitteeDetails.Enabled = false;
                cboLoanLinkSavings.Enabled = false;
                txtAdvancedSettingsComment.Enabled = false;
                txtCompulsorySavingsAmount.Enabled = false;
                btnEditSchedule.Enabled = false;
                btnDisburse.Enabled = false;
                btnPreviewInstallments.Enabled = false;
                btnSaveLoanDetails.Enabled = false;
                btnSaveAdvancedSettings.Enabled = false;

                dtpDisbursementDate.Enabled = false;
                dtpCreditCommiteeDate.Enabled = false;
                cboFundingLine.Enabled = false;
                cboLoanOfficer.Enabled = false;
                cboLoanEconomicActivity.Enabled = false;
                cboLoanStatus.Enabled = false;
                cboLoanLinkSavings.Enabled = false;
                cboInstallmentTypes.Enabled = false;
                txtLoanPurpose.Enabled = false;
                txtLineOfCredit.Enabled = false;
                txtCreditInsurance.Enabled = false;
                txtEarlyFeesATR.Enabled = false;
                txtLoanContractCode.Enabled = false;
                txtLoanAmount.Enabled = false;
                txtInterestRatePerPeriod.Enabled = false;
                txtGracePeriod.Enabled = false;
                txtNoofInstallments.Enabled = false;
                txtEarlyFeesAPR.Enabled = false;
                txtCreditCommitteCode.Enabled = false;
                txtCreditComitteComment.Enabled = false;
                txtAdvancedSettingsComment.Enabled = false;
                txtTotalLoanAmount.Enabled = false;
                txtOLB.Enabled = false;
                txtOverDueInterest.Enabled = false;
                txtCompulsorySavingsAmount.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DisableSavingsDetailsControls()
        {
            try
            {
                groupBoxSavingDetails.Enabled = false;
                groupBox34.Enabled = false;
                tabPageFeesandLimits.Enabled = false;
                txtSavingsCode.Enabled = false;
                txtSavingsInitialAmount.Enabled = false;
                txtSavingsEntryFees.Enabled = false;
                txtWithdrawFees.Enabled = false;
                cboSavingsOfficer.Enabled = false;
                txtSavingsInterestRate.Enabled = false;
                txtTransferFees.Enabled = false;
                txtCashDepositFees.Enabled = false;
                txtCloseFees.Enabled = false;
                txtManagementFees.Enabled = false;
                txtOverDraftFees.Enabled = false;
                txtAgioFees.Enabled = false;
                txtReopenFees.Enabled = false;
                txtInterBranchTransferFees.Enabled = false;
                txtChequeDepositFees.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DisableAdvancedSettingsLoanDetailsControls()
        {
            try
            {
                txtLineOfCredit.Enabled = false;
                txtCreditInsurance.Enabled = false;
                txtEarlyFeesATR.Enabled = false;
                txtEarlyFeesAPR.Enabled = false;
                txtTotalLoanAmount.Enabled = false;
                txtOverduePrincipal.Enabled = false;
                txtOLB.Enabled = false;
                txtOverDueInterest.Enabled = false;
                groupBox7.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void EnableSavingsDetailsControls()
        {
            try
            {
                groupBoxSavingDetails.Enabled = true;
                groupBox34.Enabled = true;
                tabPageFeesandLimits.Enabled = true;
                txtSavingsCode.Enabled = true;
                txtSavingsInitialAmount.Enabled = true;
                txtSavingsEntryFees.Enabled = true;
                txtWithdrawFees.Enabled = true;
                cboSavingsOfficer.Enabled = true;
                txtSavingsInterestRate.Enabled = true;
                txtTransferFees.Enabled = true;
                txtCashDepositFees.Enabled = true;
                txtCloseFees.Enabled = true;
                txtManagementFees.Enabled = true;
                txtOverDraftFees.Enabled = true;
                txtAgioFees.Enabled = true;
                txtReopenFees.Enabled = true;
                txtInterBranchTransferFees.Enabled = true;
                txtChequeDepositFees.Enabled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void EnableLoanDetailsControls()
        {
            try
            {
                groupBoxContracts.Enabled = true;
                groupBox15.Enabled = true;
                groupBox7.Enabled = true;
                groupBox23.Enabled = true;
                groupBox21.Enabled = true;
                groupBox24.Enabled = true;
                groupBox17.Enabled = true;
                btnSaveCommitteeDetails.Enabled = true;
                cboLoanLinkSavings.Enabled = true;
                txtAdvancedSettingsComment.Enabled = true;
                txtCompulsorySavingsAmount.Enabled = true;
                btnEditSchedule.Enabled = true;
                btnDisburse.Enabled = true;
                btnPreviewInstallments.Enabled = true;
                btnSaveLoanDetails.Enabled = true;
                btnSaveAdvancedSettings.Enabled = true;

                dtpDisbursementDate.Enabled = true;
                dtpCreditCommiteeDate.Enabled = true;
                cboFundingLine.Enabled = true;
                cboInstallmentTypes.Enabled = true;
                cboLoanOfficer.Enabled = true;
                cboLoanEconomicActivity.Enabled = true;
                cboLoanLinkSavings.Enabled = true;
                cboLoanStatus.Enabled = true;
                lblMinCreditInsurance.Enabled = true;
                lblSavingCurrency.Enabled = true;
                lblMaxCreditInsurance.Enabled = true;
                lblMinGracePeriod.Enabled = true;
                lblMaxGracePeriod.Enabled = true;
                lblMinAmount.Enabled = true;
                lblMaxAmount.Enabled = true;
                lblMinInterestRate.Enabled = true;
                lblMaxInterestRate.Enabled = true;
                lblMinnoofInstallments.Enabled = true;
                lblMaxnoofInstallments.Enabled = true;
                lblSelectedDisbursementDayName.Enabled = true;
                lblSelectedFirstInstallmentDayName.Enabled = true;
                lblCurrency.Enabled = true;
                lblOLB.Enabled = true;
                lblInterestDue.Enabled = true;
                lblATREntryFees.Enabled = true;
                lblAPREntryFees.Enabled = true;
                txtEarlyFeesAPR.Enabled = true;
                txtEarlyFeesATR.Enabled = true;
                txtLoanPurpose.Enabled = true;
                txtGracePeriod.Enabled = true;
                txtLineOfCredit.Enabled = true;
                txtNoofInstallments.Enabled = true;
                txtCreditInsurance.Enabled = true;
                txtLoanContractCode.Enabled = true;
                txtLoanAmount.Enabled = true;
                txtTotalLoanAmount.Enabled = true;
                txtInterestRatePerPeriod.Enabled = true;
                txtOLB.Enabled = true;
                txtOverDueInterest.Enabled = true;
                txtOverduePrincipal.Enabled = true;
                txtAdvancedSettingsComment.Enabled = true;
                txtCompulsorySavingsAmount.Enabled = true;
                txtCreditCommitteCode.Enabled = true;
                txtCreditComitteComment.Enabled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateLoansContractInstallmentsGrid(ClientLoanContractModel _contract)
        {
            try
            {
                _installments = null;
                switch (_contract.installment_type)
                {
                    case 1:
                        if (_loancontract != null)
                        {
                            bindingSourceInstallments.DataSource = null;
                            var _installmentsquery = from ins in rep.GetAllContractInstallments(_loancontract.contractid)
                                                     select ins;
                            List<InstallmentsModel> _contract_installments=_installmentsquery.ToList();
                            _installments = new List<InstallmentsModel>();
                             foreach(var installment in _contract_installments)
                             {
                                InstallmentsModel _installment = new InstallmentsModel();
                                _installment.expected_date = installment.expected_date;
                                _installment._expected_date = installment.expected_date;
                                _installment.interest_repayment = installment.interest_repayment;
                                _installment.capital_repayment = installment.capital_repayment;
                                _installment.contract_id = installment.contract_id;
                                _installment.number = installment.number;
                                _installment.paid_interest = installment.paid_interest;
                                _installment.paid_capital = installment.paid_capital;
                                _installment.fees_unpaid = installment.fees_unpaid;
                                _installment.paid_date = installment.paid_date;
                                _installment.paid_fees = installment.paid_fees;
                                _installment.comment = installment.comment;
                                _installment.pending = installment.pending;
                                _installment.start_date = installment.start_date;
                                _installment._start_date = installment.start_date;
                                _installment.olb = installment.olb;
                                _installment._olb = installment.olb;
                                _installment.installment_monthly_total = double.Parse((installment.interest_repayment + installment.capital_repayment).ToString());
                                _installment.installmentid = installment.number;

                                _installments.Add(_installment); 
                            }

                            groupBox13.Text = _installments.Count.ToString();

                            InstallmentsModel _installment_totals = new InstallmentsModel();
                            _installment_totals.installmentid = null;
                            _installment_totals.interest_repayment = _installments.Sum(i => i.interest_repayment);
                            _installment_totals.capital_repayment = _installments.Sum(i => i.capital_repayment);
                            _installment_totals.installment_monthly_total = _installments.Sum(i => i.installment_monthly_total);
                            _installment_totals._olb = null;
                            _installment_totals._expected_date = null;

                            _installments.Add(_installment_totals);

                            bindingSourceInstallments.DataSource = _installments;
                            dataGridViewInstallments.AutoGenerateColumns = false;
                            dataGridViewInstallments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridViewInstallments.DataSource = bindingSourceInstallments;
                        }
                        break;
                    case 5:
                        if (_loancontract != null)
                        {
                            bindingSourceInstallments.DataSource = null;
                            var _installmentsquery = from ins in rep.GetAllContractInstallments(_loancontract.contractid)
                                                     select ins;
                            List<InstallmentsModel> _contract_installments = _installmentsquery.ToList();
                            _installments = new List<InstallmentsModel>();
                            foreach (var installment in _contract_installments)
                            {
                                InstallmentsModel _installment = new InstallmentsModel();
                                _installment.expected_date = installment.expected_date;
                                _installment._expected_date = installment.expected_date;
                                _installment.interest_repayment = installment.interest_repayment;
                                _installment.capital_repayment = installment.capital_repayment;
                                _installment.contract_id = installment.contract_id;
                                _installment.number = installment.number;
                                _installment.paid_interest = installment.paid_interest;
                                _installment.paid_capital = installment.paid_capital;
                                _installment.fees_unpaid = installment.fees_unpaid;
                                _installment.paid_date = installment.paid_date;
                                _installment.paid_fees = installment.paid_fees;
                                _installment.comment = installment.comment;
                                _installment.pending = installment.pending;
                                _installment.start_date = installment.start_date;
                                _installment._start_date = installment.start_date;
                                _installment.olb = installment.olb;
                                _installment._olb = installment.olb;
                                _installment.installment_monthly_total = double.Parse((installment.interest_repayment + installment.capital_repayment).ToString());
                                _installment.installmentid = installment.number;

                                _installments.Add(_installment);
                            }

                            groupBox13.Text = _installments.Count.ToString();

                            InstallmentsModel _installment_totals = new InstallmentsModel();
                            _installment_totals.installmentid = null;
                            _installment_totals.interest_repayment = _installments.Sum(i => i.interest_repayment);
                            _installment_totals.capital_repayment = _installments.Sum(i => i.capital_repayment);
                            _installment_totals.installment_monthly_total = _installments.Sum(i => i.installment_monthly_total);
                            _installment_totals._olb = null;
                            _installment_totals._expected_date = null;

                            _installments.Add(_installment_totals);

                            bindingSourceInstallments.DataSource = _installments;
                            dataGridViewInstallments.AutoGenerateColumns = false;
                            dataGridViewInstallments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridViewInstallments.DataSource = bindingSourceInstallments;
                        }
                        break;
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateLoanDetailsfromPackage(LoanPackageModel _loan_package)
        {
            try
            {
                if (_loan_package.name != null)
                {
                    groupBoxContracts.Text = "Loan Type:    " + _loan_package.name;
                }
                txtLoanContractCode.Text = string.Empty;
                txtLoanContractCode.Enabled = false;
                if (_loan_package.amount != null)
                {
                    txtLoanAmount.Text = _loan_package.amount.ToString();
                }
                if (_loan_package.amount == null)
                {
                    txtLoanAmount.Text = _loan_package.amount_min.ToString();
                }
                if (_loan_package.amount_min != null)
                {
                    lblMinAmount.Text = "Min: " + _loan_package.amount_min.ToString();
                }
                if (_loan_package.amount_max != null)
                {
                    lblMaxAmount.Text = "Max: " + _loan_package.amount_max.ToString();
                }
                if (_loan_package.interest_rate != null)
                {
                    txtInterestRatePerPeriod.Text = _loan_package.interest_rate.ToString();
                }
                if (_loan_package.interest_rate == null)
                {
                    txtInterestRatePerPeriod.Text = _loan_package.interest_rate_min.ToString();
                }
                if (_loan_package.interest_rate_min != null)
                {
                    lblMinInterestRate.Text = "Min: " + _loan_package.interest_rate_min.ToString();
                }
                if (_loan_package.interest_rate_max != null)
                {
                    lblMaxInterestRate.Text = "Max: " + _loan_package.interest_rate_max.ToString();
                }
                if (_loan_package.grace_period != null)
                {
                    txtGracePeriod.Text = _loan_package.grace_period.ToString();
                }
                if (_loan_package.grace_period == null)
                {
                    txtGracePeriod.Text = _loan_package.grace_period_min.ToString();
                }
                if (_loan_package.grace_period_min != null)
                {
                    lblMinGracePeriod.Text = "Min: " + _loan_package.grace_period_min.ToString();
                }
                if (_loan_package.grace_period_max != null)
                {
                    lblMaxGracePeriod.Text = "Max: " + _loan_package.grace_period_max.ToString();
                }
                if (_loan_package.number_of_installments != null)
                {
                    txtNoofInstallments.Text = _loan_package.number_of_installments.ToString();
                }
                if (_loan_package.number_of_installments == null)
                {
                    txtNoofInstallments.Text = _loan_package.number_of_installments_min.ToString();
                }
                if (_loan_package.number_of_installments_min != null)
                {
                    lblMinnoofInstallments.Text = "Min: " + _loan_package.number_of_installments_min.ToString();
                }
                if (_loan_package.number_of_installments_max != null)
                {
                    lblMaxnoofInstallments.Text = "Max: " + _loan_package.number_of_installments_max.ToString();
                }
                if (_loan_package.installment_type != null)
                {
                    cboInstallmentTypes.SelectedValue = _loan_package.installment_type;
                }
                if (_loan_package.fundingLine_id != null)
                {
                    cboFundingLine.SelectedValue = _loan_package.fundingLine_id;
                }
                lblSelectedDisbursementDayName.Text = dtpDisbursementDate.Value.ToString("dddd");
                dtpPreferredFirstInstallmentDate.Value = dtpDisbursementDate.Value.AddMonths(1);
                cboLoanEconomicActivity.SelectedValue = _clientModel.activity_id;

                var userquery = (from usr in db.Users
                                 where usr.id == user_id
                                 select new UserModel_dto
                                 {
                                     userid = usr.id,
                                     user_name = usr.user_name,
                                     user_pass = usr.user_pass,
                                     role_code = usr.role_code,
                                     first_name = usr.first_name,
                                     last_name = usr.last_name,
                                     phone = usr.phone,
                                     mail = usr.mail,
                                     deleted = usr.deleted
                                 }).FirstOrDefault();

                cboLoanOfficer.SelectedValue = userquery.userid;
                if (_loan_package.amount_under_loc != null)
                {
                    txtLineOfCredit.Text = _loan_package.amount_under_loc.ToString();
                }
                if (_loan_package.amount_under_loc == null)
                {
                    txtLineOfCredit.Text = "0";
                }
                if (_loan_package.insurance_min != null)
                {
                    txtCreditInsurance.Text = _loan_package.insurance_min.ToString();
                }
                if (_loan_package.insurance_min != null)
                {
                    lblMinCreditInsurance.Text = "Min: " + _loan_package.insurance_min.ToString() + "%";
                }
                if (_loan_package.insurance_max != null)
                {
                    lblMaxCreditInsurance.Text = "Max: " + _loan_package.insurance_max.ToString() + "%";
                }
                if (_loan_package.anticipated_total_repayment_penalties != null)
                {
                    txtEarlyFeesATR.Text = _loan_package.anticipated_total_repayment_penalties.ToString();
                }
                if (_loan_package.anticipated_partial_repayment_penalties != null)
                {
                    txtEarlyFeesAPR.Text = _loan_package.anticipated_partial_repayment_penalties.ToString();
                }
                if (_loan_package.non_repayment_penalties_based_on_initial_amount != null)
                {
                    txtTotalLoanAmount.Text = _loan_package.non_repayment_penalties_based_on_initial_amount.ToString();
                }
                if (_loan_package.non_repayment_penalties_based_on_overdue_principal != null)
                {
                    txtOverduePrincipal.Text = _loan_package.non_repayment_penalties_based_on_overdue_principal.ToString();
                }
                if (_loan_package.non_repayment_penalties_based_on_olb != null)
                {
                    txtOLB.Text = _loan_package.non_repayment_penalties_based_on_olb.ToString();
                }
                if (_loan_package.non_repayment_penalties_based_on_overdue_interest != null)
                {
                    txtOverDueInterest.Text = _loan_package.non_repayment_penalties_based_on_overdue_interest.ToString();
                }
                if (_loan_package.compulsory_amount != null)
                {
                    txtCompulsorySavingsAmount.Text = _loan_package.compulsory_amount.ToString();
                }
                if (_loan_package.compulsory_amount == null)
                {
                    txtCompulsorySavingsAmount.Text = _loan_package.compulsory_amount_min.ToString();
                }
                lblSavingCurrency.Text = _currencymodel.code;
                var _savingscontractsquery = from af in rep.GetAllClientSavingContracts(_clientModel.tierid)
                                             select af;
                List<ClientSavingContractModel> _clientsavingcontracts = _savingscontractsquery.ToList();
                cboLoanLinkSavings.DataSource = _clientsavingcontracts;
                cboLoanLinkSavings.ValueMember = "savingcontractid";
                cboLoanLinkSavings.DisplayMember = "code";

                PopulateLoanEntryFeesGridfromEntryFees(_loan_package.packageid);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateLoanDetailsfromContract(ClientLoanContractModel _loan_contract)
        {
            try
            {
                if (_loan_contract.packagename != null)
                {
                    groupBoxContracts.Text = "Loan Type:    " + _loan_contract.packagename;
                }
                if (_loan_contract.contract_code != null)
                {
                    txtLoanContractCode.Text = _loan_contract.contract_code;
                    txtLoanContractCode.Enabled = false;
                }
                if (_loan_contract.amount != null)
                {
                    txtLoanAmount.Text = _loan_contract.amount.ToString();
                }
                if (_loan_contract.amount_min != null)
                {
                    lblMinAmount.Text = "Min: " + _loan_contract.amount_min.ToString();
                }
                if (_loan_contract.amount_max != null)
                {
                    lblMaxAmount.Text = "Max: " + _loan_contract.amount_max.ToString();
                }
                if (_loan_contract.grace_period != null)
                {
                    txtGracePeriod.Text = _loan_contract.grace_period.ToString();
                }
                if (_loan_contract.grace_period_min != null)
                {
                    lblMinGracePeriod.Text = "Min: " + _loan_contract.grace_period_min.ToString();
                }
                if (_loan_contract.grace_period_max != null)
                {
                    lblMaxGracePeriod.Text = "Max: " + _loan_contract.grace_period_max.ToString();
                }
                if (_loan_contract.interest_rate != null)
                {
                    txtInterestRatePerPeriod.Text = _loan_contract.interest_rate.ToString("N2");
                }
                if (_loan_contract.interest_rate_min != null)
                {
                    lblMinInterestRate.Text = "Min: " + _loan_contract.interest_rate_min.ToString();
                }
                if (_loan_contract.interest_rate_max != null)
                {
                    lblMaxInterestRate.Text = "Max: " + _loan_contract.interest_rate_max.ToString();
                }
                if (_loan_contract.nb_of_installment != null)
                {
                    txtNoofInstallments.Text = _loan_contract.nb_of_installment.ToString();
                }
                if (_loan_contract.nmb_of_inst_min != null)
                {
                    lblMinnoofInstallments.Text = "Min: " + _loan_contract.nmb_of_inst_min.ToString();
                }
                if (_loan_contract.nmb_of_inst_max != null)
                {
                    lblMaxnoofInstallments.Text = "Max: " + _loan_contract.nmb_of_inst_max.ToString();
                }
                if (_loan_contract.installment_type != null)
                {
                    cboInstallmentTypes.SelectedValue = _loan_contract.installment_type;
                }
                if (_loan_contract.fundingLine_id != null)
                {
                    cboFundingLine.SelectedValue = _loan_contract.fundingLine_id;
                }
                lblSelectedDisbursementDayName.Text = dtpDisbursementDate.Value.ToString("dddd");
                dtpPreferredFirstInstallmentDate.Value = dtpDisbursementDate.Value.AddMonths(1);
                cboLoanEconomicActivity.SelectedValue = _clientModel.activity_id;
                cboLoanOfficer.SelectedValue = _loan_contract.loanofficer_id;
                if (_loan_contract.amount_under_loc != null)
                {
                    txtLineOfCredit.Text = _loan_contract.amount_under_loc.ToString();
                }
                if (_loan_contract.insurance != null)
                {
                    txtCreditInsurance.Text = _loan_contract.insurance.ToString();
                }
                if (_loan_contract.insurance_min != null)
                {
                    lblMinCreditInsurance.Text = "Min: " + _loan_contract.insurance_min.ToString() + "%";
                }
                if (_loan_contract.insurance_max != null)
                {
                    lblMaxCreditInsurance.Text = "Max: " + _loan_contract.insurance_max.ToString() + "%";
                }
                if (_loan_contract.anticipated_total_repayment_penalties != null)
                {
                    txtEarlyFeesATR.Text = _loan_contract.anticipated_total_repayment_penalties.ToString();
                }
                if (_loan_contract.anticipated_partial_repayment_penalties != null)
                {
                    txtEarlyFeesAPR.Text = _loan_contract.anticipated_partial_repayment_penalties.ToString();
                }
                if (_loan_contract.non_repayment_penalties_based_on_initial_amount != null)
                {
                    txtTotalLoanAmount.Text = _loan_contract.non_repayment_penalties_based_on_initial_amount.ToString();
                }
                if (_loan_contract.non_repayment_penalties_based_on_overdue_principal != null)
                {
                    txtOverduePrincipal.Text = _loan_contract.non_repayment_penalties_based_on_overdue_principal.ToString();
                }
                if (_loan_contract.non_repayment_penalties_based_on_olb != null)
                {
                    txtOLB.Text = _loan_contract.non_repayment_penalties_based_on_olb.ToString();
                }
                if (_loan_contract.non_repayment_penalties_based_on_overdue_interest != null)
                {
                    txtOverDueInterest.Text = _loan_contract.non_repayment_penalties_based_on_overdue_interest.ToString();
                }
                lblSavingCurrency.Text = _currencymodel.code;
                if (_loan_contract.compulsory_amount != null || _loan_contract.compulsory_amount_min != null)
                {
                    txtCompulsorySavingsAmount.Text = _loan_contract.compulsory_amount.ToString() ?? _loan_contract.compulsory_amount_min.ToString();
                }
                if (_loan_contract.comments != null)
                {
                    txtAdvancedSettingsComment.Text = _loan_contract.comments.Trim();
                }
                var _savingscontractsquery = from af in rep.GetAllClientSavingContracts(_clientModel.tierid)
                                             select af;
                List<ClientSavingContractModel> _clientsavingcontracts = _savingscontractsquery.ToList();
                cboLoanLinkSavings.DataSource = _clientsavingcontracts;
                cboLoanLinkSavings.ValueMember = "savingcontractid";
                cboLoanLinkSavings.DisplayMember = "code";
                cboLoanLinkSavings.SelectedValue = _loan_contract.savingcontractid;
                if (_loan_contract.status != null)
                {
                    cboLoanStatus.SelectedValue = _loan_contract.status;
                }
                if (_loan_contract.credit_commitee_date != null)
                {
                    dtpCreditCommiteeDate.Value = _loan_contract.credit_commitee_date ?? DateTime.Now;
                }
                if (_loan_contract.credit_commitee_code != null)
                {
                    txtCreditCommitteCode.Text = _loan_contract.credit_commitee_code.Trim();
                }
                if (_loan_contract.credit_commitee_comment != null)
                {
                    txtCreditComitteComment.Text = _loan_contract.credit_commitee_comment.Trim();
                }

                PopulateLoanEntryFeesGridfromCreditEntryFees(_loan_contract.creditid);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateLoanEntryFeesGridfromEntryFees(int _package_id)
        {
            try
            {
                _credit_entryfees = new List<CreditEntryFeesModel>();
                bindingSourceEntryFees.DataSource = null;

                var _loanentryfeesquery = from rl in rep.GetLoanPackageEntryFees(_package_id)
                                          select rl;
                _credit_entryfees = _loanentryfeesquery.ToList();
                bindingSourceEntryFees.DataSource = _credit_entryfees;
                dataGridViewLoanEntryFees.AutoGenerateColumns = false;
                this.dataGridViewLoanEntryFees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewLoanEntryFees.DataSource = bindingSourceEntryFees;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        private void PopulateLoanEntryFeesGridfromCreditEntryFees(int credit_id)
        {
            try
            {
                _credit_entryfees = new List<CreditEntryFeesModel>();
                bindingSourceEntryFees.DataSource = null;

                var _loanentryfeesquery = from rl in rep.GetLoanCreditEntryFees(credit_id)
                                          select rl;
                _credit_entryfees = _loanentryfeesquery.ToList();
                bindingSourceEntryFees.DataSource = _credit_entryfees;
                dataGridViewLoanEntryFees.AutoGenerateColumns = false;
                this.dataGridViewLoanEntryFees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewLoanEntryFees.DataSource = bindingSourceEntryFees;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        private void PopulateSavingsDetailsfromSavingsProduct(SavingProductModel savings)
        {
            try
            {
                txtSavingsCode.Enabled = false;
                if (savings.initial_amount_min != null)
                {
                    txtSavingsInitialAmount.Text = savings.initial_amount_min.ToString();
                }
                if (savings.entry_fees != null)
                {
                    txtSavingsEntryFees.Text = savings.entry_fees.ToString();
                }
                if (savings.entry_fees == null)
                {
                    txtSavingsEntryFees.Text = savings.entry_fees_min.ToString();
                }
                if (savings.interest_rate != null)
                {
                    txtSavingsInterestRate.Text = savings.interest_rate.ToString();
                }
                if (savings.interest_rate == null)
                {
                    txtSavingsInterestRate.Text = savings.interest_rate_min.ToString();
                }
                if (savings.flat_withdraw_fees != null || savings.rate_withdraw_fees != null)
                {
                    txtWithdrawFees.Text = savings.flat_withdraw_fees.ToString() ?? savings.rate_withdraw_fees.ToString();
                }
                if (savings.flat_withdraw_fees == null && savings.rate_withdraw_fees == null)
                {
                    txtWithdrawFees.Text = savings.flat_withdraw_fees_min.ToString() ?? savings.rate_withdraw_fees_min.ToString();
                }
                if (savings.flat_transfer_fees != null || savings.rate_transfer_fees != null)
                {
                    txtTransferFees.Text = savings.flat_transfer_fees.ToString() ?? savings.rate_transfer_fees.ToString();
                }
                if (savings.flat_transfer_fees == null && savings.rate_transfer_fees == null)
                {
                    txtTransferFees.Text = savings.flat_transfer_fees_min.ToString() ?? savings.rate_transfer_fees_min.ToString();
                }
                if (savings.deposit_fees != null)
                {
                    txtCashDepositFees.Text = savings.deposit_fees.ToString();
                }
                if (savings.close_fees != null)
                {
                    txtCloseFees.Text = savings.close_fees.ToString();
                }
                if (savings.management_fees != null)
                {
                    txtManagementFees.Text = savings.management_fees.ToString();
                }
                if (savings.overdraft_fees != null)
                {
                    txtOverDraftFees.Text = savings.overdraft_fees.ToString();
                }
                if (savings.agio_fees != null)
                {
                    txtAgioFees.Text = savings.agio_fees.ToString();
                }
                if (savings.reopen_fees != null)
                {
                    txtReopenFees.Text = savings.reopen_fees.ToString();
                }
                if (savings.ibt_fee != null)
                {
                    txtInterBranchTransferFees.Text = savings.ibt_fee.ToString();
                }
                if (savings.cheque_deposit_fees != null)
                {
                    txtChequeDepositFees.Text = savings.cheque_deposit_fees.ToString();
                }
                if (savings.initial_amount_min != null)
                {
                    lblMinSavingsInitialAmount.Text = "Min: " + savings.initial_amount_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.initial_amount_max != null)
                {
                    lblMaxSavingsInitialAmount.Text = "Max: " + savings.initial_amount_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.initial_amount_min != null)
                {
                    lblMinSavingsInitialAmount.Text = "Min:" + savings.initial_amount_min + "  " + _currencymodel.code;
                }
                if (savings.initial_amount_max != null)
                {
                    lblMaxSavingsInitialAmount.Text = "Max:" + savings.initial_amount_max + "  " + _currencymodel.code;
                }
                if (savings.rate_transfer_fees_min != null || savings.flat_transfer_fees_min != null)
                {
                    lblMinTransferFees.Text = "Min:" + savings.rate_transfer_fees_min.ToString() ?? savings.flat_transfer_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.rate_transfer_fees_max != null || savings.flat_transfer_fees_max != null)
                {
                    lblMaxTransferFees.Text = "Max:" + savings.rate_transfer_fees_max.ToString() ?? savings.flat_transfer_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.deposit_fees_min != null)
                {
                    lblMinCashDepositFees.Text = "Min:" + savings.deposit_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.deposit_fees_max != null)
                {
                    lblMaxCashDepositFees.Text = "Max:" + savings.deposit_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.close_fees_min != null)
                {
                    lblMinCloseFees.Text = "Min:" + savings.close_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.close_fees_max != null)
                {
                    lblMaxCloseFees.Text = "Max:" + savings.close_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.management_fees_min != null)
                {
                    lblMinManagementFees.Text = "Min:" + savings.management_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.management_fees_max != null)
                {
                    lblMaxManagementFees.Text = "Max:" + savings.management_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.overdraft_fees_min != null)
                {
                    lblMinOverDraftFees.Text = "Min:" + savings.overdraft_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.overdraft_fees_max != null)
                {
                    lblMaxOverDraftFees.Text = "Max:" + savings.overdraft_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.agio_fees_min != null)
                {
                    lblMinAgio.Text = "Min:" + savings.agio_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.agio_fees_max != null)
                {
                    lblMaxAgio.Text = "Max:" + savings.agio_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.reopen_fees_min != null)
                {
                    lblMinReOpenFees.Text = "Min:" + savings.reopen_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.reopen_fees_max != null)
                {
                    lblMaxReOpenFees.Text = "Max:" + savings.reopen_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.ibt_fee_min != null)
                {
                    lblMinInterBranchTransferFees.Text = "Min:" + savings.ibt_fee_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.ibt_fee_max != null)
                {
                    lblMaxInterBranchTransferFees.Text = "Max:" + savings.ibt_fee_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.cheque_deposit_min != null)
                {
                    lblMinChequeDepositFees.Text = "Min:" + savings.cheque_deposit_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.cheque_deposit_max != null)
                {
                    lblMaxChequeDepositFees.Text = "Max:" + savings.cheque_deposit_max.ToString() + "  " + _currencymodel.code;
                }
                var userquery = (from usr in db.Users
                                 where usr.id == user_id
                                 select new UserModel_dto
                                 {
                                     userid = usr.id,
                                     user_name = usr.user_name,
                                     user_pass = usr.user_pass,
                                     role_code = usr.role_code,
                                     first_name = usr.first_name,
                                     last_name = usr.last_name,
                                     phone = usr.phone,
                                     mail = usr.mail,
                                     deleted = usr.deleted
                                 }).FirstOrDefault();

                cboSavingsOfficer.SelectedValue = userquery.userid;
                if (savings.deposit_min != null)
                {
                    lblMinDepositAmount.Text = savings.deposit_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.deposit_max != null)
                {
                    lblMaxDepositAmount.Text = savings.deposit_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.withdraw_min != null)
                {
                    lblMinWithDrawAmount.Text = savings.withdraw_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.withdraw_max != null)
                {
                    lblMaxWithDrawAmount.Text = savings.withdraw_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.transfer_min != null)
                {
                    lblMinTransferAmount.Text = savings.transfer_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.transfer_max != null)
                {
                    lblMaxTransferAmount.Text = savings.transfer_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.balance_min != null)
                {
                    lblMinBalanceAmount.Text = savings.balance_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.balance_max != null)
                {
                    lblMaxBalanceAmount.Text = savings.balance_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.interest_frequency != null)
                {
                    lblInterestAccrual.Text = savings.interest_frequency.ToString();
                }
                if (savings.posting_frequency != null)
                {
                    lblInterestPosting.Text = savings.posting_frequency.ToString();
                }
                if (savings.interest_base != null)
                {
                    lblInterestBasedOn.Text = savings.interest_base.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateSavingsDetailsfromSavingsContract(ClientSavingContractModel savings)
        {
            try
            {
                if (savings.code != null)
                {
                    txtSavingsCode.Text = savings.code;
                }
                if (savings.initial_amount != null)
                {
                    txtSavingsInitialAmount.Text = savings.initial_amount.ToString();
                }
                if (savings.entry_fees != null)
                {
                    txtSavingsEntryFees.Text = savings.entry_fees.ToString();
                }
                if (savings.interest_rate != null)
                {
                    txtSavingsInterestRate.Text = savings.interest_rate.ToString();
                }
                if (savings.flat_withdraw_fees != null || savings.rate_withdraw_fees != null)
                {
                    txtWithdrawFees.Text = savings.flat_withdraw_fees.ToString() ?? savings.rate_withdraw_fees.ToString();
                }
                if (savings.flat_transfer_fees != null || savings.rate_transfer_fees != null)
                {
                    txtTransferFees.Text = savings.flat_transfer_fees.ToString() ?? savings.overdraft_fees.ToString();
                }
                if (savings.flat_deposit_fees != null)
                {
                    txtCashDepositFees.Text = savings.flat_deposit_fees.ToString();
                }
                if (savings.flat_close_fees != null)
                {
                    txtCloseFees.Text = savings.flat_close_fees.ToString();
                }
                if (savings.flat_management_fees != null)
                {
                    txtManagementFees.Text = savings.flat_management_fees.ToString();
                }
                if (savings.flat_overdraft_fees != null)
                {
                    txtOverDraftFees.Text = savings.flat_overdraft_fees.ToString();
                }
                if (savings.rate_agio_fees != null)
                {
                    txtAgioFees.Text = savings.rate_agio_fees.ToString();
                }
                if (savings.reopen_fees != null)
                {
                    txtReopenFees.Text = savings.reopen_fees.ToString();
                }
                if (savings.flat_ibt_fee != null || savings.rate_ibt_fee != null)
                {
                    txtInterBranchTransferFees.Text = savings.flat_ibt_fee.ToString() ?? savings.rate_ibt_fee.ToString();
                }
                if (savings.cheque_deposit_fees != null)
                {
                    txtChequeDepositFees.Text = savings.cheque_deposit_fees.ToString();
                }
                if (savings.initial_amount_min != null)
                {
                    lblMinSavingsInitialAmount.Text = "Min:" + savings.initial_amount_min + "  " + _currencymodel.code;
                }
                if (savings.initial_amount_max != null)
                {
                    lblMaxSavingsInitialAmount.Text = "Max:" + savings.initial_amount_max + "  " + _currencymodel.code;
                }
                if (savings.rate_transfer_fees_min != null || savings.flat_transfer_fees_min != null)
                {
                    lblMinTransferFees.Text = "Min:" + savings.rate_transfer_fees_min.ToString() ?? savings.flat_transfer_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.rate_transfer_fees_max != null || savings.flat_transfer_fees_max != null)
                {
                    lblMaxTransferFees.Text = "Max:" + savings.rate_transfer_fees_max.ToString() ?? savings.flat_transfer_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.deposit_fees_min != null)
                {
                    lblMinCashDepositFees.Text = "Min:" + savings.deposit_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.deposit_fees_max != null)
                {
                    lblMaxCashDepositFees.Text = "Max:" + savings.deposit_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.close_fees_min != null)
                {
                    lblMinCloseFees.Text = "Min:" + savings.close_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.close_fees_max != null)
                {
                    lblMaxCloseFees.Text = "Max:" + savings.close_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.management_fees_min != null)
                {
                    lblMinManagementFees.Text = "Min:" + savings.management_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.management_fees_max != null)
                {
                    lblMaxManagementFees.Text = "Max:" + savings.management_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.overdraft_fees_min != null)
                {
                    lblMinOverDraftFees.Text = "Min:" + savings.overdraft_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.overdraft_fees_max != null)
                {
                    lblMaxOverDraftFees.Text = "Max:" + savings.overdraft_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.agio_fees_min != null)
                {
                    lblMinAgio.Text = "Min:" + savings.agio_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.agio_fees_max != null)
                {
                    lblMaxAgio.Text = "Max:" + savings.agio_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.reopen_fees_min != null)
                {
                    lblMinReOpenFees.Text = "Min:" + savings.reopen_fees_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.reopen_fees_max != null)
                {
                    lblMaxReOpenFees.Text = "Max:" + savings.reopen_fees_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.ibt_fee_min != null)
                {
                    lblMinInterBranchTransferFees.Text = "Min:" + savings.ibt_fee_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.ibt_fee_max != null)
                {
                    lblMaxInterBranchTransferFees.Text = "Max:" + savings.ibt_fee_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.cheque_deposit_min != null)
                {
                    lblMinChequeDepositFees.Text = "Min:" + savings.cheque_deposit_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.cheque_deposit_max != null)
                {
                    lblMaxChequeDepositFees.Text = "Max:" + savings.cheque_deposit_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.user_id != null)
                {
                    cboSavingsOfficer.SelectedValue = savings.user_id;
                }
                if (savings.interest_frequency != null)
                {
                    lblInterestAccrual.Text = savings.interest_frequency.ToString();
                }
                if (savings.posting_frequency != null)
                {
                    lblInterestPosting.Text = savings.posting_frequency.ToString();
                }
                if (savings.interest_base != null)
                {
                    lblInterestBasedOn.Text = savings.interest_base.ToString();
                }
                if (savings.deposit_min != null)
                {
                    lblMinDepositAmount.Text = savings.deposit_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.deposit_max != null)
                {
                    lblMaxDepositAmount.Text = savings.deposit_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.withdraw_min != null)
                {
                    lblMinWithDrawAmount.Text = savings.withdraw_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.withdraw_max != null)
                {
                    lblMaxWithDrawAmount.Text = savings.withdraw_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.transfer_min != null)
                {
                    lblMinTransferAmount.Text = savings.transfer_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.transfer_max != null)
                {
                    lblMaxTransferAmount.Text = savings.transfer_max.ToString() + "  " + _currencymodel.code;
                }
                if (savings.balance_min != null)
                {
                    lblMinBalanceAmount.Text = savings.balance_min.ToString() + "  " + _currencymodel.code;
                }
                if (savings.balance_max != null)
                {
                    lblMaxBalanceAmount.Text = savings.balance_max.ToString() + "  " + _currencymodel.code;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void GenerateMenuItems()
        {
            try
            {

                var Loansquery = from ln in rep.GetLoanPackagesList()
                                 where ln.deleted == false
                                 select ln;
                List<LoanPackageModel> Loans = Loansquery.ToList();
                foreach (LoanPackageModel p in Loans)
                {
                    ToolStripMenuItem loanmenu = new ToolStripMenuItem("", Properties.Resources.colormage);
                    loanmenu.Text = p.packageid.ToString() + "  [" + p.name + "]";
                    loanmenu.Click += new EventHandler(loanmenu_Click);
                    AddLoanToolStripMenuItem.DropDownItems.Add(loanmenu);
                }

                var savingsquery = from sv in rep.GetSavingProductsList()
                                   where sv.deleted == false
                                   select sv;
                List<SavingProductModel> Savings = savingsquery.ToList();
                foreach (SavingProductModel s in Savings)
                {
                    ToolStripMenuItem savingsmenu = new ToolStripMenuItem("", Properties.Resources.colormage);
                    savingsmenu.Text = s.savingproductid.ToString() + "  [" + s.name + "]";
                    savingsmenu.Click += new EventHandler(savingsmenu_Click);
                    AddSavingToolStripMenuItem.DropDownItems.Add(savingsmenu);
                }

                var Collateralsquery = from cl in db.CollateralProducts
                                       where cl.deleted == false
                                       select cl;
                List<CollateralProduct> Collaterals = Collateralsquery.ToList();
                foreach (CollateralProduct c in Collaterals)
                {
                    ToolStripMenuItem collateralmenu = new ToolStripMenuItem("", Properties.Resources.colormage);
                    collateralmenu.Text = c.id.ToString() + "  [" + c.name + "]";
                    collateralmenu.Click += new EventHandler(collateralmenu_Click);
                    AddCollateraltoolStripMenuItem.DropDownItems.Add(collateralmenu);
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void BindGridToTransactions()
        {
            try
            {
                dataGridViewClientCustomizableFields.Columns.Clear();
                dataGridViewClientCustomizableFields.Columns[0].Name = "Name";
                dataGridViewClientCustomizableFields.Columns[1].Name = "Value";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loanmenu_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem item = (ToolStripItem)sender;

                string[] separators = { "[", ".", "!" };
                string value = item.Text;
                string[] item_text = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int _id = int.Parse(item_text[0]);

                _loanpackage = this.GetLoanPackage(_id);

                _loancontract = null;

                ClearLoanDetailsControls();

                EnableLoanDetailsControls();

                PopulateLoanDetailsfromPackage(_loanpackage);

                DisableAdvancedSettingsLoanDetailsControls();

                if (!tabControlClients.Contains(tabPageLoansDetails))
                {
                    tabControlClients.TabPages.Add(tabPageLoansDetails);
                }
                if (tabControlClients.Contains(tabPageCreditCommittee))
                {
                    tabControlClients.TabPages.Remove(tabPageCreditCommittee);
                }
                if (tabControlClients.Contains(tabPageAdvancedSettings))
                {
                    tabControlClients.TabPages.Remove(tabPageAdvancedSettings);
                }
                if (tabControlClients.Contains(tabPageGuarantorsandCollaterals))
                {
                    tabControlClients.TabPages.Remove(tabPageGuarantorsandCollaterals);
                }
                if (tabControlClients.Contains(tabPageLoanRepayment))
                {
                    tabControlClients.TabPages.Remove(tabPageLoanRepayment);
                }
                tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageLoansDetails)];
                tabControlLoanDetails.SelectedTab = tabControlLoanDetails.TabPages[tabControlLoanDetails.TabPages.IndexOf(tabPageInstallments)];
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void savingsmenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_clientModel != null)
                {
                    ToolStripItem item = (ToolStripItem)sender;

                    string[] separators = { "[", ".", "!" };
                    string value = item.Text;
                    string[] item_text = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    int _id = int.Parse(item_text[0]);

                    _savingscontract = null;

                    _savingsproduct = new SavingProductModel();

                    _savingsproduct = this.GetSavingProduct(_id);

                    ClearSavingDetailsControls();

                    EnableSavingsDetailsControls();

                    PopulateSavingsDetailsfromSavingsProduct(_savingsproduct);

                    RefreshSavingContractCustomizableFieldsGrid();

                    RefreshSavingsContractsLoanGrid();

                    InitializeSavingsContractBalance();

                    string _imfcode = rep.GetIMFCodefromSettings("IMF_CODE");
                    string _branchcode = _branchmodel.code;
                    int _savingscontractscount = rep.GetClientSavingContractsCount(_clientModel.tierid);
                    int _nextsavingscontractid = rep.GetNextSavingContractId(_clientModel.tierid);
                    int _tierid = _clientModel.tierid;
                    string _contractidno = String.Format("{0:00}", _savingscontractscount);
                    string _clienttierid = String.Format("{0:00000}", _tierid);

                    string _savingsContractCode = _imfcode + "/" + _branchcode + "/" + _contractidno + "/" + _clienttierid + "/" + _nextsavingscontractid;

                    txtSavingsCode.Text = _savingsContractCode.Trim();

                    btnSavingsContractSaveAccount.Visible = true;
                    btnSavingsContractCloseAccount.Visible = false;
                    btnSavingsContractFirstDeposit.Visible = false;

                    if (!tabControlClients.Contains(tabPageSavingsDetails))
                    {
                        tabControlClients.TabPages.Add(tabPageSavingsDetails);
                    }
                    tabControlClients.SelectedTab = tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabPageSavingsDetails)];
                    tabControlSavingsDetails.SelectedTab = tabControlSavingsDetails.TabPages[tabControlSavingsDetails.TabPages.IndexOf(tabPageFeesandLimits)];
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void collateralmenu_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem item = (ToolStripItem)sender;

                string[] separators = { "[", ".", "!" };
                string value = item.Text;
                string[] item_text = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int _id = int.Parse(item_text[0]);

                _collateralproduct = this.GetCollateralProduct(_id);

                AddCollateralForm acf = new AddCollateralForm(_loancontract.contractid, _collateralproduct.id, connection) { Owner = this };
                acf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private LoanPackageModel GetLoanPackage(int id)
        {
            try
            {
                var package = from pk in rep.GetLoanPackagesList()
                              where pk.packageid == id
                              select pk;
                return package.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private SavingProductModel GetSavingProduct(int id)
        {
            try
            {
                var saving = from sv in rep.GetSavingProductsList()
                             where sv.savingproductid == id
                             select sv;
                return saving.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private CollateralProduct GetCollateralProduct(int id)
        {
            try
            {
                var cp = from c in db.CollateralProducts
                         where c.id == id
                         select c;
                return cp.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private decimal GetSavingsContractBalance(int tierid, int contractid)
        {
            try
            {
                decimal _balance = 0;
                var _contractsquery = rep.GetNextSavingContractId(tierid, contractid);
                _balance = _contractsquery;
                return _balance;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        #endregion "Initialization"
        #region "DataGridViews"
        private void dataGridViewSavingsEvents_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    DataGridViewRow row = dataGridViewSavingsEvents.CurrentCell.OwningRow;
                    string value = row.Cells["Columnpending"].Value.ToString();
                    if (value.Equals("True"))
                    {
                        dataGridViewSavingsEvents.ContextMenuStrip = contextMenuStripPendingEvents;
                    }
                    if (value.Equals("False"))
                    {
                        dataGridViewSavingsEvents.ContextMenuStrip = null;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewLoanEntryFees_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLoanEntryFees.SelectedRows.Count != 0)
                {
                    CreditEntryFeesModel creditentryfees = (CreditEntryFeesModel)bindingSourceEntryFees.Current;
                    if (creditentryfees.max != null)
                    {
                        lblEntryFeeMax.Text = "Max: " + creditentryfees.max.ToString();
                    }
                    if (creditentryfees.min != null)
                    {
                        lblEntryFeesMin.Text = "Min: " + creditentryfees.min.ToString();
                    }
                    if (creditentryfees.max == null)
                    {
                        lblEntryFeeMax.Text = string.Empty;
                    }
                    if (creditentryfees.min == null)
                    {
                        lblEntryFeesMin.Text = string.Empty;
                    }
                    chkRate.Checked = creditentryfees.rate.Value;
                }
                if (dataGridViewLoanEntryFees.SelectedRows.Count == 0)
                {
                    lblEntryFeeMax.Text = string.Empty;
                    lblEntryFeesMin.Text = string.Empty;
                    chkRate.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLoanContracts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLoanContracts.SelectedRows.Count != 0)
                {
                    RefreshLoanContractCollateralsGrid();

                    RefreshLoanContractCustomizableFieldsGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingsEvents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingContracts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSavingContracts.SelectedRows.Count != 0)
                {
                    RefreshSavingContractCustomizableFieldsGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLoanCustomizableFields_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLoanCustomizableFields.SelectedRows.Count != 0)
                {

                    lblLoanContractCustomFieldName.Text = "Name: " + dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnName"].Value.ToString();
                    lblLoanContractCustomFieldDescription.Text = "Description: " + dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnDesc"].Value.ToString();
                    chkLoanContractCustomFieldMandatory.Checked = Convert.ToBoolean(dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnIsMandatory"].Value.ToString());
                    chkLoanContractCustomFieldUnique.Checked = Convert.ToBoolean(dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnIsUnique"].Value.ToString());
                }
                if (dataGridViewLoanCustomizableFields.SelectedRows.Count == 0)
                {
                    lblLoanContractCustomFieldName.Text = string.Empty;
                    lblLoanContractCustomFieldDescription.Text = string.Empty;
                    chkLoanContractCustomFieldMandatory.Checked = false;
                    chkLoanContractCustomFieldUnique.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingsCustomizableFields_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSavingsCustomizableFields.SelectedRows.Count != 0)
                {

                    lblSavingContractCustomFieldName.Text = "Name: " + dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnName"].Value.ToString();
                    lblSavingContractCustomFieldDescription.Text = "Description: " + dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnDesc"].Value.ToString();
                    chkSavingContractCustomFieldMandatory.Checked = Convert.ToBoolean(dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnIsMandatory"].Value.ToString());
                    chkSavingContractCustomFieldUnique.Checked = Convert.ToBoolean(dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnIsUnique"].Value.ToString());
                }
                if (dataGridViewSavingsCustomizableFields.SelectedRows.Count == 0)
                {
                    lblSavingContractCustomFieldName.Text = string.Empty;
                    lblSavingContractCustomFieldDescription.Text = string.Empty;
                    chkSavingContractCustomFieldMandatory.Checked = false;
                    chkSavingContractCustomFieldUnique.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingsCustomizableFields_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewSavingsCustomizableFields.SelectedRows.Count != 0)
                {

                    lblSavingContractCustomFieldName.Text = "Name: " + dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnName"].Value.ToString();
                    lblSavingContractCustomFieldDescription.Text = "Description: " + dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnDesc"].Value.ToString();
                    chkSavingContractCustomFieldMandatory.Checked = Convert.ToBoolean(dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnIsMandatory"].Value.ToString());
                    chkSavingContractCustomFieldUnique.Checked = Convert.ToBoolean(dataGridViewSavingsCustomizableFields.CurrentRow.Cells["columnIsUnique"].Value.ToString());
                }
                if (dataGridViewSavingsCustomizableFields.SelectedRows.Count == 0)
                {
                    lblSavingContractCustomFieldName.Text = string.Empty;
                    lblSavingContractCustomFieldDescription.Text = string.Empty;
                    chkSavingContractCustomFieldMandatory.Checked = false;
                    chkSavingContractCustomFieldUnique.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLoanCustomizableFields_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewLoanCustomizableFields.SelectedRows.Count != 0)
                {

                    lblLoanContractCustomFieldName.Text = "Name: " + dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnName"].Value.ToString();
                    lblLoanContractCustomFieldDescription.Text = "Description: " + dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnDesc"].Value.ToString();
                    chkLoanContractCustomFieldMandatory.Checked = Convert.ToBoolean(dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnIsMandatory"].Value.ToString());
                    chkLoanContractCustomFieldUnique.Checked = Convert.ToBoolean(dataGridViewLoanCustomizableFields.CurrentRow.Cells["columnIsUnique"].Value.ToString());
                }
                if (dataGridViewLoanCustomizableFields.SelectedRows.Count == 0)
                {
                    lblLoanContractCustomFieldName.Text = string.Empty;
                    lblLoanContractCustomFieldDescription.Text = string.Empty;
                    chkLoanContractCustomFieldMandatory.Checked = false;
                    chkLoanContractCustomFieldUnique.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClientCustomizableFields_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClientCustomizableFields.SelectedRows.Count != 0)
                {

                    lblCustomFieldsName.Text = "Name: " + dataGridViewClientCustomizableFields.CurrentRow.Cells["columnName"].Value.ToString();
                    lblCustomFieldsDescription.Text = "Description: " + dataGridViewClientCustomizableFields.CurrentRow.Cells["columnDesc"].Value.ToString();
                    chkattMandatory.Checked = Convert.ToBoolean(dataGridViewClientCustomizableFields.CurrentRow.Cells["columnIsMandatory"].Value.ToString());
                    chkattUnique.Checked = Convert.ToBoolean(dataGridViewClientCustomizableFields.CurrentRow.Cells["columnIsUnique"].Value.ToString());
                }
                if (dataGridViewClientCustomizableFields.SelectedRows.Count == 0)
                {
                    lblCustomFieldsName.Text = string.Empty;
                    lblCustomFieldsDescription.Text = string.Empty;
                    chkattMandatory.Checked = false;
                    chkattUnique.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLoanCustomizableFields_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingsCustomizableFields_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingsLoanContracts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClientCustomizableFields_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewClientCustomizableFields.SelectedRows.Count != 0)
                {

                    lblCustomFieldsName.Text = "Name: " + dataGridViewClientCustomizableFields.CurrentRow.Cells["columnName"].Value.ToString();
                    lblCustomFieldsDescription.Text = "Description: " + dataGridViewClientCustomizableFields.CurrentRow.Cells["columnDesc"].Value.ToString();
                    chkattMandatory.Checked = Convert.ToBoolean(dataGridViewClientCustomizableFields.CurrentRow.Cells["columnIsMandatory"].Value.ToString());
                    chkattUnique.Checked = Convert.ToBoolean(dataGridViewClientCustomizableFields.CurrentRow.Cells["columnIsUnique"].Value.ToString());
                }
                if (dataGridViewClientCustomizableFields.SelectedRows.Count == 0)
                {
                    lblCustomFieldsName.Text = string.Empty;
                    lblCustomFieldsDescription.Text = string.Empty;
                    chkattMandatory.Checked = false;
                    chkattUnique.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLoanContracts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClientCustomizableFields_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingContracts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingContracts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSavingContracts.SelectedRows.Count != 0)
            {
                try
                {
                    InitializeSavingsContractsDetails();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewLoanContracts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                InitializeLoanContractDetails();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "DataGridViews"
        #region "Menus"
        private void confirmPendingEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSavingsEvents.SelectedRows.Count != 0)
                {
                    SavingsEventsModel _savingevent = (SavingsEventsModel)bindingSourceSavingsEvents.Current;
                    _savingevent.pending = false;

                    rep.UpdateSavingsContractEventPending(_savingevent);

                    RefreshSavingsContractEventsGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cancelPendingEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSavingsEvents.SelectedRows.Count != 0)
                {
                    SavingsEventsModel _savingevent = (SavingsEventsModel)bindingSourceSavingsEvents.Current;
                    _savingevent.pending = false;

                    rep.UpdateSavingsContractEventPending(_savingevent);

                    RefreshSavingsContractEventsGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void clientPersonalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_clientModel == null)
                {
                    MessageBox.Show("Client cannot be null!", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ( _branchmodel == null)
                {
                    MessageBox.Show("Branch cannot be null!", Utils.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (_clientModel != null && _branchmodel != null)
                {
                    //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(_clientModel.personid,_branchmodel.branchid,user_id, connection);
                    //_viewer.WindowState = FormWindowState.Normal;
                    //_viewer.StartPosition = FormStartPosition.CenterScreen;
                    //_viewer.Show();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void contractHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void disbursementCashReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void individualLoanAgreementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void committeeAppraisalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void repaymentCashReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void repaymentScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void savingAgreementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cashReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void contractStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_savingscontract != null && _currencymodel != null)
                {
                    SavingsDepositOperationsForm sfdf = new SavingsDepositOperationsForm(_savingscontract, _currencymodel, user_id, connection) { Owner = this };
                    sfdf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void withdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_savingscontract != null && _currencymodel != null)
                {
                    SavingsWithdrawOperationsForm sfdf = new SavingsWithdrawOperationsForm(_savingscontract, _currencymodel, user_id, connection) { Owner = this };
                    sfdf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_savingscontract != null && _currencymodel != null)
                {
                    SavingsTransferOperationsForm sfdf = new SavingsTransferOperationsForm(_savingscontract, _currencymodel, user_id, connection) { Owner = this };
                    sfdf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void specialOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_savingscontract != null && _currencymodel != null)
                {
                    SavingsSpecialOperationsForm sfdf = new SavingsSpecialOperationsForm(_savingscontract, _currencymodel, user_id, connection) { Owner = this };
                    sfdf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void guarantorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loanEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientReportsPDFViewer _viewer = new ClientReportsPDFViewer(user_id, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Menus"
        #region "Helpers"
        private bool NotifyMessage(string _Title, string _Text)
        {
            try
            {
                appNotifyIcon.Text = Utils.APP_NAME;
                appNotifyIcon.Icon = new Icon("Resources/Icons/Dollar.ico");
                appNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                appNotifyIcon.BalloonTipTitle = _Title;
                appNotifyIcon.BalloonTipText = _Text;
                appNotifyIcon.Visible = true;
                appNotifyIcon.ShowBalloonTip(900000);

                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        private void HideTabPage(TabPage tp)
        {
            if (tabControlClients.TabPages.Contains(tp))
                tabControlClients.TabPages.Remove(tp);
        }
        private void ShowTabPage(TabPage tp)
        {
            ShowTabPage(tp, tabControlClients.TabPages.Count);
        }
        private void ShowTabPage(TabPage tp, int index)
        {
            if (tabControlClients.TabPages.Contains(tp)) return;
            InsertTabPage(tp, index);
        }
        private void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > tabControlClients.TabCount)
                throw new ArgumentException("Index out of Range.");
            tabControlClients.TabPages.Add(tabpage);
            if (index < tabControlClients.TabCount - 1)
                do
                {
                    SwapTabPages(tabpage, (tabControlClients.TabPages[tabControlClients.TabPages.IndexOf(tabpage) - 1]));
                }
                while (tabControlClients.TabPages.IndexOf(tabpage) != index);
            tabControlClients.SelectedTab = tabpage;
        }
        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            if (tabControlClients.TabPages.Contains(tp1) == false || tabControlClients.TabPages.Contains(tp2) == false)
                throw new ArgumentException("TabPages must be in the TabControls TabPageCollection.");

            int Index1 = tabControlClients.TabPages.IndexOf(tp1);
            int Index2 = tabControlClients.TabPages.IndexOf(tp2);
            tabControlClients.TabPages[Index1] = tp2;
            tabControlClients.TabPages[Index2] = tp1;
        }
        #endregion "Helpers"









































        #endregion "Private Methods"













    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace LoansModule.Views
{
    public partial class AddLoanProductForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        BindingList<CycleParametersModel> _CycleObjectParameters;
        #endregion "Private Fields"

        #region "Constructor"
        public AddLoanProductForm(string Conn)
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
        private void AddNewLoanProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region "Combobox"
                var RoundingTypes = new BindingList<KeyValuePair<int, string>>();
                RoundingTypes.Add(new KeyValuePair<int, string>(0, "Approximate"));
                RoundingTypes.Add(new KeyValuePair<int, string>(1, "First Installment"));
                RoundingTypes.Add(new KeyValuePair<int, string>(2, "Last Installment"));
                cboRoundingType.DataSource = RoundingTypes;
                cboRoundingType.ValueMember = "Key";
                cboRoundingType.DisplayMember = "Value";
                //cboRoundingType.SelectedIndex = -1;

                var currenciesquery = from cr in rep.GetCurrenciesList()
                                      select cr;
                List<CurrencyModel> currencies = currenciesquery.ToList();
                cboCurrency.DataSource = currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                //cboCurrency.SelectedIndex = -1;

                var installmenttypesquery = from it in db.InstallmentTypes
                                            select it;
                List<InstallmentType> InstallmentTypes = installmenttypesquery.ToList();
                cboInstallmentTypes.DataSource = InstallmentTypes;
                cboInstallmentTypes.ValueMember = "id";
                cboInstallmentTypes.DisplayMember = "name";
                //cboInstallmentTypes.SelectedIndex = -1;

                List<FundingLineModel> FundingLines = rep.GetFundingLinesList();
                cboFundingLine.DataSource = FundingLines;
                cboFundingLine.ValueMember = "fundinglineid";
                cboFundingLine.DisplayMember = "name";
                //cboFundingLine.SelectedIndex = -1;

                var AdvancedParametersLoanCyclesquery = from lc in rep.GetAllCycles()
                                                        select lc;
                List<CyclesModel> AdvancedParametersLoanCycles = AdvancedParametersLoanCyclesquery.ToList();
                cboCycles.DataSource = AdvancedParametersLoanCycles;
                cboCycles.ValueMember = "cycleid";
                cboCycles.DisplayMember = "name";

                var cycleobjectsquery = from co in rep.GetAllCycleObjects()
                                        select co;
                List<CycleObjectsModel> CycleObjects = cycleobjectsquery.ToList();
                cboCycleObjects.DataSource = CycleObjects;
                cboCycleObjects.ValueMember = "cycleobjectid";
                cboCycleObjects.DisplayMember = "name";
                #endregion "Combobox"

                #region "DataGridView"
                dataGridViewEntryFees.AutoGenerateColumns = false;
                this.dataGridViewEntryFees.SelectionMode = DataGridViewSelectionMode.CellSelect;
                bindingSourceEntryFees.DataSource = rep.GetAllEntryFees();
                dataGridViewEntryFees.DataSource = bindingSourceEntryFees;
                #endregion "DataGridView"

                #region "GroupBox"
                groupBox31.Visible = false;
                groupBoxUseGuarantorsandCollaterals.Enabled = false;
                groupBoxSetSeparateValuesforGuarantorsandCollaterals.Enabled = false;
                groupBoxCompulsorySavingAmount.Enabled = false;
                groupBox17.Visible = false;
                groupBoxUseLoanCycle.Visible = false;
                groupBox15.Visible = false;
                #endregion "GroupBox"

                #region "RadioButton"
                radioButtonATRFeespercentageonOLB.Checked = true;
                rbtnNone.Checked = true;
                radioButtonAPRFeespercentageonOLB.Checked = true;
                radioButtonRateCompulsorySavingAmount.Checked = true;
                radioButtonFlatInterestType.Checked = true;
                radioButtonNoGracePeriod.Checked = true;
                #endregion "RadioButton"

                #region "Cycles"
                bindingSourceCycleObjectParameters.DataSource = null;
                dataGridViewCycleObjectParameters.AutoGenerateColumns = false;
                this.dataGridViewCycleObjectParameters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewCycleObjectParameters.DataSource = bindingSourceCycleObjectParameters;
                groupBoxCycleObjectParameters.Visible = false;
                txtMaxAmount.Enabled = false;
                txtMinAmount.Enabled = false;
                #endregion "Cycles"
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
            if (IsLoanProductValid())
            {
                try
                {

                    LoanPackageModel loan = new LoanPackageModel();
                    loan.loan_type = 0;
                    loan.client_type = "I";
                    loan.installment_type = 1;

                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        loan.name = Utils.ConvertFirstLetterToUpper(txtName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtCode.Text))
                    {
                        loan.code = Utils.ConvertFirstLetterToUpper(txtCode.Text.Trim());
                    }
                    if (cboRoundingType.SelectedIndex != -1)
                    {
                        loan.rounding_type = short.Parse(cboRoundingType.SelectedValue.ToString());
                    }
                    if (cboFundingLine.SelectedIndex != -1)
                    {
                        loan.fundingLine_id = int.Parse(cboFundingLine.SelectedValue.ToString());
                    }
                    if (cboCurrency.SelectedIndex != -1)
                    {
                        loan.currency_id = int.Parse(cboCurrency.SelectedValue.ToString());
                    }
                    int MinGracePeriod;
                    if (!string.IsNullOrEmpty(txtMinGracePeriod.Text) && int.TryParse(txtMinGracePeriod.Text, out MinGracePeriod))
                    {
                        loan.grace_period_min = int.Parse(txtMinGracePeriod.Text);
                    }
                    int MaxGracePeriod;
                    if (!string.IsNullOrEmpty(txtMaxGracePeriod.Text) && int.TryParse(txtMaxGracePeriod.Text, out MaxGracePeriod))
                    {
                        loan.grace_period_max = int.Parse(txtMaxGracePeriod.Text);
                    }
                    int ValueGracePeriod;
                    if (!string.IsNullOrEmpty(txtValueGracePeriod.Text) && int.TryParse(txtValueGracePeriod.Text, out ValueGracePeriod))
                    {
                        loan.grace_period = int.Parse(txtValueGracePeriod.Text);
                    }
                    decimal _MinAmount;
                    if (!string.IsNullOrEmpty(txtMinAmount.Text) && decimal.TryParse(txtMinAmount.Text, out _MinAmount))
                    {
                        loan.amount_min = decimal.Parse(txtMinAmount.Text);
                    }
                    decimal _MaxAmount;
                    if (!string.IsNullOrEmpty(txtMaxAmount.Text) && decimal.TryParse(txtMaxAmount.Text, out _MaxAmount))
                    {
                        loan.amount_max = decimal.Parse(txtMaxAmount.Text);
                    }
                    decimal _ValueAmount;
                    if (!string.IsNullOrEmpty(txtValueAmount.Text) && decimal.TryParse(txtValueAmount.Text, out _ValueAmount))
                    {
                        loan.amount = decimal.Parse(txtValueAmount.Text);
                    }
                    int MinInterestRate;
                    if (!string.IsNullOrEmpty(txtMinInterestRate.Text) && int.TryParse(txtMinInterestRate.Text, out MinInterestRate))
                    {
                        loan.interest_rate_min = int.Parse(txtMinInterestRate.Text);
                    }
                    int MaxInterestRate;
                    if (!string.IsNullOrEmpty(txtMaxInterestRate.Text) && int.TryParse(txtMaxInterestRate.Text, out MaxInterestRate))
                    {
                        loan.interest_rate_max = int.Parse(txtMaxInterestRate.Text);
                    }
                    int ValueInterestRate;
                    if (!string.IsNullOrEmpty(txtValueInterestRate.Text) && int.TryParse(txtValueInterestRate.Text, out ValueInterestRate))
                    {
                        loan.interest_rate = int.Parse(txtValueInterestRate.Text);
                    }
                    int MinNumberofInstallments;
                    if (!string.IsNullOrEmpty(txtMinNumberofInstallments.Text) && int.TryParse(txtMinNumberofInstallments.Text, out MinNumberofInstallments))
                    {
                        loan.number_of_installments_min = int.Parse(txtMinNumberofInstallments.Text);
                    }
                    int MaxNumberofInstallments;
                    if (!string.IsNullOrEmpty(txtMaxNumberofInstallments.Text) && int.TryParse(txtMaxNumberofInstallments.Text, out MaxNumberofInstallments))
                    {
                        loan.number_of_installments_max = int.Parse(txtMaxNumberofInstallments.Text);
                    }
                    int ValueNumberofInstallments;
                    if (!string.IsNullOrEmpty(txtValueNumberofInstallments.Text) && int.TryParse(txtValueNumberofInstallments.Text, out ValueNumberofInstallments))
                    {
                        loan.number_of_installments = int.Parse(txtValueNumberofInstallments.Text);
                    }
                    int MinLateFeesonTotalLoanAmount;
                    if (!string.IsNullOrEmpty(txtMinLateFeesonTotalLoanAmount.Text) && int.TryParse(txtMinLateFeesonTotalLoanAmount.Text, out MinLateFeesonTotalLoanAmount))
                    {
                        loan.non_repayment_penalties_based_on_initial_amount_min = int.Parse(txtMinLateFeesonTotalLoanAmount.Text);
                    }
                    int MaxLateFeesonTotalLoanAmount;
                    if (!string.IsNullOrEmpty(txtMaxLateFeesonTotalLoanAmount.Text) && int.TryParse(txtMaxLateFeesonTotalLoanAmount.Text, out MaxLateFeesonTotalLoanAmount))
                    {
                        loan.non_repayment_penalties_based_on_initial_amount_max = int.Parse(txtMaxLateFeesonTotalLoanAmount.Text);
                    }
                    int ValueLateFeesonTotalLoanAmount;
                    if (!string.IsNullOrEmpty(txtValueLateFeesonTotalLoanAmount.Text) && int.TryParse(txtValueLateFeesonTotalLoanAmount.Text, out ValueLateFeesonTotalLoanAmount))
                    {
                        loan.non_repayment_penalties_based_on_initial_amount = int.Parse(txtValueLateFeesonTotalLoanAmount.Text);
                    }
                    int MinLateFeesonOLB;
                    if (!string.IsNullOrEmpty(txtMinLateFeesonOLB.Text) && int.TryParse(txtMinLateFeesonOLB.Text, out MinLateFeesonOLB))
                    {
                        loan.non_repayment_penalties_based_on_olb_min = int.Parse(txtMinLateFeesonOLB.Text);
                    }
                    int MaxLateFeesonOLB;
                    if (!string.IsNullOrEmpty(txtMaxLateFeesonOLB.Text) && int.TryParse(txtMaxLateFeesonOLB.Text, out MaxLateFeesonOLB))
                    {
                        loan.non_repayment_penalties_based_on_olb_max = int.Parse(txtMaxLateFeesonOLB.Text);
                    }
                    int ValueLateFeesonOLB;
                    if (!string.IsNullOrEmpty(txtValueLateFeesonOLB.Text) && int.TryParse(txtValueLateFeesonOLB.Text, out ValueLateFeesonOLB))
                    {
                        loan.non_repayment_penalties_based_on_olb = int.Parse(txtValueLateFeesonOLB.Text);
                    }
                    int MinLateFeesonOverduePrincipal;
                    if (!string.IsNullOrEmpty(txtMinLateFeesonOverduePrincipal.Text) && int.TryParse(txtMinLateFeesonOverduePrincipal.Text, out MinLateFeesonOverduePrincipal))
                    {
                        loan.non_repayment_penalties_based_on_overdue_principal_min = int.Parse(txtMinLateFeesonOverduePrincipal.Text);
                    }
                    int MaxLateFeesonOverduePrincipal;
                    if (!string.IsNullOrEmpty(txtMaxLateFeesonOverduePrincipal.Text) && int.TryParse(txtMaxLateFeesonOverduePrincipal.Text, out MaxLateFeesonOverduePrincipal))
                    {
                        loan.non_repayment_penalties_based_on_overdue_principal_max = int.Parse(txtMaxLateFeesonOverduePrincipal.Text);
                    }
                    int ValueLateFeesonOverduePrincipal;
                    if (!string.IsNullOrEmpty(txtValueLateFeesonOverduePrincipal.Text) && int.TryParse(txtValueLateFeesonOverduePrincipal.Text, out ValueLateFeesonOverduePrincipal))
                    {
                        loan.non_repayment_penalties_based_on_overdue_principal = int.Parse(txtValueLateFeesonOverduePrincipal.Text);
                    }
                    int MinLateFeesonOverdueInterest;
                    if (!string.IsNullOrEmpty(txtMinLateFeesonOverdueInterest.Text) && int.TryParse(txtMinLateFeesonOverdueInterest.Text, out MinLateFeesonOverdueInterest))
                    {
                        loan.non_repayment_penalties_based_on_overdue_interest_min = int.Parse(txtMinLateFeesonOverdueInterest.Text);
                    }
                    int MaxLateFeesonOverdueInterest;
                    if (!string.IsNullOrEmpty(txtMaxLateFeesonOverdueInterest.Text) && int.TryParse(txtMaxLateFeesonOverdueInterest.Text, out MaxLateFeesonOverdueInterest))
                    {
                        loan.non_repayment_penalties_based_on_overdue_interest_max = int.Parse(txtMaxLateFeesonOverdueInterest.Text);
                    }
                    int ValueLateFeesonOverdueInterest;
                    if (!string.IsNullOrEmpty(txtValueLateFeesonOverdueInterest.Text) && int.TryParse(txtValueLateFeesonOverdueInterest.Text, out ValueLateFeesonOverdueInterest))
                    {
                        loan.non_repayment_penalties_based_on_overdue_interest = int.Parse(txtValueLateFeesonOverdueInterest.Text);
                    }
                    int GracePeriodofLateFees;
                    if (!string.IsNullOrEmpty(txtGracePeriodofLateFees.Text) && int.TryParse(txtGracePeriodofLateFees.Text, out GracePeriodofLateFees))
                    {
                        loan.grace_period_of_latefees = int.Parse(txtGracePeriodofLateFees.Text);
                    }
                    int MinATRFees;
                    if (!string.IsNullOrEmpty(txtMinATRFees.Text) && int.TryParse(txtMinATRFees.Text, out MinATRFees))
                    {
                        loan.anticipated_total_repayment_penalties_min = int.Parse(txtMinATRFees.Text);
                    }
                    int MaxATRFees;
                    if (!string.IsNullOrEmpty(txtMaxATRFees.Text) && int.TryParse(txtMaxATRFees.Text, out MaxATRFees))
                    {
                        loan.anticipated_total_repayment_penalties_max = int.Parse(txtMaxATRFees.Text);
                    }
                    int ValueATRFees;
                    if (!string.IsNullOrEmpty(txtValueATRFees.Text) && int.TryParse(txtValueATRFees.Text, out ValueATRFees))
                    {
                        loan.anticipated_total_repayment_penalties = int.Parse(txtValueATRFees.Text);
                    }
                    foreach (Control ctrl in groupBoxBaseforATRFees.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                switch (((RadioButton)ctrl).Name)
                                {
                                    case "radioButtonATRFeespercentageonOLB":
                                        loan.anticipated_total_repayment_base = 0;
                                        break;
                                    case "radioButtonATRFeespercentageonInterest":
                                        loan.anticipated_total_repayment_base = 1;
                                        break;
                                }
                            }
                        }
                    }
                    int MinAPRFees;
                    if (!string.IsNullOrEmpty(txtMinAPRFees.Text) && int.TryParse(txtMinAPRFees.Text, out MinAPRFees))
                    {
                        loan.anticipated_partial_repayment_penalties_min = int.Parse(txtMinAPRFees.Text);
                    }
                    int MaxAPRFees;
                    if (!string.IsNullOrEmpty(txtMaxAPRFees.Text) && int.TryParse(txtMaxAPRFees.Text, out MaxAPRFees))
                    {
                        loan.anticipated_partial_repayment_penalties_max = int.Parse(txtMaxAPRFees.Text);
                    }
                    int ValueAPRFees;
                    if (!string.IsNullOrEmpty(txtValueAPRFees.Text) && int.TryParse(txtValueAPRFees.Text, out ValueAPRFees))
                    {
                        loan.anticipated_partial_repayment_penalties = int.Parse(txtValueAPRFees.Text);
                    }
                    foreach (Control ctrl in groupBoxBaseforAPRFees.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                switch (((RadioButton)ctrl).Name)
                                {
                                    case "radioButtonAPRFeespercentageonOLB":
                                        loan.anticipated_partial_repayment_base = 0;
                                        break;
                                    case "radioButtonAPRFeespercentageonInterest":
                                        loan.anticipated_partial_repayment_base = 1;
                                        break;
                                    case "radioButtonAPRFeespercentageonPrepaidPrincipal":
                                        loan.anticipated_partial_repayment_base = 2;
                                        break;
                                }
                            }
                        }
                    }
                    loan.allow_flexible_schedule = chkAllowFlexibleSchedule.Checked;
                    int NoofDrawingsunderLOC;
                    if (!string.IsNullOrEmpty(txtNoofDrawingsunderLOC.Text) && int.TryParse(txtNoofDrawingsunderLOC.Text, out NoofDrawingsunderLOC))
                    {
                        loan.number_of_drawings_loc = int.Parse(txtNoofDrawingsunderLOC.Text);
                    }
                    decimal _MinAmountunderLOC;
                    if (!string.IsNullOrEmpty(txtMinAmountunderLOC.Text) && decimal.TryParse(txtMinAmountunderLOC.Text, out _MinAmountunderLOC))
                    {
                        loan.amount_under_loc_min = decimal.Parse(txtMinAmountunderLOC.Text);
                    }
                    decimal _MaxAmountunderLOC;
                    if (!string.IsNullOrEmpty(txtMaxAmountunderLOC.Text) && decimal.TryParse(txtMaxAmountunderLOC.Text, out _MaxAmountunderLOC))
                    {
                        loan.amount_under_loc_max = decimal.Parse(txtMaxAmountunderLOC.Text);
                    }
                    decimal ValueAmountunderLOC;
                    if (!string.IsNullOrEmpty(txtValueAmountunderLOC.Text) && decimal.TryParse(txtValueAmountunderLOC.Text, out ValueAmountunderLOC))
                    {
                        loan.amount_under_loc = decimal.Parse(txtValueAmountunderLOC.Text);
                    }
                    int MinTrancheMaturity;
                    if (!string.IsNullOrEmpty(txtMinTrancheMaturity.Text) && int.TryParse(txtMinTrancheMaturity.Text, out MinTrancheMaturity))
                    {
                        loan.maturity_loc_min = int.Parse(txtMinTrancheMaturity.Text);
                    }
                    int MaxTrancheMaturity;
                    if (!string.IsNullOrEmpty(txtMaxTrancheMaturity.Text) && int.TryParse(txtMaxTrancheMaturity.Text, out MaxTrancheMaturity))
                    {
                        loan.maturity_loc_max = int.Parse(txtMaxTrancheMaturity.Text);
                    }
                    int ValueTrancheMaturity;
                    if (!string.IsNullOrEmpty(txtValueTrancheMaturity.Text) && int.TryParse(txtValueTrancheMaturity.Text, out ValueTrancheMaturity))
                    {
                        loan.maturity_loc = int.Parse(txtValueTrancheMaturity.Text);
                    }
                    loan.use_guarantor_collateral = chkUseGuarantorsandCollateral.Checked;
                    int PercentageofGuarantorsandCollaterals;
                    if (!string.IsNullOrEmpty(txtMinPercentageofGuarantorsandCollaterals.Text) && int.TryParse(txtMinPercentageofGuarantorsandCollaterals.Text, out PercentageofGuarantorsandCollaterals))
                    {
                        loan.percentage_total_guarantor_collateral = int.Parse(txtMinPercentageofGuarantorsandCollaterals.Text);
                    }
                    loan.set_separate_guarantor_collateral = chkSetSeparateValuesforGuarantorsandCollaterals.Checked;
                    int PercentageforGuarantors;
                    if (!string.IsNullOrEmpty(txtMinPercentageforGuarantors.Text) && int.TryParse(txtMinPercentageforGuarantors.Text, out PercentageforGuarantors))
                    {
                        loan.percentage_separate_guarantor = int.Parse(txtMinPercentageforGuarantors.Text);
                    }
                    int PercentageforCollaterals;
                    if (!string.IsNullOrEmpty(txtMinPercentageforCollaterals.Text) && int.TryParse(txtMinPercentageforCollaterals.Text, out PercentageforCollaterals))
                    {
                        loan.percentage_separate_collateral = int.Parse(txtMinPercentageforCollaterals.Text);
                    }
                    loan.use_compulsory_savings = chkUseCompulsorySavings.Checked;
                    decimal MinCompulsorySavingsAmount;
                    if (!string.IsNullOrEmpty(txtMinCompulsorySavingsAmount.Text) && decimal.TryParse(txtMinCompulsorySavingsAmount.Text, out MinCompulsorySavingsAmount))
                    {
                        loan.compulsory_amount_min = int.Parse(txtMinCompulsorySavingsAmount.Text);
                    }
                    decimal MaxCompulsorySavingsAmount;
                    if (!string.IsNullOrEmpty(txtMaxCompulsorySavingsAmount.Text) && decimal.TryParse(txtMaxCompulsorySavingsAmount.Text, out MaxCompulsorySavingsAmount))
                    {
                        loan.compulsory_amount_max = int.Parse(txtMaxCompulsorySavingsAmount.Text);
                    }
                    decimal ValueCompulsorySavingsAmount;
                    if (!string.IsNullOrEmpty(txtValueCompulsorySavingsAmount.Text) && decimal.TryParse(txtValueCompulsorySavingsAmount.Text, out ValueCompulsorySavingsAmount))
                    {
                        loan.compulsory_amount = int.Parse(txtValueCompulsorySavingsAmount.Text);
                    }
                    decimal MinCreditInsurance;
                    if (!string.IsNullOrEmpty(txtMinCreditInsurance.Text) && decimal.TryParse(txtMinCreditInsurance.Text, out MinCreditInsurance))
                    {
                        loan.insurance_min = decimal.Parse(txtMinCreditInsurance.Text);
                    }
                    decimal MaxCreditInsurance;
                    if (!string.IsNullOrEmpty(txtMaxCreditInsurance.Text) && decimal.TryParse(txtMaxCreditInsurance.Text, out MaxCreditInsurance))
                    {
                        loan.insurance_max = decimal.Parse(txtMaxCreditInsurance.Text);
                    }

                    if (rep.GetLoanPackagesList().Any(i => i.code == loan.code && i.name == loan.name))
                    {
                        MessageBox.Show("Loan Product with Name " + loan.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!rep.GetLoanPackagesList().Any(i => i.code == loan.code && i.name == loan.name))
                    {
                        rep.AddNewLoanPackage(loan);

                        //LoanProductsListForm f = (LoanProductsListForm)this.Owner;
                        LoanProductsListForm f = new LoanProductsListForm(connection);
                        if (this.Owner == f)
                        {
                            f.RefreshGrid();
                        }
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsLoanProductValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtCode, "Code cannot be null!");
                return false;
            }
            return noerror;
        }
        private bool IsCyclePropertyValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtCycleMinAmount.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtCycleMinAmount, "Min Amount cannot be null!");
                return false;
            }
            decimal _MinAmount;
            if (!decimal.TryParse(txtCycleMinAmount.Text, out _MinAmount))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtCycleMinAmount, "Min Amount must be decimal!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCycleMaxAmount.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtCycleMaxAmount, "Max Amount cannot be null!");
                return false;
            }
            decimal _MaxAmount;
            if (!decimal.TryParse(txtCycleMaxAmount.Text, out _MaxAmount))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtCycleMaxAmount, "Max Amount must be decimal!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"
        private void chkAllClients_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllClients.Checked)
            {
                chkIndividualClient.Checked = true;
                chkSolidarityClient.Checked = true;
                chkNonSolidarityClient.Checked = true;
                chkCorporateClient.Checked = true;
            }
            else
            {
                chkIndividualClient.Checked = false;
                chkSolidarityClient.Checked = false;
                chkNonSolidarityClient.Checked = false;
                chkCorporateClient.Checked = false;
            }
        }
        private void chkUseLoanCycleEntryFees_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseLoanCycleEntryFees.Checked)
            {
                groupBox31.Visible = true;
            }
            else
            {
                groupBox31.Visible = false;
            }
        }
        private void chkUseGuarantorsandCollateral_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseGuarantorsandCollateral.Checked)
            {
                groupBoxUseGuarantorsandCollaterals.Enabled = true;
                chkSetSeparateValuesforGuarantorsandCollaterals.Enabled = true;
            }
            else
            {
                groupBoxUseGuarantorsandCollaterals.Enabled = false;
                chkSetSeparateValuesforGuarantorsandCollaterals.Enabled = false;
                groupBoxSetSeparateValuesforGuarantorsandCollaterals.Enabled = false;
                chkSetSeparateValuesforGuarantorsandCollaterals.Checked = false;
                txtMinPercentageforGuarantors.Text = "0";
                txtMinPercentageforCollaterals.Text = "0";
            }
        }
        private void chkSetSeparateValuesforGuarantorsandCollaterals_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetSeparateValuesforGuarantorsandCollaterals.Checked)
            {
                groupBoxSetSeparateValuesforGuarantorsandCollaterals.Enabled = true;
            }
            else
            {
                groupBoxSetSeparateValuesforGuarantorsandCollaterals.Enabled = false;
            }
        }
        private void chkUseCompulsorySavings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseCompulsorySavings.Checked)
            {
                groupBoxCompulsorySavingAmount.Enabled = true;
            }
            else
            {
                groupBoxCompulsorySavingAmount.Enabled = false;
            }
        }
        private void dataGridViewEntryFees_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewEntryFees_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewEntryFees_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddNewLoanCycle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (string.IsNullOrEmpty(txtLoancycle.Text))
                {
                    errorProvider.Clear();
                    errorProvider.SetError(txtLoancycle, "Description cannot be null!");
                    return;
                }
                if (!string.IsNullOrEmpty(txtLoancycle.Text))
                {
                    CyclesModel cycle = new CyclesModel();
                    cycle.name = Utils.ConvertFirstLetterToUpper(txtLoancycle.Text);

                    if (rep.GetAllCycles().Any(i => i.name == cycle.name))
                    {
                        MessageBox.Show("Cycle with Name " + cycle.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!rep.GetAllCycles().Any(i => i.name == cycle.name))
                    {
                        rep.AddNewCycle(cycle);
                        RefreshLoanCyclesCombo();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddCycleObject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                CycleObjectsForm cof = new CycleObjectsForm(connection) { Owner = this };
                cof.Text = "Cycle Objects";
                cof.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddCycleObjectParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboCycles.SelectedIndex != -1 && cboCycleObjects.SelectedIndex != -1)
            {
                if (IsCyclePropertyValid())
                {
                    try
                    {
                        bindingSourceCycleObjectParameters.DataSource = null;
                        if (_CycleObjectParameters == null)
                        {
                            _CycleObjectParameters = new BindingList<CycleParametersModel>();
                        }
                        CyclesModel _Cycle = (CyclesModel)cboCycles.SelectedItem;
                        CycleObjectsModel CycleObject = (CycleObjectsModel)cboCycleObjects.SelectedItem;

                        CycleParametersModel _cycle = new CycleParametersModel();
                        _cycle.min = txtCycleMinAmount.Value;
                        _cycle.max = txtCycleMaxAmount.Value;
                        _cycle.cycle_object_id = CycleObject.cycleobjectid;
                        _cycle.cycle_id = _Cycle.cycleid;
                        _cycle._cycle_parameter_id = int.Parse(Utils.NextSeries(LastCycleId()));
                        _cycle.loan_cycle = _cycle._cycle_parameter_id;

                        if (!_CycleObjectParameters.Any(i => i.cycle_id == _cycle.cycle_id && i.cycle_object_id == _cycle.cycle_object_id && i.min == _cycle.min && i.max == _cycle.max))
                        {
                            _CycleObjectParameters.Add(_cycle);
                        }
                        bindingSourceCycleObjectParameters.DataSource = _CycleObjectParameters;
                        groupBoxCycleObjectParameters.Text = _CycleObjectParameters.Count.ToString();
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
        }
        private void btnRemoveCycleParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewCycleObjectParameters.SelectedRows.Count != 0)
                {
                    CycleParametersModel lcp = (CycleParametersModel)bindingSourceCycleObjectParameters.Current;

                    _CycleObjectParameters.Remove(lcp);
                    RefreshCycleObjectParametersGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSaveCycleParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (var param in _CycleObjectParameters)
                {
                    rep.AddNewCycleParameter(param);
                }
                RefreshCycleObjectParametersGrid();
                MessageBox.Show("Save Successfull", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboCycles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshCycleObjectParametersGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboLoanCycleObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCycleObjectParametersGrid();
        }
        private void txtLoancycle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLoancycle.Text))
                {
                    btnAddNewLoanCycle.Enabled = true;
                }
                else
                {
                    btnAddNewLoanCycle.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCycleProperties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCycleObjectParameters.SelectedRows.Count != 0)
            {
                btnRemoveCycleAmount.Enabled = true;
            }
            else
            {
                btnRemoveCycleAmount.Enabled = false;
            }
        }
        public void RefreshLoanCyclesCombo()
        {
            try
            {
                var AdvancedParametersLoanCyclesquery = from lc in rep.GetAllCycles()
                                                        select lc;
                List<CyclesModel> AdvancedParametersLoanCycles = AdvancedParametersLoanCyclesquery.ToList();
                cboCycles.DataSource = AdvancedParametersLoanCycles;
                cboCycles.ValueMember = "cycleid";
                cboCycles.DisplayMember = "name";
                if (cboCycles.Items.Count != 0)
                {
                    int index = cboCycles.FindString(txtLoancycle.Text);
                    cboCycles.SelectedIndex = index;
                }
                cboCycles.SelectedIndexChanged += new EventHandler(cboCycles_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshCycleObjectsCombo()
        {
            try
            {
                cboCycleObjects.DataSource = null;
                cboCycleObjects.Items.Clear();
                var cycleobjectsquery = from co in rep.GetAllCycleObjects()
                                        select co;
                List<CycleObjectsModel> CycleObjects = cycleobjectsquery.ToList();
                cboCycleObjects.DataSource = CycleObjects;
                cboCycleObjects.ValueMember = "cycleobjectid";
                cboCycleObjects.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshCycleObjectParametersGrid()
        {
            if (cboCycles.SelectedIndex != -1 && cboCycleObjects.SelectedIndex != -1)
            {
                try
                {
                    groupBoxCycleObjectParameters.Visible = true;
                    txtMaxAmount.Enabled = true;
                    txtMinAmount.Enabled = true;
                    bindingSourceCycleObjectParameters.DataSource = null;
                    if (_CycleObjectParameters == null)
                    {
                        _CycleObjectParameters = new BindingList<CycleParametersModel>();
                    }
                    CyclesModel LoanCycle = (CyclesModel)cboCycles.SelectedItem;
                    CycleObjectsModel cycleobjs = (CycleObjectsModel)cboCycleObjects.SelectedItem;

                    var cyclepropertiesquery = from cp in rep.GetAllCycleParameters()
                                               where cp.cycle_id == LoanCycle.cycleid
                                               where cp.cycle_object_id == cycleobjs.cycleobjectid
                                               select cp;
                    BindingList<CycleParametersModel> _CyclbjctPrmtrs = new BindingList<CycleParametersModel>(cyclepropertiesquery.ToList());
                    var _counter = 1;
                    foreach (var _cycle in _CyclbjctPrmtrs)
                    {
                        if (!_CycleObjectParameters.Any(i => i.cycle_id == _cycle.cycle_id && i.cycle_object_id == _cycle.cycle_object_id && i.min == _cycle.min && i.max == _cycle.max))
                        {
                            _cycle._cycle_parameter_id = _counter;
                            _CycleObjectParameters.Add(_cycle);
                            _counter++;
                        }
                    }
                    bindingSourceCycleObjectParameters.DataSource = _CycleObjectParameters;
                    groupBoxCycleObjectParameters.Text = bindingSourceCycleObjectParameters.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewCycleObjectParameters.Rows)
                    {
                        dataGridViewCycleObjectParameters.Rows[dataGridViewCycleObjectParameters.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewCycleObjectParameters.Rows.Count - 1;
                        bindingSourceCycleObjectParameters.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public string LastCycleId()
        {
            try
            {
                if (_CycleObjectParameters == null)
                {
                    return "0";
                }
                var lcp = _CycleObjectParameters.OrderByDescending(r => r._cycle_parameter_id).FirstOrDefault();
                if (lcp == null)
                    return "0";
                return lcp._cycle_parameter_id.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
            }
        }
        private void rbtnNone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManageAdvancedSettings();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void rbtnUseExoticInstallments_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManageAdvancedSettings();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void rbtnUseLoanCycle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManageAdvancedSettings();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void rbtnUseLineofCredit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManageAdvancedSettings();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ManageAdvancedSettings()
        {
            try
            {
                foreach (Control ctrl in groupBox29.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            switch (((RadioButton)ctrl).Name)
                            {
                                case "rbtnNone":
                                    groupBoxUseLoanCycle.Visible = false;
                                    groupBox15.Visible = false;
                                    groupBox17.Visible = false;
                                    break;
                                case "rbtnUseExoticInstallments":
                                    groupBox15.Visible = true;
                                    groupBox15.Location = groupBoxUseLoanCycle.Location;
                                    groupBoxUseLoanCycle.Visible = false;
                                    groupBox17.Visible = false;
                                    break;
                                case "rbtnUseLoanCycle":
                                    groupBoxUseLoanCycle.Visible = true;
                                    groupBoxUseLoanCycle.Location = groupBoxUseLoanCycle.Location;
                                    groupBox15.Visible = false;
                                    groupBox17.Visible = false;
                                    _CycleObjectParameters = new BindingList<CycleParametersModel>();
                                    RefreshLoanCyclesCombo();
                                    RefreshCycleObjectsCombo();
                                    RefreshCycleObjectParametersGrid();
                                    break;
                                case "rbtnUseLineofCredit":
                                    groupBox17.Visible = true;
                                    groupBox17.Location = groupBoxUseLoanCycle.Location;
                                    groupBoxUseLoanCycle.Visible = false;
                                    groupBox15.Visible = false;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCancelCycleParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewExoticInstallments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnPropertiesGrid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                CollectionEditor epf = new CollectionEditor(connection) { Owner = this };
                epf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

























        #endregion "Private Methods"





















    }
}
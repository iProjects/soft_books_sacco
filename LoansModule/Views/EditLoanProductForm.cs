using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using Microsoft.VisualBasic;


namespace LoansModule.Views
{
    public partial class EditLoanProductForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        LoanPackageModel loan;
        BindingList<CycleParametersModel> _CycleObjectParameters;
        #endregion "Private Fields"

        #region "Constructor"
        public EditLoanProductForm(LoanPackageModel _loan, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            loan = _loan;
        }
        #endregion "Constructor"

        #region "Private Methods"
        #region "Validation"
        private bool IsLoanProductValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCode, "Code cannot be null!");
                return false;
            }
            return noerror;
        }
        private bool IsCyclePropertyValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtCycleMinAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCycleMinAmount, "Min Amount cannot be null!");
                return false;
            }
            decimal _MinAmount;
            if (!decimal.TryParse(txtCycleMinAmount.Text, out _MinAmount))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCycleMinAmount, "Min Amount must be decimal!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCycleMaxAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCycleMaxAmount, "Max Amount cannot be null!");
                return false;
            }
            decimal _MaxAmount;
            if (!decimal.TryParse(txtCycleMaxAmount.Text, out _MaxAmount))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCycleMaxAmount, "Max Amount must be decimal!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"
        #region "buttons"
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
        private void btnAddNewLoanCycleAdvancedParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtLoancycle.Text))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtLoancycle, "Description cannot be null!");
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
                        txtLoancycle.Text = string.Empty;
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
                        bindingSourceCycleParameters.DataSource = null;

                        CyclesModel _Cycle = (CyclesModel)cboCycles.SelectedItem;
                        CycleObjectsModel CycleObject = (CycleObjectsModel)cboCycleObjects.SelectedItem;

                        CycleParametersModel _cycleobjectparam = new CycleParametersModel();
                        _cycleobjectparam.min = txtCycleMinAmount.Value;
                        _cycleobjectparam.max = txtCycleMaxAmount.Value;
                        _cycleobjectparam.cycle_object_id = CycleObject.cycleobjectid;
                        _cycleobjectparam.cycle_id = _Cycle.cycleid;

                        _CycleObjectParameters.Add(_cycleobjectparam);

                        RefreshCycleObjectParametersGrid();
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
        }
        private void btnRemoveAmountCycleAdvancedParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewCycleParameters.SelectedRows.Count != 0)
                {
                    CycleParametersModel _cycleparameter = (CycleParametersModel)bindingSourceCycleParameters.Current;

                    CycleParametersModel _cycleparam = rep.GetCycleParameter(_cycleparameter.cycleparameterid);

                    if (_cycleparam != null)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Cycle Parameter", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteCycleParameter(_cycleparam);
                            RefreshCycleObjectParametersGrid();
                        }
                    }
                    if (_cycleparam == null)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Cycle Parameter", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            _CycleObjectParameters.Remove(_cycleparameter);
                            RefreshCycleObjectParametersGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSaveAmountCycleAdvancedParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (var param in _CycleObjectParameters)
                {
                    if (!rep.GetAllCycleParameters().Any(i => i.cycleparameterid == param.cycleparameterid && i.cycle_id == param.cycle_id && i.cycle_object_id == param.cycle_object_id))
                    {
                        rep.AddNewCycleParameter(param);
                    }
                }

                RefreshCycleObjectParametersGrid();

                MessageBox.Show("Save Successfull", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsLoanProductValid())
            {
                try
                {

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
                        loan.rounding_type = int.Parse(cboRoundingType.SelectedValue.ToString());
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

                    rep.UpdatePackage(loan);

                    LoanProductsListForm f = (LoanProductsListForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #endregion "buttons"
        #region "datagridviews"
        private void dataGridViewCycleParameters_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCycleParameters.SelectedRows.Count != 0)
                {
                    //txtCycleMinAmount.Value = txtCycleMinAmount.Minimum;
                    //txtCycleMaxAmount.Value = txtCycleMaxAmount.Minimum;

                    CycleParametersModel _param = (CycleParametersModel)bindingSourceCycleParameters.Current; 

                    txtCycleMinAmount.Value = decimal.Parse(_param.min.ToString());
                    txtCycleMaxAmount.Value=decimal.Parse(_param.max.ToString());
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCycleParameters_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        private void dataGridViewCycleParameters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCycleParameters.SelectedRows.Count != 0)
            {
                btnRemoveCycleAmount.Enabled = true;
            }
            else
            {
                btnRemoveCycleAmount.Enabled = false;
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
        #endregion "datagridviews"
        #region "comboboxes"
        private void cboAPLoanCycles_SelectedIndexChanged(object sender, EventArgs e)
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
        #endregion "comboboxes"
        #region "radiobuttons"
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
        #endregion "radiobuttons"
        #region "checkboxes"
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
        #endregion "checkboxes"
        #region "functions"
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

                                    bindingSourceExotics.DataSource = null;
                                    var _exoticsquery = from ei in rep.GetAllExotics()
                                                        select ei;
                                    List<ExoticsModel> _exotics = _exoticsquery.ToList();
                                    bindingSourceExotics.DataSource = _exotics;
                                    dataGridViewExotics.AutoGenerateColumns = false;
                                    dataGridViewExotics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                    dataGridViewExotics.DataSource = bindingSourceExotics;
                                    groupBox15.Text = bindingSourceExotics.Count.ToString();
                                    break;
                                case "rbtnUseLoanCycle":
                                    groupBoxUseLoanCycle.Visible = true;
                                    groupBoxUseLoanCycle.Location = groupBoxUseLoanCycle.Location;
                                    groupBox15.Visible = false;
                                    groupBox17.Visible = false;
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
        private void EditLoanProductForm_Load(object sender, EventArgs e)
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
                cboRoundingType.SelectedIndex = -1;

                var currenciesquery = from cr in rep.GetCurrenciesList()
                                      select cr;
                List<CurrencyModel> currencies = currenciesquery.ToList();
                cboCurrency.DataSource = currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;

                var installmenttypesquery = from it in db.InstallmentTypes
                                            select it;
                List<InstallmentType> InstallmentTypes = installmenttypesquery.ToList();
                cboInstallmentTypes.DataSource = InstallmentTypes;
                cboInstallmentTypes.ValueMember = "id";
                cboInstallmentTypes.DisplayMember = "name";
                cboInstallmentTypes.SelectedIndex = -1;

                List<FundingLineModel> FundingLines = rep.GetFundingLinesList();
                cboFundingLine.DataSource = FundingLines;
                cboFundingLine.ValueMember = "fundinglineid";
                cboFundingLine.DisplayMember = "name";
                cboFundingLine.SelectedIndex = -1;

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
                bindingSourceEntryFees.DataSource = rep.GetPackageEntryFees(loan.packageid);
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
                bindingSourceCycleParameters.DataSource = null;
                dataGridViewCycleParameters.AutoGenerateColumns = false;
                this.dataGridViewCycleParameters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewCycleParameters.DataSource = bindingSourceCycleParameters;
                groupBoxCycleObjectParameters.Visible = false;
                txtMaxAmount.Enabled = false;
                txtMinAmount.Enabled = false;
                #endregion "Cycles"

                InitializeControls();
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
                if (loan.name != null)
                {
                    txtName.Text = loan.name;
                }
                if (loan.code != null)
                {
                    txtCode.Text = loan.code;
                }
                if (loan.installment_type != null)
                {
                    cboInstallmentTypes.SelectedValue = loan.installment_type;
                }
                if (loan.rounding_type != null)
                {
                    cboRoundingType.SelectedValue = loan.rounding_type;
                }
                if (loan.fundingLine_id != null)
                {
                    cboFundingLine.SelectedValue = loan.fundingLine_id;
                }
                if (loan.currency_id != null)
                {
                    cboCurrency.SelectedValue = loan.currency_id;
                }
                radioButtonFlatInterestType.Checked = true;
                radioButtonNoGracePeriod.Checked = true;
                if (loan.grace_period_min != null)
                {
                    txtMinGracePeriod.Text = loan.grace_period_min.ToString();
                }
                if (loan.grace_period_max != null)
                {
                    txtMaxGracePeriod.Text = loan.grace_period_max.ToString();
                }
                if (loan.grace_period != null)
                {
                    txtValueGracePeriod.Text = loan.grace_period.ToString();
                }
                if (loan.amount_min != null)
                {
                    txtMinAmount.Text = loan.amount_min.ToString();
                }
                if (loan.amount_max != null)
                {
                    txtMaxAmount.Text = loan.amount_max.ToString();
                }
                if (loan.amount != null)
                {
                    txtValueAmount.Text = loan.amount.ToString();
                }
                if (loan.interest_rate_min != null)
                {
                    txtMinInterestRate.Text = loan.interest_rate_min.ToString();
                }
                if (loan.interest_rate_max != null)
                {
                    txtMaxInterestRate.Text = loan.interest_rate_max.ToString();
                }
                if (loan.interest_rate != null)
                {
                    txtValueInterestRate.Text = loan.interest_rate.ToString();
                }
                if (loan.number_of_installments_min != null)
                {
                    txtMinNumberofInstallments.Text = loan.number_of_installments_min.ToString();
                }
                if (loan.number_of_installments_max != null)
                {
                    txtMaxNumberofInstallments.Text = loan.number_of_installments_max.ToString();
                }
                if (loan.number_of_installments != null)
                {
                    txtValueNumberofInstallments.Text = loan.number_of_installments.ToString();
                }
                chkUseLoanCycleEntryFees.Checked = loan.use_entry_fees_cycles;
                if (loan.non_repayment_penalties_based_on_initial_amount_min != null)
                {
                    txtMinLateFeesonTotalLoanAmount.Text = loan.non_repayment_penalties_based_on_initial_amount_min.ToString();
                }
                if (loan.non_repayment_penalties_based_on_initial_amount_max != null)
                {
                    txtMaxLateFeesonTotalLoanAmount.Text = loan.non_repayment_penalties_based_on_initial_amount_max.ToString();
                }
                if (loan.non_repayment_penalties_based_on_initial_amount != null)
                {
                    txtValueLateFeesonTotalLoanAmount.Text = loan.non_repayment_penalties_based_on_initial_amount.ToString();
                }
                if (loan.non_repayment_penalties_based_on_olb_min != null)
                {
                    txtMinLateFeesonOLB.Text = loan.non_repayment_penalties_based_on_olb_min.ToString();
                }
                if (loan.non_repayment_penalties_based_on_olb_max != null)
                {
                    txtMaxLateFeesonOLB.Text = loan.non_repayment_penalties_based_on_olb_max.ToString();
                }
                if (loan.non_repayment_penalties_based_on_olb != null)
                {
                    txtValueLateFeesonOLB.Text = loan.non_repayment_penalties_based_on_olb.ToString();
                }
                if (loan.non_repayment_penalties_based_on_overdue_principal_min != null)
                {
                    txtMinLateFeesonOverduePrincipal.Text = loan.non_repayment_penalties_based_on_overdue_principal_min.ToString();
                }
                if (loan.non_repayment_penalties_based_on_overdue_principal_max != null)
                {
                    txtMaxLateFeesonOverduePrincipal.Text = loan.non_repayment_penalties_based_on_overdue_principal_max.ToString();
                }
                if (loan.non_repayment_penalties_based_on_overdue_principal != null)
                {
                    txtValueLateFeesonOverduePrincipal.Text = loan.non_repayment_penalties_based_on_overdue_principal.ToString();
                }
                if (loan.non_repayment_penalties_based_on_overdue_interest_min != null)
                {
                    txtMinLateFeesonOverdueInterest.Text = loan.non_repayment_penalties_based_on_overdue_interest_min.ToString();
                }
                if (loan.non_repayment_penalties_based_on_overdue_interest_max != null)
                {
                    txtMaxLateFeesonOverdueInterest.Text = loan.non_repayment_penalties_based_on_overdue_interest_max.ToString();
                }
                if (loan.non_repayment_penalties_based_on_overdue_interest != null)
                {
                    txtValueLateFeesonOverdueInterest.Text = loan.non_repayment_penalties_based_on_overdue_interest.ToString();
                }
                if (loan.grace_period_of_latefees != null)
                {
                    txtGracePeriodofLateFees.Text = loan.grace_period_of_latefees.ToString();
                }
                if (loan.anticipated_total_repayment_penalties_min != null)
                {
                    txtMinATRFees.Text = loan.anticipated_total_repayment_penalties_min.ToString();
                }
                if (loan.anticipated_total_repayment_penalties_max != null)
                {
                    txtMaxATRFees.Text = loan.anticipated_total_repayment_penalties_max.ToString();
                }
                if (loan.anticipated_total_repayment_penalties != null)
                {
                    txtValueATRFees.Text = loan.anticipated_total_repayment_penalties.ToString();
                }
                if (loan.anticipated_total_repayment_base != null)
                {
                    switch (loan.anticipated_total_repayment_base.ToString())
                    {
                        case "0":
                            radioButtonATRFeespercentageonOLB.Checked = true;
                            break;
                        case "1":
                            radioButtonATRFeespercentageonInterest.Checked = true;
                            break;
                    }
                }

                if (loan.anticipated_partial_repayment_penalties_min != null)
                {
                    txtMinAPRFees.Text = loan.anticipated_partial_repayment_penalties_min.ToString();
                }
                if (loan.anticipated_partial_repayment_penalties_max != null)
                {
                    txtMaxAPRFees.Text = loan.anticipated_partial_repayment_penalties_max.ToString();
                }
                if (loan.anticipated_partial_repayment_penalties != null)
                {
                    txtValueAPRFees.Text = loan.anticipated_partial_repayment_penalties.ToString();
                }
                if (loan.anticipated_partial_repayment_base != null)
                {
                    switch (loan.anticipated_partial_repayment_base.ToString())
                    {
                        case "0":
                            radioButtonAPRFeespercentageonOLB.Checked = true;
                            break;
                        case "1":
                            radioButtonAPRFeespercentageonInterest.Checked = true;
                            break;
                        case "2":
                            radioButtonAPRFeespercentageonPrepaidPrincipal.Checked = true;
                            break;
                    }
                }
                chkAllowFlexibleSchedule.Checked = loan.allow_flexible_schedule;
                if (loan.number_of_drawings_loc != null)
                {
                    txtNoofDrawingsunderLOC.Text = loan.number_of_drawings_loc.ToString();
                }
                if (loan.amount_under_loc_min != null)
                {
                    txtMinAmountunderLOC.Text = loan.amount_under_loc_min.ToString();
                }
                if (loan.amount_under_loc_max != null)
                {
                    txtMaxAmountunderLOC.Text = loan.amount_under_loc_max.ToString();
                }
                if (loan.amount_under_loc != null)
                {
                    txtValueAmountunderLOC.Text = loan.amount_under_loc.ToString();
                }
                chkUseGuarantorsandCollateral.Checked = loan.use_guarantor_collateral ?? false;
                if (loan.percentage_total_guarantor_collateral != null)
                {
                    txtMinPercentageofGuarantorsandCollaterals.Text = loan.percentage_total_guarantor_collateral.ToString();
                }
                chkSetSeparateValuesforGuarantorsandCollaterals.Checked = loan.set_separate_guarantor_collateral;
                if (loan.percentage_separate_guarantor != null)
                {
                    txtMinPercentageforGuarantors.Text = loan.percentage_separate_guarantor.ToString();
                }
                if (loan.percentage_separate_collateral != null)
                {
                    txtMinPercentageforCollaterals.Text = loan.percentage_separate_collateral.ToString();
                }
                chkUseCompulsorySavings.Checked = loan.use_compulsory_savings;
                radioButtonRateCompulsorySavingAmount.Checked = true;
                if (loan.compulsory_amount_min != null)
                {
                    txtMinCompulsorySavingsAmount.Text = loan.compulsory_amount_min.ToString();
                }
                if (loan.compulsory_amount_max != null)
                {
                    txtMaxCompulsorySavingsAmount.Text = loan.compulsory_amount_max.ToString();
                }
                if (loan.compulsory_amount != null)
                {
                    txtValueCompulsorySavingsAmount.Text = loan.compulsory_amount.ToString();
                }
                if (loan.insurance_min != null)
                {
                    txtMinCreditInsurance.Text = loan.insurance_min.ToString();
                }
                if (loan.insurance_max != null)
                {
                    txtMaxCreditInsurance.Text = loan.insurance_max.ToString();
                }
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
                txtName.Enabled = false;
                txtCode.Enabled = false;
                cboInstallmentTypes.Enabled = false;
                chkAllClients.Enabled = false;
                chkNonSolidarityClient.Enabled = false;
                chkSolidarityClient.Enabled = false;
                chkIndividualClient.Enabled = false;
                chkCorporateClient.Enabled = false;
                cboRoundingType.Enabled = false;
                cboFundingLine.Enabled = false;
                cboCurrency.Enabled = false;
                radioButtonFlatInterestType.Enabled = false;
                radioButtonDecliningFixedInstallments.Enabled = false;
                radioButtonDecliningFixedPrincipal.Enabled = false;
                radioButtonFixedPrincipalRealInterest.Enabled = false;
                radioButtonYesGracePeriod.Enabled = false;
                radioButtonNoGracePeriod.Enabled = false;
                txtMinGracePeriod.Enabled = false;
                txtMaxGracePeriod.Enabled = false;
                txtValueGracePeriod.Enabled = false;
                txtMinAmount.Enabled = false;
                txtMaxAmount.Enabled = false;
                txtValueAmount.Enabled = false;
                txtMinInterestRate.Enabled = false;
                txtMaxInterestRate.Enabled = false;
                txtValueInterestRate.Enabled = false;
                txtMinNumberofInstallments.Enabled = false;
                txtMaxNumberofInstallments.Enabled = false;
                txtValueNumberofInstallments.Enabled = false;
                chkUseLoanCycleEntryFees.Enabled = false;
                cboEntryFeesLoanCycle.Enabled = false;
                txtFrom.Enabled = false;
                btnAddEntryFeesCycle.Enabled = false;
                btnRemoveEntryFeesCycle.Enabled = false;
                dataGridViewEntryFees.Enabled = false;
                txtMinLateFeesonTotalLoanAmount.Enabled = false;
                txtMaxLateFeesonTotalLoanAmount.Enabled = false;
                txtValueLateFeesonTotalLoanAmount.Enabled = false;
                txtMinLateFeesonOLB.Enabled = false;
                txtMaxLateFeesonOLB.Enabled = false;
                txtValueLateFeesonOLB.Enabled = false;
                txtMinLateFeesonOverduePrincipal.Enabled = false;
                txtMaxLateFeesonOverduePrincipal.Enabled = false;
                txtValueLateFeesonOverduePrincipal.Enabled = false;
                txtMinLateFeesonOverdueInterest.Enabled = false;
                txtMaxLateFeesonOverdueInterest.Enabled = false;
                txtValueLateFeesonOverdueInterest.Enabled = false;
                txtGracePeriodofLateFees.Enabled = false;
                txtMinATRFees.Enabled = false;
                txtMaxATRFees.Enabled = false;
                txtValueATRFees.Enabled = false;
                radioButtonATRFeespercentageonOLB.Enabled = false;
                radioButtonATRFeespercentageonInterest.Enabled = false;
                txtMinAPRFees.Enabled = false;
                txtMaxAPRFees.Enabled = false;
                txtValueAPRFees.Enabled = false;
                radioButtonAPRFeespercentageonOLB.Enabled = false;
                radioButtonAPRFeespercentageonInterest.Enabled = false;
                radioButtonAPRFeespercentageonPrepaidPrincipal.Enabled = false;
                chkAllowFlexibleSchedule.Enabled = false;
                txtNoofDrawingsunderLOC.Enabled = false;
                txtMinAmountunderLOC.Enabled = false;
                txtMaxAmountunderLOC.Enabled = false;
                txtValueAmountunderLOC.Enabled = false;
                txtMinTrancheMaturity.Enabled = false;
                txtMaxTrancheMaturity.Enabled = false;
                txtValueTrancheMaturity.Enabled = false;
                chkUseGuarantorsandCollateral.Enabled = false;
                txtMinPercentageofGuarantorsandCollaterals.Enabled = false;
                chkSetSeparateValuesforGuarantorsandCollaterals.Enabled = false;
                txtMinPercentageforGuarantors.Enabled = false;
                txtMinPercentageforCollaterals.Enabled = false;
                chkUseCompulsorySavings.Enabled = false;
                radioButtonFlatCompulsorySavingAmount.Enabled = false;
                radioButtonRateCompulsorySavingAmount.Enabled = false;
                txtMinCompulsorySavingsAmount.Enabled = false;
                txtMaxCompulsorySavingsAmount.Enabled = false;
                txtValueCompulsorySavingsAmount.Enabled = false;
                txtMinCreditInsurance.Enabled = false;
                txtMaxCreditInsurance.Enabled = false;
                btnUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
                cboCycles.SelectedIndexChanged += new EventHandler(cboAPLoanCycles_SelectedIndexChanged);
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
                    bindingSourceCycleParameters.DataSource = null;
                    if (_CycleObjectParameters == null)
                    {
                        _CycleObjectParameters = new BindingList<CycleParametersModel>();
                    }

                    CyclesModel LoanCycle = (CyclesModel)cboCycles.SelectedItem;
                    CycleObjectsModel cycleobjs = (CycleObjectsModel)cboCycleObjects.SelectedItem;

                    var cyclepropertiesquery = from cp in rep.GetCycleParameters(LoanCycle.cycleid, cycleobjs.cycleobjectid)
                                               where cp.cycle_id == LoanCycle.cycleid
                                               where cp.cycle_object_id == cycleobjs.cycleobjectid
                                               select cp;
                    BindingList<CycleParametersModel> _lstCycleObjectParameters = new BindingList<CycleParametersModel>(cyclepropertiesquery.ToList());

                    foreach (var _param in _lstCycleObjectParameters)
                    {
                        if (!_CycleObjectParameters.Any(i =>i.cycleparameterid == _param.cycleparameterid))
                        {
                            _CycleObjectParameters.Add(_param);
                        }
                    }

                    int rowid = 1;
                    foreach (var row in _CycleObjectParameters)
                    {
                        row._cycle_parameter_id = rowid;
                        row.loan_cycle = row._cycle_parameter_id;
                        rowid++;
                    }

                    bindingSourceCycleParameters.DataSource = _CycleObjectParameters;
                    groupBoxCycleObjectParameters.Text = bindingSourceCycleParameters.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewCycleParameters.Rows)
                    {
                        dataGridViewCycleParameters.Rows[dataGridViewCycleParameters.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewCycleParameters.Rows.Count - 1;
                        bindingSourceCycleParameters.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void LoadCycleObjectParameters()
        {
            if (cboCycles.SelectedIndex != -1 && cboCycleObjects.SelectedIndex != -1)
            {
                try
                {
                    groupBoxCycleObjectParameters.Visible = true;
                    txtMaxAmount.Enabled = true;
                    txtMinAmount.Enabled = true;
                    bindingSourceCycleParameters.DataSource = null;
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
                    BindingList<CycleParametersModel> _lstCycleObjectParameters = new BindingList<CycleParametersModel>(cyclepropertiesquery.ToList());

                    foreach (var _param in _lstCycleObjectParameters)
                    {
                        if (!_CycleObjectParameters.Any(i => i.cycle_id == _param.cycle_id && i.cycle_object_id == _param.cycle_object_id && i.min == _param.min && i.max == _param.max && i.cycleparameterid == _param.cycleparameterid))
                        {
                            _CycleObjectParameters.Add(_param);
                        }
                    }

                    int rowid = 1;
                    foreach (var row in _CycleObjectParameters)
                    {
                        row._cycle_parameter_id = rowid;
                        row.loan_cycle = row._cycle_parameter_id;
                        rowid++;
                    }

                    bindingSourceCycleParameters.DataSource = _CycleObjectParameters;
                    groupBoxCycleObjectParameters.Text = bindingSourceCycleParameters.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewCycleParameters.Rows)
                    {
                        dataGridViewCycleParameters.Rows[dataGridViewCycleParameters.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewCycleParameters.Rows.Count - 1;
                        bindingSourceCycleParameters.Position = nRowIndex;
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
        #endregion "functions"
        #region "textboxes"
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
        private void txtCycleMinAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCycleParameters.SelectedRows.Count != 0)
                {
                    CycleParametersModel _param = (CycleParametersModel)bindingSourceCycleParameters.Current;

                    _param.min=decimal.Parse( txtCycleMinAmount.Value.ToString());
                    _param.max = decimal.Parse(txtCycleMaxAmount.Value.ToString());

                    dataGridViewCycleParameters.Refresh();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtCycleMaxAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCycleParameters.SelectedRows.Count != 0)
                {
                    CycleParametersModel _param = (CycleParametersModel)bindingSourceCycleParameters.Current;

                    _param.min = decimal.Parse(txtCycleMinAmount.Value.ToString());
                    _param.max = decimal.Parse(txtCycleMaxAmount.Value.ToString());

                    dataGridViewCycleParameters.Refresh();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "textboxes"  
        #endregion "Private Methods"














    }
}
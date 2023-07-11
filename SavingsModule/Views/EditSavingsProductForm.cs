using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace SavingsModule.Views
{
    public partial class EditSavingsProductForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        SavingProductModel savings;
        #endregion "Private Fields"

        #region "Constructor"
        public EditSavingsProductForm(SavingProductModel _savings, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            savings = _savings;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsSavingsProductValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        savings.name = Utils.ConvertFirstLetterToUpper(txtName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtCode.Text))
                    {
                        savings.code = Utils.ConvertFirstLetterToUpper(txtCode.Text);
                    } 
                    if (cboCurrency.SelectedIndex != -1)
                    {
                        savings.currency_id = int.Parse(cboCurrency.SelectedValue.ToString());
                    }
                    decimal MinInitialAmount;
                    if (!string.IsNullOrEmpty(txtMinInitialAmount.Text) && decimal.TryParse(txtMinInitialAmount.Text, out MinInitialAmount))
                    {
                        savings.initial_amount_min = decimal.Parse(txtMinInitialAmount.Text);
                    }
                    decimal MaxInitialAmount;
                    if (!string.IsNullOrEmpty(txtMaxInitialAmount.Text) && decimal.TryParse(txtMaxInitialAmount.Text, out MaxInitialAmount))
                    {
                        savings.initial_amount_max = decimal.Parse(txtMaxInitialAmount.Text);

                    }
                    decimal MinBalance;
                    if (!string.IsNullOrEmpty(txtMinBalance.Text) && decimal.TryParse(txtMinBalance.Text, out MinBalance))
                    {
                        savings.balance_min = decimal.Parse(txtMinBalance.Text);
                    }
                    decimal MaxBalance;
                    if (!string.IsNullOrEmpty(txtMaxBalance.Text) && decimal.TryParse(txtMaxBalance.Text, out MaxBalance))
                    {
                        savings.balance_max = decimal.Parse(txtMaxBalance.Text);
                    }
                    int MinInterestRate;
                    if (!string.IsNullOrEmpty(txtMinInterestRate.Text) && int.TryParse(txtMinInterestRate.Text, out MinInterestRate))
                    {
                        savings.interest_rate_min = int.Parse(txtMinInterestRate.Text);
                    }
                    int MaxInterestRate;
                    if (!string.IsNullOrEmpty(txtMaxInterestRate.Text) && int.TryParse(txtMaxInterestRate.Text, out MaxInterestRate))
                    {
                        savings.interest_rate_max = int.Parse(txtMaxInterestRate.Text);
                    }
                    int ValueInterestRate;
                    if (!string.IsNullOrEmpty(txtValueInterestRate.Text) && int.TryParse(txtValueInterestRate.Text, out ValueInterestRate))
                    {
                        savings.interest_rate = int.Parse(txtValueInterestRate.Text);
                    }
                    if (cboInterestBase.SelectedIndex != -1)
                    {
                        savings.interest_base = short.Parse(cboInterestBase.SelectedValue.ToString());
                    }
                    if (cboPostingFrequency.SelectedIndex != -1)
                    {
                        savings.interest_frequency = short.Parse(cboPostingFrequency.SelectedValue.ToString());
                    }
                    if (cboCalculateAmountBasedOn.SelectedIndex != -1)
                    {
                        savings.calcul_amount_base = short.Parse(cboCalculateAmountBasedOn.SelectedValue.ToString());
                    }
                    decimal MinChequeDepositAmount;
                    if (!string.IsNullOrEmpty(txtMinChequeDeposit.Text) && decimal.TryParse(txtMinChequeDeposit.Text, out MinChequeDepositAmount))
                    {
                        savings.cheque_deposit_min = decimal.Parse(txtMinChequeDeposit.Text);
                    }
                    decimal MaxChequeDepositAmount;
                    if (!string.IsNullOrEmpty(txtMaxChequeDeposit.Text) && decimal.TryParse(txtMaxChequeDeposit.Text, out MaxChequeDepositAmount))
                    {
                        savings.cheque_deposit_max = decimal.Parse(txtMaxChequeDeposit.Text);
                    }
                    decimal MinChequeDepositFeesAmount;
                    if (!string.IsNullOrEmpty(txtMinChequeDepositFees.Text) && decimal.TryParse(txtMinChequeDepositFees.Text, out MinChequeDepositFeesAmount))
                    {
                        savings.cheque_deposit_fees_min = decimal.Parse(txtMinChequeDepositFees.Text);
                    }
                    decimal MaxChequeDepositFeesAmount;
                    if (!string.IsNullOrEmpty(txtMaxChequeDepositFees.Text) && decimal.TryParse(txtMaxChequeDepositFees.Text, out MaxChequeDepositFeesAmount))
                    {
                        savings.cheque_deposit_fees_max = decimal.Parse(txtMaxChequeDepositFees.Text);
                    }
                    decimal ValueChequeDepositFees;
                    if (!string.IsNullOrEmpty(txtChequeDepositFees.Text) && decimal.TryParse(txtChequeDepositFees.Text, out ValueChequeDepositFees))
                    {
                        savings.cheque_deposit_fees = decimal.Parse(txtChequeDepositFees.Text);
                    }
                    decimal MinCashDepositAmount;
                    if (!string.IsNullOrEmpty(txtMinChequeDeposit.Text) && decimal.TryParse(txtMinChequeDeposit.Text, out MinCashDepositAmount))
                    {
                        savings.deposit_min = decimal.Parse(txtMinChequeDeposit.Text);
                    }
                    decimal MaxCashDepositAmount;
                    if (!string.IsNullOrEmpty(txtMaxChequeDeposit.Text) && decimal.TryParse(txtMaxChequeDeposit.Text, out MaxCashDepositAmount))
                    {
                        savings.deposit_max = decimal.Parse(txtMaxChequeDeposit.Text);
                    }
                    decimal MinCashDepositFeesAmount;
                    if (!string.IsNullOrEmpty(txtMinChequeDepositFees.Text) && decimal.TryParse(txtMinChequeDepositFees.Text, out MinCashDepositFeesAmount))
                    {
                        savings.deposit_fees_min = decimal.Parse(txtMinChequeDepositFees.Text);
                    }
                    decimal MaxCashDepositFeesAmount;
                    if (!string.IsNullOrEmpty(txtMaxChequeDepositFees.Text) && decimal.TryParse(txtMaxChequeDepositFees.Text, out MaxCashDepositFeesAmount))
                    {
                        savings.deposit_fees_max = decimal.Parse(txtMaxChequeDepositFees.Text);
                    }
                    decimal MinWithDrawAmoun;
                    if (!string.IsNullOrEmpty(txtMinWithdrawAmount.Text) && decimal.TryParse(txtMinWithdrawAmount.Text, out MinWithDrawAmoun))
                    {
                        savings.withdraw_min = decimal.Parse(txtMinWithdrawAmount.Text);
                    }
                    decimal MaxWithDrawAmount;
                    if (!string.IsNullOrEmpty(txtMaxWithdrawAmount.Text) && decimal.TryParse(txtMaxWithdrawAmount.Text, out MaxWithDrawAmount))
                    {
                        savings.withdraw_max = decimal.Parse(txtMaxWithdrawAmount.Text);
                    }
                    foreach (Control ctrl in groupBoxWithDrawalFees.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                switch (((RadioButton)ctrl).Name)
                                {
                                    case "radioButtonFlatWithdrawalFees":
                                        decimal MinWithDrawFees;
                                        if (!string.IsNullOrEmpty(txtMinWithdrawalFees.Text) && decimal.TryParse(txtMinWithdrawalFees.Text, out MinWithDrawFees))
                                        {
                                            savings.flat_withdraw_fees_min = decimal.Parse(txtMinWithdrawalFees.Text);
                                        }
                                        decimal MaxWithDrawFees;
                                        if (!string.IsNullOrEmpty(txtMaxWithdrawalFees.Text) && decimal.TryParse(txtMaxWithdrawalFees.Text, out MaxWithDrawFees))
                                        {
                                            savings.flat_withdraw_fees_max = decimal.Parse(txtMaxWithdrawalFees.Text);
                                        }
                                        decimal ValueWithDrawFees;
                                        if (!string.IsNullOrEmpty(txtValueWithdrawalFees.Text) && decimal.TryParse(txtValueWithdrawalFees.Text, out ValueWithDrawFees))
                                        {
                                            savings.flat_withdraw_fees = decimal.Parse(txtValueWithdrawalFees.Text);
                                        }
                                        break;
                                    case "radioButtonRateWithdrawalFees":
                                        double MinRateWithDrawFees;
                                        if (!string.IsNullOrEmpty(txtMinWithdrawalFees.Text) && double.TryParse(txtMinWithdrawalFees.Text, out MinRateWithDrawFees))
                                        {
                                            savings.rate_withdraw_fees_min = double.Parse(txtMinWithdrawalFees.Text);
                                        }
                                        double MaxRateWithDrawFees;
                                        if (!string.IsNullOrEmpty(txtMaxWithdrawalFees.Text) && double.TryParse(txtMaxWithdrawalFees.Text, out MaxRateWithDrawFees))
                                        {
                                            savings.rate_withdraw_fees_max = double.Parse(txtMaxWithdrawalFees.Text);
                                        }
                                        double ValueRateWithDrawFees;
                                        if (!string.IsNullOrEmpty(txtValueWithdrawalFees.Text) && double.TryParse(txtValueWithdrawalFees.Text, out ValueRateWithDrawFees))
                                        {
                                            savings.rate_withdraw_fees = double.Parse(txtValueWithdrawalFees.Text);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    decimal MinTransferAmount;
                    if (!string.IsNullOrEmpty(txtMinTransferAmount.Text) && decimal.TryParse(txtMinTransferAmount.Text, out MinTransferAmount))
                    {
                        savings.transfer_min = decimal.Parse(txtMinTransferAmount.Text);
                    }
                    decimal MaxTransferAmount;
                    if (!string.IsNullOrEmpty(txtMaxTransferAmount.Text) && decimal.TryParse(txtMaxTransferAmount.Text, out MaxTransferAmount))
                    {
                        savings.transfer_max = decimal.Parse(txtMaxTransferAmount.Text);
                    }
                    foreach (Control ctrl in groupBoxTransferFees.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                switch (((RadioButton)ctrl).Name)
                                {
                                    case "radioButtonFlatTransferFees":
                                        decimal MinTransferFees;
                                        if (!string.IsNullOrEmpty(txtMinTransferFees.Text) && decimal.TryParse(txtMinTransferFees.Text, out MinTransferFees))
                                        {
                                            savings.flat_transfer_fees_min = decimal.Parse(txtMinTransferFees.Text);
                                        }
                                        decimal MaxTransferFees;
                                        if (!string.IsNullOrEmpty(txtMaxTransferFees.Text) && decimal.TryParse(txtMaxTransferFees.Text, out MaxTransferFees))
                                        {
                                            savings.flat_transfer_fees_max = decimal.Parse(txtMaxTransferFees.Text);
                                        }
                                        decimal ValueTransferFees;
                                        if (!string.IsNullOrEmpty(txtValueTransferFees.Text) && decimal.TryParse(txtValueTransferFees.Text, out ValueTransferFees))
                                        {
                                            savings.flat_transfer_fees = decimal.Parse(txtValueTransferFees.Text);
                                        }
                                        break;
                                    case "radioButtonRateTransferFees":
                                        double MinRateTransferFees;
                                        if (!string.IsNullOrEmpty(txtMinTransferFees.Text) && double.TryParse(txtMinTransferFees.Text, out MinRateTransferFees))
                                        {
                                            savings.rate_transfer_fees_min = double.Parse(txtMinTransferFees.Text);
                                        }
                                        double MaxRateTransferFees;
                                        if (!string.IsNullOrEmpty(txtMaxTransferFees.Text) && double.TryParse(txtMaxTransferFees.Text, out MaxRateTransferFees))
                                        {
                                            savings.rate_transfer_fees_max = double.Parse(txtMaxTransferFees.Text);
                                        }
                                        double ValueRateTransferFees;
                                        if (!string.IsNullOrEmpty(txtValueTransferFees.Text) && double.TryParse(txtValueTransferFees.Text, out ValueRateTransferFees))
                                        {
                                            savings.rate_transfer_fees = double.Parse(txtValueTransferFees.Text);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    decimal MinEntryFees;
                    if (!string.IsNullOrEmpty(txtMinEntryFees.Text) && decimal.TryParse(txtMinEntryFees.Text, out MinEntryFees))
                    {
                        savings.entry_fees_min = decimal.Parse(txtMinEntryFees.Text);
                    }
                    decimal MaxEntryFees;
                    if (!string.IsNullOrEmpty(txtMaxEntryFees.Text) && decimal.TryParse(txtMaxEntryFees.Text, out MaxEntryFees))
                    {
                        savings.entry_fees_max = decimal.Parse(txtMaxEntryFees.Text);
                    }
                    decimal ValueEntryFees;
                    if (!string.IsNullOrEmpty(txtValueEntryFees.Text) && decimal.TryParse(txtValueEntryFees.Text, out ValueEntryFees))
                    {
                        savings.entry_fees = decimal.Parse(txtValueEntryFees.Text);
                    }
                    decimal MinReopenFees;
                    if (!string.IsNullOrEmpty(txtMinReopenFees.Text) && decimal.TryParse(txtMinReopenFees.Text, out MinReopenFees))
                    {
                        savings.reopen_fees_min = decimal.Parse(txtMinReopenFees.Text);
                    }
                    decimal MaxReopenFees;
                    if (!string.IsNullOrEmpty(txtMaxReopenFees.Text) && decimal.TryParse(txtMaxReopenFees.Text, out MaxReopenFees))
                    {
                        savings.reopen_fees_max = decimal.Parse(txtMaxReopenFees.Text);
                    }
                    decimal ValueReopenFees;
                    if (!string.IsNullOrEmpty(txtValueReopenFees.Text) && decimal.TryParse(txtValueReopenFees.Text, out ValueReopenFees))
                    {
                        savings.reopen_fees = decimal.Parse(txtValueReopenFees.Text);
                    }
                    decimal MinCloseFees;
                    if (!string.IsNullOrEmpty(txtMinCloseFees.Text) && decimal.TryParse(txtMinCloseFees.Text, out MinCloseFees))
                    {
                        savings.close_fees_min = decimal.Parse(txtMinCloseFees.Text);
                    }
                    decimal MaxCloseFees;
                    if (!string.IsNullOrEmpty(txtMaxCloseFees.Text) && decimal.TryParse(txtMaxCloseFees.Text, out MaxCloseFees))
                    {
                        savings.close_fees_max = decimal.Parse(txtMaxCloseFees.Text);
                    }
                    decimal ValueCloseFees;
                    if (!string.IsNullOrEmpty(txtValueCloseFees.Text) && decimal.TryParse(txtValueCloseFees.Text, out ValueCloseFees))
                    {
                        savings.close_fees = decimal.Parse(txtValueCloseFees.Text);
                    }
                    decimal MinManagementFees;
                    if (!string.IsNullOrEmpty(txtMinManagementFees.Text) && decimal.TryParse(txtMinManagementFees.Text, out MinManagementFees))
                    {
                        savings.management_fees_min = decimal.Parse(txtMinManagementFees.Text);
                    }
                    decimal MaxManagementFees;
                    if (!string.IsNullOrEmpty(txtMaxManagementFees.Text) && decimal.TryParse(txtMaxManagementFees.Text, out MaxManagementFees))
                    {
                        savings.management_fees_max = decimal.Parse(txtMaxManagementFees.Text);
                    }
                    decimal ValueManagementFees;
                    if (!string.IsNullOrEmpty(txtValueManagementFees.Text) && decimal.TryParse(txtValueManagementFees.Text, out ValueManagementFees))
                    {
                        savings.management_fees = decimal.Parse(txtValueManagementFees.Text);
                    }
                    if (cboManagementFeesPostingFrequency.SelectedIndex != -1)
                    {
                        savings.management_fees_freq = int.Parse(cboManagementFeesPostingFrequency.SelectedValue.ToString());
                    }
                    decimal MinFixedOverDraftFees;
                    if (!string.IsNullOrEmpty(txtMinFixedOverdraftFees.Text) && decimal.TryParse(txtMinFixedOverdraftFees.Text, out MinFixedOverDraftFees))
                    {
                        savings.overdraft_fees_min = decimal.Parse(txtMinFixedOverdraftFees.Text);
                    }
                    decimal MaxFixedOverdraftFees;
                    if (!string.IsNullOrEmpty(txtMaxFixedOverdraftFees.Text) && decimal.TryParse(txtMaxFixedOverdraftFees.Text, out MaxFixedOverdraftFees))
                    {
                        savings.overdraft_fees_max = decimal.Parse(txtMaxFixedOverdraftFees.Text);
                    }
                    decimal ValueFixedOverDraftFees;
                    if (!string.IsNullOrEmpty(txtValueFixedOverdraftFees.Text) && decimal.TryParse(txtValueFixedOverdraftFees.Text, out ValueFixedOverDraftFees))
                    {
                        savings.overdraft_fees = decimal.Parse(txtValueFixedOverdraftFees.Text);
                    }
                    decimal MinAgioFees;
                    if (!string.IsNullOrEmpty(txtMinAgioFees.Text) && decimal.TryParse(txtMinAgioFees.Text, out MinAgioFees))
                    {
                        savings.agio_fees_min = double.Parse(txtMinAgioFees.Text);
                    }
                    decimal MaxAgioFees;
                    if (!string.IsNullOrEmpty(txtMaxAgioFees.Text) && decimal.TryParse(txtMaxAgioFees.Text, out MaxAgioFees))
                    {
                        savings.agio_fees_max = double.Parse(txtMaxAgioFees.Text);
                    }
                    decimal ValueAgioFees;
                    if (!string.IsNullOrEmpty(txtValueAgioFees.Text) && decimal.TryParse(txtValueAgioFees.Text, out ValueAgioFees))
                    {
                        savings.agio_fees = double.Parse(txtValueAgioFees.Text);
                    }
                    if (cboAgioPostingFrequency.SelectedIndex != -1)
                    {
                        savings.agio_fees_freq = int.Parse(cboAgioPostingFrequency.SelectedValue.ToString());
                    }
                    savings.use_term_deposit = chkUseTermDeposits.Checked;
                    int MinTermDepositNoofPeriods;
                    if (!string.IsNullOrEmpty(txtMinNumberofPeriods.Text) && int.TryParse(txtMinNumberofPeriods.Text, out MinTermDepositNoofPeriods))
                    {
                        savings.term_deposit_period_min = int.Parse(txtMinNumberofPeriods.Text);
                    }
                    int MaxTermDepositNoofPeriods;
                    if (!string.IsNullOrEmpty(txtMaxNumberofPeriods.Text) && int.TryParse(txtMaxNumberofPeriods.Text, out MaxTermDepositNoofPeriods))
                    {
                        savings.term_deposit_period_max = int.Parse(txtMaxNumberofPeriods.Text);
                    }
                    if (cboDepositPostingFrequency.SelectedIndex != -1)
                    {
                        savings.posting_frequency = int.Parse(cboDepositPostingFrequency.SelectedValue.ToString());
                    }

                    rep.UpdateSavingsProduct(savings);

                    SavingsProductsListForm f = (SavingsProductsListForm)this.Owner;
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
        private bool IsSavingsProductValid()
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
            if (string.IsNullOrEmpty(txtMinInitialAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMinInitialAmount, "Min Initial Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtMaxInitialAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMaxInitialAmount, "Max Initial Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtMinBalance.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMinBalance, "Min Balance Amount cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtMaxBalance.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMaxBalance, "Max Balance Amount cannot be null!");
                return false;
            }
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCurrency, "Select Currency!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"
        private void EditSavingsProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                groupBoxNumberofPeriods.Enabled = false;
                groupBoxPostingFrequency.Enabled = false;

                var currenciesquery = from cr in rep.GetCurrenciesList()
                                      select cr;
                List<CurrencyModel> currencies = currenciesquery.ToList();
                cboCurrency.DataSource = currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;

                var accrualfrequency = new BindingList<KeyValuePair<int, string>>();
                accrualfrequency.Add(new KeyValuePair<int, string>(1, "Daily"));
                accrualfrequency.Add(new KeyValuePair<int, string>(1, "Weekly"));
                accrualfrequency.Add(new KeyValuePair<int, string>(1, "Monthly"));
                cboInterestBase.DataSource = accrualfrequency;
                cboInterestBase.ValueMember = "Key";
                cboInterestBase.DisplayMember = "Value";
                cboInterestBase.SelectedIndex = -1;

                var postingfrequency = new BindingList<KeyValuePair<int, string>>();
                postingfrequency.Add(new KeyValuePair<int, string>(1, "End of Day"));
                postingfrequency.Add(new KeyValuePair<int, string>(2, "End of Week"));
                postingfrequency.Add(new KeyValuePair<int, string>(3, "End of Month"));
                postingfrequency.Add(new KeyValuePair<int, string>(4, "End of Year"));
                cboPostingFrequency.DataSource = postingfrequency;
                cboPostingFrequency.ValueMember = "Key";
                cboPostingFrequency.DisplayMember = "Value";
                cboPostingFrequency.SelectedIndex = -1;

                var calculatebasedon = new BindingList<KeyValuePair<int, string>>();
                calculatebasedon.Add(new KeyValuePair<int, string>(1, "Minimal Amount"));
                cboCalculateAmountBasedOn.DataSource = calculatebasedon;
                cboCalculateAmountBasedOn.ValueMember = "Key";
                cboCalculateAmountBasedOn.DisplayMember = "Value";
                cboCalculateAmountBasedOn.SelectedIndex = -1;

                var transactionin = new BindingList<KeyValuePair<int, string>>();
                transactionin.Add(new KeyValuePair<int, string>(1, "Cash"));
                transactionin.Add(new KeyValuePair<int, string>(2, "Cheque"));
                cboTransactionIn.DataSource = transactionin;
                cboTransactionIn.ValueMember = "Key";
                cboTransactionIn.DisplayMember = "Value";
                cboTransactionIn.SelectedIndex = -1;

                var transfertype = new BindingList<KeyValuePair<int, string>>();
                transfertype.Add(new KeyValuePair<int, string>(1, "Inter-Branch Transfer"));
                transfertype.Add(new KeyValuePair<int, string>(2, "Intra-Branch Transfer"));
                cboTransferType.DataSource = transfertype;
                cboTransferType.ValueMember = "Key";
                cboTransferType.DisplayMember = "Value";
                cboTransferType.SelectedIndex = -1;

                var managementfeespostingfrequency = new BindingList<KeyValuePair<int, string>>();
                managementfeespostingfrequency.Add(new KeyValuePair<int, string>(1, "Daily"));
                managementfeespostingfrequency.Add(new KeyValuePair<int, string>(2, "Weekly"));
                managementfeespostingfrequency.Add(new KeyValuePair<int, string>(3, "Monthly"));
                cboManagementFeesPostingFrequency.DataSource = managementfeespostingfrequency;
                cboManagementFeesPostingFrequency.ValueMember = "Key";
                cboManagementFeesPostingFrequency.DisplayMember = "Value";
                cboManagementFeesPostingFrequency.SelectedIndex = -1;

                var agiopostingfrequency = new BindingList<KeyValuePair<int, string>>();
                agiopostingfrequency.Add(new KeyValuePair<int, string>(1, "Daily"));
                agiopostingfrequency.Add(new KeyValuePair<int, string>(2, "Weekly"));
                agiopostingfrequency.Add(new KeyValuePair<int, string>(3, "Monthly"));
                cboAgioPostingFrequency.DataSource = agiopostingfrequency;
                cboAgioPostingFrequency.ValueMember = "Key";
                cboAgioPostingFrequency.DisplayMember = "Value";
                cboAgioPostingFrequency.SelectedIndex = -1;

                var depositpostingfrequency = new BindingList<KeyValuePair<int, string>>();
                depositpostingfrequency.Add(new KeyValuePair<int, string>(1, "Daily"));
                depositpostingfrequency.Add(new KeyValuePair<int, string>(2, "Weekly"));
                depositpostingfrequency.Add(new KeyValuePair<int, string>(3, "Monthly"));
                cboDepositPostingFrequency.DataSource = depositpostingfrequency;
                cboDepositPostingFrequency.ValueMember = "Key";
                cboDepositPostingFrequency.DisplayMember = "Value";
                cboDepositPostingFrequency.SelectedIndex = -1;

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
                if (savings.name != null)
                {
                    txtName.Text = savings.name;
                }
                if (savings.code != null)
                {
                    txtCode.Text = savings.code;
                }
                if (savings.client_type != null)
                {
                    switch (savings.client_type)
                    {
                        case "I":
                            chkIndividualClient.Checked = true;
                            break;
                        case "A":
                            chkAllClients.Checked = true;
                            break;
                        case "V":
                            chkNonSolidarityClient.Checked = true;
                            break;
                        case "S":
                            chkSolidarityClient.Checked = true;
                            break;
                        case "C":
                            chkCorporateClient.Checked = true;
                            break;
                    }
                }
                if (savings.currency_id != null)
                {
                    cboCurrency.SelectedValue = savings.currency_id;
                }
                if (savings.initial_amount_min != null)
                {
                    txtMinInitialAmount.Text = savings.initial_amount_min.ToString();
                }
                if (savings.initial_amount_max != null)
                {
                    txtMaxInitialAmount.Text = savings.initial_amount_max.ToString();
                }
                if (savings.balance_min != null)
                {
                    txtMinBalance.Text = savings.balance_min.ToString();
                }
                if (savings.balance_max != null)
                {
                    txtMaxBalance.Text = savings.balance_max.ToString();
                }
                if (savings.interest_rate_min != null)
                {
                    txtMinInterestRate.Text = savings.interest_rate_min.ToString();
                }
                if (savings.interest_rate_max != null)
                {
                    txtMaxInterestRate.Text = savings.interest_rate_max.ToString();
                }
                if (savings.interest_rate != null)
                {
                    txtValueInterestRate.Text = savings.interest_rate.ToString();
                }
                if (savings.interest_frequency != null)
                {
                    cboInterestBase.SelectedValue = savings.interest_frequency;
                }
                if (savings.posting_frequency != null)
                {
                    cboPostingFrequency.SelectedValue = savings.posting_frequency;
                }
                if (savings.calcul_amount_base != null)
                {
                    cboCalculateAmountBasedOn.SelectedValue = savings.calcul_amount_base;
                }
                if (savings.cheque_deposit_min != null)
                {
                    txtMinChequeDeposit.Text = savings.cheque_deposit_min.ToString();
                }
                if (savings.cheque_deposit_max != null)
                {
                    txtMaxChequeDeposit.Text = savings.cheque_deposit_max.ToString();
                }
                radioButtonFlatChequeDepositFees.Checked = true;
                if (savings.cheque_deposit_fees_min != null)
                {
                    txtMinChequeDepositFees.Text = savings.cheque_deposit_fees_min.ToString();
                }
                if (savings.cheque_deposit_fees_max != null)
                {
                    txtMaxChequeDepositFees.Text = savings.cheque_deposit_fees_max.ToString();
                }
                if (savings.cheque_deposit_fees != null)
                {
                    txtChequeDepositFees.Text = savings.cheque_deposit_fees.ToString();
                }
                if (savings.withdraw_min != null)
                {
                    txtMinWithdrawAmount.Text = savings.withdraw_min.ToString();
                }
                if (savings.withdraw_max != null)
                {
                    txtMaxWithdrawAmount.Text = savings.withdraw_max.ToString();
                }
                if (savings.withdraw_fees_type != null)
                {
                    switch (savings.withdraw_fees_type.ToString())
                    {
                        case "1":
                            radioButtonFlatWithdrawalFees.Checked = true;
                            break;
                        case "0":
                            radioButtonRateWithdrawalFees.Checked = true;
                            break;
                    }
                }
                if (savings.flat_withdraw_fees_min != null)
                {
                    txtMinWithdrawalFees.Text = savings.flat_withdraw_fees_min.ToString();
                }
                if (savings.flat_withdraw_fees_max != null)
                {
                    txtMaxWithdrawalFees.Text = savings.flat_withdraw_fees_max.ToString();
                }
                if (savings.flat_withdraw_fees != null)
                {
                    txtValueWithdrawalFees.Text = savings.flat_withdraw_fees.ToString();
                }
                if (savings.transfer_min != null)
                {
                    txtMinTransferAmount.Text = savings.transfer_min.ToString();
                }
                if (savings.transfer_max != null)
                {
                    txtMaxTransferAmount.Text = savings.transfer_max.ToString();
                }
                if (savings.transfer_fees_type != null)
                {
                    switch (savings.transfer_fees_type.ToString())
                    {
                        case "1":
                            radioButtonFlatTransferFees.Checked = true;
                            break;
                        case "0":
                            radioButtonRateTransferFees.Checked = true;
                            break;
                    }
                }
                if (savings.flat_transfer_fees_min != null)
                {
                    txtMinTransferFees.Text = savings.flat_transfer_fees_min.ToString();
                }
                if (savings.flat_transfer_fees_max != null)
                {
                    txtMaxTransferFees.Text = savings.flat_transfer_fees_max.ToString();
                }
                if (savings.flat_transfer_fees != null)
                {
                    txtValueTransferFees.Text = savings.flat_transfer_fees.ToString();
                }
                if (savings.transfer_fees_type != null)
                {
                    cboTransferType.SelectedValue = savings.transfer_fees_type;
                }
                if (savings.transfer_fees_type != null)
                {
                    switch (savings.transfer_fees_type.ToString())
                    {
                        case "1":
                            radioButtonFlatTransferFees.Checked = true;
                            break;
                        case "0":
                            radioButtonRateTransferFees.Checked = true;
                            break;
                    }
                }
                if (savings.entry_fees_min != null)
                {
                    txtMinEntryFees.Text = savings.entry_fees_min.ToString();
                }
                if (savings.entry_fees_max != null)
                {
                    txtMaxEntryFees.Text = savings.entry_fees_max.ToString();
                }
                if (savings.entry_fees != null)
                {
                    txtValueEntryFees.Text = savings.entry_fees.ToString();
                }
                radioButtonFlatReopenFees.Checked = true;
                if (savings.reopen_fees_min != null)
                {
                    txtMinReopenFees.Text = savings.reopen_fees_min.ToString();
                }
                if (savings.reopen_fees_max != null)
                {
                    txtMaxReopenFees.Text = savings.reopen_fees_max.ToString();
                }
                if (savings.reopen_fees != null)
                {
                    txtValueReopenFees.Text = savings.reopen_fees.ToString();
                }
                radioButtonFlatCloseFees.Checked = true;
                if (savings.close_fees_min != null)
                {
                    txtMinCloseFees.Text = savings.close_fees_min.ToString();
                }
                if (savings.close_fees_max != null)
                {
                    txtMaxCloseFees.Text = savings.close_fees_max.ToString();
                }
                if (savings.close_fees != null)
                {
                    txtValueCloseFees.Text = savings.close_fees.ToString();
                }
                radioButtonFlatManagementFees.Checked = true;

                if (savings.management_fees_min != null)
                {
                    txtMinManagementFees.Text = savings.management_fees_min.ToString();
                }
                if (savings.management_fees_max != null)
                {
                    txtMaxManagementFees.Text = savings.management_fees_max.ToString();
                }
                if (savings.management_fees != null)
                {
                    txtValueManagementFees.Text = savings.management_fees.ToString();
                }
                if (savings.management_fees_freq != null)
                {
                    cboManagementFeesPostingFrequency.SelectedValue = savings.management_fees_freq;
                }
                radioButtonFlatFixedOverdraftFees.Checked = true;
                if (savings.overdraft_fees_min != null)
                {
                    txtMinFixedOverdraftFees.Text = savings.overdraft_fees_min.ToString();
                }
                if (savings.overdraft_fees_max != null)
                {
                    txtMaxFixedOverdraftFees.Text = savings.overdraft_fees_max.ToString();
                }
                if (savings.overdraft_fees != null)
                {
                    txtValueFixedOverdraftFees.Text = savings.overdraft_fees.ToString();
                }
                radioButtonFlatAgio.Checked = true;
                if (savings.agio_fees_min != null)
                {
                    txtMinAgioFees.Text = savings.agio_fees_min.ToString();
                }
                if (savings.agio_fees_max != null)
                {
                    txtMaxAgioFees.Text = savings.agio_fees_max.ToString();
                }
                if (savings.agio_fees != null)
                {
                    txtValueAgioFees.Text = savings.agio_fees.ToString();
                }
                if (savings.agio_fees_freq != null)
                {
                    cboAgioPostingFrequency.SelectedValue = savings.agio_fees_freq;
                }
                if (savings.use_term_deposit != null)
                {
                    chkUseTermDeposits.Checked = savings.use_term_deposit;
                }
                if (savings.term_deposit_period_min != null)
                {
                    txtMinNumberofPeriods.Text = savings.term_deposit_period_min.ToString();
                }
                if (savings.term_deposit_period_max != null)
                {
                    txtMaxNumberofPeriods.Text = savings.term_deposit_period_max.ToString();
                }
                if (savings.use_term_deposit)
                {
                    groupBoxNumberofPeriods.Enabled = true;
                    groupBoxPostingFrequency.Enabled = true;
                }
                else
                {
                    groupBoxNumberofPeriods.Enabled = false;
                    groupBoxPostingFrequency.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableControls()
        {
            txtName.Enabled = false;
            txtCode.Enabled = false;
            chkAllClients.Enabled = false;
            chkNonSolidarityClient.Enabled = false;
            chkSolidarityClient.Enabled = false;
            chkIndividualClient.Enabled = false;
            chkCorporateClient.Enabled = false;
            cboCurrency.Enabled = false;
            txtMinInitialAmount.Enabled = false;
            txtMaxInitialAmount.Enabled = false;
            txtMinBalance.Enabled = false;
            cboManagementFeesPostingFrequency.Enabled = false;
            txtMaxBalance.Enabled = false;
            txtMinInterestRate.Enabled = false;
            txtMaxInterestRate.Enabled = false;
            txtValueInterestRate.Enabled = false;
            cboInterestBase.Enabled = false;
            cboPostingFrequency.Enabled = false;
            cboCalculateAmountBasedOn.Enabled = false;
            txtMinChequeDeposit.Enabled = false;
            txtMaxChequeDeposit.Enabled = false;
            txtMinChequeDepositFees.Enabled = false;
            txtMaxChequeDepositFees.Enabled = false;
            txtChequeDepositFees.Enabled = false;
            txtMinWithdrawAmount.Enabled = false;
            txtMaxWithdrawAmount.Enabled = false;
            txtMinWithdrawalFees.Enabled = false;
            txtMaxWithdrawalFees.Enabled = false;
            txtValueWithdrawalFees.Enabled = false;
            txtMinTransferAmount.Enabled = false;
            txtMaxTransferAmount.Enabled = false;
            txtMinTransferFees.Enabled = false;
            txtMaxTransferFees.Enabled = false;
            txtValueTransferFees.Enabled = false;
            txtMinEntryFees.Enabled = false;
            txtMaxEntryFees.Enabled = false;
            txtValueEntryFees.Enabled = false;
            txtMinReopenFees.Enabled = false;
            txtMaxReopenFees.Enabled = false;
            txtValueReopenFees.Enabled = false;
            txtMinCloseFees.Enabled = false;
            txtMaxCloseFees.Enabled = false;
            txtValueCloseFees.Enabled = false;
            txtMinManagementFees.Enabled = false;
            txtMaxManagementFees.Enabled = false;
            txtValueManagementFees.Enabled = false;
            txtMinFixedOverdraftFees.Enabled = false;
            txtMaxFixedOverdraftFees.Enabled = false;
            txtValueFixedOverdraftFees.Enabled = false;
            txtMinAgioFees.Enabled = false;
            txtMaxAgioFees.Enabled = false;
            txtValueAgioFees.Enabled = false;
            cboAgioPostingFrequency.Enabled = false;
            chkUseTermDeposits.Enabled = false;
            txtMinNumberofPeriods.Enabled = false;
            txtMaxNumberofPeriods.Enabled = false;
            cboDepositPostingFrequency.Enabled = false;
            cboTransactionIn.Enabled = false;
            radioButtonFlatAgio.Enabled = false;
            radioButtonFlatChequeDepositFees.Enabled = false;
            radioButtonFlatCloseFees.Enabled = false;
            radioButtonFlatEntryFees.Enabled = false;
            radioButtonFlatFixedOverdraftFees.Enabled = false;
            radioButtonFlatManagementFees.Enabled = false;
            radioButtonFlatReopenFees.Enabled = false;
            radioButtonFlatTransferFees.Enabled = false;
            radioButtonFlatWithdrawalFees.Enabled = false;
            radioButtonRateAgio.Enabled = false;
            radioButtonRateChequeDepositFees.Enabled = false;
            radioButtonRateCloseFees.Enabled = false;
            radioButtonRateEntryFees.Enabled = false;
            radioButtonRateFixedOverdraftFees.Enabled = false;
            radioButtonRateManagementFees.Enabled = false;
            radioButtonRateReopenFees.Enabled = false;
            radioButtonRateTransferFees.Enabled = false;
            radioButtonRateWithdrawalFees.Enabled = false;
            cboTransferType.Enabled = false;
            cboAgioPostingFrequency.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
        }
        private void chkUseTermDeposits_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkUseTermDeposits.Checked)
                {
                    groupBoxNumberofPeriods.Enabled = true;
                    groupBoxPostingFrequency.Enabled = true;
                }
                else
                {
                    groupBoxNumberofPeriods.Enabled = false;
                    groupBoxPostingFrequency.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkAllClients_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboTransactionIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTransactionIn.SelectedIndex != -1)
                {
                    KeyValuePair<int, string> transactionin = (KeyValuePair<int, string>)cboTransactionIn.SelectedItem;

                    switch (transactionin.Key)
                    {
                        case 1:
                            groupBoxDeposit.Text = "Cash Deposit";
                            groupBoxDepositFees.Text = "Cash Deposit Fees";
                            break;
                        case 2:
                            groupBoxDeposit.Text = "Cheque Deposit";
                            groupBoxDepositFees.Text = "Cheque Deposit Fees";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboTransferType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }




        #endregion "Private Methods"


















    }
}
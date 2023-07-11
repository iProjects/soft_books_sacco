using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AdminstratorModule.Views
{
    public partial class AddAccountingRulesForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddAccountingRulesForm(string Conn)
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AccountingRuleModel ar = new AccountingRuleModel();
                //ar.rule_type = accountingrule.rule_type;
                //ar.deleted = accountingrule.deleted;
                //ar.booking_direction = accountingrule.booking_direction;
                //ar.event_type = accountingrule.event_type;
                //ar.event_attribute_id = accountingrule.event_attribute_id;
                //ar.debit_account_number_id = accountingrule.debit_account_number_id;
                //ar.credit_account_number_id = accountingrule.credit_account_number_id;
                //ar.order = accountingrule.order;
                //ar.description = accountingrule.description; 
                //ar.product_type = accountingrule.product_type;
                //ar.loan_product_id = accountingrule.loan_product_id;
                //ar.savings_product_id = accountingrule.savings_product_id;
                //ar.client_type = accountingrule.client_type;
                //ar.activity_id = accountingrule.activity_id;
                //ar.currency_id = accountingrule.currency_id;

                rep.AddNewAccountingRule(ar);

                AccountingRulesForm a = (AccountingRulesForm)this.Owner;
                //a.RefreshGrid();
                this.Close();
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
        private void AddAccountingRulesForm_Load(object sender, EventArgs e)
        {
            try
            {
                //PaymentMethod Combox
                var PaymentMethod = new BindingList<KeyValuePair<int, string>>();
                PaymentMethod.Add(new KeyValuePair<int, string>(1, "All"));
                PaymentMethod.Add(new KeyValuePair<int, string>(2, "Cash"));
                PaymentMethod.Add(new KeyValuePair<int, string>(3, "Cheque"));
                PaymentMethod.Add(new KeyValuePair<int, string>(4, "Withdrawal"));
                PaymentMethod.Add(new KeyValuePair<int, string>(5, "DirectDebit"));
                PaymentMethod.Add(new KeyValuePair<int, string>(6, "WireTransfer"));
                PaymentMethod.Add(new KeyValuePair<int, string>(7, "Debitcard"));
                PaymentMethod.Add(new KeyValuePair<int, string>(8, "Voucher"));
                PaymentMethod.Add(new KeyValuePair<int, string>(9, "Savings"));
                cboPaymentMethod.DataSource = PaymentMethod;
                cboPaymentMethod.ValueMember = "Key";
                cboPaymentMethod.DisplayMember = "Value";


                //ProductType Combox
                var ProductType = new BindingList<KeyValuePair<int, string>>();
                ProductType.Add(new KeyValuePair<int, string>(1, "All"));
                ProductType.Add(new KeyValuePair<int, string>(2, "Collateral"));
                ProductType.Add(new KeyValuePair<int, string>(3, "Guarantee"));
                ProductType.Add(new KeyValuePair<int, string>(4, "Loan"));
                ProductType.Add(new KeyValuePair<int, string>(5, "Saving"));
                cboProductType.DataSource = ProductType;
                cboProductType.ValueMember = "Key";
                cboProductType.DisplayMember = "Value";

                //ClientType Combox
                var ClientType = new BindingList<KeyValuePair<int, string>>();
                ClientType.Add(new KeyValuePair<int, string>(1, "All"));
                ClientType.Add(new KeyValuePair<int, string>(2, "Person"));
                ClientType.Add(new KeyValuePair<int, string>(3, "Corporate"));
                ClientType.Add(new KeyValuePair<int, string>(4, "Solidarity Group"));
                ClientType.Add(new KeyValuePair<int, string>(5, "Non-Solidarity Group"));
                cboClientType.DataSource = ClientType;
                cboClientType.ValueMember = "Key";
                cboClientType.DisplayMember = "Value";

                var currenciesquery = from cr in rep.GetCurrenciesList()
                                      select cr;
                List<CurrencyModel> currencies = currenciesquery.ToList();
                cboCurrency.DataSource = currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;

                List<ActivityModel> _EconomicActivities = rep.GetEconomicActivitiesList();
                cboEconomicActivity.DataSource = _EconomicActivities;
                cboEconomicActivity.ValueMember = "activityid";
                cboEconomicActivity.DisplayMember = "name";
                cboEconomicActivity.SelectedIndex = -1;

                var eventtypesquery = from et in rep.GetEventTypesList()
                                      select et;
                List<EventTypesModel> _EventTypes = eventtypesquery.ToList();
                cboEventType.DataSource = _EventTypes;
                cboEventType.ValueMember = "eventtypeid";
                cboEventType.DisplayMember = "description";
                cboEventType.SelectedIndex = -1;

                var draccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _drAccounts = draccountsquery.ToList();
                cboDebitAccount.DataSource = _drAccounts;
                cboDebitAccount.ValueMember = "accountid";
                cboDebitAccount.DisplayMember = "label";
                cboDebitAccount.SelectedIndex = -1;

                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                cboCreditAccount.DataSource = _crAccounts;
                cboCreditAccount.ValueMember = "accountid";
                cboCreditAccount.DisplayMember = "label";
                cboCreditAccount.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void cboEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboEventType.SelectedIndex != -1)
                {
                    EventTypesModel _eventtype = (EventTypesModel)cboEventType.SelectedItem;

                    var _eventattributesquery = rep.GetEventAttributesList(_eventtype.event_type);
                    List<EventAttributesModel> _EventAttributes = _eventattributesquery.ToList();
                    cboEventTypeAttribute.DataSource = _EventAttributes;
                    cboEventTypeAttribute.ValueMember = "eventattributeid";
                    cboEventTypeAttribute.DisplayMember = "name";
                    cboEventTypeAttribute.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"





    }
}

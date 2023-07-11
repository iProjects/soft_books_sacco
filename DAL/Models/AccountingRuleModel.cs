using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AccountingRuleModel
    {
        #region "AccountingRule"
        public int accountingruleid
        {
            get;
            set;
        }
        public string rule_type
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public short booking_direction
        {
            get;
            set;
        }
        public string event_type
        {
            get;
            set;
        }
        public int event_attribute_id
        {
            get;
            set;
        }
        public string event_attribute_name
        {
            get;
            set;
        }
        public string event_type_description
        {
            get;
            set;
        }
        public string draccount_description
        {
            get;
            set;
        }
        public string craccount_description
        {
            get;
            set;
        }
        public int debit_account_number_id
        {
            get;
            set;
        }
        public int credit_account_number_id
        {
            get;
            set;
        }
        public int order
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        #endregion "AccountingRule"
        #region "ContractAccountingRule"
        public int contractaccountingruleid
        {
            get;
            set;
        }
        public short product_type
        {
            get;
            set;
        }
        public int? loan_product_id
        {
            get;
            set;
        }
        public int? savings_product_id
        {
            get;
            set;
        }
        public string client_type
        {
            get;
            set;
        }
        public int? activity_id
        {
            get;
            set;
        }
        public int? currency_id
        {
            get;
            set;
        }
        #endregion "ContractAccountingRule"
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SavingsAccountingMovementModel
    {

        #region "SavingsAccountingMovement"
        public int savingaccountingid
        {
            get;
            set;
        }
        public int contract_id
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
        public decimal amount
        {
            get;
            set;
        } 
        public DateTime transaction_date
        {
            get;
            set;
        }
        public DateTime? export_date
        {
            get;
            set;
        }
        public bool is_exported
        {
            get;
            set;
        }
        public int currency_id
        {
            get;
            set;
        }
        public double exchange_rate
        {
            get;
            set;
        }
        public int rule_id
        {
            get;
            set;
        } 
        public int? event_id
        {
            get;
            set;
        }
        public int branch_id
        {
            get;
            set;
        }
        public int? closure_id
        {
            get;
            set;
        }
        public int? fiscal_year_id
        {
            get;
            set;
        }
        #endregion "SavingsAccountingMovement"
    }
}

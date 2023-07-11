using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class InstallmentsModel
    {
        #region "Installments"
        public DateTime expected_date
        {
            get;
            set;
        }
        public DateTime? _expected_date
        {
            get;
            set;
        }
        public decimal interest_repayment
        {
            get;
            set;
        }
        public decimal capital_repayment
        {
            get;
            set;
        }
        public int contract_id
        {
            get;
            set;
        }
        public int number
        {
            get;
            set;
        }
        public decimal paid_interest
        {
            get;
            set;
        }
        public decimal paid_capital
        {
            get;
            set;
        }
        public decimal fees_unpaid
        {
            get;
            set;
        }
        public DateTime? paid_date
        {
            get;
            set;
        }
        public decimal paid_fees
        {
            get;
            set;
        }
        public string comment
        {
            get;
            set;
        }
        public bool pending
        {
            get;
            set;
        }
        public DateTime start_date
        {
            get;
            set;
        }
        public DateTime? _start_date
        {
            get;
            set;
        }
        public decimal olb
        {
            get;
            set;
        }
        public decimal? _olb
        {
            get;
            set;
        } 
        public int? installmentid
        {
            get;
            set;
        }
        public double installment_monthly_total
        {
            get;
            set;
        }
        #endregion "Installments"
    }
}

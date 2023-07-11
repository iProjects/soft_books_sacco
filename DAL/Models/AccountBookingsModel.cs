using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AccountBookingsModel
    {

        #region "AccountBooking" 
        public DateTime? date
        {
            get;
            set;
        }
        public decimal? amount
        {
            get;
            set;
        }
        public bool? is_exported
        {
            get;
            set;
        }
        public string event_code
        {
            get;
            set;
        }
        public string contract_code
        {
            get;
            set;
        }
        public string debit_local_account_number
        {
            get;
            set;
        }
        public string credit_local_account_number
        {
            get;
            set;
        }
        public double? exchange_rate
        {
            get;
            set;
        } 
        #endregion "AccountBooking"
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ExportAccounting_Transaction_with_datesModel
    {

        #region "ExportAccounting_Transaction_with_dates"
        public int? elementary_id
        {
            get;
            set;
        }
        public string type
        {
            get;
            set;
        }
        public DateTime? date
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
        public decimal? amount
        {
            get;
            set;
        }
        public string fundingLine
        {
            get;
            set;
        }
        public string currency_name
        {
            get;
            set;
        }
        public int? currency_id
        {
            get;
            set;
        }
        public double? exchange_rate
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
        public string name
        {
            get;
            set;
        }
        #endregion "ExportAccounting_Transaction_with_dates"
    }
}

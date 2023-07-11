using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TellerModel
    {

        #region "Teller"
        public int tellerid
        {
            get;
            set;
        }
        public string _DisplayName
        {
            get { return name + " " + desc; }  
        }
        public string name
        {
            get;
            set;
        }
        public string desc
        {
            get;
            set;
        }
        public int account_id
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public int branch_id
        {
            get;
            set;
        }
        public int currency_id
        {
            get;
            set;
        } 
        public int user_id
        {
            get;
            set;
        }
        public decimal? amount_min
        {
            get;
            set;
        }
        public decimal? amount_max
        {
            get;
            set;
        }
        public decimal? deposit_amount_min
        {
            get;
            set;
        }
        public decimal? deposit_amount_max
        {
            get;
            set;
        }
        public decimal? withdrawal_amount_min
        {
            get;
            set;
        }
        public decimal? withdrawal_amount_max
        {
            get;
            set;
        }
        public decimal? cash_in_min
        {
            get;
            set;
        }
        public decimal? cash_in_max
        {
            get;
            set;
        }
        public decimal? cash_out_min
        {
            get;
            set;
        }
        public decimal? cash_out_max
        {
            get;
            set;
        }
        public decimal? balance_min
        {
            get;
            set;
        }
        public decimal? balance_max
        {
            get;
            set;
        }
        #endregion "Teller"
    }
}

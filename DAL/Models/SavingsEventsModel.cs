using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SavingsEventsModel
    {

        #region "SavingsEvents"
        public int savingseventid
        {
            get;
            set;
        }
        public int user_id
        {
            get;
            set;
        }
        public int contract_id
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
        public decimal amount
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public DateTime creation_date
        {
            get;
            set;
        }
        public bool cancelable
        {
            get;
            set;
        }
        public bool is_fired
        {
            get;
            set;
        }
        public string related_contract_code
        {
            get;
            set;
        }
        public decimal? fees
        {
            get;
            set;
        }
        public bool is_exported
        {
            get;
            set;
        }
        public short? savings_method
        {
            get;
            set;
        }
        public bool pending
        {
            get;
            set;
        }
        public int? pending_event_id
        {
            get;
            set;
        }
        public int? teller_id
        {
            get;
            set;
        }
        public int? loan_event_id
        {
            get;
            set;
        }
        public DateTime? cancel_date
        {
            get;
            set;
        } 
        #endregion "SavingsEvents"
    }
}

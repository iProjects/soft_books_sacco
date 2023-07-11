using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PaymentMethodModel
    {
        #region "PaymentMethod"
        public int paymentmethodid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public bool is_active_for_loans
        {
            get;
            set;
        }
        public bool is_pending_for_loans
        {
            get;
            set;
        }
        public bool is_active_for_savings
        {
            get;
            set;
        }
        public bool is_pending_for_savings
        {
            get;
            set;
        }
        public int? account_id
        {
            get;
            set;
        }
        public bool is_deleted
        {
            get;
            set;
        }
        #endregion "PaymentMethod"
    }
}

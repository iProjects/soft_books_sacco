using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CreditEntryFeesModel
    {
        #region "CreditEntryFees"
        public int creditentryfeeid
        {
            get;
            set;
        }
        public int credit_id
        {
            get;
            set;
        }
        public int entry_fee_id
        {
            get;
            set;
        }   
        public int id_product
        {
            get;
            set;
        }
        public string name_of_fee
        {
            get;
            set;
        }  
        public bool? rate
        {
            get;
            set;
        } 
        public int entryfeeid
        {
            get;
            set;
        }  
        public decimal? min
        {
            get;
            set;
        }
        public decimal? max
        {
            get;
            set;
        }
        public decimal? value
        {
            get;
            set;
        }
        public decimal? Amount
        {
            get
            {
                return value ?? min;
            }
        }
        public decimal fee_value
        {
            get;
            set;
        } 
        public bool is_deleted
        {
            get;
            set;
        }
        public int fee_index
        {
            get;
            set;
        }
        public int? cycle_id
        {
            get;
            set;
        }
        #endregion "CreditEntryFees"
    }
}

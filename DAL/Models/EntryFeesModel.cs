using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class EntryFeesModel
    {
        #region "EntryFees"
        public int entryfeeid
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
        public decimal _fee_value
        {
            get 
            {
                return value ?? 0;
            }
        }
        public bool? rate
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
        #endregion "EntryFees"
    }
}

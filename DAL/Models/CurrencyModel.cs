using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CurrencyModel
    {

        #region "Currency"
        public int currencyid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public bool is_pivot
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
        public bool is_swapped
        {
            get;
            set;
        }
        public bool use_cents
        {
            get;
            set;
        }
        #endregion "Currency"
    }
}

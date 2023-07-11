using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LoansLinkSavingsBookModel
    {
        #region "LoansLinkSavings"
        public int loanlinksavingid
        {
            get;
            set;
        }
        public int? loan_id
        {
            get;
            set;
        }
        public int? savings_id
        {
            get;
            set;
        }
        public int? loan_percentage
        {
            get;
            set;
        }
        #endregion "LoansLinkSavings"
    }
}

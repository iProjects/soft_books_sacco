using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LoanGuarantorsModel
    {
        #region "LoanGuarantors"
        public int loanscaleid
        {
            get;
            set;
        }
        public int? ScaleMin
        {
            get;
            set;
        }
        public int? ScaleMax
        {
            get;
            set;
        }
        #endregion "LoanGuarantors"
    }
}

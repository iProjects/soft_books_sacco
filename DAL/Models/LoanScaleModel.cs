using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LoanScaleModel
    {
        #region "LoanScale"
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
        #endregion "LoanScale"
    }
}

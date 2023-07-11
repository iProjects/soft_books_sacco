using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FiscalYearModel
    {

        #region "FinancialPeriod"
        public int fiscalyearid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public DateTime? open_date
        {
            get;
            set;
        }
        public DateTime? close_date
        {
            get;
            set;
        } 
        #endregion "FinancialPeriod"
    }
}

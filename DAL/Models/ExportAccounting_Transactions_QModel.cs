using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ExportAccounting_Transactions_QModel
    {

        #region "ExportAccounting_Transactions_Q"
        public int? ID
        {
            get;
            set;
        }
        public string Loan
        {
            get;
            set;
        }
        public string TRNS
        {
            get;
            set;
        }
        public string TRNSTYPE
        {
            get;
            set;
        }
        public string DATE
        {
            get;
            set;
        }
        public string ACCNT
        {
            get;
            set;
        }
        public string NAME
        {
            get;
            set;
        }
        public string AMOUNT
        {
            get;
            set;
        } 
        #endregion "ExportAccounting_Transactions_Q"
    }
}

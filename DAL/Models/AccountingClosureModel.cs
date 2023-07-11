using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AccountingClosureModel
    {

        #region "AccountingClosure"
        public int accountingclosureid
        {
            get;
            set;
        }
        public int user_id
        {
            get;
            set;
        }
        public DateTime date_of_closure
        {
            get;
            set;
        }
        public int count_of_transactions
        {
            get;
            set;
        }
        public bool? is_deleted
        {
            get;
            set;
        } 
        #endregion "AccountingClosure"
    }
}

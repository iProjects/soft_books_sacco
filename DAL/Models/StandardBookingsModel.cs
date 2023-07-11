using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StandardBookingsModel
    {

        #region "StandardBookings"
        public int standardbookingid
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int debit_account_id
        {
            get;
            set;
        }
        public int credit_account_id
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        } 
        #endregion "StandardBookings"
    }
}

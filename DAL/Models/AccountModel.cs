using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AccountModel
    {
        #region "Account"
        public int accountid
        {
            get;
            set;
        }
        public string account_number
        {
            get;
            set;
        }
        public string label
        {
            get;
            set;
        }
        public bool debit_plus
        {
            get;
            set;
        }
        public string type_code
        {
            get;
            set;
        }
        public short account_category_id
        {
            get;
            set;
        }
        public bool type
        {
            get;
            set;
        }
        public int? parent_account_id
        {
            get;
            set;
        } 
        public int lft
        {
            get;
            set;
        }
        public int rgt
        {
            get;
            set;
        }
        #endregion "Account"
    }
}

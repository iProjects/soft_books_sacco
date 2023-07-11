using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RoleModel
    {

        #region "Role"
        public int roleid
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public bool? role_of_loan
        {
            get;
            set;
        }
        public bool? role_of_saving
        {
            get;
            set;
        }
        public bool? role_of_teller
        {
            get;
            set;
        }
        #endregion "Role"
    }
}

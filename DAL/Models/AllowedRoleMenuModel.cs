using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AllowedRoleMenuModel
    {

        #region "AllowedRoleMenu"
        public int menu_item_id
        {
            get;
            set;
        }
        public int role_id
        {
            get;
            set;
        }
        public bool allowed
        {
            get;
            set;
        } 
        #endregion "AllowedRoleMenu"
    }
}

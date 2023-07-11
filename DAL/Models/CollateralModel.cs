using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CollateralModel
    {
        #region "Collateral"
        public int activityid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public int? parent_id
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        #endregion "Collateral"
    }
}

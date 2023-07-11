using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CollateralPropertyCollectionsModel
    {
        #region "CollateralPropertyCollections"
        public int collpropcollid
        {
            get;
            set;
        }
        public int property_id
        {
            get;
            set;
        }
        public string value
        {
            get;
            set;
        }
        public string propertyname
        {
            get;
            set;
        } 
        #endregion "CollateralPropertyCollections"
    }
}

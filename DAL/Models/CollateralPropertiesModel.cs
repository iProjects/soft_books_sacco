using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CollateralPropertiesModel
    {

        #region "CollateralProperties"
        public int collateralpropertyid
        {
            get;
            set;
        }
        public int _collateralpropertyid
        {
            get;
            set;
        }
        public int product_id
        {
            get;
            set;
        }
        public int type_id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string productname
        {
            get;
            set;
        }
        public string desc
        {
            get;
            set;
        }
        public string value
        {
            get;
            set;
        }
        #endregion "CollateralProperties"
    }
}

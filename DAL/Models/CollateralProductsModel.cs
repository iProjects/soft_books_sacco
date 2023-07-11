using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CollateralProductsModel
    {
        #region "CollateralProducts"
        public int collateralproductid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string desc
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public List<CollateralPropertiesModel> productProperties { get; set; }
        #endregion "CollateralProducts"
    }
}

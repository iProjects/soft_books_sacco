using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DistrictModel
    {
        #region "District"
        public int districtid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public int province_id
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        #endregion "District"
    }
}

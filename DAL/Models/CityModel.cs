using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CityModel
    {
        #region "City"
        public int cityid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public int district_id
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        #endregion "City"
    }
}

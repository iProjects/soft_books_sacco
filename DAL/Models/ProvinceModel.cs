using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProvinceModel
    {
        #region "Province"
        public int provinceid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        } 
        public bool deleted
        {
            get;
            set;
        }
        #endregion "Province"
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ExoticInstallmentsModel
    {
        #region "ExoticInstallments"
        public int number
        {
            get;
            set;
        }
        public decimal principal_coeff
        {
            get;
            set;
        }
        public decimal interest_coeff
        {
            get;
            set;
        }
        public int exotic_id
        {
            get;
            set;
        }
        #endregion "ExoticInstallments"
    }
}

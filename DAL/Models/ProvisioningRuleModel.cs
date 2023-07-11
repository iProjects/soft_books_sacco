using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProvisioningRuleModel
    {
        #region "ProvisioningRule"
        public int provisioningruleid
        {
            get;
            set;
        }
        public int number_of_days_min
        {
            get;
            set;
        }
        public int number_of_days_max
        {
            get;
            set;
        }
        public double provisioning_value
        {
            get;
            set;
        }
        #endregion "ProvisioningRule"
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class InstallmentTypesModel
    {
        #region "InstallmentType"
        public int installmenttypesid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public int nb_of_days
        {
            get;
            set;
        }
        public int nb_of_months
        {
            get;
            set;
        }
        #endregion "InstallmentType"
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ClientPersonalInformationSavingsModel
    {

        #region "ClientPersonalInformationSavings"
        public string savings_code
        {
            get;
            set;
        }
        public decimal? balance_amount
        {
            get;
            set;
        }
        public string product_name
        {
            get;
            set;
        }
        public string product_code
        {
            get;
            set;
        }
        public string product_type
        {
            get;
            set;
        }
        public DateTime? creation_date
        {
            get;
            set;
        }
        public DateTime? closed_date
        {
            get;
            set;
        } 
        #endregion "ClientPersonalInformationSavings"
    }
}

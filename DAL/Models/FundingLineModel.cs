using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FundingLineModel
    {
        #region "FundingLine"
        public int fundinglineid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public DateTime begin_date
        {
            get;
            set;
        }
        public DateTime end_date
        {
            get;
            set;
        }
        public decimal amount
        {
            get;
            set;
        }
        public string purpose
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public int currency_id
        {
            get;
            set;
        }
        #endregion "FundingLine"
    }
}
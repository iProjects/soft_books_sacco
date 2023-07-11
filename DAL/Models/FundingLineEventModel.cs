using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FundingLineEventModel
    {
        #region "FundingLineEvent"
        public int fundinglineeventid
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
        public decimal amount
        {
            get;
            set;
        }
        public short direction
        {
            get;
            set;
        }
        public int fundingline_id
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public DateTime creation_date
        {
            get;
            set;
        }
        public short type
        {
            get;
            set;
        }
        public int? user_id
        {
            get;
            set;
        }
        public int? contract_event_id
        {
            get;
            set;
        }
        #endregion "FundingLineEvent"
    }
}
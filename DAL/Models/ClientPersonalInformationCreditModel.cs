using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ClientPersonalInformationCreditModel
    {

        #region "ClientPersonalInformationCredit"
        public string contract_code
        {
            get;
            set;
        }
        public string status
        {
            get;
            set;
        }
        public decimal? amount
        {
            get;
            set;
        }
        public decimal? olb
        {
            get;
            set;
        }
        public DateTime? creation_date
        {
            get;
            set;
        }
        public DateTime? start_date
        {
            get;
            set;
        }
        public DateTime? close_date
        {
            get;
            set;
        }
        public string group_name
        {
            get;
            set;
        }
        public int? total_late_days
        {
            get;
            set;
        }
        public bool? has_atr
        {
            get;
            set;
        } 
        #endregion "ClientPersonalInformationCredit"
    }
}

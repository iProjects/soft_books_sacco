using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProjectModel
    {
        #region "Project"
        public int projectid
        {
            get;
            set;
        }
        public int tiers_id
        {
            get;
            set;
        }
        public short status
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
        public string aim
        {
            get;
            set;
        }
        public DateTime begin_date
        {
            get;
            set;
        }
        public string abilities
        {
            get;
            set;
        }
        public string experience
        {
            get;
            set;
        }
        public string market
        {
            get;
            set;
        } 
        public string concurrence
        {
            get;
            set;
        }
        public string purpose
        {
            get;
            set;
        }
        public string corporate_name
        {
            get;
            set;
        }
        public string corporate_juridicStatus
        {
            get;
            set;
        }
        public string corporate_FiscalStatus
        {
            get;
            set;
        }
        public string corporate_siret
        {
            get;
            set;
        }
        public decimal corporate_CA
        {
            get;
            set;
        }
        public int corporate_nbOfJobs
        {
            get;
            set;
        }
        public string corporate_financialPlanType
        {
            get;
            set;
        }
        public string corporateFinancialPlanAmount
        {
            get;
            set;
        }
        public decimal corporate_financialPlanTotalAmount
        {
            get;
            set;
        }
        public string address
        {
            get;
            set;
        }
        public string city
        {
            get;
            set;
        }
        public string zipCode
        {
            get;
            set;
        }
        public int district_id
        {
            get;
            set;
        } 
        public string home_phone
        {
            get;
            set;
        }
        public string personalPhone
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string hometype
        {
            get;
            set;
        }
        public string corporate_registre
        {
            get;
            set;
        }
        #endregion "Project"
    }
}

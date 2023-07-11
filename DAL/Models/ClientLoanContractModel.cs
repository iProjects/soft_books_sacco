using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ClientLoanContractModel
    {

        #region "Contracts"
        public int contractid
        {
            get;
            set;
        }
        public string contract_code
        {
            get;
            set;
        }
        public string packagename
        {
            get;
            set;
        }
        public string branch_code
        {
            get;
            set;
        }
        public DateTime creation_date
        {
            get;
            set;
        }
        public DateTime start_date
        {
            get;
            set;
        }
        public DateTime close_date
        {
            get;
            set;
        }
        public bool closed
        {
            get;
            set;
        }
        public int project_id
        {
            get;
            set;
        }
        public short status
        {
            get;
            set;
        }
        public DateTime? credit_commitee_date
        {
            get;
            set;
        }
        public string credit_commitee_comment
        {
            get;
            set;
        }
        public string credit_commitee_code
        {
            get;
            set;
        }
        public DateTime? align_disbursed_date
        {
            get;
            set;
        }
        public string loan_purpose
        {
            get;
            set;
        }
        public string comments
        {
            get;
            set;
        }
        public int? nsg_id
        {
            get;
            set;
        }
        public int activity_id
        {
            get;
            set;
        }
        public DateTime first_installment_date
        {
            get;
            set;
        }
        #endregion "Contracts"

        #region "Credit"
        public int creditid
        {
            get;
            set;
        }
        public int package_id
        {
            get;
            set;
        }
        public decimal amount
        {
            get;
            set;
        }
        public decimal interest_rate
        {
            get;
            set;
        }
        public decimal? interest_rate_min
        {
            get;
            set;
        }
        public decimal? interest_rate_max
        {
            get;
            set;
        }
        public int installment_type
        {
            get;
            set;
        }
        public int nb_of_installment
        {
            get;
            set;
        } 
        public double anticipated_total_repayment_penalties
        {
            get;
            set;
        }
        public bool disbursed
        {
            get;
            set;
        }
        public int loanofficer_id
        {
            get;
            set;
        }
        public int? grace_period
        {
            get;
            set;
        }
        public int? grace_period_min
        {
            get;
            set;
        }
        public int? grace_period_max
        {
            get;
            set;
        }
        public bool written_off
        {
            get;
            set;
        }
        public bool rescheduled
        {
            get;
            set;
        }
        public bool bad_loan
        {
            get;
            set;
        }
        public double non_repayment_penalties_based_on_overdue_principal
        {
            get;
            set;
        }
        public double non_repayment_penalties_based_on_initial_amount
        {
            get;
            set;
        }
        public double non_repayment_penalties_based_on_olb
        {
            get;
            set;
        }
        public double non_repayment_penalties_based_on_overdue_interest
        {
            get;
            set;
        }
        public int fundingLine_id
        {
            get;
            set;
        }
        public int currency_id
        {
            get;
            set;
        }
        public bool synchronize
        {
            get;
            set;
        }
        public decimal interest
        {
            get;
            set;
        }
        public int grace_period_of_latefees
        {
            get;
            set;
        }
        public double? anticipated_partial_repayment_penalties
        {
            get;
            set;
        }
        public int? number_of_drawings_loc
        {
            get;
            set;
        }
        public decimal? amount_under_loc
        {
            get;
            set;
        }
        public int? maturity_loc
        {
            get;
            set;
        }
        public short anticipated_partial_repayment_base
        {
            get;
            set;
        }
        public short anticipated_total_repayment_base
        {
            get;
            set;
        }
        public bool schedule_changed
        {
            get;
            set;
        }
        public decimal? amount_min
        {
            get;
            set;
        }
        public decimal? amount_max
        {
            get;
            set;
        }
        public decimal? ir_min
        {
            get;
            set;
        }
        public decimal? ir_max
        {
            get;
            set;
        }
        public int? nmb_of_inst_min
        {
            get;
            set;
        }
        public int? nmb_of_inst_max
        {
            get;
            set;
        }
        public int? loan_cycle
        {
            get;
            set;
        }
        public decimal insurance
        {
            get;
            set;
        }
        public decimal insurance_min
        {
            get;
            set;
        }
        public decimal insurance_max
        {
            get;
            set;
        }
        public int? exotic_id
        {
            get;
            set;
        }
        public int savingcontractid
        {
            get;
            set;
        }
        #endregion "Credit"

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
        public short project_status
        {
            get;
            set;
        }
        public string project_name
        {
            get;
            set;
        }
        public string project_code
        {
            get;
            set;
        }
        public string aim
        {
            get;
            set;
        }
        public DateTime project_begin_date
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
        public decimal? corporate_CA
        {
            get;
            set;
        }
        public int? corporate_nbOfJobs
        {
            get;
            set;
        }
        public string corporate_financialPlanType
        {
            get;
            set;
        }
        public decimal? corporateFinancialPlanAmount
        {
            get;
            set;
        }
        public decimal? corporate_financialPlanTotalAmount
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
        public int? district_id
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

        #region "CompusorySaving"
        public int? compulsory_amount
        {
            get;
            set;
        }
        public int? compulsory_amount_min
        {
            get;
            set;
        }
        #endregion "CompusorySaving"

    }
}
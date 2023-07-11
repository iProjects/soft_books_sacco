using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LoanPackageModel
    {
        #region "Packages"
        public int packageid
        {
            get;
            set;
        }
        public int contract_id
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string client_type
        {
            get;
            set;
        }
        public decimal? amount
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
        public decimal? interest_rate
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
        public int? installment_type
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
        public int? number_of_installments
        {
            get;
            set;
        }
        public int? number_of_installments_min
        {
            get;
            set;
        }
        public int? number_of_installments_max
        {
            get;
            set;
        }
        public double? anticipated_total_repayment_penalties
        {
            get;
            set;
        }
        public double? anticipated_total_repayment_penalties_min
        {
            get;
            set;
        }
        public double? anticipated_total_repayment_penalties_max
        {
            get;
            set;
        }
        public int? loan_type
        {
            get;
            set;
        }
        public bool keep_expected_installment
        {
            get;
            set;

        }
        public bool charge_interest_within_grace_period
        {
            get;
            set;
        } 
        public int? cycle_id
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_overdue_interest
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_initial_amount
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_olb
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_overdue_principal
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_overdue_interest_min
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_initial_amount_min
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_olb_min
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_overdue_principal_min
        {
            get;
            set;

        }
        public double? non_repayment_penalties_based_on_overdue_interest_max
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_initial_amount_max
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_olb_max
        {
            get;
            set;
        }
        public double? non_repayment_penalties_based_on_overdue_principal_max
        {
            get;
            set;
        }
        public int? fundingLine_id
        {
            get;
            set;
        }
        public int currency_id
        {
            get;
            set;
        }
        public int rounding_type
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
        public double? anticipated_partial_repayment_penalties_min
        {
            get;
            set;
        }
        public double? anticipated_partial_repayment_penalties_max
        {
            get;
            set;
        }
        public double? anticipated_partial_repayment_base
        {
            get;
            set;
        }
        public int? anticipated_total_repayment_base
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
        public decimal? amount_under_loc_min
        {
            get;
            set;
        }
        public decimal? amount_under_loc_max
        {
            get;
            set;
        }
        public int? maturity_loc
        {
            get;
            set;
        }
        public int? maturity_loc_min
        {
            get;
            set;
        }
        public int? maturity_loc_max
        {
            get;
            set;
        }
        public bool activated_loc
        {
            get;
            set;
        } 
        public bool allow_flexible_schedule
        {
            get;
            set;
        }
        public bool? use_guarantor_collateral
        {
            get;
            set;

        }
        public bool set_separate_guarantor_collateral
        {
            get;
            set;
        }
        public int percentage_total_guarantor_collateral
        {
            get;
            set;
        }
        public int percentage_separate_guarantor
        {
            get;
            set;
        }
        public int percentage_separate_collateral
        {
            get;
            set;
        }
        public bool use_compulsory_savings
        {
            get;
            set;
        }
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
        public int? compulsory_amount_max
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
        public bool use_entry_fees_cycles
        {
            get;
            set;

        }
        public bool is_balloon
        {
            get;
            set;
        } 
        #endregion "Packages"

    }
}

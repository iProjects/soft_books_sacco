using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SavingProductModel
    {
        #region "SavingProduct"
        public int savingproductid
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
        public decimal? initial_amount_min
        {
            get;
            set;
        }
        public decimal? initial_amount_max
        {
            get;
            set;
        }
        public decimal? balance_min
        {
            get;
            set;
        }
        public decimal? balance_max
        {
            get;
            set;
        }
        public decimal? withdraw_min
        {
            get;
            set;
        }
        public decimal? withdraw_max
        {
            get;
            set;
        }
        public decimal? deposit_min
        {
            get;
            set;

        }
        public decimal? deposit_max
        {
            get;
            set;
        }
        public double? interest_rate
        {
            get;
            set;
        }
        public double? interest_rate_min
        {
            get;
            set;
        }
        public double? interest_rate_max
        {
            get;
            set;
        }
        public int currency_id
        {
            get;
            set;
        }
        public decimal? entry_fees_min
        {
            get;
            set;
        }
        public decimal? entry_fees_max
        {
            get;
            set;
        }
        public decimal? entry_fees
        {
            get;
            set;
        }
        public string product_type
        {
            get;
            set;
        }
        public decimal transfer_min
        {
            get;
            set;
        }
        public decimal transfer_max
        {
            get;
            set;

        }
        #endregion "SavingProduct"

        #region "SavingBookProducts"
        public int saving_book_productid
        {
            get;
            set;
        }
        public short interest_base
        {
            get;
            set;
        }
        public short interest_frequency
        {
            get;
            set;
        }
        public short? calcul_amount_base
        {
            get;
            set;
        }
        public float withdraw_fees_type
        {
            get;
            set;
        }
        public decimal? flat_withdraw_fees_min
        {
            get;
            set;
        }
        public decimal? flat_withdraw_fees_max
        {
            get;
            set;
        }
        public decimal? flat_withdraw_fees
        {
            get;
            set;
        }
        public double? rate_withdraw_fees_min
        {
            get;
            set;
        }
        public double? rate_withdraw_fees_max
        {
            get;
            set;
        }
        public double? rate_withdraw_fees
        {
            get;
            set;

        }
        public short transfer_fees_type
        {
            get;
            set;
        }
        public decimal? flat_transfer_fees_min
        {
            get;
            set;
        }
        public decimal? flat_transfer_fees_max
        {
            get;
            set;
        }
        public decimal? flat_transfer_fees
        {
            get;
            set;
        }
        public double? rate_transfer_fees_min
        {
            get;
            set;
        }
        public double? rate_transfer_fees_max
        {
            get;
            set;
        }
        public double? rate_transfer_fees
        {
            get;
            set;
        }
        public decimal? deposit_fees
        {
            get;
            set;
        }
        public decimal? deposit_fees_max
        {
            get;
            set;
        }
        public decimal? deposit_fees_min
        {
            get;
            set;
        }
        public decimal? close_fees
        {
            get;
            set;
        }
        public decimal? close_fees_max
        {
            get;
            set;
        }
        public decimal? close_fees_min
        {
            get;
            set;

        }
        public decimal? management_fees
        {
            get;
            set;
        }
        public decimal? management_fees_max
        {
            get;
            set;
        }
        public decimal? management_fees_min
        {
            get;
            set;
        }
        public int management_fees_freq
        {
            get;
            set;
        }
        public decimal? overdraft_fees
        {
            get;
            set;
        }
        public decimal? overdraft_fees_max
        {
            get;
            set;
        }
        public decimal? overdraft_fees_min
        {
            get;
            set;
        }
        public double? agio_fees
        {
            get;
            set;
        }
        public double? agio_fees_max
        {
            get;
            set;
        }
        public double? agio_fees_min
        {
            get;
            set;
        }
        public int agio_fees_freq
        {
            get;
            set;

        }
        public decimal? cheque_deposit_min
        {
            get;
            set;
        }
        public decimal? cheque_deposit_max
        {
            get;
            set;
        }
        public decimal? cheque_deposit_fees
        {
            get;
            set;
        }
        public decimal? cheque_deposit_fees_min
        {
            get;
            set;
        }
        public decimal? cheque_deposit_fees_max
        {
            get;
            set;
        }
        public decimal? reopen_fees
        {
            get;
            set;
        }
        public decimal? reopen_fees_min
        {
            get;
            set;
        }
        public decimal? reopen_fees_max
        {
            get;
            set;
        }
        public bool is_ibt_fee_flat
        {
            get;
            set;
        }
        public decimal? ibt_fee_min
        {
            get;
            set;
        }
        public decimal? ibt_fee_max
        {
            get;
            set;

        }
        public decimal? ibt_fee
        {
            get;
            set;
        }
        public bool use_term_deposit
        {
            get;
            set;
        }
        public int? term_deposit_period_min
        {
            get;
            set;
        }
        public int? term_deposit_period_max
        {
            get;
            set;

        }
        public int? posting_frequency
        {
            get;
            set;
        }
        #endregion "SavingBookProducts"
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ClientContractCollateralsModel
    {
        #region "ClientContractCollaterals" 
        public int clientcontractcollateralid
        {
            get;
            set;
        }   
        public int contract_id
        {
            get;
            set;
        }   
        public string product_desc
        {
            get;
            set;
        }
        public bool deleted
        {
            get;
            set;
        } 
        public int collateralpropertyvalueid
        {
            get;
            set;
        }
        public int contract_collateral_id
        {
            get;
            set;
        }
        public int property_id
        {
            get;
            set;
        }
        public string property_name
        {
            get;
            set;
        }
        public string property_desc
        {
            get;
            set;
        }
        public string value
        {
            get;
            set;
        } 
        public int _collateralpropertyid
        {
            get;
            set;
        }
        public int product_id
        {
            get;
            set;
        }
        public int type_id
        {
            get;
            set;
        } 
        public string product_name
        {
            get;
            set;
        }
        public decimal amount
        {
            get;
            set;
        }
        public double loan_percentage
        {
            get;
            set;
        } 
        #endregion "ClientContractCollaterals"
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BranchModel
    {
        #region "Branch"
        public int branchid
        {
            get;
            set;
        }
        public string name
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
        public string address
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        #endregion "Branch"
    }
}

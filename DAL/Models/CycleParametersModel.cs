using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CycleParametersModel
    {

        #region "CycleParameters"
        public int cycleparameterid
        {
            get;
            set;
        }
        public int _cycle_parameter_id
        {
            get;
            set;
        }
        public int loan_cycle
        {
            get;
            set;
        }
        public decimal min
        {
            get;
            set;
        }
        public decimal max
        {
            get;
            set;
        }
        public int cycle_object_id
        {
            get;
            set;
        }
        public int cycle_id
        {
            get;
            set;
        }
        #endregion "CycleParameters"
    }
}

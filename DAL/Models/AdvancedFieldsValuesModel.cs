using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AdvancedFieldsValuesModel
    {
        #region "AdvancedFieldsValues"
        public int advfieldsvaluesid
        {
            get;
            set;
        }
        public int entity_field_id
        {
            get;
            set;
        }
        public int field_id
        {
            get;
            set;
        }
        public string value
        {
            get;
            set;
        }
        #endregion "AdvancedFieldsValues"
    }
}

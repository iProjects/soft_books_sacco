using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CustomizableFieldsModel
    {

        #region "CustomizableFields"
        public int advfieldsid
        {
            get;
            set;
        } 
        public int entity_id
        {
            get;
            set;
        }
        public int fieldscount
        {
            get;
            set;
        }
        public string fieldnameslist
        {
            get;
            set;
        } 
        #endregion "CustomizableFields"
    }
}

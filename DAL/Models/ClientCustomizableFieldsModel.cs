using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ClientCustomizableFieldsModel
    {

        #region "ClientCustomizableFields"
        public int advfieldsid
        {
            get;
            set;
        }
        public int _advnsdfldid
        {
            get;
            set;
        }
        public int entity_id
        {
            get;
            set;
        }
        public int type_id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string desc
        {
            get;
            set;
        }
        public bool is_mandatory
        {
            get;
            set;
        }
        public bool is_unique
        {
            get;
            set;
        }
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
        #endregion "ClientCustomizableFields"
    }
}

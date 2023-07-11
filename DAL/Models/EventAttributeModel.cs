using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class EventAttributesModel
    {
        #region "EventAttribute"
        public int eventattributeid
        {
            get;
            set;
        }
        public string event_type
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        #endregion "EventAttribute"
    }
}

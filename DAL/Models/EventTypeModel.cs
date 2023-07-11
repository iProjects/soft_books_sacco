using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class EventTypesModel
    {
        #region "EventType"
        public int eventtypeid
        {
            get;
            set;
        }
        public string event_type
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public int? sort_order
        {
            get;
            set;
        }
        public bool? accounting
        {
            get;
            set;
        }       
        #endregion "EventType"
    }
}

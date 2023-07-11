using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StoredProceduresModel
    {

        #region "StoredProcedures"
        public int storedprocedureid
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Schema
        {
            get;
            set;
        }
        public string TextHeader
        {
            get;
            set;
        } 
        public string TextBody
        {
            get;
            set;
        } 
        #endregion "StoredProcedures"
    }
}

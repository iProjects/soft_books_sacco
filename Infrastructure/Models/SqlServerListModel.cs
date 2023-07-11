using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Infrastructure.Models
{
    public class SqlServerListModel
    {

        public string FullServerName
        {
            get
            {
                return this.ServerName.Trim() + @"\" + this.InstanceName.Trim() ;
            }
        }
      
        public string ServerName
        {
            get;
            set;
        }

        public string DatabaseName
        {
            get;
            set;
        }

        public string SelectedServer
        {
            get
            {
                return this.ServerName;
            }

        }

        public string SelectedDatabase
        {
            get
            {
                return this.DatabaseName;
            }
            
        }

        public string TableName
        {
            get;
            set;
        }

        public string DBUser
        {
            get;
            set;
        }

        public string NewDatabaseName
        {
            get;
            set;
        }

        public string StoredProcedureName
        {
            get;
            set;
        }

        public string InstanceName
        {
            get;
            set;
        }

        public bool IsClustered
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool UseWindowsAuthentication
        {
            get;
            set;
        }

        public bool UseSQLServerAuthentication
        {
            get;
            set;
        }

        public bool Select_EnterDatabase
        {
            get;
            set;
        }

        public bool AttachDatabase
        {
            get;
            set;
        }

        public string OFDSelectedDatabase
        {
            get;
            set;
        }



    }
}

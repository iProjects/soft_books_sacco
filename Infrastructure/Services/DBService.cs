using System.Collections.Generic;
using System.Data;

using Microsoft.SqlServer.Management.Smo;


namespace Infrastructure.Services
{
    public class DBService : IDBService
    {
        SMOHelper smoHelper;

        public DBService()
        {
        }

        public void Connect(string serverAndInstanceName, string userName, string password, bool useWindowsAuthentication)
        {
            smoHelper = new SMOHelper(
                serverAndInstanceName,
                userName,
                password,
                useWindowsAuthentication);

            smoHelper.Connect();
        }
        

        /*
        1. Name | String | The name of the instance of SQL Server.
        
        2. Server |String|The name of the server on which the instance of SQL Server is installed.
        3. Instance String The instance of SQL Server.
        4. IsClustered Boolean A Boolean value that is True if the instance is participating in failover clustering, or False if it is not.
        5. Version String The version of the instance of SQL Server.
        6. IsLocal Boolean A Boolean value that is True if the instance is local, or False if the instance is remote.
         */
        public DataTable GetNetworkServers()
        {
            /*
             * Pros:
 + Includes SQL Servers which are not registered

 Cons:
 - Doesn't work when there's no network connection
 - Subject to firewall rules (Blocked TCP 1433 and UDP 1434)
 - Doesn't find SQL Servers if SQL Browser is off
 - Doesn't find SQL Servers if they are hidden
 - List contents not guaranteed to be repeatable
             */
            //bool localOnly = true;
            DataTable table = SmoApplication.EnumAvailableSqlServers();
            return table;
        }


        public List<string> GetDatabases()
        {
            return smoHelper.GetDatabaseNameList();
        }

        public List<string> GetTableNameList(Database db)
        {
            return smoHelper.GetTableNameList(db); 
        }

        public List<string> GetStoredProcedureNameList(Database db)
        {
            return smoHelper.GetStoredProcedureNameList(db); 
        }

        public List<string> GetUserNameList(Database db)
        {
            return smoHelper.GetUserNameList(db); 
        }

        public void BackupDatabase(string databaseName)
        {
             smoHelper.BackupDatabase(databaseName);
        }

        public void RestoreDB(string databaseName)
        {
            smoHelper.RestoreDB(databaseName);
        }











    }

}

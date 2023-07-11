using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;


namespace Infrastructure.Services
{
   public  interface IDBService
    {
        System.Data.DataTable GetNetworkServers();

        List<string> GetDatabases();

        void Connect(string serverAndInstanceName, string userName, string password, bool useWindowsAuthentication);

        List<string> GetTableNameList(Database db);

        List<string> GetStoredProcedureNameList(Database db);

        List<string> GetUserNameList(Database db);

        void BackupDatabase(string databaseName);

        void RestoreDB(string databaseName);






    }
}

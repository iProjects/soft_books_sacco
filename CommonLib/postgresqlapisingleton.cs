/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/28/2018
 * Time: 19:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace CommonLib
{
    /// <summary>
    /// Description of postgresqlapisingleton.
    /// </summary>
    public class postgresqlapisingleton
    {

        // Because the _instance member is made private, the only way to get the single
        // instance is via the static Instance property below. This can also be similarly
        // achieved with a GetInstance() method instead of the property.
        private static postgresqlapisingleton singleInstance;

        public static postgresqlapisingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            // The first call will create the one and only instance.
            if (singleInstance == null)
                singleInstance = new postgresqlapisingleton(notificationmessageEventname);
            // Every call afterwards will return the single instance created above.
            return singleInstance;
        }

        private string CONNECTION_STRING = @"Server=127.0.0.1;Database=tasks_tracking_db;User Id=sa;Password=123456789;Port=5432";
        private string db_name = DBContract.DATABASE_NAME;//"tasks_tracking_db";
        private event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        private string TAG;
        postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();

        private postgresqlapisingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            _notificationmessageEventname = notificationmessageEventname;
            try
            {
                TAG = this.GetType().Name;
                setconnectionstring();
                createdatabase();
                createtables();
                //				updateexistingdbschema();
            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
            }
        }

        private postgresqlapisingleton()
        {

        }
        public responsedto set_up_database_on_load()
        {
            responsedto _responsedto = new responsedto();

            responsedto _database_responsedto = createdatabaseonfirstload();
            responsedto _tables_responsedto = createtablesonfirstload();

            if (!string.IsNullOrEmpty(_database_responsedto.responsesuccessmessage))
            {
                _responsedto.responsesuccessmessage += _database_responsedto.responsesuccessmessage + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(_database_responsedto.responseerrormessage))
            {
                _responsedto.responseerrormessage += _database_responsedto.responseerrormessage + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(_tables_responsedto.responsesuccessmessage))
            {
                _responsedto.responsesuccessmessage += _tables_responsedto.responsesuccessmessage;
            }
            if (!string.IsNullOrEmpty(_tables_responsedto.responseerrormessage))
            {
                _responsedto.responseerrormessage += _tables_responsedto.responseerrormessage;
            }

            return _responsedto;
        }
        private responsedto createdatabaseonfirstload()
        {
            _connectionstringdto = new postgresqlconnectionstringdto();

            _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
            _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
            _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
            _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
            _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

            responsedto _responsedto = create_database_given_name(_connectionstringdto);
            return _responsedto;
        }
        private responsedto createtablesonfirstload()
        {
            _connectionstringdto = new postgresqlconnectionstringdto();

            _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
            _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
            _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
            _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
            _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

            responsedto _responsedto = create_tables(_connectionstringdto);
            return _responsedto;
        }
        public responsedto create_database_given_name(postgresqlconnectionstringdto _connectionstringdto)
        {
            responsedto _responsedto = new responsedto();
            try
            {
                _connectionstringdto.new_database_name = _connectionstringdto.database;
                _connectionstringdto.database = "postgres";

                string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);

                string query = "CREATE DATABASE " + _connectionstringdto.new_database_name + ";";

                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 60;
                        cmd.ExecuteNonQuery();
                        _responsedto.isresponseresultsuccessful = true;
                        _responsedto.responsesuccessmessage = "successfully created database [ " + _connectionstringdto.new_database_name + " ] in " + DBContract.postgresql + ".";
                        this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_responsedto.responsesuccessmessage, TAG));
                        _responsedto.responseresultobject = _connectionstringdto;
                        return _responsedto;
                    }
                }
            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return _responsedto;
            }
        }

        private void setconnectionstring()
        {
            try
            {
                _connectionstringdto = new postgresqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

                CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
            }
        }

        string buildconnectionstringfromobject(postgresqlconnectionstringdto _connectionstringdto)
        {
            string CONNECTION_STRING = @"Server=" + _connectionstringdto.datasource + ";" +
                "Database=" + _connectionstringdto.database + ";" +
                "Port=" + _connectionstringdto.port + ";" +
                "User Id=" + _connectionstringdto.userid + ";" +
                "Password=" + _connectionstringdto.password;
            return CONNECTION_STRING;
        }

        private postgresqlconnectionstringdto get_connection_string_dto()
        {
            try
            {
                _connectionstringdto = new postgresqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.new_database_name = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

                CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);

                return _connectionstringdto;

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return null;
            }
        }

        public responsedto createdatabasegivenname(postgresqlconnectionstringdto _connectionstringdto)
        {
            responsedto _responsedto = new responsedto();
            try
            {
                _connectionstringdto.database = "postgres";

                string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);

                string query = "CREATE DATABASE " + _connectionstringdto.new_database_name + ";";

                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 60;
                        cmd.ExecuteNonQuery();
                        _responsedto.isresponseresultsuccessful = true;
                        _responsedto.responsesuccessmessage = "successfully created database [ " + _connectionstringdto.new_database_name + " ] in " + DBContract.postgresql + ".";
                        _responsedto.responseresultobject = _connectionstringdto;
                        return _responsedto;
                    }
                }
            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                return _responsedto;
            }
        }

        public responsedto createdatabasegivennamefromconsole(string new_database_name)
        {
            responsedto _responsedto = new responsedto();
            try
            {
                _connectionstringdto = getpostgresqlconnectionstringdto();
                _connectionstringdto.database = "postgres";

                string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);

                string query = "CREATE DATABASE " + new_database_name + ";";

                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 60;
                        cmd.ExecuteNonQuery();
                        _responsedto.isresponseresultsuccessful = true;
                        _responsedto.responsesuccessmessage = "successfully created database [ " + new_database_name + " ] in " + DBContract.postgresql + ".";
                        _responsedto.responseresultobject = _connectionstringdto;
                        return _responsedto;
                    }
                }
            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                return _responsedto;
            }
        }

        public bool createdatabase()
        {
            try
            {
                string _default_database_name = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_database", "tasks_tracking_db");
                _connectionstringdto = getpostgresqlconnectionstringdto();
                _connectionstringdto.database = "postgres";

                string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);

                string query = "CREATE DATABASE " + _default_database_name + ";";

                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 60;
                        cmd.ExecuteNonQuery();
                        this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created database [ " + _default_database_name + " ] in " + DBContract.postgresql + ".", TAG));
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return false;
            }
        }

        public void createtables()
        {
            responsedto _responsedto = create_tables(get_connection_string_dto());
            if (_responsedto.isresponseresultsuccessful)
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_responsedto.responsesuccessmessage, TAG));
            else
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_responsedto.responseerrormessage, TAG));
        }

        public responsedto create_tables(postgresqlconnectionstringdto _connectionstringdto)
        {
            responsedto _responsedto = new responsedto();
            responsedto _innerresponsedto = new responsedto();
            try
            {

                _connectionstringdto.database = _connectionstringdto.new_database_name;
                string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);

                bool does_users_table_exist_in_db = checkiftableexists(CONNECTION_STRING, DBContract.users_entity_table.TABLE_NAME);

                if (!does_users_table_exist_in_db)
                {
                    //Create users table 
                    string SQL_CREATE_USERS_TABLE = " CREATE TABLE IF NOT EXISTS " + DBContract.users_entity_table.TABLE_NAME + " (" +
                          DBContract.users_entity_table.ID + " SERIAL PRIMARY KEY NOT NULL, " +
                          DBContract.users_entity_table.EMAIL + " VARCHAR(1000), " +
                          DBContract.users_entity_table.PASSWORD + " VARCHAR(1000), " +
                          DBContract.users_entity_table.PASSWORD_SALT + " VARCHAR(1000), " +
                          DBContract.users_entity_table.PASSWORD_HASH + " VARCHAR(1000), " +
                          DBContract.users_entity_table.FULLNAMES + " VARCHAR(1000), " +
                          DBContract.users_entity_table.YEAR + " VARCHAR(1000), " +
                          DBContract.users_entity_table.MONTH + " VARCHAR(1000), " +
                          DBContract.users_entity_table.DAY + " VARCHAR(1000), " +
                          DBContract.users_entity_table.GENDER + " VARCHAR(1000), " +
                          DBContract.users_entity_table.STATUS + " VARCHAR(1000), " +
                          DBContract.users_entity_table.CREATED_DATE + " VARCHAR(1000) " +
                           " ); ";

                    _innerresponsedto = createtable(SQL_CREATE_USERS_TABLE, CONNECTION_STRING, DBContract.users_entity_table.TABLE_NAME);
                    if (_innerresponsedto.isresponseresultsuccessful)
                        _responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
                    else
                        _responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
                }

                bool does_logs_table_exist_in_db = checkiftableexists(CONNECTION_STRING, DBContract.logs_entity_table.TABLE_NAME);

                if (!does_logs_table_exist_in_db)
                {
                    //Create logs table 
                    string SQL_CREATE_LOGS_TABLE = " CREATE TABLE IF NOT EXISTS " + DBContract.logs_entity_table.TABLE_NAME + " (" +
                          DBContract.logs_entity_table.ID + " SERIAL PRIMARY KEY NOT NULL, " +
                          DBContract.logs_entity_table.MESSAGE + " VARCHAR(1000), " +
                          DBContract.logs_entity_table.TIMESTAMP + " VARCHAR(1000), " +
                          DBContract.logs_entity_table.TAG + " VARCHAR(1000), " +
                          DBContract.logs_entity_table.STATUS + " VARCHAR(1000), " +
                          DBContract.logs_entity_table.CREATED_DATE + " VARCHAR(1000) " +
                           " ); ";

                    _innerresponsedto = createtable(SQL_CREATE_LOGS_TABLE, CONNECTION_STRING, DBContract.logs_entity_table.TABLE_NAME);
                    if (_innerresponsedto.isresponseresultsuccessful)
                        _responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
                    else
                        _responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
                }

                _responsedto.isresponseresultsuccessful = true;

                return _responsedto;

            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage += Environment.NewLine + ex.Message;
                return _responsedto;
            }
        }

        public responsedto createtable(string query, string CONNECTION_STRING, string table_name)
        {
            responsedto _responsedto = new responsedto();
            try
            {
                //setup the connection to the database
                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    //open a new command
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        //execute the query 
                        cmd.CommandTimeout = 90;
                        cmd.ExecuteNonQuery();

                        _responsedto.isresponseresultsuccessful = true;

                        _responsedto.responsesuccessmessage = "successfully created table [ " + table_name + " ] in [ " + DBContract.postgresql + " ].";

                        return _responsedto;
                    }
                }
            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                Exception _exception = ex.GetBaseException();
                //_responsedto.responseerrormessage += Environment.NewLine + "error executing query [ " + query + " ].";
                _responsedto.responseerrormessage += Environment.NewLine + Environment.NewLine + _exception.ToString() + Environment.NewLine;
                return _responsedto;
            }
        }

        bool checkiftableexists(string CONNECTION_STRING, string table_name)
        {
            try
            {
                string query = @"
                    SELECT EXISTS (
                        SELECT FROM pg_tables
                        WHERE schemaname = @schemaName AND tablename = @tableName
                    );";

                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    //open a new command
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        string schemaName = "public";

                        cmd.Parameters.AddWithValue("schemaName", schemaName);
                        cmd.Parameters.AddWithValue("tableName", table_name);

                        //execute the query  
                        int _rows_affected = cmd.ExecuteNonQuery();
                        Console.WriteLine("_rows_affected [ " + _rows_affected + " ]");

                        if (_rows_affected < 0)
                        {
                            return false;
                        }

                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                return false;
            }
        }

        public int insertgeneric(string query, Dictionary<string, object> args, string CONNECTION_STRING)
        {
            int numberOfRowsAffected;
            if (CONNECTION_STRING == null)
            {
                numberOfRowsAffected = insertgeneric(query, args);
                return numberOfRowsAffected;
            }
            else if (String.IsNullOrEmpty(CONNECTION_STRING))
            {
                numberOfRowsAffected = insertgeneric(query, args);
                return numberOfRowsAffected;
            }
            else
            {

                //setup the connection to the database
                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    //open a new command
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        //set the arguments given in the query
                        foreach (var pair in args)
                        {
                            cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                        }
                        //execute the query and get the number of row affected
                        numberOfRowsAffected = cmd.ExecuteNonQuery();
                    }
                    return numberOfRowsAffected;
                }
            }
        }

        public int insertgeneric(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;
            //setup the connection to the database
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                //open a new command
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    //set the arguments given in the query
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    //execute the query and get the number of row affected
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }
                return numberOfRowsAffected;
            }
        }

        public DataTable getallrecordsglobal(string query)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    var da = new NpgsqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
        }

        public DataTable getallrecordsglobal(string query, string CONNECTION_STRING)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    var da = new NpgsqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
        }

        public int updategeneric(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;
            //setup the connection to the database
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                //open a new command
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    //set the arguments given in the query
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    //execute the query and get the number of row affected
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }
                return numberOfRowsAffected;
            }
        }

        public int deletegeneric(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;
            //setup the connection to the database
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                //open a new command
                using (var cmd = new SqlCommand(query, con))
                {
                    //set the arguments given in the query
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    //execute the query and get the number of row affected
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }
                return numberOfRowsAffected;
            }
        }

        private DataTable ExecuteRead(string query, Dictionary<string, object> args)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (var cmd = new SqlCommand(query, con))
                {
                    foreach (KeyValuePair<string, object> entry in args)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
        }

        public bool isdbconnectionalive()
        {
            var con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            return true;
        }

        public bool isdbconnectionalive(string CONNECTION_STRING)
        {
            var con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            return true;
        }

        private void updatedbschema(string query)
        {
            try
            {
                //setup the connection to the database
                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    //open a new command
                    using (var cmd = new NpgsqlCommand(query, con))
                    {
                        //execute the query  
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
            }
        }

        public void updateexistingdbschema()
        {
            try
            {

                //update the tables  
                //string SQL_ALTER_CROPS_TABLE = " ALTER TABLE " + 
                //      DBContract.cropsentitytable.CROPS_TABLE_NAME +
                //      " ALTER COLUMN " + 
                //      DBContract.cropsentitytable.CROP_ID +
                //      " SERIAL PRIMARY KEY NOT NULL "; 
                //updatedbschema(SQL_ALTER_CROPS_TABLE);				

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
            }
        }
        public responsedto checkpostgresqlconnectionstate()
        {
            responsedto _responsedto = new responsedto();
            try
            {
                _connectionstringdto = getpostgresqlconnectionstringdto();

                _responsedto = checkconnectionasadmin(_connectionstringdto);

                return _responsedto;
            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                return _responsedto;
            }
        }
        public responsedto checkconnectionasadmin(postgresqlconnectionstringdto _connectionstringdto)
        {
            responsedto _responsedto = new responsedto();
            try
            {
                string CONNECTION_STRING = @"Server=" + _connectionstringdto.datasource + ";" +
                "Database=" + _connectionstringdto.database + ";" +
                "User Id=" + _connectionstringdto.userid + ";" +
                "Password=" + _connectionstringdto.password + ";" +
                "Port=" + _connectionstringdto.port;

                string query = DBContract.logs_entity_table.SELECT_ALL_QUERY;

                int count = getrecordscountgiventable(DBContract.logs_entity_table.TABLE_NAME, CONNECTION_STRING);

                if (count != -1)
                {
                    _responsedto.isresponseresultsuccessful = true;
                    _responsedto.responsesuccessmessage = "connection to postgresql successfull. properties count [ " + count + " ].";
                    return _responsedto;
                }
                else
                {
                    _responsedto.isresponseresultsuccessful = false;
                    _responsedto.responseerrormessage = "connection to postgresql failed.";
                    return _responsedto;
                }
            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                return _responsedto;
            }
        }

        public int getrecordscountgiventable(string tablename, string CONNECTION_STRING)
        {
            string query = "SELECT * FROM " + tablename;
            DataTable dt = getallrecordsglobal(query, CONNECTION_STRING);
            if (dt != null)
                return dt.Rows.Count;
            else
                return -1;
        }

        public postgresqlconnectionstringdto getpostgresqlconnectionstringdto()
        {
            try
            {
                _connectionstringdto = new postgresqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

                return _connectionstringdto;

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return null;
            }
        }

        public List<string> get_postgresql_databases()
        {
            List<string> server_databases = new List<string>();
            try
            {

                string CONNECTION_STRING = getpostgresqlconnectionstring();

                string query = "SELECT * FROM pg_catalog.pg_database";

                DataTable dt = getpostgresqldatabasesfromschema(query, CONNECTION_STRING);

                var _recordscount = dt.Rows.Count;

                for (int i = 0; i < _recordscount; i++)
                {
                    //table_name, table_catalog, table_schema
                    server_databases.Add(Convert.ToString(dt.Rows[i]["datname"]));

                }

                return server_databases;
            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return server_databases;
            }
        }

        public bool check_if_postgresql_database_exists(string database_name)
        {
            bool _exists = false;
            try
            {
                List<string> server_databases = get_postgresql_databases();
                var _recordscount = server_databases.Count;

                for (int i = 0; i < _recordscount; i++)
                {

                    var _record_from_server = server_databases[i];

                    if (database_name == _record_from_server)
                    {
                        _exists = true;
                        return _exists;
                    }
                }

                return _exists;
            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return _exists;
            }
        }

        public string getpostgresqlconnectionstring()
        {
            try
            {
                _connectionstringdto = new postgresqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

                string CONNECTION_STRING = buildpostgresqlconnectionstringfromobject(_connectionstringdto);

                return CONNECTION_STRING;

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return null;
            }
        }

        string buildpostgresqlconnectionstringfromobject(postgresqlconnectionstringdto _connectionstringdto)
        {
            string CONNECTION_STRING = @"Server=" + _connectionstringdto.datasource + ";" +
                "Database=" + _connectionstringdto.database + ";" +
                "Port=" + _connectionstringdto.port + ";" +
                "User Id=" + _connectionstringdto.userid + ";" +
                "Password=" + _connectionstringdto.password;
            return CONNECTION_STRING;
        }

        public DataTable getpostgresqldatabasesfromschema(string query, string CONNECTION_STRING)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    var da = new NpgsqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
        }

        public DataTable execute_select_query(string query, string CONNECTION_STRING)
        {
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    var da = new NpgsqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
        }

        public int execute_data_manipulation_query(string query, string CONNECTION_STRING)
        {
            int numberOfRowsAffected;
            //setup the connection to the database
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                //open a new command
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    //execute the query and get the number of row affected
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }
                return numberOfRowsAffected;
            }
        }

        public responsedto truncate_database()
        {
            responsedto _responsedto = new responsedto();
            try
            {
                //setup the connection to the database
                using (var con = new NpgsqlConnection(CONNECTION_STRING))
                {
                    con.Open();

                    foreach (var table in DBContract.table_names_arr)
                    {
                        string query = "TRUNCATE TABLE " + table + ";";

                        //open a new command
                        using (var cmd = new NpgsqlCommand(query, con))
                        {
                            //execute the query  
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                _responsedto.isresponseresultsuccessful = true;
                _responsedto.responsesuccessmessage = "Tables successfully truncated in " + DBContract.postgresql;

                return _responsedto;
            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                return _responsedto;
            }
        }

        #region "logs"
        public responsedto create_log_in_database(log_dto _dto)
        {
            responsedto _responsedto = new responsedto();
            try
            {
                string query = "INSERT INTO " +
                DBContract.logs_entity_table.TABLE_NAME +
                " ( " +
                DBContract.logs_entity_table.MESSAGE + ", " +
                DBContract.logs_entity_table.TIMESTAMP + ", " +
                DBContract.logs_entity_table.TAG + ", " +
                DBContract.logs_entity_table.STATUS + ", " +
                DBContract.logs_entity_table.CREATED_DATE +
                " ) VALUES(@message, @timestamp, @tag, @status, @created_date)";

                //here we are setting the parameter values that will be actually replaced in the query in Execute method
                var args = new Dictionary<string, object>
			    {
				    {"@message", _dto.message},
				    {"@timestamp", _dto.timestamp},
                    {"@tag", _dto.tag},  
                    {"@status", "active"},
				    {"@created_date", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt")}
			    };

                int numberOfRowsAffected = insertgeneric(query, args, CONNECTION_STRING);
                if (numberOfRowsAffected != 1)
                {
                    _responsedto.isresponseresultsuccessful = false;
                    //_responsedto.responseerrormessage = "Record creation failed in " + DBContract.mysql + ".";
                    _responsedto.responseerrormessage = "Record creation failed.";
                    this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_responsedto.responseerrormessage, TAG));
                    return _responsedto;
                }
                else
                {
                    _responsedto.isresponseresultsuccessful = true;
                    //_responsedto.responsesuccessmessage = "Record created successfully in " + DBContract.mysql + ".";
                    _responsedto.responsesuccessmessage = "Record created successfully.";
                    this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_responsedto.responsesuccessmessage, TAG));
                    return _responsedto;
                }

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                return _responsedto;
            }
        }
        #endregion "logs"










    }
}

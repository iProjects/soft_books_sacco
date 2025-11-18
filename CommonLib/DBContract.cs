using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLib
{
    public static class DBContract
    {
        public static String DATABASE_NAME = "july";
        public static String SQLITE_DATABASE_NAME = "july.sqlite3";

        public static String error = "error";
        public static String info = "info";
        public static String warn = "warn";

        public static String mssql = "mssql";
        public static String mysql = "mysql";
        public static String sqlite = "sqlite";
        public static String postgresql = "postgresql";
        public static String mongodb = "mongodb";

        public static DialogResult dialogresult = DialogResult.OK;


        //weights table
        public static class error_entity_table
        {
            public static String TABLE_NAME = "tblweights";
            //Columns of the table
            public static String WEIGHT_ID = "weight_id";
            public static String WEIGHT_WEIGHT = "weight_weight";
            public static String WEIGHT_DATE = "weight_date";
            public static String WEIGHT_STATUS = "weight_status";
            public static String CREATED_DATE = "created_date";
            public static String WEIGHT_APP = "weight_app";

        public static String SELECT_ALL_QUERY = "SELECT * FROM " +
                                    DBContract.error_entity_table.TABLE_NAME;

        public static String SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
                            DBContract.error_entity_table.TABLE_NAME +
                            " where " +
                            DBContract.error_entity_table.WEIGHT_STATUS +
                            " = " +
                            "'active'";

        }

        //users table
        public static class users_entity_table
        {
            public static String TABLE_NAME = "tbl_users";
            //Columns of the table
            public static String ID = "id";
            public static String EMAIL = "email";
            public static String PASSWORD = "password";
            public static String FULLNAMES = "fullnames";
            public static String DOB = "dob";
            public static String YEAR = "year";
            public static String MONTH = "month";
            public static String DAY = "day";
            public static String PASSWORD_SALT = "password_salt";
            public static String PASSWORD_HASH = "password_hash";
            public static String GENDER = "gender";
            public static String STATUS = "status";
            public static String CREATED_DATE = "created_date";

            //query
            public static String SELECT_ALL_QUERY = "SELECT * FROM " +
                                        DBContract.users_entity_table.TABLE_NAME;

            public static String SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
                                DBContract.users_entity_table.TABLE_NAME +
                                " where " +
                                DBContract.users_entity_table.STATUS +
                                " = " +
                                "'active'";

        }

        //logs table
        public static class logs_entity_table
        {
            public static String TABLE_NAME = "tbl_logs";
            //Columns of the table
            public static String ID = "id";
            public static String MESSAGE = "message";
            public static String TIMESTAMP = "timestamp";
            public static String TAG = "tag";
            public static String STATUS = "status";
            public static String CREATED_DATE = "created_date";

            //users query
            public static String SELECT_ALL_QUERY = "SELECT * FROM " +
                                        DBContract.logs_entity_table.TABLE_NAME;

            public static String SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
                                DBContract.logs_entity_table.TABLE_NAME +
                                " where " +
                                DBContract.logs_entity_table.STATUS +
                                " = " +
                                "'active'";

        }

        public static string[] table_names_arr = {
		"tbl_tasks",
        "tbl_logs"
	};

        public static string[] _entities = {
			"mssql", 
			"mysql",
			"postgresql", 
			"sqlite",
            "mongodb"
		};




    }
}

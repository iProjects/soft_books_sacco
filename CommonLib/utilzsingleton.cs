using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace CommonLib
{
    /// <summary>
    /// Description of utilzsingleton.
    /// </summary>
    public sealed class utilzsingleton
    {
        // Because the _instance member is made private, the only way to get the single
        // instance is via the static Instance property below. This can also be similarly
        // achieved with a GetInstance() method instead of the property. 
        private static utilzsingleton singleInstance;

        public static utilzsingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            // The first call will create the one and only instance.
            if (singleInstance == null)
                singleInstance = new utilzsingleton(notificationmessageEventname);
            // Every call afterwards will return the single instance created above.
            return singleInstance;
        }

        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        public string TAG;

        private utilzsingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            TAG = this.GetType().Name;
            _notificationmessageEventname = notificationmessageEventname;
        }

        private utilzsingleton()
        {

        }


        public string getappsettinggivenkey(string key = "", string defaultvalue = "")
        {
            try
            {

                string configvalue = "";

                configvalue = System.Configuration.ConfigurationManager.AppSettings[key];

                if (configvalue == null || String.IsNullOrEmpty(configvalue))
                {
                    return defaultvalue;
                }
                else
                {
                    return configvalue;
                }

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, this.TAG));
                return defaultvalue;
            }
        }

        public error_logger_dto build_error_dto_given_datatable(DataTable dt, int _index)
        {
            error_logger_dto _error_logger_dto = new error_logger_dto();
            _error_logger_dto.error_id = Convert.ToString(dt.Rows[_index][DBContract.error_entity_table.WEIGHT_ID]);
            _error_logger_dto.error_description = Convert.ToString(dt.Rows[_index][DBContract.error_entity_table.WEIGHT_WEIGHT]);
            _error_logger_dto.error_date = Convert.ToString(dt.Rows[_index][DBContract.error_entity_table.WEIGHT_DATE]);
            _error_logger_dto.error_category = Convert.ToString(dt.Rows[_index][DBContract.error_entity_table.WEIGHT_STATUS]);
            _error_logger_dto.created_date = Convert.ToString(dt.Rows[_index][DBContract.error_entity_table.CREATED_DATE]);
            _error_logger_dto.error_source = Convert.ToString(dt.Rows[_index][DBContract.error_entity_table.WEIGHT_APP]);

            return _error_logger_dto;
        }
        public DataTable Convert_List_To_Datatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public List<T> Convert_DataTable_To_list<T>(DataTable dt)
        {
            if (dt == null) return null;
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item;
                try
                {
                    item = GetItem<T>(row);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    continue;
                }
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (dr[column.ColumnName] == null || dr[column.ColumnName] == DBNull.Value)
                    {
                        continue;
                    }

                    if (pro == null)
                    {
                        continue;
                    }
                    if (obj == null)
                    {
                        continue;
                    }

                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }




    }
}

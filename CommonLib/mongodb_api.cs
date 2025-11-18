/*
 * Created by: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 01/23/2020
 * Time: 02:55
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms; 

namespace CommonLib
{
    public sealed class mongodb_api
    {
        // Because the _instance member is made private, the only way to get the single
        // instance is via the static Instance property below. This can also be similarly
        // achieved with a GetInstance() method instead of the property.
        private static mongodb_api singleInstance;
        public static mongodb_api getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            // The first call will create the one and only instance.
            if (singleInstance == null)
                singleInstance = new mongodb_api(notificationmessageEventname);
            // Every call afterwards will return the single instance created above.
            return singleInstance;
        }
        public string TAG;

        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        public mongodb_api(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {

            TAG = this.GetType().Name;

            _notificationmessageEventname = notificationmessageEventname;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized mongodb_api...", TAG));
        }
         






    }
}

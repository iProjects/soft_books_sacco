using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;


namespace DatabaseAdministrationModule.Views
{
    public partial class RunSQLForm : Form
    {

        #region "Private Fields" 
        int _user;
        private IDBService databaseservice;
        private SqlServerListModel servermodel;
        ObservableCollection<string> srvdbs;
        public ObservableCollection<SqlServerListModel> serverlist;
        public ObservableCollection<SqlServerListModel> databaselist;
        public ObservableCollection<SqlServerListModel> tablelist;
        public ObservableCollection<SqlServerListModel> userlist;
        public ObservableCollection<SqlServerListModel> procedurelist;
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public RunSQLForm(int user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (user == null)
                throw new ArgumentNullException("User");
            _user = user;

            serverlist = new ObservableCollection<SqlServerListModel>();
            databaselist = new ObservableCollection<SqlServerListModel>();
            tablelist = new ObservableCollection<SqlServerListModel>();
            userlist = new ObservableCollection<SqlServerListModel>();
            procedurelist = new ObservableCollection<SqlServerListModel>();
            servermodel = new SqlServerListModel();
        }
        #endregion "Constructor"
         
        #region "Private Methods"
        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSQLQueryEditor.Text)) ;
                {
                    string query = txtSQLQueryEditor.Text.Trim();
                    //db.ExecuteStoreCommand(query);
                    var result = db.ExecuteStoreCommand(query);
                    txtSQLQueryStatus.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void RunSQLForm_Load(object sender, EventArgs e)
        {

        }
        #endregion "Private Methods"



    }
}
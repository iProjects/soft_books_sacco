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
    public partial class DatabaseMaintenanceForm : Form
    {

        #region "Private Fields" 
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int _user;
        private IDBService databaseservice;
        private SqlServerListModel servermodel;
        ObservableCollection<string> srvdbs;
        public ObservableCollection<SqlServerListModel> serverlist;
        public ObservableCollection<SqlServerListModel> databaselist;
        public ObservableCollection<SqlServerListModel> tablelist;
        public ObservableCollection<SqlServerListModel> userlist;
        public ObservableCollection<SqlServerListModel> procedurelist;
        #endregion "Private Fields"

        #region "Constructor"
        public DatabaseMaintenanceForm(int user, string Conn)
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
        private void btnRebuildLoanCycle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnShrinkDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnAddAllMissingCashFlows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnRebuildConsolidations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnRunSQL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RunSQLForm rsf = new RunSQLForm(_user,connection) { Owner=this };
            rsf.ShowDialog();
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        #endregion "Private Methods"

    }
}
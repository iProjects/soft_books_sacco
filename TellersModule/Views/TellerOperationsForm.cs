using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using Infrastructure.Models;

namespace TellersModule.Views
{
    public partial class TellerOperationsForm : Form
    {
        #region "Private Fields"
        SBSaccoDBEntities db;
        Repository rep;
        string connection;
        int _userid;
        #endregion "Private Fields"

         #region "Constructor"
        public TellerOperationsForm(int userid, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
             
            _userid = userid;
        }
        #endregion "Constructor"

        private void TellerOperationsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _tellersquery = from br in rep.GetNonDeletedTellers()
                                  select br;
                List<TellerModel> _Tellers = _tellersquery.ToList();
                cboTeller.DataSource = _Tellers;
                cboTeller.ValueMember = "tellerid";
                cboTeller.DisplayMember = "_DisplayName";
                cboTeller.SelectedIndex = -1;

                var _entrybranchesquery = from br in rep.GetNonDeletedBranches()
                                          select br;
                List<BranchModel> _EntryBranches = _entrybranchesquery.ToList();
                cboBranch.DataSource = _EntryBranches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                cboBranch.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             errorProvider1.Clear();
             if (IsTellerOperationValid())
             {
                 try 
                 { 
                 }
                 catch (Exception ex)
                 {
                     Utils.ShowError(ex);
                 }
             }
        }
        #region "Validation"
        private bool IsTellerOperationValid()
        {
            bool noerror = true;
            
            return noerror;
        }
        #endregion "Validation"

         




    }
}

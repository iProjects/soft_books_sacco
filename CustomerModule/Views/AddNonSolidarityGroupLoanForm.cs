using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Globalization;
using SearchModule.Views;
using System.Diagnostics;

namespace CustomerModule.Views
{
    public partial class AddNonSolidarityGroupLoanForm : Form
    {
         #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public AddNonSolidarityGroupLoanForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
             
        }
        #endregion "Constructor"

        #region "Private Methods" 
        private void btnConfirmLoanCreation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
               

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
         
        private void AddNonSolidarityGroupLoanForm_Load(object sender, EventArgs e)
        {
            try
            { 
                listViewNonSolidarityGroupLoan.View = View.Details;
                listViewNonSolidarityGroupLoan.GridLines = true;
                listViewNonSolidarityGroupLoan.FullRowSelect = true;
                listViewNonSolidarityGroupLoan.MultiSelect = false;
                listViewNonSolidarityGroupLoan.Columns.Add("", "Name", 200);
                listViewNonSolidarityGroupLoan.Columns.Add("", "File", 100);
                listViewNonSolidarityGroupLoan.Columns.Add("", "User", 100);
                listViewNonSolidarityGroupLoan.Columns.Add("", "Comment", 100);
                listViewNonSolidarityGroupLoan.Columns.Add("", "Date", 100);
                listViewNonSolidarityGroupLoan.Columns.Add("", "Size", -2); 
                 
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
            }
        }
        
        #endregion "Private Methods"

       
    }
}

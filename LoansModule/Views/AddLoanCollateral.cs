using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace LoansModule.Views
{
    public partial class AddLoanCollateral : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        //gl_Guarantee guarantee;
        #endregion "Private Fields"

        #region "Constructor"
        public AddLoanCollateral(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            //guarantee = _guarantee;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void AddLoanCollateral_Load(object sender, EventArgs e)
        {

        }



        #endregion "Private Methods"

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

      

        


    }
}

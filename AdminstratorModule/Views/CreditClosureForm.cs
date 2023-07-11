using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class CreditClosureForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        //gl_Corporate corporate;
        #endregion "Private Fields"

        #region "Constructor"
        public CreditClosureForm(int _user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
            
            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void CreditClosureForm_Load(object sender, EventArgs e)
        {

        }
        #endregion "Private Methods"

        
        private void btnClose_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void lblStatus_DoubleClick(object sender, EventArgs e)
        {
            AccountingJournalsForm ajf = new AccountingJournalsForm(connection);
            ajf.ShowDialog();
        }
    }
}

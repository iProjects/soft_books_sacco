using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class ReassignContractsForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public ReassignContractsForm(int _user, string Conn)
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void ReassignContractsForm_Load(object sender, EventArgs e)
        {
            try
            {
                IList<UserModel_dto> loanoficers = rep.GetUsersModelwithRolesList();
                cboUsersFrom.DataSource = loanoficers;
                cboUsersFrom.DisplayMember = "full_name";
                cboUsersFrom.ValueMember = "userid";
                cboUsersFrom.SelectedIndex = -1;

                IList<UserModel_dto> savingsofficers = rep.GetUsersModelwithRolesList();
                cboUsersTo.DataSource = savingsofficers;
                cboUsersTo.DisplayMember = "full_name";
                cboUsersTo.ValueMember = "userid";
                cboUsersTo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAssign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboUsersFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }  
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {

        } 
        private void chkActiveOnly_CheckedChanged(object sender, EventArgs e)
        {

        }
#endregion "Private Methods"




    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;


namespace AdminstratorModule.Views
{
    public partial class AddAccountForm : Form
    {
       
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;  
        #endregion "Private Fields"

        #region "Constructor"
        public AddAccountForm(int item, string Conn)
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        } 
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AddAccountForm_Load(object sender, EventArgs e)
        {

        }
        #endregion "Private Methods"
    }
}

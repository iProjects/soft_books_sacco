using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace AdminstratorModule.Views
{
    public partial class AccountingJournalsForm : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        public AccountingJournalsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }

        private void AccountingJournalsForm_Load(object sender, EventArgs e)
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
        private void btnViewBalance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnRun_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
}

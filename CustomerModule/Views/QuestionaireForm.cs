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

namespace CustomerModule.Views
{
    public partial class QuestionaireForm : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        public QuestionaireForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }
         
        private void QuestionaireForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSendSurvey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnNeverAskMeAgain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }







    }
}

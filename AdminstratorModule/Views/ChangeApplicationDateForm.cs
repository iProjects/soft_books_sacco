using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class ChangeApplicationDateForm : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        public ChangeApplicationDateForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }

        private void mcApplicationDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                int day = mcApplicationDate.SelectionStart.Day;
                int year = mcApplicationDate.SelectionStart.Year;
                int month = mcApplicationDate.SelectionStart.Month;
                lblSelectedDate.Text = day + "/" + month + "/" + year;
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
        private void ChangeApplicationDateForm_Load(object sender, EventArgs e)
        {
            try
            {
                int day = mcApplicationDate.SelectionStart.Day;
                int year = mcApplicationDate.SelectionStart.Year;
                int month = mcApplicationDate.SelectionStart.Month;
                lblSelectedDate.Text = day + "/" + month + "/" + year;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }



    }
}
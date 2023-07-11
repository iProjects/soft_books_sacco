using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class EditEconomicActivityForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        ActivityModel _EconomicActivity; 
        #endregion "Private Fields"

        public EditEconomicActivityForm(ActivityModel _economicActivity, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (_economicActivity == null)
                throw new ArgumentNullException("ActivityModel");
            _EconomicActivity = _economicActivity;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_EconomicActivity != null)
                {
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _EconomicActivity.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    }

                    rep.UpdateEconomicActivity(_EconomicActivity);

                    EconomicActivityForm f = (EconomicActivityForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void EditEconomicActivityForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_EconomicActivity.name != null)
                {
                    txtDescription.Text = _EconomicActivity.name;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }






    }
}
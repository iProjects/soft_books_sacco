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
    public partial class AddPublicHolidaysForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddPublicHolidaysForm(string Conn)
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void btnAdd_Click(object sender, EventArgs e)
        {
             errorProvider1.Clear();
             if (IsPublicHolidayValid())
             {
                 try
                 {
                     PublicHolidayModel _publicholiday = new PublicHolidayModel();
                     _publicholiday.date = dtpDate.Value;
                     _publicholiday.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                     if (rep.GetAllPublicHolidays().Any(i => i.date == _publicholiday.date &&   i.name == _publicholiday.name))
                     {
                         MessageBox.Show("Date with Same Description Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     if (!rep.GetAllPublicHolidays().Any(i => i.date == _publicholiday.date && i.name == _publicholiday.name))
                     {
                         rep.AddNewPublicHoliday(_publicholiday);

                         GeneralSettingsForm f = (GeneralSettingsForm)this.Owner;
                         f.RefreshGrid();
                         this.Close();
                     } 
                 }
                 catch (Exception ex)
                 {

                     Utils.ShowError(ex);
                 }
             }
        }
        public bool IsPublicHolidayValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            return noerror;
        }
        #endregion "Private Methods"


    }
}

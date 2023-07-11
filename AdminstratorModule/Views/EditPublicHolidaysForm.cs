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
    public partial class EditPublicHolidaysForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        PublicHolidayModel _publicholiday;
        #endregion "Private Fields"

        #region "Constructor"
        public EditPublicHolidaysForm(PublicHolidayModel publicholiday, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _publicholiday = publicholiday;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsPublicHolidayValid())
            {
                try
                {
                    _publicholiday.date = dtpDate.Value;
                    _publicholiday.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                    rep.UpdatePublicHoliday(_publicholiday);

                    GeneralSettingsForm f = (GeneralSettingsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
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
        private void EditPublicHolidaysForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls(); 
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {
            try
            {
                if (_publicholiday.date != null)
                {
                    dtpDate.Value = _publicholiday.date;
                }
                if (_publicholiday.name != null)
                {
                    txtDescription.Text = _publicholiday.name;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion "Private Methods"



    }
}
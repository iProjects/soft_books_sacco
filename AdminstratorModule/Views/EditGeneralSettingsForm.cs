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
    public partial class EditGeneralSettingsForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        GeneralParametersModel _generalparameters;
        #endregion "Private Fields"

        #region "Constructor"
        public EditGeneralSettingsForm(GeneralParametersModel generalparameters, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _generalparameters = generalparameters;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsGeneralSettingValid())
            {
                try
                {
                    _generalparameters.key =  txtKey.Text ;
                    _generalparameters.value = txtValue.Text ;

                    rep.UpdateGeneralParameter(_generalparameters);

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
        public bool IsGeneralSettingValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtValue.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtValue, "Value cannot be null!");
                return false;
            }
            return noerror;
        }
        private void EditGeneralSettingsForm_Load(object sender, EventArgs e)
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
                if (_generalparameters.key != null)
                {
                    txtKey.Text = _generalparameters.key;
                }
                if (_generalparameters.value != null)
                {
                    txtValue.Text = _generalparameters.value;
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
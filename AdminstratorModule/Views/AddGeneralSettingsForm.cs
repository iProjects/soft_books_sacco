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
    public partial class AddGeneralSettingsForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddGeneralSettingsForm(string Conn)
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
             if (IsGeneralSettingValid())
             {
                 try
                 {
                     GeneralParametersModel _generalparameter = new GeneralParametersModel();
                     _generalparameter.key = txtKey.Text;
                     _generalparameter.value = txtValue.Text;

                     if (  rep.GetAllGeneralParameters().Any(i => i.key == _generalparameter.key))
                     {
                         MessageBox.Show("Parameter with Key Exist!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     if (!rep.GetAllGeneralParameters().Any(i => i.key == _generalparameter.key))
                     {
                         rep.AddNewGeneralParameter(_generalparameter);

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
        public bool IsGeneralSettingValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtKey, "Key cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtValue.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtValue, "Value cannot be null!");
                return false;
            }
            return noerror;
        }
        #endregion "Private Methods"


    }
}

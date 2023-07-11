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
    public partial class ManageFinancialPeriodsForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        string _setup;
        FiscalYearModel _fpModel;
        #endregion "Private Fields"

        #region "Constructor"
        public ManageFinancialPeriodsForm(string setup,string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _setup = setup;
        }
        public ManageFinancialPeriodsForm(FiscalYearModel fpModel,string setup, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _setup = setup;

            _fpModel = fpModel;

            InitializeControls();
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void ManageFinancialPeriodsForm_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            } 
        }  
        private bool IsFinancialPeriodValid()
        {
            bool noerror = true;
            switch (_setup)
            {
                case "create":
                    if (txtName.Enabled == true && string.IsNullOrEmpty(txtName.Text))
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(txtName, "Name cannot be null!");
                        return false;
                    }
                    break;
                case "open":
                    break;

                case "close":
                    break;
            } 
            return noerror;
        } 
        private void btnOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsFinancialPeriodValid())
            {
                try
                {
                    switch (_setup)
                    {
                        case "create":
                            FiscalYearModel fpm = new FiscalYearModel();
                            if (txtName.Enabled == true && !string.IsNullOrEmpty(txtName.Text))
                            {
                                fpm.name = txtName.Text;
                                fpm.open_date = null;
                                fpm.close_date = null;

                                rep.AddNewFiscalYear(fpm);

                                FinancialPeriodsForm f = (FinancialPeriodsForm)this.Owner;
                                f.RefreshGrid();
                                this.Close(); 
                            }
                            break;
                        case "open":
                            if (dtpOpenDate.Enabled == true)
                            {
                                _fpModel.open_date = dtpOpenDate.Value;
                                rep.OpenFiscalYear(_fpModel);

                                FinancialPeriodsForm f = (FinancialPeriodsForm)this.Owner;
                                f.RefreshGrid();
                                this.Close(); 
                            }
                            break; 
                        case "close":
                            if (dtpCloseDate.Enabled == true)
                            {
                                _fpModel.close_date = dtpCloseDate.Value;
                                rep.CloseFiscalYear(_fpModel);

                                FinancialPeriodsForm f = (FinancialPeriodsForm)this.Owner;
                                f.RefreshGrid();
                                this.Close(); 
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void CreatePeriod()
        {
            try
            {
                txtName.Enabled = true; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void OpenPeriod()
        {
            try
            {
                dtpOpenDate.Enabled = true; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void ClosePeriod()
        {
            try
            {
                dtpCloseDate.Enabled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableControls()
        {
            try
            {
                txtName.Enabled = false;
                dtpOpenDate.Enabled = false;
                dtpCloseDate.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void InitializeControls()
        {
            try
            {
                if (_fpModel.name != null)
                {
                    txtName.Text = _fpModel.name.Trim();
                }
                if (_fpModel.open_date != null)
                {
                    dtpOpenDate.Value = _fpModel.open_date.Value;
                }
                if (_fpModel.close_date != null)
                {
                    dtpCloseDate.Value = _fpModel.close_date.Value;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"

    }
}

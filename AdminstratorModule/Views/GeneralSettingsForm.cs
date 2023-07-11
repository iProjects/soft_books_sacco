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
    public partial class GeneralSettingsForm : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        public GeneralSettingsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void GeneralSettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _generalParameteresquery = from gp in rep.GetAllGeneralParameters()
                                               select gp;
                List<GeneralParametersModel> _generalParamemeters = _generalParameteresquery.ToList();
                dataGridViewGeneralSettings.AutoGenerateColumns = false;
                this.dataGridViewGeneralSettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceGeneralSettings.DataSource = _generalParamemeters;
                dataGridViewGeneralSettings.DataSource = bindingSourceGeneralSettings;
                groupBox3.Text = bindingSourceGeneralSettings.Count.ToString();


                var _provisioningrulesquery = from gp in rep.GetAllProvisioningRules()
                                              select gp;
                List<ProvisioningRuleModel> _provisioningrules = _provisioningrulesquery.ToList();
                dataGridViewgProvisioningRules.AutoGenerateColumns = false;
                this.dataGridViewgProvisioningRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceProvisioningRules.DataSource = _provisioningrules;
                dataGridViewgProvisioningRules.DataSource = bindingSourceProvisioningRules;
                groupBox5.Text = bindingSourceProvisioningRules.Count.ToString();


                var _publicholidaysquery = from gp in rep.GetAllPublicHolidays()
                                           select gp;
                List<PublicHolidayModel> _publicholidays = _publicholidaysquery.ToList();
                dataGridViewHoliday.AutoGenerateColumns = false;
                this.dataGridViewHoliday.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceHolidays.DataSource = _publicholidays;
                dataGridViewHoliday.DataSource = bindingSourceHolidays;
                groupBox7.Text = bindingSourceHolidays.Count.ToString();


                var _loanscalesquery = from gp in rep.GetAllLoanScales()
                                       select gp;
                List<LoanScaleModel> _loanscales = _loanscalesquery.ToList();
                dataGridViewLoanScale.AutoGenerateColumns = false;
                this.dataGridViewLoanScale.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceLoanScales.DataSource = _loanscales;
                dataGridViewLoanScale.DataSource = bindingSourceLoanScales;
                groupBox9.Text = bindingSourceLoanScales.Count.ToString();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddGeneralSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddGeneralSettingsForm aflf = new AddGeneralSettingsForm(connection) { Owner = this };
                aflf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddProvisioningRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddProvisioningRulesForm aflf = new AddProvisioningRulesForm(connection) { Owner = this };
                aflf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddHoliday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddPublicHolidaysForm aflf = new AddPublicHolidaysForm(connection) { Owner = this };
                aflf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnAddLoanScale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddLoanScalesForm aflf = new AddLoanScalesForm(connection) { Owner = this };
                aflf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEditGeneralSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewGeneralSettings.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.GeneralParametersModel generalparameter = (DAL.GeneralParametersModel)bindingSourceGeneralSettings.Current;
                    EditGeneralSettingsForm epf = new EditGeneralSettingsForm(generalparameter, connection) { Owner = this };
                    epf.Text = generalparameter.key.ToUpper().Trim();
                    epf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnEditProvisioningRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewgProvisioningRules.SelectedRows.Count != 0)
                {
                    try
                    {
                        DAL.ProvisioningRuleModel provisioningrule = (DAL.ProvisioningRuleModel)bindingSourceProvisioningRules.Current;
                        EditProvisioningRulesForm epf = new EditProvisioningRulesForm(provisioningrule, connection) { Owner = this };
                        epf.Text = "Edit Provisioning Rule";
                        epf.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnEditPublicHoliday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewHoliday.SelectedRows.Count != 0)
                {
                    try
                    {
                        DAL.PublicHolidayModel publicholiday = (DAL.PublicHolidayModel)bindingSourceHolidays.Current;
                        EditPublicHolidaysForm epf = new EditPublicHolidaysForm(publicholiday, connection) { Owner = this };
                        epf.Text = publicholiday.name.ToUpper().Trim();
                        epf.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEditLoanScale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewLoanScale.SelectedRows.Count != 0)
                {
                    try
                    {
                        DAL.LoanScaleModel loanscale = (DAL.LoanScaleModel)bindingSourceLoanScales.Current;
                        EditLoanScalesForm epf = new EditLoanScalesForm(loanscale, connection) { Owner = this };
                        epf.Text = "Edit Loan Scale";
                        epf.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteGeneralSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewGeneralSettings.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.GeneralParametersModel generalparameters = (DAL.GeneralParametersModel)bindingSourceGeneralSettings.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete General Parameter\n" + generalparameters.key.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteGeneralParameter(generalparameters);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDeleteProvisioningRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewgProvisioningRules.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.ProvisioningRuleModel provisioningrulemodel = (DAL.ProvisioningRuleModel)bindingSourceProvisioningRules.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Provisioning Rule", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteProvisioningRule(provisioningrulemodel);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDeleteHoliday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewHoliday.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.PublicHolidayModel publicholiday = (DAL.PublicHolidayModel)bindingSourceHolidays.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Public Holiday\n" + publicholiday.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeletePublicHoliday(publicholiday);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDeleteLoanScale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewLoanScale.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.LoanScaleModel loanscale = (DAL.LoanScaleModel)bindingSourceLoanScales.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Loan Scale", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteLoanScale(loanscale);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        public void RefreshGrid()
        {
            try
            {
                bindingSourceGeneralSettings.DataSource = null;
                var _generalParameteresquery = from gp in rep.GetAllGeneralParameters()
                                               select gp;
                List<GeneralParametersModel> _generalParamemeters = _generalParameteresquery.ToList();
                bindingSourceGeneralSettings.DataSource = _generalParamemeters;
                groupBox3.Text = bindingSourceGeneralSettings.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewGeneralSettings.Rows)
                {
                    dataGridViewGeneralSettings.Rows[dataGridViewGeneralSettings.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewGeneralSettings.Rows.Count - 1;
                    bindingSourceGeneralSettings.Position = nRowIndex;
                }


                bindingSourceProvisioningRules.DataSource = null;
                var _provisioningrulesquery = from gp in rep.GetAllProvisioningRules()
                                              select gp;
                List<ProvisioningRuleModel> _provisioningrules = _provisioningrulesquery.ToList();
                bindingSourceProvisioningRules.DataSource = _provisioningrules;
                groupBox5.Text = bindingSourceProvisioningRules.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewgProvisioningRules.Rows)
                {
                    dataGridViewgProvisioningRules.Rows[dataGridViewgProvisioningRules.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewgProvisioningRules.Rows.Count - 1;
                    bindingSourceProvisioningRules.Position = nRowIndex;
                }


                bindingSourceHolidays.DataSource = null;
                var _publicholidaysquery = from gp in rep.GetAllPublicHolidays()
                                           select gp;
                List<PublicHolidayModel> _publicholidays = _publicholidaysquery.ToList();
                bindingSourceHolidays.DataSource = _publicholidays;
                groupBox7.Text = bindingSourceHolidays.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewHoliday.Rows)
                {
                    dataGridViewHoliday.Rows[dataGridViewHoliday.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewHoliday.Rows.Count - 1;
                    bindingSourceHolidays.Position = nRowIndex;
                }


                bindingSourceLoanScales.DataSource = null;
                var _loanscalesquery = from gp in rep.GetAllLoanScales()
                                       select gp;
                List<LoanScaleModel> _loanscales = _loanscalesquery.ToList();
                bindingSourceLoanScales.DataSource = _loanscales;
                groupBox9.Text = bindingSourceLoanScales.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewLoanScale.Rows)
                {
                    dataGridViewLoanScale.Rows[dataGridViewLoanScale.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewLoanScale.Rows.Count - 1;
                    bindingSourceLoanScales.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }




    }
}

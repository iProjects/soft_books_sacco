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
    public partial class ExoticShedulesForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        List<ExoticInstallmentsModel> _lstexoticinstallments = new List<ExoticInstallmentsModel>();
        public int SelectedRowIndex { get; set; }
        #endregion "Private Fields"

        #region "Constructor"
        public ExoticShedulesForm(string Conn)
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        #region "Validation"
        private bool IsExoticSheduleValid()
        {
            bool noerror = true;

            return noerror;
        }
        private bool IsNameValid()
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
        #endregion "Validation"
        private void ExoticShedulesForm_Load(object sender, EventArgs e)
        {
            try
            {
                btnAddName.Enabled = false;

                lblTotalInterest.Visible = false;
                lblTotalPrincipal.Visible = false;

                var _exoticsquery = from ex in rep.GetAllExotics()
                                    select ex;
                List<ExoticsModel> _exotics = _exoticsquery.ToList();
                bindingSourceExotics.DataSource = _exotics;
                cboExoticShedules.DataSource = bindingSourceExotics;
                cboExoticShedules.DisplayMember = "name";
                cboExoticShedules.ValueMember = "exoticid"; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsNameValid())
            {
                try
                {
                    ExoticsModel exotic = new ExoticsModel();
                    if (!string.IsNullOrEmpty(txtDescription.Text.Trim()))
                    {
                        exotic.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }

                    if (rep.GetAllExotics().Any(i => i.name == exotic.name))
                    {
                        MessageBox.Show("Exotic with Name " + exotic.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!rep.GetAllExotics().Any(i => i.name == exotic.name))
                    {
                        rep.AddNewExotic(exotic);
                        RefreshComboBox();
                        txtDescription.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDeleteName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboExoticShedules.SelectedIndex != -1)
            {
                try
                {
                    ExoticsModel _exotic = (ExoticsModel)cboExoticShedules.SelectedItem;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Exotic\n" + _exotic.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteExotic(_exotic);
                        RefreshComboBox();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (var inst in _lstexoticinstallments)
                {
                    rep.AddNewExoticInstallment(inst);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCycleObjectParameters_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCycleObjectParameters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboExoticShedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboExoticShedules.SelectedIndex != -1)
            {
                try
                {
                    _lstexoticinstallments = null;
                    _lstexoticinstallments = new List<ExoticInstallmentsModel>();
                    ExoticsModel _exotic = (ExoticsModel)cboExoticShedules.SelectedItem;
                    var _exoticinstallments = from ex in rep.GetAllExoticInstallments(_exotic.exoticid)
                                              select ex;
                    _lstexoticinstallments = _exoticinstallments.ToList();
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescription.Text))
                {
                    btnAddName.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtDescription.Text))
                {
                    btnAddName.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                MoveUp(bindingSourceExoticInstallments);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                MoveDown(bindingSourceExoticInstallments);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddInstallment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (cboExoticShedules.SelectedIndex != -1)
                {
                    ExoticsModel exotic = (ExoticsModel)cboExoticShedules.SelectedItem;

                    ExoticInstallmentsModel exoticinstallment = new ExoticInstallmentsModel();
                    exoticinstallment.interest_coeff = 0;
                    exoticinstallment.principal_coeff = 0;
                    exoticinstallment.exotic_id = exotic.exoticid;

                    _lstexoticinstallments.Add(exoticinstallment);

                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteInstallment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewExoticInstallments.SelectedRows.Count != -1)
                {
                    ExoticInstallmentsModel exotic = (ExoticInstallmentsModel)bindingSourceExoticInstallments.Current;
                    _lstexoticinstallments.Remove(exotic);

                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshComboBox()
        {
            try
            {
                bindingSourceExotics.DataSource = null;
                var _exoticsquery = from ex in rep.GetAllExotics()
                                    select ex;
                List<ExoticsModel> _exotics = _exoticsquery.ToList();
                bindingSourceExotics.DataSource = _exotics;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshGrid()
        {
            try
            {
                bindingSourceExoticInstallments.DataSource = null;

                foreach (var row in _lstexoticinstallments)
                {
                    int index = _lstexoticinstallments.IndexOf(row);
                    row.number = index + 1;
                }

                dataGridViewExoticInstallments.AutoGenerateColumns = false;
                this.dataGridViewExoticInstallments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceExoticInstallments.DataSource = _lstexoticinstallments;
                dataGridViewExoticInstallments.DataSource = bindingSourceExoticInstallments;
                groupBox15.Text = bindingSourceExoticInstallments.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewExoticInstallments.Rows)
                {
                    dataGridViewExoticInstallments.Rows[dataGridViewExoticInstallments.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewExoticInstallments.Rows.Count - 1;
                    bindingSourceExoticInstallments.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void MoveUp(BindingSource aBindingSource)
        {
            int position = aBindingSource.Position;
            if (position == 0) return; // already at top

            aBindingSource.RaiseListChangedEvents = false;

            object current = aBindingSource.Current;
            aBindingSource.Remove(current);

            position--;

            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;

            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }
        private void MoveDown(BindingSource aBindingSource)
        {
            int position = aBindingSource.Position;
            if (position == aBindingSource.Count - 1) return; // already at bottom

            aBindingSource.RaiseListChangedEvents = false;

            object current = aBindingSource.Current;
            aBindingSource.Remove(current);

            position++;

            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;

            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }




        #endregion "Private Methods"
















    }
}
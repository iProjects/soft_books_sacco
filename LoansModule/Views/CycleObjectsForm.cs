using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace LoansModule.Views
{
    public partial class CycleObjectsForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        Package loan;
        #endregion "Private Fields"

        public CycleObjectsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtDescription.Text))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDescription, "Description cannot be null!");
                    return;
                }
                if (!string.IsNullOrEmpty(txtDescription.Text))
                {
                    CycleObjectsModel cycle = new CycleObjectsModel();
                    cycle.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                    if (rep.GetAllCycleObjects().Any(i => i.name == cycle.name))
                    {
                        MessageBox.Show("Cycle Object with Name " + cycle.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!rep.GetAllCycleObjects().Any(i => i.name == cycle.name))
                    {
                        rep.AddNewCycleObject(cycle);
                        RefreshGrid();
                        txtDescription.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCycleObjects.SelectedRows.Count != 0)
            {
                try
                {
                    CycleObjectsModel cycleobs = (CycleObjectsModel)bindingSourceCycleObject.Current;
                    var CycleObjectsPropsquery = from cop in rep.GetAllCycleParameters()
                                                 where cop.cycle_object_id == cycleobs.cycleobjectid
                                                 select cop;
                    List<CycleParametersModel> CycleObjectsProps = CycleObjectsPropsquery.ToList();
                    if (CycleObjectsProps.Count > 0)
                    {
                        MessageBox.Show("There is a Cycle Object Property Associated with this Cycle Object.\n Delete the Cycle Object Property First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Cycle Object\n" + cycleobs.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteCycleObject(cycleobs);
                            RefreshGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void CycleObjectsForm_Load(object sender, EventArgs e)
        {
            try
            {
                bindingSourceCycleObject.DataSource = null;
                var cycleobjectsquery = from co in rep.GetAllCycleObjects()
                                        select co;
                List<CycleObjectsModel> Cycleobjects = cycleobjectsquery.ToList();
                bindingSourceCycleObject.DataSource = Cycleobjects;
                dataGridViewCycleObjects.AutoGenerateColumns = false;
                dataGridViewCycleObjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewCycleObjects.DataSource = bindingSourceCycleObject;
                groupBox4.Text = Cycleobjects.Count.ToString();
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
                bindingSourceCycleObject.DataSource = null;
                var cycleobjectsquery = from co in rep.GetAllCycleObjects()
                                        select co;
                List<CycleObjectsModel> Cycleobjects = cycleobjectsquery.ToList();
                bindingSourceCycleObject.DataSource = Cycleobjects;
                groupBox4.Text = Cycleobjects.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.Owner is EditLoanProductForm)
                {
                    EditLoanProductForm f = (EditLoanProductForm)this.Owner;
                    f.RefreshCycleObjectsCombo();
                    this.Close();
                }
                if (this.Owner is AddLoanProductForm)
                {
                    AddLoanProductForm f = (AddLoanProductForm)this.Owner;
                    f.RefreshCycleObjectsCombo();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }





















    }
}
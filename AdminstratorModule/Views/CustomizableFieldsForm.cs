using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class CustomizableFieldsForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public CustomizableFieldsForm(int _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddCustomizableFieldsForm acff = new AddCustomizableFieldsForm(connection) { Owner = this };
                acff.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCustomizableFields.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.CustomizableFieldsModel _cust = (DAL.CustomizableFieldsModel)bindingSourceCustomizableFields.Current;
                    EditCustomizableFieldsForm ecf = new EditCustomizableFieldsForm(_cust, connection) { Owner = this };
                    ecf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewCustomizableFields.SelectedRows.Count != 0)
                {
                    try
                    {
                        DAL.CustomizableFieldsModel _cust = (DAL.CustomizableFieldsModel)bindingSourceCustomizableFields.Current;
                        EditCustomizableFieldsForm ecf = new EditCustomizableFieldsForm(_cust, connection) { Owner = this };
                        ecf.DisableControls();
                        ecf.ShowDialog();
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void CustomizableFieldsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _AdvancedFieldentitiesquery = from et in rep.GetAllAdvancedFieldsEntities()
                                                  select et;
                List<AdvancedFieldsEntitiesModel> _advfieldEntities = _AdvancedFieldentitiesquery.ToList();
                DataGridViewComboBoxColumn colAdvancedFieldEntity = new DataGridViewComboBoxColumn();
                colAdvancedFieldEntity.HeaderText = "Entity";
                colAdvancedFieldEntity.Name = "cbAdvancedFieldEntity";
                colAdvancedFieldEntity.DataSource = _advfieldEntities;
                colAdvancedFieldEntity.DisplayMember = "name";
                //foreign key
                colAdvancedFieldEntity.DataPropertyName = "entity_id";
                //primary key
                colAdvancedFieldEntity.ValueMember = "advfieldsentitiesid";
                colAdvancedFieldEntity.MaxDropDownItems = 10;
                colAdvancedFieldEntity.DisplayIndex = 1;
                colAdvancedFieldEntity.MinimumWidth = 5;
                colAdvancedFieldEntity.Width = 100;
                //colAdvancedFieldEntity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAdvancedFieldEntity.FlatStyle = FlatStyle.Flat;
                colAdvancedFieldEntity.DefaultCellStyle.NullValue = "--- Select ---";
                if (!this.dataGridViewCustomizableFields.Columns.Contains("cbAdvancedFieldEntity"))
                {
                    dataGridViewCustomizableFields.Columns.Add(colAdvancedFieldEntity);
                }


                dataGridViewCustomizableFields.AutoGenerateColumns = false;
                this.dataGridViewCustomizableFields.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceCustomizableFields.DataSource = rep.GetCustomizableFields();
                dataGridViewCustomizableFields.DataSource = bindingSourceCustomizableFields;
                groupBox2.Text = bindingSourceCustomizableFields.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCustomizableFields.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.CustomizableFieldsModel _cust = (DAL.CustomizableFieldsModel)bindingSourceCustomizableFields.Current;

                    var _advancedfieldsquery = from br in rep.GetAdvancedFields(_cust.entity_id)
                                               select br;
                    List<AdvancedFieldsModel> _advancedfields = _advancedfieldsquery.ToList();

                    if (_advancedfields.Count > 0)
                    {
                        MessageBox.Show("There is a Field Associated with this Entity\nDelete the field first!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (DialogResult.Yes == MessageBox.Show("By clicking yes you will delete all Field values and any collection items they may have\n", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            AdvancedFieldsEntitiesModel afem = rep.GetAdvancedFieldEntity(_cust.entity_id);
                            rep.DeleteAdvancedFieldsEntity(afem);
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
                //set the datasource to null
                bindingSourceCustomizableFields.DataSource = null;
                //set the datasource to a method
                var _CustomizableFieldsquery = from fl in rep.GetCustomizableFields()
                                               select fl;
                List<CustomizableFieldsModel> _CustomizableFields = _CustomizableFieldsquery.ToList();
                bindingSourceCustomizableFields.DataSource = _CustomizableFields;
                groupBox2.Text = bindingSourceCustomizableFields.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewCustomizableFields.Rows)
                {
                    dataGridViewCustomizableFields.Rows[dataGridViewCustomizableFields.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewCustomizableFields.Rows.Count - 1;
                    bindingSourceCustomizableFields.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewCustomizableFields_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCustomizableFields.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.CustomizableFieldsModel _cust = (DAL.CustomizableFieldsModel)bindingSourceCustomizableFields.Current;
                    EditCustomizableFieldsForm ecf = new EditCustomizableFieldsForm(_cust, connection) { Owner = this };
                    ecf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        #endregion "Private Methods"


    }
}

using System; 
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; 
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using CommonLib;
using DAL;

namespace LoansModule.Views
{
    public partial class AddCollateralProductForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        List<CollateralPropertiesModel> _lstcollateralprops = new List<CollateralPropertiesModel>();
        List<CollateralPropertyCollectionsModel> _lstpropscolls = new List<CollateralPropertyCollectionsModel>();
        #endregion "Private Fields"

        #region "Constructor"
        public AddCollateralProductForm(string Conn)
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
        private void AddCollateralProductForm_Load(object sender, EventArgs e)
        {
            try
            {

                var _CollateralPropertyTypesquery = from et in rep.GetAllCollateralPropertyTypes()
                                                    select et;
                List<CollateralPropertyTypesModel> _CollateralPropertyTypes = _CollateralPropertyTypesquery.ToList();
                cboCollateralPropertyTypes.DataSource = _CollateralPropertyTypes;
                cboCollateralPropertyTypes.ValueMember = "collateralpropertytypeid";
                cboCollateralPropertyTypes.DisplayMember = "name";
                cboCollateralPropertyTypes.SelectedIndex = -1;

                txtattPropertyDescription.Text = string.Empty;
                lblattPropertyName.Text = string.Empty;
                txtattPropertyDescription.Visible = false;
                lblattPropertyName.Visible = false;

                ManagePropertyControls();

                gbAttributes.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (IsCollateralProductValid())
                {
                    CollateralProductsModel _collateralproductmodel = new CollateralProductsModel();
                    if (!string.IsNullOrEmpty(txtProductName.Text))
                    {
                        _collateralproductmodel.name = Utils.ConvertFirstLetterToUpper(txtProductName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtProductDescription.Text))
                    {
                        _collateralproductmodel.desc = Utils.ConvertFirstLetterToUpper(txtProductDescription.Text.Trim());
                    }
                    _collateralproductmodel.deleted = false;
                    if (dataGridViewCollateralProperties.SelectedRows.Count != 0)
                    {
                        _collateralproductmodel.productProperties = _lstcollateralprops;
                    }

                    rep.AddNewCollateralProduct(_collateralproductmodel);

                    CollateralProductsListForm cf = (CollateralProductsListForm)this.Owner;
                    cf.RefreshGrid();
                    this.Close(); 
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddProperty_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsCollateralPropertyValid())
            {
                try
                {
                    DAL.CollateralPropertyTypesModel _propertytype = (DAL.CollateralPropertyTypesModel)cboCollateralPropertyTypes.SelectedItem;
                    string _propertyname = Utils.ConvertFirstLetterToUpper(txtPropertyName.Text.Trim());

                    switch (_propertytype.collateralpropertytypeid)
                    {
                        case 4:
                            StringBuilder sb = new StringBuilder();
                            foreach (var row in _lstpropscolls)
                            {
                                if (row.propertyname == _propertyname)
                                {
                                    sb.Append(Utils.ConvertFirstLetterToUpper(row.value.Trim()) + ",");
                                }
                            }
                            CollateralPropertiesModel _colprop = new CollateralPropertiesModel();
                            if (!string.IsNullOrEmpty(txtPropertyName.Text))
                            {
                                _colprop.name = Utils.ConvertFirstLetterToUpper(txtPropertyName.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtPropertyDescription.Text))
                            {
                                _colprop.desc = sb.ToString();
                            }
                            if (cboCollateralPropertyTypes.SelectedIndex != -1)
                            {
                                _colprop.type_id = int.Parse(cboCollateralPropertyTypes.SelectedValue.ToString());
                            }

                            if (_lstcollateralprops.Any(i => i.name == _colprop.name))
                            {
                                MessageBox.Show("Property with Name " + _colprop.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (!_lstcollateralprops.Any(i => i.name == _colprop.name))
                            {
                                _lstcollateralprops.Add(_colprop);
                                RefreshGrid();
                                ClearControls();
                                ClearCollectionControls();
                                EnableControls();
                                DisableProductControls();
                            }
                            break;
                        default:
                            CollateralPropertiesModel colprop = new CollateralPropertiesModel();
                            if (!string.IsNullOrEmpty(txtPropertyName.Text))
                            {
                                colprop.name = Utils.ConvertFirstLetterToUpper(txtPropertyName.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtPropertyDescription.Text))
                            {
                                colprop.desc = Utils.ConvertFirstLetterToUpper(txtPropertyDescription.Text.Trim());
                            }
                            if (cboCollateralPropertyTypes.SelectedIndex != -1)
                            {
                                colprop.type_id = int.Parse(cboCollateralPropertyTypes.SelectedValue.ToString());
                            }

                            if (_lstcollateralprops.Any(i => i.name == colprop.name))
                            {
                                MessageBox.Show("Property with Name " + colprop.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (!_lstcollateralprops.Any(i => i.name == colprop.name))
                            {
                                _lstcollateralprops.Add(colprop);
                                RefreshGrid();
                                ClearControls();
                                ClearCollectionControls();
                                EnableControls();
                                DisableProductControls();
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
        private void btnDeleteProperty_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCollateralProperties.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.CollateralPropertiesModel _advfld = (DAL.CollateralPropertiesModel)bindingSourceCollateralProperties.Current;
                    _lstcollateralprops.Remove(_advfld);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnAddItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (string.IsNullOrEmpty(txtItem.Text))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtItem, "Name cannot be null!");
                    return;
                }
                if (!string.IsNullOrEmpty(txtItem.Text))
                {
                    CollateralPropertyCollectionsModel colitem = new CollateralPropertyCollectionsModel();
                    colitem.value = Utils.ConvertFirstLetterToUpper(txtItem.Text.Trim());
                    colitem.propertyname =Utils.ConvertFirstLetterToUpper( txtPropertyName.Text.Trim());

                    if (_lstpropscolls.Any(i => i.value == colitem.value))
                    {
                        MessageBox.Show("Item with Name " + colitem.value + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!_lstpropscolls.Any(i => i.value == colitem.value))
                    {
                        _lstpropscolls.Add(colitem);
                        RefreshListBox();
                        ManageAdvancedItem();
                        txtItem.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lstCollections.SelectedIndex != -1)
            {
                try
                {
                    DAL.CollateralPropertyCollectionsModel colitem = (DAL.CollateralPropertyCollectionsModel)bindingSourceCollateralPropertyCollections.Current;
                    _lstpropscolls.Remove(colitem);
                    RefreshListBox();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ManagePropertyCollections()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPropertyName.Text) && !string.IsNullOrEmpty(txtPropertyDescription.Text) && cboCollateralPropertyTypes.SelectedIndex != -1)
                {
                    ManageCollections();
                }
                if (string.IsNullOrEmpty(txtPropertyName.Text) && string.IsNullOrEmpty(txtPropertyDescription.Text) && cboCollateralPropertyTypes.SelectedIndex == -1)
                {
                    groupBox3.Enabled = false;
                    txtItem.Enabled = false;
                    btnAddItem.Enabled = false;
                    btnDeleteItem.Enabled = false;
                    lstCollections.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ManagePropertyControls()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtProductDescription.Text) )
                {
                    groupBox2.Enabled = true;
                }
                if (string.IsNullOrEmpty(txtProductName.Text) && string.IsNullOrEmpty(txtProductDescription.Text) )
                {
                    groupBox2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ManageColletionControls()
        {
            if (cboCollateralPropertyTypes.SelectedIndex != -1)
            {
                try
                {
                    CollateralPropertyTypesModel afcm = (CollateralPropertyTypesModel)cboCollateralPropertyTypes.SelectedItem;
                    switch (afcm.collateralpropertytypeid)
                    {
                        case 1:
                            groupBox3.Enabled = false;
                            txtItem.Enabled = false;
                            lstCollections.Enabled = false;
                            break;
                        case 2:
                            groupBox3.Enabled = false;
                            txtItem.Enabled = false;
                            lstCollections.Enabled = false;
                            break;
                        case 3:
                            groupBox3.Enabled = false;
                            txtItem.Enabled = false;
                            lstCollections.Enabled = false;
                            break;
                        case 4:
                            ManagePropertyCollections();
                            break;
                        case 5:
                            groupBox3.Enabled = false;
                            txtItem.Enabled = false;
                            lstCollections.Enabled = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ManageFieldAddButton()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPropertyName.Text) && !string.IsNullOrEmpty(txtPropertyDescription.Text) && cboCollateralPropertyTypes.SelectedIndex != -1)
                {
                    btnAddItem.Enabled = true;
                }
                if (string.IsNullOrEmpty(txtPropertyName.Text) && string.IsNullOrEmpty(txtPropertyDescription.Text) && cboCollateralPropertyTypes.SelectedIndex == -1)
                {
                    btnAddItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ManageCollections()
        {
            if (cboCollateralPropertyTypes.SelectedIndex != -1)
            {
                try
                {
                    CollateralPropertyTypesModel afcm = (CollateralPropertyTypesModel)cboCollateralPropertyTypes.SelectedItem;
                    switch (afcm.collateralpropertytypeid)
                    {
                        case 4:
                            groupBox3.Enabled = true;
                            txtItem.Enabled = true;
                            lstCollections.Enabled = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ManageAdvancedItem()
        {
            try
            {
                txtPropertyName.Enabled = false;
                txtPropertyDescription.Enabled = false;
                cboCollateralPropertyTypes.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                txtPropertyName.Text = string.Empty;
                txtPropertyDescription.Text = string.Empty;
                cboCollateralPropertyTypes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void EnableControls()
        {
            try
            {
                txtPropertyName.Enabled = true;
                txtPropertyDescription.Enabled = true;
                cboCollateralPropertyTypes.Enabled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DisableProductControls()
        {
            try
            {
                txtProductName.Enabled = false;
                txtProductDescription.Enabled = false; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearCollectionControls()
        {
            try
            {
                txtItem.Text = string.Empty;
                txtPropertyDescription.Text = string.Empty;
                _lstpropscolls.Clear();
                RefreshListBox();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshListBox()
        {
            try
            {
                bindingSourceCollateralPropertyCollections.DataSource = null;
                bindingSourceCollateralPropertyCollections.DataSource = _lstpropscolls;
                groupBox3.Text = "Collection Items = " + bindingSourceCollateralPropertyCollections.Count.ToString();
                lstCollections.DataSource = bindingSourceCollateralPropertyCollections;
                lstCollections.ValueMember = "collpropcollid";
                lstCollections.DisplayMember = "value";
                lstCollections.SelectedIndex = _lstpropscolls.Count - 1;
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
                var _AdvancedFieldtypesquery = from et in rep.GetAllCollateralPropertyTypes()
                                               select et;
                List<CollateralPropertyTypesModel> _proptypes = _AdvancedFieldtypesquery.ToList();
                DataGridViewComboBoxColumn colAdvancedFieldType = new DataGridViewComboBoxColumn();
                colAdvancedFieldType.HeaderText = "Type";
                colAdvancedFieldType.Name = "cbAdvancedFieldTypes";
                colAdvancedFieldType.DataSource = _proptypes;
                colAdvancedFieldType.DisplayMember = "name";
                //foreign key
                colAdvancedFieldType.DataPropertyName = "type_id";
                //primary key
                colAdvancedFieldType.ValueMember = "collateralpropertytypeid";
                colAdvancedFieldType.MaxDropDownItems = 10;
                colAdvancedFieldType.DisplayIndex = 3;
                colAdvancedFieldType.MinimumWidth = 5;
                colAdvancedFieldType.Width = 100;
                colAdvancedFieldType.FlatStyle = FlatStyle.Flat;
                colAdvancedFieldType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAdvancedFieldType.ReadOnly = true;
                if (!this.dataGridViewCollateralProperties.Columns.Contains("cbAdvancedFieldTypes"))
                {
                    dataGridViewCollateralProperties.Columns.Add(colAdvancedFieldType);
                }

                foreach (var row in _lstcollateralprops)
                {
                    int index = _lstcollateralprops.IndexOf(row);
                    row._collateralpropertyid = index + 1;
                }

                dataGridViewCollateralProperties.AutoGenerateColumns = false;
                this.dataGridViewCollateralProperties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceCollateralProperties.DataSource = null;
                bindingSourceCollateralProperties.DataSource = _lstcollateralprops;
                dataGridViewCollateralProperties.DataSource = bindingSourceCollateralProperties;
                groupBox1.Text = bindingSourceCollateralProperties.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewCollateralProperties.Rows)
                {
                    dataGridViewCollateralProperties.Rows[dataGridViewCollateralProperties.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewCollateralProperties.Rows.Count - 1;
                    bindingSourceCollateralProperties.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool IsCollateralProductValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtProductDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductDescription, "Description cannot be null!");
                return false;
            }
            return noerror;
        }
        public bool IsCollateralPropertyValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtProductDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductDescription, "Description cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPropertyName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPropertyName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPropertyDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPropertyDescription, "Description cannot be null!");
                return false;
            }
            if (cboCollateralPropertyTypes.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCollateralPropertyTypes, "select Field Type!");
                return false;
            }
            return noerror;
        }
        private void dataGridViewCollateralProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewCollateralProperties.SelectedRows.Count != 0)
                {

                    DAL.CollateralPropertiesModel _colprop = (DAL.CollateralPropertiesModel)bindingSourceCollateralProperties.Current;
                    txtattPropertyDescription.Text = _colprop.desc;
                    lblattPropertyName.Text = _colprop.name;
                    txtattPropertyDescription.Visible = true;
                    lblattPropertyName.Visible = true;
                }
                if (dataGridViewCollateralProperties.SelectedRows.Count == 0)
                {
                    txtattPropertyDescription.Visible = false;
                    lblattPropertyName.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void lstCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstCollections.SelectedIndex == -1)
                {
                    btnDeleteItem.Enabled = false;
                }
                if (lstCollections.SelectedIndex != -1)
                {
                    btnDeleteItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtItem.Text))
                {
                    btnAddItem.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtItem.Text))
                {
                    btnAddItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtPropertyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ManagePropertyCollections();
                ManageFieldAddButton();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtPropertyDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ManagePropertyCollections();
                ManageFieldAddButton();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboCollateralPropertyTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ManageColletionControls();
                ManagePropertyCollections();
                ManageFieldAddButton();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCollateralProperties_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCollateralProperties.SelectedRows.Count != 0)
                {

                    DAL.CollateralPropertiesModel _colprop = (DAL.CollateralPropertiesModel)bindingSourceCollateralProperties.Current;
                    txtattPropertyDescription.Text = _colprop.desc;
                    lblattPropertyName.Text = _colprop.name;
                    txtattPropertyDescription.Visible = true;
                    lblattPropertyName.Visible = true;
                    btnDeleteProperty.Enabled = true;
                }
                if (dataGridViewCollateralProperties.SelectedRows.Count == 0)
                {
                    txtattPropertyDescription.Visible = false;
                    lblattPropertyName.Visible = false;
                    btnDeleteProperty.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ManagePropertyControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void txtProductDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ManagePropertyControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"







    }
}
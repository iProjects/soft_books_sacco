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
    public partial class AddCustomizableFieldsForm : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        List<AdvancedFieldsModel> _lstadvancedfields = new List<AdvancedFieldsModel>();
        List<AdvancedFieldsCollectionsModel> _lstadvfcolls = new List<AdvancedFieldsCollectionsModel>();


        public AddCustomizableFieldsForm(string Conn)
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
        private void AddCustomizableFieldsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _AdvancedFieldEntitiesquery = from et in rep.GetAllAdvancedFieldsEntities()
                                                  select et;
                List<AdvancedFieldsEntitiesModel> _AdvancedFieldEntities = _AdvancedFieldEntitiesquery.ToList();
                cboAdvancedFieldEntities.DataSource = _AdvancedFieldEntities;
                cboAdvancedFieldEntities.ValueMember = "advfieldsentitiesid";
                cboAdvancedFieldEntities.DisplayMember = "name";
                cboAdvancedFieldEntities.SelectedIndex = -1;

                var _AdvancedFieldTypesquery = from et in rep.GetAllAdvancedFieldsTypes()
                                               select et;
                List<AdvancedFieldsTypesModel> _AdvancedFieldTypes = _AdvancedFieldTypesquery.ToList();
                cboAdvancedFieldTypes.DataSource = _AdvancedFieldTypes;
                cboAdvancedFieldTypes.ValueMember = "advfieldstypesid";
                cboAdvancedFieldTypes.DisplayMember = "name";
                cboAdvancedFieldTypes.SelectedIndex = -1;

                txtattFieldDescription.Text = string.Empty;
                lblattFieldName.Text = string.Empty;
                chkattMandatory.Visible = false;
                chkattUnique.Visible = false;
                txtattFieldDescription.Visible = false;
                lblattFieldName.Visible = false; 
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
                if (dataGridViewAdvancedFields.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No Fields to Add!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dataGridViewAdvancedFields.SelectedRows.Count != 0)
                {
                    DAL.AdvancedFieldsEntitiesModel _fieldentity = (DAL.AdvancedFieldsEntitiesModel)cboAdvancedFieldEntities.SelectedItem;
                    var _AdvancedFieldsquery = (from s in db.AdvancedFields
                                                where s.entity_id == _fieldentity.advfieldsentitiesid
                                                select s).ToList();
                    if (_AdvancedFieldsquery.Count > 0)
                    {
                        MessageBox.Show("Fields for Entity " + _fieldentity.name + " Already Exists \nUse the Edit Button to Add More Fields!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (_AdvancedFieldsquery.Count == 0)
                    {
                        foreach (var af in _lstadvancedfields)
                        {
                            rep.AddNewAdvancedField(af);
                        }

                        CustomizableFieldsForm cf = (CustomizableFieldsForm)this.Owner;
                        cf.RefreshGrid();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddField_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsAdvancedFieldValid())
            {
                try
                {
                    DAL.AdvancedFieldsTypesModel _fieldtype = (DAL.AdvancedFieldsTypesModel)cboAdvancedFieldTypes.SelectedItem;
                    string _fieldname = Utils.ConvertFirstLetterToUpper(txtFieldName.Text.Trim());

                    switch (_fieldtype.advfieldstypesid)
                    {
                        case 5:
                            StringBuilder sb = new StringBuilder();
                            foreach (var row in _lstadvfcolls)
                            {
                                if (row.fieldname == _fieldname)
                                {
                                    sb.Append(Utils.ConvertFirstLetterToUpper(row.value.Trim()) + ",");
                                }
                            }
                            AdvancedFieldsModel _advfield = new AdvancedFieldsModel();
                            if (cboAdvancedFieldEntities.SelectedIndex != -1)
                            {
                                _advfield.entity_id = int.Parse(cboAdvancedFieldEntities.SelectedValue.ToString());
                            }
                            if (!string.IsNullOrEmpty(txtFieldName.Text))
                            {
                                _advfield.name = Utils.ConvertFirstLetterToUpper(txtFieldName.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtDescription.Text))
                            {
                                _advfield.desc = sb.ToString();
                            }
                            if (cboAdvancedFieldTypes.SelectedIndex != -1)
                            {
                                _advfield.type_id = int.Parse(cboAdvancedFieldTypes.SelectedValue.ToString());
                            }
                            _advfield.is_mandatory = chkMandatory.Checked;
                            _advfield.is_unique = chkUnique.Checked;

                            if (_lstadvancedfields.Any(i => i.name == _advfield.name))
                            {
                                MessageBox.Show("Field with Name " + _advfield.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (!_lstadvancedfields.Any(i => i.name == _advfield.name))
                            {
                                _lstadvancedfields.Add(_advfield);
                                RefreshGrid();
                                ClearControls();
                                ClearCollectionControls();
                                EnableControls();
                            }
                            break;
                        default:
                            AdvancedFieldsModel advfield = new AdvancedFieldsModel();
                            if (cboAdvancedFieldEntities.SelectedIndex != -1)
                            {
                                advfield.entity_id = int.Parse(cboAdvancedFieldEntities.SelectedValue.ToString());
                            }
                            if (!string.IsNullOrEmpty(txtFieldName.Text))
                            {
                                advfield.name = Utils.ConvertFirstLetterToUpper(txtFieldName.Text.Trim());
                            }
                            if (!string.IsNullOrEmpty(txtDescription.Text))
                            {
                                advfield.desc = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                            }
                            if (cboAdvancedFieldTypes.SelectedIndex != -1)
                            {
                                advfield.type_id = int.Parse(cboAdvancedFieldTypes.SelectedValue.ToString());
                            }
                            advfield.is_mandatory = chkMandatory.Checked;
                            advfield.is_unique = chkUnique.Checked;

                            if (_lstadvancedfields.Any(i => i.name == advfield.name))
                            {
                                MessageBox.Show("Field with Name " + advfield.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (!_lstadvancedfields.Any(i => i.name == advfield.name))
                            {
                                _lstadvancedfields.Add(advfield);
                                RefreshGrid();
                                ClearControls();
                                EnableControls();
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
        private void btnDeleteField_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewAdvancedFields.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.AdvancedFieldsModel _advfld = (DAL.AdvancedFieldsModel)bindingSourceAdvancedFields.Current;
                    _lstadvancedfields.Remove(_advfld);
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
                    AdvancedFieldsCollectionsModel colitem = new AdvancedFieldsCollectionsModel();
                    colitem.value = Utils.ConvertFirstLetterToUpper(txtItem.Text.Trim());
                    colitem.fieldname = Utils.ConvertFirstLetterToUpper(txtFieldName.Text.Trim());

                    if (_lstadvfcolls.Any(i => i.value == colitem.value))
                    {
                        MessageBox.Show("Item with Name " + colitem.value + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!_lstadvfcolls.Any(i => i.value == colitem.value))
                    {
                        _lstadvfcolls.Add(colitem);
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
                    DAL.AdvancedFieldsCollectionsModel colitem = (DAL.AdvancedFieldsCollectionsModel)bindingSourceAdvancedFieldsCollections.Current;
                    _lstadvfcolls.Remove(colitem);
                    RefreshListBox();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ManageFieldCollections()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFieldName.Text) && !string.IsNullOrEmpty(txtDescription.Text) && cboAdvancedFieldTypes.SelectedIndex != -1)
                {
                    ManageCollections();
                }
                if (string.IsNullOrEmpty(txtFieldName.Text) && string.IsNullOrEmpty(txtDescription.Text) && cboAdvancedFieldTypes.SelectedIndex == -1)
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
        private void ManageFieldAttributes()
        {
            if (cboAdvancedFieldTypes.SelectedIndex != -1)
            {
                try
                {
                    AdvancedFieldsTypesModel afcm = (AdvancedFieldsTypesModel)cboAdvancedFieldTypes.SelectedItem;
                    switch (afcm.advfieldstypesid)
                    {
                        case 1:
                            chkMandatory.Enabled = false;
                            chkUnique.Enabled = false;
                            break;
                        case 2:
                            chkMandatory.Enabled = true;
                            chkUnique.Enabled = true;
                            break;
                        case 3:
                            chkMandatory.Enabled = true;
                            chkUnique.Enabled = true;
                            break;
                        case 4:
                            chkMandatory.Enabled = true;
                            chkUnique.Enabled = true;
                            break;
                        case 5:
                            chkMandatory.Enabled = true;
                            chkUnique.Enabled = false;
                            break;
                        case 6:
                            chkMandatory.Enabled = true;
                            chkUnique.Enabled = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ManageColletionControls()
        {
            if (cboAdvancedFieldTypes.SelectedIndex != -1)
            {
                try
                {
                    AdvancedFieldsTypesModel afcm = (AdvancedFieldsTypesModel)cboAdvancedFieldTypes.SelectedItem;
                    switch (afcm.advfieldstypesid)
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
                            groupBox3.Enabled = false;
                            txtItem.Enabled = false;
                            lstCollections.Enabled = false;
                            break;
                        case 5:
                            ManageFieldCollections();
                            break;
                        case 6:
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
                if (!string.IsNullOrEmpty(txtFieldName.Text) && !string.IsNullOrEmpty(txtDescription.Text) && cboAdvancedFieldTypes.SelectedIndex != -1)
                {
                    btnAddItem.Enabled = true;
                }
                if (string.IsNullOrEmpty(txtFieldName.Text) && string.IsNullOrEmpty(txtDescription.Text) && cboAdvancedFieldTypes.SelectedIndex == -1)
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
            if (cboAdvancedFieldTypes.SelectedIndex != -1)
            {
                try
                {
                    AdvancedFieldsTypesModel afcm = (AdvancedFieldsTypesModel)cboAdvancedFieldTypes.SelectedItem;
                    switch (afcm.advfieldstypesid)
                    {
                        case 5:
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
                txtFieldName.Enabled = false;
                txtDescription.Enabled = false;
                cboAdvancedFieldTypes.Enabled = false;
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
                txtFieldName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                cboAdvancedFieldTypes.SelectedIndex = -1;
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
                txtFieldName.Enabled = true;
                txtDescription.Enabled = true;
                cboAdvancedFieldTypes.Enabled = true;
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
                txtDescription.Text = string.Empty;
                _lstadvfcolls.Clear();
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
                bindingSourceAdvancedFieldsCollections.DataSource = null;
                bindingSourceAdvancedFieldsCollections.DataSource = _lstadvfcolls;
                groupBox3.Text = "Collection Items = " + bindingSourceAdvancedFieldsCollections.Count.ToString();
                lstCollections.DataSource = bindingSourceAdvancedFieldsCollections;
                lstCollections.ValueMember = "advfieldscollectionid";
                lstCollections.DisplayMember = "value";
                lstCollections.SelectedIndex = _lstadvfcolls.Count - 1;
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
                var _AdvancedFieldtypesquery = from et in rep.GetAllAdvancedFieldsTypes()
                                               select et;
                List<AdvancedFieldsTypesModel> _advfieldtyps = _AdvancedFieldtypesquery.ToList();
                DataGridViewComboBoxColumn colAdvancedFieldType = new DataGridViewComboBoxColumn();
                colAdvancedFieldType.HeaderText = "Type";
                colAdvancedFieldType.Name = "cbAdvancedFieldTypes";
                colAdvancedFieldType.DataSource = _advfieldtyps;
                colAdvancedFieldType.DisplayMember = "name";
                //foreign key
                colAdvancedFieldType.DataPropertyName = "type_id";
                //primary key
                colAdvancedFieldType.ValueMember = "advfieldstypesid";
                colAdvancedFieldType.MaxDropDownItems = 10;
                colAdvancedFieldType.DisplayIndex = 3;
                colAdvancedFieldType.MinimumWidth = 5;
                colAdvancedFieldType.Width = 100;
                colAdvancedFieldType.FlatStyle = FlatStyle.Flat;
                colAdvancedFieldType.DefaultCellStyle.NullValue = "--- Select ---";
                //colAdvancedFieldType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAdvancedFieldType.ReadOnly = true;
                if (!this.dataGridViewAdvancedFields.Columns.Contains("cbAdvancedFieldTypes"))
                {
                    dataGridViewAdvancedFields.Columns.Add(colAdvancedFieldType);
                }

                foreach (var row in _lstadvancedfields)
                {
                    int index = _lstadvancedfields.IndexOf(row);
                    row._advnsdfldid = index + 1;
                }

                dataGridViewAdvancedFields.AutoGenerateColumns = false;
                this.dataGridViewAdvancedFields.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceAdvancedFields.DataSource = null;
                bindingSourceAdvancedFields.DataSource = _lstadvancedfields;
                dataGridViewAdvancedFields.DataSource = bindingSourceAdvancedFields;
                groupBox1.Text = bindingSourceAdvancedFields.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewAdvancedFields.Rows)
                {
                    dataGridViewAdvancedFields.Rows[dataGridViewAdvancedFields.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewAdvancedFields.Rows.Count - 1;
                    bindingSourceAdvancedFields.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool IsAdvancedFieldValid()
        {
            bool noerror = true;
            if (cboAdvancedFieldEntities.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboAdvancedFieldEntities, "select Field Entity!");
                return false;
            }
            if (string.IsNullOrEmpty(txtFieldName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtFieldName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (cboAdvancedFieldTypes.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboAdvancedFieldTypes, "select Field Type!");
                return false;
            }
            return noerror;
        }
        private void dataGridViewAdvancedFields_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewAdvancedFields.SelectedRows.Count != 0)
                {

                    DAL.AdvancedFieldsModel _advfld = (DAL.AdvancedFieldsModel)bindingSourceAdvancedFields.Current;
                    txtattFieldDescription.Text = _advfld.desc;
                    lblattFieldName.Text = _advfld.name;
                    chkattMandatory.Checked = _advfld.is_mandatory;
                    chkattUnique.Checked = _advfld.is_unique;
                    txtattFieldDescription.Visible = true;
                    lblattFieldName.Visible = true;
                    chkattMandatory.Visible = true;
                    chkattUnique.Visible = true;
                }
                if (dataGridViewAdvancedFields.SelectedRows.Count == 0)
                {
                    chkattMandatory.Visible = false;
                    chkattUnique.Visible = false;
                    txtattFieldDescription.Visible = false;
                    lblattFieldName.Visible = false;
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
        private void txtFieldName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ManageFieldCollections();
                ManageFieldAddButton();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ManageFieldCollections();
                ManageFieldAddButton();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ManageColletionControls();
                ManageFieldAttributes();
                ManageFieldCollections();
                ManageFieldAddButton();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void dataGridViewAdvancedFields_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAdvancedFields.SelectedRows.Count != 0)
                {

                    DAL.AdvancedFieldsModel _advfld = (DAL.AdvancedFieldsModel)bindingSourceAdvancedFields.Current;
                    txtattFieldDescription.Text = _advfld.desc;
                    lblattFieldName.Text = _advfld.name;
                    chkattMandatory.Checked = _advfld.is_mandatory;
                    chkattUnique.Checked = _advfld.is_unique;
                    txtattFieldDescription.Visible = true;
                    lblattFieldName.Visible = true;
                    chkattMandatory.Visible = true;
                    chkattUnique.Visible = true;
                    btnDeleteField.Enabled = true;
                }
                if (dataGridViewAdvancedFields.SelectedRows.Count == 0)
                {
                    chkattMandatory.Visible = false;
                    chkattUnique.Visible = false;
                    txtattFieldDescription.Visible = false;
                    lblattFieldName.Visible = false;
                    btnDeleteField.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }













    }
}

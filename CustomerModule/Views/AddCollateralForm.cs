using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace CustomerModule.Views
{
    public partial class AddCollateralForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        List<CollateralPropertiesModel> _collateralproperties;
        int _contractid;
        int _productid;
        #endregion "Private Fields"

        #region "Constructor"
        public AddCollateralForm(int contractid, int productid, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _contractid = contractid;

            _productid = productid;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AddCollateralForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _colprosvaluesquery = from cp in rep.GetCollateralProductPropertiesforProduct(_productid)
                                          select cp;
                _collateralproperties = _colprosvaluesquery.ToList();

                dataGridViewCollaterals.AutoGenerateColumns = false;
                dataGridViewCollaterals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewCollaterals.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewCollaterals.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                lblCollateralDescription.Text = string.Empty;
                lblCollateralName.Text = string.Empty;

                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsSolidarityGroupValid())
            {
                try
                {
                    CollateralPropertyValuesModel _collateral = new CollateralPropertyValuesModel();
                    int _collaterallinkcontract = rep.GetCollateralLinkContractid(_contractid);

                    foreach (DataGridViewRow row in dataGridViewCollaterals.Rows)
                    {
                        string _cellvalue = string.Empty;
                        int _propertyid = 0;
                        int _typeid = int.Parse(row.Cells["columnTypeId"].Value.ToString());

                        switch (_typeid)
                        {
                            case 1:
                                if (row.Cells["columnValue"].Value != null)
                                {
                                    _cellvalue = row.Cells["columnValue"].Value.ToString();
                                }
                                if (row.Cells["columnPropId"].Value != null)
                                {
                                    _propertyid = int.Parse(row.Cells["columnPropId"].Value.ToString());
                                }
                                _collateral.contract_collateral_id = _collaterallinkcontract;
                                _collateral.property_id = _propertyid;
                                _collateral.value = _cellvalue;

                                rep.AddNewCollateralPropertyValue(_collateral);
                                break;
                            case 2:
                                if (row.Cells["columnValue"].Value != null)
                                {
                                    _cellvalue = row.Cells["columnValue"].Value.ToString();
                                }
                                if (row.Cells["columnPropId"].Value != null)
                                {
                                    _propertyid = int.Parse(row.Cells["columnPropId"].Value.ToString());
                                }
                                _collateral.contract_collateral_id = _collaterallinkcontract;
                                _collateral.property_id = _propertyid;
                                _collateral.value = _cellvalue;

                                rep.AddNewCollateralPropertyValue(_collateral);
                                break;
                            case 3:
                                if (row.Cells["columnValue"].Value != null)
                                {
                                    _cellvalue = row.Cells["columnValue"].Value.ToString();
                                }
                                if (row.Cells["columnPropId"].Value != null)
                                {
                                    _propertyid = int.Parse(row.Cells["columnPropId"].Value.ToString());
                                }
                                _collateral.contract_collateral_id = _collaterallinkcontract;
                                _collateral.property_id = _propertyid;
                                _collateral.value = _cellvalue;

                                rep.AddNewCollateralPropertyValue(_collateral);
                                break;
                            case 4:
                                if (row.Cells["columnValue"].Value != null)
                                {
                                    _cellvalue = row.Cells["columnValue"].Value.ToString();
                                }
                                if (row.Cells["columnPropId"].Value != null)
                                {
                                    _propertyid = int.Parse(row.Cells["columnPropId"].Value.ToString());
                                }
                                _collateral.contract_collateral_id = _collaterallinkcontract;
                                _collateral.property_id = _propertyid;
                                _collateral.value = _cellvalue;

                                rep.AddNewCollateralPropertyValue(_collateral);
                                break;
                            case 5:
                                if (row.Cells["columnValue"].Value != null)
                                {
                                    _cellvalue = row.Cells["columnValue"].Value.ToString();
                                }
                                if (row.Cells["columnPropId"].Value != null)
                                {
                                    _propertyid = int.Parse(row.Cells["columnPropId"].Value.ToString());
                                }
                                _collateral.contract_collateral_id = _collaterallinkcontract;
                                _collateral.property_id = _propertyid;
                                _collateral.value = _cellvalue;

                                rep.AddNewCollateralPropertyValue(_collateral);
                                break;
                        } 
                    }

                    EditPersonForm cf = (EditPersonForm)this.Owner;
                    cf.RefreshLoanContractCollateralsGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsSolidarityGroupValid()
        {
            bool noerror = true;


            return noerror;
        }
        #endregion "Validation"
        private void InitializeControls()
        {
            try
            { 
                int _rowid = 1;
                foreach (var c in _collateralproperties)
                {
                    switch (c.type_id)
                    { 
                        case 1:
                            DataGridViewRow _numberrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _numberidcell = new DataGridViewTextBoxCell();
                            _numberidcell.Value = _rowid.ToString();
                            _numberrow.Cells.Add(_numberidcell);

                            DataGridViewColumn _numberiddataGridViewColumn = new DataGridViewColumn();
                            _numberiddataGridViewColumn.DataPropertyName = "_rowid";
                            _numberiddataGridViewColumn.HeaderText = "Id";
                            _numberiddataGridViewColumn.CellTemplate = _numberidcell;
                            _numberiddataGridViewColumn.Name = "columnId";
                            _numberiddataGridViewColumn.ReadOnly = true;
                            _numberiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_numberiddataGridViewColumn);
                            }
                            
                            DataGridViewTextBoxCell _numbernamecell = new DataGridViewTextBoxCell();
                            _numbernamecell.Value = c.name.Trim();
                            _numberrow.Cells.Add(_numbernamecell);

                            DataGridViewColumn _numbernamedataGridViewColumn = new DataGridViewColumn();
                            _numbernamedataGridViewColumn.DataPropertyName = "name";
                            _numbernamedataGridViewColumn.HeaderText = "Property";
                            _numbernamedataGridViewColumn.CellTemplate = _numbernamecell;
                            _numbernamedataGridViewColumn.Name = "columnName";
                            _numbernamedataGridViewColumn.ReadOnly = true;
                            _numbernamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnName"))
                            {
                                dataGridViewCollaterals.Columns.Add(_numbernamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbercolidcell = new DataGridViewTextBoxCell();
                            _numbercolidcell.Value = c.collateralpropertyid;
                            _numberrow.Cells.Add(_numbercolidcell);

                            DataGridViewColumn _numbercoliddataGridViewColumn = new DataGridViewColumn();
                            _numbercoliddataGridViewColumn.DataPropertyName = "collateralpropertyid";
                            _numbercoliddataGridViewColumn.HeaderText = "Property Id";
                            _numbercoliddataGridViewColumn.CellTemplate = _numbercolidcell;
                            _numbercoliddataGridViewColumn.Name = "columnPropId";
                            _numbercoliddataGridViewColumn.ReadOnly = true;
                            _numbercoliddataGridViewColumn.Visible = false;
                            _numbercoliddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnPropId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_numbercoliddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbertype_idcell = new DataGridViewTextBoxCell();
                            _numbertype_idcell.Value = c.type_id;
                            _numberrow.Cells.Add(_numbertype_idcell);

                            DataGridViewColumn _numbertype_iddataGridViewColumn = new DataGridViewColumn();
                            _numbertype_iddataGridViewColumn.DataPropertyName = "type_id";
                            _numbertype_iddataGridViewColumn.HeaderText = "Type";
                            _numbertype_iddataGridViewColumn.CellTemplate = _numbercolidcell;
                            _numbertype_iddataGridViewColumn.Name = "columnTypeId";
                            _numbertype_iddataGridViewColumn.ReadOnly = true;
                            _numbertype_iddataGridViewColumn.Visible = false;
                            _numbertype_iddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnTypeId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_numbertype_iddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numberdesccell = new DataGridViewTextBoxCell();
                            _numberdesccell.Value = c.desc.Trim();
                            _numberrow.Cells.Add(_numberdesccell);

                            DataGridViewColumn _numberdescdataGridViewColumn = new DataGridViewColumn();
                            _numberdescdataGridViewColumn.DataPropertyName = "desc";
                            _numberdescdataGridViewColumn.HeaderText = "Desc";
                            _numberdescdataGridViewColumn.CellTemplate = _numberdesccell;
                            _numberdescdataGridViewColumn.Name = "columnDesc";
                            _numberdescdataGridViewColumn.ReadOnly = true;
                            _numberdescdataGridViewColumn.Visible = false;
                            _numberdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnDesc"))
                            {
                                dataGridViewCollaterals.Columns.Add(_numberdescdataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _numbervaluecell = new DataGridViewTextBoxCell();
                            _numbervaluecell.Value = c.value;
                            _numberrow.Cells.Add(_numbervaluecell);

                            DataGridViewColumn _numbervaluedataGridViewColumn = new DataGridViewColumn();
                            _numbervaluedataGridViewColumn.DataPropertyName = "value";
                            _numbervaluedataGridViewColumn.HeaderText = "Value";
                            _numbervaluedataGridViewColumn.CellTemplate = _numbervaluecell;
                            _numbervaluedataGridViewColumn.Name = "columnValue";
                            _numbervaluedataGridViewColumn.ReadOnly = false;
                            _numbervaluedataGridViewColumn.Width = 150;
                            _numbervaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnValue"))
                            {
                                dataGridViewCollaterals.Columns.Add(_numbervaluedataGridViewColumn);
                            }

                            dataGridViewCollaterals.Rows.Add(_numberrow);
                            break;
                        case 2:
                            DataGridViewRow _stringrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _stringidcell = new DataGridViewTextBoxCell();
                            _stringidcell.Value = _rowid.ToString();
                            _stringrow.Cells.Add(_stringidcell);

                            DataGridViewColumn _stringiddataGridViewColumn = new DataGridViewColumn();
                            _stringiddataGridViewColumn.DataPropertyName = "_rowid";
                            _stringiddataGridViewColumn.HeaderText = "Id";
                            _stringiddataGridViewColumn.CellTemplate = _stringidcell;
                            _stringiddataGridViewColumn.Name = "columnId";
                            _stringiddataGridViewColumn.ReadOnly = true;
                            _stringiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_stringiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringnamecell = new DataGridViewTextBoxCell();
                            _stringnamecell.Value = c.name.Trim();
                            _stringrow.Cells.Add(_stringnamecell);

                            DataGridViewColumn _stringnamedataGridViewColumn = new DataGridViewColumn();
                            _stringnamedataGridViewColumn.DataPropertyName = "name";
                            _stringnamedataGridViewColumn.HeaderText = "Property";
                            _stringnamedataGridViewColumn.CellTemplate = _stringnamecell;
                            _stringnamedataGridViewColumn.Name = "columnName";
                            _stringnamedataGridViewColumn.ReadOnly = true;
                            _stringnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnName"))
                            {
                                dataGridViewCollaterals.Columns.Add(_stringnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringcolidcell = new DataGridViewTextBoxCell();
                            _stringcolidcell.Value = c.collateralpropertyid;
                            _stringrow.Cells.Add(_stringcolidcell);

                            DataGridViewColumn _stringcoliddataGridViewColumn = new DataGridViewColumn();
                            _stringcoliddataGridViewColumn.DataPropertyName = "collateralpropertyid";
                            _stringcoliddataGridViewColumn.HeaderText = "Property Id";
                            _stringcoliddataGridViewColumn.CellTemplate = _stringcolidcell;
                            _stringcoliddataGridViewColumn.Name = "columnPropId";
                            _stringcoliddataGridViewColumn.ReadOnly = true;
                            _stringcoliddataGridViewColumn.Visible = false;
                            _stringcoliddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnPropId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_stringcoliddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringtype_idcell = new DataGridViewTextBoxCell();
                            _stringtype_idcell.Value = c.type_id;
                            _stringrow.Cells.Add(_stringtype_idcell);

                            DataGridViewColumn _stringtype_iddataGridViewColumn = new DataGridViewColumn();
                            _stringtype_iddataGridViewColumn.DataPropertyName = "type_id";
                            _stringtype_iddataGridViewColumn.HeaderText = "Type";
                            _stringtype_iddataGridViewColumn.CellTemplate = _stringtype_idcell;
                            _stringtype_iddataGridViewColumn.Name = "columnTypeId";
                            _stringtype_iddataGridViewColumn.ReadOnly = true;
                            _stringtype_iddataGridViewColumn.Visible = false;
                            _stringtype_iddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnTypeId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_stringtype_iddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _stringdesccell = new DataGridViewTextBoxCell();
                            _stringdesccell.Value = c.desc.Trim();
                            _stringrow.Cells.Add(_stringdesccell);

                            DataGridViewColumn _stringdescdataGridViewColumn = new DataGridViewColumn();
                            _stringdescdataGridViewColumn.DataPropertyName = "desc";
                            _stringdescdataGridViewColumn.HeaderText = "Desc";
                            _stringdescdataGridViewColumn.CellTemplate = _stringdesccell;
                            _stringdescdataGridViewColumn.Name = "columnDesc";
                            _stringdescdataGridViewColumn.ReadOnly = true;
                            _stringdescdataGridViewColumn.Visible = false;
                            _stringdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnDesc"))
                            {
                                dataGridViewCollaterals.Columns.Add(_stringdescdataGridViewColumn);
                            } 

                            DataGridViewTextBoxCell _stringvaluecell = new DataGridViewTextBoxCell();
                            _stringvaluecell.Value = c.value;
                            _stringrow.Cells.Add(_stringvaluecell);

                            DataGridViewColumn _stringvaluedataGridViewColumn = new DataGridViewColumn();
                            _stringvaluedataGridViewColumn.DataPropertyName = "value";
                            _stringvaluedataGridViewColumn.HeaderText = "Value";
                            _stringvaluedataGridViewColumn.CellTemplate = _stringvaluecell;
                            _stringvaluedataGridViewColumn.Name = "columnValue";
                            _stringvaluedataGridViewColumn.ReadOnly = false;
                            _stringvaluedataGridViewColumn.Width = 150;
                            _stringvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnValue"))
                            {
                                dataGridViewCollaterals.Columns.Add(_stringvaluedataGridViewColumn);
                            }

                            dataGridViewCollaterals.Rows.Add(_stringrow);
                            break;
                        case 3:
                            DataGridViewRow _daterow = new DataGridViewRow();

                            DataGridViewTextBoxCell _dateidcell = new DataGridViewTextBoxCell();
                            _dateidcell.Value = _rowid.ToString();
                            _daterow.Cells.Add(_dateidcell);

                            DataGridViewColumn _dateiddataGridViewColumn = new DataGridViewColumn();
                            _dateiddataGridViewColumn.DataPropertyName = "_rowid";
                            _dateiddataGridViewColumn.HeaderText = "Id";
                            _dateiddataGridViewColumn.CellTemplate = _dateidcell;
                            _dateiddataGridViewColumn.Name = "columnId";
                            _dateiddataGridViewColumn.ReadOnly = true;
                            _dateiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_dateiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datenamecell = new DataGridViewTextBoxCell();
                            _datenamecell.Value = c.name.Trim();
                            _daterow.Cells.Add(_datenamecell);

                            DataGridViewColumn _datenamedataGridViewColumn = new DataGridViewColumn();
                            _datenamedataGridViewColumn.DataPropertyName = "name";
                            _datenamedataGridViewColumn.HeaderText = "Property";
                            _datenamedataGridViewColumn.CellTemplate = _datenamecell;
                            _datenamedataGridViewColumn.Name = "columnName";
                            _datenamedataGridViewColumn.ReadOnly = true;
                            _datenamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnName"))
                            {
                                dataGridViewCollaterals.Columns.Add(_datenamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datecolidcell = new DataGridViewTextBoxCell();
                            _datecolidcell.Value = c.collateralpropertyid;
                            _daterow.Cells.Add(_datecolidcell);

                            DataGridViewColumn _datecoliddataGridViewColumn = new DataGridViewColumn();
                            _datecoliddataGridViewColumn.DataPropertyName = "collateralpropertyid";
                            _datecoliddataGridViewColumn.HeaderText = "Property Id";
                            _datecoliddataGridViewColumn.CellTemplate = _datecolidcell;
                            _datecoliddataGridViewColumn.Name = "columnPropId";
                            _datecoliddataGridViewColumn.ReadOnly = true;
                            _datecoliddataGridViewColumn.Visible = false;
                            _datecoliddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnPropId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_datecoliddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datetype_idcell = new DataGridViewTextBoxCell();
                            _datetype_idcell.Value = c.type_id;
                            _daterow.Cells.Add(_datetype_idcell);

                            DataGridViewColumn _datetype_iddataGridViewColumn = new DataGridViewColumn();
                            _datetype_iddataGridViewColumn.DataPropertyName = "type_id";
                            _datetype_iddataGridViewColumn.HeaderText = "Type";
                            _datetype_iddataGridViewColumn.CellTemplate = _datetype_idcell;
                            _datetype_iddataGridViewColumn.Name = "columnTypeId";
                            _datetype_iddataGridViewColumn.ReadOnly = true;
                            _datetype_iddataGridViewColumn.Visible = false;
                            _datetype_iddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnTypeId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_datetype_iddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _datedesccell = new DataGridViewTextBoxCell();
                            _datedesccell.Value = c.desc.Trim();
                            _daterow.Cells.Add(_datedesccell);

                            DataGridViewColumn _datedescdataGridViewColumn = new DataGridViewColumn();
                            _datedescdataGridViewColumn.DataPropertyName = "desc";
                            _datedescdataGridViewColumn.HeaderText = "Desc";
                            _datedescdataGridViewColumn.CellTemplate = _datedesccell;
                            _datedescdataGridViewColumn.Name = "columnDesc";
                            _datedescdataGridViewColumn.ReadOnly = true;
                            _datedescdataGridViewColumn.Visible = false;
                            _datedescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnDesc"))
                            {
                                dataGridViewCollaterals.Columns.Add(_datedescdataGridViewColumn);
                            } 

                            DataGridViewTextBoxCell _datevaluecell = new DataGridViewTextBoxCell();
                            _datevaluecell.Value = c.value;
                            _daterow.Cells.Add(_datevaluecell);

                            DataGridViewColumn _datevaluedataGridViewColumn = new DataGridViewColumn();
                            _datevaluedataGridViewColumn.DataPropertyName = "value";
                            _datevaluedataGridViewColumn.HeaderText = "Value";
                            _datevaluedataGridViewColumn.CellTemplate = _datevaluecell;
                            _datevaluedataGridViewColumn.Name = "columnValue";
                            _datevaluedataGridViewColumn.ReadOnly = false;
                            _datevaluedataGridViewColumn.Width = 150;
                            _datevaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnValue"))
                            {
                                dataGridViewCollaterals.Columns.Add(_datevaluedataGridViewColumn);
                            }

                            dataGridViewCollaterals.Rows.Add(_daterow);
                            break;
                        case 4:
                            List<CollateralPropertyCollectionsModel> colpropsitems = rep.GetCollateralPropertyCollectionItemsList(c.collateralpropertyid);

                            DataGridViewRow _collectionrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _collectionidcell = new DataGridViewTextBoxCell();
                            _collectionidcell.Value = _rowid.ToString();
                            _collectionrow.Cells.Add(_collectionidcell);

                            DataGridViewColumn _collectioniddataGridViewColumn = new DataGridViewColumn();
                            _collectioniddataGridViewColumn.DataPropertyName = "_rowid";
                            _collectioniddataGridViewColumn.HeaderText = "Id";
                            _collectioniddataGridViewColumn.CellTemplate = _collectionidcell;
                            _collectioniddataGridViewColumn.Name = "columnId";
                            _collectioniddataGridViewColumn.ReadOnly = true;
                            _collectioniddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_collectioniddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectionnamecell = new DataGridViewTextBoxCell();
                            _collectionnamecell.Value = c.name.Trim();
                            _collectionrow.Cells.Add(_collectionnamecell);

                            DataGridViewColumn _collectionnamedataGridViewColumn = new DataGridViewColumn();
                            _collectionnamedataGridViewColumn.DataPropertyName = "name";
                            _collectionnamedataGridViewColumn.HeaderText = "Property";
                            _collectionnamedataGridViewColumn.CellTemplate = _collectionnamecell;
                            _collectionnamedataGridViewColumn.Name = "columnName";
                            _collectionnamedataGridViewColumn.ReadOnly = true;
                            _collectionnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnName"))
                            {
                                dataGridViewCollaterals.Columns.Add(_collectionnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectioncolidcell = new DataGridViewTextBoxCell();
                            _collectioncolidcell.Value = c.collateralpropertyid;
                            _collectionrow.Cells.Add(_collectioncolidcell);

                            DataGridViewColumn _collectioncoliddataGridViewColumn = new DataGridViewColumn();
                            _collectioncoliddataGridViewColumn.DataPropertyName = "collateralpropertyid";
                            _collectioncoliddataGridViewColumn.HeaderText = "Property Id";
                            _collectioncoliddataGridViewColumn.CellTemplate = _collectioncolidcell;
                            _collectioncoliddataGridViewColumn.Name = "columnPropId";
                            _collectioncoliddataGridViewColumn.ReadOnly = true;
                            _collectioncoliddataGridViewColumn.Visible = false;
                            _collectioncoliddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnPropId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_collectioncoliddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectiontype_idcell = new DataGridViewTextBoxCell();
                            _collectiontype_idcell.Value = c.type_id;
                            _collectionrow.Cells.Add(_collectiontype_idcell);

                            DataGridViewColumn _collectiontype_iddataGridViewColumn = new DataGridViewColumn();
                            _collectiontype_iddataGridViewColumn.DataPropertyName = "type_id";
                            _collectiontype_iddataGridViewColumn.HeaderText = "Type";
                            _collectiontype_iddataGridViewColumn.CellTemplate = _collectiontype_idcell;
                            _collectiontype_iddataGridViewColumn.Name = "columnTypeId";
                            _collectiontype_iddataGridViewColumn.ReadOnly = true;
                            _collectiontype_iddataGridViewColumn.Visible = false;
                            _collectiontype_iddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnTypeId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_collectiontype_iddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _collectiondesccell = new DataGridViewTextBoxCell();
                            _collectiondesccell.Value = c.desc.Trim();
                            _collectionrow.Cells.Add(_collectiondesccell);

                            DataGridViewColumn _collectiondescdataGridViewColumn = new DataGridViewColumn();
                            _collectiondescdataGridViewColumn.DataPropertyName = "desc";
                            _collectiondescdataGridViewColumn.HeaderText = "Desc";
                            _collectiondescdataGridViewColumn.CellTemplate = _collectiondesccell;
                            _collectiondescdataGridViewColumn.Name = "columnDesc";
                            _collectiondescdataGridViewColumn.ReadOnly = true;
                            _collectiondescdataGridViewColumn.Visible = false;
                            _collectiondescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnDesc"))
                            {
                                dataGridViewCollaterals.Columns.Add(_collectiondescdataGridViewColumn);
                            } 

                            DataGridViewComboBoxCell _collectionvaluecell = new DataGridViewComboBoxCell();
                            _collectionvaluecell.DataSource = colpropsitems;
                            _collectionvaluecell.ValueMember = "value";
                            _collectionvaluecell.DisplayMember = "value";
                            _collectionvaluecell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                            _collectionvaluecell.FlatStyle = FlatStyle.Flat;
                            _collectionrow.Cells.Add(_collectionvaluecell);

                            DataGridViewColumn _collectionvaluedataGridViewColumn = new DataGridViewColumn();
                            _collectionvaluedataGridViewColumn.DataPropertyName = "value";
                            _collectionvaluedataGridViewColumn.HeaderText = "Value";
                            _collectionvaluedataGridViewColumn.CellTemplate = _collectionvaluecell;
                            _collectionvaluedataGridViewColumn.Name = "columnValue";
                            _collectionvaluedataGridViewColumn.ReadOnly = false;
                            _collectionvaluedataGridViewColumn.Width = 150;
                            _collectionvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnValue"))
                            {
                                dataGridViewCollaterals.Columns.Add(_collectionvaluedataGridViewColumn);
                            }

                            dataGridViewCollaterals.Rows.Add(_collectionrow);
                            break;
                        case 5:
                            DataGridViewRow _clientrow = new DataGridViewRow();

                            DataGridViewTextBoxCell _clientidcell = new DataGridViewTextBoxCell();
                            _clientidcell.Value = _rowid.ToString();
                            _clientrow.Cells.Add(_clientidcell);

                            DataGridViewColumn _clientiddataGridViewColumn = new DataGridViewColumn();
                            _clientiddataGridViewColumn.DataPropertyName = "_rowid";
                            _clientiddataGridViewColumn.HeaderText = "Id";
                            _clientiddataGridViewColumn.CellTemplate = _clientidcell;
                            _clientiddataGridViewColumn.Name = "columnId";
                            _clientiddataGridViewColumn.ReadOnly = true;
                            _clientiddataGridViewColumn.Width = 30;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_clientiddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientnamecell = new DataGridViewTextBoxCell();
                            _clientnamecell.Value = c.name.Trim();
                            _clientrow.Cells.Add(_clientnamecell);

                            DataGridViewColumn _clientnamedataGridViewColumn = new DataGridViewColumn();
                            _clientnamedataGridViewColumn.DataPropertyName = "name";
                            _clientnamedataGridViewColumn.HeaderText = "Property";
                            _clientnamedataGridViewColumn.CellTemplate = _clientnamecell;
                            _clientnamedataGridViewColumn.Name = "columnName";
                            _clientnamedataGridViewColumn.ReadOnly = true;
                            _clientnamedataGridViewColumn.Width = 300;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnName"))
                            {
                                dataGridViewCollaterals.Columns.Add(_clientnamedataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientcolidcell = new DataGridViewTextBoxCell();
                            _clientcolidcell.Value = c.collateralpropertyid;
                            _clientrow.Cells.Add(_clientcolidcell);

                            DataGridViewColumn _clientcoliddataGridViewColumn = new DataGridViewColumn();
                            _clientcoliddataGridViewColumn.DataPropertyName = "collateralpropertyid";
                            _clientcoliddataGridViewColumn.HeaderText = "Property Id";
                            _clientcoliddataGridViewColumn.CellTemplate = _clientcolidcell;
                            _clientcoliddataGridViewColumn.Name = "columnPropId";
                            _clientcoliddataGridViewColumn.ReadOnly = true;
                            _clientcoliddataGridViewColumn.Visible = false;
                            _clientcoliddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnPropId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_clientcoliddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clienttype_idcell = new DataGridViewTextBoxCell();
                            _clienttype_idcell.Value = c.type_id;
                            _clientrow.Cells.Add(_clienttype_idcell);

                            DataGridViewColumn _clienttype_iddataGridViewColumn = new DataGridViewColumn();
                            _clienttype_iddataGridViewColumn.DataPropertyName = "type_id";
                            _clienttype_iddataGridViewColumn.HeaderText = "Type";
                            _clienttype_iddataGridViewColumn.CellTemplate = _clienttype_idcell;
                            _clienttype_iddataGridViewColumn.Name = "columnTypeId";
                            _clienttype_iddataGridViewColumn.ReadOnly = true;
                            _clienttype_iddataGridViewColumn.Visible = false;
                            _clienttype_iddataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnTypeId"))
                            {
                                dataGridViewCollaterals.Columns.Add(_clienttype_iddataGridViewColumn);
                            }

                            DataGridViewTextBoxCell _clientdesccell = new DataGridViewTextBoxCell();
                            _clientdesccell.Value = c.desc.Trim();
                            _clientrow.Cells.Add(_clientdesccell);

                            DataGridViewColumn _clientdescdataGridViewColumn = new DataGridViewColumn();
                            _clientdescdataGridViewColumn.DataPropertyName = "desc";
                            _clientdescdataGridViewColumn.HeaderText = "Desc";
                            _clientdescdataGridViewColumn.CellTemplate = _clientdesccell;
                            _clientdescdataGridViewColumn.Name = "columnDesc";
                            _clientdescdataGridViewColumn.ReadOnly = true;
                            _clientdescdataGridViewColumn.Visible = false;
                            _clientdescdataGridViewColumn.Width = 150;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnDesc"))
                            {
                                dataGridViewCollaterals.Columns.Add(_clientdescdataGridViewColumn);
                            } 

                            DataGridViewTextBoxCell _clientvaluecell = new DataGridViewTextBoxCell();
                            _clientvaluecell.Value = c.value;
                            _clientrow.Cells.Add(_clientvaluecell);

                            DataGridViewColumn _clientvaluedataGridViewColumn = new DataGridViewColumn();
                            _clientvaluedataGridViewColumn.DataPropertyName = "value";
                            _clientvaluedataGridViewColumn.HeaderText = "Value";
                            _clientvaluedataGridViewColumn.CellTemplate = _clientvaluecell;
                            _clientvaluedataGridViewColumn.Name = "columnValue";
                            _clientvaluedataGridViewColumn.ReadOnly = false;
                            _clientvaluedataGridViewColumn.Width = 150;
                            _clientvaluedataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            if (!this.dataGridViewCollaterals.Columns.Contains("columnValue"))
                            {
                                dataGridViewCollaterals.Columns.Add(_clientvaluedataGridViewColumn);
                            }

                            dataGridViewCollaterals.Rows.Add(_clientrow);
                            break;
                    }
                    _rowid++;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClearOwner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSelectOwner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddOwner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void dataGridViewCollaterals_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCollaterals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewCollaterals.SelectedRows.Count != 0)
                { 

                    lblCollateralName.Text = "Name: " + dataGridViewCollaterals.CurrentRow.Cells["columnName"].Value.ToString();
                    lblCollateralDescription.Text = "Description: " + dataGridViewCollaterals.CurrentRow.Cells["columnDesc"].Value.ToString(); 
                }
                if (dataGridViewCollaterals.SelectedRows.Count == 0)
                {
                    lblCollateralName.Text = string.Empty;
                    lblCollateralDescription.Text = string.Empty; 
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
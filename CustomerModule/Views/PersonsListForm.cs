using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace CustomerModule.Views
{
    public partial class PersonsListForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        IQueryable<ClientModel> _personClients;
        #endregion "Private Fields"

        #region "Constructor"
        public PersonsListForm(int _user, string Conn)
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnAddNewPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddPersonForm anpf = new AddPersonForm(connection) { Owner = this };
                anpf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PersonsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                _personClients = rep.GetPersonsList().AsQueryable();

                dataGridViewPersons.AutoGenerateColumns = false;
                this.dataGridViewPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourcePersons.DataSource = rep.GetPersonsList();
                dataGridViewPersons.DataSource = bindingSourcePersons;
                groupBox1.Text = bindingSourcePersons.Count.ToString();

                AutoCompleteStringCollection acscfrstnm = new AutoCompleteStringCollection();
                acscfrstnm.AddRange(this.AutoComplete_FirstNames());
                txtFirstName.AutoCompleteCustomSource = acscfrstnm;
                txtFirstName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtFirstName.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsclstnm = new AutoCompleteStringCollection();
                acsclstnm.AddRange(this.AutoComplete_LastNames());
                txtLastName.AutoCompleteCustomSource = acsclstnm;
                txtLastName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtLastName.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_FirstNames()
        {
            try
            {
                var first_namesquery = from st in rep.GetPersonsList() 
                                    select st.first_name;
                return first_namesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_LastNames()
        {
            try
            {
                var last_namesquery = from st in rep.GetPersonsList() 
                                    select st.last_name;
                return last_namesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourcePersons.DataSource = null;
                //set the datasource to a method
                bindingSourcePersons.DataSource = rep.GetPersonsList();
                groupBox1.Text = bindingSourcePersons.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewPersons.Rows)
                {
                    dataGridViewPersons.Rows[dataGridViewPersons.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewPersons.Rows.Count - 1;
                    bindingSourcePersons.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewPersons.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.ClientModel person = (DAL.ClientModel)bindingSourcePersons.Current;
                    EditPersonForm epf = new EditPersonForm(person, user, connection) { Owner = this };
                    epf.Text = person.client_name.ToUpper().Trim();
                    epf.ShowDialog();
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
                if (dataGridViewPersons.SelectedRows.Count != 0)
                {
                    DAL.ClientModel person = (DAL.ClientModel)bindingSourcePersons.Current;
                    EditPersonForm epf = new EditPersonForm(person, user, connection) { Owner = this };
                    epf.Text = person.client_name.ToUpper().Trim();
                    epf.DisableControls();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewPersons_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewPersons.SelectedRows.Count != 0)
                {
                    DAL.ClientModel person = (DAL.ClientModel)bindingSourcePersons.Current;
                    EditPersonForm epf = new EditPersonForm(person, user, connection) { Owner = this };
                    epf.Text = person.client_name.ToUpper().Trim();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewPersons.SelectedRows.Count != 0)
                {
                    DAL.Person person = (DAL.Person)bindingSourcePersons.Current;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Person\n" + person.first_name.ToString().Trim().ToUpper() + person.last_name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeletePerson(person);
                        RefreshGrid();

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                this.bindingSourcePersons.DataSource = null;
                var filter = CreateFilter(_personClients);
                // set the filter
                this.bindingSourcePersons.DataSource = filter;
                groupBox1.Text = bindingSourcePersons.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<ClientModel> CreateFilter(IQueryable<ClientModel> _pClients)
        {
            //none
            if (string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtLastName.Text))
            {
                return _pClients;
            }
            //all
            if (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text))
            {
                _pClients = null;
                string _FirstName = txtFirstName.Text.Trim();
                string _LastName = txtLastName.Text.Trim();
                _pClients = (from st in _personClients
                            where st.first_name.StartsWith(_FirstName)
                            where st.last_name.StartsWith(_LastName) 
                            select st).AsQueryable();
                return _pClients;
            }
            //firstname
            if (!string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtLastName.Text) )
            {
                _pClients = null;
                string _FirstName = txtFirstName.Text.Trim();
                _pClients = (from st in _personClients
                             where st.first_name.Trim().StartsWith(_FirstName) 
                             select st).AsQueryable();
                return _pClients;
            }
            //lastname  
            if (string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text) )
            {
                _pClients = null;
                string _LastName = txtLastName.Text.Trim();
                _pClients = (from st in _personClients 
                             where st.last_name.StartsWith(_LastName) 
                             select st).AsQueryable();
                return _pClients;
            }
            return _pClients;
        }
        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtLastName_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        #endregion "Private Methods"




    }
}
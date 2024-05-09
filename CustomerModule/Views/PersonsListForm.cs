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
using System.Data.SqlClient;

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
                //_personClients = rep.GetPersonsList().AsQueryable();

                dataGridViewPersons.AutoGenerateColumns = false;
                this.dataGridViewPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //bindingSourcePersons.DataSource = rep.GetPersonsList();
                //dataGridViewPersons.DataSource = bindingSourcePersons;
                //groupBox1.Text = bindingSourcePersons.Count.ToString();

                this.RefreshGrid(1);

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

        int NO_OF_RECORDS_PER_PAGE = 5;
        int NO_OF_PAGES_TO_DISPLAY = 5;

        public void RefreshGrid(int pageIndex)
        {
            try
            {
                NO_OF_RECORDS_PER_PAGE = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NO_OF_RECORDS_PER_PAGE"]);
                int no_of_records_per_page_from_db = rep.get_no_of_records_per_page();
                NO_OF_RECORDS_PER_PAGE = no_of_records_per_page_from_db;
                NO_OF_PAGES_TO_DISPLAY = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NO_OF_PAGES_TO_DISPLAY"]);

                string[] conn_str_arr = connection.Split(';');
                string data_source = string.Empty;
                string data_base = string.Empty;
                string integrated_security = string.Empty;

                for (int i = 0; i < conn_str_arr.Length; i++)
                {
                    if (i == 2)
                    {
                        string[] data_source_arr = conn_str_arr[2].Split('=');
                        data_source = data_source_arr[2];
                    }
                    if (i == 3)
                    {
                        string[] data_base_arr = conn_str_arr[3].Split('=');
                        data_base = data_base_arr[1];
                    }
                    if (i == 4)
                    {
                        string[] integrated_security_arr = conn_str_arr[4].Split('=');
                        integrated_security = integrated_security_arr[1];
                    }
                }

                string constring = @"Data Source=" + data_source + @";Initial Catalog=" + data_base + @";Integrated Security=" + integrated_security;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("GetPersonsPageWise", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                        cmd.Parameters.AddWithValue("@PageSize", NO_OF_RECORDS_PER_PAGE);
                        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        BindGrid(dt);
                        con.Close();
                        int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                        this.PopulatePager(recordCount, pageIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(NO_OF_RECORDS_PER_PAGE));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + NO_OF_PAGES_TO_DISPLAY - 1 < NO_OF_PAGES_TO_DISPLAY ? currentPage : 1;
            endIndex = pageCount > NO_OF_PAGES_TO_DISPLAY ? NO_OF_PAGES_TO_DISPLAY : pageCount;
            if (currentPage > NO_OF_PAGES_TO_DISPLAY % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (NO_OF_PAGES_TO_DISPLAY - currentPage) + 1;
            }

            if (endIndex - (NO_OF_PAGES_TO_DISPLAY - 1) > startIndex)
            {
                startIndex = endIndex - (NO_OF_PAGES_TO_DISPLAY - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - NO_OF_PAGES_TO_DISPLAY) + 1) > 0 ? (endIndex - NO_OF_PAGES_TO_DISPLAY) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "First", Value = "1" });
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = "Last", Value = pageCount.ToString() });
            }

            //Clear existing Pager Buttons.
            pnlPager.Controls.Clear();

            //Loop and add Buttons for Pager.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(38 * count, 5);
                btnPage.Size = new System.Drawing.Size(40, 20);
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.BackColor = Color.LimeGreen;
                btnPage.ForeColor = Color.Black;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                pnlPager.Controls.Add(btnPage);
                count++;

                if (page.Selected)
                {
                    btnPage.BackColor = Color.Magenta;
                    btnPage.ForeColor = Color.Black;
                }
            }
        }

        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.RefreshGrid(int.Parse(btnPager.Name));
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
            if (!string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtLastName.Text))
            {
                _pClients = null;
                string _FirstName = txtFirstName.Text.Trim();
                _pClients = (from st in _personClients
                             where st.first_name.Trim().StartsWith(_FirstName)
                             select st).AsQueryable();
                return _pClients;
            }
            //lastname  
            if (string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text))
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
                        RefreshGrid(1);

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
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

        private void dataGridViewPersons_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            { 
                Console.WriteLine(e.Exception);
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }

        private void BindGrid(DataTable dt)
        {
            try
            {
                //set the datasource to null
                bindingSourcePersons.DataSource = null;
                //set the datasource to a method
                bindingSourcePersons.DataSource = dt;
                dataGridViewPersons.DataSource = bindingSourcePersons;
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

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

    }


}